using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;
using libMPSSEWrapper.Types;

namespace Tas1945_mon
{
	public partial class MainForm : Form
	{
		public	Tas1945_Uc_RawImage g_ucRawImage;
		public	Tas1945_Uc_RawPixels g_ucRawPixels;

		public	OpenFileDialog g_openFileDlg = new OpenFileDialog ();

		private string g_strTitle = "GUI Ver 2.77";
		// 20240215 GitHub version v2.77 배포

		public DirectoryInfo dirPixelCsvFolder = new DirectoryInfo (Application.StartupPath + @"\Data\");

		public Tas1945_RegForm g_fTas1945RegForm;
		public Tas1945_PixelChartForm g_fPixelChartForm;

		public UDPSocket g_clsUDPClient;

		public Thread g_thrImage;
		
		// SERIAL SETTING --------------------------------------------------------
		public SerialPort serial = new SerialPort();       // Set Serial Port
		private const int BAURATE = 115200;                   // Set Baurate
		private const int DATABITS = 8;                     // Set BataBits
		private const StopBits STOPBITS = (StopBits)1;      // Set StopBits
		private const Parity PARITY = (Parity)0;            // Set Parity
		private Mutex mutex = new Mutex();

		//private const string dialogInitPath    = "c:\\";
		public string dialogInitPath = "c:\\Cal_buf_Info\\";
		private const string dialogFilter = "Csv File (*.csv)|*.csv|All Files (*,*)|*.*";
		private const int dialogFilterIndex = 2;

		public bool cal25_flag = false;
		public bool cal35_flag = false;
		public bool cal45_flag = false;

		public bool Dataverify_flag = false;

		public bool DarkAvg_flag = false;

		public bool cal_mode = false;
		public bool sensitivity_cal_flag = false;
		public bool DP_apply_flag=false;
		public bool StoN_flag = false;
		public bool Signal_flag = false;
		public bool Noise_flag = false;
		public bool Noise_filter_flag = false;
		public bool DPC_apply_flag = false;
		public bool ISP_offset_flag = false;

		public bool g_bContinueRead;
		public bool g_bFistImage;
		public int g_ContinuePixelRead_Cnt = 0;
//		public double g_dbMaxScale = 33200;
//		public double g_dbMinScale = 32400;

		decimal g_decPreClockValue;

		public string Ret_Log_String = "";

		/// <summary>
		/// 
		/// </summary>
		public MainForm ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load (object sender, EventArgs e)
		{
			DateTime buildDate = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
			g_strTitle = this.Text + " " + g_strTitle + "  [ Built : " + buildDate + " ]";

			this.Text = g_strTitle;

			Initialize ();
			Select_RawImageType ();
			ToolHint ();
		}

		/// <summary>
		/// 
		/// </summary>
		private void Select_RawImageType ()
		{
			if (TGSGet (tgsPixels) == false)
			{
				nudPixelSpace.Enabled = false;

				g_ucRawImage = new Tas1945_Uc_RawImage (this);
				UserControlRawImage (panMain, g_ucRawImage);
			}
			else
			{
				nudPixelSpace.Enabled = true;

				g_ucRawPixels = new Tas1945_Uc_RawPixels (this);
				UserControlRawPixel (panMain, g_ucRawPixels);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void Initialize ()
		{
			try
			{
				g_clsUDPClient = new UDPSocket (this);

				//ComButtonEnable (false);

				TGSSet (tgsDebugLog, false);
				TGSSet (tgsCsvSave, false);
				g_bCsvOn = false;
				TGSSet (tgsImageX10, false);

				RBSet (rbSetPixel1, true);
				
				// default rb 변경 - 23' 12/18 조남인
				//RBSet (rbNormal, true);
				RBSet(rbNormal, true);

				NUDSet (nudInterval, 50);

				if (TGSGet (tgsNetMode) == true)
				{
					NUDSet (nudTcpPort, 5000);
					NUDSet (nupSetPort, 5000);
				}
				else
				{
					NUDSet (nudTcpPort, 10000);
					NUDSet (nupSetPort, 10000);
				}

				TcpIpButtonEnable (false);

				if (rbClient.Checked == true)	BTNSet (btnTcpConnect, "Connect");
				else							BTNSet (btnTcpConnect, "Start");

				BTNSet (btnGetPixelInfo, "Read");

				//Tas1945_LoadPixelOffset (dirPixelCsvFolder + "Pixel_Offset.csv");

				Tas1945_RegisterInit ();
							
				tssConnectStatus.Text = "Connected : No";

				NUDSet (nudSetClock, 100);
				g_decPreClockValue = nudSetClock.Value;

				NUDSet (nudClockDelay, 1);
				TGSSet (tgsReadEdge, false);

				nudMaxVal.Maximum = 32767;
				nudMaxVal.Minimum = -32767;
				nudMinVal.Maximum = 32766;
				nudMinVal.Minimum = -32768;

				nudSetCenterValue.Maximum = 32767;
				nudSetCenterValue.Minimum = -32768;

				NUDSet (nudMaxVal, 300);
				NUDSet (nudMinVal, -300);

				NUDSet (nudSetCenterValue, 0);

				cbReg127mode.SelectedIndex = 0;

				for (int i = 0; i < 4860; i++)
                {
					row = (int)i / COL;
					col = i - row * COL;

					Active_Line_Ctrl[row,col] = 1;
					Active_XY_Ctrl[row,col] = 1;
				}

				btnRegRD_Set1.Enabled = false;
				btnRegRD_Set2.Enabled = false;

				cbReg24yearSetting.Checked = true;

				rbSetPixel1.Enabled = false;
				rbSetPixel2.Enabled = false;
				rbSetPixel3.Enabled = false;
				rbSetPixel4.Enabled = false;
				rbSetPixel5.Enabled = false;

				cbSensitivy_cal.Enabled = false;
				tbGain.Enabled = false;
				btnGain.Enabled = false;

				cbDP_apply.Enabled = false;
				StoN_ck.Enabled = false;
				Signal_ck.Enabled = false;
				Noise_ck.Enabled = false;
				tbStoN_max.Enabled = false;
				tbStoN_min.Enabled = false;
				tbSignal_max.Enabled = false;
				tbSignal_min.Enabled = false;
				tbNoise_max.Enabled = false;
				tbNoise_min.Enabled = false;
				btnDP_cal.Enabled = false;

				cbNF_apply.Enabled = false;
				tbKalmanError.Enabled = false;
				btnKalmanError.Enabled=false;

				cbDPC_apply.Enabled = false;

				btnChartClear.Enabled = false;

				rbOffsetDisable.Checked = true;

				cbOffset_apply.Checked = true;

				lbOdd.Color = Color.Black;
				lbEven.Color = Color.Black;

				g_byReadDspMode = 2;

				g_bContinueRead = false;

				RBSet (rbTestPixel, true);
				if (RBGet (rbTestPixel) == true)
				{
					g_iCsvSaveMode = 0;
				}
				else if (RBGet (rbChartPixel) == true)
				{
					g_iCsvSaveMode = 1;
				}
				else
				{
					g_iCsvSaveMode = 0;
				}

				tmImageDsp.Start ();					//	Timer 에서 display
			}
			catch (Exception)
			{
				;	//
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosed (object sender, FormClosedEventArgs e)
		{
			TcpUdp_Close ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bEnable"></param>
		public void TcpIpButtonEnable (bool bEnable)
		{
			btnRegWrite.Enabled = bEnable;
			btnRegRead.Enabled = bEnable;
			btnGetPixelInfo.Enabled = bEnable;
			btnIpSetup.Enabled = bEnable;
			btnTas1945RegCtrl.Enabled = bEnable;
			btnSetClock.Enabled = bEnable;
			btnSetRead.Enabled = bEnable;
			btnSetAverage.Enabled = bEnable;
			btnRegAllRead.Enabled = bEnable;
			btnReadPushMode.Enabled = bEnable;
			btnSetReadPLStart.Enabled = bEnable;
			btnGetSetupInfo.Enabled = bEnable;
			btnResend.Enabled = bEnable;
			btnReset.Enabled = bEnable;

			rbServer.Enabled = !bEnable;
			rbClient.Enabled = !bEnable;
			ipAddress.Enabled = !bEnable;
			nudTcpPort.Enabled = !bEnable;

			tgsNetMode.Enabled = !bEnable;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLogClear_Click (object sender, EventArgs e)
		{	
			rtbLog.Clear ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pan"></param>
		/// <param name="uc"></param>
		private void UserControlRawImage (Panel pan, UserControl uc)
		{
			try
			{
				pan.Controls.Clear ();
				pan.Controls.Add (uc);
				uc.Dock = DockStyle.Fill;
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pan"></param>
		/// <param name="uc"></param>
		private void UserControlRawPixel (Panel pan, UserControl uc)
		{
			try
			{
				pan.Controls.Clear ();
				pan.Controls.Add (uc);
				uc.Dock = DockStyle.Fill;
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImageClear_Click (object sender, EventArgs e)
		{
			try
			{
				if (TGSGet (tgsPixels) == false)
				{
					g_ucRawImage.ClearBitmap ();
				}
				else
				{
					g_ucRawPixels.ClearPixels ();
				}
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTcpConnect_Click (object sender, EventArgs e)
		{
			try
			{
				string strIp;
				int iTcpPort;

				strIp = ipAddress.Text;
				iTcpPort = Convert.ToInt32 (NUDGet (nudTcpPort));

				if (BTNGet (btnTcpConnect) == "Connect")
				{
					TcpIpButtonEnable (true);

					if (RBGet (rbClient) == true)
					{
						BTNSet (btnTcpConnect, "Disconnect");

						tssConnectStatus.Text = (TGSGet (tgsNetMode) == true) ? "TCP " : "UDP " + "Connected : Server " + strIp + ":" + iTcpPort;

						if (TGSGet (tgsNetMode) == true)
						{
							TcpIp_ClientConnectToServer (strIp, iTcpPort);
						}
						else
						{
							g_clsUDPClient.Setup (false, strIp, iTcpPort);

							Tas1945_DeviceInitSetup ();
						}
					}
					else if (RBGet (rbServer) == true)
					{
						BTNSet (btnTcpConnect, "Stop");

						string ip = GetLocalIP ();
						int port = Convert.ToInt32 (NUDGet (nudTcpPort));

						ipAddress.Text = ip;
					
						if (TGSGet (tgsNetMode) == true)
						{
							TcpIp_ServerStart (ip, port);
						}
						else
						{
							g_clsUDPClient.Setup (true, strIp, iTcpPort);

							Tas1945_DeviceInitSetup ();
						}
					}
				}
				else
				{
					if (BTNGet (btnGetPixelInfo) == "Stop")	
					{
						GetPixelInfoRead_Click ();
					}

					TcpIpButtonEnable (false);

					tssConnectStatus.Text = "Connected : No";

					if (RBGet (rbClient) == true)
					{
						BTNSet (btnTcpConnect, "Connect");

						if (TGSGet (tgsNetMode) == true)
						{
							TcpIp_ClientDisconnectFromServer ();
						}
						else
						{
							Tas1945_PL_StatusCheck (false);

							g_clsUDPClient.Close ();
						}
					}
					else if (RBGet (rbServer) == true)
					{
						BTNSet (btnTcpConnect, "Start");

						if (TGSGet (tgsNetMode) == true)
						{
							TcpIp_ServerStop ();
						}
						else
						{
							Tas1945_PL_StatusCheck (false);

							g_clsUDPClient.Close ();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbRegData_KeyPress (object sender, KeyPressEventArgs e)
		{
			HexCheckForInputChar (sender, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbClient_CheckedChanged (object sender, EventArgs e)
		{
			if (BTNGet (btnTcpConnect) == "Disconnect")
			{
				TcpIp_ClientDisconnectFromServer ();
			}
			else if (BTNGet (btnTcpConnect) == "Stop")
			{
				TcpIp_ServerStop ();
			}

            BTNSet (btnTcpConnect, "Connect");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbServer_CheckedChanged (object sender, EventArgs e)
		{
			if (BTNGet (btnTcpConnect) == "Disconnect")
			{
				TcpIp_ClientDisconnectFromServer ();
			}
			else if (BTNGet (btnTcpConnect) == "Stop")
			{
				TcpIp_ServerStop ();
			}

			BTNSet (btnTcpConnect, "Start");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSpiWrite_Click (object sender, EventArgs e)
		{	
			Tas1945_RegisterWrite ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSpiRead_Click (object sender, EventArgs e)
		{
			Tas1945_RegisterRead (1);
		}

		/// <summary>
		/// 
		/// </summary>
		private void GetPixelInfoRead_Click ()
		{
			bool	bStatus;

			try
			{
				if ((TGSGet (tgsContinue) == true) || (RBGet (rbGuiAvr) == true))
				{
					if (BTNGet (btnGetPixelInfo) == "Read")
					{	
						//	PL read
						Tas1945_PL_StatusCheck (true);

	//					if (BTNGet (btnSetReadPLStart) == "PL Read")
	//					{	
	//						BTNSet (btnSetReadPLStart, "PL Stop");
	//		
	//						Tas1945_PLReadCtrl (true);
	//		
	//						if (Resp_CheckWait (5000) == false)		return;
	//					}

						if (TGSGet (tgsNetMode) == false)
						{ 
							if (g_bPLReadStart == false)
							{
								ERR ("PL Read not enable !!!");
								return;
							}
						}

						BTNSet (btnGetPixelInfo, "Stop");
						tmPixelCountinue.Interval = (int)NUDGet (nudInterval);
						if((int)NUDGet(nudInterval) < 10)
                        {
							tmImageDsp.Interval = (int)NUDGet(nudInterval);   // 120frame 을 위해 추가함 - 20230817 조남인
						}

						Kalman_Init ();
						LPF_IIR_Init ((double)NUDGet (nudLpfSensitive));

						g_bFistImage = false;

						if (TGSGet (tgsCsvSave) == true)
						{
							g_bCsvOn = true;

							if (RBGet (rbTestPixel) == true)
							{
								g_iCsvSaveMode = 0;

								TestPixelLog_CsvFileOpen ();
							}
							else if (RBGet (rbChartPixel) == true)
							{
								g_iCsvSaveMode = 1;
								RawLog_CsvFileOpen ();
							}
							else
							{
								RBSet (rbTestPixel, true);
								g_iCsvSaveMode = 0;

								TestPixelLog_CsvFileOpen ();
							}
						}
						else
						{
							g_bCsvOn = false;
						}

						tmPixelCountinue.Start ();
						//tmFrameCnt.Start ();

						bStatus = false;

						if(tmImageDsp.Enabled == false)
							tmImageDsp.Start();
						//tmImageDsp.Interval = 100;
					}
					else
					{
						BTNSet (btnGetPixelInfo, "Read");
					
						if (g_iCsvSaveMode == 1)
						{
							RawLog_CsvFileClose ();
						}
						else
						{	
							Save_TestPixelCsv ();

							TestPixelLog_CsvFileClose ();
						}	

						tmImageDsp.Stop ();
						tmPixelCountinue.Stop ();
						//tmFrameCnt.Stop();

						Tas1945_PL_StatusCheck (false);

	//					if (BTNGet (btnSetReadPLStart) == "PL Stop")
	//					{	
	//						BTNSet (btnSetReadPLStart, "PL Read");
	//		
	//						Tas1945_PLReadCtrl (false);
	//		
	//						if (Resp_CheckWait (5000) == false)		return;
	//					}

						bStatus = true;
					}

					cbReg127mode.Enabled = bStatus;
					cbReg24yearSetting.Enabled = bStatus;

					btnRegWrite.Enabled = bStatus;
					btnRegWR_Set1.Enabled = bStatus;
					btnRegWR_Set2.Enabled = bStatus;
					//btnRegRD_Set1.Enabled = bStatus;
					//btnRegRD_Set2.Enabled = bStatus;
					btnRegRead.Enabled = bStatus;
					btnTas1945RegCtrl.Enabled = bStatus;
					btnIpSetup.Enabled = bStatus;
					btnRegAllRead.Enabled = bStatus;
					btnSetClock.Enabled = bStatus;
					btnReadPushMode.Enabled = bStatus;
					btnSetRead.Enabled = bStatus;
					btnSetAverage.Enabled = bStatus;
					btnGetSetupInfo.Enabled = bStatus;
					btnSetReadPLStart.Enabled = bStatus;
					btnResend.Enabled = bStatus;
					btnReset.Enabled = bStatus;
				
					tgsContinue.Enabled = bStatus;
				
					rbNormal.Enabled = bStatus;
					rbFpgaAvr.Enabled = bStatus;
					rbGuiAvr.Enabled = bStatus;
					rbMoveAvr.Enabled= bStatus;

					tgsCsvSave.Enabled = bStatus;

					nudAvrCnt.Enabled = bStatus;

					tgsRefVal.Enabled = bStatus;

					rbOffsetDisable.Enabled = bStatus;
					rbDark_X_Offset.Enabled = bStatus;
					rbDark_Y_Offset.Enabled	= bStatus;
					rbAvrOffset.Enabled = bStatus;

					nudSetCenterValue.Enabled = bStatus;
					nudDark_X.Enabled = bStatus;
					nudDark_Y.Enabled = bStatus;
					nudPixelMeasure.Enabled = bStatus;

					g_iAvrCount = 0;

					Array.Clear	(g_aiOffAvrData, 0, g_aiOffAvrData.Length);

					s_bInitKalamn = false;

					g_iMoveAvrCnt = 0;
					g_iMoveAvrCnt_Cal = 0;
					g_iMonteAvrCnt_Cal = 0;
					g_bMoveAvrDsp = false;

					g_iOffPixelCnt = 0;
					g_bOffPixelApply = false;

					Pulse_cnt_flag = false;
					Pulse_cnt = 0;

					g_iBuffer_no = 1;
					g_iBuffer_Cal_no = 1;
					g_iBuffer_Monte_no = 1;
					g_iBuffer_cnt = 0;

					StoN_max = Convert.ToDouble(TBGet(tbStoN_max));
					StoN_min = Convert.ToDouble(TBGet(tbStoN_min));
					Signal_max = Convert.ToDouble(TBGet(tbSignal_max));
					Signal_min = Convert.ToDouble(TBGet(tbSignal_min));
					Noise_max = Convert.ToDouble(TBGet(tbNoise_max));
					Noise_min = Convert.ToDouble(TBGet(tbNoise_min));

					g_iOffAvfrCnt = 0;
					g_bOffAvrApply = false;

					if (g_fTas1945RegForm != null)
					{
						g_fTas1945RegForm.btnTas1945Init.Enabled = bStatus;
						g_fTas1945RegForm.btnTas1945InitClose.Enabled = bStatus;
						g_fTas1945RegForm.btnSetReg127.Enabled = bStatus;
						g_fTas1945RegForm.btnSetReg190.Enabled = bStatus;
						g_fTas1945RegForm.btnSetReg191.Enabled = bStatus;
						g_fTas1945RegForm.btnSetReg156.Enabled = bStatus;
						g_fTas1945RegForm.btnSetReg157.Enabled = bStatus;
						g_fTas1945RegForm.tcRegControl.Enabled = bStatus;
					}

					g_bContinueRead = !bStatus;

					if (BTNGet (btnGetPixelInfo) == "Read")		return;
				}
				else
				{
					if (TGSGet (tgsNetMode) == false)
					{
						if (g_bPLReadStart == false)
						{
							ERR ("PL Read not enable !!!");
							return;
						}
					}
				}

				Tas1945_GetPixelInfo ();			
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void PushModeRead_Click ()
		{
			bool	bStatus;

			if (BTNGet (btnReadPushMode) == "Push Read")
			{
				Tas1945_PL_StatusCheck (true);	

				if (g_bPLReadStart == false)
				{
					ERR ("PL Read not enable !!!");
					return;
				}

				RBSet (rbFpgaAvr, true);

				BTNSet (btnReadPushMode, "Push Stop");

				g_bFistImage = false;

				if (TGSGet (tgsCsvSave) == true)
				{
					g_bCsvOn = true;

					if (RBGet (rbTestPixel) == true)
					{
						g_iCsvSaveMode = 0;

						TestPixelLog_CsvFileOpen ();
					}
					else if (RBGet (rbChartPixel) == true)
					{
						g_iCsvSaveMode = 1;
						RawLog_CsvFileOpen ();
					}
					else
					{
						RBSet (rbTestPixel, true);
						g_iCsvSaveMode = 0;

						TestPixelLog_CsvFileOpen ();
					}
				}
				else
				{
					g_bCsvOn = false;
				}

				bStatus = false;

				//RBSet (rbOffNormal, true);

				Thread.Sleep (200);

				g_bPushSkipFlag = false;
				
				g_bOffPixelApply = false;
				g_iOffPixelCnt = 0;
				g_bOffAvrApply = false;
				g_iOffAvfrCnt = 0;

				Kalman_Init ();
				LPF_IIR_Init ((double)NUDGet (nudLpfSensitive));

				//tmImageDsp.Interval = 60;
				//tmImageDsp.Start ();					//	Timer 에서 display

				Tas1945_GetPixelInfoPushMode ();
			}
			else
			{
				BTNSet (btnReadPushMode, "Push Read");

				if (g_iCsvSaveMode == 1)
				{
					RawLog_CsvFileClose ();
				}
				else
				{
					Save_TestPixelCsv ();

					TestPixelLog_CsvFileClose ();
				}	

				bStatus = true;

				Tas1945_PushModeStop ();

				Tas1945_PL_StatusCheck (false);

				//tmImageDsp.Stop ();
			}

			btnRegWrite.Enabled = bStatus;
			btnRegRead.Enabled = bStatus;
			btnTas1945RegCtrl.Enabled = bStatus;
			btnIpSetup.Enabled = bStatus;
			btnRegAllRead.Enabled = bStatus;
			btnSetClock.Enabled = bStatus;
			btnGetPixelInfo.Enabled = bStatus;
			btnSetRead.Enabled = bStatus;
			btnSetAverage.Enabled = bStatus;
			btnGetSetupInfo.Enabled = bStatus;
			btnSetReadPLStart.Enabled = bStatus;
			btnResend.Enabled = bStatus;
			btnReset.Enabled = bStatus;

			tgsContinue.Enabled = bStatus;
				
			rbNormal.Enabled = bStatus;
			rbFpgaAvr.Enabled = bStatus;
			rbGuiAvr.Enabled = bStatus;
			rbMoveAvr.Enabled= bStatus;

			tgsCsvSave.Enabled = bStatus;

			nudAvrCnt.Enabled = bStatus;

			tgsRefVal.Enabled = bStatus;

			rbOffsetDisable.Enabled = bStatus;
			rbDark_X_Offset.Enabled = bStatus;
			rbDark_Y_Offset.Enabled = bStatus;
			rbAvrOffset.Enabled = bStatus;

			nudSetCenterValue.Enabled = bStatus;
			nudDark_X.Enabled = bStatus;
			nudDark_Y.Enabled = bStatus;
			nudPixelMeasure.Enabled = bStatus;

			if (g_fTas1945RegForm != null)
			{
				g_fTas1945RegForm.btnTas1945Init.Enabled = bStatus;
				g_fTas1945RegForm.btnTas1945InitClose.Enabled = bStatus;
				g_fTas1945RegForm.btnSetReg127.Enabled = bStatus;
				g_fTas1945RegForm.btnSetReg190.Enabled = bStatus;
				g_fTas1945RegForm.btnSetReg191.Enabled = bStatus;
				g_fTas1945RegForm.btnSetReg156.Enabled = bStatus;
				g_fTas1945RegForm.btnSetReg157.Enabled = bStatus;
				g_fTas1945RegForm.tcRegControl.Enabled = bStatus;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetPixelInfoRead_Click (object sender, EventArgs e)
		{
			GetPixelInfoRead_Click ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReset_Click (object sender, EventArgs e)
		{
			Tas1945_Reset ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnIpSetup_Click (object sender, EventArgs e)
		{
			Tas1945_IpSetup ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmImage_Tick (object sender, EventArgs e)
		{
			try
			{
				if (g_queImage.Count > 0)
				{
					float[]	asImage = g_queImage.Dequeue ();

					if (asImage == null)		return;
					if (asImage.Length <= 0)	return;

					if (g_fPixelChartForm != null)
					{
						g_fPixelChartForm.Chart_Update (asImage, asImage.Length);
					}

					if (TGSGet (tgsShowImage) == false)		return;

					if (TGSGet (tgsPixels) == false)
					{
						g_ucRawImage.CreateColorBitmapZoom (asImage, asImage.Length);
					}
					else
					{
						g_ucRawPixels.CreatePixels (asImage, asImage.Length);
					}
				}
			}
			catch (Exception)
			{
				ERR ("Image Error !!!");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Get_PosXY_Value (object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar != Convert.ToChar (Keys.Enter))
				{
					if (CheckDigit (sender, e) == false)	return;

					return;
				}

				int x = StringToInt (tbPixelX.Text);
				int y = StringToInt (tbPixelY.Text);

				if (x > 80)		x = 80;					
				if (y > 59)		y = 59;					

				TBSet (tbPixelX, x.ToString ());
				TBSet (tbPixelY, y.ToString ());

				if (TGSGet (tgsPixels) == false)
				{
					if (TGSGet (tgsImageX10) == false)
					{
						x = x * g_ucRawImage.g_iZoom;
						y = y * g_ucRawImage.g_iZoom;
					}

					g_ucRawImage.GetPanelBitmapValue (x, y);
				}
				else
				{
					g_ucRawPixels.GetPanelPixelValue (x * 10, y * 10);
				}		
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbPixelX_KeyPress (object sender, KeyPressEventArgs e)
		{
			Get_PosXY_Value (sender, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbPixelY_KeyPress (object sender, KeyPressEventArgs e)
		{
			Get_PosXY_Value (sender, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_SizeChanged (object sender, EventArgs e)
		{
			if (g_ucRawImage == null) return;
			if (TGSGet (tgsPixels) == false)
			{
				g_ucRawImage.ImageRefresh ();
			}
			else
			{
				//g_ucRawPixels.Refresh ();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Activated (object sender, EventArgs e)
		{
			if (TGSGet (tgsPixels) == false)
			{
				g_ucRawImage.ImageRefresh ();
			}
			else
			{
				//g_ucRawPixels.Refresh ();
			}	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTas1945Init_Click (object sender, EventArgs e)
		{
			try
			{				
				if (g_fTas1945RegForm != null)	return;

				Tas1945_RegisterInit ();

				g_fTas1945RegForm = new Tas1945_RegForm (this);

				// 레지스터form 시작위치 지정 - v2.05 240101 조남인
				g_fTas1945RegForm.StartPosition = FormStartPosition.Manual;
				g_fTas1945RegForm.Location = new Point (300,3);

				g_fTas1945RegForm.Show ();
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tmPixelCountinue_Tick (object sender, EventArgs e)
		{
			if (g_bContinueRead == true)
			{
				if ((g_bCommComplete == false)&&(g_bSendRead == true))
				//if (g_bCommComplete == false)
				{ 
//					g_ContinuePixelRead_Cnt++;
//					
//					if (g_ContinuePixelRead_Cnt < 3)	return;
//
//					g_ContinuePixelRead_Cnt = 0;

					return;
				}

				if ((RBGet (rbGuiAvr) == true) && (g_iAvrCount == (int)NUDGet (nudAvrCnt)))
				{
					GetPixelInfoRead_Click ();
					return;
				}

				g_bCommComplete = false;

				if (Algorithm_Flag == true)
					return;
                else
                {
					// BookMark #4 : 타이머로 돌면서 FPGA에 PixelData를 요청하는 부분
					Algorithm_Flag = true;
					Tas1945_GetPixelInfo();
                }
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byBankNum"></param>
		private void Set_Bank (byte byBankNum)
		{
			byte[]		abyData = new byte[2];

			abyData[0] = 255;
			abyData[1] = byBankNum;

			LOG ("REG WR : " + abyData[0].ToString () + ", " + abyData[1].ToString () + "[0x" + HexToAscStr (abyData[1], false) + "]" , Color.Blue);

			Tas1945_TcpUdpSend ((uint)REQ.REG_WR, abyData, 2);		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRegAllRead_Click (object sender, EventArgs e)
		{
			Tas1945_InitDataAllRead ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nudSetClock_ValueChanged (object sender, EventArgs e)
		{	
			if (NUDGet (nudSetClock) == 10 || NUDGet (nudSetClock) == 50 || NUDGet (nudSetClock) == 100)	return;

			if (NUDGet (nudSetClock) < g_decPreClockValue)						//	down
            {
                if (50 < NUDGet (nudSetClock))
				{
					NUDSet (nudSetClock, 50);
				}
				else
				{
					NUDSet (nudSetClock, 10);
				}
            }
            else if(NUDGet (nudSetClock) > g_decPreClockValue)					//	up
            {
				if (50 <= NUDGet (nudSetClock))
				{
					NUDSet (nudSetClock, 100);
				}
				else
				{
					NUDSet (nudSetClock, 50);
				}
            }

            g_decPreClockValue = NUDGet (nudSetClock);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetClock_Click (object sender, EventArgs e)
		{
			Tas1945_SetClock ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsPixels_CheckedChanged (object sender, EventArgs e)
		{
			Select_RawImageType ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPixelChartShow_Click (object sender, EventArgs e)
		{
			try
			{				
				if (g_fPixelChartForm != null)	return;

				rbSetPixel1.Enabled = true;
				rbSetPixel2.Enabled = true;
				rbSetPixel3.Enabled = true;
				rbSetPixel4.Enabled = true;
				rbSetPixel5.Enabled = true;
				btnChartClear.Enabled = true;
				btnPixelChartShow.Enabled = false;

				g_fPixelChartForm = new Tas1945_PixelChartForm (this);

				g_fPixelChartForm.Show ();
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}	
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChartClear_Click (object sender, EventArgs e)
		{
			g_fPixelChartForm.Clear_PixelChart ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsCsvSave_CheckedChanged (object sender, EventArgs e)
		{
			//if (TGSGet (tgsCsvSave) == true)	RawLog_CsvFileOpen ();
			//else								RawLog_CsvFileClose ();
		}

		/// <summary>
		/// 
		/// </summary>
		private void AverageMode_Change ()
		{
			if (RBGet (rbFpgaAvr) == true)		NUDSet (nudInterval, 50);
			else								NUDSet (nudInterval, 50);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbNormal_CheckedChanged (object sender, EventArgs e)
		{
			AverageMode_Change ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbFpgaAvr_CheckedChanged (object sender, EventArgs e)
		{
			AverageMode_Change ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbGuiAvr_CheckedChanged (object sender, EventArgs e)
		{
			AverageMode_Change ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbMoveAvr_CheckedChanged (object sender, EventArgs e)
		{
			AverageMode_Change ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void nudInterval_Click (object sender, EventArgs e)
		{
			tmPixelCountinue.Interval = (int)NUDGet (nudInterval);
			if ((int)NUDGet(nudInterval) < 10)
			{
				tmImageDsp.Interval = (int)NUDGet(nudInterval);   // 120frame 을 위해 추가함 - 20230817 조남인
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetRead_Click (object sender, EventArgs e)
		{
			Tas1945_SetRead ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetAverage_Click (object sender, EventArgs e)
		{
			Tas1945_SetAverageCount ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGetSetupInfo_Click (object sender, EventArgs e)
		{
			Tas1945_GetSetupInfo ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReadPushMode_Click (object sender, EventArgs e)
		{
			PushModeRead_Click ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsNetMode_CheckedChanged (object sender, EventArgs e)
		{
			if (TGSGet (tgsNetMode) == true)
			{
				NUDSet (nudTcpPort, 5000);

				btnSetClock.Visible = false;
				btnSetRead.Visible = false;
				btnSetAverage.Visible = false;
				btnSetReadPLStart.Visible = false;
				btnResend.Visible = false;

				nudSetClock.Visible = false;
				nudClockDelay.Visible = false;
				nudSetAvrCnt.Visible = false;

				tgsReadEdge.Visible = false;
				btnGetSetupInfo.Visible = false;

				btnReadPushMode.Visible = false;
			}
			else
			{
				NUDSet (nudTcpPort, 10000);

				btnSetClock.Visible = true;
				btnSetRead.Visible = true;
				btnSetAverage.Visible = true;
				btnSetReadPLStart.Visible = true;
				btnResend.Visible = true;

				nudSetClock.Visible = true;
				nudClockDelay.Visible = true;
				nudSetAvrCnt.Visible = true;

				tgsReadEdge.Visible = true;
				btnGetSetupInfo.Visible = true;

				btnReadPushMode.Visible = true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetReadPLStart_Click (object sender, EventArgs e)
		{
			if (BTNGet (btnSetReadPLStart) == "PL Read")
			{	
				BTNSet (btnSetReadPLStart, "PL Stop");

				Tas1945_PLReadCtrl (true);
			}
			else
			{
				BTNSet (btnSetReadPLStart, "PL Read");

				Tas1945_PLReadCtrl (false);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnResend_Click (object sender, EventArgs e)
		{
			Tas1945_Resend ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbAvrOffset_CheckedChanged (object sender, EventArgs e)
		{
			nudPixelMeasure.Maximum = 100;
			NUDSet (nudPixelMeasure, 10);

			NUDSet (nudInterval, 50);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbPixelOffset_CheckedChanged (object sender, EventArgs e)
		{
			nudPixelMeasure.Maximum = 100;
			NUDSet (nudPixelMeasure, 10);

			NUDSet (nudInterval, 50);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsIntValue_CheckedChanged (object sender, EventArgs e)
		{
			nudMaxVal.Maximum = 32767;
			nudMaxVal.Minimum = -32767;
			nudMinVal.Maximum = 32766;
			nudMinVal.Minimum = -32768;

			nudSetCenterValue.Maximum = 32767;
			nudSetCenterValue.Minimum = -32768;

			NUDSet (nudMaxVal, nudMaxVal.Maximum);
			NUDSet (nudMinVal, nudMinVal.Minimum);

			NUDSet (nudSetCenterValue, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbOffNormal_CheckedChanged (object sender, EventArgs e)
		{
			NUDSet (nudInterval, 50);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbDarkOffset_CheckedChanged (object sender, EventArgs e)
		{
			NUDSet (nudInterval, 50);
		}

        private void tmFrameCnt_Tick(object sender, EventArgs e)
        {
			maxFrame = cntFrames;
			LBSet(lbMaxFrame,maxFrame.ToString());
			cntFrames = 0;
        }

        private void btncal25_Click(object sender, EventArgs e)
        {
			if (BTNGet(btnGetPixelInfo) == "Read") return;
			Array.Clear(cal25AvrData, 0, cal25AvrData.Length);
			cal25_flag = true;
		}

        private void btncal35_Click(object sender, EventArgs e)
        {
			if (BTNGet(btnGetPixelInfo) == "Read") return;
			Array.Clear(cal35AvrData, 0, cal35AvrData.Length);
			cal35_flag = true;
		}

        private void btncal45_Click(object sender, EventArgs e)
        {
			if (BTNGet(btnGetPixelInfo) == "Read") return;
			Array.Clear(cal45AvrData, 0, cal45AvrData.Length);
			cal45_flag = true;
		}

		private void g_calCtrl_btLoad(object sender, EventArgs e)
		{
			#region _CONNECT_TO_DEVICE_CHECK_

			if (BTNGet(btnTcpConnect) == "Connect")
			{
				LOG("Please Connect to Device", Color.Red); return;
			}

			#endregion

			Button bt = sender as Button;

			string calFilePath = string.Empty; // file path

			float[,] iBuffer = new float[ROW, COL]; // file value
			int iRaw = 0, iCol = 0;             // raw col init

			#region _OPEN_TO_DIALOG_

			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				//dialog.InitialDirectory = dialogInitPath;    //init directory path
				dialog.InitialDirectory = "c:\\Cal_buf_Info\\";
				dialog.Filter = dialogFilter;      // dialog filter
				dialog.FilterIndex = dialogFilterIndex; // dialog filterindex
				dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() == DialogResult.Cancel)
				{
					LOG("dialog Cancel return to mainForm", Color.Black); return;
				}

				calFilePath = dialog.FileName; // get cal csv file path

				if (calFilePath.Contains(".csv") == false)
				{
					LOG("is not csv file return to main Form", Color.Black); return;
				}
			}

			#endregion

			#region _READ_TO_FILE_

			using (StreamReader reader = new StreamReader(calFilePath, Encoding.Default))
			{
				while (!reader.EndOfStream)
				{
					string sReadLine = reader.ReadLine();    // read line
					string[] sSplitLine = sReadLine.Split(','); // split line

					foreach (string str in sSplitLine)
					{
						// 자료형이 short일 때, 쓰였던 부분
						//iBuffer[iRaw, iCol++] = Convert.ToInt32(str);

						// 자료형이 float로 바뀌면서 아래 If문 추가함 - 2024.02.07
						// 예외 처리를 추가하여 변환 가능한 경우에만 변환을 시도합니다.
						if (float.TryParse(str, out float parsedValue))
						{
							// 부동 소수점 값을 그대로 넣습니다.
							iBuffer[iRaw, iCol++] = parsedValue;
						}
						else
						{
							// 예외 처리 또는 기본값 설정 등을 수행할 수 있습니다.
							LOG("자료형이 맞지않아 Cal data 입력에 실패하였습니다", Color.Red);
							return;
						}
					}

					iCol = 0; //col count init
					iRaw++;   //raw count up
				}
			}

			#endregion

			#region _SAVE_INT_IMAGE_BUFFER_

			if (bt == btcal25load) { Image_buf_25C = iBuffer; LOG("Successful saving of 25℃ image buffer", Color.Blue); }
			else if (bt == btcal35load)
			{
				Image_buf_35C = iBuffer; LOG("Successful saving of 35℃ image buffer", Color.Blue);
				
			}
			else if (bt == btcal45load) { Image_buf_45C = iBuffer; LOG("Successful saving of 45℃ image buffer", Color.Blue); }
			else if (bt == btcalOffsetload) { Image_buf_offset = iBuffer; LOG("Successful saving of Offset image buffer", Color.Blue); }

			#endregion
		}

		private void cbCalmode_CheckedChanged(object sender, EventArgs e)
		{
			if (cbCalmode.Checked == true)
			{
				NUDSet(nudMaxVal, 500);
				NUDSet(nudMinVal, -50);

				cbSensitivy_cal.Enabled = true;
				cbDP_apply.Enabled = true;
				cbNF_apply.Enabled = true;
				cbDPC_apply.Enabled = true;
				
				// Cal_mode 진입 flag
				cal_mode = true;
			}
			else
			{
				NUDSet(nudMaxVal, 300);
				NUDSet(nudMinVal, -300);

				cbSensitivy_cal.Checked = false;
				cbDP_apply.Checked = false;
				cbNF_apply.Checked = false;
				cbDPC_apply.Checked = false;

				cbSensitivy_cal.Enabled = false;
				cbDP_apply.Enabled = false;
				cbNF_apply.Enabled = false;
				cbDPC_apply.Enabled = false;

				s_bInitKalamn = false;

				// Cal mode 체크 해제 시 Image_buf_ISP를 다시 처음부터 쌓기 위한 초기화
				ISP_cnt = 0;
				ISP_cnt_flag = false;

				cal_mode = false;
			}
		}

        private void cbSensitivy_cal_CheckedChanged(object sender, EventArgs e)
        {
			if (cbSensitivy_cal.Checked == true)
			{
				for (int i = 0; i < 4860; i++)
                {
					row = (int)i / COL;
					col = i - row * COL;

					sensitivity_buf[row, col] = (double)(Image_buf_45C[row, col] - Image_buf_25C[row, col]);
				}

				tbGain.Enabled = true;
				btnGain.Enabled = true;

				sensitivity_cal_flag = true;
			}
			else
			{
				tbGain.Enabled = false;
				btnGain.Enabled = false;

				sensitivity_cal_flag = false;
			}
		}

        private void btnGain_Click(object sender, EventArgs e)
        {
			string inputText = tbGain.Text;
			double result;

			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				if (result < 1 || result > 1000000) return;
				GAIN = result;
			}
			else
			{
				// 숫자로 변환에 실패한 경우
				return;
			}
        }

        private void cbDP_apply_CheckedChanged(object sender, EventArgs e)
        {
			if (cbDP_apply.Checked == true)
			{
				StoN_ck.Enabled = true;
				Signal_ck.Enabled = true;
				Noise_ck.Enabled = true;
				tbStoN_max.Enabled = true;
				tbStoN_min.Enabled = true;
				tbSignal_max.Enabled = true;
				tbSignal_min.Enabled = true;
				tbNoise_max.Enabled = true;
				tbNoise_min.Enabled = true;
				btnDP_cal.Enabled = true;

				DP_apply_flag = true;
			}
			else
			{
				StoN_ck.Checked = false;
				Signal_ck.Checked=false;
				Noise_ck.Checked=false;

				StoN_ck.Enabled = false;
				Signal_ck.Enabled = false;
				Noise_ck.Enabled = false;
				tbStoN_max.Enabled = false;
				tbStoN_min.Enabled = false;
				tbSignal_max.Enabled = false;
				tbSignal_min.Enabled = false;
				tbNoise_max.Enabled = false;
				tbNoise_min.Enabled = false;
				btnDP_cal.Enabled = false;

				DP_apply_flag = false;
			}
		}

        private void StoN_ck_CheckedChanged(object sender, EventArgs e)
        {
			if (StoN_ck.Checked == true)
				StoN_flag = true;
			else StoN_flag = false;
		}

        private void Signal_ck_CheckedChanged(object sender, EventArgs e)
        {
			if (Signal_ck.Checked == true)
				Signal_flag = true;
			else Signal_flag = false;
		}

        private void Noise_ck_CheckedChanged(object sender, EventArgs e)
        {
			if (Noise_ck.Checked == true)
				Noise_flag = true;
			else Noise_flag = false;
		}

        private void btnDP_cal_Click(object sender, EventArgs e)
        {
			string inputText;
			double result;

			inputText = tbStoN_max.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				StoN_max = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;

			inputText = tbStoN_min.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				StoN_min = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;

			inputText = tbSignal_max.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				Signal_max = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;

			inputText = tbSignal_min.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				Signal_min = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;

			inputText = tbNoise_max.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				Noise_max = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;

			inputText = tbNoise_min.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				Noise_min = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void cbNF_apply_CheckedChanged(object sender, EventArgs e)
        {
			if (cbNF_apply.Checked == true)
			{
				for (int i = 0; i < 4860; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Kalman_ME_Each[row, col] = (double)(Image_buf_35C[row, col] * kalman_ME);
				}

				tbKalmanError.Enabled = true;
				btnKalmanError.Enabled = true;

				Noise_filter_flag = true;

			}
			else
			{
				tbKalmanError.Enabled = false;
				btnKalmanError.Enabled = false;

				s_bInitKalamn = false;

				g_iMoveAvrCnt_Cal = 0;
				g_iMonteAvrCnt_Cal = 0;
				g_iBuffer_Cal_no = 1;
				g_iBuffer_Monte_no = 1;
				Array.Clear(g_aiMoveAvrData_Cal, 0, g_aiMoveAvrData_Cal.Length);


				Noise_filter_flag = false;
			}
		}

        private void btnKalmanError_Click(object sender, EventArgs e)
        {
			string inputText;
			double result;

			inputText = tbKalmanError.Text;
			if (double.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				kalman_ME = result;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;

			for (int i = 0; i < 4860; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;

				Kalman_ME_Each[row, col] = (double)(Image_buf_35C[row, col] * kalman_ME);
			}

		}

        private void btnDataverify_Click(object sender, EventArgs e)
        {
			if (BTNGet(btnGetPixelInfo) == "Read") return;

			Dataverify_flag = true;
		}

        private void cbDPC_apply_CheckedChanged(object sender, EventArgs e)
        {
			if (cbDPC_apply.Checked == true)
			{
				DPC_apply_flag = true;
			}
			else
			{
				DPC_apply_flag = false;
			}
		}

        private void btnISPoffsetCal_Click(object sender, EventArgs e)
        {
			if (ISP_cnt_flag == false)
				return;
			else
            {
				Array.Clear(Image_buf_ISP_offset, 0, Image_buf_ISP_offset.Length);
				for (int i = 0; i < 50; i++)
                {
					for(int j = 0; j < 4860; j++)
                    {
						Image_buf_ISP_offset[j] += Image_buf_ISP[i, j];
					}
				}
				for(int i = 0;i < 4860; i++)
                {
					Image_buf_ISP_offset[i] /= (float) 50.0 ;
				}
				LOG("Image_buf_ISP_offset 세팅 완료", Color.Blue);
			}
        }

        private void cbISPoffset_CheckedChanged(object sender, EventArgs e)
        {
			if (cbISPoffset.Checked == true)
			{
				ISP_offset_flag = true;
			}
			else
			{
				ISP_offset_flag = false;
			}
		}

        private void btnColDead_Click(object sender, EventArgs e)
        {
			string inputText;
			int result;

			inputText = tbColselect.Text;
			if (int.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				for (int i = 0; i < 60; i++)
				{
					Active_Line_Ctrl[i, result] = 0;
				}
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void btnColLive_Click(object sender, EventArgs e)
        {
			string inputText;
			int result;

			inputText = tbColselect.Text;
			if (int.TryParse(inputText, out result))
			{
				// 숫자로 변환에 성공한 경우
				for (int i = 0; i < 60; i++)
				{
					Active_Line_Ctrl[i, result] = 1;
				}
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void btnColInit_Click(object sender, EventArgs e)
        {
			for (int i = 0; i < 4860; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;

				Active_Line_Ctrl[row, col] = 1;
			}
		}

        private void btnXYDead_Click(object sender, EventArgs e)
        {
			string inputText_X;
			string inputText_Y;
			int result_X;
			int result_Y;

            inputText_X = tbX_dpc.Text;
			inputText_Y = tbY_dpc.Text;

			if (int.TryParse(inputText_X, out result_X) && int.TryParse(inputText_Y, out result_Y))
			{
				// 숫자로 변환에 성공한 경우
				Active_XY_Ctrl[result_Y, result_X] = 0;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void btnXYLive_Click(object sender, EventArgs e)
        {
			string inputText_X;
			string inputText_Y;
			int result_X;
			int result_Y;

			inputText_X = tbX_dpc.Text;
			inputText_Y = tbY_dpc.Text;

			if (int.TryParse(inputText_X, out result_X) && int.TryParse(inputText_Y, out result_Y))
			{
				// 숫자로 변환에 성공한 경우
				Active_XY_Ctrl[result_Y, result_X] = 1;
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void btnXYInit_Click(object sender, EventArgs e)
        {
			for (int i = 0; i < 4860; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;

				Active_XY_Ctrl[row, col] = 1;
			}
		}

        private void cbDark_Apply_CheckedChanged(object sender, EventArgs e)
        {
			if (cbDark_Apply.Checked)
				DarkAvg_flag = true;
			else
				DarkAvg_flag = false;
		}

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
			Graphics gr = e.Graphics;
			Font fon1 = new Font(e.Font, FontStyle.Regular);

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			gr.DrawString("TAS1945 Ctrl", fon1, Brushes.Black, this.tabControl1.GetTabRect(0),sf);
			gr.DrawString("Device Ctrl", fon1, Brushes.BlueViolet, this.tabControl1.GetTabRect(1), sf);
			gr.DrawString("Filter", fon1, Brushes.IndianRed, this.tabControl1.GetTabRect(2), sf);
			gr.DrawString("Image Cal", fon1, Brushes.Blue, this.tabControl1.GetTabRect(3), sf);
			gr.DrawString("Reg Test", fon1, Brushes.CadetBlue, this.tabControl1.GetTabRect(4), sf);
		}

        private void btnRegWR_Set1_Click(object sender, EventArgs e)
        {
			string inputText_127;
			string inputText_154;
			string inputText_213;
			string inputText_215;
			byte result_127;
			byte result_154;
			byte result_213;
			byte result_215;

			inputText_127 = TBGet(tbReg127_Set1);
			inputText_154 = TBGet(tbReg154_Set1);
			inputText_213 = TBGet(tbReg213_Set1);
			inputText_215 = TBGet(tbReg215_Set1);

			if (byte.TryParse(inputText_127, System.Globalization.NumberStyles.HexNumber, null, out result_127) && byte.TryParse(inputText_154, System.Globalization.NumberStyles.HexNumber, null, out result_154)
				&& byte.TryParse(inputText_213, System.Globalization.NumberStyles.HexNumber, null, out result_213) && byte.TryParse(inputText_215, System.Globalization.NumberStyles.HexNumber, null, out result_215))
			{
				// 숫자로 변환에 성공한 경우
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_127), result_127);
				Delay(10);
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_154), result_154);
				Delay(10);
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_213), result_213);
				Delay(10);
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_215), result_215);
				Delay(10);
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void btnRegWR_Set2_Click(object sender, EventArgs e)
        {
			string inputText_127;
			string inputText_154;
			string inputText_213;
			string inputText_215;
			byte result_127;
			byte result_154;
			byte result_213;
			byte result_215;

			inputText_127 = tbReg127_Set2.Text;
			inputText_154 = tbReg154_Set2.Text;
			inputText_213 = tbReg213_Set2.Text;
			inputText_215 = tbReg215_Set2.Text;

			if (byte.TryParse(inputText_127, System.Globalization.NumberStyles.HexNumber, null, out result_127) && byte.TryParse(inputText_154, System.Globalization.NumberStyles.HexNumber, null, out result_154)
				&& byte.TryParse(inputText_213, System.Globalization.NumberStyles.HexNumber, null, out result_213) && byte.TryParse(inputText_215, System.Globalization.NumberStyles.HexNumber, null, out result_215))
			{
				// 숫자로 변환에 성공한 경우
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_127), result_127);
				Delay(10);
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_154), result_154);
				Delay(10);
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_213), result_213);
				Delay(10);
				Tas1945_RegisterWrite((byte)NUDGet(nudTestReg_215), result_215);
				Delay(10);
			}
			else  // 숫자로 변환에 실패한 경우		
				return;
		}

        private void btnRegRD_Set1_Click(object sender, EventArgs e)
        {
			return ;
        }

        private void btnRegRD_Set2_Click(object sender, EventArgs e)
        {
			return ;
        }

        private void cbReg127mode_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (CBBIdxGet(cbReg127mode) == 0)   // 미선택
			{
				LOG("미선택 모드", Color.Blue);
				return;
			}
			else if (CBBIdxGet(cbReg127mode) == 1)   //  Differencial
			{
				Tas1945_RegisterWrite(127, 0x00);
				Delay(10);
			}
			else if (CBBIdxGet(cbReg127mode) == 2)   //  Sensor
			{
				Tas1945_RegisterWrite(127, 0x04);
				Delay(10);
			}
			else if (CBBIdxGet(cbReg127mode) == 3)   //  Reset
			{
				Tas1945_RegisterWrite(127, 0x08);
				Delay(10);
			}
			else
			{
				Tas1945_RegisterWrite(127, 0x00);
			}
		}

        private void btnPortSearch_Click(object sender, EventArgs e)
        {
			cbPort.DataSource = SerialPort.GetPortNames();
			
			// SerialPort.GetPortNames()로 검색된 모든 포트 가져오기
			string[] portNames = SerialPort.GetPortNames();

			// 각 포트를 로그로 출력
			foreach (string portName in portNames)
			{
				LOG("Found Port: " + portName, Color.Blue);
			}
		}

		private void btnComOpen_Click(object sender, EventArgs e)
		{
			if (cbPort.Text == "") return;

			FTDI.FT_STATUS ftStaus = FTDI.FT_STATUS.FT_OK;
			FT_DEVICE_LIST_INFO_NODE ftDevList = default;
			FtChannelConfig ftChannelConfig = default;
			uint address = 0;
			ushort data = 0;
			uint i = 0;
			byte latency = 2;
			int numChannels = 0;

			ftChannelConfig.ClockRate = 5000000;
			ftChannelConfig.LatencyTimer = latency;
			ftChannelConfig.configOptions = FtConfigOptions.Mode0 | FtConfigOptions.CsDbus3 | FtConfigOptions.CsActivelow;
			ftChannelConfig.Pin = 0x00000000;

			LibMpsse.Init();

			LibMpsseSpi.SPI_GetNumChannels(out numChannels);
			print_ftStatus(ftStaus);
			Ret_Log_String = "channel num : " + numChannels.ToString() + "\r\n";
			LOG(Ret_Log_String);




			// UART 통신 준비하는 코드
			//if (!serial.IsOpen)
			//{
			//    /* SERIAL OPEN BEGIN */
			//    serial.PortName = cbPort.Text;          // Port Name
			//    serial.BaudRate = BAURATE;              // Baud Rate
			//    serial.DataBits = DATABITS;             // Data Bits
			//    serial.StopBits = STOPBITS;             // Stop Bits
			//    serial.Parity = PARITY;                 // Parity
			//    serial.DataReceived += new SerialDataReceivedEventHandler(Receive_USB); // Event Handler
			//    serial.Open();                          // Serial Open

			//    btnPortSearch.Enabled = false;
			//    cbPort.Enabled = false;

			//	TcpIpButtonEnable(true);

			//	/* SERIAL OPEN END */
			//	LOG("Port Open : " + cbPort.Text, Color.Blue);
			//}
			//else
			//{
			//	LOG("Port Already Open", Color.Red);
			//}
		}
		private void Receive_USB(object sender, SerialDataReceivedEventArgs e)
		{
			// 이벤트 핸들러에서 호출할 메서드
			if (serial.IsOpen)
			{
				int bytesToRead = serial.BytesToRead;
				byte[] buffer = new byte[bytesToRead];
				serial.Read(buffer, 0, bytesToRead);

				// 데이터를 받으면 Tas1945_RespParser 호출
				Tas1945_RespParser(buffer, bytesToRead);
			}
		}

		private void btnComClose_Click(object sender, EventArgs e)
        {
			if (serial.IsOpen)
			{
				serial.Close();

				btnPortSearch.Enabled = true;
				cbPort.Enabled = true;

				LOG("Port Close" , Color.Blue);
			}
			else
			{
				btnPortSearch.Enabled = true;
				cbPort.Enabled = true;

				LOG("Port Already Close", Color.Red);
			}
		}
    }

    /// <summary>
    /// 깜박임을 없애기 위한 Double buffer - 별료 효과 없다.
    /// </summary>
    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel ()
        {
            this.SetStyle (ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
			//this.SetStyle (ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

            this.UpdateStyles ();
        }
    }
}

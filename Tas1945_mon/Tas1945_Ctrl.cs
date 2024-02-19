using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class MainForm : Form
	{
		public byte[] g_abyTas1945Register = new byte[256];
		public float[] g_aiDarkX_PixelOffset = new float[81];
		public float[] g_aiDarkY_PixelOffset = new float[60];

		public bool g_bCommComplete;
		public byte g_byReadDspMode;											//	0 : Regiser Form, LOG, 1 : Main Textbox, LOG, 2 : LOG, 3 : No Display
		public byte g_byReadData;
		public bool g_bPushSkipFlag = false;

		public bool g_bSendRead;

		public double g_dbPixelAvrage;

		public float[] g_aiAvrData = new float[4860];
		public float[] g_aiMaxData = new float[4860];
		public float[] g_aiMinData = new float[4860];
		public float[,] g_aiMoveAvrData = new float[16, 4860];

		public float[] g_aiAvrData_Cal = new float[4860];
		public float[] g_aiMaxData_Cal = new float[4860];
		public float[] g_aiMinData_Cal = new float[4860];
		public float[,] g_aiMoveAvrData_Cal = new float[100, 4860];

		public float[] g_aiAvrData_Monte = new float[4860];
		public float[] g_aiMaxData_Monte = new float[4860];
		public float[] g_aiMinData_Monte = new float[4860];
		public float[,] g_aiMonteAvrData_Cal = new float[100, 4860];

		public float[,] aiDataverify = new float[100, 4860];

		float[] cal25AvrData = new float[4860];
		float[] cal35AvrData = new float[4860];
		float[] cal45AvrData = new float[4860];

		public const int DEAD = -10000;

		public byte[,] Active = new byte[ROW, COL];
		public byte[,] Active_ISP = new byte[ROW, COL];
		public byte[,] Active_Line_Ctrl = new byte[ROW, COL];
		public byte[,] Active_XY_Ctrl = new byte[ROW, COL];
		public byte[,] Active_Final = new byte[ROW, COL];

		public double Pixel_live_perc;
		public double Pixel_DPC_live_perc;

		private System.Diagnostics.Stopwatch stopwatch_Data = new System.Diagnostics.Stopwatch();
		private System.Diagnostics.Stopwatch stopwatch_Chart = new System.Diagnostics.Stopwatch();
		private System.Diagnostics.Stopwatch stopwatch_Bitmap = new System.Diagnostics.Stopwatch();

		public const int ROW = 60;
		public const int COL = 81;
		public const int BUFFER = 4860;
		public float[,] Image_buf_25C = new float[ROW, COL]; //25C image
		public float[,] Image_buf_35C = new float[ROW, COL]; //35C image
		public float[,] Image_buf_35C_max = new float[ROW, COL]; //35C image
		public float[,] Image_buf_35C_min = new float[ROW, COL]; //35C image
		public float[,] Image_buf_45C = new float[ROW, COL]; //45C image
		public float[,] Image_buf = new float[ROW, COL]; //Image_buffer
		public float[,] Image_buf_Dark = new float[ROW, COL]; //Image_buffer for Dark average
		public float[,] Image_buf_disp = new float[ROW, COL]; //Image_buffer for display
		public float[,] Image_buf_DPC = new float[ROW, COL]; //Image_buffer for display
		public float[,] Image_buf_offset = new float[ROW, COL]; //Level이 변하는 픽셀에 실시간 대응을 위한 Offset buffer
		public float[,] Image_buf_ISP = new float[50, 4860]; //Level이 변하는 픽셀에 실시간 대응을 위한 ISP data 수집용 buffer
		public double[] Image_buf_ISP_offset = new double[4860]; //Level이 변하는 픽셀에 실시간 대응을 위한 ISP offset buffer

		public float[,] Image_buf_pulse = new float[100, 4860]; //Pulse noise Pixel을 거르기 위한 버퍼들
		public double[] Image_buf_pulse_avg = new double[4860]; //Pulse noise Pixel을 거르기 위한 버퍼들
		public float[] Image_buf_pulse_min = new float[4860]; //Pulse noise Pixel을 거르기 위한 버퍼들
		public float[] Image_buf_pulse_max = new float[4860]; //Pulse noise Pixel을 거르기 위한 버퍼들

		public int g_iBuffer_no;
		public int g_iBuffer_cnt;

		double GAIN = 1000.0;

		float k = 0;

		public int row;//x_cordination 0~59
		public int col;//y_cordination 0~80

		public double StoN = 1.0;
		public double sensitivity = 1.0f;
		public double[,] sensitivity_buf = new double[ROW, COL];
		public double Noise = 1.0f;
		public double Signal = 1.0f;

		public float[] g_asOffPixelData = new float[4860];
		public int g_iOffPixelCnt;
		public bool g_bOffPixelApply;

		public float[] g_asOffAvrData = new float[4860];
		public float[] g_aiOffAvrData = new float[4860];
		public int g_iOffAvfrCnt;
		public bool g_bOffAvrApply;

		public int g_iMoveAvrCnt;
		public bool g_bMoveAvrDsp;
		public bool g_bOddEvenToggle = false;

		public int g_iAvrCount;

		public int g_iBuffer_Cal_no;
		public int g_iBuffer_Monte_no;

		public int g_iMoveAvrCnt_Cal;
		public int g_iMonteAvrCnt_Cal;

		public int g_iDataVerifyCnt = 0;

		public bool g_bPLReadStart = false;

		public bool g_bCsvOn = false;
		public int g_iCsvSaveMode = 0;                                          //	0 : Test Pixel Save, 1 : Chart Pixel Save

		public int cal25_Cnt = 0;
		public int cal35_Cnt = 0;
		public int cal45_Cnt = 0;
		public int PulseCal_Cnt = 0;

		public double StoN_max = 0.0;
		public double StoN_min = 0.0;
		public double Signal_max = 0.0;
		public double Signal_min = 0.0;
		public double Noise_max = 0.0;
		public double Noise_min = 0.0;

		public Queue<float[]> g_queImage = new Queue<float[]> ();

		float[] asPixelData = new float[4860];
		public float[] g_asPixelData = new float[4860];
		public float[] g_asPixelData_Cal = new float[4860];

		public int int32data;

		/// <summary>
		/// 
		/// </summary>
		public void cal25_calibration(float[] g_asPixelData_Cal)
        {
			cal25_Cnt++;

			LOG("25 calibration Measure : " + cal25_Cnt.ToString(), Color.Red);

			if (cal25_Cnt >= (int)NUDGet(nudcal25))
            {
				cal25_flag = false;
				LOG("25cal 완료", Color.Red);
            }

			if (cal25_Cnt > 1)
            {
				float iValue = 0;

				try
                {
					for(int i = 0; i < g_asPixelData_Cal.Length; i++)
                    {
						iValue = Get_PixelData(g_asPixelData_Cal, i);
						cal25AvrData[i] += iValue;
					}
					if (cal25_flag == false)
                    {
						for(int i = 0; i < g_asPixelData_Cal.Length; i++)
                        {
							cal25AvrData[i] = cal25AvrData[i] / (int)(NUDGet(nudcal25)-1);
							row = (int)(i / 81);
							col = i - 81 * row;
							Image_buf_25C[row, col] = cal25AvrData[i];
						}

						Cal25_buf_save();

						g_iMoveAvrCnt_Cal = 0;
						g_iBuffer_Cal_no = 1;
						Array.Clear(g_aiMoveAvrData_Cal, 0, g_aiMoveAvrData_Cal.Length);
						cal25_Cnt = 0;
					}
                }
				catch (Exception ex)
                {
					ERR(ex.Message);
                }
            }
        }

		public void cal35_calibration(float[] g_asPixelData_Cal)
		{
			cal35_Cnt++;

			LOG("35 calibration Measure : " + cal35_Cnt.ToString(), Color.Red);
			//LOG("Max : " + Image_buf_35C_max[30, 40].ToString() + "  Min : " + Image_buf_35C_min[30, 40], Color.Red);
			//LOG("Max : " + Image_buf_35C_max[10, 40].ToString() + "  Min : " + Image_buf_35C_min[10, 40], Color.Red);
			//LOG("Max : " + Image_buf_35C_max[55, 40].ToString() + "  Min : " + Image_buf_35C_min[55, 40], Color.Red);

			if (cal35_Cnt >= (int)NUDGet(nudcal35))
			{
				cal35_flag = false;
				LOG("35cal 완료", Color.Red);
			}
			if (cal35_Cnt == 1)
			{
				for (int i = 0; i < g_asPixelData_Cal.Length; i++)
				{
					row = (int)(i / 81);
					col = i - 81 * row;
					Image_buf_35C_max[row, col] = Get_PixelData(g_asPixelData_Cal, i);
					Image_buf_35C_min[row, col] = Image_buf_35C_max[row, col];
				};
			}

			if (cal35_Cnt > 1)
			{
				float iValue = 0;

				try
				{
					for (int i = 0; i < g_asPixelData_Cal.Length; i++)
					{
						iValue = Get_PixelData(g_asPixelData_Cal, i);
						cal35AvrData[i] += iValue;
						row = (int)(i / 81);
						col = i - 81 * row;
						if (iValue > Image_buf_35C_max[row, col]) Image_buf_35C_max[row, col] = iValue;
						if (iValue < Image_buf_35C_min[row, col]) Image_buf_35C_min[row, col] = iValue;
					}
					if (cal35_flag == false)
					{
						for (int i = 0; i < g_asPixelData_Cal.Length; i++)
						{
							cal35AvrData[i] = cal35AvrData[i] / (int)(NUDGet(nudcal35)-1);
							row = (int)(i / 81);
							col = i - 81 * row;
							Image_buf_35C[row, col] =(Image_buf_35C_max[row, col]- Image_buf_35C_min[row, col]);// cal35AvrData[i];
							/*if (Image_buf_45C[raw, col] <= Image_buf_25C[raw, col]) Image_buf_35C[raw, col] = 0;
							else
                            {
								if (Image_buf_35C_max[raw, col] <= Image_buf_35C_min[raw, col]) Image_buf_35C[raw, col] = 0;
								else Image_buf_35C[raw, col] = 1000*(Image_buf_45C[raw, col] - Image_buf_25C[raw, col])/(Image_buf_35C_max[raw, col] - Image_buf_35C_min[raw, col]);

							}*/
						}

						Cal35_buf_save();


						g_iMoveAvrCnt_Cal = 0;
						g_iBuffer_Cal_no = 1;
						Array.Clear(g_aiMoveAvrData_Cal, 0, g_aiMoveAvrData_Cal.Length);
						cal35_Cnt = 0;
					}
				}
				catch (Exception ex)
				{
					ERR(ex.Message);
				}
			}
		}

		public void cal45_calibration(float[] g_asPixelData_Cal)
		{
			cal45_Cnt++;

			LOG("45 calibration Measure : " + cal45_Cnt.ToString(), Color.Red);

			if (cal45_Cnt >= (int)NUDGet(nudcal45))
			{
				cal45_flag = false;
				LOG("45cal 완료", Color.Red);
			}

			if (cal45_Cnt > 1)
			{
				float iValue = 0;

				try
				{
					for (int i = 0; i < g_asPixelData_Cal.Length; i++)
					{
						iValue = Get_PixelData(g_asPixelData_Cal, i);
						cal45AvrData[i] += iValue;
					}
					if (cal45_flag == false)
					{
						for (int i = 0; i < g_asPixelData_Cal.Length; i++)
						{
							cal45AvrData[i] = cal45AvrData[i] / (int)(NUDGet(nudcal45)-1);
							row = (int)(i / 81);
							col = i - 81 * row;
							Image_buf_45C[row, col] = cal45AvrData[i];
						}

						Cal45_buf_save();

						g_iMoveAvrCnt_Cal = 0;
						g_iBuffer_Cal_no = 1;
						Array.Clear(g_aiMoveAvrData_Cal, 0, g_aiMoveAvrData_Cal.Length);
						cal45_Cnt = 0;
					}
				}
				catch (Exception ex)
				{
					ERR(ex.Message);
				}
			}
		}
		/// <summary>
		/// Dead Pixel을 선정하여 Display를 막는 함수
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DeadPixel_Apply(ref float[] asPixelData, int iPixelDataSize)
        {
			if (iPixelDataSize > 4860) return;

			// 반복문으로 4860개 픽셀 확인하며 Active 배열 결정 및 'Image_buf_disp' 배열값을 결정
			for (int i = 0; i < iPixelDataSize; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;
				//Active[row, col] = 1;

				StoN = Math.Round(sensitivity_buf[row, col] / ((double)Image_buf_35C[row, col] + 1), 2);
				Noise = (double)Image_buf_35C[row, col];

				//조건분리
				if (StoN_flag == true && Signal_flag == false && Noise_flag == false)  //조건 1
				{
					if ((Math.Abs(StoN) >= StoN_min) && (Math.Abs(StoN) < StoN_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else if (StoN_flag == false && Signal_flag == true && Noise_flag == false) //조건 2
				{
					if ((Math.Abs(sensitivity_buf[row, col]) >= Signal_min) && (Math.Abs(sensitivity_buf[row, col]) < Signal_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else if (StoN_flag == false && Signal_flag == false && Noise_flag == true) //조건 3
				{
					if ((Math.Abs(Noise) >= Noise_min) && (Math.Abs(Noise) < Noise_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else if (StoN_flag == true && Signal_flag == true && Noise_flag == false) //조건 4
				{
					if ((Math.Abs(StoN) >= StoN_min) && (Math.Abs(StoN) < StoN_max) && (Math.Abs(sensitivity_buf[row, col]) >= Signal_min) && (Math.Abs(sensitivity_buf[row, col]) < Signal_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else if (StoN_flag == true && Signal_flag == false && Noise_flag == true) //조건 5
				{
					if ((Math.Abs(StoN) >= StoN_min) && (Math.Abs(StoN) < StoN_max) && (Math.Abs(Noise) >= Noise_min) && (Math.Abs(Noise) < Noise_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else if (StoN_flag == false && Signal_flag == true && Noise_flag == true) //조건 6
				{
					if ((Math.Abs(sensitivity_buf[row, col]) >= Signal_min) && (Math.Abs(sensitivity_buf[row, col]) < Signal_max) && (Math.Abs(Noise) >= Noise_min) && (Math.Abs(Noise) < Noise_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else if (StoN_flag == true && Signal_flag == true && Noise_flag == true) //조건 7
				{
					if ((Math.Abs(StoN) >= StoN_min) && (Math.Abs(StoN) < StoN_max) && (Math.Abs(sensitivity_buf[row, col]) >= Signal_min) && (Math.Abs(sensitivity_buf[row, col]) < Signal_max) && (Math.Abs(Noise) >= Noise_min) && (Math.Abs(Noise) < Noise_max))
					{
						Image_buf_disp[row, col] = asPixelData[i];
						Active[row, col] = 1;
					}
					else
					{
						Image_buf_disp[row, col] = DEAD;
						Active[row, col] = 0;
					};
				}
				else  //조건 8 false
				{
					Image_buf_disp[row, col] = asPixelData[i];
					Active[row, col] = 1;
				}
			}

			// 원본 Active[]배열과 Active_Line, Active_XY 배열들을 곱하여 적용
			for (int i = 0; i < iPixelDataSize; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;

				Active[row, col] = (byte)(Active[row,col] * Active_Line_Ctrl[row,col] * Active_XY_Ctrl[row,col]);
			}

			// 최종 Active[]배열 판정에 따라, 원본 데이터 또는 DEAD 데이터 적용
			for (int i = 0; i < iPixelDataSize; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;

				if(Active[row,col] == 1) // 최종적으로 Live 픽셀은 원본데이터 그대로 지정
                {
					asPixelData[i] = (float)Image_buf_disp[row, col];
				}
                else  // 최종적으로 Dead 픽셀들
                {
					Image_buf_disp[row, col] = DEAD;
					asPixelData[i] = (float)Image_buf_disp[row, col];
				}
			}

			// Live Pixel count를 위한 'Active[]' 배열 반복문
			int ret_cnt = 0;
			for (int i = 0; i < iPixelDataSize; i++)
            {
				row = (int)i / COL;
				col = i - row * COL;

				ret_cnt += Active[row, col];
			}

			Pixel_live_perc = Math.Round(ret_cnt * 100.0 / 4860);
			LBSet(lbLivePixel_count, ret_cnt.ToString());
			LBSet(lbLivePixel_perc, Pixel_live_perc.ToString() + " %");
		}
		/// <summary>
		/// DPC 알고리즘 적용 함수
		/// 이 함수에서는 Active[] 배열이 조건, Active_ISP[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NP1(ref float[] asPixelData, int iPixelDataSize)
        {
			try
            {
				if (iPixelDataSize > 4860) return;
								
				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
                {
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// Dead Pixel(=Active[]==0) 수량 검증구문, 결과 OK = 240106 조남인
				/*int ret_cnt = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					if(Active[row, col] == 0)
						ret_cnt++;
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt.ToString());*/
				

				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if(col == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if(col == 80)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if(row == 59)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float) Image_buf_disp[row, col];
							Active_ISP[row, col] = 1;
						}
						else   
						{
							// 죽은 픽셀 보정 파트

							float ret = 0;   // 임시 변수

							if((Active[row - 1, col] + Active[row, col - 1] + Active[row, col + 1] + Active[row + 1, col]) == 0)
                            {
								// Neighbor Pixel 4개가 다 죽은 경우에는 원본값(DEAD=-10000)그대로 유지
								asPixelData[i] = asPixelData[i];
								Active_ISP[row, col] = 0;
                            }
                            else
                            {
                                // (4개 평균값 보간) 순서대로 죽은 픽셀의 위, 왼쪽, 오른쪽, 아래 픽셀 
                                ret = (float)((Image_buf_disp[row - 1, col] * Active[row - 1, col]
									+ Image_buf_disp[row, col - 1] * Active[row, col - 1]
									+ Image_buf_disp[row, col + 1] * Active[row, col + 1]
									+ Image_buf_disp[row + 1, col] * Active[row + 1, col])
									  / (Active[row - 1, col] + Active[row, col - 1] + Active[row, col + 1] + Active[row + 1, col]));

                                #region (선형 가중 보간)
                                // 가중치 변수들
                                /*double x = 0.5, y = 0.5;

								if (Image_buf_disp[row, col - 1] > Image_buf_disp[row, col + 1]) x = 0.8;
								else x = 0.2;

								if (Image_buf_disp[row - 1, col] > Image_buf_disp[row + 1, col]) y = 0.8;
								else y = 0.2;

								// 순서대로 죽은 픽셀의 위, 왼쪽, 오른쪽, 아래 픽셀
								ret = (float)(Image_buf_disp[row - 1, col] * Active[row - 1, col] * y
									+ Image_buf_disp[row, col - 1] * Active[row, col - 1] * x
									+ Image_buf_disp[row, col + 1] * Active[row, col + 1] * (1 - x)
									+ Image_buf_disp[row + 1, col] * Active[row + 1, col] * (1 - y));*/
                                #endregion

                                Active_ISP[row, col] = 1;
								asPixelData[i] = ret;
							}
						}
					}
				}
				
				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active_ISP[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
            {

            }
		}
		/// <summary>
		/// DPC 알고리즘 적용 함수2
		/// 이 함수에서는 Active_ISP[] 배열이 조건, Active[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NP2(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// Dead Pixel(=Active[]==0) 수량 검증구문, 결과 OK = 240106 조남인
				/*int ret_cnt = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					if(Active_ISP[row, col] == 0)
						ret_cnt++;
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt.ToString());*/


				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 if/else if 에서 죽인 후 else 진입
					{
						if (Active_ISP[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트

							float ret = 0;   // 임시 변수

							if ((Active_ISP[row - 1, col] + Active_ISP[row, col - 1] + Active_ISP[row, col + 1] + Active_ISP[row + 1, col]) == 0)
							{
								// Neighbor Pixel 4개가 다 죽은 경우에는 원본값(DEAD=-10000)그대로 유지
								asPixelData[i] = asPixelData[i];
								Active[row, col] = 0;
							}
							else
							{
								// (4개 평균값 보간) 순서대로 죽은 픽셀의 위, 왼쪽, 오른쪽, 아래 픽셀 
								ret = (float)((Image_buf_disp[row - 1, col] * Active_ISP[row - 1, col]
									+ Image_buf_disp[row, col - 1] * Active_ISP[row, col - 1]
									+ Image_buf_disp[row, col + 1] * Active_ISP[row, col + 1]
									+ Image_buf_disp[row + 1, col] * Active_ISP[row + 1, col])
									  / (Active_ISP[row - 1, col] + Active_ISP[row, col - 1] + Active_ISP[row, col + 1] + Active_ISP[row + 1, col]));

								#region (선형 가중 보간)
								// 가중치 변수들
								/*double x = 0.5, y = 0.5;

								if (Image_buf_disp[row, col - 1] > Image_buf_disp[row, col + 1]) x = 0.8;
								else x = 0.2;

								if (Image_buf_disp[row - 1, col] > Image_buf_disp[row + 1, col]) y = 0.8;
								else y = 0.2;

								// 순서대로 죽은 픽셀의 위, 왼쪽, 오른쪽, 아래 픽셀
								ret = (float)(Image_buf_disp[row - 1, col] * Active_ISP[row - 1, col] * y
									+ Image_buf_disp[row, col - 1] * Active_ISP[row, col - 1] * x
									+ Image_buf_disp[row, col + 1] * Active_ISP[row, col + 1] * (1 - x)
									+ Image_buf_disp[row + 1, col] * Active_ISP[row + 1, col] * (1 - y));*/
								#endregion

								Active[row, col] = 1;
								asPixelData[i] = ret;
							}
						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		/// <summary>
		/// NNP 픽셀 참조하는 1번 함수
		/// 이 함수에서는 Active[] 배열이 조건, Active_ISP[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NNP1(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// Dead Pixel(=Active[]==0) 수량 검증구문, 결과 OK = 240106 조남인
				/*int ret_cnt = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					if(Active[row, col] == 0)
						ret_cnt++;
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt.ToString());*/


				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active_ISP[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트
							
							float ret = 0;   // 임시 변수

							if ((Active[row - 1, col] + Active[row, col - 1] + Active[row, col + 1] + Active[row + 1, col]
								+ Active[row - 1, col - 1] + Active[row - 1, col + 1] + Active[row + 1, col - 1] + Active[row + 1, col + 1]) == 0)
							{
								// Next Neighbor Pixel 8개가 다 죽은 경우에는 원본값(DEAD=-10000)그대로 유지
								asPixelData[i] = asPixelData[i];
								Active_ISP[row, col] = 0;
							}
							else
							{
								// NNP 와 NP 중 Live Pixel의 평균값
								ret = (float)((Image_buf_disp[row - 1, col] * Active[row - 1, col]
									+ Image_buf_disp[row, col - 1] * Active[row, col - 1]
									+ Image_buf_disp[row, col + 1] * Active[row, col + 1]
									+ Image_buf_disp[row + 1, col] * Active[row + 1, col]
									+ Image_buf_disp[row - 1, col - 1] * Active[row - 1, col - 1]
									+ Image_buf_disp[row - 1, col + 1] * Active[row - 1, col + 1]
									+ Image_buf_disp[row + 1, col - 1] * Active[row + 1, col - 1]
									+ Image_buf_disp[row + 1, col + 1] * Active[row + 1, col + 1])
									  / (Active[row - 1, col] + Active[row, col - 1] + Active[row, col + 1] + Active[row + 1, col]
									  + Active[row - 1, col - 1] + Active[row - 1, col + 1] + Active[row + 1, col - 1] + Active[row + 1, col + 1]));

								Active_ISP[row, col] = 1;
								asPixelData[i] = ret;
							}
						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active_ISP[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		/// <summary>
		/// NNP 픽셀 참조하는 2번 함수
		/// 이 함수에서는 Active_ISP[] 배열이 조건, Active[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NNP2(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// Dead Pixel(=Active[]==0) 수량 검증구문, 결과 OK = 240106 조남인
				/*int ret_cnt = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					if(Active[row, col] == 0)
						ret_cnt++;
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt.ToString());*/


				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active_ISP[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트

							float ret = 0;   // 임시 변수

							if ((Active_ISP[row - 1, col] + Active_ISP[row, col - 1] + Active_ISP[row, col + 1] + Active_ISP[row + 1, col]
								+ Active_ISP[row - 1, col - 1] + Active_ISP[row - 1, col + 1] + Active_ISP[row + 1, col - 1] + Active_ISP[row + 1, col + 1]) == 0)
							{
								// Next Neighbor Pixel 8개가 다 죽은 경우에는 원본값(DEAD=-10000)그대로 유지
								asPixelData[i] = asPixelData[i];
								Active[row, col] = 0;
							}
							else
							{
								// NNP 와 NP 중 Live Pixel의 평균값
								ret = (float)((Image_buf_disp[row - 1, col] * Active_ISP[row - 1, col]
									+ Image_buf_disp[row, col - 1] * Active_ISP[row, col - 1]
									+ Image_buf_disp[row, col + 1] * Active_ISP[row, col + 1]
									+ Image_buf_disp[row + 1, col] * Active_ISP[row + 1, col]
									+ Image_buf_disp[row - 1, col - 1] * Active_ISP[row - 1, col - 1]
									+ Image_buf_disp[row - 1, col + 1] * Active_ISP[row - 1, col + 1]
									+ Image_buf_disp[row + 1, col - 1] * Active_ISP[row + 1, col - 1]
									+ Image_buf_disp[row + 1, col + 1] * Active_ISP[row + 1, col + 1])
									  / (Active_ISP[row - 1, col] + Active_ISP[row, col - 1] + Active_ISP[row, col + 1] + Active_ISP[row + 1, col]
									  + Active_ISP[row - 1, col - 1] + Active_ISP[row - 1, col + 1] + Active_ISP[row + 1, col - 1] + Active_ISP[row + 1, col + 1]));

								Active[row, col] = 1;
								asPixelData[i] = ret;
							}
						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		/// <summary>
		/// DPC 알고리즘 적용 함수
		/// 이 함수에서는 Active[] 배열이 조건, Active_ISP[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NNP_Edge1(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active_ISP[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트

							float ret = 0, ret1 = 0, ret2 = 0, ret3 = 0, ret4 = 0; // 임시 변수

							if ((Active[row - 1, col] + Active[row, col - 1] + Active[row, col + 1] + Active[row + 1, col]
								+ Active[row - 1, col - 1] + Active[row - 1, col + 1] + Active[row + 1, col - 1] + Active[row + 1, col + 1]) == 0)
							{
								// Next Neighbor Pixel 8개가 다 죽은 경우에는 원본값(DEAD=-10000)그대로 유지
								asPixelData[i] = asPixelData[i];
								Active_ISP[row, col] = 0;
							}
							else
							{
								//세로 2개 비교
								if (Active[row - 1, col] == 0 && Active[row + 1, col] == 0)
									ret1 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret1 = (float)Math.Abs(Image_buf_disp[row - 1, col] - Image_buf_disp[row + 1, col]);
								//가로 2개 비교
								if (Active[row, col - 1] == 0 && Active[row, col + 1] == 0)
									ret2 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret2 = (float)Math.Abs(Image_buf_disp[row, col - 1] - Image_buf_disp[row, col + 1]);
								//좌상단 우하단 비교
								if (Active[row - 1, col - 1] == 0 && Active[row + 1, col + 1] == 0)
									ret3 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret3 = (float)Math.Abs(Image_buf_disp[row - 1, col - 1] - Image_buf_disp[row + 1, col + 1]);
								//우상단 좌하단 비교
								if (Active[row - 1, col + 1] == 0 && Active[row + 1, col - 1] == 0)
									ret4 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret4 = (float)Math.Abs(Image_buf_disp[row - 1, col + 1] - Image_buf_disp[row + 1, col - 1]);

								//위에서 비교한 4개의 값 중에 제일 작은 값의 인덱스를 리턴받음
								ret = (float)FindMinIndex(ret1, ret2, ret3, ret4);

								//인덱스 리턴값에 따라서 비교값이 제일 작은, 즉 값이 비슷한 두 픽셀의 평균값을 대입함
								if (ret == 1)
									ret = (float)(Image_buf_disp[row - 1, col] + Image_buf_disp[row + 1, col] / 2) ;
								else if (ret == 2)
									ret = (float)(Image_buf_disp[row, col - 1] + Image_buf_disp[row, col + 1] / 2);
								else if (ret == 3)
									ret = (float)(Image_buf_disp[row - 1, col - 1] + Image_buf_disp[row + 1, col + 1] / 2);
								else  //ret = 4
									ret = (float)(Image_buf_disp[row - 1, col + 1] + Image_buf_disp[row + 1, col - 1] / 2);

								Active_ISP[row, col] = 1;
								asPixelData[i] = ret;
							}
						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active_ISP[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		/// <summary>
		/// DPC 알고리즘 적용 함수
		/// 이 함수에서는 Active_ISP[] 배열이 조건, Active[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NNP_Edge2(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active_ISP[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트

							float ret = 0, ret1 = 0, ret2 = 0, ret3 = 0, ret4 = 0; // 임시 변수

							if ((Active_ISP[row - 1, col] + Active_ISP[row, col - 1] + Active_ISP[row, col + 1] + Active_ISP[row + 1, col]
								+ Active_ISP[row - 1, col - 1] + Active_ISP[row - 1, col + 1] + Active_ISP[row + 1, col - 1] + Active_ISP[row + 1, col + 1]) == 0)
							{
								// Next Neighbor Pixel 8개가 다 죽은 경우에는 원본값(DEAD=-10000)그대로 유지
								asPixelData[i] = asPixelData[i];
								Active[row, col] = 0;
							}
							else
							{
								//세로 2개 비교
								if (Active_ISP[row - 1, col] == 0 && Active_ISP[row + 1, col] == 0)
									ret1 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret1 = (float)Math.Abs(Image_buf_disp[row - 1, col] - Image_buf_disp[row + 1, col]);
								//가로 2개 비교
								if (Active_ISP[row, col - 1] == 0 && Active_ISP[row, col + 1] == 0)
									ret2 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret2 = (float)Math.Abs(Image_buf_disp[row, col - 1] - Image_buf_disp[row, col + 1]);
								//좌상단 우하단 비교
								if (Active_ISP[row - 1, col - 1] == 0 && Active_ISP[row + 1, col + 1] == 0)
									ret3 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret3 = (float)Math.Abs(Image_buf_disp[row - 1, col - 1] - Image_buf_disp[row + 1, col + 1]);
								//우상단 좌하단 비교
								if (Active_ISP[row - 1, col + 1] == 0 && Active_ISP[row + 1, col - 1] == 0)
									ret4 = DEAD * (-1); // 둘 다 죽은 경우에는 값을 10,000으로 만들어 최대치로 보내버림
								else
									ret4 = (float)Math.Abs(Image_buf_disp[row - 1, col + 1] - Image_buf_disp[row + 1, col - 1]);

								//위에서 비교한 4개의 값 중에 제일 작은 값의 인덱스를 리턴받음
								ret = (float)FindMinIndex(ret1, ret2, ret3, ret4);

								//인덱스 리턴값에 따라서 비교값이 제일 작은, 즉 값이 비슷한 두 픽셀의 평균값을 대입함
								if (ret == 1)
									ret = (float)(Image_buf_disp[row - 1, col] + Image_buf_disp[row + 1, col] / 2);
								else if (ret == 2)
									ret = (float)(Image_buf_disp[row, col - 1] + Image_buf_disp[row, col + 1] / 2);
								else if (ret == 3)
									ret = (float)(Image_buf_disp[row - 1, col - 1] + Image_buf_disp[row + 1, col + 1] / 2);
								else  //ret = 4
									ret = (float)(Image_buf_disp[row - 1, col + 1] + Image_buf_disp[row + 1, col - 1] / 2);

								Active[row, col] = 1;
								asPixelData[i] = ret;
							}
						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		/// <summary>
		/// DPC 알고리즘 적용 함수
		/// 이 함수에서는 Active[] 배열이 조건, Active_ISP[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NNP_Total1(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active_ISP[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active_ISP[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트
							float ret = 0.0f;
							float a = -0.5f;
							float root2 = (float)Math.Sqrt(2);
							float coef_root2 = (a * root2 * root2 * root2) 
								- (5.0f * a * root2 * root2) + (8.0f * a * root2) - (4.0f * a);
							float coef_dist1 = (a+2) - (a+3) + 1;

							ret = coef_root2 * Active[row-1, col-1] * Image_buf_disp[row-1, col-1]
								+ coef_root2 * Active[row-1, col+1] * Image_buf_disp[row-1, col+1]
								+ coef_root2 * Active[row+1, col-1] * Image_buf_disp[row+1, col-1]
								+ coef_root2 * Active[row+1, col+1] * Image_buf_disp[row+1, col+1];

							Active_ISP[row, col] = 1;
							asPixelData[i] = ret;
						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active_ISP[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		/// <summary>
		/// DPC 알고리즘 적용 함수
		/// 이 함수에서는 Active_ISP[] 배열이 조건, Active[] 배열이 결과
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DPC_Apply_NNP_Total2(ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				if (iPixelDataSize > 4860) return;

				// DPC 데이터 처리를 위해 buf에 데이터 복사
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					Image_buf_disp[row, col] = asPixelData[i];
				}

				// DPC 알고리즘 반복문
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					// DPC 적용
					if (row == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 0)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (col == 80)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else if (row == 59)
					{
						asPixelData[i] = DEAD;
						Active[row, col] = 0;
					}
					else // 테두리 한줄씩은 위의 'if'와 'else if'에서 죽인 후 else 진입
					{
						if (Active_ISP[row, col] == 1)
						{
							// Live Pixel 은 data 그대로 복사
							asPixelData[i] = (float)Image_buf_disp[row, col];
							Active[row, col] = 1;
						}
						else
						{
							// 죽은 픽셀 보정 파트
							float ret = 0.0f;
							float a = -0.5f;
							float root2 = (float)Math.Sqrt(2);
							float coef_root2 = (a * root2 * root2 * root2)
								- (5.0f * a * root2 * root2) + (8.0f * a * root2) - (4.0f * a);
							float coef_dist1 = (a + 2) - (a + 3) + 1;

							ret = coef_root2 * Active_ISP[row - 1, col - 1] * Image_buf_disp[row - 1, col - 1]
								+ coef_root2 * Active_ISP[row - 1, col + 1] * Image_buf_disp[row - 1, col + 1]
								+ coef_root2 * Active_ISP[row + 1, col - 1] * Image_buf_disp[row + 1, col - 1]
								+ coef_root2 * Active_ISP[row + 1, col + 1] * Image_buf_disp[row + 1, col + 1];

							Active[row, col] = 1;
							asPixelData[i] = ret;

						}
					}
				}

				int ret_cnt2 = 0;
				for (int i = 0; i < iPixelDataSize; i++)
				{
					row = (int)i / COL;
					col = i - row * COL;

					ret_cnt2 += Active[row, col];
				}
				Pixel_DPC_live_perc = Math.Round(ret_cnt2 * 100.0 / 4860);
				LBSet(lbDPC_apply_perc, Pixel_DPC_live_perc.ToString() + " %");
				LBSet(lbDPC_apply_cnt, ret_cnt2.ToString());
			}
			catch (Exception)
			{

			}
		}
		int FindMinIndex(float a, float b, float c, float d)
		{
			// 배열을 사용하여 각 변수의 값을 저장하고, Array.IndexOf로 최소값의 인덱스를 찾음
			float[] values = { a, b, c, d };
			int minIndex = Array.IndexOf(values, values.Min()) + 1;

			return minIndex;
		}
		public void ISP_Offset_Cal(ref float[] asPixelData, int iPixelDataSize)
        {
			for (int i = 0; i < iPixelDataSize; i++)
            {
				row = (int)i / COL;
				col = i - row * COL;

				Image_buf_ISP[ISP_cnt, i] = asPixelData[i];
			}

			ISP_cnt++;

			if (ISP_cnt == 50)
			{
				ISP_cnt %= 50;
				ISP_cnt_flag = true;
				return ;
			}
            else
            {
				return ;
			}
			

		}

		/// <summary>
		/// 감도보정 함수. 25℃↔45℃ Data로 Full Scale을 잡고 Gain을 이용하여 증가시킴
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void Sensitivity_Cal(ref float[] asPixelData, int iPixelDataSize)
        {
			if (iPixelDataSize > 4860) return;

			float[,] tmep_Origin = new float[ROW, COL];
			float[,] temp_aiRet1 = new float[ROW, COL];
			double[,] temp_aiRet2 = new double[ROW, COL];
			double[,] temp_aiRet3 = new double[ROW, COL];
			float[,] temp_short_new = new float[ROW, COL];
			float[,] temp_short_old = new float[ROW, COL];

			int temp_debugMode = 0;   // 0 : new ,  1 : old

			for (int i = 0; i < iPixelDataSize; i++)
            {
				row = (int)i / COL;
				col = i - row * COL;

				tmep_Origin[row, col] = asPixelData[i];   // 원본 복사
				temp_aiRet1[row, col] = asPixelData[i] - Image_buf_offset[row, col];   // Measure - Offset
				temp_aiRet2[row, col] = temp_aiRet1[row, col] / sensitivity_buf[row, col];  // (Measure - Offset) ÷ Signal
				temp_aiRet3[row, col] = temp_aiRet2[row, col] * GAIN;   // ((Measure - Offset) ÷ Signal) * GAIN
				temp_short_new[row, col] = (float) temp_aiRet3[row, col];

				// 기존에 float형으로 사용하던 원본 2024.02.05
				Image_buf[row, col] = asPixelData[i] - Image_buf_offset[row, col];
				Image_buf[row, col] = (int)(GAIN * (double)Image_buf[row, col] / sensitivity_buf[row, col]);
				temp_short_old[row, col] = (float)(Image_buf[row, col]);

				if (temp_debugMode == 0)
					asPixelData[i] = temp_short_new[row, col];
				else
					asPixelData[i] = temp_short_old[row, col];

				// Gaing Cal과 NF 와 DPC 순서를 바꿔가며 할 때 사용한 구문
				//asPixelData[i] = (float) (Image_buf[row,col] * Active[row,col]);
			}

			return;
        }
		/// <summary>
		/// Dark Pixel Line(80번Column)의 Avg.를 모든 Pixel에서 빼주는 함수
		/// 시간에 따른 Dark Pixel의 움직임을 상쇄하기 위함
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		public void DarkAvg_Apply(ref float[] asPixelData, int iPixelDataSize)
		{
			if (iPixelDataSize > 4860) return;

			double[] ret_avg_buff = new double[60];
			double ret_avg = 0;

			for ( int i = 0; i < 60; i++)
            {
				ret_avg_buff[i] = asPixelData[i * 81 + 80];
				ret_avg += ret_avg_buff[i];

			}

			ret_avg = Math.Round(ret_avg /= 60,0);

			for (int i = 0; i < iPixelDataSize; i++)
			{
				row = (int)i / COL;
				col = i - row * COL;

				Image_buf_Dark[row, col] = (int)(asPixelData[i] - ret_avg);

				asPixelData[i] = (float)(Image_buf_Dark[row, col]);
			}

			return;
		}
		/// <summary>
		/// Receive Data / Display Data / Chart Data 를 비교하기 위한 검증용 함수
		/// 이 함수에서는 Receive Data를 메모리(배열)에 받는 동안 Display와 Chart를 막다가 Receive가 끝나면 csv파일에 저장한다
		/// </summary>
		/// <param name="g_asDataverify"></param>
		/// <returns></returns>
		public bool DataVerify(float[] asDataverify)
        {
			int iDataverify = 100;
			
			for (int i = 0; i < asDataverify.Length; i++)
			{
				aiDataverify[g_iDataVerifyCnt, i] = Get_PixelData(asDataverify, i);
			}
			
			g_iDataVerifyCnt++;

			if (g_iDataVerifyCnt < iDataverify)
			{
				LOG("DataVerify : " + g_iDataVerifyCnt.ToString(), Color.Red); // 1 ~ 99 카운팅
				return false;
			}
			else
			{
				LOG("DataVerify : " + g_iDataVerifyCnt.ToString(), Color.Red); // 100 카운팅

				Dataverify_save(aiDataverify);

				LOG("Log 저장 완료", Color.Red); // 100 카운팅

				g_iDataVerifyCnt = 0;
				Array.Clear(aiDataverify, 0, aiDataverify.Length);

				return true;
			}

        }
		/// <summary>
		/// Monte Carlo Method를 위해 만든 함수 : 2024.02.07
		/// 자료형을 short에서 float를 바꾼 후 frame을 합하여 분해능 향상 도모
		/// </summary>
		/// <param name="g_asPixelData"></param>
		/// <param name="iAvrCnt">합칠 Frame 갯수를 입력하면 됨</param>
		/// <returns></returns>
		public bool monteCarlo_Method(ref float[] g_asPixelData, int iAvrCnt)
		{
			// BookMark #10 : Monte Carlo Method를 사용할 함수

			for (int i = 0; i < g_asPixelData.Length; i++)
			{
				g_aiMonteAvrData_Cal[g_iMonteAvrCnt_Cal, i] = Get_PixelData(g_asPixelData, i);
			}

			g_iMonteAvrCnt_Cal++;
			g_iMonteAvrCnt_Cal %= iAvrCnt;

			if (g_iBuffer_Monte_no < iAvrCnt)
			{
				g_iBuffer_Monte_no++;
				return false;
			}

			Array.Clear(g_aiAvrData_Monte, 0, g_aiAvrData_Monte.Length);

			for (int i = 0; i < g_aiAvrData_Monte.Length; i++)
			{
				g_aiAvrData_Monte[i] = g_aiMaxData_Monte[i] = g_aiMinData_Monte[i] = g_aiMonteAvrData_Cal[0, i];
				for (int j = 1; j < iAvrCnt; j++)
				{
					g_aiAvrData_Monte[i] += g_aiMonteAvrData_Cal[j, i];
					if (g_aiMaxData_Monte[i] < g_aiMonteAvrData_Cal[j, i]) g_aiMaxData_Monte[i] = g_aiMonteAvrData_Cal[j, i];
					if (g_aiMinData_Monte[i] > g_aiMonteAvrData_Cal[j, i]) g_aiMinData_Monte[i] = g_aiMonteAvrData_Cal[j, i];
				}
				g_aiAvrData_Monte[i] -= (g_aiMaxData_Monte[i] + g_aiMinData_Monte[i]);
				//g_aiAvrData_Monte[i] /= (int)(iAvrCnt - 2);

				Set_PixelData(ref g_asPixelData, i, (float)g_aiAvrData_Monte[i]);
			}

			return true;
		}
		/// <summary>
		/// 기존의 move8 함수는 진정한 이동평균이 아니여서 새롭게 추가함
		/// 23' 12/28 엑셀로 검증함 - 조남인
		/// 이 함수를 사용하고 나면 'g_iMoveAvrCnt_Cal' 'g_iBuffer_Cal_no' 'g_aiMoveAvrData_Cal' 초기화를 잘 해야함
		/// </summary>
		/// <param name="g_asPixelData_Cal"></param>
		/// <param name="iAvrCnt">합칠 Frame 갯수를 입력하면 됨</param>
		/// <returns></returns>
		public bool moveAverage_cal(ref float[] g_asPixelData_Cal, int iAvrCnt)
		{
			// BookMark #9 : Moving Average를 별도로 사용할 수 있는 함수

			for (int i = 0; i < g_asPixelData_Cal.Length; i++)
			{
				g_aiMoveAvrData_Cal[g_iMoveAvrCnt_Cal, i] = Get_PixelData(g_asPixelData_Cal, i);
			}

			g_iMoveAvrCnt_Cal++;
			g_iMoveAvrCnt_Cal %= iAvrCnt;

			if (g_iBuffer_Cal_no < iAvrCnt)
			{
				g_iBuffer_Cal_no++;
				return false;
			}

			Array.Clear(g_aiAvrData_Cal, 0, g_aiAvrData_Cal.Length);

			for (int i = 0; i < g_aiAvrData_Cal.Length; i++)
			{
				g_aiAvrData_Cal[i] = g_aiMaxData_Cal[i] = g_aiMinData_Cal[i] = g_aiMoveAvrData_Cal[0, i];
				for (int j = 1; j < iAvrCnt; j++)
				{
					g_aiAvrData_Cal[i] += g_aiMoveAvrData_Cal[j, i];
					if (g_aiMaxData_Cal[i] < g_aiMoveAvrData_Cal[j, i]) g_aiMaxData_Cal[i] = g_aiMoveAvrData_Cal[j, i];
					if (g_aiMinData_Cal[i] > g_aiMoveAvrData_Cal[j, i]) g_aiMinData_Cal[i] = g_aiMoveAvrData_Cal[j, i];
				}
				g_aiAvrData_Cal[i] -= (g_aiMaxData_Cal[i] + g_aiMinData_Cal[i]);
				g_aiAvrData_Cal[i] /= (int)(iAvrCnt - 2);

				Set_PixelData(ref g_asPixelData_Cal, i, (float)g_aiAvrData_Cal[i]);
			}

			return true;
		}
		/// <summary>
		/// 박사님이 말씀하신 Pulse Noise 잡는 함수
		/// 일정 프레임의 평균을 기준으로 그보다 크거나 작은 값은 버린다
		/// </summary>
		/// <param name="g_asPixelData_Cal"></param>
		/// <param name="iAvrCnt"></param>
		/// <returns></returns>
		public bool PulseAverage_filter(ref float[] asPixelData, int iPixelDataSize, int iAvrCnt)
		{
			if (iPixelDataSize > 4860) return false;

			#region [버퍼에 iAvrCnt개의 데이터를 계속 채우는 부분]
			for (int i = 0; i < iPixelDataSize; i++)
			{
				Image_buf_pulse[Pulse_cnt, i] = asPixelData[i];
			}

			Pulse_cnt++;

			if ((Pulse_cnt < iAvrCnt) && Pulse_cnt_flag == false)
			{
				LOG("화면조정중 : " + Pulse_cnt.ToString(), Color.Red);
				return false;
			}
			else
			{
				Pulse_cnt %= iAvrCnt;
				Pulse_cnt_flag = true;
			}
			#endregion

			// 검증용 배열
			/*float[,] Image_buf_ret = new float[4860, 100];
			for (int i = 0; i < iPixelDataSize; i++)
			{
				for(int j = 0; j < iAvrCnt; j++)
					Image_buf_ret[i,j] = Image_buf_pulse[j, i];
			}*/

			#region 'Pulse_cnt_flag' True 된 후에 데이터 처리 부분
			if (Pulse_cnt_flag == false) return false;  //혹시 모를 버그 처리 구문
            else
            {
				// 반복문을 통해 iAvrCnt 버퍼만큼의 평균,min,Max를 구하고 Pulse 픽셀인지 판정해서 값을 정함
				for (int i = 0; i < iPixelDataSize; i++)
				{
					Image_buf_pulse_avg[i] = Image_buf_pulse_min[i] = Image_buf_pulse_max[i] = Image_buf_pulse[0, i];

					for (int j = 1; j < iAvrCnt; j++)
					{
						Image_buf_pulse_avg[i] += Image_buf_pulse[j, i];
						if (Image_buf_pulse_min[i] > Image_buf_pulse[j, i]) Image_buf_pulse_min[i] = Image_buf_pulse[j, i];
						if (Image_buf_pulse_max[i] < Image_buf_pulse[j, i]) Image_buf_pulse_max[i] = Image_buf_pulse[j, i];
					}
					Image_buf_pulse_avg[i] /= (float)iAvrCnt ;

					// 위에서 계산된 avg,min,max를 통해 pulse noise 픽셀 선정 및 처리
					if (Math.Abs(Image_buf_pulse_max[i] - Image_buf_pulse_min[i]) > 255)
					{
						int ret;

						if (Pulse_cnt == 0) ret = (iAvrCnt-1);
						else ret = Pulse_cnt - 1;

						while (Image_buf_pulse[ret, i] >= Image_buf_pulse_avg[i])
						{
							if (ret < 1) ret = (iAvrCnt-1);
							else ret--;
						}

						asPixelData[i] = Image_buf_pulse[ret, i];
						
						/*if(Math.Abs(Image_buf_pulse_max[i] - Image_buf_pulse_avg[i]) > Math.Abs(Image_buf_pulse_min[i] - Image_buf_pulse_avg[i]))
                        {
							// 여기에 들어온다는 것은 avg가 min에 더 가깝다, 즉 min 쪽이 real data일 확률이 높다.
						}
						else
                        {
							// 여기에 들어온다는 것은 avg가 max에 더 가깝다, 즉 max 쪽이 real data일 확률이 높다.
							while (Image_buf_pulse[ret, i] <= Image_buf_pulse_avg[i])
							{
								if (ret < 1) ret = (iAvrCnt - 1);
								else ret--;
							}

							asPixelData[i] = Image_buf_pulse[ret, i];
						}*/

						
					}
					else asPixelData[i] = asPixelData[i];
				}

				return true;
            }
            #endregion
        }
        /// <summary>
        /// float == int16 이며, -32768 ~ 32767 (0x8000 ~ 0x7FFF) 의 범위의 값을 가진다.
        /// 0x8000 == -32768 / 0xFFFF == -1 (2의 보수로 변환이 된다.)
        /// </summary>
        /// <param name="abyPixelData"></param>
        /// <param name="iDataSize"></param>
        /// <param name="asPixelData"></param>
        public void Convert_PixelData (byte[] abyPixelData, int iDataSize, ref float[] asPixelData)
		{
			try
			{
				Array.Clear (asPixelData, 0, asPixelData.Length);
				
				short[] temp_asPixelData = new short[4860];

				if ((iDataSize / 2) > asPixelData.Length)		return;
				
				for (int i = 0; i < iDataSize / 2; i++)
				{
					// 바이트 데이터 변환 원본
					temp_asPixelData[i] = (short)(abyPixelData[i * 2 + 0] << 0 | abyPixelData[i * 2 + 1] << 8);
					asPixelData[i] = (float) temp_asPixelData[i];

					// 20240116 테스트 코드 (= 1줄짜리 원본코드와 항상 같은것으로 검증함)
					/*int32data = abyPixelData[i * 2 + 0] + 256 * abyPixelData[i * 2 + 1];
                    if ((int32data > 32767)) int32data = -1 * (1 - int32data + 65535);
                    asPixelData[i] = (float)(int32data);*/

					// 20240126 테스트 코드 = BFE 보수처리 따라함
					//int32data = abyPixelData[i * 2 + 0] + 256 * abyPixelData[i * 2 + 1];
					//if ((int32data > 16383)) int32data = (-1) * (1 - int32data + 32768);
					//if(int32data>0) 
					//asPixelData[i] = (float)(int32data);
					//if (int32data < 0) asPixelData[i] = (float)(-int32data);

					// 20240109 상위비트의 &연산 추가
					//asPixelData[i] = (float)((abyPixelData[i * 2 + 0] << 0 | abyPixelData[i * 2 + 1] << 8) & 0x00FF);
				}
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// iY = 0 ~ 59, iX = 0 ~ 80 까지의 범위를 가진다.
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iX"></param>
		/// <param name="iY"></param>
		/// <returns></returns>
		public float Get_PixelData (float[] asPixelData, int iX, int iY)
		{
			float sData = 0;

			try
			{
				sData = asPixelData[iY * 81 + iX];
			}
//			catch (Exception ex)
			catch (Exception)
			{
//				ERR (ex.Message);
				return 0;
			}

			return sData;
		}

		/// <summary>
		/// iIndex = 0 ~ 4859 의 값을 가진다.
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iIndex"></param>
		/// <returns></returns>
		public float Get_PixelData (float[] asPixelData, int iIndex)
		{
			float sData = 0;

			try
			{
				sData = asPixelData[iIndex];
			}
//			catch (Exception ex)
			catch (Exception)
			{
//				ERR (ex.Message);
				return 0;
			}

			return sData;
		}

		/// <summary>
		/// iIndex = 0 ~ 4859 의 값을 가진다.
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iIndex"></param>
		/// <param name="sSetData"></param>
		public void Set_PixelData (ref float[] asPixelData, int iIndex, float sSetData)
		{
			try
			{
				asPixelData[iIndex] = sSetData;
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// iY = 0 ~ 59, iX = 0 ~ 80 까지의 범위를 가진다.
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iX"></param>
		/// <param name="iY"></param>
		/// <param name="sSetData"></param>
		public void Set_PixelData (ref float[] asPixelData, int iX, int iY, float sSetData)
		{
			try
			{
				asPixelData[iY * 81 + iX] = sSetData;
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// Pixel_Value = Pixel_Value + Offset_Value
		/// 5 회 카운트 후 입력된 Offset Value 적용한다.
		/// </summary>		/// <param name="asPixelData"></param>
		/// <param name="iPixelSize"></param>
		/// <param name="asOffsetData"></param>
		public void Tas1945_Set_PixelOffset (ref float[] asPixelData, int iPixelSize, float[] asOffsetData)
		{
			float iValue;

			try
			{	
				if (iPixelSize > 4860)		return;

				if (cbOffset_apply.Checked == false) return;

				for (int i = 0; i < iPixelSize; i++)
				{
					// 20231108 원본 코드
					
					iValue = Get_PixelData(asPixelData, i);    //	참고 : int 로 받아도 원 Data 가 2 byte 이기 때문에 음수가 되지는 않는다. 계산하기 편하기 위해 int 로 변환
					iValue -= Get_PixelData(asOffsetData, i);
					if(cbABS_apply.Checked == true) iValue = Math.Abs(iValue);

					// 20231108 박사님 코드 = 플러스 마이너스 반전개념
					/*iValue = - Get_PixelData (asPixelData, i);	//	참고 : int 로 받아도 원 Data 가 2 byte 이기 때문에 음수가 되지는 않는다. 계산하기 편하기 위해 int 로 변환
					iValue += Get_PixelData (asOffsetData, i);*/

					Set_PixelData (ref asPixelData, i, (float)iValue);
				}
				//if (data_status != 2) LOG("비상!!", Color.Red);
				//data_status = 3;
				//LOG($"Data Status = {data_status} → Offset 적용완료", Color.Green);
			}
			//catch (Exception)
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 설정된 회 카운트 후 입력된 Pixel 값을 가지고 Offset Value 측정한다.
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelSize"></param>
		/// <param name="asOffsetData"></param>
		public void Tas1945_CalPixelOffset (float[] asPixelData, int iPixelSize, ref float[] asOffsetData)
		{
			float iValue = 0;

			try
			{
				int iRefValue = (int)NUDGet (nudSetCenterValue);

				for (int i = 0; i < asOffsetData.Length; i++)
				{ 
					iValue = Get_PixelData (asPixelData, i);

					asOffsetData[i] = (float)(iValue - iRefValue);
				}
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// 전체 Pixel 을 더한것을 Pixel 갯수, 누적횟수(Average count) 로 나누어서 평균을 내어 각 Pixel 에서 평균값을 뺀 것을 Offset 으로 생성
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelSize"></param>
		/// <param name="iAvrCnt"></param>
		/// <param name="asOffsetData"></param>
		/// <param name="bApply"></param>
		public void Tas1945_CalAvrPixelOffset (float[] asPixelData, int iPixelSize, int iAvrCnt, ref float[] asOffsetData, bool bApply)
		{
			float iValue = 0;

			try
			{
				for (int i = 0; i < iPixelSize; i++)
				{ 
					iValue = Get_PixelData (asPixelData, i);

					g_aiOffAvrData[i] += iValue;
				}

				if (bApply == true)
				{
					for (int i = 0; i < asOffsetData.Length; i++)
					{
						asOffsetData[i] = (float)(g_aiOffAvrData[i] / iAvrCnt);
					}
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
		/// <param name="abyData"></param>
		/// <param name="iSize"></param>
		/// <param name="iStartIdx"></param>
		/// <param name="iSaveSize"></param>
		public void Tas1945_TextSave (byte[] abyData, int iSize, int iStartIdx, int iSaveSize)
		{
			if (g_bCsvOn == false)	return;

			if (iSaveSize % 9600 != 0)	return;

			RawLog_TextFileOpen ();
			
			//	80 * 60 * 2 개씩 나누어서 라인 바꿔서 저장
			for (int i = 0; i < iSaveSize / 9600; i++)
			{
				RawLog_TextFileWrite (HexArrToAscStr (abyData, iStartIdx + (9600 * i), 9600, false));
			}

			RawLog_TextFileClose ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abySaveData"></param>
		/// <param name="iSaveSize"></param>
		/// <param name="iStartIdx"></param>
		/// <param name="iSaveCnt"></param>
		public void Tas1945_CvsSave (byte[] abySaveData, int iSaveSize, int iStartIdx, int iSaveCnt)
		{
			if (iSaveSize - iStartIdx <  9600 * iSaveCnt)	return;

			RawLog_CsvFileOpen ();

			for (int i = 0; i < iSaveCnt; i++)
			{
				for (int iRow = 0; iRow < 60; iRow++)
				{
					RawLog_CsvFileWrite ("P-" + iRow.ToString () + ", ");

					for (int iCol = 0; iCol < 80; iCol++)
					{
						UInt16 u16RawData = (UInt16)(abySaveData[iStartIdx + (9600 * i) + (iRow * 80 * 2) + (iCol * 2)] << 0 | abySaveData[iStartIdx + (9600 * i) + (iRow * 80 * 2) + (iCol * 2) + 1] << 8);

						RawLog_CsvFileWrite (u16RawData.ToString () + ", ");
					}

					swCsvStreamW.Write ("\n");
				}
			}

			swCsvStreamW.Write ("\n\n");

			RawLog_CsvFileClose ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uiP1"></param>
		/// <param name="uiP2"></param>
		/// <param name="uiP3"></param>
		/// <param name="uiP4"></param>
		/// <param name="uiP5"></param>
		public void Tas1945_PixelInfoCvsSave (uint uiP1, uint uiP2, uint uiP3, uint uiP4, uint uiP5, uint uiTP)
		{
			try
			{
				RawLog_CsvFileWrite (uiP1.ToString () + ", ");
				RawLog_CsvFileWrite (uiP2.ToString () + ", ");
				RawLog_CsvFileWrite (uiP3.ToString () + ", ");
				RawLog_CsvFileWrite (uiP4.ToString () + ", ");
				RawLog_CsvFileWrite (uiP5.ToString () + ", ");
				RawLog_CsvFileWrite (uiTP.ToString () + ", ");

				swCsvStreamW.Write ("\n");
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="uiP1"></param>
		/// <param name="uiP2"></param>
		/// <param name="uiP3"></param>
		/// <param name="uiP4"></param>
		/// <param name="uiP5"></param>
		public void Tas1945_PixelInfoCvsSaveInt (float iP1, float iP2, float iP3, float iP4, float iP5, float iTP)
		{
			try
			{
				RawLog_CsvFileWrite (iP1.ToString () + ", ");
				RawLog_CsvFileWrite (iP2.ToString () + ", ");
				RawLog_CsvFileWrite (iP3.ToString () + ", ");
				RawLog_CsvFileWrite (iP4.ToString () + ", ");
				RawLog_CsvFileWrite (iP5.ToString () + ", ");
				RawLog_CsvFileWrite (iTP.ToString () + ", ");

				swCsvStreamW.Write ("\n");
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="iT1"></param>
		/// <param name="iT2"></param>
		/// <param name="iT3"></param>
		public void Tas1945_TestPixelCsvSave (float iT1, float iT2, float iT3)
		{
			try
			{
				RawLog_CsvFileWrite (iT1.ToString () + ", ");
				RawLog_CsvFileWrite (iT2.ToString () + ", ");
				RawLog_CsvFileWrite (iT3.ToString () + ", ");

				swCsvStreamW.Write ("\n");
			}
			catch (Exception)
			{
				;
			}
		}

		public void Tas1945_TestPixelCsvSave(float iT1, float iT2, float iT3, float iT4, float iT5)
		{
			try
			{
				RawLog_CsvFileWrite(iT1.ToString() + ", ");
				RawLog_CsvFileWrite(iT2.ToString() + ", ");
				RawLog_CsvFileWrite(iT3.ToString() + ", ");
				RawLog_CsvFileWrite(iT4.ToString() + ", ");
				RawLog_CsvFileWrite(iT5.ToString() + ", ");

				swCsvStreamW.Write("\n");
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abySaveData"></param>
		/// <param name="iSaveSize"></param>
		/// <param name="iStartIdx"></param>
		public void Tas1945_CvsAvrSave (byte[] abySaveData, int iSaveSize, int iStartIdx)
		{
			if (g_bCsvOn == false)	return;

			if (iSaveSize - iStartIdx <  9600)	return;

			RawLog_CsvFileOpen ("AVR_");

			for (int iRow = 0; iRow < 60; iRow++)
			{
				RawLog_CsvFileWrite ("P-" + iRow.ToString () + ", ");

				for (int iCol = 0; iCol < 80; iCol++)
				{
					UInt16 u16RawData = (UInt16)(abySaveData[iStartIdx + (iRow * 80 * 2) + (iCol * 2)] << 0 | abySaveData[iStartIdx + (iRow * 80 * 2) + (iCol * 2) + 1] << 8);

					RawLog_CsvFileWrite (u16RawData.ToString () + ", ");
				}

				swCsvStreamW.Write ("\n");
			}

			swCsvStreamW.Write ("\n\n");

			RawLog_CsvFileClose ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bReadStart"></param>
		public void Tas1945_PL_StatusCheck (bool bRunning)
		{
			if (TGSGet (tgsNetMode) == true)	return;

			//	PL read
			if (bRunning == false)
			{
				if (BTNGet (btnSetReadPLStart) == "PL Stop")
				{	
					BTNSet (btnSetReadPLStart, "PL Read");
		
					Tas1945_PLReadCtrl (false);
		
					if (Resp_CheckWait (5000) == false)		return;
				}
			}
			else
			{
				if (BTNGet (btnSetReadPLStart) == "PL Read")
				{	
					BTNSet (btnSetReadPLStart, "PL Stop");
		
					Tas1945_PLReadCtrl (true);
		
					if (Resp_CheckWait (5000) == false)		return;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterWrite ()
		{
			byte[]		abyConv = new byte[2];
			byte[]		abyData = new byte[2];

			//	PL read
			Tas1945_PL_StatusCheck (false);

			if (AscStrToHexArr (tbRegData.Text, ref abyConv) > 1)
			{
				ERR ("Data length over\n");
				return;
			}

			abyData[0] = (byte)NUDGet (nudRegAddr);
			abyData[1] = abyConv[0];

			LOG ("REG WR : " + abyData[0].ToString () + ", " + abyData[1].ToString () + "[0x" + HexToAscStr (abyData[1], false) + "]" , Color.Blue);

			Tas1945_TcpUdpSend ((uint)REQ.REG_WR, abyData, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byRegAddr"></param>
		/// <param name="byRegData"></param>
		public void Tas1945_RegisterWrite (byte byRegAddr, byte byRegData)
		{
			byte[]		abyData = new byte[2];

			//	PL read
			Tas1945_PL_StatusCheck (false);

			abyData[0] = byRegAddr;
			abyData[1] = byRegData;

			LOG ("REG WR : " + byRegAddr.ToString () + ", " + byRegData.ToString () + "[0x" + HexToAscStr (byRegData, false) + "]", Color.Blue);

			Tas1945_TcpUdpSend ((uint)REQ.REG_WR, abyData, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterRead (byte byMainUi)
		{
			byte[]		abyData = new byte[1];

			//	PL read
			Tas1945_PL_StatusCheck (false);

			abyData[0] = (byte)NUDGet (nudRegAddr);

			g_byReadDspMode = byMainUi;

			Tas1945_TcpUdpSend ((uint)REQ.REG_RD, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterRead (byte byAddr, byte byMainUi)
		{
			byte[]		abyData = new byte[1];

			//	PL read
			Tas1945_PL_StatusCheck (false);

			abyData[0] = byAddr;

			g_byReadDspMode = byMainUi;

			Tas1945_TcpUdpSend ((uint)REQ.REG_RD, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_GetPixelInfo ()
		{
			byte[]		abyData = new byte[2];

			g_queImage.Clear ();

			if (RBGet (rbFpgaAvr) == false)
			{
				if (RBGet (rbSingleOdd) == true)
				{
					abyData[0] = 0x01;
				}
				else if (RBGet (rbSingleEven) == true)
				{
					abyData[0] = 0x02;
				}
				else
				{
					if (g_bOddEvenToggle == true)
					{
						abyData[0] = 0x01;
						g_bOddEvenToggle = false;
					}
					else
					{
						abyData[0] = 0x02;
						g_bOddEvenToggle = true;
					}
				}
			}
			else
			{
				if (TGSGet (tgsNetMode) == true)
				{
					if (RBGet (rbFpgaAvr) == true)
					{
						abyData[0] = 0x03;

						abyData[1] = (byte)NUDGet (nudAvrCnt);
						abyData[1] /= 2;
					}
					else
					{
						if		(RBGet (rbSingleOdd) == true)	abyData[0] = 0x01;
						else if (RBGet (rbSingleEven) == true)	abyData[0] = 0x02;
					}
				}
			}

			if (RBGet (rbFpgaAvr) == false)
			{
				Tas1945_TcpUdpSend ((uint)REQ.GET_SNG_RD_81x60, abyData, 1);
			}
			else
			{
				if (TGSGet (tgsNetMode) == true)
				{
					Tas1945_TcpUdpSend ((uint)REQ.GET_AVR_RD_81x60, abyData, 2);
				}
				else
				{
					Tas1945_TcpUdpSend ((uint)REQ.GET_AVR_RD_81x60, null, 0);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_GetPixelInfoPushMode ()
		{
			byte[]		abyData = new byte[2];

			Array.Clear (g_abyPixelData, 0, g_abyPixelData.Length);

			if (RBGet (rbSingleOdd) == true)		abyData[0] = (byte)0x01;
			else if (RBGet (rbSingleEven) == true)	abyData[0] = (byte)0x02;
			else									abyData[0] = (byte)0x03;

			if (RBGet (rbFpgaAvr) == false)		Tas1945_TcpUdpSend ((uint)REQ.GET_SNG_PUSH_81x60, abyData, 1);
			else								Tas1945_TcpUdpSend ((uint)REQ.GET_AVR_PUSH_81x60, null, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_PushModeStop ()
		{
			byte[]		abyData = new byte[2];

			abyData[0] = 0x03;

			Tas1945_TcpUdpSend ((uint)REQ.SET_PIXEL_READ, abyData, 1);

			if (Resp_CheckWait (5000) == false)		return;

			Thread.Sleep (500);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_Reset ()
		{
			Tas1945_TcpUdpSend ((uint)REQ.DEV_RST, null, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_PLReadCtrl (bool bStart)
		{	
			byte[]		abyData = new byte[2];

			g_bPLReadStart = bStart;

			if (bStart == true)		abyData[0] = 0x01;
			else					abyData[0] = 0x02;

			Tas1945_TcpUdpSend ((uint)REQ.SET_PIXEL_READ, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_Resend ()
		{	
			Tas1945_TcpUdpSend ((uint)REQ.RESEND_REQ, null, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_IpSetup ()
		{	
			string	strSetIp;

			strSetIp = ipSetAddress.Text + ":" + NUDGet (nupSetPort).ToString ();

			byte[]	abyIpData = Encoding.UTF8.GetBytes (strSetIp);
			byte[]	abySendData = new byte[abyIpData.Length + 1];

			if (RBGet (rbSetIpServer) == true)	abySendData[0] = 0x01;
			else								abySendData[0] = 0x02;

			Array.Copy (abyIpData, 0, abySendData, 1, abyIpData.Length);

			Tas1945_TcpUdpSend ((uint)REQ.SET_IP, abySendData, (uint)abySendData.Length);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="asOffset"></param>
		/// <param name="bX"></param>
		public void Tas1945_Set_DarkPixelInfo (float[] asPixelData, ref float[] asOffset, bool bX)
		{
			try
			{
				Array.Clear (asOffset, 0, asOffset.Length);

				if (bX == true)
				{
					//	Offset
					for (int x = 0; x < asOffset.Length; x++)
					{
						asOffset[x] = Get_PixelData (asPixelData, x, (int)NUDGet (nudDark_X));
					}
				}
				else
				{
					//	Offset
					for (int y = 0; y < asOffset.Length; y++)
					{
						asOffset[y] = Get_PixelData (asPixelData, (int)NUDGet (nudDark_Y), y);
					}
				}
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// Pixel_Value = Pixel_Value + 2^15 - Dark_Value
		/// 중간 값을 기준으로 Pixel Value 를 조정한다.
		/// </summary>
		/// <param name="abyPixelData"></param>
		/// <param name="iPixelSize"></param>
		public void Tas1945_Set_DarkPixelOffset (ref float[] asPixelData, int iPixelSize, float[] asOffset, bool bX)
		{
			try
			{
				float iPixelData;
				int iDarkY = (int)NUDGet (nudDark_X);
				int iDarkX = (int)NUDGet (nudDark_Y);

				if (bX == true)
				{
					for (int y = 0; y < 60; y++)
					{
						//if (y != iDarkY)       //	Dark Pixel 적용 된 것은 Skip
						//{
							for (int x = 0; x < 81; x++)
							{
								iPixelData = Get_PixelData (asPixelData, x, y);		
								
								//iPixelData = iPixelData + (int)Math.Pow (2, 15) - (int)g_aiDarkX_PixelOffset[x];
								iPixelData = iPixelData - asOffset[x];

								Set_PixelData (ref asPixelData, x, y, (float)iPixelData);
							}
						//}
					}
				}
				else
				{
					for (int y = 0; y < 60; y++)
					{
						for (int x = 0; x < 81; x++)
						{
							//if (x != iDarkX)		//	Dark Pixel 적용 된 것은 Skip
							//{
								iPixelData = Get_PixelData (asPixelData, x, y);
								
								//iPixelData = iPixelData + (int)Math.Pow (2, 15) - (int)g_aiDarkY_PixelOffset[y];
								iPixelData = iPixelData - asOffset[y];
								
								Set_PixelData (ref asPixelData, x, y, (float)iPixelData);
							//}
						}
					}
				}
			}
			//catch (Exception)
			catch (Exception ex)
			{
				ERR (ex.Message);		//
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="iSetTime"></param>
		/// <returns></returns>
		public bool Resp_CheckWait (int iSetTime)
		{
			DateTime dtCommTick;

			dtCommTick = DateTime.Now;

			while (CheckWait (iSetTime, dtCommTick) != true)
			{
				Application.DoEvents ();

				if (g_bCommComplete == true)		break;
			}

			if (g_bCommComplete == false)
			{
				ERR ("Time out error\n");
				return	false;
			}

			return	true;
		}
				
		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_InitDataAllRead ()
		{
			try
			{
				byte[]		abyConv = new byte[2];
				string		strData = String.Empty;

				//	255 register setting - 0x00
				Tas1945_RegisterWrite (255, 0x00);				//	255, 0x00

				if (Resp_CheckWait (5000) == false)		return;

				//	255 register verity
				Tas1945_RegisterRead (255, 2);
				if (Resp_CheckWait (5000) == false)		return;

				/*
				if (Get_RegisterDataTextBox (255) != 0x00)
				{
					g_fMainForm.ERR ("Miss match !!!");
					return;
				}
				*/

				g_bCommComplete = false;

				for (int iAddr = 0; iAddr < 255; iAddr++)
				{
					//	spare 처리
					if (iAddr >= 44 && iAddr <= 47)		continue;
					if (iAddr >= 96 && iAddr <= 111)	continue;
					if (iAddr == 120)					continue;
					if (iAddr >= 124 && iAddr <= 126)	continue;
					if (iAddr >= 142 && iAddr <= 143)	continue;
					if (iAddr >= 145 && iAddr <= 153)	continue;
					if (iAddr == 159)					continue;
					if (iAddr >= 160 && iAddr <= 175)	continue;
					if (iAddr >= 183 && iAddr <= 189)	continue;
					if (iAddr >= 192 && iAddr <= 207)	continue;
					if (iAddr >= 222 && iAddr <= 223)	continue;
					if (iAddr >= 224 && iAddr <= 239)	continue;
					if (iAddr >= 241 && iAddr <= 254)	continue;

					Tas1945_RegisterRead ((byte)iAddr, 2);
					if (Resp_CheckWait (5000) == false)		return;

					g_bCommComplete = false;
				}

				/*
				//	255 register setting - 0x00
				g_fMainForm.Tas1945_RegisterWrite (255, 0x00);				//	255, 0x00

				if (Resp_CheckWait (5000) == false)		return;

				//	255 register verity
				g_fMainForm.Tas1945_RegisterRead (255, false);
				if (Resp_CheckWait (5000) == false)		return;

				if (Get_RegisterDataTextBox (255) != 0x00)
				{
					g_fMainForm.ERR ("Miss match !!!");
					return;
				}
				*/

				LOG ("Initialize Register read  ok!!!");
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_SetClock ()
		{
			byte[]		abyData = new byte[1];

			abyData[0] = (byte)NUDGet (nudSetClock);

			Tas1945_TcpUdpSend ((uint)REQ.SET_SPI_CLOCK, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_SetRead ()
		{
			byte[]		abyData = new byte[2];

			abyData[0] = (byte)NUDGet (nudClockDelay);
			abyData[1] = (byte)((TGSGet (tgsReadEdge) == false) ? 0x00 : 0x01);

			Tas1945_TcpUdpSend ((uint)REQ.SET_SPI_READ, abyData, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_SetAverageCount ()
		{
			byte[]		abyData = new byte[1];

			abyData[0] = (byte)NUDGet (nudSetAvrCnt);

			Tas1945_TcpUdpSend ((uint)REQ.SET_AVR_COUNT, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_GetSetupInfo ()
		{
			Tas1945_TcpUdpSend ((uint)REQ.GET_SETUP_INFO, null, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_ResendRequest ()
		{
			Tas1945_TcpUdpSend ((uint)REQ.RESEND_REQ, null, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_DeviceInitSetup ()
		{
			//	read set
			Tas1945_SetRead ();

			if (Resp_CheckWait (5000) == false)		return;
			
			//	clock set
			Tas1945_SetClock ();

			if (Resp_CheckWait (5000) == false)		return;

			//	average set
			Tas1945_SetAverageCount ();

			if (Resp_CheckWait (5000) == false)		return;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelSize"></param>
		/// <param name="asOffPixelData"></param>
		public void DspPixelValue (float[] asPixelData, int iPixelSize, float[] asOffPixelData, int iOffsetMode)
		{
			int x, y;
			float iPixelData;
			float iOffset;			

			try
			{
				if (g_fPixelChartForm != null)
				{
					//	Position 0
					x = g_fPixelChartForm.g_iChX[0];
					y = g_fPixelChartForm.g_iChY[0];

					iPixelData = Get_PixelData (asPixelData, x, y);
					TBSet (g_fPixelChartForm.tbP1Value, ((float)iPixelData).ToString ());

					if (iOffsetMode == 0)												//	Offset Mode : Pixel, Pixel Average
					{
						iOffset = Get_PixelData (asOffPixelData, x, y);
						TBSet (g_fPixelChartForm.tbP1Offset, ((float)iOffset).ToString ());

						iPixelData -= iOffset;

						TBSet (g_fPixelChartForm.tbP1CalValue, ((float)iPixelData).ToString ());
					}	
//					else if (iOffsetMode == 1)											//	Offset Mode : 미사용
//					{
//						iOffset = Tas1945_Get_PixelLineInfo (x);
//
//						TBSet (g_fPixelChartForm.tbP1Offset, iOffset.ToString ());
//
//						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iDark;
//						iPixelData = iPixelData - iOffset;
//						TBSet (g_fPixelChartForm.tbP1CalValue, iPixelData.ToString ());
//					}
					else																//	Dark Pixel X, Y
					{
						if (RBGet (rbDark_X_Offset) == true)
						{
							iOffset = Get_PixelData (asOffPixelData, x);
						}
						else
						{
							iOffset = Get_PixelData (asOffPixelData, y);
						}

						TBSet (g_fPixelChartForm.tbP1Offset, ((float)iOffset).ToString ());

						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iOffset;
						iPixelData = iPixelData - iOffset;
						TBSet (g_fPixelChartForm.tbP1CalValue, ((float)iPixelData).ToString ());
					}

					//	Position 1
					x = g_fPixelChartForm.g_iChX[1];
					y = g_fPixelChartForm.g_iChY[1];

					iPixelData = Get_PixelData (asPixelData, x, y);
					TBSet (g_fPixelChartForm.tbP2Value, ((float)iPixelData).ToString ());

					if (iOffsetMode == 0)
					{
						iOffset = Get_PixelData (asOffPixelData, x, y);
						TBSet (g_fPixelChartForm.tbP2Offset, ((float)iOffset).ToString ());

						iPixelData -= iOffset;

						TBSet (g_fPixelChartForm.tbP2CalValue, ((float)iPixelData).ToString ());
					}
//					else if (iOffsetMode == 1)
//					{
//						iOffset = Tas1945_Get_PixelLineInfo (x);
//
//						TBSet (g_fPixelChartForm.tbP2Offset, iOffset.ToString ());
//
//						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iDark;
//						iPixelData = iPixelData - iOffset;
//						TBSet (g_fPixelChartForm.tbP2CalValue, iPixelData.ToString ());
//					}
					else
					{
						if (RBGet (rbDark_X_Offset) == true)
						{
							iOffset = Get_PixelData (asOffPixelData, x);
						}
						else
						{
							iOffset = Get_PixelData (asOffPixelData, y);
						}
							
						TBSet (g_fPixelChartForm.tbP2Offset, ((float)iOffset).ToString ());

						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iOffset;
						iPixelData = iPixelData - iOffset;
						TBSet (g_fPixelChartForm.tbP2CalValue, ((float)iPixelData).ToString ());
					}
					
					//	Position 2
					x = g_fPixelChartForm.g_iChX[2];
					y = g_fPixelChartForm.g_iChY[2];

					
					iPixelData = Get_PixelData (asPixelData, x, y);
					TBSet (g_fPixelChartForm.tbP3Value, ((float)iPixelData).ToString ());

					if (iOffsetMode == 0)
					{
						iOffset = Get_PixelData (asOffPixelData, x, y);
						TBSet (g_fPixelChartForm.tbP3Offset, ((float)iOffset).ToString ());

						iPixelData -= iOffset;

						TBSet (g_fPixelChartForm.tbP3CalValue, ((float)iPixelData).ToString ());
					}
//					else if (iOffsetMode == 1)
//					{
//						iOffset = Tas1945_Get_PixelLineInfo (x);
//
//						TBSet (g_fPixelChartForm.tbP3Offset, iOffset.ToString ());
//
//						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iDark;
//						iPixelData = iPixelData - iOffset;
//						TBSet (g_fPixelChartForm.tbP3CalValue, iPixelData.ToString ());
//					}
					else
					{
						if (RBGet (rbDark_X_Offset) == true)
						{
							iOffset = Get_PixelData (asOffPixelData, x);
						}
						else
						{
							iOffset = Get_PixelData (asOffPixelData, y);
						}

						TBSet (g_fPixelChartForm.tbP3Offset, ((float)iOffset).ToString ());

						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iOffset;
						iPixelData = iPixelData - iOffset;
						TBSet (g_fPixelChartForm.tbP3CalValue, ((float)iPixelData).ToString ());
					}

					//	Position 3
					x = g_fPixelChartForm.g_iChX[3];
					y = g_fPixelChartForm.g_iChY[3];

					iPixelData = Get_PixelData (asPixelData, x, y);
					TBSet (g_fPixelChartForm.tbP4Value, ((float)iPixelData).ToString ());
					
					if (iOffsetMode == 0)
					{
						iOffset = Get_PixelData (asOffPixelData, x, y);
						TBSet (g_fPixelChartForm.tbP4Offset, ((float)iOffset).ToString ());

						iPixelData -= iOffset;

						TBSet (g_fPixelChartForm.tbP4CalValue, ((float)iPixelData).ToString ());
					}
//					else if (iOffsetMode == 1)
//					{
//						iOffset = Tas1945_Get_PixelLineInfo (x);
//
//						TBSet (g_fPixelChartForm.tbP4Offset, iOffset.ToString ());
//
//						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iDark;
//						iPixelData = iPixelData - iOffset;
//						TBSet (g_fPixelChartForm.tbP4CalValue, iPixelData.ToString ());
//					}
					else
					{
						if (RBGet (rbDark_X_Offset) == true)
						{
							iOffset = Get_PixelData (asOffPixelData, x);
						}
						else
						{
							iOffset = Get_PixelData (asOffPixelData, y);
						}
							
						TBSet (g_fPixelChartForm.tbP4Offset, ((float)iOffset).ToString ());

						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iOffset;
						iPixelData = iPixelData - iOffset;
						TBSet (g_fPixelChartForm.tbP4CalValue, ((float)iPixelData).ToString ());
					}

					//	Position 4
					x = g_fPixelChartForm.g_iChX[4];
					y = g_fPixelChartForm.g_iChY[4];

					iPixelData = Get_PixelData (asPixelData, x, y);
					TBSet (g_fPixelChartForm.tbP5Value, ((float)iPixelData).ToString ());

					if (iOffsetMode == 0)
					{
						iOffset = Get_PixelData (asOffPixelData, x, y);
						TBSet (g_fPixelChartForm.tbP5Offset, ((float)iOffset).ToString ());

						iPixelData -= iOffset;

						TBSet (g_fPixelChartForm.tbP5CalValue, ((float)iPixelData).ToString ());
					}
//					else if (iOffsetMode == 1)
//					{
//						iOffset = Tas1945_Get_PixelLineInfo (x);
//
//						TBSet (g_fPixelChartForm.tbP5Offset, iOffset.ToString ());
//
//						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iDark;
//						iPixelData = iPixelData - iOffset;
//						TBSet (g_fPixelChartForm.tbP5CalValue, iPixelData.ToString ());
//					}
					else
					{	
						if (RBGet (rbDark_X_Offset) == true)
						{
							iOffset = Get_PixelData (asOffPixelData, x);
						}
						else
						{
							iOffset = Get_PixelData (asOffPixelData, y);
						}
							
						TBSet (g_fPixelChartForm.tbP5Offset, ((float)iOffset).ToString ());

						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iOffset;
						iPixelData = iPixelData - iOffset;
						TBSet (g_fPixelChartForm.tbP5CalValue, ((float)iPixelData).ToString ());
					}

					//	Position TP
					x = 80;
					y = 2;

					iPixelData = Get_PixelData (asPixelData, x, y);
					TBSet (g_fPixelChartForm.tbTPValue, ((float)iPixelData).ToString ());

					if (iOffsetMode == 0)
					{
						iOffset = Get_PixelData (asOffPixelData, x, y);
						TBSet (g_fPixelChartForm.tbTPOffset, ((float)iOffset).ToString ());

						iPixelData -= iOffset;

						TBSet (g_fPixelChartForm.tbTPCalValue, ((float)iPixelData).ToString ());
					}
//					else if (iOffsetMode == 1)
//					{
//						iOffset = Tas1945_Get_PixelLineInfo (x);
//
//						TBSet (g_fPixelChartForm.tbTPOffset, iOffset.ToString ());
//
//						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iDark;
//						iPixelData = iPixelData - iOffset;
//						TBSet (g_fPixelChartForm.tbTPCalValue, iPixelData.ToString ());
//					}
					else
					{						
						if (RBGet (rbDark_X_Offset) == true)
						{
							iOffset = Get_PixelData (asOffPixelData, x);
						}
						else
						{
							iOffset = Get_PixelData (asOffPixelData, y);
						}

						TBSet (g_fPixelChartForm.tbTPOffset, ((float)iOffset).ToString ());

						//iPixelData = iPixelData + (int)Math.Pow (2, 15) - iOffset;
						iPixelData = iPixelData - iOffset;
						TBSet (g_fPixelChartForm.tbTPCalValue, ((float)iPixelData).ToString ());
					}
				}
			}
			//catch (Exception ex)
			catch (Exception)
			{
				;	//ERR (ex.Message);
			}		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="iPixelSize"></param>
		public bool Check_PixelSize (int iPixelSize)
		{	
			if (iPixelSize != 9720)
			{
				ERR ("Pixel Size Error !!!");
				return false;
			}

			return true;
		}

		/// <summary>
		/// GUI 에서 Average 를 적용.
		/// GUI mode	: 8 Frame 단위로 을 Read 해서 Average 적용
		/// Move8 mode	: 8 Frame 이 후 부터 누적으로 1 Frame 씩 추가하면서 Average 적용
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		/// <returns></returns>
		public bool Average_Apply (ref float[] asPixelData, int iPixelDataSize)
		{
			try
			{
				//int iAvrCnt = (int)NUDGet (nudAvrCnt);
				int iAvrCnt = 8;

				if (RBGet (rbGuiAvr) == true)									//	GUI Average mode
				{
					if (g_iAvrCount == (iAvrCnt - 1))							//	이번에 전송받은 Data 까지 포함해서 Average 적용한다.
					{
						for (int i = 0; i < g_aiAvrData.Length; i++)			//	Average (GUI)
						{
							g_aiAvrData[i] += Get_PixelData (asPixelData, i);

							g_aiAvrData[i] /= iAvrCnt;
						
							Set_PixelData (ref asPixelData, i, (float)g_aiAvrData[i]);
						}

						//if (TGSGet (tgsDebugLog) == true && g_iAvrCount == (iAvrCnt - 1))
						//{
						//	LOG ("AVR : " + HexArrToAscStr (abyPixelData, 0, iPixelDataSize, true));
						//}

						g_iAvrCount = 0;
					}
					else
					{
						if (g_iAvrCount == 0)
						{	
							Array.Clear (g_aiAvrData, 0, g_aiAvrData.Length);
						}

						for (int i = 0; i < g_aiAvrData.Length; i++)
						{
							g_aiAvrData[i] += Get_PixelData (asPixelData, i);
						}

						g_iAvrCount++;

						return false;
					}
				}
				else if (RBGet (rbMoveAvr) == true)								//	Move Average mode
				{
					for (int i = 0; i < asPixelData.Length; i++)
					{
						g_aiMoveAvrData[g_iMoveAvrCnt, i] = Get_PixelData (asPixelData, i);
					}

					//LOG ("AVR CNT : " + g_iMoveAvrCnt.ToString ());

					g_iMoveAvrCnt++;
					g_iMoveAvrCnt %= iAvrCnt;

					if (g_iBuffer_no < iAvrCnt) g_iBuffer_no++;
					else if (g_iBuffer_no == iAvrCnt) g_bMoveAvrDsp = true;    // 20231108 박사님 말씀대로 Move Average mode 수정 = 최초 7개 이미지는 안띄우고 8번째 이미지부터는 계속 출력
					//if (g_iMoveAvrCnt == 0)		g_bMoveAvrDsp = true;

					if (g_bMoveAvrDsp == false)		return false;				//	Average count 만큼 data 가 모일때 까지 display 안함.
									
					//	평균
					Array.Clear (g_aiAvrData, 0, g_aiAvrData.Length);

					for (int i = 0; i < g_aiAvrData.Length; i++) 
					{
						float[] ret = new float[iAvrCnt];

						for( int j = 0; j < iAvrCnt; j++)
                        {
							ret[j] = g_aiMoveAvrData[j, i];
							g_aiAvrData[i] += g_aiMoveAvrData[j, i];
						}

						Array.Sort(ret);

						// BookMark #3 : 'Move8' RadioButton에 의해 평균이 계산되는 부분
						g_aiAvrData[i] = g_aiAvrData[i] - ret[0] - ret[ret.Length-1];
						g_aiAvrData[i] /= (iAvrCnt - 2);

						Set_PixelData(ref asPixelData, i, (float)g_aiAvrData[i]);
					}
									
					/*for (int i = 0; i < g_aiAvrData.Length; i++)
					{
						g_aiAvrData[i]-=(g_aiMaxData[i]+g_aiMinData[i]);
						//g_aiAvrData[i] /= (int)(iAvrCnt-2);

						Set_PixelData (ref asPixelData, i, (float)g_aiAvrData[i]);
					}*/
				}

				return true;
			}
			catch (Exception)
			{
				;
			}

			return false;
		}
		
		/// <summary>
		/// Pixel Offset	: 설정된 카운터에 입력된 Pixel 정보를 가지고 Offset 을 계산 해서 적용한다.
		/// Average Offset	: 설정된 카운터 만큰 모든 Pixel 정보를 누적하여 평균을 낸값을 Offset 에 적용한다.
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		/// <returns></returns>
		public bool Offset_Apply (ref float[] asPixelData, int iPixelDataSize)
		{
			if (TGSGet (tgsRefVal) == true)										//	설정된 기준값으로 각 Pixel 별 Offset 적용
			{
				if (g_bOffPixelApply == false)
				{
					g_iOffPixelCnt++;

					LOG ("Pixle Measure : " + g_iOffPixelCnt.ToString (), Color.Blue);

					if (g_iOffPixelCnt >= (int)NUDGet (nudPixelMeasure))									//	설정된 Count 에 측정 후 Pixel 정보를 Offset 에 적용한다.
					{
						// Offset 설정
						g_bOffPixelApply = true;

						//Tas1945_CalPixelOffset (asPixelData, asPixelData.Length, ref g_asOffPixelData);	//	앞에 측정된 값은 무시하고 측정 카우트에 전송되는 데이터를 기준으로 Offset 을 계산
		
						LOG ("Set Offset", Color.Blue);
					}

					//	Offset Count Offset 설정 - 맨 처음 데이터는 버리고 측정 카운트 - 1 한 데이터를 Average 내서 적용
					if (g_iOffPixelCnt > 1)
					{
						Tas1945_CalAvrPixelOffset (asPixelData, asPixelData.Length, g_iOffPixelCnt - 1, ref g_asOffPixelData, g_bOffPixelApply);
					}

					return false;
				}
				else
				{
					//	Offset Display
					DspPixelValue (asPixelData, asPixelData.Length, g_asOffPixelData, 0);

					//	각 Pixel 에 Offset 적용
					Tas1945_Set_PixelOffset (ref asPixelData, asPixelData.Length, g_asOffPixelData);
				}
			}

			if (RBGet (rbDark_X_Offset) == true || RBGet (rbDark_Y_Offset) == true)			//	Dark Pixel 기준으로 Offset 설정
			{
				//	Dark Pixel Offset 설정
				if (RBGet (rbDark_X_Offset) == true)
				{
					Tas1945_Set_DarkPixelInfo (asPixelData, ref g_aiDarkX_PixelOffset, true);

					//	Offset Display
					DspPixelValue (asPixelData, asPixelData.Length, g_aiDarkX_PixelOffset, 2);

					Tas1945_Set_DarkPixelOffset (ref asPixelData, asPixelData.Length, g_aiDarkX_PixelOffset, true);			//	Y 축 기준 (X : 0 ~ 81) Dark pixel offset
				}
				else
				{
					Tas1945_Set_DarkPixelInfo (asPixelData, ref g_aiDarkY_PixelOffset, false);

					//	Offset Display
					DspPixelValue (asPixelData, asPixelData.Length, g_aiDarkY_PixelOffset, 2);

					Tas1945_Set_DarkPixelOffset (ref asPixelData, asPixelData.Length, g_aiDarkY_PixelOffset, false);		//	X 축 기준 (Y : 0 ~ 59) Dark pixel offset
				}
			}
			else if (RBGet (rbAvrOffset) == true)										//	설정된 Count 만큼 각 Pixel 별로 누적하여 Average 로 Offset 설정
			{
				if (g_bOffAvrApply == false)
				{
					g_iOffAvfrCnt++;

					LOG ("Pixle Measure : " + g_iOffAvfrCnt.ToString (), Color.Blue);

					if (g_iOffAvfrCnt >= (int)NUDGet (nudPixelMeasure))					//	설정된 Count 만큼 전체 Pixel 을 누적하여 측정하여 Average 를 낸 이후부터 Offset 을 적용한다.
					{
						g_bOffAvrApply = true;

						LOG ("Set Offset", Color.Blue);
					}

					//	Average Offset 설정
					if (g_iOffAvfrCnt > 1)
					{
						Tas1945_CalAvrPixelOffset (asPixelData, asPixelData.Length, g_iOffAvfrCnt - 1, ref g_asOffAvrData, g_bOffAvrApply);
					}

					return false;
				}
				else
				{
					//	Offset Display
					DspPixelValue (asPixelData, asPixelData.Length, g_asOffAvrData, 0);

					//	각 Pixel 에 Offset 적용
					Tas1945_Set_PixelOffset (ref asPixelData, asPixelData.Length, g_asOffAvrData);
				}
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		/// <returns></returns>
		public bool Kalman_Filter_Apply (ref float[] asPixelData, int iPixelDataSize)
		{
			double dbValue;

			try
			{
				for (int i = 0; i < iPixelDataSize; i++)
				{
					dbValue = Get_PixelData (asPixelData, i);

					dbValue = Kalman_Filter (dbValue, i);

					Set_PixelData (ref asPixelData, i, (float)dbValue);
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="asPixelData"></param>
		/// <param name="iPixelDataSize"></param>
		/// <returns></returns>
		public bool LPF_IIR_Filter_Apply (ref float[] asPixelData, int iPixelDataSize, double dbSensitive)
		{
			double dbValue;

			try 
			{
				LPF_IIR_SetFirstData (asPixelData, iPixelDataSize);

				for (int i = 0; i < iPixelDataSize; i++)
				{
					dbValue = Get_PixelData (asPixelData, i);

					dbValue = LPF_IIR_Filter (dbValue, i, dbSensitive);

					Set_PixelData (ref asPixelData, i, (float)dbValue);
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterInit ()
		{
			int		iIndex;

			iIndex = 0;

			if(cbReg24yearSetting.Checked == false)
            {
				// BookMark #5 : Register Setting - 22' SPI Instruction
				#region   2022.02.24
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 0 - rro_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 1 - rro_start [8:15]
				g_abyTas1945Register[iIndex++] = 0xA6;      //  Register: 2 - rro_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 3 - rro_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 4 - pna_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 5 - pna_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x02;      //  Register: 6 - pna_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 7 - pna_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 8 - g2_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 9 - g2_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x1A;      //  Register: 10 - g2_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 11 - g2_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 12 - g3_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 13 - g3_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x0E;      //  Register: 14 - g3_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 15 - g3_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 16 - g4_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 17 - g4_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x0E;      //  Register: 18 - g4_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 19 - g4_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x1A;      //  Register: 20 - gccrst_b_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 21 - gccrst_b_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 22 - gccrst_b_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 23 - gccrst_b_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x03;      //  Register: 24 - xfr_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 25 - xfr_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x05;      //  Register: 26 - xfr_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 27 - xfr_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x0C;      //  Register: 28 - store_b_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 29 - store_b_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x06;      //  Register: 30 - store_b_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 31 - store_b_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 32 - adcramprst_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 33 - adcramprst_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x1C;      //  Register: 34 - adcramprst_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 35 - adcramprst_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 36 - buff_en_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 37 - buff_en_start [8:15]
				g_abyTas1945Register[iIndex++] = 0xEE;      //  Register: 38 - buff_en_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x0F;      //  Register: 39 - buff_en_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x07;      //  Register: 40 - clr_stk_in_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 41 - clr_stk_in_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x09;      //	Register: 42 - clr_stk_in_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 43 - clr_stk_in_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 44-47 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 45
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 46
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 47

				g_abyTas1945Register[iIndex++] = 0x50;      //  Register: 48 - intsmpl_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 49 - intsmpl_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x6A;      //  Register: 50 - intsmpl_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x03;      //  Register: 51 - intsmpl_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x54;      //  Register: 52 - intpsh_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 53 - intpsh_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x66;      //  Register: 54 - intpsh_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x03;      //  Register: 55 - intpsh_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 56 - ps2_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 57 - ps2_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x1C;      //  Register: 58 - ps2_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x03;      //  Register: 59 - ps2_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x2E;      //  Register: 60 - ps3_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x06;      //  Register: 61 - ps3_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x31;      //  Register: 62 - ps3_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x06;      //  Register: 63 - ps3_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x65;      //  Register: 64 - chopn_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 65 - chopn_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x30;      //  Register: 66 - chopn_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 67 - chopn_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x32;      //  Register: 68 - chopp_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 69 - chopp_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x65;      //  Register: 70 - chopp_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 71 - chopp_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x5F;      //  Register: 72 - demodn_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 73 - demodn_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x3D;      //  Register: 74 - demodn_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 75 - demodn_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x2C;      //  Register: 76 - demodp_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 77 - demodp_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x09;      //  Register: 78 - demodp_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 79 - demodp_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 80 - p4_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 81 - p4_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x31;      //  Register: 82 - p4_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 83 - p4_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x32;      //  Register: 84 - p5_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 85 - p5_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 86 - p5_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 87 - p5_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 88 - p6_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 89 - p6_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 90 - p6_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 91 - p6_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x62;      //  Register: 92 - p7_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 93 - p7_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x64;      //  Register: 94 - p7_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 95 - p7_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 96-111 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 97
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 98
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 99
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 100
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 101
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 102
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 103
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 104
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 105
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 106
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 107
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 108
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 109
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 110
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 111

				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 112 - idac_chop [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 113 - idac_demod [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 114 - idac_intsmpl [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 115 - idac_intpsh [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 116 - idac_srsta [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 117 - idac_srstb [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 118 - idac_sig_sigb [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 119 - idac_intrst [0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 120 - spare
				g_abyTas1945Register[iIndex++] = 0x25;      //  Register: 121 - idac_adcramp [0:5]
				g_abyTas1945Register[iIndex++] = 0x09;      //  Register: 122 - idac_vb2 [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 123 - idac_atcore [0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 124-126 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 125
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 126
				g_abyTas1945Register[iIndex++] = 0x00;      //0x00	Register: 127 - Mixed - sel_sig_test, sel_rst_test

				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 128 - Mixed - rro_man, rro_en, pna_man, pna_en, g2_man, g2_en, g3_man, g3_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 129 - Mixed - rro_sinv, rro_rrst, pna_sinv, pna_rrst, g2_sinv, g2_rrst, g3_sinv, g3_rrst
				g_abyTas1945Register[iIndex++] = 0xA8;      //  Register: 130 - Mixed - g4_man, g4_en, gccrst_b_man, gccrst_b_en, xfr_man, xfr_en, store_b_man, store_b_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 131 - Mixed - g4_sinv, g4_rrst, gccrst_b_sinv, gccrst_b_rrst, xfr_sinv, xfr_rrst, store_b_sinv, store_b_rrst
				g_abyTas1945Register[iIndex++] = 0x2A;      //  Register: 132 - Mixed - adcramprst_man, adcramprst_en, buff_en_man, buff_en_en, clr_stk_in_man, clr_stk_in_en, g11_man, g11_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 133 - Mixed - adcramprst_sinv, adcramprst_rrst, buff_en_sinv, buff_en_rrst, clr_stk_in_sinv, clr_stk_in_rrst, g11_sinv, g11_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 134 - Mixed - intsmpl_man, intsmpl_en, intpsh_man, intpsh_en, ps2_man, ps2_en, ps3_man, ps3_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 135 - Mixed - intsmpl_sinv, intsmpl_rrst, intpsh_sinv, intpsh_rrst, ps2_sinv, ps2_rrst, ps3_sinv, ps3_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 136 - Mixed - chopn_man, chopn_en, chopp_man, chopp_en, demodn_man, demodn_en, demodp_man, demodp_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 137 - Mixed - chopn_sinv, chopn_rrst, chopp_sinv, chopp_rrst, demodn_sinv, demodn_rrst, demodp_sinv, demodp_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 138 - Mixed - p4_man, p4_en, p5_man, p5_en, p6_man, p6_en, p7_man, p7_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 139 - Mixed - p4_sinv, p4_rrst, p5_sinv, p5_rrst, p6_sinv, p6_rrst, p7_sinv, p7_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 140 - Mixed - p8_man, p8_en, p9_man, p9_en, p10_man, p10_en, p11_man, p11_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 141 - Mixed - p8_sinv, p8_rrst, p9_sinv, p9_rrst, p10_sinv, p10_rrst, p11_sinv, p11_rrst

				//	142, 143 Not designed  - BFE guide (20220217)
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 142 - Mixed - p12_man, p12_en, p13_man, p13_en, p14_man, p14_en, p15_man, p15_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 143 - Mixed - p12_sinv, p12_rrst, p13_sinv, p13_rrst, p14_sinv, p14_rrst, p15_sinv, p15_rrst

				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 144 - Mixed - lvdsctrl[0], lvdsctrl[1], lvdsctrl[2], lvdsctrl[3], lvdsctrl[4], lvdsctrl[5], lvdsctrl[6], lvdsctrl[7]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 145-153 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 146
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 147
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 148
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 149
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 150
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 151
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 152
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 153
				g_abyTas1945Register[iIndex++] = 0x2F;      //  Register: 154 - clk_divider_2M [0:7]
				//g_abyTas1945Register[iIndex++] = 0x2E;      //  Register: 154 - clk_divider_2M [0:7]   화면노이즈 조정값
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 155 - clk_divider_2M [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 156 - dto1_sel[0],
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 157 - dto0_sel[0],
				g_abyTas1945Register[iIndex++] = 0xC0;      //  Register: 158 - Mixed - intrst, srsta, srstb, ssig, foe, pd, rowen
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 159 - spare

				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 160-175 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 161
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 162
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 163
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 164
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 165
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 166
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 167
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 168
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 169
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 170
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 171
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 172
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 173
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 174
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 175

				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 176 - row address for pixel
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 177 -
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 178 - Mixed - rcnt_ra_sel, rcnt_cnt_down, rcnt_cnt_up, rcnt_en, rcnt_ensy [0:1], rcnt_clk_pol, rcnt_lsync_sel
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 179 - rcnt_regrst [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 180 - rcnt_regrst [8:15]
				g_abyTas1945Register[iIndex++] = 0x48;      //  Register: 181 - man[3:0],ds_sox[2:0], lsync_bit
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 182 - Mixed - lsync_rcnt_sel [0:0], lsync_pat_sel [0:0], rcnt_xsync_en, rcnt_rs_lsb_sel, rcnt_clr_sel
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 183-189 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 184
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 185
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 186
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 187
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 188
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 189
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 190 - ato_sel[0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 191 - Mixed - ato_sf_bias, ato_vout_pd, ato_hs_sel, ato_hs_mux [0:2]

				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 192-207 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 193
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 194
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 195
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 196
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 197
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 198
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 199
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 200
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 201
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 202
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 203
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 204
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 205
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 206
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 207

				//	208 ~ 223 Write Only - BFE guide (20220217)
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 208 - pat_dload [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 209 - pat_dload [8:15]
				g_abyTas1945Register[iIndex++] = 0x53;      //  Register: 210 - Mixed - pat_cn_en, pat_cnt_up, pat_cnt_down, pat_clk_pol, pat_ensy[0], pat_ensy[1], pat_ensyp[0], pat_ensyp[1]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 211 - Mixed - pat_ensyps[0],
				g_abyTas1945Register[iIndex++] = 0x81;      //  Register: 212 - Mixed - pat_cntsel_bit, pat_ensyps[1] pat_prst_sel, pat_disable_sclr, pat_en_sync, pat_ppload_sel [0:1], pat_pload_sel [0:1]
				//g_abyTas1945Register[iIndex++] = 0x18;      //  Register: 213 - d_intcm [0:5]
				g_abyTas1945Register[iIndex++] = 0x14;      //  Register: 213 - d_intcm [0:5]    20240114박사님신규값
				g_abyTas1945Register[iIndex++] = 0x1D;      //  Register: 214 - d_intcmbuf [0:5]
				//g_abyTas1945Register[iIndex++] = 0x17;      //  Register: 215 - d_pixamp_vocm [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 215 - d_pixamp_vocm [0:5]    20240114박사님신규값
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 216 - d_intamp_col [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 217 - d_pixamp_col [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 218 - d_pixamp_fb_col [0:5]
				g_abyTas1945Register[iIndex++] = 0x07;      //  Register: 219 - d_vb_pixout [0:5]
				g_abyTas1945Register[iIndex++] = 0x1D;      //  Register: 220 - d_vocm [0:5]
				g_abyTas1945Register[iIndex++] = 0x1B;      //  Register: 221 - d_chop_ref [0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 222-223 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 223

				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 224-239 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 225
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 226
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 227
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 228
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 229
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 230
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 231
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 232
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 233
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 234
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 235
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 236
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 237
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 238
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 239

				g_abyTas1945Register[iIndex++] = 0x80;      //  Register: 240 - Mixed - lsb0_sel [0:1], lsb1_sel [0:1], clkdivout_sel [0:0]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 241-254 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 242
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 243
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 244
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 245
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 246
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 247
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 248
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 249
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 250
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 251
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 252
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 253
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 254
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 255 - Bank_sel[0], reg_rst,
				#endregion
            }
			else
            {
				// BookMark #6 : Register Setting - 24' SPI Instruction
				#region   2024.02.02
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 0 - rro_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 1 - rro_start [8:15]
				g_abyTas1945Register[iIndex++] = 0xA6;      //  Register: 2 - rro_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 3 - rro_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 4 - pna_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 5 - pna_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x02;      //  Register: 6 - pna_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 7 - pna_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 8 - g2_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 9 - g2_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x1A;      //  Register: 10 - g2_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 11 - g2_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 12 - g3_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 13 - g3_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x0E;      //  Register: 14 - g3_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 15 - g3_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 16 - g4_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 17 - g4_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x0E;      //  Register: 18 - g4_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 19 - g4_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x1A;      //  Register: 20 - gccrst_b_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 21 - gccrst_b_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 22 - gccrst_b_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 23 - gccrst_b_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x03;      //  Register: 24 - xfr_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 25 - xfr_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x05;      //  Register: 26 - xfr_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 27 - xfr_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x0C;      //  Register: 28 - store_b_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 29 - store_b_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x06;      //  Register: 30 - store_b_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 31 - store_b_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 32 - adcramprst_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 33 - adcramprst_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x1C;      //  Register: 34 - adcramprst_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 35 - adcramprst_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 36 - buff_en_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 37 - buff_en_start [8:15]
				g_abyTas1945Register[iIndex++] = 0xEE;      //  Register: 38 - buff_en_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x0F;      //  Register: 39 - buff_en_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x07;      //  Register: 40 - clr_stk_in_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 41 - clr_stk_in_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x09;      //	Register: 42 - clr_stk_in_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 43 - clr_stk_in_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 44-47 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 45
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 46
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 47

				g_abyTas1945Register[iIndex++] = 0x70;      //  Register: 48 - intsmpl_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 49 - intsmpl_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x77;      //  Register: 50 - intsmpl_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x02;      //  Register: 51 - intsmpl_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x74;      //  Register: 52 - intpsh_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 53 - intpsh_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x73;      //  Register: 54 - intpsh_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x02;      //  Register: 55 - intpsh_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 56 - ps2_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 57 - ps2_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x1C;      //  Register: 58 - ps2_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x03;      //  Register: 59 - ps2_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 60 - ps3_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x04;      //  Register: 61 - ps3_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x02;      //  Register: 62 - ps3_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x04;      //  Register: 63 - ps3_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x65;      //  Register: 64 - chopn_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 65 - chopn_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x2F;      //  Register: 66 - chopn_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 67 - chopn_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x30;      //  Register: 68 - chopp_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 69 - chopp_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x64;      //  Register: 70 - chopp_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 71 - chopp_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x5F;      //  Register: 72 - demodn_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 73 - demodn_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x3D;      //  Register: 74 - demodn_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 75 - demodn_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x2C;      //  Register: 76 - demodp_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 77 - demodp_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x09;      //  Register: 78 - demodp_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 79 - demodp_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 80 - p4_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 81 - p4_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x31;      //  Register: 82 - p4_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 83 - p4_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x32;      //  Register: 84 - p5_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 85 - p5_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 86 - p5_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 87 - p5_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 88 - p6_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 89 - p6_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 90 - p6_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 91 - p6_stop [8:15]
				g_abyTas1945Register[iIndex++] = 0x62;      //  Register: 92 - p7_start [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 93 - p7_start [8:15]
				g_abyTas1945Register[iIndex++] = 0x63;      //  Register: 94 - p7_stop [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 95 - p7_stop [8:15]

				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 96-111 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 97
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 98
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 99
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 100
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 101
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 102
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 103
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 104
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 105
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 106
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 107
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 108
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 109
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 110
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 111

				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 112 - idac_chop [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 113 - idac_demod [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 114 - idac_intsmpl [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 115 - idac_intpsh [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 116 - idac_srsta [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 117 - idac_srstb [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 118 - idac_sig_sigb [0:5]
				g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 119 - idac_intrst [0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 120 - spare
				g_abyTas1945Register[iIndex++] = 0x25;      //  Register: 121 - idac_adcramp [0:5]
				g_abyTas1945Register[iIndex++] = 0x09;      //  Register: 122 - idac_vb2 [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 123 - idac_atcore [0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 124-126 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 125
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 126
				g_abyTas1945Register[iIndex++] = 0x00;      //0x00	Register: 127 - Mixed - sel_sig_test, sel_rst_test

				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 128 - Mixed - rro_man, rro_en, pna_man, pna_en, g2_man, g2_en, g3_man, g3_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 129 - Mixed - rro_sinv, rro_rrst, pna_sinv, pna_rrst, g2_sinv, g2_rrst, g3_sinv, g3_rrst
				g_abyTas1945Register[iIndex++] = 0xA8;      //  Register: 130 - Mixed - g4_man, g4_en, gccrst_b_man, gccrst_b_en, xfr_man, xfr_en, store_b_man, store_b_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 131 - Mixed - g4_sinv, g4_rrst, gccrst_b_sinv, gccrst_b_rrst, xfr_sinv, xfr_rrst, store_b_sinv, store_b_rrst
				g_abyTas1945Register[iIndex++] = 0x2A;      //  Register: 132 - Mixed - adcramprst_man, adcramprst_en, buff_en_man, buff_en_en, clr_stk_in_man, clr_stk_in_en, g11_man, g11_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 133 - Mixed - adcramprst_sinv, adcramprst_rrst, buff_en_sinv, buff_en_rrst, clr_stk_in_sinv, clr_stk_in_rrst, g11_sinv, g11_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 134 - Mixed - intsmpl_man, intsmpl_en, intpsh_man, intpsh_en, ps2_man, ps2_en, ps3_man, ps3_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 135 - Mixed - intsmpl_sinv, intsmpl_rrst, intpsh_sinv, intpsh_rrst, ps2_sinv, ps2_rrst, ps3_sinv, ps3_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 136 - Mixed - chopn_man, chopn_en, chopp_man, chopp_en, demodn_man, demodn_en, demodp_man, demodp_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 137 - Mixed - chopn_sinv, chopn_rrst, chopp_sinv, chopp_rrst, demodn_sinv, demodn_rrst, demodp_sinv, demodp_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 138 - Mixed - p4_man, p4_en, p5_man, p5_en, p6_man, p6_en, p7_man, p7_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 139 - Mixed - p4_sinv, p4_rrst, p5_sinv, p5_rrst, p6_sinv, p6_rrst, p7_sinv, p7_rrst
				g_abyTas1945Register[iIndex++] = 0xAA;      //  Register: 140 - Mixed - p8_man, p8_en, p9_man, p9_en, p10_man, p10_en, p11_man, p11_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 141 - Mixed - p8_sinv, p8_rrst, p9_sinv, p9_rrst, p10_sinv, p10_rrst, p11_sinv, p11_rrst

				//	142, 143 Not designed  - BFE guide (20220217)
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 142 - Mixed - p12_man, p12_en, p13_man, p13_en, p14_man, p14_en, p15_man, p15_en
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 143 - Mixed - p12_sinv, p12_rrst, p13_sinv, p13_rrst, p14_sinv, p14_rrst, p15_sinv, p15_rrst

				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 144 - Mixed - lvdsctrl[0], lvdsctrl[1], lvdsctrl[2], lvdsctrl[3], lvdsctrl[4], lvdsctrl[5], lvdsctrl[6], lvdsctrl[7]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 145-153 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 146
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 147
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 148
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 149
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 150
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 151
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 152
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 153
				g_abyTas1945Register[iIndex++] = 0x2F;      //  Register: 154 - clk_divider_2M [0:7]
				//g_abyTas1945Register[iIndex++] = 0x2E;      //  Register: 154 - clk_divider_2M [0:7]   화면노이즈 조정값
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 155 - clk_divider_2M [8:15]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 156 - dto1_sel[0],
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 157 - dto0_sel[0],
				g_abyTas1945Register[iIndex++] = 0xC0;      //  Register: 158 - Mixed - intrst, srsta, srstb, ssig, foe, pd, rowen
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 159 - spare

				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 160-175 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 161
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 162
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 163
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 164
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 165
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 166
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 167
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 168
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 169
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 170
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 171
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 172
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 173
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 174
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 175

				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 176 - row address for pixel
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 177 -
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 178 - Mixed - rcnt_ra_sel, rcnt_cnt_down, rcnt_cnt_up, rcnt_en, rcnt_ensy [0:1], rcnt_clk_pol, rcnt_lsync_sel
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 179 - rcnt_regrst [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 180 - rcnt_regrst [8:15]
				g_abyTas1945Register[iIndex++] = 0x48;      //  Register: 181 - man[3:0],ds_sox[2:0], lsync_bit
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 182 - Mixed - lsync_rcnt_sel [0:0], lsync_pat_sel [0:0], rcnt_xsync_en, rcnt_rs_lsb_sel, rcnt_clr_sel
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 183-189 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 184
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 185
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 186
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 187
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 188
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 189
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 190 - ato_sel[0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 191 - Mixed - ato_sf_bias, ato_vout_pd, ato_hs_sel, ato_hs_mux [0:2]

				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 192-207 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 193
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 194
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 195
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 196
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 197
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 198
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 199
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 200
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 201
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 202
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 203
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 204
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 205
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 206
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 207

				//	208 ~ 223 Write Only - BFE guide (20220217)
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 208 - pat_dload [0:7]
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 209 - pat_dload [8:15]
				g_abyTas1945Register[iIndex++] = 0x53;      //  Register: 210 - Mixed - pat_cn_en, pat_cnt_up, pat_cnt_down, pat_clk_pol, pat_ensy[0], pat_ensy[1], pat_ensyp[0], pat_ensyp[1]
				g_abyTas1945Register[iIndex++] = 0x01;      //  Register: 211 - Mixed - pat_ensyps[0],
				g_abyTas1945Register[iIndex++] = 0x00;      //  Register: 212 - Mixed - pat_cntsel_bit, pat_ensyps[1] pat_prst_sel, pat_disable_sclr, pat_en_sync, pat_ppload_sel [0:1], pat_pload_sel [0:1]
				//g_abyTas1945Register[iIndex++] = 0x1E;      //  Register: 213 - d_intcm [0:5]
				g_abyTas1945Register[iIndex++] = 0x14;      //  Register: 213 - d_intcm [0:5]    20240114박사님신규값
				g_abyTas1945Register[iIndex++] = 0x1D;      //  Register: 214 - d_intcmbuf [0:5]
				//g_abyTas1945Register[iIndex++] = 0x17;      //  Register: 215 - d_pixamp_vocm [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 215 - d_pixamp_vocm [0:5]    20240114박사님신규값
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 216 - d_intamp_col [0:5]
				g_abyTas1945Register[iIndex++] = 0x20;      //  Register: 217 - d_pixamp_col [0:5]
				g_abyTas1945Register[iIndex++] = 0x1F;      //  Register: 218 - d_pixamp_fb_col [0:5]
				g_abyTas1945Register[iIndex++] = 0x07;      //  Register: 219 - d_vb_pixout [0:5]
				g_abyTas1945Register[iIndex++] = 0x17;      //  Register: 220 - d_vocm [0:5]
				g_abyTas1945Register[iIndex++] = 0x2E;      //  Register: 221 - d_chop_ref [0:5]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 222-223 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 223

				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 224-239 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 225
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 226
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 227
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 228
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 229
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 230
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 231
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 232
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 233
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 234
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 235
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 236
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 237
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 238
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 239

				g_abyTas1945Register[iIndex++] = 0x80;      //  Register: 240 - Mixed - lsb0_sel [0:1], lsb1_sel [0:1], clkdivout_sel [0:0]
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 241-254 - spare
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 242
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 243
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 244
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 245
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 246
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 247
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 248
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 249
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 250
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 251
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 252
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 253
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 254
				g_abyTas1945Register[iIndex++] = 0x00;      //	Register: 255 - Bank_sel[0], reg_rst,
				#endregion
            }

		}

		/// <summary>
		/// 
		/// </summary>
		public void TcpUdp_Close ()
		{
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
		private void StartDataProcessingTimer()
		{
			stopwatch_Data.Restart(); // Stopwatch 초기화 및 시작
		}
		private void StartChartTimer()
		{
			stopwatch_Chart.Restart(); // Stopwatch 초기화 및 시작
		}
		private void StartBitmapTimer()
		{
			stopwatch_Bitmap.Restart(); // Stopwatch 초기화 및 시작
		}
		private void StopDataProcessingTimer()
		{
			stopwatch_Data.Stop(); // Stopwatch 정지
			LOG($"Data Processing Time: {stopwatch_Data.ElapsedMilliseconds} ms", Color.Red);
			//Console.WriteLine($"Data Processing Time: {stopwatch.ElapsedMilliseconds} ms");
		}
		private void StopChartTimer()
		{
			stopwatch_Chart.Stop(); // Stopwatch 정지
			LOG($"Chart Time: {stopwatch_Chart.ElapsedMilliseconds} ms", Color.Red);
			//Console.WriteLine($"Data Processing Time: {stopwatch.ElapsedMilliseconds} ms");
		}
		private void StopBitmapTimer()
		{
			stopwatch_Bitmap.Stop(); // Stopwatch 정지
			LOG($"Bitmap Time: {stopwatch_Bitmap.ElapsedMilliseconds} ms", Color.Red);
			//Console.WriteLine($"Data Processing Time: {stopwatch.ElapsedMilliseconds} ms");
		}
		private void BicubicInterpolation(ref float[,] data, int outWidth, int outHeight)
		{
			if (outWidth < 1 || outHeight < 1)
			{
				throw new ArgumentException(
					"BicubicInterpolation: Expected output size to be " +
					$"[1, 1] or greater, got [{outHeight}, {outWidth}].");
			}

			// props to https://stackoverflow.com/a/20924576/240845 for getting me started
			float InterpolateCubic(float v0, float v1, float v2, float v3, float fraction)
			{
				float p = (v3 - v2) - (v0 - v1);
				float q = (v0 - v1) - p;
				float r = v2 - v0;

				return (fraction * ((fraction * ((fraction * p) + q)) + r)) + v1;
			}

			// around 6000 gives fastest results on my computer.
			int rowsPerChunk = 6000 / outWidth;
			if (rowsPerChunk == 0)
			{
				rowsPerChunk = 1;
			}

			int chunkCount = (outHeight / rowsPerChunk)
							 + (outHeight % rowsPerChunk != 0 ? 1 : 0);

			var width = data.GetLength(1);
			var height = data.GetLength(0);
			var ret = new float[outHeight, outWidth];

			Parallel.For(0, chunkCount, (chunkNumber) =>
			{
				int jStart = chunkNumber * rowsPerChunk;
				int jStop = jStart + rowsPerChunk;
				if (jStop > outHeight)
				{
					jStop = outHeight;
				}

				for (int j = jStart; j < jStop; ++j)
				{
					float jLocationFraction = j / (float)outHeight;
					var jFloatPosition = height * jLocationFraction;
					var j2 = (int)jFloatPosition;
					var jFraction = jFloatPosition - j2;
					var j1 = j2 > 0 ? j2 - 1 : j2;
					var j3 = j2 < height - 1 ? j2 + 1 : j2;
					var j4 = j3 < height - 1 ? j3 + 1 : j3;
					for (int i = 0; i < outWidth; ++i)
					{
						float iLocationFraction = i / (float)outWidth;
						var iFloatPosition = width * iLocationFraction;
						var i2 = (int)iFloatPosition;
						var iFraction = iFloatPosition - i2;
						var i1 = i2 > 0 ? i2 - 1 : i2;
						var i3 = i2 < width - 1 ? i2 + 1 : i2;
						var i4 = i3 < width - 1 ? i3 + 1 : i3;
						float jValue1 = InterpolateCubic(
							data[j1, i1], data[j1, i2], data[j1, i3], data[j1, i4], iFraction);
						float jValue2 = InterpolateCubic(
							data[j2, i1], data[j2, i2], data[j2, i3], data[j2, i4], iFraction);
						float jValue3 = InterpolateCubic(
							data[j3, i1], data[j3, i2], data[j3, i3], data[j3, i4], iFraction);
						float jValue4 = InterpolateCubic(
							data[j4, i1], data[j4, i2], data[j4, i3], data[j4, i4], iFraction);
						data[j, i] = InterpolateCubic(
							jValue1, jValue2, jValue3, jValue4, jFraction);
					}
				}
			});

			return ;
		}
	}
}

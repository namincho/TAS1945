using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class Tas1945_RegForm : Form
	{
		MainForm	g_fMainForm;

		TextBox[]	g_textBox = new TextBox[256];

		/// <summary>
		/// 
		/// </summary>
		public Tas1945_RegForm ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="mf"></param>
		public Tas1945_RegForm (MainForm mf)
		{
			InitializeComponent ();

			g_fMainForm = mf;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tas1945RegForm_FormClosed (object sender, FormClosedEventArgs e)
		{
			g_fMainForm.g_fTas1945RegForm = null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tas1945RegForm_Load (object sender, EventArgs e)
		{
			Initiaizlie ();

			ToolHint ();
		}

		/// <summary>
		/// 
		/// </summary>
		private void ToolHint ()
		{
			ttHint.SetToolTip (tgsInitVerify, "Register Write 후 Verify 실행 유무를 설정 한다.");
			ttHint.SetToolTip (btnTas1945Init, "TAS1945 의 Register 를 Initialize 한다.");
			ttHint.SetToolTip (btnDefault, "Default Register Inital Value 을 Load 한다.");
			ttHint.SetToolTip (gbReg127, "Select Pixel Output Value - REG 190 Control 하여 전송할 TAS1945 의 Pixel 정보를 선택 한다. Sensor 값 또는 Reset 값을 전송 한다.");
			ttHint.SetToolTip (btnTas1945InitClose, "Form Close");
		}

		/// <summary>
		/// 
		/// </summary>
		private void Initiaizlie ()
		{
			for (int i = 0; i < g_textBox.Length; i++)
			{
				TextBox		textBox = (Controls.Find ("tbData" + i.ToString (), true)[0] as TextBox);

				g_fMainForm.TBSet (textBox, g_fMainForm.HexToAscStr (g_fMainForm.g_abyTas1945Register[i], false));
			}

			cbReg127Tp.SelectedIndex = 0;
			cbReg190Tp.SelectedIndex = 0;
			cbReg191Tp.SelectedIndex = 0;
			cbReg156Tp.SelectedIndex = 0;
			cbReg157Tp.SelectedIndex = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tbDataXX_KeyPress (object sender, KeyPressEventArgs e)
		{
			g_fMainForm.HexCheckForInputChar (sender, e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTas1945InitClose_Click (object sender, EventArgs e)
		{
			this.Close ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddrRDXX_Click (object sender, EventArgs e)
		{
			string		strBtnName, strNumber;

			strBtnName = ((Button)sender).Name;
			
			strNumber = strBtnName.Substring ("btnAddrRD".Length);

			g_fMainForm.Tas1945_RegisterRead ((byte)g_fMainForm.StringToUint (strNumber), 0);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddrWRXX_Click (object sender, EventArgs e)
		{
			string		strBtnName, strNumber, strData;
			byte		byAddr;
			byte[]		abyConv = new byte[2];

			strBtnName = ((Button)sender).Name;
			
			strNumber = strBtnName.Substring ("btnAddrWR".Length);

			TextBox		textBox = (Controls.Find ("tbData" + strNumber, true)[0] as TextBox);

			strData = g_fMainForm.TBGet (textBox);

			byAddr = (byte)g_fMainForm.StringToUint (strNumber); 

			if (g_fMainForm.AscStrToHexArr (strData, ref abyConv) > 1)
			{
				g_fMainForm.ERR ("Data length over\n");
				return;
			}

			g_fMainForm.Tas1945_RegisterWrite (byAddr, abyConv[0]);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byRegAddr"></param>
		/// <param name="byRegData"></param>
		public void Set_RegisterDataTextBox (byte byRegAddr, byte byRegData)
		{
			TextBox		textBox = (Controls.Find ("tbData" + g_fMainForm.StringToUint (byRegAddr.ToString ()).ToString (), true)[0] as TextBox);

			g_fMainForm.TBSet (textBox, g_fMainForm.HexToAscStr (byRegData, false));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byRegAddr"></param>
		/// <returns></returns>
		public byte Get_RegisterDataTextBox (byte byRegAddr)
		{
			TextBox		textBox = (Controls.Find ("tbData" + g_fMainForm.StringToUint (byRegAddr.ToString ()).ToString (), true)[0] as TextBox);

			string	strData = g_fMainForm.TBGet (textBox);

			//byte byRegData = (byte)g_fMainForm.StringToInt (strData);
			byte byRegData = (byte)g_fMainForm.HexStr2Byte (strData);

			return	byRegData;
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
				byte[]		abyConv = new byte[2];
				string		strData = String.Empty;

				//	PL read
				g_fMainForm.Tas1945_PL_StatusCheck (false);

				//	255 register setting - 0x10 (Reset)
				g_fMainForm.Tas1945_RegisterWrite (255, 0x10);				//	255, 0x10

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;
				
				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	255 register verify
					g_fMainForm.Tas1945_RegisterRead (255, 0);
					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (255) != 0x10)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}
				
				//	255 register setting - 0x00
				g_fMainForm.Tas1945_RegisterWrite (255, 0x00);				//	255, 0x00

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	255 register verity
					g_fMainForm.Tas1945_RegisterRead (255, 0);

					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (255) != 0x00)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}

				g_fMainForm.g_bCommComplete = false;

				for (int iAddr = 0; iAddr < 255; iAddr++)
				//for (int iAddr = 0; iAddr < 138; iAddr++)
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

					if (g_fMainForm.g_bCommComplete == false)
					{
						if(g_fMainForm.CBGet(g_fMainForm.cbReg24yearSetting))
                        {
							// BFE 2024.02.02 SPI Instruction 진행
							if (iAddr == 212)  // 212번지는 3번 연속으로 Write 해야함
							{
								TextBox textBox = (Controls.Find("tbData" + iAddr.ToString(), true)[0] as TextBox);

								strData = g_fMainForm.TBGet(textBox);

								if (g_fMainForm.AscStrToHexArr(strData, ref abyConv) > 1)
								{
									g_fMainForm.ERR("Data length over\n");
									return;
								}

								g_fMainForm.Tas1945_RegisterWrite((byte)iAddr, abyConv[0]);
								g_fMainForm.Delay(10);
								g_fMainForm.Tas1945_RegisterWrite((byte)iAddr, 0xA0);
								g_fMainForm.Delay(10);
								g_fMainForm.Tas1945_RegisterWrite((byte)iAddr, 0x10);
								g_fMainForm.Delay(10);
							}
                            else  // 212번지 제외한 나머지는 일반 진행
                            {
								TextBox textBox = (Controls.Find("tbData" + iAddr.ToString(), true)[0] as TextBox);

								strData = g_fMainForm.TBGet(textBox);

								if (g_fMainForm.AscStrToHexArr(strData, ref abyConv) > 1)
								{
									g_fMainForm.ERR("Data length over\n");
									return;
								}

								g_fMainForm.Tas1945_RegisterWrite((byte)iAddr, abyConv[0]);
							}
						}
						else
                        {
							// BFE 2024.0202 문서 이전 원본
							TextBox textBox = (Controls.Find("tbData" + iAddr.ToString(), true)[0] as TextBox);

							strData = g_fMainForm.TBGet(textBox);

							if (g_fMainForm.AscStrToHexArr(strData, ref abyConv) > 1)
							{
								g_fMainForm.ERR("Data length over\n");
								return;
							}

							g_fMainForm.Tas1945_RegisterWrite((byte)iAddr, abyConv[0]);
						}
					}

					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if ( g_fMainForm.TGSGet (tgsInitVerify) == true)
					{
						//	Register verity
						//	address 240 에 wirte 된 값이 SPARE 및 200 번대 Register 값에 모두 적용되고 있음.
						//	더 있는지는 확인해 봐야함.
						g_fMainForm.Tas1945_RegisterRead ((byte)iAddr, 0);
						if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

						if (Get_RegisterDataTextBox ((byte)iAddr) != g_fMainForm.HexStr2Byte (strData))
						{
							if ((iAddr != 142) && (iAddr != 210) && (iAddr != 211) && (iAddr != 212) &&			//	Read only Register ????
								(iAddr != 213) && (iAddr != 214) && (iAddr != 215) && (iAddr != 216) && 
								(iAddr != 217) && (iAddr != 218) && (iAddr != 219) && (iAddr != 220) && 
								(iAddr != 221) && (iAddr != 253) && (iAddr != 254))
							{
								g_fMainForm.ERR ("Miss match !!!");

								return;
							}
							else
							{
								g_fMainForm.ERR ("Miss match !!!");
							}
						}
					}

					g_fMainForm.g_bCommComplete = false;
				}

				//	255 register setting - 0x00
				g_fMainForm.Tas1945_RegisterWrite (255, 0x00);				//	255, 0x00

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	255 register verity
					g_fMainForm.Tas1945_RegisterRead (255, 0);

					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (255) != 0x00)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}

				//	BFE guide (20220217)
				//	202107XX version SPI instruction
				//	138 register setting - 0x6A
				g_fMainForm.Tas1945_RegisterWrite (138, 0x6A);				//	138, 0x6A

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	138 register verity
					g_fMainForm.Tas1945_RegisterRead (138, 0);
					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (138) != 0x6A)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}

				//	138 register setting - 0xAA
				g_fMainForm.Tas1945_RegisterWrite (138, 0xAA);				//	138, 0xAA

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	138 register verity
					g_fMainForm.Tas1945_RegisterRead (138, 0);
					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (138) != 0xAA)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}

				//	134 register setting - 0x6A
				g_fMainForm.Tas1945_RegisterWrite (134, 0x6A);				//	134, 0x6A

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	134 register verity
					g_fMainForm.Tas1945_RegisterRead (134, 0);
					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (134) != 0x6A)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}

				//	134 register setting - 0xAA
				g_fMainForm.Tas1945_RegisterWrite (134, 0xAA);				//	134, 0xAA

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (g_fMainForm.TGSGet (tgsInitVerify) == true)
				{
					//	134 register verity
					g_fMainForm.Tas1945_RegisterRead (134, 0);
					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (134) != 0xAA)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}
				
/*				g_fMainForm.Tas1945_RegisterWrite (255, 0x00);				//	255, 0x00

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (tgsInitVerify.Checked == true)
				{
					//	255 register verity
					g_fMainForm.Tas1945_RegisterRead (255, 0);
					if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

					if (Get_RegisterDataTextBox (255) != 0x00)
					{
						g_fMainForm.ERR ("Miss match !!!");
						return;
					}
				}
*/
//				g_fMainForm.g_bSelfReadToggle = false;

				g_fMainForm.LOG ("Register Initialize ok!!!");
			}
			catch (Exception ex)
			{
				g_fMainForm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDefault_Click (object sender, EventArgs e)
		{
			g_fMainForm.Tas1945_RegisterInit ();

			Initiaizlie ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byValue"></param>
		private void Reg_WriteWaitResp (byte byAddress, byte byValue)
		{
			bool bReadStatus = false;

			try
			{
				if (g_fMainForm.BTNGet (g_fMainForm.btnGetPixelInfo) == "Stop")
				{
					bReadStatus = true;
					g_fMainForm.tmPixelCountinue.Stop ();
					//g_fMainForm.tmFrameCnt.Stop();

					Thread.Sleep (100);
				}
				
				//	register setting - 0x00
				g_fMainForm.Tas1945_RegisterWrite (byAddress, byValue);				//	byAddress, 0x00

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return;

				if (bReadStatus == true)
				{ 
					Thread.Sleep (100);

					g_fMainForm.tmPixelCountinue.Interval = (int)g_fMainForm.NUDGet (g_fMainForm.nudInterval);

					g_fMainForm.g_bFistImage = false;

					g_fMainForm.tmPixelCountinue.Start ();
					//g_fMainForm.tmFrameCnt.Start();
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
		/// <param name="byValue"></param>
		private byte Reg_ReadWaitRespCtrl (byte byAddress)
		{
			bool bReadStatus = false;
			byte byValue = 0;

			try
			{
				if (g_fMainForm.BTNGet (g_fMainForm.btnGetPixelInfo) == "Stop")
				{
					bReadStatus = true;
					g_fMainForm.tmPixelCountinue.Stop ();
					//g_fMainForm.tmFrameCnt.Stop();

					Thread.Sleep (100);
				}
				
				g_fMainForm.Tas1945_PL_StatusCheck (false);

				//	register setting - 0x00
				g_fMainForm.Tas1945_RegisterRead (byAddress, 0);				//	byAddress, 0x00

				if (g_fMainForm.Resp_CheckWait (5000) == false)		return byValue;

				byValue= Get_RegisterDataTextBox (byAddress);

				if (bReadStatus == true)
				{ 
					Thread.Sleep (100);

					g_fMainForm.tmPixelCountinue.Interval = (int)g_fMainForm.NUDGet (g_fMainForm.nudInterval);

					g_fMainForm.g_bFistImage = false;

					g_fMainForm.tmPixelCountinue.Start ();
					//g_fMainForm.tmFrameCnt.Start();
				}
			}
			catch (Exception)
			{
				;
			}

			return byValue;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetPixelOutput_Click (object sender, EventArgs e)
		{
			if (g_fMainForm.CBBIdxGet (cbReg127Tp) == 0)
			{
				Reg_WriteWaitResp (127, 0x00);
			}
			else if (g_fMainForm.CBBIdxGet (cbReg127Tp) == 1)
			{
				Reg_WriteWaitResp (127, 0x06);
			}
			else if (g_fMainForm.CBBIdxGet (cbReg127Tp) == 2)
			{
				Reg_WriteWaitResp (127, 0x08);
			}
			else
			{
				Reg_WriteWaitResp (127, 0x00);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetReg190_Click (object sender, EventArgs e)
		{
			int iIndex = g_fMainForm.CBBIdxGet (cbReg190Tp);

			if (iIndex > 31)	return;

			byte byValue = (byte)(iIndex << 2 & 0x00FF);

			Reg_WriteWaitResp (190, byValue);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetReg191_Click (object sender, EventArgs e)
		{
			int iIndex = g_fMainForm.CBBIdxGet (cbReg191Tp);

			if (iIndex > 7)	return;

			byte byValue = Reg_ReadWaitRespCtrl (191);

			byValue &= 0x1F;
			byValue |= (byte)(iIndex << 5 & 0x00FF);

			Reg_WriteWaitResp (191, byValue);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetReg156_Click (object sender, EventArgs e)
		{
			int iIndex = g_fMainForm.CBBIdxGet (cbReg156Tp);

			if (iIndex > 31)	return;

			byte byValue = (byte)(iIndex & 0x001F);

			Reg_WriteWaitResp (156, byValue);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetReg157_Click (object sender, EventArgs e)
		{
			int iIndex = g_fMainForm.CBBIdxGet (cbReg157Tp);

			if (iIndex > 31)	return;

			byte byValue = (byte)(iIndex & 0x001F);

			Reg_WriteWaitResp (157, byValue);
		}
	}
}


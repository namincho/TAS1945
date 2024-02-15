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
		public byte[]	g_abySendData = new byte[1024];
		public uint		g_uiSendSize = 0;

		//public byte[]	g_abyRcvData = new byte[9600 + 128];

		//public int[]	g_aiAvrData = new int[4800];
		public int[]	g_aiAvrData = new int[4860];
		public int		g_iAvrCount;
		
		
		public bool		g_bFoundHeader = false;
		public uint		g_uiLastReqCode = 0;
		public uint		g_uiResCode, g_uiStatus;
		public int[,]	g_iPixelOffset = new int[60, 80];
		public byte[]	g_abyTas1945Register = new byte[256];
		public bool		g_bCommComplete;
		byte[]			g_abyPixelData = new byte[9720];
		int				g_iPixelLen;
		byte			g_byReadDspMode;
		bool			g_bOddEvenToggle;
		byte			g_byReadData;
		public bool		g_bSelfReadToggle = false;
		
		public double	g_dbPixelAvrage;

		public Queue<byte[]>    g_queImage = new Queue<byte[]> ();

		public string	g_strOffsetFileName = @"\Pixel_Offset.csv";			//	Default csv file name

		/// <summary>
		/// 
		/// </summary>
		enum REQ : uint
		{
			DEV_RST				= 0x0001,
			SET_IP				= 0x0002,
			SET_CLK				= 0x0003,
			SET_INIT			= 0x0004,
			REG_RD				= 0x1001,
			REG_WR				= 0x2001,
			GET_SNG_RD			= 0x3001,
			GET_AVR_RD			= 0x3010,
			GET_SNG_RD_81x60	= 0x3002,
			GET_AVR_RD_81x60	= 0x3020,
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyData"></param>
		/// <param name="uiDataSize"></param>
		public void Tas1945_TcpIpSend (uint uiReqCode, byte[] abyData, uint uiDataSize)
		{
			ushort		usCrc16;

			g_uiSendSize = 0;
			Array.Clear (g_abySendData, 0, g_abySendData.Length);

			g_uiLastReqCode = uiReqCode;

			g_abySendData[g_uiSendSize++] = (byte)'T';
			g_abySendData[g_uiSendSize++] = (byte)'P';
			g_abySendData[g_uiSendSize++] = (byte)(uiReqCode >> 0 & 0x00FF);
			g_abySendData[g_uiSendSize++] = (byte)(uiReqCode >> 8 & 0x00FF);
			g_abySendData[g_uiSendSize++] = 0;
			g_abySendData[g_uiSendSize++] = 0;
			g_abySendData[g_uiSendSize++] = 0;
			g_abySendData[g_uiSendSize++] = 0;

			if (uiDataSize > 0)
			{
				Array.Copy (abyData, 0, g_abySendData, g_uiSendSize, uiDataSize);
				g_uiSendSize += uiDataSize;
			}

			g_abySendData[4] = (byte)((g_uiSendSize + 2) >>  0 & 0x000000FF);
			g_abySendData[5] = (byte)((g_uiSendSize + 2) >>  8 & 0x000000FF);
			g_abySendData[6] = (byte)((g_uiSendSize + 2) >> 16 & 0x000000FF);
			g_abySendData[7] = (byte)((g_uiSendSize + 2) >> 24 & 0x000000FF);

			usCrc16 = CalCrc16 (g_abySendData, (int)g_uiSendSize);

			g_abySendData[g_uiSendSize++] = (byte)(usCrc16 >> 0 & 0x00FF);
			g_abySendData[g_uiSendSize++] = (byte)(usCrc16 >> 8 & 0x00FF);

			g_bCommComplete = false;

			TcpIp_ClientSendBytes (g_abySendData, (int)g_uiSendSize);
		}

//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="abyData"></param>
//		/// <param name="iLength"></param>
//		public void Tas1945_RespParser (byte[] abyData, int iLength)
//		{
//			try
//			{
//				//if (Environment.TickCount - g_iCheckTick > 100)
//				if (Environment.TickCount - g_iCheckTick > 5)
//				{
//					g_iCheckTick = Environment.TickCount;
//
//					if (g_bFoundHeader == true)
//					{	
//						//ERR ("Time Out Error !!! : " + HexArrToAscStr (abyData, 0, iLength, true));
//					}
//
//					Array.Clear (g_abyRcvData, 0, g_abyRcvData.Length);
//					g_iRcvSize = 0;
//				
//					g_bFoundHeader = false;
//					g_uiResCode	= 0;
//					g_uiStatus	= 0;
//				}
//
//				Array.Copy (abyData, 0, g_abyRcvData, g_iRcvSize, iLength);
//				g_iRcvSize += iLength;
//
//				if (iLength >= 8 && g_bFoundHeader == false)
//				{
//					if (g_abyRcvData[0] == 'T' && g_abyRcvData[1] == 'P')
//					{
//						g_bFoundHeader = true;
//
//						g_uiResCode  = (uint)g_abyRcvData[2] << 0;
//						g_uiResCode |= (uint)g_abyRcvData[3] << 8;
//						g_uiResCode ^= 0x0100;
//					
//						g_iCheckSize  = (int)g_abyRcvData[4] << 0;
//						g_iCheckSize |= (int)g_abyRcvData[5] << 8;
//						g_iCheckSize |= (int)g_abyRcvData[6] << 16;
//						g_iCheckSize |= (int)g_abyRcvData[7] << 24;
//
//						g_uiStatus  = (uint)g_abyRcvData[8] << 0;
//						g_uiStatus |= (uint)g_abyRcvData[9] << 8;
//					}
//				}
//			
//				if (g_iRcvSize >= g_iCheckSize)
//				{
//					if (g_uiResCode != (uint)REQ.GET_SNG_RD && g_uiResCode != (uint)REQ.GET_AVR_RD)
//					{
//						//	CRC16 검사
//					}
//
//					if (tgsDebugLog.Checked == true)
//					{
//						LOG ("RES : " + HexArrToAscStr (g_abyRcvData, 0, g_iRcvSize, true));
//					}
//
//					g_bCommComplete = true;
//
//					switch (g_uiResCode)
//					{
//						case (uint)REQ.DEV_RST :
//							if (g_uiStatus == 0x00)	LOG ("Reset Success !!!", Color.Blue);
//							else					ERR ("Reset Error !!! : " + g_uiStatus.ToString ());
//							break;
//
//						case (uint)REQ.SET_IP :
//							if (g_uiStatus == 0x00)	LOG ("Set IP Success !!!", Color.Blue);
//							else					ERR ("Set IP Error !!! : " + g_uiStatus.ToString ());
//							break;
//
//						case  (uint)REQ.SET_CLK :
//							if (g_uiStatus == 0x00)	LOG ("Set CLK Success !!!", Color.Blue);
//							else					ERR ("Set CLK Error !!! : " + g_uiStatus.ToString ());
//							break;
//
//						case (uint)REQ.SET_INIT :
//							if (g_uiStatus == 0x00)	LOG ("Set Init Success !!!", Color.Blue);
//							else					ERR ("Set Init Error !!! : " + g_uiStatus.ToString ());
//
//							for (int i = 0; i < (g_iRcvSize  - 12) / 2; i++)
//							{
//								LOG ("REG RD : " + g_abyRcvData[(i * 2) + 10].ToString () + ", " + g_abyRcvData[(i * 2) + 11].ToString () + "[0x" + HexToAscStr (g_abyRcvData[(i * 2) + 11], false) + "]" , Color.Blue);
//							}
//							break;
//
//						case (uint)REQ.REG_RD :
//							if (g_uiStatus == 0x00)
//							{
//								if (g_byReadDspMode == 1)	TBSet (tbRegData, HexArrToAscStr (g_abyRcvData, 11, 1, false));
//
//								g_abyTas1945Register[StringToInt (g_abyRcvData[10].ToString ())] = (byte)StringToInt (g_abyRcvData[11].ToString ());
//							
//								if (g_byReadDspMode == 0)	g_fTas1945RegForm.Set_RegisterDataTextBox (g_abyRcvData[10], g_abyRcvData[11]);
//
//								g_byReadData = g_abyRcvData[11];
//
//								//LOG ("REG RD Success !!! : " + abyData[10].ToString () + ", " + abyData[11].ToString () + "[" + HexToAscStr (abyData[11], false) + "]" , Color.Blue);
//								if (g_byReadDspMode != 3)	LOG ("REG RD : " + g_abyRcvData[10].ToString () + ", " + g_abyRcvData[11].ToString () + "[0x" + HexToAscStr (g_abyRcvData[11], false) + "]" , Color.Blue);
//							}
//							else
//							{
//								ERR ("REG RD Error !!! : " + g_uiStatus.ToString ());
//							}
//							break;
//
//						case (uint)REQ.REG_WR :
//							//if (g_uiStatus == 0x00)	LOG ("REG WR Success !!!", Color.Blue);
//							//else					ERR ("REG WR Error !!! : " + g_uiStatus.ToString ());
//							if (g_uiStatus != 0x00)		ERR ("REG WR Error !!! : " + g_uiStatus.ToString ());
//							break;
//
//						case (uint)REQ.GET_SNG_RD :
//						case (uint)REQ.GET_AVR_RD :
//							if (g_uiStatus == 0x00)
//							{
//								if (g_iCheckSize != 9613)
//								{
//									ERR ("Pixel Size Error !!!");
//									return;
//								}
//
//								if (tgsPixels.Checked == false)
//								{
//									g_ucRawImage.SetImageSize (tgsImageX10.Checked);
//								}
//
//								if ((g_uiResCode == (uint)REQ.GET_SNG_RD) || (g_uiResCode == (uint)REQ.GET_AVR_RD))
//								{
//									Array.Clear (g_abyPixelData, 0, g_abyPixelData.Length);
//									g_iPixelLen = 0;
//
//									if (tgsCvsSave.Checked == true)
//									{
//										Tas1945_CvsSave (g_abyRcvData, g_iRcvSize, 11, 120);
//										Tas1945_TextSave (g_abyRcvData, g_iRcvSize, 11, g_iRcvSize - 13);
//									}
//
//									g_iPixelLen = 9600;
//
//									Array.Copy (g_abyRcvData, 11, g_abyPixelData, 0, g_iPixelLen);
//
//									if ((tgsDspAverage.Checked == false) || ((tgsDspAverage.Checked == true) && (g_iAvrCount == 7)))
//									{
//										if (tgsDspAverage.Checked == true && g_iAvrCount == 7)
//										{
//											for (int i = 0; i < g_aiAvrData.Length; i++)
//											{
//												g_aiAvrData[i] += (int)(g_abyPixelData[i * 2 + 0] << 0 | g_abyPixelData[i * 2 + 1] << 8);
//
//												g_aiAvrData[i] /= 8;
//
//												g_abyPixelData[i * 2 + 0] = (byte)(g_aiAvrData[i] >> 0 & 0xFF);
//												g_abyPixelData[i * 2 + 1] = (byte)(g_aiAvrData[i] >> 8 & 0xFF);
//											}
//										}		
//
//										if (tgsDebugLog.Checked == true && g_iAvrCount == 7)
//										{
//											LOG ("AVR : " + HexArrToAscStr (g_abyPixelData, 0, 9600, true));
//										}
//
//										//	여기서 offset value 로 보정해야한다.
//										if (tgsOffset.Checked == true && tgsRowOffset.Checked == false)
//										{
//											Tas1945_PixelOffset (ref g_abyPixelData, g_iPixelLen);
//										}
//										else if (tgsRowOffset.Checked == true && tgsOffset.Checked == false)
//										{
//											Tas1945_Set_ColumnOffset (ref g_abyPixelData, g_iPixelLen);
//										}
//
//										//	만약 High Temp 에 적용되는 Gain value 로 보정해야 한다.
//										if (g_queImage.Count < 45)
//										{
//											g_queImage.Enqueue (g_abyPixelData);
//										}
//
//										if (tgsContinue.Checked != true)
//										{
//											g_iAvrCount = 8;
//										}
//										else
//										{
//											g_iAvrCount = 0;
//										}
//									}
//									else
//									{
//										if (g_iAvrCount == 0)
//										{
//											Array.Clear (g_aiAvrData, 0, g_aiAvrData.Length);
//											
//											for (int i = 0; i < g_aiAvrData.Length; i++)
//											{
//												g_aiAvrData[i] = (int)(g_abyPixelData[i * 2 + 0] << 0 | g_abyPixelData[i * 2 + 1] << 8);
//											}
//										}
//										else
//										{
//											for (int i = 0; i < g_aiAvrData.Length; i++)
//											{
//												g_aiAvrData[i] += (int)(g_abyPixelData[i * 2 + 0] << 0 | g_abyPixelData[i * 2 + 1] << 8);
//											}
//										}
//
//										g_iAvrCount++;
//									}
//								}
//							
//								tmImageDsp.Start ();
//
//								if ((g_bContinueRead != true) || (tgsDspAverage.Checked == true && g_iAvrCount == 8))
//								{
//									LOG ("GET SNG RD : " + g_abyRcvData[10].ToString (), Color.Blue);
//								}
//							}
//							else
//							{
//								//ERR ("GET SNG RD Error !!! : " + g_uiStatus.ToString ());
//							}
//							break;
//
//						case (uint)REQ.GET_SNG_RD_81x60 :
//						case (uint)REQ.GET_AVR_RD_81x60 :
//							if (g_uiStatus == 0x00)
//							{
//								if (g_iCheckSize != 9733)
//								{
//									ERR ("Pixel Size Error !!!");
//									return;
//								}
//
//								if (tgsPixels.Checked == false)
//								{
//									g_ucRawImage.SetImageSize (tgsImageX10.Checked);
//								}
//
//								if ((g_uiResCode == (uint)REQ.GET_SNG_RD_81x60) || (g_uiResCode == (uint)REQ.GET_AVR_RD_81x60))
//								{
//									Array.Clear (g_abyPixelData, 0, g_abyPixelData.Length);
//									g_iPixelLen = 0;
//
//									/*
//									if (tgsCvsSave.Checked == true)
//									{
//										Tas1945_CvsSave (g_abyRcvData, g_iRcvSize, 11, 120);
//										Tas1945_TextSave (g_abyRcvData, g_iRcvSize, 11, g_iRcvSize - 13);
//									}
//									*/
//
//									g_iPixelLen = 9720;
//
//									Array.Copy (g_abyRcvData, 11, g_abyPixelData, 0, g_iPixelLen);
//
//									if ((tgsDspAverage.Checked == false) || ((tgsDspAverage.Checked == true) && (g_iAvrCount == 7)))
//									{
//										if (tgsDspAverage.Checked == true && g_iAvrCount == 7)
//										{
//											for (int i = 0; i < g_aiAvrData.Length; i++)
//											{
//												g_aiAvrData[i] += (int)(g_abyPixelData[i * 2 + 0] << 0 | g_abyPixelData[i * 2 + 1] << 8);
//
//												g_aiAvrData[i] /= 8;
//
//												g_abyPixelData[i * 2 + 0] = (byte)(g_aiAvrData[i] >> 0 & 0xFF);
//												g_abyPixelData[i * 2 + 1] = (byte)(g_aiAvrData[i] >> 8 & 0xFF);
//											}
//										}		
//
//										if (tgsDebugLog.Checked == true)
//										{
//											LOG ("AVR : " + HexArrToAscStr (g_abyPixelData, 0, 9720, true));
//										}
//
//										/*
//										//	여기서 offset value 로 보정해야한다.
//										if (tgsOffset.Checked == true && tgsRowOffset.Checked == false)
//										{
//											Tas1945_PixelOffset (ref g_abyPixelData, g_iPixelLen);
//										}
//										else if (tgsRowOffset.Checked == true && tgsOffset.Checked == false)
//										{
//											Tas1945_Set_ColumnOffset (ref g_abyPixelData, g_iPixelLen);
//										}
//										*/
//
//										if (tgsRowOffset.Checked == true && tgsOffset.Checked == false)
//										{
//											Tas1945_Set_ColumnOffset (ref g_abyPixelData, g_iPixelLen);
//										}
//
//										//	만약 High Temp 에 적용되는 Gain value 로 보정해야 한다.
//
//										if (g_queImage.Count < 45)
//										{
//											g_queImage.Enqueue (g_abyPixelData);
//										}
//
//										if (tgsContinue.Checked != true)
//										{
//											g_iAvrCount = 8;
//										}
//										else
//										{
//											g_iAvrCount = 0;
//										}
//									}
//									else
//									{
//										if (g_iAvrCount == 0)
//										{
//											Array.Clear (g_aiAvrData, 0, g_aiAvrData.Length);
//											
//											for (int i = 0; i < g_aiAvrData.Length; i++)
//											{
//												g_aiAvrData[i] = (int)(g_abyPixelData[i * 2 + 0] << 0 | g_abyPixelData[i * 2 + 1] << 8);
//											}
//										}
//										else
//										{
//											for (int i = 0; i < g_aiAvrData.Length; i++)
//											{
//												g_aiAvrData[i] += (int)(g_abyPixelData[i * 2 + 0] << 0 | g_abyPixelData[i * 2 + 1] << 8);
//											}
//										}
//
//										g_iAvrCount++;
//									}
//								}
//							
//								tmImageDsp.Start ();
//
//								if ((g_bContinueRead != true) || (tgsDspAverage.Checked == true && g_iAvrCount == 8))
//								{
//									LOG ("GET SNG RD Success !!!", Color.Blue);
//								}
//							}
//							else
//							{
//								//ERR ("GET SNG RD Error !!! : " + g_uiStatus.ToString ());
//							}
//							break;
//
//						default :
//							//ERR ("Unknown Code !!! : " + HexArrToAscStr (abyData, 0, iLength, true));
//							return;
//					}
//
//					Array.Clear (g_abyRcvData, 0, g_abyRcvData.Length);
//					g_iRcvSize = 0;
//				
//					g_bFoundHeader = false;
//					g_uiResCode	= 0;
//					g_uiStatus	= 0;
//				}
//			}
//			//catch (Exception ex)
//			catch (Exception)
//			{
//				//ERR (ex.Message);
//			}
//		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyAvrData"></param>
		/// <param name="iAvrLen"></param>
		public void Tas1945_PixelOffset (ref byte[] abyAvrData, int iAvrLen)
		{
			try
			{
				if (iAvrLen < 9600)		return;

				for (int i = 0; i < 60; i++)
				{
					for (int j = 0; j < 80; j++)
					{
						short sOffset = (short)(abyAvrData[i * 80 * 2 + j * 2] << 0 | abyAvrData[i * 80 * 2 + j * 2 + 1] << 8);
						sOffset += (short)g_iPixelOffset[i, j];

						abyAvrData[i * 80 * 2 + j * 2]		= (byte)(sOffset >> 0 & 0xFF);
						abyAvrData[i * 80 * 2 + j * 2 + 1]	= (byte)(sOffset >> 8 & 0xFF);
					}
				}
			}
			catch (Exception)
			{
				;	//
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
			if (tgsCvsSave.Checked == false)	return;

			if (iSaveSize % 9600 != 0)	return;

			RawLog_TextFileOpen ();
			
			//	80 * 60 * 2 개씩 나누어서 라인 바꿔서 저장
			for (int i = 0; i < iSaveSize / 9600; i++)
			{
				RawLog_TextFileWrite (HexArrToAscStr (g_abyRcvData, iStartIdx + (9600 * i), 9600, false));
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
		/// <param name="abySaveData"></param>
		/// <param name="iSaveSize"></param>
		/// <param name="iStartIdx"></param>
		public void Tas1945_CvsAvrSave (byte[] abySaveData, int iSaveSize, int iStartIdx)
		{
			if (tgsCvsSave.Checked == false)	return;

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
		public void Tas1945_RegisterWrite ()
		{
			byte[]		abyConv = new byte[2];
			byte[]		abyData = new byte[2];

			if (AscStrToHexArr (tbRegData.Text, ref abyConv) > 1)
			{
				ERR ("Data length over\n");
				return;
			}

			abyData[0] = (byte)NUPGet (nudRegAddr);
			abyData[1] = abyConv[0];

			LOG ("REG WR : " + abyData[0].ToString () + ", " + abyData[1].ToString () + "[0x" + HexToAscStr (abyData[1], false) + "]" , Color.Blue);

			Tas1945_TcpIpSend ((uint)REQ.REG_WR, abyData, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byRegAddr"></param>
		/// <param name="byRegData"></param>
		public void Tas1945_RegisterWrite (byte byRegAddr, byte byRegData)
		{
			byte[]		abyData = new byte[2];

			abyData[0] = byRegAddr;
			abyData[1] = byRegData;

			LOG ("REG WR : " + byRegAddr.ToString () + ", " + byRegData.ToString () + "[0x" + HexToAscStr (byRegData, false) + "]", Color.Blue);

			Tas1945_TcpIpSend ((uint)REQ.REG_WR, abyData, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterRead (byte byMainUi)
		{
			byte[]		abyData = new byte[1];

			abyData[0] = (byte)NUPGet (nudRegAddr);

			g_byReadDspMode = byMainUi;

			Tas1945_TcpIpSend ((uint)REQ.REG_RD, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterRead (byte byAddr, byte byMainUi)
		{
			byte[]		abyData = new byte[1];

			abyData[0] = byAddr;

			g_byReadDspMode = byMainUi;

			Tas1945_TcpIpSend ((uint)REQ.REG_RD, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_GetSinglePixelInfo ()
		{
			byte[]		abyData = new byte[1];

			if		(rbSingleOdd.Checked == true)	abyData[0] = 0x01;
			else if (rbSingleEven.Checked == true)	abyData[0] = 0x02;
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
			
			if (tgsSensorTyp.Checked == false)
			{
				if (tgsAverage.Checked == false)	Tas1945_TcpIpSend ((uint)REQ.GET_SNG_RD, abyData, 1);
				else								Tas1945_TcpIpSend ((uint)REQ.GET_AVR_RD, abyData, 1);
			}
			else
			{
				if (tgsAverage.Checked == false)	Tas1945_TcpIpSend ((uint)REQ.GET_SNG_RD_81x60, abyData, 1);
				else								Tas1945_TcpIpSend ((uint)REQ.GET_AVR_RD_81x60, abyData, 1);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_Reset ()
		{
			Tas1945_TcpIpSend ((uint)REQ.DEV_RST, null, 0);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_IpSetup ()
		{	
			string	strSetIp;

			strSetIp = ipSetAddress.Text + ":" + NUPGet (nupSetPort).ToString ();

			byte[]	abyIpData = Encoding.UTF8.GetBytes (strSetIp);
			byte[]	abySendData = new byte[abyIpData.Length + 1];

			if (tbSetIpServer.Checked == true)	abySendData[0] = 0x01;
			else								abySendData[0] = 0x02;

			Array.Copy (abyIpData, 0, abySendData, 1, abyIpData.Length);

			Tas1945_TcpIpSend ((uint)REQ.SET_IP, abySendData, (uint)abySendData.Length);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_LoadPixelOffset (string strFileName)
		{
			try
			{
				StreamReader srPixelOffset = new StreamReader (strFileName);

				Array.Clear (g_iPixelOffset, 0, g_iPixelOffset.Length);

				for (int j = 0; j < 60; j++)
				{
					string strReadLine = srPixelOffset.ReadLine ();
					string[] strReadData = strReadLine.Split (',');

					for (int i = 0; i < strReadData.Length; i++)
					{
						g_iPixelOffset[j, i] = StringToInt (strReadData[i]);
					}
					
					while (srPixelOffset.EndOfStream)
						break;
				}

				if (srPixelOffset != null)
				{
					srPixelOffset.Close ();
					srPixelOffset = null;
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
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Tas1945_GetPixelOffset (int x, int y)
		{
			return	g_iPixelOffset[y, x];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyPixelData"></param>
		/// <param name="iPixelSize"></param>
		public void Tas1945_Set_ColumnOffset (ref byte[] abyPixelData, int iPixelSize)
		{
			try
			{
				int[]	aiPixelOffset = new int[80];
				
				Array.Clear (aiPixelOffset, 0, aiPixelOffset.Length);

				for (int i = 0; i < 60; i++)
				{
					for (int j = 0; j < 80; j++)
					{
						aiPixelOffset[j] += (int)(abyPixelData[(i * 80 * 2) + (j * 2)] << 0 | abyPixelData [(i * 80 * 2) + (j * 2 + 1)] << 8);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					aiPixelOffset[i] /= 60;
				}

				for (int i = 0; i < 60; i++)
				{
					for (int j = 0; j < 80; j++)
					{
						int iPixelData = (int)(abyPixelData[(i * 80 * 2) + (j * 2)] << 0 | abyPixelData [(i * 80 * 2) + (j * 2 + 1)] << 8);

						iPixelData -= aiPixelOffset[j];

						abyPixelData[(i * 80 * 2) + (j * 2)]		= (byte)(iPixelData >> 0 & 0xFF);
						abyPixelData [(i * 80 * 2) + (j * 2 + 1)]	= (byte)(iPixelData >> 8 & 0xFF);
					}
				}
			}
			catch (Exception)
			{
				//
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
		
//		/// <summary>
//		/// 
//		/// </summary>
//		public void Tas1945_SelfRead ()
//		{
//			try
//			{
//				byte byRow, byCol;
//
//				/*
//				if (Resp_CheckWait (5000) == false)		return;
//
//					//	255 register verify
//					Tas1945_RegisterRead (255, false);
//					if (Resp_CheckWait (5000) == false)		return;
//
//					if (Get_RegisterDataTextBox (255) != 0x10)
//					{
//						g_fMainForm.ERR ("Miss match !!!");
//						return;
//					}
//	*/
//
//
//				Array.Clear (g_abyPixelData, 0, g_abyPixelData.Length);
//				g_iPixelLen = 0;
//
//				//	ODD
//				//	255		0
//				Tas1945_RegisterWrite (255, 0x00);
//				if (Resp_CheckWait (5000) == false)		return;
//
//				//	158		C0
//				Tas1945_RegisterWrite (158, 0xC0);
//				if (Resp_CheckWait (5000) == false)		return;
//
//				//	158		D1
//				Tas1945_RegisterWrite (158, 0xD1);
//				if (Resp_CheckWait (5000) == false)		return;
//
//				//	158		C2 - Odd
//				//	158		C4 - Even
//				if (g_bSelfReadToggle == false)
//				{
//					Tas1945_RegisterWrite (158, 0xC2);
//					g_bSelfReadToggle = true;
//				}
//				else
//				{
//					Tas1945_RegisterWrite (158, 0xC4);
//					g_bSelfReadToggle = false;
//				}
//
//				if (Resp_CheckWait (5000) == false)		return;
//
//
//
//
//
//
//				//	158		C8
//				Tas1945_RegisterWrite (158, 0xC8);
//				if (Resp_CheckWait (5000) == false)		return;
//
//				//	158		C0
//				Tas1945_RegisterWrite (158, 0xC0);
//				if (Resp_CheckWait (5000) == false)		return;
//
//
//
//
//
//
//
//
//				for (byRow = 0; byRow < 60; byRow++)
//				{
//					//	176		00...9F
//					Tas1945_RegisterWrite (176, byRow);
//					if (Resp_CheckWait (5000) == false)		return;
//
//					//	255		01
//					Tas1945_RegisterWrite (255, 0x01);
//					if (Resp_CheckWait (5000) == false)		return;
//
//					//	0
//					Tas1945_RegisterRead (0, 2);
//					if (Resp_CheckWait (5000) == false)		return;
//
//					for (byCol = 1; byCol < 160; byCol++)
//					{
//						//	1 ~ 159 read
//						if (byCol == 159)	Tas1945_RegisterRead (byCol, 2);
//						else				Tas1945_RegisterRead (byCol, 3);
//
//							if (Resp_CheckWait (5000) == false)		return;
//
//						g_abyPixelData[g_iPixelLen++] = g_byReadData;
//					}
//					
//					//	159
//					Tas1945_RegisterRead (159, 2);
//					if (Resp_CheckWait (5000) == false)		return;
//
//					g_abyPixelData[g_iPixelLen++] = g_byReadData;
//
//					//	255		0
//					Tas1945_RegisterWrite (255, 0x00);
//					if (Resp_CheckWait (5000) == false)		return;
//				}
//
//				/*
//				//	158		C8
//				Tas1945_RegisterWrite (158, 0xC8);
//				if (Resp_CheckWait (5000) == false)		return;
//
//				//	158		C0
//				Tas1945_RegisterWrite (158, 0xC0);
//				if (Resp_CheckWait (5000) == false)		return;
//				*/
//
//				if (g_queImage.Count < 45)
//				{
//					g_queImage.Enqueue (g_abyPixelData);
//				}
//
//				tmImageDsp.Start ();
//			}
//			catch (Exception ex)
//			{
//				ERR (ex.Message);
//			}
//		}
				
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

			abyData[0] = (byte)NUPGet (nudSetClock);

			Tas1945_TcpIpSend ((uint)REQ.SET_CLK, abyData, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_SetInit ()
		{
			try
			{
				byte[] abyData = new byte[778];
				uint uiDataLen;

				uiDataLen = 0;

	//			Tas1945_RegisterInit ();

				//	Address 255, 0x10: Reset
				abyData[uiDataLen++] = 255;		
				abyData[uiDataLen++] = 0x10;

				//	Address 255, 0x00: Sel Bank 0
				abyData[uiDataLen++] = 255;		
				abyData[uiDataLen++] = 0x00;

				for (int iAddr = 0; iAddr < 255; iAddr++)
				{
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
					if (iAddr >= 222 && iAddr <= 223)	
						continue;
					if (iAddr >= 224 && iAddr <= 239)	continue;
					if (iAddr >= 241 && iAddr <= 254)	continue;

					abyData[uiDataLen++] = (byte)iAddr;
					abyData[uiDataLen++] = g_abyTas1945Register[iAddr];
				}

				//	Address 255, 0x00: Sel Bank 0
				abyData[uiDataLen++] = 255;		
				abyData[uiDataLen++] = 0x00;

				Tas1945_TcpIpSend ((uint)REQ.SET_INIT, abyData, uiDataLen);
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Tas1945_RegisterInit ()
		{
			int		iIndex;

			iIndex = 0;

			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 0 - rro_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 1 - rro_start [8:15]
			g_abyTas1945Register[iIndex++] = 0xA6;		//  Register: 2 - rro_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 3 - rro_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 4 - pna_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 5 - pna_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x02;		//  Register: 6 - pna_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 7 - pna_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 8 - g2_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 9 - g2_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x1A;		//  Register: 10 - g2_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 11 - g2_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 12 - g3_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 13 - g3_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x0E;		//  Register: 14 - g3_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 15 - g3_stop [8:15]

			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 16 - g4_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 17 - g4_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x0E;		//  Register: 18 - g4_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 19 - g4_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x10;		//  Register: 20 - gccrst_b_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 21 - gccrst_b_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 22 - gccrst_b_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 23 - gccrst_b_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x03;		//  Register: 24 - xfr_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 25 - xfr_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x05;		//  Register: 26 - xfr_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 27 - xfr_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x0C;		//  Register: 28 - store_b_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 29 - store_b_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x06;		//  Register: 30 - store_b_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 31 - store_b_stop [8:15]

			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 32 - adcramprst_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 33 - adcramprst_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x1A;		//  Register: 34 - adcramprst_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 35 - adcramprst_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 36 - buff_en_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 37 - buff_en_start [8:15]
			g_abyTas1945Register[iIndex++] = 0xEE;		//  Register: 38 - buff_en_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x0F;		//  Register: 39 - buff_en_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 40 - clr_stk_in_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 41 - clr_stk_in_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x09;		//	Register: 42 - clr_stk_in_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 43 - clr_stk_in_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 44-47 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 45
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 46
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 47

			g_abyTas1945Register[iIndex++] = 0x50;		//  Register: 48 - intsmpl_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 49 - intsmpl_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x6A;		//  Register: 50 - intsmpl_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x03;		//  Register: 51 - intsmpl_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x54;		//  Register: 52 - intpsh_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 53 - intpsh_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x66;		//  Register: 54 - intpsh_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x03;		//  Register: 55 - intpsh_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 56 - ps2_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 57 - ps2_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x1C;		//  Register: 58 - ps2_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x03;		//  Register: 59 - ps2_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x2E;		//  Register: 60 - ps3_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x06;		//  Register: 61 - ps3_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x31;		//  Register: 62 - ps3_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x06;		//  Register: 63 - ps3_stop [8:15]

			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 64 - chopn_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 65 - chopn_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x34;		//  Register: 66 - chopn_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 67 - chopn_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x32;		//  Register: 68 - chopp_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 69 - chopp_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 70 - chopp_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 71 - chopp_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x64;		//  Register: 72 - demodn_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 73 - demodn_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x41;		//  Register: 74 - demodn_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 75 - demodn_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x2E;		//  Register: 76 - demodp_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 77 - demodp_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x0B;		//  Register: 78 - demodp_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 79 - demodp_stop [8:15]

			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 80 - p4_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 81 - p4_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x31;		//  Register: 82 - p4_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 83 - p4_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x32;		//  Register: 84 - p5_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 85 - p5_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 86 - p5_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 87 - p5_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 88 - p6_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 89 - p6_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 90 - p6_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 91 - p6_stop [8:15]
			g_abyTas1945Register[iIndex++] = 0x60;		//  Register: 92 - p7_start [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 93 - p7_start [8:15]
			g_abyTas1945Register[iIndex++] = 0x62;		//  Register: 94 - p7_stop [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 95 - p7_stop [8:15]

			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 96-111 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 97
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 98
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 99
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 100
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 101
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 102
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 103
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 104
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 105
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 106
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 107
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 108
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 109
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 110
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 111

			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 112 - idac_chop [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 113 - idac_demod [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 114 - idac_intsmpl [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 115 - idac_intpsh [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 116 - idac_srsta [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 117 - idac_srstb [0:5]
			g_abyTas1945Register[iIndex++] = 0x18;		//  Register: 118 - idac_sig_sigb [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 119 - idac_intrst [0:5]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 120 - spare
			g_abyTas1945Register[iIndex++] = 0x24;		//  Register: 121 - idac_adcramp [0:5]
			g_abyTas1945Register[iIndex++] = 0x09;		//  Register: 122 - idac_vb2 [0:5]
			g_abyTas1945Register[iIndex++] = 0x1F;		//  Register: 123 - idac_atcore [0:5]
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 124-126 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 125
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 126
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 127 - Mixed - sel_sig_test, sel_rst_test

			g_abyTas1945Register[iIndex++] = 0xAA;		//  Register: 128 - Mixed - rro_man, rro_en, pna_man, pna_en, g2_man, g2_en, g3_man, g3_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 129 - Mixed - rro_sinv, rro_rrst, pna_sinv, pna_rrst, g2_sinv, g2_rrst, g3_sinv, g3_rrst
			g_abyTas1945Register[iIndex++] = 0xA8;		//  Register: 130 - Mixed - g4_man, g4_en, gccrst_b_man, gccrst_b_en, xfr_man, xfr_en, store_b_man, store_b_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 131 - Mixed - g4_sinv, g4_rrst, gccrst_b_sinv, gccrst_b_rrst, xfr_sinv, xfr_rrst, store_b_sinv, store_b_rrst
			g_abyTas1945Register[iIndex++] = 0x2A;		//  Register: 132 - Mixed - adcramprst_man, adcramprst_en, buff_en_man, buff_en_en, clr_stk_in_man, clr_stk_in_en, g11_man, g11_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 133 - Mixed - adcramprst_sinv, adcramprst_rrst, buff_en_sinv, buff_en_rrst, clr_stk_in_sinv, clr_stk_in_rrst, g11_sinv, g11_rrst
			g_abyTas1945Register[iIndex++] = 0xAA;		//  Register: 134 - Mixed - intsmpl_man, intsmpl_en, intpsh_man, intpsh_en, ps2_man, ps2_en, ps3_man, ps3_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 135 - Mixed - intsmpl_sinv, intsmpl_rrst, intpsh_sinv, intpsh_rrst, ps2_sinv, ps2_rrst, ps3_sinv, ps3_rrst
			g_abyTas1945Register[iIndex++] = 0xAA;		//  Register: 136 - Mixed - chopn_man, chopn_en, chopp_man, chopp_en, demodn_man, demodn_en, demodp_man, demodp_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 137 - Mixed - chopn_sinv, chopn_rrst, chopp_sinv, chopp_rrst, demodn_sinv, demodn_rrst, demodp_sinv, demodp_rrst
			g_abyTas1945Register[iIndex++] = 0xAA;		//  Register: 138 - Mixed - p4_man, p4_en, p5_man, p5_en, p6_man, p6_en, p7_man, p7_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 139 - Mixed - p4_sinv, p4_rrst, p5_sinv, p5_rrst, p6_sinv, p6_rrst, p7_sinv, p7_rrst
			g_abyTas1945Register[iIndex++] = 0xAA;		//  Register: 140 - Mixed - p8_man, p8_en, p9_man, p9_en, p10_man, p10_en, p11_man, p11_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 141 - Mixed - p8_sinv, p8_rrst, p9_sinv, p9_rrst, p10_sinv, p10_rrst, p11_sinv, p11_rrst
			g_abyTas1945Register[iIndex++] = 0xAA;		//  Register: 142 - Mixed - p12_man, p12_en, p13_man, p13_en, p14_man, p14_en, p15_man, p15_en
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 143 - Mixed - p12_sinv, p12_rrst, p13_sinv, p13_rrst, p14_sinv, p14_rrst, p15_sinv, p15_rrst

			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 144 - Mixed - lvdsctrl[0], lvdsctrl[1], lvdsctrl[2], lvdsctrl[3], lvdsctrl[4], lvdsctrl[5], lvdsctrl[6], lvdsctrl[7]
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 145-153 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 146
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 147
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 148
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 149
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 150
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 151
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 152
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 153
			g_abyTas1945Register[iIndex++] = 0x2F;		//  Register: 154 - clk_divider_2M [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 155 - clk_divider_2M [8:15]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 156 - dto1_sel[0],
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 157 - dto0_sel[0],
			g_abyTas1945Register[iIndex++] = 0xC0;		//  Register: 158 - Mixed - intrst, srsta, srstb, ssig, foe, pd, rowen
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 159 - spare

			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 160-175 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 161
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 162
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 163
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 164
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 165
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 166
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 167
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 168
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 169
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 170
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 171
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 172
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 173
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 174
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 175

			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 176 - row address for pixel
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 177 -
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 178 - Mixed - rcnt_ra_sel, rcnt_cnt_down, rcnt_cnt_up, rcnt_en, rcnt_ensy [0:1], rcnt_clk_pol, rcnt_lsync_sel
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 179 - rcnt_regrst [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 180 - rcnt_regrst [8:15]
			g_abyTas1945Register[iIndex++] = 0x48;		//  Register: 181 - man[3:0],ds_sox[2:0], lsync_bit
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 182 - Mixed - lsync_rcnt_sel [0:0], lsync_pat_sel [0:0], rcnt_xsync_en, rcnt_rs_lsb_sel, rcnt_clr_sel
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 183-189 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 184
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 185
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 186
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 187
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 188
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 189
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 190 - ato_sel[0:5]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 191 - Mixed - ato_sf_bias, ato_vout_pd, ato_hs_sel, ato_hs_mux [0:2]

			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 192-207 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 193
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 194
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 195
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 196
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 197
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 198
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 199
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 200
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 201
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 202
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 203
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 204
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 205
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 206
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 207
			
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 208 - pat_dload [0:7]
			g_abyTas1945Register[iIndex++] = 0x00;		//  Register: 209 - pat_dload [8:15]
			g_abyTas1945Register[iIndex++] = 0x53;		//  Register: 210 - Mixed - pat_cn_en, pat_cnt_up, pat_cnt_down, pat_clk_pol, pat_ensy[0], pat_ensy[1], pat_ensyp[0], pat_ensyp[1]
			g_abyTas1945Register[iIndex++] = 0x01;		//  Register: 211 - Mixed - pat_ensyps[0],
			g_abyTas1945Register[iIndex++] = 0x81;		//  Register: 212 - Mixed - pat_cntsel_bit, pat_ensyps[1] pat_prst_sel, pat_disable_sclr, pat_en_sync, pat_ppload_sel [0:1], pat_pload_sel [0:1]
			g_abyTas1945Register[iIndex++] = 0x1E;		//  Register: 213 - d_intcm [0:5]
			g_abyTas1945Register[iIndex++] = 0x1D;		//  Register: 214 - d_intcmbuf [0:5]
			g_abyTas1945Register[iIndex++] = 0x17;		//  Register: 215 - d_pixamp_vocm [0:5]
			g_abyTas1945Register[iIndex++] = 0x1F;		//  Register: 216 - d_intamp_col [0:5]
			g_abyTas1945Register[iIndex++] = 0x20;		//  Register: 217 - d_pixamp_col [0:5]
			g_abyTas1945Register[iIndex++] = 0x1F;		//  Register: 218 - d_pixamp_fb_col [0:5]
			g_abyTas1945Register[iIndex++] = 0x07;		//  Register: 219 - d_vb_pixout [0:5]
			g_abyTas1945Register[iIndex++] = 0x17;		//  Register: 220 - d_vocm [0:5]
			g_abyTas1945Register[iIndex++] = 0x2E;		//  Register: 221 - d_chop_ref [0:5]
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 222-223 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 223

			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 224-239 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 225
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 226
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 227
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 228
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 229
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 230
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 231
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 232
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 233
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 234
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 235
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 236
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 237
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 238
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 239

			g_abyTas1945Register[iIndex++] = 0x80;		//  Register: 240 - Mixed - lsb0_sel [0:1], lsb1_sel [0:1], clkdivout_sel [0:0]
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 241-254 - spare
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 242
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 243
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 244
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 245
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 246
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 247
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 248
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 249
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 250
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 251
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 252
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 253
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 254
			g_abyTas1945Register[iIndex++] = 0x00;		//	Register: 255 - Bank_sel[0], reg_rst,
		}
	}
}

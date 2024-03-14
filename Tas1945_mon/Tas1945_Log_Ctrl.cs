using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class MainForm : Form
	{
		string	strRawLogPath = null;
		string CalSavePath = null;

		float[,]	g_asTestPixelLog;
		float[,]	g_asTestLog_pixel1;
		int			g_iTestPixelLogCnt = 0;
		int testcnt = 0;

		DirectoryInfo   dirRawLogFolder;
		DirectoryInfo CalFolder;
		StreamWriter    swCsvStreamW = null;
		StreamWriter    swTextStreamW = null;
		StreamWriter	calBufStreamW = null;

		/// <summary>
		/// 
		/// </summary>
		public void RawLog_CsvFileOpen ()
		{
			try
			{
				if (swCsvStreamW == null)
				{
					strRawLogPath = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);

					strRawLogPath = strRawLogPath + @"\PixelInfo\" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + @"\";

					dirRawLogFolder = new DirectoryInfo (strRawLogPath);

					if (dirRawLogFolder.Exists == false)
					{
						dirRawLogFolder.Create ();
					}

					swCsvStreamW = new StreamWriter (strRawLogPath + "PixelInfo_" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + ".csv");

					for (int i = 0; i < 5; i++)
					{
						swCsvStreamW.Write ("P-" + (i + 1).ToString () + ", " );
					}

					swCsvStreamW.Write ("TP, ");

					swCsvStreamW.Write ("\n");
				}
			}
			catch (Exception ex)
			{
				ERR (ex.Message);
			}
		}

		public void RawLog_CsvFileOpen(int i1, int i2, int i3, int i4, int i5)
		{
			try
			{
				if (swCsvStreamW == null)
				{
					strRawLogPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

					strRawLogPath = strRawLogPath + @"\PixelInfo\" + DateTime.Now.ToString("yyyy_MM_dd_HH_m_ss") + @"\";

					dirRawLogFolder = new DirectoryInfo(strRawLogPath);

					if (dirRawLogFolder.Exists == false)
					{
						dirRawLogFolder.Create();
					}

					swCsvStreamW = new StreamWriter(strRawLogPath + "PixelInfo_" + DateTime.Now.ToString("yyyy_MM_dd_HH_m_ss") + ".csv");

					swCsvStreamW.Write("P-" + i1.ToString() + ", ");
					swCsvStreamW.Write("P-" + i2.ToString() + ", ");
					swCsvStreamW.Write("P-" + i3.ToString() + ", ");
					swCsvStreamW.Write("P-" + i4.ToString() + ", ");
					swCsvStreamW.Write("P-" + i5.ToString() + ", ");

					swCsvStreamW.Write("TP, ");

					swCsvStreamW.Write("\n");
				}
			}
			catch (Exception ex)
			{
				ERR(ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void TestPixelLog_CsvFileOpen ()
		{
			try
			{
				if (swCsvStreamW == null)
				{
					g_asTestPixelLog = new float[(int)NUDGet (nudCsvSaveCnt), 3];

					Array.Clear (g_asTestPixelLog, 0, g_asTestPixelLog.Length);
					g_iTestPixelLogCnt = 0;

					strRawLogPath = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);

					strRawLogPath = strRawLogPath + @"\PixelInfo\" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + @"\";

					dirRawLogFolder = new DirectoryInfo (strRawLogPath);

					if (dirRawLogFolder.Exists == false)
					{
						dirRawLogFolder.Create ();
					}

					swCsvStreamW = new StreamWriter (strRawLogPath + "TestPixelInfo_" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + ".csv");

//					for (int i = 0; i < 5; i++)
//					{
//						swCsvStreamW.Write ("P-" + (i + 1).ToString () + ", " );
//					}
					swCsvStreamW.Write ("(80-0), ");
					swCsvStreamW.Write ("(80-2), ");
					swCsvStreamW.Write ("(80-59), ");

					swCsvStreamW.Write ("\n");
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
		/// <param name="strFileName"></param>
		public void RawLog_CsvFileOpen (string strFileName)
		{
			try
			{
				if (swCsvStreamW == null)
				{
					if (strRawLogPath == null)
					{ 
						strRawLogPath = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);

						strRawLogPath = strRawLogPath + @"\PixelInfo\" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + @"\";

						dirRawLogFolder = new DirectoryInfo (strRawLogPath);

						if (dirRawLogFolder.Exists == false)
						{
							dirRawLogFolder.Create ();
						}
					}

					swCsvStreamW = new StreamWriter (strRawLogPath + strFileName + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + ".csv");

					for (int i = 0; i < 5; i++)
					{
						swCsvStreamW.Write ("P-" + (i + 1).ToString () + ", " );
					}

					swCsvStreamW.Write ("\n");
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
		public void RawLog_CsvFileClose ()
		{
			try
			{
				if (swCsvStreamW != null)
				{
					swCsvStreamW.Close ();
					swCsvStreamW = null;
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
		public void TestPixelLog_CsvFileClose ()
		{
			try
			{
				if (swCsvStreamW != null)
				{
					swCsvStreamW.Close ();
					swCsvStreamW = null;
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
		/// <param name="strData"></param>
		public void RawLog_CsvFileWrite (string strData)
		{
			try
			{
				if (swCsvStreamW != null)
				{
					swCsvStreamW.Write (strData);
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
		/// <returns></returns>
		public bool RawLog_CsvIsFileOpen ()
		{
			if (swCsvStreamW != null) return true;

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		public void RawLog_TextFileOpen ()
		{
			try
			{
				if (swTextStreamW == null)
				{
					if (strRawLogPath == null)
					{
						strRawLogPath = Environment.GetFolderPath (Environment.SpecialFolder.Desktop);

						strRawLogPath = strRawLogPath + @"\PixelInfo\" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + @"\";

						dirRawLogFolder = new DirectoryInfo (strRawLogPath);

						if (dirRawLogFolder.Exists == false)
						{
							dirRawLogFolder.Create ();
						}
					}

					swTextStreamW = new StreamWriter (strRawLogPath + "PixelInfo_" + DateTime.Now.ToString ("yyyy_MM_dd_HH_m_ss") + ".txt");
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
		public void RawLog_TextFileClose ()
		{
			try
			{
				if (swTextStreamW != null)
				{
					swTextStreamW.Close ();
					swTextStreamW = null;
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
		/// <param name="strWriteData"></param>
		public void RawLog_TextFileWrite (string strWriteData)
		{
			try
			{
				if (swTextStreamW != null)
				{
					//swTextStreamW.Write (strWriteData);
					swTextStreamW.WriteLine (strWriteData);
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
		/// <returns></returns>
		public bool RawLog_TextIsFileOpen ()
		{
			if (swTextStreamW != null) return true;

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool Save_Csv ()
		{
			if (g_bCsvOn == true)				//	Save - Pixel data
			{
				if (g_iCsvSaveMode == 1)
				{
					if (g_fPixelChartForm != null)
					{
						float iP1 = Get_PixelData (g_asPixelData, g_fPixelChartForm.g_iChX[0], g_fPixelChartForm.g_iChY[0]);
						float iP2 = Get_PixelData (g_asPixelData, g_fPixelChartForm.g_iChX[1], g_fPixelChartForm.g_iChY[1]);
						float iP3 = Get_PixelData (g_asPixelData, g_fPixelChartForm.g_iChX[2], g_fPixelChartForm.g_iChY[2]);
						float iP4 = Get_PixelData (g_asPixelData, g_fPixelChartForm.g_iChX[3], g_fPixelChartForm.g_iChY[3]);
						float iP5 = Get_PixelData (g_asPixelData, g_fPixelChartForm.g_iChX[4], g_fPixelChartForm.g_iChY[4]);

						float iTP = Get_PixelData (g_asPixelData, 80, 2);

						Tas1945_PixelInfoCvsSaveInt (iP1, iP2, iP3, iP4, iP5, iTP);
					}

					//Tas1945_CvsSave (g_abyRcvData, g_iRcvSize, 11, 120);
					//Tas1945_TextSave (g_abyRcvData, g_iRcvSize, 11, g_iRcvSize - 13);
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public bool Save_TestPixelCsv ()
		{
			if (g_bCsvOn == true)
			{
				if (g_iCsvSaveMode == 0)
				{
					for (int i = 0; i < g_iTestPixelLogCnt; i++)
					{
						Tas1945_TestPixelCsvSave (g_asTestPixelLog[i, 0], g_asTestPixelLog[i, 1], g_asTestPixelLog[i, 2]);
					}
						
					Array.Clear (g_asTestPixelLog, 0, g_asTestPixelLog.Length);
					g_iTestPixelLogCnt = 0;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

			return true;
		}

		public bool Save_Test5PixelCsv()
		{
			if (g_bCsvOn == true)
			{
				if (g_iCsvSaveMode == 0)
				{
					for (int i = 0; i < g_iTestPixelLogCnt; i++)
					{
						Tas1945_TestPixelCsvSave(g_asTestPixelLog[i, 0], g_asTestPixelLog[i, 1], g_asTestPixelLog[i, 2], g_asTestPixelLog[i, 3], g_asTestPixelLog[i, 4]) ;
					}

					Array.Clear(g_asTestPixelLog, 0, g_asTestPixelLog.Length);
					g_iTestPixelLogCnt = 0;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

			return true;
		}

		public void Cal25_buf_save()
		{
			try
			{
				if (calBufStreamW == null)
				{
					CalSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

					CalSavePath = CalSavePath + @"\Cal_buf_Info\" + @"\";

					CalFolder = new DirectoryInfo(CalSavePath);

					if (CalFolder.Exists == false)
					{
						CalFolder.Create();
					}

					calBufStreamW = new StreamWriter(CalSavePath + "Cal25_buf_" + DateTime.Now.ToString("yyyy_MM_dd_HH_m_ss") + ".csv");

					for (int i = 0; i < 60; i++)
					{
						for (int j = 0; j < 81; j++)
						{
							if (j == 80)
							{
								calBufStreamW.Write(Image_buf_25C[i, j].ToString());
								break;
							}
							;
							calBufStreamW.Write(Image_buf_25C[i, j].ToString() + ", ");

						}
						if (i != 59) calBufStreamW.Write("\n");
					}
					calBufStreamW.Close();
					calBufStreamW = null;
				}
			}
			catch (Exception ex)
			{
				ERR(ex.Message);
			}
		}

		public void Cal35_buf_save()
		{
			try
			{
				if (calBufStreamW == null)
				{
					CalSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

					CalSavePath = CalSavePath + @"\Cal_buf_Info\" + @"\";

					CalFolder = new DirectoryInfo(CalSavePath);

					if (CalFolder.Exists == false)
					{
						CalFolder.Create();
					}

					calBufStreamW = new StreamWriter(CalSavePath + "Cal35_buf_" + DateTime.Now.ToString("yyyy_MM_dd_HH_m_ss") + ".csv");

					for (int i = 0; i < 60; i++)
					{
						for (int j = 0; j < 81; j++)
						{
							if (j == 80)
							{
								calBufStreamW.Write(Image_buf_35C[i, j].ToString());
								break;
							}
							;
							calBufStreamW.Write(Image_buf_35C[i, j].ToString() + ", ");

						}
						if (i != 59) calBufStreamW.Write("\n");
					}
					calBufStreamW.Close();
					calBufStreamW = null;
				}
			}
			catch (Exception ex)
			{
				ERR(ex.Message);
			}
		}

		public void Cal45_buf_save()
		{
			try
			{
				if (calBufStreamW == null)
				{
					CalSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

					CalSavePath = CalSavePath + @"\Cal_buf_Info\" + @"\";

					CalFolder = new DirectoryInfo(CalSavePath);

					if (CalFolder.Exists == false)
					{
						CalFolder.Create();
					}

					calBufStreamW = new StreamWriter(CalSavePath + "Cal45_buf_" + DateTime.Now.ToString("yyyy_MM_dd_HH_m_ss") + ".csv");

					for (int i = 0; i < 60; i++)
					{
						for (int j = 0; j < 81; j++)
						{
							if (j == 80)
							{
								calBufStreamW.Write(Image_buf_45C[i, j].ToString());
								break;
							}
							;
							calBufStreamW.Write(Image_buf_45C[i, j].ToString() + ", ");

						}
						if (i != 59) calBufStreamW.Write("\n");
					}
					calBufStreamW.Close();
					calBufStreamW = null;
				}
			}
			catch (Exception ex)
			{
				ERR(ex.Message);
			}
		}

		public void Dataverify_save(float[,] Dataverify)
        {
            try
            {
				if (calBufStreamW == null)
                {
					CalSavePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

					CalSavePath = CalSavePath + @"\Cal_buf_Info\" + @"\";

					CalFolder = new DirectoryInfo(CalSavePath);

					if (CalFolder.Exists == false)
					{
						CalFolder.Create();
					}

					calBufStreamW = new StreamWriter(CalSavePath + "DataVerify_" + DateTime.Now.ToString("yyyy_MM_dd_HH_m_ss") + ".csv");

					for(int i = 0; i < 4861; i++)
                    {
						if(i == 0)  // 첫번째 줄에 머릿말 입력 : No / Row / Col / 1~100(data 순서)
                        {
							//for (int j = 0; j < 102; j++)
       //                     {
							//	if(j==0) calBufStreamW.Write("Row(Y)" + ",");
							//	else if(j==1) calBufStreamW.Write("Col(X)" + ",");
							//	else if(j==101) calBufStreamW.Write((j-1) + "\n");
							//	else calBufStreamW.Write((j-1) + ",");
							//}

							// No를 넣기 위해 조금 변경됨 - 20240123
							for (int j = 0; j < 103; j++)
							{
								if (j == 0) calBufStreamW.Write("No" + ",");
								else if (j == 1) calBufStreamW.Write("Row(Y)" + ",");
								else if (j == 2) calBufStreamW.Write("Col(X)" + ",");
								else if (j == 102) calBufStreamW.Write((j - 2) + "\n");
								else calBufStreamW.Write((j - 2) + ",");
							}
						}
                        else
                        {
							//for (int j = 0; j < 102; j++)
							//{
							//	if (j == 0) calBufStreamW.Write(((int)(i-1) / COL) + ",");
							//	else if (j == 1) calBufStreamW.Write(((i-1) - ((int)(i-1)/COL) * COL) + ",");
							//	else if (j == 101) calBufStreamW.Write((Dataverify[j - 2, i - 1]) + "\n");
							//	else calBufStreamW.Write((Dataverify[j - 2, i - 1]) + ",");
							//}

							// No를 넣기 위해 조금 변경됨 - 20240123
							for (int j = 0; j < 103; j++)
							{
								if (j == 0) calBufStreamW.Write((i - 1) + ",");
								else if (j == 1) calBufStreamW.Write(((int)(i - 1) / COL) + ",");
								else if (j == 2) calBufStreamW.Write(((i - 1) - ((int)(i - 1) / COL) * COL) + ",");
								else if (j == 102) calBufStreamW.Write((Dataverify[j - 3, i - 1]) + "\n");
								else calBufStreamW.Write((Dataverify[j - 3, i - 1]) + ",");
							}
						}
                    }

					calBufStreamW.Close();
					calBufStreamW = null;
				}

			}
			catch (Exception ex)
            {
				ERR(ex.Message);
			}
        }
	}
}

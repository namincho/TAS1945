using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class PixelForm : Form
	{
		MainForm		g_fm;

		//DirectoryInfo dirPixelCvsFolder = new DirectoryInfo (Application.StartupPath + @"\Data");

		StreamWriter    swPixelCsvStreamW = null;

		/// <summary>
		/// 
		/// </summary>
		public PixelForm ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fm"></param>
		public PixelForm (MainForm fm)
		{
			InitializeComponent ();
			
			g_fm = fm;
		}

		/// <summary>
		/// 
		/// </summary>
		private void CvsPixelOffsetFileOpen ()
		{
			try
			{
				if (swPixelCsvStreamW == null)
				{
					if (!g_fm.dirPixelCvsFolder.Exists)
					{
						g_fm.dirPixelCvsFolder.Create ();
					}

					string	strFile = g_fm.dirPixelCvsFolder + @"\Pixel_Offset.csv";

					if (!File.Exists (strFile))
					{
						swPixelCsvStreamW = new StreamWriter (g_fm.dirPixelCvsFolder + @"\Pixel_Offset.csv");

						for (int i = 0; i < 60; i++)
						{
							swPixelCsvStreamW.Write ("0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, " +
													 "0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ");

							swPixelCsvStreamW.Write ("\n");
						}
					}
				}
			}
			catch (Exception ex)
			{
				g_fm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void CvsPixelOffsetFileClose ()
		{
			try
			{
				if (swPixelCsvStreamW != null)
				{
					swPixelCsvStreamW.Close ();
					swPixelCsvStreamW = null;
				}
			}
			catch (Exception ex)
			{
				g_fm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private bool CvsPixelOffsetFileIsOpen ()
		{
			if (swPixelCsvStreamW != null)	return	true;

			return	false;
		}

		/// <summary>
		/// 
		/// </summary>
		private void Initialize ()
		{
			try
			{
				string		strReadLine;
				string[]	strReadData, strRowData;

				StreamReader	srPixelOffset;

				strRowData = new string[81];

				CvsPixelOffsetFileOpen ();

				if (CvsPixelOffsetFileIsOpen () == true)
				{
					CvsPixelOffsetFileClose ();
				}

				Controls.Add (dgvPixelOffset);

				dgvPixelOffset.Rows.Clear ();
				
				dgvPixelOffset.ColumnCount = 81;

				dgvPixelOffset.Columns[0].Name = "Y / X";

				for (int i = 0; i < dgvPixelOffset.ColumnCount - 1; i++)
				{
					dgvPixelOffset.Columns[i + 1].Name = "X-" + i.ToString ();
					dgvPixelOffset.Columns[i + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}

				//	read 해서 grid 에 display 하고 main 에서 cvs file 있을 시 offset 적용
				srPixelOffset = new StreamReader (g_fm.dirPixelCvsFolder + @"\Pixel_Offset.csv");
				
				for (int j = 0; j < 60; j++)
				{
					strReadLine = srPixelOffset.ReadLine ();
					strReadData = strReadLine.Split (',');

					strRowData = Enumerable.Repeat<string>("0", strRowData.Length).ToArray<string>();

					strRowData[0] = "Y-" + j.ToString ();

					for (int i = 0; i < strReadData.Length; i++)
					{
						strRowData[i + 1] = strReadData[i];
					}
					
					dgvPixelOffset.Rows.Add (strRowData);

					while (srPixelOffset.EndOfStream)		break;
				}

				srPixelOffset.Close ();
				srPixelOffset = null;
			}
			catch (Exception ex)
			{
				g_fm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PixelForm_Load (object sender, EventArgs e)
		{
			Initialize ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PixelForm_FormClosed (object sender, FormClosedEventArgs e)
		{
			if (CvsPixelOffsetFileIsOpen () == true)
			{
				CvsPixelOffsetFileClose ();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPixelFormClose_Click (object sender, EventArgs e)
		{
			this.Close ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPixelOffsetSave_Click (object sender, EventArgs e)
		{
			try
			{
				string[]	strPixelOffsetData = new string[80];

				swPixelCsvStreamW = new StreamWriter (g_fm.dirPixelCvsFolder + @"\Pixel_Offset.csv");

				for (int i = 0; i < 60; i ++)
				{
					for (int j = 0; j < 80; j++)
					{ 
						strPixelOffsetData[j] = dgvPixelOffset.Rows[i].Cells[j + 1].Value.ToString ();
					}

					if (swPixelCsvStreamW != null)
					{
						string		strCsvData = string.Join(",", strPixelOffsetData);
						swPixelCsvStreamW.WriteLine (strCsvData);
					}
					else
					{
						g_fm.ERR ("CVS file not opened !!!");
					}
				}

				if (swPixelCsvStreamW != null)
				{
					swPixelCsvStreamW.Close ();
					swPixelCsvStreamW = null;
				}

				g_fm.Read_PixelOffset ();
			}
			catch (Exception ex)
			{
				g_fm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvPixelOffset_CellValueChanged (object sender, DataGridViewCellEventArgs e)
		{
			try
			{	
				if (e.ColumnIndex == 0)		return;

				int iResult = g_fm.StringToInt (dgvPixelOffset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString ());
				if (iResult > 65535 || iResult < -65535)
				{
					dgvPixelOffset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
				}
				else
				{
					dgvPixelOffset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = iResult.ToString ();
				}

				g_fm.TBSet (tbPosXY, e.RowIndex.ToString () + ", " + e.ColumnIndex.ToString ());
				g_fm.TBSet (tbPixelOffset, dgvPixelOffset.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString ());			
			}
			catch (Exception)
			{
				//g_fm.ERR (ex.Message);
			}
		}

		private void btnPixelOffsetZero_Click (object sender, EventArgs e)
		{

		}
	}
}

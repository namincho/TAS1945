using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class Tas1945_Uc_RawPixels : UserControl
	{
		private	MainForm	g_fMainForm;

		public Graphics		g_Graphics;

		private Cinema		g_Cinema = new Cinema();

		public ushort[]		g_ausPixelValue = new ushort[4860];		//	X, Y position pixel value
		public float[]		g_asPixelValue = new float[4860];		//	X, Y position pixel value

		/// <summary>
		/// 
		/// </summary>
		public Tas1945_Uc_RawPixels ()	
		{
			InitializeComponent ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fMainForm"></param>
		public Tas1945_Uc_RawPixels (MainForm fMainForm)
		{
			InitializeComponent ();

			g_fMainForm = fMainForm;

			g_Graphics = panPixels.CreateGraphics();

			ClearPixels ();

			Array.Clear (g_Cinema.g_abyColor, 0, g_Cinema.g_abyColor.Length);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyRcvData"></param>
		/// <param name="iRcvLength"></param>
		public void CreatePixels (float[] asPixelData, int iPixelDataLength)
		{
			try
			{				
				double      dbVal;
				decimal decMinVal = g_fMainForm.NUDGet (g_fMainForm.nudMinVal);				
				decimal decMaxVal = g_fMainForm.NUDGet (g_fMainForm.nudMaxVal);

				g_fMainForm.g_dbPixelAvrage = 0;

				for (int y = 0; y < 60; y++)					//	y
				{
					for (int x = 0; x < 81; x++)			//	x = 80 or 81
					{
						dbVal = (double)g_fMainForm.Get_PixelData (asPixelData, x, y);

						g_fMainForm.g_dbPixelAvrage += dbVal;

						g_asPixelValue[(y * 81) + x] = (float)dbVal;

						g_Cinema.g_dbSeats[y, x] = (dbVal - (int)decMinVal) / (int)(decMaxVal - decMinVal);
						//g_Cinema.g_dbSeats[y, x] = dbVal / 65535.0;
						//g_Cinema.g_dbSeats[iRow, iCol] = (dbVal - g_fMainForm.g_dbMinScale) / (g_fMainForm.g_dbMaxScale - g_fMainForm.g_dbMinScale) + 0.5F;
					}
				}
					
				g_fMainForm.g_dbPixelAvrage /= (81 * 60);

				g_Cinema.Draw (g_Graphics, (int)g_fMainForm.NUDGet (g_fMainForm.nudPixelSpace));
			}
			//catch (Exception ex)
			catch (Exception)
			{
				;//g_fMainForm.ERR (ex.Message);
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public void ClearPixels ()
		{
			try
			{
				//g_Graphics.Clear (Color.White);
				panPixels.Refresh ();
				Array.Clear (g_Cinema.g_abyColor, 0, g_Cinema.g_abyColor.Length);
				//g_Cinema.Clear (panPixels.CreateGraphics());
			}
			catch (Exception ex)
			{
				g_fMainForm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void GetPanelPixelValue (int x, int y)
		{
			float sValue;

			try
			{
				if ((x <= 81 * 10) && (y <= 60 * 10))
				{
					if (g_fMainForm.g_fPixelChartForm != null)
					{
						if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel2) == true)
						{
							g_fMainForm.g_fPixelChartForm.g_iChX[1] = x / 10;
							g_fMainForm.g_fPixelChartForm.g_iChY[1] = y / 10;
						}
						else if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel3) == true)
						{
							g_fMainForm.g_fPixelChartForm.g_iChX[2] = x / 10;
							g_fMainForm.g_fPixelChartForm.g_iChY[2] = y / 10;
						}
						else if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel4) == true)
						{
							g_fMainForm.g_fPixelChartForm.g_iChX[3] = x / 10;
							g_fMainForm.g_fPixelChartForm.g_iChY[3] = y / 10;
						}
						else if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel5) == true)
						{
							g_fMainForm.g_fPixelChartForm.g_iChX[4] = x / 10;
							g_fMainForm.g_fPixelChartForm.g_iChY[4] = y / 10;
						}
						else
						{
							g_fMainForm.g_fPixelChartForm.g_iChX[0] = x / 10;
							g_fMainForm.g_fPixelChartForm.g_iChY[0] = y / 10;
						}
					}

					sValue = g_asPixelValue[(y / 10 * 81) + x / 10];



					g_fMainForm.LOG ("Pixel (x, y, value, R, G, B) : "  + (x / 10).ToString () + ", " 
																		+ (y / 10).ToString () + ", " 
																		+ sValue.ToString () + ", "
																		+ g_Cinema.g_abyColor[((y / 10) * 81) + (x / 10), 0].ToString () + ", " 
																		+ g_Cinema.g_abyColor[((y / 10) * 81) + (x / 10), 1].ToString () + ", " 
																		+ g_Cinema.g_abyColor[((y / 10) * 81) + (x / 10), 2].ToString (), Color.Blue);

					g_fMainForm.TBSet (g_fMainForm.tbPixelX, (x / 10).ToString ());
					g_fMainForm.TBSet (g_fMainForm.tbPixelY, (y / 10).ToString ());
					g_fMainForm.TBSet (g_fMainForm.tbPixelValue, sValue.ToString ());
					
					//	if (g_fMainForm.RBGet (g_fMainForm.rbRefOffset) == true)	
					//	{
					//		g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_asOffPixelData, x / 10, y / 10).ToString ()); 
					//	}
					//	else if (g_fMainForm.RBGet (g_fMainForm.rbDark_X_Offset) == true || g_fMainForm.RBGet (g_fMainForm.rbDark_Y_Offset) == true)
					//	{
					//		if (g_fMainForm.RBGet (g_fMainForm.rbDark_X_Offset) == true)
					//		{
					//			g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_aiDarkX_PixelOffset, x / 10, y / 10).ToString ());
					//		}
					//		else
					//		{
					//			g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_aiDarkY_PixelOffset, x / 10, y / 10).ToString ());
					//		}
					//	}		
					//	else if (g_fMainForm.RBGet (g_fMainForm.rbAvrOffset) == true)
					//	{
					//		g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_asOffAvrData, x / 10, y / 10).ToString ());
					//	}

					g_fMainForm.TBSet (g_fMainForm.tbPixelRGB,	g_Cinema.g_abyColor[((y / 10) * 81) + (x / 10), 0].ToString () + ", " + 
																g_Cinema.g_abyColor[((y / 10) * 81) + (x / 10), 1].ToString () + ", " + 
																g_Cinema.g_abyColor[((y / 10) * 81) + (x / 10), 2].ToString ());
				}
				else
				{
					g_fMainForm.ERR ("Pixel Position Error (81 * 60) : "	+ (x / 10).ToString () + ", " 
																			+ (y / 10).ToString ());
				}
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
		private void panPixels_MouseDown (object sender, MouseEventArgs e)
		{
			try
			{
				GetPanelPixelValue (e.X, e.Y);
			}
			catch (Exception)
			{
				;
			}
		}
	}
}

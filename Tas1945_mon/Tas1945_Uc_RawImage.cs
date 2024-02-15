using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class Tas1945_Uc_RawImage : UserControl
	{
		private MainForm	g_fMainForm;

		ushort[]    g_u16ImageValue = new ushort[4860]; //	X, Y position pixel value
		float[]		g_s16ImageValue = new float[4860]; //	X, Y position pixel value

		public int	g_iZoom = 1;

		Graphics	g_gGraphics = null;                 //	Graphics of the panel object
		Bitmap		g_bmBitmap = null;					//	Bitmap object

		/// <summary>
		/// 
		/// </summary>
		public Tas1945_Uc_RawImage (MainForm mf)
		{
			InitializeComponent ();

			g_fMainForm = mf;

			g_gGraphics = panRawImage.CreateGraphics ();
		}

/*		/// <summary>
		/// 화면 갱신 플리커 해결(ㅡㅡ) - 효과 없다.
		/// </summary>
		protected override CreateParams CreateParams 
		{
			get {
				var cp = base.CreateParams;
				cp.ExStyle |= 0x2000000;
				return cp;
			}
		}
*/

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyArrayData"></param>
		/// <param name="iArrayLength"></param>
		public void CreateColorBitmapZoom (float[] asArrayData, int iArrayLength)
		{
			try
			{
				g_bmBitmap = new Bitmap (81 * g_iZoom, 60 * g_iZoom, PixelFormat.Format24bppRgb);

				BitmapData bmBitMapData = g_bmBitmap.LockBits (new Rectangle(0, 0, 81 * g_iZoom, 60 * g_iZoom), ImageLockMode.ReadOnly, g_bmBitmap.PixelFormat);

				// This 'unsafe' part of the code populates the bitmap bmp with data stored in pixel16.
				// It does so using pointers, and therefore the need for 'unsafe'. 
				unsafe
				{
					int         iPixelSize = 3;
					int         iRow, iCol, iSaveCol; 
					float		s16Val;

					Int32 uiColor_R = 0, uiColor_G = 0, uiColor_B = 255;
					double dbVal, dbSeat;
					
					decimal decMinVal = g_fMainForm.NUDGet (g_fMainForm.nudMinVal);
					decimal decMaxVal = g_fMainForm.NUDGet (g_fMainForm.nudMaxVal);

					for (iRow = 0; iRow < bmBitMapData.Height; iRow += g_iZoom)
					{
						for (iCol = 0; iCol < bmBitMapData.Width; iCol += g_iZoom)
						{
							dbVal = (double)g_fMainForm.Get_PixelData (asArrayData, iCol / g_iZoom, iRow / g_iZoom);

							dbSeat = (dbVal - (int)decMinVal) / (int)(decMaxVal - decMinVal);

							if (dbSeat < 0.0)      dbSeat = 0.0;
							if (dbSeat > 1.0)      dbSeat = 1.0;

							// BookMark #7 : 비트맵 이미지에 칼라 공식 부분
							// 칼라 표현 원본
							/*uiColor_R = (Int32)(255.0 * Math.Sqrt (Math.Sin ((dbSeat * 3.141592) / 2)));
							uiColor_G = (Int32)(255.0 * dbSeat * dbSeat);
							if (dbSeat < 0.5)	uiColor_B = (Int32)(160.0 * Math.Sin(dbSeat * 2.0 * 3.141592));
							else				uiColor_B = (Int32)(255.0 * (2 * (dbSeat - 0.5)) * (2 * (dbSeat - 0.5)));
							*/
							
							// 칼라 표현 박사님 추가본 - 20240114
							uiColor_R = (Int32)((43.144*Math.Pow(dbSeat,6)-154.96*Math.Pow(dbSeat,5)+216.62*Math.Pow(dbSeat,4)-145.47* Math.Pow(dbSeat, 3)+44.483 * Math.Pow(dbSeat, 2) - 2.8428 * dbSeat+0.0235)*255);
							uiColor_G = (Int32)((-2.5295 * Math.Pow(dbSeat, 3) + 4.758 * Math.Pow(dbSeat, 2) - 1.2734* dbSeat + 0.0509)*255);
							if (dbSeat > 0.75) uiColor_B = (Int32)((12.48*dbSeat*dbSeat-18.686*dbSeat+6.9931)*255);
							else uiColor_B = (Int32)((-3.6076*Math.Pow(dbSeat,4)+17.728*Math.Pow(dbSeat,3)-19.358*dbSeat*dbSeat+5.9906*dbSeat+0.0388)*255);
							
							if (uiColor_R < 0)    uiColor_R = 0;
							if (uiColor_R > 255)  uiColor_R = 255;
							if (uiColor_G < 0)    uiColor_G = 0;
							if (uiColor_G > 255)  uiColor_G = 255;
							if (uiColor_B < 0)    uiColor_B = 0;
							if (uiColor_B > 255)  uiColor_B = 255;

							s16Val = (float)g_fMainForm.Get_PixelData (asArrayData, iCol / g_iZoom, iRow / g_iZoom);

							g_s16ImageValue[(81 * (iRow / g_iZoom)) + (iCol / g_iZoom)] = s16Val;

							iSaveCol = iCol * iPixelSize;

							for (int i  = 0; i < g_iZoom; i++)
							{
								byte *pbyRow = (byte *)bmBitMapData.Scan0 + ((iRow + i) * bmBitMapData.Stride);
								
								for (int j = 0; j < g_iZoom; j++)
								{
									pbyRow[iSaveCol + 0 + (3 * j)]	= (byte)uiColor_B;		//	Blue
									pbyRow[iSaveCol + 1 + (3 * j)]	= (byte)uiColor_G;		//	Green
									pbyRow[iSaveCol + 2 + (3 * j)]	= (byte)uiColor_R;		//	Red
								}
							}
						}
					}
				}

				g_bmBitmap.UnlockBits (bmBitMapData);

				//	이미지 테두리 주위의 고 스팅을 방지합니다.
				//using (var wrapMode = new ImageAttributes ())
				//{
				//	wrapMode.SetWrapMode (WrapMode.TileFlipXY);
				//	
				//	if (g_iZoom == 1)		//	원본 비율 x1 or x10
				//	{
				//		var varDestRect = new Rectangle (0, 0, 81, 60);
				//		//g_gGraphics.DrawImage (g_bmBitmap, varDestRect, 0, 0, 81, 60, GraphicsUnit.Pixel, wrapMode);
				//
				//		pbRawImage.Image = g_bmBitmap;
				//	}
				//	else
				//	{
				//		var varDestRect = new Rectangle (0, 0, 810, 600);
				//		//g_gGraphics.DrawImage (g_bmBitmap, varDestRect, 0, 0, 81, 60, GraphicsUnit.Pixel, wrapMode);
				//
				//		Bitmap bmResize = new Bitmap (g_bmBitmap, new Size (810, 600));
				//		pbRawImage.Image = bmResize;
				//	}
				//	
				//	//Invalidate ();
				//}

				if (pbRawImage.InvokeRequired) 
				{ 
					pbRawImage.Invoke (new MethodInvoker (delegate () { pbRawImage.Image = g_bmBitmap; })); 
				}
                else 
				{ 
					pbRawImage.Image = g_bmBitmap; 
				}
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
		public void ClearBitmap ()
		{
			try
			{
				if (pbRawImage.InvokeRequired) 
				{ 
					pbRawImage.Invoke (new MethodInvoker (delegate () { pbRawImage.Image = null; })); 
				}
                else 
				{ 
					pbRawImage.Image = null; 
				}
			}
			catch (Exception)
			{
				;
			}
		}

		/// <summary>
		/// Image 를 80x60 을 800x600 으로 변경 하였기 때문에 1 Piexe 의 크기가 x10 되었으며, 이에 따라 X, Y 축 좌표도 /10 이 되어야 한다.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void GetPanelBitmapValue (int x, int y)
		{		
			float s16Value = 0;

			try
			{
				Color	cColor = Color.FromKnownColor (KnownColor.Control);

				if (pbRawImage.Image == null)	return;

				if (g_fMainForm.g_fPixelChartForm != null)
				{
					//int iMagnification = 1;

					if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel2) == true)
					{
						g_fMainForm.g_fPixelChartForm.g_iChX[1] = x / g_iZoom;
						g_fMainForm.g_fPixelChartForm.g_iChY[1] = y / g_iZoom;
					}
					else if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel3) == true)
					{
						g_fMainForm.g_fPixelChartForm.g_iChX[2] = x / g_iZoom;
						g_fMainForm.g_fPixelChartForm.g_iChY[2] = y / g_iZoom;
					}
					else if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel4) == true)
					{
						g_fMainForm.g_fPixelChartForm.g_iChX[3] = x / g_iZoom;
						g_fMainForm.g_fPixelChartForm.g_iChY[3] = y / g_iZoom;
					}
					else if (g_fMainForm.RBGet (g_fMainForm.rbSetPixel5) == true)
					{
						g_fMainForm.g_fPixelChartForm.g_iChX[4] = x / g_iZoom;
						g_fMainForm.g_fPixelChartForm.g_iChY[4] = y / g_iZoom;
					}
					else
					{
						g_fMainForm.g_fPixelChartForm.g_iChX[0] = x / g_iZoom;
						g_fMainForm.g_fPixelChartForm.g_iChY[0] = y / g_iZoom;
					}
				}

				if ((x <= 81 * g_iZoom) && (y <= 60 * g_iZoom))
				{
					cColor = g_bmBitmap.GetPixel (x, y);

					s16Value = g_s16ImageValue[((y / g_iZoom) * 81) + (x / g_iZoom)];

					g_fMainForm.LOG ("Pixel (x, y, value, R, G, B) : "  + (x / g_iZoom).ToString () + ", " 
																		+ (y / g_iZoom).ToString () + ", " 
																		+ s16Value.ToString () + ", "
																		+ cColor.R.ToString () + ", " 
																		+ cColor.G.ToString () + ", " 
																		+ cColor.B.ToString (), Color.Blue);

					g_fMainForm.TBSet (g_fMainForm.tbPixelX, (x / g_iZoom).ToString ());
					g_fMainForm.TBSet (g_fMainForm.tbPixelY, (y / g_iZoom).ToString ());
					
					g_fMainForm.TBSet (g_fMainForm.tbPixelValue, s16Value.ToString ());

					//if (g_fMainForm.RBGet (g_fMainForm.rbRefOffset) == true)	
					//{
					//	g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_asOffPixelData, x / g_iZoom, y / g_iZoom).ToString ()); 
					//}
					//else if (g_fMainForm.RBGet (g_fMainForm.rbDark_X_Offset) == true || g_fMainForm.RBGet (g_fMainForm.rbDark_Y_Offset) == true)
					//{
					//	if (g_fMainForm.RBGet (g_fMainForm.rbDark_X_Offset) == true)
					//	{
					//		g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_aiDarkX_PixelOffset, x / g_iZoom, y / g_iZoom).ToString ());
					//	}
					//	else
					//	{
					//		g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_aiDarkY_PixelOffset, x / g_iZoom, y / g_iZoom).ToString ());
					//	}
					//}		
					//else if (g_fMainForm.RBGet (g_fMainForm.rbAvrOffset) == true)
					//{
					//	g_fMainForm.TBSet (g_fMainForm.tbPixelOffset, g_fMainForm.Get_PixelData (g_fMainForm.g_asOffAvrData, x / g_iZoom, y / g_iZoom).ToString ());
					//}

					g_fMainForm.TBSet (g_fMainForm.tbPixelRGB, cColor.R.ToString () + ", " + cColor.G.ToString () + ", " + cColor.B.ToString ());
				}
				else
				{
					g_fMainForm.ERR ("Pixel Position Error (81 * 60) : "	+ (x / g_iZoom).ToString () + ", " 
																			+ (y / g_iZoom).ToString ());
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
		/// <param name="bOriginal"></param>
		public void SetImageSize (bool bOriginal)
		{
			try
			{
				if (bOriginal == true)
				{
					g_iZoom = 1;
				}
				else
				{
					g_iZoom = 10;
				}

				if ((g_gGraphics != null) && (g_bmBitmap != null))
				{
					g_gGraphics.Clear (Color.FromKnownColor (KnownColor.Control));

					g_gGraphics.DrawImage (g_bmBitmap, 0, 0, 81 * g_iZoom, 60 * g_iZoom);
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
		public void ImageRefresh ()
		{
			try
			{
				if ((g_gGraphics != null) && (g_bmBitmap != null))
				{
					g_gGraphics.DrawImage (g_bmBitmap, 0, 0, 81 * g_iZoom, 60 * g_iZoom);		//	원본 비율 x1 or x10
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
		private void panRawImage_MouseDown (object sender, MouseEventArgs e)
		{
			try
			{
				GetPanelBitmapValue (e.X, e.Y);
			}
			catch (Exception)
			{
				;
			}
		}
	}
}

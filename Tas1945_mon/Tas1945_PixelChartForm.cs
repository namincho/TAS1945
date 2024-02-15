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
using System.Windows.Forms.DataVisualization.Charting;

namespace Tas1945_mon
{
	public partial class Tas1945_PixelChartForm : Form
	{
		MainForm g_fMainForm = null;

		public Series	g_srChartCh1 = new Series ();
		public Series	g_srChartCh2 = new Series ();
		public Series	g_srChartCh3 = new Series ();
		public Series	g_srChartCh4 = new Series ();
		public Series	g_srChartCh5 = new Series ();
		public Series	g_srChartTP = new Series ();

		public int[] g_iChX = new int [50];
		public int[] g_iChY = new int [50];
		public int g_iChCount = 0;

		/// <summary>
		/// 
		/// </summary>
		public Tas1945_PixelChartForm ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="mf"></param>
		public Tas1945_PixelChartForm (MainForm mf)
		{
			InitializeComponent ();

			this.g_fMainForm = mf;

			/*
			this.Controls.Clear ();
			this.Controls.Add (splitContainerChartVertical);
			splitContainerChartVertical.Dock = DockStyle.Fill;

            splitContainerChartVertical.Orientation = Orientation.Vertical;
            splitContainerChartVertical.SplitterDistance = splitContainerChartVertical.Size.Width / 2;
            splitContainerChartVertical.Panel1.Controls.Add(chPixel);
			chPixel.Dock = DockStyle.Fill;
			*/

			chPixel.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsShowChart1_CheckedChanged (object sender, EventArgs e)
		{
			g_srChartCh1.Enabled = tgsShowPixel1.Checked;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsShowChart2_CheckedChanged (object sender, EventArgs e)
		{
			g_srChartCh2.Enabled = tgsShowPixel2.Checked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsShowChart3_CheckedChanged (object sender, EventArgs e)
		{
			g_srChartCh3.Enabled = tgsShowPixel3.Checked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsShowChart4_CheckedChanged (object sender, EventArgs e)
		{
			g_srChartCh4.Enabled = tgsShowPixel4.Checked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsShowChart5_CheckedChanged (object sender, EventArgs e)
		{
			g_srChartCh5.Enabled = tgsShowPixel5.Checked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tgsShowPixelTP_CheckedChanged (object sender, EventArgs e)
		{
			g_srChartTP.Enabled = tgsShowPixelTP.Checked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PixelGraph_Load (object sender, EventArgs e)
		{
			ChartInit ();

			chPixel.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
//			chPixel.MouseWheel += ChPixel_MouseWheel;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception cref="NotImplementedException"></exception>
//		private void ChPixel_MouseWheel (object sender, MouseEventArgs e)
//		{
//			throw new NotImplementedException ();
//		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PixelGraph_FormClosed (object sender, FormClosedEventArgs e)
		{
			g_fMainForm.g_fPixelChartForm = null;

			g_fMainForm.rbSetPixel1.Enabled = false;
			g_fMainForm.rbSetPixel2.Enabled = false;
			g_fMainForm.rbSetPixel3.Enabled = false;
			g_fMainForm.rbSetPixel4.Enabled = false;
			g_fMainForm.rbSetPixel5.Enabled = false;
			g_fMainForm.btnChartClear.Enabled = false;
			g_fMainForm.btnPixelChartShow.Enabled = true;
		}

		/// <summary>
		/// 
		/// </summary>
		private void ChartInit ()
		{
			try
			{
				g_srChartCh1 = chPixel.Series.Add ("CH1");
				g_srChartCh2 = chPixel.Series.Add ("CH2");
				g_srChartCh3 = chPixel.Series.Add ("CH3");
				g_srChartCh4 = chPixel.Series.Add ("CH4");
				g_srChartCh5 = chPixel.Series.Add ("CH5");
				g_srChartTP = chPixel.Series.Add ("TP");

				g_srChartCh1.ChartType = SeriesChartType.Line;
				g_srChartCh1.Color = Color.Red;

				g_srChartCh2.ChartType = SeriesChartType.Line;
				g_srChartCh2.Color = Color.Blue;

				g_srChartCh3.ChartType = SeriesChartType.Line;
				g_srChartCh3.Color = Color.Green;

				g_srChartCh4.ChartType = SeriesChartType.Line;
				g_srChartCh4.Color = Color.Orange;

				g_srChartCh5.ChartType = SeriesChartType.Line;
				g_srChartCh5.Color = Color.Black;

				g_srChartTP.ChartType = SeriesChartType.Line;
				g_srChartTP.Color = Color.DeepPink;

				tgsShowPixel1.Checked = true;
				g_srChartCh1.Enabled = true;

				tgsShowPixel2.Checked = true;
				g_srChartCh2.Enabled = true;

				tgsShowPixel3.Checked = true;
				g_srChartCh3.Enabled = true;

				tgsShowPixel4.Checked = true;
				g_srChartCh4.Enabled = true;

				tgsShowPixel5.Checked = true;
				g_srChartCh5.Enabled = true;

				tgsShowPixelTP.Checked = true;
				g_srChartTP.Enabled = true;

				//chPixel.ChartAreas[0].AxisX.IntervalOffset = chPixel.ChartAreas[0].AxisX.Maximum - (int)g_fMainForm.NUDGet (nudChartLimit);

				chPixel.ChartAreas[0].AxisY.IsStartedFromZero = false;

				//chPixel.ChartAreas[0].AxisY.Maximum = g_fMainForm.g_dbMaxScale;
				//chPixel.ChartAreas[0].AxisY.Minimum = g_fMainForm.g_dbMinScale;
				
				g_srChartCh1.Enabled = true;
			}
			catch (Exception ex)
			{
				g_fMainForm.ERR (ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Clear_PixelChart ()
		{
			g_srChartCh1.Points.Clear ();
			g_srChartCh2.Points.Clear ();
			g_srChartCh3.Points.Clear ();
			g_srChartCh4.Points.Clear ();
			g_srChartCh5.Points.Clear ();
			g_srChartTP.Points.Clear ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClear_Click (object sender, EventArgs e)
		{
			Clear_PixelChart ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ch"></param>
		/// <param name="series"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void ChartSet (Chart ch, Series series, double x, double y)
		{
			try
			{
				if (ch.InvokeRequired)
				{
					ch.Invoke(new MethodInvoker(delegate ()
					{
						try
						{
							series.Points.AddXY(x, y);
							ch.Invalidate();
						}
						catch (Exception ex)
						{
							g_fMainForm.ERR(ex.Message + '\n');
						}
					}));
				}
				else
				{
					try
					{
						series.Points.AddXY(x, y);
						ch.Invalidate();
					}
					catch (Exception ex)
					{
						g_fMainForm.ERR(ex.Message + '\n');
					}
				}
			}
			catch (Exception ex)
			{
				g_fMainForm.ERR(ex.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click (object sender, EventArgs e)
		{
			this.Close ();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyRcvData"></param>
		/// <param name="iRcvLength"></param>
		public void Chart_Update (float[] asPixelData, int iPixelDataLength)
		{
			float iPixelData = 0;
			uint[] uiPx = new uint[6];
			float[] iPx = new float[6];
			int x, y; 

			try
			{
				//Thread.Sleep (10);

				if (g_fMainForm.g_fPixelChartForm != null)
				{
					//	Position 0
					x = g_iChX[0];
					g_fMainForm.TBSet (tbChart1X, x.ToString ());

					y = g_iChY[0];
					g_fMainForm.TBSet (tbChart1Y, y.ToString ());

					iPixelData = g_fMainForm.Get_PixelData (asPixelData, x, y);

					g_fMainForm.TBSet (tbChart1Value, ((float)iPixelData).ToString ());
						
					ChartSet (chPixel, g_srChartCh1, 0, (float)iPixelData);

					iPx[0] = (float)iPixelData;

					//	Position 1
					x = g_iChX[1];
					g_fMainForm.TBSet (tbChart2X, x.ToString ());

					y = g_iChY[1];
					g_fMainForm.TBSet (tbChart2Y, y.ToString ());

					iPixelData = g_fMainForm.Get_PixelData (asPixelData, x, y);

					g_fMainForm.TBSet (tbChart2Value, ((float)iPixelData).ToString ());

					ChartSet (chPixel, g_srChartCh2, 0, (float)iPixelData);
					
					iPx[1] = (float)iPixelData;

					//	Position 2
					x = g_iChX[2];
					g_fMainForm.TBSet (tbChart3X, x.ToString ());

					y = g_iChY[2];
					g_fMainForm.TBSet (tbChart3Y, y.ToString ());

					iPixelData = g_fMainForm.Get_PixelData (asPixelData, x, y);

					g_fMainForm.TBSet (tbChart3Value, ((float)iPixelData).ToString ());

					ChartSet (chPixel, g_srChartCh3, 0, (float)iPixelData);

					iPx[2] = (float)iPixelData;

					//	Position 3
					x = g_iChX[3];
					g_fMainForm.TBSet (tbChart4X, x.ToString ());

					y = g_iChY[3];
					g_fMainForm.TBSet (tbChart4Y, y.ToString ());

					iPixelData = g_fMainForm.Get_PixelData (asPixelData, x, y);

					g_fMainForm.TBSet (tbChart4Value, ((float)iPixelData).ToString ());

					ChartSet (chPixel, g_srChartCh4, 0, (float)iPixelData);

					iPx[3] = (float)iPixelData;

					//	Position 4
					x = g_iChX[4];
					g_fMainForm.TBSet (tbChart5X, x.ToString ());

					y = g_iChY[4];
					g_fMainForm.TBSet (tbChart5Y, y.ToString ());

					iPixelData = g_fMainForm.Get_PixelData (asPixelData, x, y);

					g_fMainForm.TBSet (tbChart5Value, ((float)iPixelData).ToString ());

					ChartSet (chPixel, g_srChartCh5, 0, (float)iPixelData);

					iPx[4] = (float)iPixelData;

					//	Position TP
					x = 80;
					g_fMainForm.TBSet (tbChartTPX, x.ToString ());

					y = 2;
					g_fMainForm.TBSet (tbChartTPY, y.ToString ());

					iPixelData = g_fMainForm.Get_PixelData (asPixelData, x, y);

					g_fMainForm.TBSet (tbChartTPValue, ((float)iPixelData).ToString ());

					ChartSet (chPixel, g_srChartTP, 0, (float)iPixelData);

					iPx[5] = (float)iPixelData;
					
					if (g_fMainForm.TGSGet (g_fMainForm.tgsChartLog) == true)
					{
						g_fMainForm.LOG ("Px : " + iPx[0].ToString () + ", " 
													+ iPx[1].ToString () + ", "
													+ iPx[2].ToString () + ", "
													+ iPx[3].ToString () + ", "
													+ iPx[4].ToString () + ", "
													+ iPx[5].ToString () + "(TP)");
					}

					if (chPixel.InvokeRequired)
					{
						chPixel.Invoke(new MethodInvoker(delegate ()
						{
							try
							{
								if (chPixel.ChartAreas[0].AxisX.Maximum > (double)g_fMainForm.NUDGet (nudChartMax))
								{
									Clear_PixelChart ();
								}

								if (g_fMainForm.CBGet (cbChartRange) == true)
								{
									if (chPixel.ChartAreas[0].AxisX.Maximum > (int)g_fMainForm.NUDGet (nudChartLimit))
									{
										chPixel.ChartAreas[0].AxisX.Minimum = chPixel.ChartAreas[0].AxisX.Maximum - (int)g_fMainForm.NUDGet (nudChartLimit);
									}
									else
									{
										chPixel.ChartAreas[0].AxisX.Minimum = 0;
									}
								}
								else
								{
									chPixel.ChartAreas[0].AxisX.Minimum = 0;
								}
							}
							catch (Exception ex)
							{
								g_fMainForm.ERR(ex.Message + '\n');
							}
						}));
					}
					else
					{
						try
						{
							if (chPixel.ChartAreas[0].AxisX.Maximum > (double)g_fMainForm.NUDGet (nudChartMax))
							{
								Clear_PixelChart ();
							}

							if (g_fMainForm.CBGet (cbChartRange) == true)
							{
								if (chPixel.ChartAreas[0].AxisX.Maximum > (int)g_fMainForm.NUDGet (nudChartLimit))
								{
									chPixel.ChartAreas[0].AxisX.Minimum = chPixel.ChartAreas[0].AxisX.Maximum - (int)g_fMainForm.NUDGet (nudChartLimit);
								}
								else
								{
									chPixel.ChartAreas[0].AxisX.Minimum = 0;
								}
							}
							else
							{
								chPixel.ChartAreas[0].AxisX.Minimum = 0;
							}
						}
						catch (Exception ex)
						{
							g_fMainForm.ERR(ex.Message + '\n');
						}
					}
				}
			}
			catch (Exception ex)
			{
				g_fMainForm.ERR (ex.Message);
			}
		}

        private void btnChart_ScaleSet_Click(object sender, EventArgs e)
        {
			// 사용자가 입력한 최대 및 최소 Y값을 가져옴
			if (double.TryParse(tbChart_MaxScale.Text, out double maxY) && double.TryParse(tbChart_MinScale.Text, out double minY))
			{
				// Y축 스케일 설정
				chPixel.ChartAreas[0].AxisY.Minimum = minY;
				chPixel.ChartAreas[0].AxisY.Maximum = maxY;

				// 차트 업데이트 (선택적으로 필요할 수 있음)
				//chPixel.Update();
			}
			else
			{
				MessageBox.Show("유효한 숫자를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnChart_ScaleInit_Click(object sender, EventArgs e)
        {
			// Y축 스케일 초기화
			chPixel.ChartAreas[0].AxisY.Minimum = double.NaN;
			chPixel.ChartAreas[0].AxisY.Maximum = double.NaN;

			// 차트 업데이트 (선택적으로 필요할 수 있음)
			chPixel.Update();
		}
    }
}

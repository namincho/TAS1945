//#define CHART_ENABLED

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
    public partial class MainForm : Form
    {
        /*
         * Check Box Check Set
         */
        public void CBSet(CheckBox cb, bool set)
        {
            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { cb.Checked = set; })); }
                else { cb.Checked = set; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Check Box Check Get
         */
        public bool CBGet(CheckBox cb)
        {
            bool set = false;

            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { set = cb.Checked; })); }
                else { set = cb.Checked; }

                return set;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return set;
            }
        }

        /*
         * Check Box Text/Check Set
         */
        public void CBTextSet(CheckBox cb, bool set, string str)
        {
            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { cb.Checked = set; cb.Text = str; })); }
                else { cb.Checked = set; cb.Text = str; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Check Box Text Set
         */
        public void CBTextSet(CheckBox cb, string str)
        {
            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { cb.Text = str; })); }
                else { cb.Text = str; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Text Box Text Set
         */
        public void TBSet(TextBox tb, string str)
        {
            try
            {
                if (tb.InvokeRequired) { tb.Invoke(new MethodInvoker(delegate () { tb.Text = str; })); }
                else { tb.Text = str; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Text Box BG Color Set
         */
        public void TBSetBgColor(TextBox tb, Color bgColor)
        {
            try
            {
                if (tb.InvokeRequired) { tb.Invoke(new MethodInvoker(delegate () { tb.BackColor = bgColor; })); }
                else { tb.BackColor = bgColor; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Text Box Text Get
         */
        public string TBGet(TextBox tb)
        {
            string str = "";

            try
            {
                if (tb.InvokeRequired) { tb.Invoke(new MethodInvoker(delegate () { str = tb.Text; })); }
                else { str = tb.Text; }

                return str;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return str;
            }
        }

        /*
         * Text Box Text Get UINT32 with NULL check
         */
        public UInt32 TextBoxGetUInt32(TextBox tb)
        {
            string str = "";

            try
            {
                if (tb.InvokeRequired)
                {
                    tb.Invoke(new MethodInvoker(delegate ()
                    {
                        if (string.IsNullOrWhiteSpace(tb.Text)) { str = "0"; MessageBox.Show("TextBox is empty"); }
                        else { str = tb.Text; }
                    }));
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(tb.Text)) { str = "0"; MessageBox.Show("TextBox is empty"); }
                    else { str = tb.Text; }
                }

                return Convert.ToUInt32(str);
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return 0;
            }
        }

        /*
         * Text Box Text Get UINT16 with NULL check
         */
        public UInt16 TextBoxGetUInt16(TextBox tb)
        {
            string str = "";

            try
            {
                if (tb.InvokeRequired)
                {
                    tb.Invoke(new MethodInvoker(delegate ()
                    {
                        if (string.IsNullOrWhiteSpace(tb.Text)) { str = "0"; MessageBox.Show("TextBox is empty"); }
                        else { str = tb.Text; }
                    }));
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(tb.Text)) { str = "0"; MessageBox.Show("TextBox is empty"); }
                    else { str = tb.Text; }
                }

                return Convert.ToUInt16(str);
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return 0;
            }
        }

        //public void TB_Add(string tbName, int pointX, int pointY, int sizeX, int sizeY, int num)
        public void TextBoxAddToGroupBox(GroupBox gb, string tbName, string defaultText, int startNum, int num, int sizeX, int sizeY, int pointX, int pointY, int offsetX)
        {
            string name = tbName;
            int x = pointX, y = pointY;

            try
            {
                for (int i = 0; i < num; i++)
                {
                    TextBox tb = new TextBox();
                    tb.Name = name + startNum.ToString();
                    tb.Size = new Size(sizeX, sizeY);
                    tb.Location = new Point(x, y);
                    tb.TextAlign = HorizontalAlignment.Center;
                    tb.Text = defaultText;

                    x += sizeX + offsetX;
                    startNum++;

                    gb.Controls.Add(tb);
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message + "\n");
            }
        }

        public void LabelAddToGroupBox(GroupBox gb, string labelName, string lName, int startNum, int num, int sizeX, int sizeY, int pointX, int pointY, int offsetX)
        {
            string name = labelName;
            int x = pointX, y = pointY;

            try
            {
                for (int i = 0; i < num; i++)
                {
                    Label lb = new Label();
                    lb.Name = name + startNum.ToString();
                    lb.Text = lName + startNum.ToString();
                    lb.Size = new Size(sizeX, sizeY);
                    lb.Location = new Point(x, y);

                    x += offsetX;
                    startNum++;
                    gb.Controls.Add(lb);
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        public void ButtonAddToGroupBox(GroupBox gb, string btName, string defaultText, int sizeX, int sizeY, int pointX, int pointY, EventHandler evt)
        {
            string name = btName;

            try
            {
                Button bt = new Button();
                bt.Name = name;
                bt.Size = new Size(sizeX, sizeY);
                bt.Location = new Point(pointX, pointY);
                //bt.TextAlign = HorizontalAlignment.Center;
                bt.Text = defaultText;
                bt.Click += new EventHandler(evt);
                gb.Controls.Add(bt);
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * GroupBox안에 textBox를 여러개 표시하고자 할때 사용
         */
        public void TextBoxArrayInGroupBox(GroupBox gb, string tbName, string tbText, string lName, string labelText)
        {
            int tbNum = 10;
            int startNum = 0;
            int tbSizeX = 69;
            int tbSizeY = 21;
            int lSizeX = 60;
            int lSizeY = 10;
            int tbPointX = 6;
            int tbPointY = 20;
            int lPointX = 6;
            int lPointY = 43;

            int tbOffsetX = 15;
            int lOffsetX = tbSizeX + tbOffsetX;

            int OffsetY = 45;

            for (int i = 0; i < 4; i++)
            {
                TextBoxAddToGroupBox(gb, tbName, tbText, startNum, tbNum, tbSizeX, tbSizeY, tbPointX, tbPointY, tbOffsetX);
                LabelAddToGroupBox(gb, lName, labelText, startNum, tbNum, lSizeX, lSizeY, lPointX, lPointY, lOffsetX);

                startNum += 10;
                tbPointY += OffsetY;
                lPointY += OffsetY;
            }
        }

        /*
         * Label Text Set
         */
        public void LBSet(Label lb, string str)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    lb.Invoke(new MethodInvoker(delegate () { lb.Text = str; }));
                }
                else
                {
                    lb.Text = str;
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Label BG color Set
         */
        public void LabelSetForeColor(Label lb, Color clr)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    lb.Invoke(new MethodInvoker(delegate () { lb.ForeColor = clr; }));
                }
                else
                {
                    lb.ForeColor = clr;
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * ComboBox Text Get
         */
        public string CBBGet(ComboBox cb)
        {
            string str = "";

            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { str = cb.Text; })); }
                else { str = cb.Text; }

                return str;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return str;
            }
        }

        /*
         * ComboBox Text Get
         */
        public int CBBIdxGet(ComboBox cb)
        {
            int iIndex = 0;   

            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { iIndex = cb.SelectedIndex; })); }
                else { iIndex = cb.SelectedIndex; }

                return iIndex = cb.SelectedIndex;;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return iIndex = cb.SelectedIndex;;
            }
        }


        /*
         * ComboBox Text Set
         */
        public string ComboTextSet(ComboBox cb, string str)
        {
            try
            {
                if (cb.InvokeRequired) { cb.Invoke(new MethodInvoker(delegate () { cb.Text = str; })); }
                else { cb.Text = str; }

                return str;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return str;
            }
        }

        /*
         * Radio Button Checked Get
         */
        public bool RBGet(RadioButton rb)
        {
            bool ret = false;

            try
            {
                if (rb.InvokeRequired) { rb.Invoke(new MethodInvoker(delegate () { if (rb.Checked) { ret = true; } else { ret = false; } })); }
                else { if (rb.Checked) { ret = true; } else { ret = false; } }

                return ret;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return ret;
            }
        }

        /*
         * Radio Button Checked Set
         */
        public bool RBSet(RadioButton rb, bool val)
        {
            bool ret = false;

            try
            {
                if (rb.InvokeRequired) { rb.Invoke(new MethodInvoker(delegate () { rb.Checked = val; })); }
                else { rb.Checked = val; }

                return ret;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return ret;
            }
        }

        /*
         * Button Text Set
         */
        public void BTNSet(Button bt, string str)
        {
            try
            {
                if (bt.InvokeRequired) { bt.Invoke(new MethodInvoker(delegate () { bt.Text = str; })); }
                else { bt.Text = str; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Button Text Get
         */
        public string BTNGet(Button bt)
        {
            string ret = "";
            try
            {
                if (bt.InvokeRequired) { bt.Invoke(new MethodInvoker(delegate () { ret = bt.Text; })); }
                else { ret = bt.Text; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
            return ret;
        }

        /*
         * List View Item Remove
         */
        public void LVItemRemove(ListView view, ListViewItem item)
        {
            try
            {
                if (view.InvokeRequired) { view.Invoke(new MethodInvoker(delegate () { view.Items.Remove(item); })); }
                else { view.Items.Remove(item); }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * List View Item Add
         */
        public void LVItemAdd(ListView view, ListViewItem item)
        {
            try
            {
                if (view.InvokeRequired) { view.Invoke(new MethodInvoker(delegate () { view.Items.Add(item); })); }
                else { view.Items.Add(item); }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * List Box Add
         */
        public void LBAdd(ListBox lbx, string str)
        {
            try
            {
                if (lbx.InvokeRequired) { lbx.Invoke(new MethodInvoker(delegate () { lbx.Items.Add(str); lbx.TopIndex = lbx.Items.Count - 1; })); }
                else { lbx.Items.Add(str); lbx.TopIndex = lbx.Items.Count - 1; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Numeric Up Down Value Set
         */
        public void NUDSet (NumericUpDown nud, decimal decValue)
        {
            try
            {
                if (nud.InvokeRequired) { nud.Invoke(new MethodInvoker(delegate () { nud.Value = decValue; })); }
                else { nud.Value = decValue; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Numeric Up Down BG Color Set
         */
        public void NUDSetBgColor(NumericUpDown nud, Color bgColor)
        {
            try
            {
                if (nud.InvokeRequired) { nud.Invoke(new MethodInvoker(delegate () { nud.BackColor = bgColor; })); }
                else { nud.BackColor = bgColor; }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        /*
         * Numeric Up Down Value Get
         */
        public decimal NUDGet(NumericUpDown nud)
        {
            decimal     decValue = 0;

            try
            {
                if (nud.InvokeRequired) { nud.Invoke(new MethodInvoker(delegate () { decValue = nud.Value; })); }
                else { decValue = nud.Value; }

                return decValue;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return decValue;
            }
        }

        /*
         * Toggle Button Checked Get
         */
        public bool TGSGet(JCS.ToggleSwitch tgs)
        {
            bool ret = false;

            

            try
            {
                if (tgs.InvokeRequired) { tgs.Invoke(new MethodInvoker(delegate () { if (tgs.Checked) { ret = true; } else { ret = false; } })); }
                else { if (tgs.Checked) { ret = true; } else { ret = false; } }

                return ret;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return ret;
            }
        }

        /*
         * Radio Button Checked Set
         */
        public bool TGSSet(JCS.ToggleSwitch tgs, bool val)
        {
            bool ret = false;

            try
            {
                if (tgs.InvokeRequired) { tgs.Invoke(new MethodInvoker(delegate () { tgs.Checked = val; })); }
                else { tgs.Checked = val; }

                return ret;
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
                return ret;
            }
        }


#if CHART_ENABLED
        public void ChartSet(Chart ch, UInt32 count, string series, double val)
        {
            try
            {
                if (ch.InvokeRequired)
                {
                    ch.Invoke(new MethodInvoker(delegate ()
                    {
                        try
                        {
                            ch.Series[series].Points.AddXY(count, val);
                            ch.Invalidate();
                        }
                        catch (Exception ex)
                        {
                            ERR(ex.Message + '\n');
                        }
                    }));
                }
                else
                {
                    try
                    {
                        ch.Series[series].Points.AddXY(count, val);
                        ch.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        ERR(ex.Message + '\n');
                    }
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        public void ChartSet(Chart ch, string series, double val)
        {
            try
            {
                if (ch.InvokeRequired)
                {
                    ch.Invoke(new MethodInvoker(delegate ()
                    {
                        try
                        {
                            ch.Series[series].Points.AddY(val);
                            ch.Invalidate();
                        }
                        catch (Exception ex)
                        {
                            ERR(ex.Message + '\n');
                        }
                    }));
                }
                else
                {
                    try
                    {
                        ch.Series[series].Points.AddY(val);
                        ch.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        ERR(ex.Message + '\n');
                    }
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        public void ChartSet(Chart ch, double x, double y)
        {
            try
            {
                if (ch.InvokeRequired)
                {
                    ch.Invoke(new MethodInvoker(delegate ()
                    {
                        try
                        {
                            ch.Series[0].Points.AddXY(x, y);
                            ch.Invalidate();
                        }
                        catch (Exception ex)
                        {
                            ERR(ex.Message + '\n');
                        }
                    }));
                }
                else
                {
                    try
                    {
                        ch.Series[0].Points.AddXY(x, y);
                        ch.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        ERR(ex.Message + '\n');
                    }
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        public void ChartSet(Chart ch, int seriesOffset, double x, double y)
        {
            try
            {
                if (ch.InvokeRequired)
                {
                    ch.Invoke(new MethodInvoker(delegate ()
                    {
                        try
                        {
                            ch.Series[seriesOffset].Points.AddXY(x, y);
                            ch.Invalidate();
                        }
                        catch (Exception ex)
                        {
                            ERR(ex.Message + '\n');
                        }
                    }));
                }
                else
                {
                    try
                    {
                        ch.Series[seriesOffset].Points.AddXY(x, y);
                        ch.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        ERR(ex.Message + '\n');
                    }
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        public void ChartClear(Chart ch)
        {
            if (ch.InvokeRequired)
            {
                ch.Invoke(new MethodInvoker(delegate ()
                {
                    foreach (var series in ch.Series)
                    {
                        series.Points.Clear();
                    }
                }));
            }
            else
            {
                foreach (var series in ch.Series)
                {
                    series.Points.Clear();
                }
            }
        }
#endif
    }
}

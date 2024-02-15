using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
    public partial class MainForm : Form
    {
        UInt32      LogMaxCount = 5000;

        public void _L(string str)
        {
            try
            {
                if (rtbLog.InvokeRequired)
                {
                    rtbLog.Invoke(new MethodInvoker(delegate ()
                    {
                        if (rtbLog.Lines.Length > LogMaxCount)
                            LOG_Clear();

                        rtbLog.AppendText(str);
                        rtbLog.ScrollToCaret();
                    }));
                }
                else
                {
                    if (rtbLog.Lines.Length > LogMaxCount)
                        LOG_Clear();

                    rtbLog.AppendText(str);
                    rtbLog.ScrollToCaret();
                }
            }
            catch (Exception ex)
            {
                ERR(ex.Message);
            }
        }

        public void _L(string str, Color userColor)
        {
            try
            {
                str = "\r\n[" + DateTime.Now.ToString("HH:mm:ss") + "] " + str;
                if (rtbLog.InvokeRequired)
                {
                    rtbLog.Invoke(new MethodInvoker(delegate ()
                    {
                        rtbLog.SelectionColor = userColor;
                        if (rtbLog.Lines.Length > LogMaxCount)
                            LOG_Clear();

                        rtbLog.AppendText(str);
                        rtbLog.ScrollToCaret();
                        rtbLog.SelectionColor = rtbLog.ForeColor;
                    }));
                }
                else
                {
                    rtbLog.SelectionColor = userColor;
                    if (rtbLog.Lines.Length > LogMaxCount)
                        LOG_Clear();

                    rtbLog.AppendText(str);
                    rtbLog.ScrollToCaret();
                    rtbLog.SelectionColor = rtbLog.ForeColor;
                }
            }
            catch (Exception ex)
            {
                DBG(ex.Message);
            }
        }
        public void LOG(string str)
        {
            _L(str, Color.Black);
        }

        public void LOG(string str, Color clr)
        {
            _L(str, clr);
        }

        public void ERR(string str, [CallerMemberName] string memberName = "", [CallerLineNumber] int sourceLine = 0)
        {
            _L("[" + memberName + ", " + sourceLine + "] " + str + "\n", Color.Red);

        }

        public void LOG_Clear()
        {
            rtbLog.Clear();
        }

        public void DBG(string str)
        {
            try
            {
                Debug.Print("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + str);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
    }
}

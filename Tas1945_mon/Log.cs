﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FTD2XX_NET;

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

        void print_ftStatus(FTDI.FT_STATUS status)
        {
            switch (status)
            {
                case FTDI.FT_STATUS.FT_OK: LOG("FT_OK"); break;
                case FTDI.FT_STATUS.FT_INVALID_HANDLE: LOG("FT_INVALID_HANDLE"); break;
                case FTDI.FT_STATUS.FT_DEVICE_NOT_FOUND: LOG("FT_DEVICE_NOT_FOUND"); break;
                case FTDI.FT_STATUS.FT_DEVICE_NOT_OPENED: LOG("FT_DEVICE_NOT_OPENED"); break;
                case FTDI.FT_STATUS.FT_IO_ERROR: LOG("FT_IO_ERROR"); break;
                case FTDI.FT_STATUS.FT_INSUFFICIENT_RESOURCES: LOG("FT_INSUFFICIENT_RESOURCES"); break;
                case FTDI.FT_STATUS.FT_INVALID_PARAMETER: LOG("FT_INVALID_PARAMETER"); break;
                case FTDI.FT_STATUS.FT_INVALID_BAUD_RATE: LOG("FT_INVALID_BAUD_RATE"); break;
                case FTDI.FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_ERASE: LOG("FT_DEVICE_NOT_OPENED_FOR_ERASE"); break;
                case FTDI.FT_STATUS.FT_DEVICE_NOT_OPENED_FOR_WRITE: LOG("FT_DEVICE_NOT_OPENED_FOR_WRITE"); break;
                case FTDI.FT_STATUS.FT_FAILED_TO_WRITE_DEVICE: LOG("FT_FAILED_TO_WRITE_DEVICE"); break;
                case FTDI.FT_STATUS.FT_EEPROM_READ_FAILED: LOG("FT_EEPROM_READ_FAILED"); break;
                case FTDI.FT_STATUS.FT_EEPROM_WRITE_FAILED: LOG("FT_EEPROM_WRITE_FAILED"); break;
                case FTDI.FT_STATUS.FT_EEPROM_ERASE_FAILED: LOG("FT_EEPROM_ERASE_FAILED"); break;
                case FTDI.FT_STATUS.FT_EEPROM_NOT_PRESENT: LOG("FT_EEPROM_NOT_PRESENT"); break;
                case FTDI.FT_STATUS.FT_EEPROM_NOT_PROGRAMMED: LOG("FT_EEPROM_NOT_PROGRAMMED"); break;
                case FTDI.FT_STATUS.FT_INVALID_ARGS: LOG("FT_INVALID_ARGS"); break;
                //case FTDI.FT_STATUS.FT_NOT_SUPPORTED: LOG("FT_NOT_SUPPORTED"); break;
                case FTDI.FT_STATUS.FT_OTHER_ERROR: LOG("FT_OTHER_ERROR"); break;
                //case FTDI.FT_STATUS.FT_DEVICE_LIST_NOT_READY: LOG("FT_DEVICE_LIST_NOT_READY"); break;
                default: LOG("FT_UNKNOWN"); break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tas1945_mon
{
	public partial class MainForm : Form
	{
		public byte[]	g_abySendData = new byte[1024];
		public uint		g_uiSendSize = 0;
		public uint		g_uiLastReqCode = 0;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="abyData"></param>
		/// <param name="uiDataSize"></param>
		public void Tas1945_TcpUdpSend (uint uiReqCode, byte[] abyData, uint uiDataSize)
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
			//g_abySendData[g_uiSendSize++] = 0x00;			//	crc16 error test
			//g_abySendData[g_uiSendSize++] = 0x00;

			g_bCommComplete = false;

			if (TGSGet (tgsNetMode) == true)
			{
				TcpIp_ClientSendBytes (g_abySendData, (int)g_uiSendSize);
			}
			else
			{
				string strIp = ipAddress.Text;
				int iTcpPort = Convert.ToInt32 (NUDGet (nudTcpPort));

				if (RBGet (rbServer) == true)
				{
					g_clsUDPClient.SendTo (true, strIp, iTcpPort, g_abySendData, (int)g_uiSendSize);
				}
				else
				{
					g_clsUDPClient.SendTo (false, strIp, iTcpPort, g_abySendData, (int)g_uiSendSize);
				}
			}
		}
	}
}

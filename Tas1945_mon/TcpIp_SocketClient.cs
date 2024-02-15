using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSockets;

namespace Tas1945_mon
{
	public partial class MainForm : Form
	{
		CClientSocket		Client = null;

        public void TcpIp_ClientConnectToServer (string ip, int port)
        {
            try
            {
                Client				 = new CClientSocket (ip, Convert.ToInt16(port));
                Client.OnConnect	+= new CClientSocket.ConnectionDelegate (Client_OnConnect);
                Client.OnDisconnect += new CClientSocket.ConnectionDelegate (Client_OnDisconnect);
                Client.OnError		+= new CClientSocket.ErrorDelegate (Client_OnError);
                Client.OnReadBytes	+= new CClientSocket.ConnectionDelegate (Client_OnReadBytes);
                Client.OnWriteBytes += new CClientSocket.ConnectionDelegate (Client_OnWriteBytes);

                Client.Connect();

                LOG ("Connect : " + ip + ":" + port.ToString ());
            }
            catch(Exception ex)
            {
                ERR (ex.Message);
            } 
        }

        public void TcpIp_ClientDisconnectFromServer ()
        {
            try
            {
                if(Client != null)
                {
                    Client.Disconnect();

                    LOG ("Disconnect");
                }
                else
                {
                    ERR("Client is null");
                }
            }
            catch (Exception ex)
            {
                DBG(ex.Message);
            }
        }

        public void TcpIp_ClientSendBytes (byte[] abyData)
		{
            try
            {
                if (Client != null)
                {
                    Client.SendBytes (abyData);

                    LOG ("REQ : " + HexArrToAscStr (abyData, 0, abyData.Length, true));
                }
                else
                {
                    ERR("Client is null");
                }
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
		}

        public void TcpIp_ClientSendBytes (byte[] abyData, int iLength)
		{
            try
            {
                if (Client != null)
                {
                    Client.SendBytes (abyData, iLength);

                    if (TGSGet (tgsDebugLog) == true)
					{
                        LOG ("REQ : " + HexArrToAscStr (abyData, 0, iLength, true));
					}
                }
                else
                {
                    ERR("Client is null");
                }
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
		}

        #region ## Client Handler ##
        /*
         * Client side registered handler
         */

        private void Client_OnConnect (Socket soc)
        {
            Invoke (new MethodInvoker(delegate ()
            {
                LOG ("Connected To Server");
            }));
        }

        private void Client_OnDisconnect (Socket soc)
        {
            Invoke (new MethodInvoker(delegate ()
            {
                LOG ("Server Disconnected");
            }));
        }

        private void Client_OnError(string ErrMessage, Socket soc, int ErrCode)
        {
            if (soc != null)
            {
                ERR (ErrMessage + ", ErrCode " + ErrCode);
            }
        }

        private void Client_OnReadBytes(Socket soc)
        {
            Invoke (new MethodInvoker(delegate ()
            {
                byte[] abyData   = Client.ReceivedBytes;

                //LOG ("RES : " + HexArrToAscStr (abyData, 0, abyData.Length, true));
                
                Tas1945_RespParser (abyData, abyData.Length);

                {
                    /*
                     * Handle received bytes here
                     */

                    /******************************/
                }
            }));
        }

        private void Client_OnWriteBytes (Socket soc)
        {

        }
        #endregion
	}
}

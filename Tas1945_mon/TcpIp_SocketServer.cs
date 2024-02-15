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
        // Network socket class
        CServerSocket       Server = null;

        private void TcpIp_ServerStart (string ip, int port)
        {
            try
            {
                Server               = new CServerSocket (ip, port);

                Server.OnConnect    += new CServerSocket.ConnectionDelegate (Server_OnConnect);
                Server.OnDisconnect += new CServerSocket.ConnectionDelegate (Server_OnDisconnect);
                Server.OnError      += new CServerSocket.ErrorDelegate (Server_OnError);
                Server.OnListen     += new CServerSocket.ListenDelegate (Server_OnListen);
                Server.OnReadBytes  += new CServerSocket.ConnectionDelegate (Server_OnReadBytes);
                Server.OnWrite      += new CServerSocket.ConnectionDelegate (Server_OnWriteBytes);

                Server.Run ();
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
        }

        private void TcpIp_ServerStop ()
        {
            try
            {
                Server.Stop ();
            }
            catch (Exception ex)
            {
                ERR (ex.Message);
            }
        }

        #region ### Server handler  ###
        /*
         * Server side registered handler
         */
        private void Server_OnConnect (Socket soc)
        {
            Invoke (new Action(delegate
            {
                LOG ("Server Connected\n");
            }));
        }



        private void Server_OnDisconnect (Socket soc)
        {
            Invoke (new MethodInvoker(delegate ()
            {
                LOG ("Client Disconnected\n");
            }));
        }

        private void Server_OnWriteBytes (Socket soc)
        {

        }

        private void Server_OnError (string ErrMessage, Socket soc, int ErrCode)
        {
            ERR (ErrMessage + ", ErrCode " + ErrCode + "\n");
        }

        private void Server_OnReadBytes (Socket soc)
        {
            Invoke (new MethodInvoker(delegate ()
            {
                byte[] byData   = Server.ReceivedBytes;
                string str      = Encoding.ASCII.GetString(byData);

                //richTextBoxServerLog.AppendText(CallerName() + " : Got " + byData.Length + ", " + str + "\n");
                LOG ("RES : " + str);

                {
                    /*
                     * Handle received bytes here
                     */

                    /******************************/
                }
            }));

        }
        private void Server_OnListen ()
        {
            LOG ("Listening...\n");
        }
        #endregion

        public void Server_SendText (string str)
        {
            try
            {
                if(Server != null)
                {
                    Server.SendText (str, 0);
                }
                else
                {
                    ERR ("Server is null\n");
                }
            }
            catch(Exception ex)
            {
                ERR (ex.Message);
            }
        }
	}
}

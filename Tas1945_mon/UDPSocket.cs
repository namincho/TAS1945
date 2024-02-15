using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tas1945_mon
{
	public class UDPSocket
	{
        MainForm        g_mfMainForm;

        private Socket _socket = null;
        private State state = null;
        private EndPoint epFrom = null;
        private AsyncCallback recv = null;

        private const int bufSize = 10 * 1024;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mf"></param>
        public UDPSocket (MainForm mf)
		{
            g_mfMainForm = mf;
		}

        /// <summary>
        /// 
        /// </summary>
        public class State
        {
            public byte[] buffer = new byte[bufSize];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void Setup (bool bServer, string address, int port)
        {
			try
			{  
                if (bServer == true)
				{
                    _socket = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    state = new State ();

                    epFrom = new IPEndPoint (IPAddress.Any, 0);

                    _socket.SetSocketOption (SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                    
                    _socket.Bind (new IPEndPoint (IPAddress.Parse (address), port));

                    Receive ();
				}
				else
				{
                    _socket = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    state = new State ();

                    epFrom = new IPEndPoint (IPAddress.Any, 0);

                    _socket.SetSocketOption (SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
				}
			}
			catch (Exception ex)
			{
                g_mfMainForm.LOG (ex.Message);
			}
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close ()
		{
			try
			{
                if (_socket != null)
				{
                    _socket.Shutdown (SocketShutdown.Both);
                    _socket.Close ();
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
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="text"></param>
        public void SendTo (string address, int port, string text)
		{
			try
			{
                byte[] byData = Encoding.Default.GetBytes (text);
                IPEndPoint ipEndPoint = new IPEndPoint (IPAddress.Parse(address), port);

                _socket.SendTo (byData, byData.Length, SocketFlags.None, ipEndPoint);
			}
			catch (Exception ex)
			{
                g_mfMainForm.ERR (ex.ToString ());
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        /// <param name="abyData"></param>
        /// <param name="iLength"></param>
        public void SendTo (bool bServer, string address, int port, byte[] abyData, int iLength)
		{
			try
			{   
                IPEndPoint ipEndPoint = new IPEndPoint (IPAddress.Parse(address), port);
                
                _socket.SendTo (abyData, iLength, SocketFlags.None, ipEndPoint);

                if (g_mfMainForm.TGSGet (g_mfMainForm.tgsDebugLog) == true)
				{
                    g_mfMainForm.LOG ("REQ : " + g_mfMainForm.HexArrToAscStr (abyData, 0, iLength, true));
				}

                if (bServer == false)
				{
                    g_mfMainForm.g_bSendRead = false;
                    epFrom = new IPEndPoint (IPAddress.Any, 0);

                    Receive ();
				}
			}
			catch (Exception ex)
			{
                g_mfMainForm.ERR (ex.ToString ());
			}
		}

        /// <summary>
        /// 
        /// </summary>
        private void Receive ()
        {
			try
			{
                _socket.BeginReceiveFrom (state.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv = (ar) =>
                {
					try
					{
                        State so = (State)ar.AsyncState;
                        int bytes = _socket.EndReceiveFrom (ar, ref epFrom);
                        _socket.BeginReceiveFrom (so.buffer, 0, bufSize, SocketFlags.None, ref epFrom, recv, so);

                        //g_mfMainForm.LOG ("IP : " + epFrom.ToString ());
                        //g_mfMainForm.LOG ("RES : " + g_mfMainForm.HexArrToAscStr (so.buffer, 0, bytes, true));

                        g_mfMainForm.Tas1945_RespParser (so.buffer, bytes);
					}
					catch (Exception)
					{
                        ;
					}

                }, state);
			}
			//catch (Exception ex)
            catch (Exception)
			{
                ; //g_mfMainForm.ERR (ex.ToString ());
			}
        }
	}
}

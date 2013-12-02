using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
	public class NetServer :  NetService
	{
		
		private Socket clientSocket;
		private TcpListener serverListener;
		private bool keepAlive;

		public NetServer(Game sender, IPAddress ip, int portNumber)
		{
			this.portNumber = portNumber;
			this.ipAdress = ip;
			this.gameForm = sender;
			this.isOnline = false;
			this.isListening = false;
			this.isHosting = true;
		}
		
		public override void Start()
		{
			if(this.netThread == null && !this.isListening) 
			{
				this.CreateChat();
				this.keepAlive = true;
				this.netThread = new Thread( new ThreadStart( this.startServer ) );
				this.netThread.Start();
				this.netThread.Priority=ThreadPriority.Highest;
				this.isManualDisconnected=false;
				this.chat.Text+=" - Server";
				this.chat.pBox.Visible = true;
			}
			else 
			{
				MessageBox.Show("You are already running as a Server","Server error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}

		public override void Stop()
		{
			try
			{
				if (this.netThread != null && this.isListening)
				{
					this.isManualDisconnected=true;
					if (this.clientSocket != null)
						this.Send(((int)DataType.supervisory), NetService.terminationString);
					else
					{
						TcpClient tempTCPClient = new TcpClient("localhost",this.portNumber);
						tempTCPClient.Close();
						if(this.netThread != null)
							this.netThread.Interrupt();
					}
					this.chat.TextBoxConnectionLog.AppendText("\r\nShuting down server... ");
					while(this.netThread.IsAlive)
						Thread.Sleep(1000);
					this.chat.TextBoxConnectionLog.AppendText("Server stopped");
					this.chat.pBox.Visible = false;
					this.netThread=null;
				}
			}
			catch(Exception exc)
			{
				MessageBox.Show(exc.ToString());
			}
		}

		private void startServer()
		{
			try 
			{
				try
				{
					this.serverListener = new TcpListener(this.portNumber);
					this.serverListener.Start();
				}
				catch
				{
					this.chat.TextBoxConnectionLog.AppendText("\nCould not start server");
					this.netThread=null;
					return;
				}
				this.chat.TextBoxConnectionLog.AppendText("\r\nServer started");
				this.isListening = true;
				while (this.keepAlive && !this.isManualDisconnected)
				{
					this.chat.TextBoxConnectionLog.AppendText("\r\nWaiting for connections...");
					this.clientSocket = this.serverListener.AcceptSocket();
					if (this.isManualDisconnected)
					{
						this.clientSocket.Close();
						this.clientSocket=null;
						break;
					}
					this.chat.TextBoxConnectionLog.AppendText("\r\nConnection accepted from: " + ((IPEndPoint)(this.clientSocket.RemoteEndPoint)).Address.ToString());
					this.networkStream = new NetworkStream(this.clientSocket);
					this.isOnline = true;
					this.SynchronizeConnection();
					this.gameForm.InitializeNetworkGame();
					while(!this.isManualDisconnected)
					{
						int dataType = (int)this.binaryFormatter.Deserialize(networkStream);
						Object data = this.binaryFormatter.Deserialize(networkStream);
						if (this.ProcessNetworkData(dataType, data))
						{
							this.chat.TextBoxConnectionLog.AppendText("\nClient has terminated the connection");
							break;
						}
					}
					this.clientSocket.Close();
					this.clientSocket=null;
					this.isOnline = false;
					this.networkStream = null;
				} // Keep Alive end

				this.serverListener.Stop();
				this.isListening=false;
			}
			catch
			{
				MessageBox.Show("Connection has been closed the connection abnormaly"); 
			}
		}
	}
}

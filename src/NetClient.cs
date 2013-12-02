using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
	public class NetClient : NetService
	{
		private TcpClient tcpClient;
		
		public NetClient(Game sender, IPAddress ip, int portNumber)
		{
			this.portNumber = portNumber;
			this.ipAdress = ip;
			this.gameForm = sender;
			this.isOnline = false;
			this.isListening = false;
			this.isHosting = false;
		}

		public override void Start()
		{
			if (this.netThread == null && !this.isOnline)
			{
				this.CreateChat();
				this.netThread = new Thread ( new ThreadStart (this.startClient));
				this.netThread.Start();
				this.isManualDisconnected=false;
				this.chat.Text+=" - Client";
				this.chat.pBox.Visible = true;
			}
			else
				if(this.isOnline)
					MessageBox.Show("You are already running as a Client","Client error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}
		
		public override void Stop()
		{
			try 
			{
				if (this.netThread != null && this.isOnline)
				{
					this.isManualDisconnected=true;
					this.Send((int)DataType.supervisory, NetService.terminationString);
					this.netThread=null;
					this.chat.TextBoxConnectionLog.AppendText("\r\nClient has terminated the connection");
					this.chat.pBox.Visible = false;
				}
				else
					if(this.chat != null)
						this.chat.TextBoxConnectionLog.AppendText("\r\nYou are already disconnected");
			}
			catch (Exception excStop)
			{
				MessageBox.Show(excStop.ToString());
			}
		}

		private void startClient()
		{
			IPEndPoint endPoint = new IPEndPoint(this.ipAdress.Address,this.portNumber);
			try 
			{
				//Connecting to server
				this.tcpClient = new TcpClient();
				try 
				{ 
					this.chat.pBox.Visible = true;
					this.chat.TextBoxConnectionLog.AppendText("\r\nSearching for Server...  "); 
					this.tcpClient.Connect(endPoint); 
				}
				catch 
				{
					this.chat.TextBoxConnectionLog.AppendText("Server not found");
					this.chat.pBox.Visible = false;
					Thread.Sleep(1000);
					this.chat.Hide();
					this.netThread=null;
					return;
				}
				this.chat.TextBoxConnectionLog.AppendText("Server found");
				this.networkStream = this.tcpClient.GetStream();
				this.chat.TextBoxConnectionLog.AppendText("\r\nClient started");
				this.isOnline = true;
				this.isListening = true;
				this.SynchronizeConnection();
				
				while (!this.isManualDisconnected)
				{
					int dataType = (int)binaryFormatter.Deserialize(networkStream);
					Object data = binaryFormatter.Deserialize(networkStream);
					if (this.ProcessNetworkData(dataType, data))
						break;
				}
	
				if(!this.isManualDisconnected && this.chat != null)
					this.chat.TextBoxConnectionLog.AppendText("\r\nServer has terminated the connection");
				this.networkStream.Close();
				this.tcpClient.Close();
			}
			catch (Exception excStartClient)
			{
				MessageBox.Show(excStartClient.ToString());
			}
			finally
			{
				this.isOnline=false;
				this.isListening = false;
				this.netThread=null;
			}
		}
	}
}

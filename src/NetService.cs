using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace Game
{
	enum DataType {name, move, endGame, message, supervisory};
	abstract public class NetService
	{
		public static string terminationString = "TERMINATE_CONNECTION";
		public static string startGameString = "START_NEW_GAME";
		public static string requestInitializeString = "END_GAME_REQ_INIT";
		public static string initializeString = "END_GAME_INIT";

		protected int portNumber;
		protected IPAddress ipAdress;
		protected Thread netThread;
		protected Game gameForm;
		protected bool isManualDisconnected;
		protected bool isListening;
		protected bool isOnline;
		protected bool isHosting;
		protected Chat chat;
		protected NetworkStream networkStream;
		protected BinaryFormatter binaryFormatter;
	
		public NetService()
		{
			this.netThread = null;
			this.networkStream = null;
			this.binaryFormatter = new BinaryFormatter();
			this.isListening = false;
			this.isOnline = false;
		}
		
		abstract public void Start();
		abstract public void Stop();
	
		public void Send(int dataType, Object data)
		{
			if(this.isOnline && this.networkStream != null )
			{
				if(dataType == (int)DataType.message && (string)data == "")
					return;
				this.binaryFormatter.Serialize(this.networkStream, dataType);
				this.binaryFormatter.Serialize(this.networkStream, data);
				if(dataType == (int)DataType.message)
					this.AddChatMessage((string)data,true);
			}
			else 
				MessageBox.Show("Can not send information you are not online","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}

		protected bool ProcessNetworkData(int dataType, Object data)
		{
			switch (dataType)
			{
				case (int)DataType.supervisory:
					return this.SupervisoryHandle(data);
				case (int)DataType.message:
					this.AddChatMessage((string)data,false);
					break;
				case (int)DataType.name:
					this.HandleNames((string) data);
					break;
				case (int)DataType.endGame:
					this.EndGameHandle((string) data);
					break;
				case (int)DataType.move:
					this.HandleMove((int)data);
					break;
			}
			return false;
		}


		#region Comunication Handlers

		private bool SupervisoryHandle(Object receiveData)
		{
			if ((string)receiveData == NetService.terminationString)
			{
				if(!this.isManualDisconnected)
				{
					this.Send((int)DataType.supervisory, NetService.terminationString);
					return true;
				}
			}
			if((string)receiveData == NetService.startGameString)
			{
				
				if(!this.isHosting)
					this.Send((int)DataType.supervisory,NetService.startGameString);
				this.gameForm.EnableGame = true;
				this.chat.TextBoxConnectionLog.AppendText("\nGame Started");
			}
			return false;
		}

		private void AddChatMessage(string reciveMessage,bool isLocalMessage)
		{
			// isLocalMessage:  true - local host sent message , false - message arrived from the net

			this.chat.TextBoxChatMessageReceive.Focus();
			if (this.isHosting && isLocalMessage)
			{
				this.chat.TextBoxChatMessageReceive.ForeColor = this.gameForm.Player1.CColor;
				this.chat.TextBoxChatMessageReceive.AppendText("\n" + this.gameForm.Player1.Name + ": " + reciveMessage);
			}
			if(this.isHosting && !isLocalMessage)
			{	
				this.chat.TextBoxChatMessageReceive.ForeColor = this.gameForm.Player2.CColor;
				this.chat.TextBoxChatMessageReceive.AppendText("\n" + this.gameForm.Player2.Name + ": " + reciveMessage);
			}
			if(!this.isHosting && isLocalMessage)
			{
				this.chat.TextBoxChatMessageReceive.ForeColor = this.gameForm.Player2.CColor;
				this.chat.TextBoxChatMessageReceive.AppendText("\n" + this.gameForm.Player2.Name + ": " + reciveMessage);
			}
			if(!this.isHosting && !isLocalMessage)
			{
				this.chat.TextBoxChatMessageReceive.ForeColor = this.gameForm.Player1.CColor;
				this.chat.TextBoxChatMessageReceive.AppendText("\n" + this.gameForm.Player1.Name + ": " + reciveMessage);
			}	
			
			this.chat.TextBoxChatMessageSend.Focus();
		}

		protected void HandleNames(string receiveData)
		{
			if(this.isHosting)
			{
				this.gameForm.Player2.Name = receiveData;
				this.gameForm.Stb.NameP2 = receiveData;
			}
			else
			{
				this.gameForm.Player1.Name = receiveData;	
				this.gameForm.Stb.NameP1 = receiveData;
			}
		}
			
		protected void HandleMove(int col)
		{
			this.chat.TextBoxConnectionLog.AppendText("\nMove: " + col);
			this.gameForm.ExecuteTurn(col,false);
		}
		
		protected void EndGameHandle(string endString)
		{
			if(endString == NetService.initializeString )
			{
				this.gameForm.EnableGame = true;
				if(!this.isHosting)
					this.Send((int)DataType.endGame,NetService.initializeString);
				this.chat.TextBoxConnectionLog.AppendText("\nGame Started");
				this.gameForm.statBar.Text = "Ready";
				
			}
			if(endString == NetService.requestInitializeString)
			{
				this.gameForm.EndGameSyncFar = true;
				if(this.isHosting && this.gameForm.EndGameSyncNear==true)
					this.Send((int)DataType.endGame,NetService.initializeString);
			}

		}

		#endregion

		#region Initialization Functions

		public static NetService Create(Game sender) 
		{
			NetworkSettings dlg = new NetworkSettings();
			if(sender.NetService != null)
				sender.NetService.DisposeChat();
			if (dlg.ShowDialog() == DialogResult.OK ) 
			{
				if(dlg.IsHosting)
					return new NetServer(sender,dlg.GetIPAddress,dlg.PortNumber);
				else
					return new NetClient(sender,dlg.GetIPAddress,dlg.PortNumber);
			}
			else 
				return null;
		}

		public void SynchronizeConnection()
		{
			if(this.isHosting)
			{
				this.Send((int)DataType.name,this.gameForm.Player1.Name);
				this.Send((int)DataType.supervisory,NetService.startGameString);
			}
			else	
				this.Send((int)DataType.name,this.gameForm.Player2.Name);
		}

		protected void CreateChat()
		{
			if(this.chat == null)
				this.chat = new Chat(this);
			this.chat.Show();
		}

		public void DisposeChat()
		{
			if ( this.chat != null ) 
			{
				this.chat.Hide();
				this.chat.Close();
				this.chat = null;
			}
		}
	
		#endregion

		#region Properties

		public bool IsListening
		{
			get
			{
				return this.isListening;
			}
		}

		public bool IsOnline
		{
			get
			{
				return this.isOnline;
			}
		}

		public bool IsHosting
		{
			get
			{
				return this.isHosting;
			}
		}

		public Chat Chat
		{
			set
			{
				this.chat = value;
			}
			get
			{
				return this.chat;
			}
		}
		#endregion
	}
}

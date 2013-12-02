using System;
using System.Net;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Game
{
	public class NetworkSettings : System.Windows.Forms.Form
	{
		private IPAddress ipAdress;
		private int portNumber;
		private bool isHosting;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBoxIpPort;
		private System.Windows.Forms.PictureBox pictureBoxConnection;
		private System.Windows.Forms.RadioButton radioButtonServer;
		private System.Windows.Forms.RadioButton radioButtonClient;
		private System.Windows.Forms.TextBox textBoxIP;
		private System.Windows.Forms.TextBox textBoxPort;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.ComponentModel.Container components = null;

		public NetworkSettings()
		{
			InitializeComponent();
			this.ipAdress = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0];
			this.portNumber = 8100;
			this.textBoxIP.Text = "127.0.0.1";
			this.textBoxPort.Text = this.portNumber.ToString();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NetworkSettings));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxIP = new System.Windows.Forms.TextBox();
			this.textBoxPort = new System.Windows.Forms.TextBox();
			this.groupBoxIpPort = new System.Windows.Forms.GroupBox();
			this.pictureBoxConnection = new System.Windows.Forms.PictureBox();
			this.radioButtonServer = new System.Windows.Forms.RadioButton();
			this.radioButtonClient = new System.Windows.Forms.RadioButton();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Address";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.label2.Location = new System.Drawing.Point(16, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Port";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxIP
			// 
			this.textBoxIP.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.textBoxIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxIP.Location = new System.Drawing.Point(88, 34);
			this.textBoxIP.Name = "textBoxIP";
			this.textBoxIP.Size = new System.Drawing.Size(144, 20);
			this.textBoxIP.TabIndex = 2;
			this.textBoxIP.Text = "";
			// 
			// textBoxPort
			// 
			this.textBoxPort.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.textBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBoxPort.Location = new System.Drawing.Point(88, 64);
			this.textBoxPort.Name = "textBoxPort";
			this.textBoxPort.Size = new System.Drawing.Size(80, 20);
			this.textBoxPort.TabIndex = 3;
			this.textBoxPort.Text = "";
			// 
			// groupBoxIpPort
			// 
			this.groupBoxIpPort.BackColor = System.Drawing.Color.PeachPuff;
			this.groupBoxIpPort.Location = new System.Drawing.Point(8, 8);
			this.groupBoxIpPort.Name = "groupBoxIpPort";
			this.groupBoxIpPort.Size = new System.Drawing.Size(280, 88);
			this.groupBoxIpPort.TabIndex = 4;
			this.groupBoxIpPort.TabStop = false;
			this.groupBoxIpPort.Text = "Network Information";
			// 
			// pictureBoxConnection
			// 
			this.pictureBoxConnection.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.pictureBoxConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxConnection.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBoxConnection.Image")));
			this.pictureBoxConnection.Location = new System.Drawing.Point(312, 13);
			this.pictureBoxConnection.Name = "pictureBoxConnection";
			this.pictureBoxConnection.Size = new System.Drawing.Size(104, 83);
			this.pictureBoxConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxConnection.TabIndex = 5;
			this.pictureBoxConnection.TabStop = false;
			// 
			// radioButtonServer
			// 
			this.radioButtonServer.Checked = true;
			this.radioButtonServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.radioButtonServer.Location = new System.Drawing.Point(16, 120);
			this.radioButtonServer.Name = "radioButtonServer";
			this.radioButtonServer.Size = new System.Drawing.Size(96, 24);
			this.radioButtonServer.TabIndex = 6;
			this.radioButtonServer.TabStop = true;
			this.radioButtonServer.Text = "Host a Game";
			// 
			// radioButtonClient
			// 
			this.radioButtonClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.radioButtonClient.Location = new System.Drawing.Point(120, 120);
			this.radioButtonClient.Name = "radioButtonClient";
			this.radioButtonClient.TabIndex = 7;
			this.radioButtonClient.Text = "Join a Game";
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.Cornsilk;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(256, 144);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.BackColor = System.Drawing.Color.Cornsilk;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(344, 144);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			// 
			// NetworkSettings
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.PeachPuff;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(424, 175);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.buttonCancel,
																		  this.buttonOK,
																		  this.radioButtonClient,
																		  this.radioButtonServer,
																		  this.pictureBoxConnection,
																		  this.textBoxPort,
																		  this.textBoxIP,
																		  this.label2,
																		  this.label1,
																		  this.groupBoxIpPort});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NetworkSettings";
			this.Opacity = 0.85000002384185791;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Network Settings";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ipAdress = IPAddress.Parse(this.textBoxIP.Text);
			this.portNumber = int.Parse(this.textBoxPort.Text);
			this.isHosting = this.radioButtonServer.Checked;
		}

		public IPAddress GetIPAddress
		{
			get
			{
				return this.ipAdress;
			}
		}
		
		public int PortNumber
		{
			get
			{
				return this.portNumber;
			}
		}

		public bool IsHosting
		{
			get
			{
				return this.isHosting;
			}
		}
	}
}

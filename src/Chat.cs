using System;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Game
{
	public class Chat : System.Windows.Forms.Form
	{
		private NetService netInterface;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Button buttonSend;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.RichTextBox textBoxConnectionLog;
		private System.Windows.Forms.TextBox textBoxChatMessageSend;
		private System.Windows.Forms.RichTextBox textBoxChatMessageReceive;
		private System.Windows.Forms.ToolBarButton ButtonSendSmile;
		private System.Windows.Forms.ToolBarButton ButtonSendSad;
		private System.Windows.Forms.ToolBarButton ButtonSendHappy;
		private System.Windows.Forms.ToolBarButton ButtonSendLove;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolBarButton toolBarButtonWhat;
		private System.Windows.Forms.ToolBarButton toolBarButtonHideChat;
		private System.Windows.Forms.ToolBarButton toolBarButton1;

		private System.ComponentModel.IContainer components;

		public Chat(NetService sender)
		{
			InitializeComponent();
			this.netInterface = sender;
			this.pictureBox1.Visible = false;
		}

		protected override void Dispose( bool disposing )
		{
			this.netInterface.Chat = null;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Chat));
			this.buttonSend = new System.Windows.Forms.Button();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.ButtonSendSmile = new System.Windows.Forms.ToolBarButton();
			this.ButtonSendSad = new System.Windows.Forms.ToolBarButton();
			this.ButtonSendHappy = new System.Windows.Forms.ToolBarButton();
			this.ButtonSendLove = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonWhat = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonHideChat = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.textBoxChatMessageReceive = new System.Windows.Forms.RichTextBox();
			this.textBoxConnectionLog = new System.Windows.Forms.RichTextBox();
			this.textBoxChatMessageSend = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// buttonSend
			// 
			this.buttonSend.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.buttonSend.BackColor = System.Drawing.Color.Cornsilk;
			this.buttonSend.Location = new System.Drawing.Point(267, 260);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(88, 21);
			this.buttonSend.TabIndex = 1;
			this.buttonSend.Text = "Send";
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.AllowDrop = true;
			this.toolBar1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.AutoSize = false;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.ButtonSendSmile,
																						this.ButtonSendSad,
																						this.ButtonSendHappy,
																						this.ButtonSendLove,
																						this.toolBarButtonWhat,
																						this.toolBarButton1,
																						this.toolBarButtonHideChat});
			this.toolBar1.ButtonSize = new System.Drawing.Size(30, 30);
			this.toolBar1.Divider = false;
			this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(146, 23);
			this.toolBar1.TabIndex = 4;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// ButtonSendSmile
			// 
			this.ButtonSendSmile.ImageIndex = 4;
			this.ButtonSendSmile.ToolTipText = "Send a smile";
			// 
			// ButtonSendSad
			// 
			this.ButtonSendSad.ImageIndex = 3;
			this.ButtonSendSad.ToolTipText = "Send a sad face";
			// 
			// ButtonSendHappy
			// 
			this.ButtonSendHappy.ImageIndex = 0;
			this.ButtonSendHappy.ToolTipText = "Send happy";
			// 
			// ButtonSendLove
			// 
			this.ButtonSendLove.ImageIndex = 2;
			this.ButtonSendLove.ToolTipText = "send a kiss";
			// 
			// toolBarButtonWhat
			// 
			this.toolBarButtonWhat.ImageIndex = 1;
			this.toolBarButtonWhat.ToolTipText = "send a question";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonHideChat
			// 
			this.toolBarButtonHideChat.ImageIndex = 5;
			this.toolBarButtonHideChat.ToolTipText = "Hide chat box";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// textBoxChatMessageReceive
			// 
			this.textBoxChatMessageReceive.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBoxChatMessageReceive.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxChatMessageReceive.Location = new System.Drawing.Point(0, 22);
			this.textBoxChatMessageReceive.Name = "textBoxChatMessageReceive";
			this.textBoxChatMessageReceive.Size = new System.Drawing.Size(356, 176);
			this.textBoxChatMessageReceive.TabIndex = 5;
			this.textBoxChatMessageReceive.Text = "Chat:";
			// 
			// textBoxConnectionLog
			// 
			this.textBoxConnectionLog.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBoxConnectionLog.BackColor = System.Drawing.Color.Linen;
			this.textBoxConnectionLog.Location = new System.Drawing.Point(0, 198);
			this.textBoxConnectionLog.Name = "textBoxConnectionLog";
			this.textBoxConnectionLog.Size = new System.Drawing.Size(356, 55);
			this.textBoxConnectionLog.TabIndex = 6;
			this.textBoxConnectionLog.Text = "Connection log:";
			// 
			// textBoxChatMessageSend
			// 
			this.textBoxChatMessageSend.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textBoxChatMessageSend.Location = new System.Drawing.Point(0, 261);
			this.textBoxChatMessageSend.Name = "textBoxChatMessageSend";
			this.textBoxChatMessageSend.Size = new System.Drawing.Size(260, 20);
			this.textBoxChatMessageSend.TabIndex = 7;
			this.textBoxChatMessageSend.Text = "";
			this.textBoxChatMessageSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChatMessageSend_KeyDown);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(323, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(33, 22);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// Chat
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.PeachPuff;
			this.ClientSize = new System.Drawing.Size(356, 286);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.textBoxChatMessageSend,
																		  this.textBoxConnectionLog,
																		  this.textBoxChatMessageReceive,
																		  this.toolBar1,
																		  this.buttonSend});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Chat";
			this.ShowInTaskbar = false;
			this.Text = "Chat";
			this.ResumeLayout(false);

		}
		#endregion

		private void textBoxChatMessageSend_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Enter )
				this.netInterface.Send((int)DataType.message,this.textBoxChatMessageSend.Text);
		}

		private void buttonSend_Click(object sender, System.EventArgs e)
		{
			this.textBoxChatMessageSend_KeyDown(this,new KeyEventArgs(Keys.Enter));
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(!this.netInterface.IsOnline)
				return;
			if(e.Button == this.ButtonSendSmile)
				this.netInterface.Send((int)DataType.message,"very big S-M-I-L-E");
			if(e.Button == this.ButtonSendSad)
				this.netInterface.Send((int)DataType.message,"I'm very Sad");
			if(e.Button == this.ButtonSendHappy)
				this.netInterface.Send((int)DataType.message,"I'm very Happy");
            if(e.Button == this.ButtonSendLove)
				this.netInterface.Send((int)DataType.message,"Kiss !!!");
			if(e.Button == this.toolBarButtonWhat)
				this.netInterface.Send((int)DataType.message,"What did you said ?");
			if(e.Button == this.toolBarButtonHideChat)
				this.Visible = false;
		}

		#region Chat Properties
		public RichTextBox TextBoxChatMessageReceive
		{
			get
			{
				return this.textBoxChatMessageReceive;
			}
		}

		public RichTextBox TextBoxConnectionLog
		{
			get
			{
				return this.textBoxConnectionLog;
			}
		}

		public TextBox TextBoxChatMessageSend
		{
			get
			{
				return this.textBoxChatMessageSend;
			}
		}
		public PictureBox pBox
		{
			get
			{
				return this.pictureBox1;
			}
		}
		#endregion
	}
}

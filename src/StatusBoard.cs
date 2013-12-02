using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Game
{
	
	public class StatusBoard : System.Windows.Forms.Form
	{
		private string player1,player2;
		private string mousePosition;
		private bool currentTurn;
		private System.Windows.Forms.Label labelP1;
		private System.Windows.Forms.Label labelP2;
		private System.Windows.Forms.Label labelMousePosition;
		private System.Windows.Forms.PictureBox pictureBoxP1;
		private System.Windows.Forms.PictureBox pictureBoxP2;
		
		private System.ComponentModel.Container components = null;

		public StatusBoard(string np1, string np2, string mp, bool ct)
		{
			InitializeComponent();
			this.player1=np1;
			this.player2=np2;
			this.mousePosition="";
			this.currentTurn=ct;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StatusBoard));
			this.labelP1 = new System.Windows.Forms.Label();
			this.labelP2 = new System.Windows.Forms.Label();
			this.labelMousePosition = new System.Windows.Forms.Label();
			this.pictureBoxP1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxP2 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// labelP1
			// 
			this.labelP1.BackColor = System.Drawing.Color.Transparent;
			this.labelP1.ForeColor = System.Drawing.Color.White;
			this.labelP1.Location = new System.Drawing.Point(32, 13);
			this.labelP1.Name = "labelP1";
			this.labelP1.Size = new System.Drawing.Size(81, 24);
			this.labelP1.TabIndex = 0;
			this.labelP1.Text = "label1";
			this.labelP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelP2
			// 
			this.labelP2.BackColor = System.Drawing.Color.Transparent;
			this.labelP2.ForeColor = System.Drawing.Color.White;
			this.labelP2.Location = new System.Drawing.Point(32, 45);
			this.labelP2.Name = "labelP2";
			this.labelP2.Size = new System.Drawing.Size(81, 24);
			this.labelP2.TabIndex = 1;
			this.labelP2.Text = "label2";
			this.labelP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMousePosition
			// 
			this.labelMousePosition.BackColor = System.Drawing.Color.Transparent;
			this.labelMousePosition.ForeColor = System.Drawing.Color.White;
			this.labelMousePosition.Location = new System.Drawing.Point(8, 88);
			this.labelMousePosition.Name = "labelMousePosition";
			this.labelMousePosition.Size = new System.Drawing.Size(108, 24);
			this.labelMousePosition.TabIndex = 2;
			this.labelMousePosition.Text = "Empty";
			this.labelMousePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBoxP1
			// 
			this.pictureBoxP1.BackColor = System.Drawing.Color.IndianRed;
			this.pictureBoxP1.Location = new System.Drawing.Point(8, 17);
			this.pictureBoxP1.Name = "pictureBoxP1";
			this.pictureBoxP1.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxP1.TabIndex = 3;
			this.pictureBoxP1.TabStop = false;
			// 
			// pictureBoxP2
			// 
			this.pictureBoxP2.BackColor = System.Drawing.Color.IndianRed;
			this.pictureBoxP2.Location = new System.Drawing.Point(8, 47);
			this.pictureBoxP2.Name = "pictureBoxP2";
			this.pictureBoxP2.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxP2.TabIndex = 4;
			this.pictureBoxP2.TabStop = false;
			// 
			// StatusBoard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(124, 120);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBoxP2,
																		  this.pictureBoxP1,
																		  this.labelMousePosition,
																		  this.labelP2,
																		  this.labelP1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatusBoard";
			this.Opacity = 0.85000002384185791;
			this.ShowInTaskbar = false;
			this.Text = "Status Board";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.StatusBoard_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		private void StatusBoard_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.labelP1.Text=player1;
			this.labelP2.Text=player2;
			this.pictureBoxP1.Visible=currentTurn;
			this.pictureBoxP2.Visible=!currentTurn;
		}

		#region Status Board properties

		public string NameP1
		{
			set
			{
				player1=value;
				this.labelP1.Invalidate();
			}
		}
		public string NameP2
		{
			set
			{
				player2=value;
				this.labelP2.Invalidate();
			}
		}
		public string CurrentMousePosition
		{
			set
			{
				mousePosition=value;
				this.labelMousePosition.Text=mousePosition;
				labelMousePosition.Invalidate();
			}
		}
		public bool CurrentTurn
		{
			set
			{
				currentTurn=value;
				this.Invalidate();
			}
			get 
			{
				return currentTurn;
			}
		}
		#endregion
		
	}
}

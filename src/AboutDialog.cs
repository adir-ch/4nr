using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Game
{
	public class AboutDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label Selectionlabel;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.ComponentModel.Container components = null;

		public AboutDialog()
		{
			InitializeComponent();
			listBox1.SelectedIndex=0;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutDialog));
			this.buttonOK = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.Selectionlabel = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.Linen;
			this.buttonOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.buttonOK.ForeColor = System.Drawing.Color.Black;
			this.buttonOK.Location = new System.Drawing.Point(273, 106);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.listBox1.ForeColor = System.Drawing.Color.Black;
			this.listBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.listBox1.Items.AddRange(new object[] {
														  "About the Game",
														  "Last update date",
														  "Version"});
			this.listBox1.Location = new System.Drawing.Point(9, 6);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(120, 41);
			this.listBox1.TabIndex = 3;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// Selectionlabel
			// 
			this.Selectionlabel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Selectionlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Selectionlabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(177)));
			this.Selectionlabel.ForeColor = System.Drawing.Color.Black;
			this.Selectionlabel.Location = new System.Drawing.Point(9, 79);
			this.Selectionlabel.Name = "Selectionlabel";
			this.Selectionlabel.Size = new System.Drawing.Size(195, 55);
			this.Selectionlabel.TabIndex = 4;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(365, 141);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 6;
			this.pictureBox2.TabStop = false;
			// 
			// AboutDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.PeachPuff;
			this.ClientSize = new System.Drawing.Size(365, 141);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1,
																		  this.Selectionlabel,
																		  this.buttonOK,
																		  this.pictureBox2});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.Opacity = 0.85;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About 4 In A Row Game";
			this.TransparencyKey = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.ResumeLayout(false);

		}
		#endregion

	
		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listBox1.SelectedIndex==0)
				Selectionlabel.Text="This Game brought to you by Adir Cohen\nAll Right reserved (c)\nMail to: adir@matavtv.net";
			if(this.listBox1.SelectedIndex==1)
				Selectionlabel.Text="24/8/2002";
			if(this.listBox1.SelectedIndex==2)
				Selectionlabel.Text="Build 2.00 - Release\nNext version 2.5 at 1/10/2002";
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			while((this.Opacity-=0.1)>0);
			this.DialogResult=DialogResult.OK;
			
		}
	}
}

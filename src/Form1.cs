using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
	public class Game : System.Windows.Forms.Form
	{
		private GameMatrix matrix;
		private Player player1,player2;
		private Environment env;
		private BinaryFormatter formatter;
		private string path;
		private Bitmap backPicture;
		private StatusBoard stb;
		private NetService netService;
		private Brush tBrush;
		private bool modifyFlag;
		private bool isAnimating;
		private bool isNetworkGame;
		private bool enableGame;
		private bool[] endGameSync;

		
		#region System variants
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuItemSettings;
		private System.Windows.Forms.MenuItem menuItemView;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuFileNew;
		private System.Windows.Forms.MenuItem menuFileLoad;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuFileSaveAs;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuViewToolBar;
		private System.Windows.Forms.MenuItem menuViewStatusBar;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.MenuItem menuEditUndo;
		private System.Windows.Forms.MenuItem menuEditRedo;
		private System.Windows.Forms.MenuItem menuViewGameBoard;
		public System.Windows.Forms.ToolBarButton toolBarButtonNewGame;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.MenuItem menuSettingsPlayer2;
		private System.Windows.Forms.MenuItem menuSettingsPlayer1;
		private System.Windows.Forms.MenuItem menuSettingsP1Color;
		private System.Windows.Forms.MenuItem menuSettingsP1Name;
		private System.Windows.Forms.MenuItem menuSettingsP2Color;
		private System.Windows.Forms.MenuItem menuSettingsP2Name;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolBarButton toolBarButtonExit;
		private System.Windows.Forms.MenuItem menuSetGType4IR;
		private System.Windows.Forms.MenuItem menuSetGType5IR;
		private System.Windows.Forms.MenuItem menuSetGType6IR;
		private System.Windows.Forms.MenuItem menuSettingsGT;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolBarButton toolBarButtonSave;
		private System.Windows.Forms.ToolBarButton toolBarButtonOpen;
		private System.Windows.Forms.MenuItem menuSettingsBackPicture;
		private System.Windows.Forms.MenuItem menuSettingBackground;
		private System.Windows.Forms.MenuItem menuSettingsBackGroundColor;
		private System.Windows.Forms.ToolBarButton toolBarButtonUndo;
		private System.Windows.Forms.ToolBarButton toolBarButtonRedo;
		private System.Windows.Forms.ToolBarButton toolBarButtonAbout;
		private System.Windows.Forms.ToolBarButton toolBarButtonSep1;
		private System.Windows.Forms.ToolBarButton toolBarButtonSep2;
		private System.Windows.Forms.MenuItem menuSettingsShowStatus;
		private System.Windows.Forms.MenuItem menuNet;
		private System.Windows.Forms.MenuItem menuNetSettings;
		private System.Windows.Forms.MenuItem menuNetConnect;
		private System.Windows.Forms.MenuItem menuNetDisconnect;
		private System.Windows.Forms.MenuItem menuNetChat;
		private System.Windows.Forms.MenuItem menuFileLocalGame;
		private System.Windows.Forms.MenuItem menuFileNetworkGame;
		private System.Windows.Forms.ToolBarButton toolBarButtonNewNetGame;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuSettingsAnimate;
		private System.ComponentModel.IContainer components;
		#endregion

		public Game()
		{ 
			InitializeComponent();
			this.ResizeRedraw=true;
			this.env=new Environment(true);
			this.matrix=new GameMatrix();
			this.player1=new Player("Player1",Color.Fuchsia);
			this.player2=new Player("Player2",Color.Yellow);
			this.formatter = new BinaryFormatter();
			this.backPicture=new Bitmap("..\\..\\back.jpg");
			this.tBrush=new TextureBrush(this.backPicture);
			this.stb=new StatusBoard(player1.Name,player2.Name,"",true);
			this.isAnimating = false;
			this.isNetworkGame = false;
			this.endGameSync = new bool[2];
			this.stb.Show();
			this.Text="New "+matrix.VictoryType + " In A Row game";
			InitializeLocalGame();
		}

		#region Dispose 
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Game));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuFileNew = new System.Windows.Forms.MenuItem();
			this.menuFileLocalGame = new System.Windows.Forms.MenuItem();
			this.menuFileNetworkGame = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuFileLoad = new System.Windows.Forms.MenuItem();
			this.menuFileSave = new System.Windows.Forms.MenuItem();
			this.menuFileSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.menuEditUndo = new System.Windows.Forms.MenuItem();
			this.menuEditRedo = new System.Windows.Forms.MenuItem();
			this.menuItemSettings = new System.Windows.Forms.MenuItem();
			this.menuSettingsPlayer1 = new System.Windows.Forms.MenuItem();
			this.menuSettingsP1Color = new System.Windows.Forms.MenuItem();
			this.menuSettingsP1Name = new System.Windows.Forms.MenuItem();
			this.menuSettingsPlayer2 = new System.Windows.Forms.MenuItem();
			this.menuSettingsP2Color = new System.Windows.Forms.MenuItem();
			this.menuSettingsP2Name = new System.Windows.Forms.MenuItem();
			this.menuSettingsGT = new System.Windows.Forms.MenuItem();
			this.menuSetGType4IR = new System.Windows.Forms.MenuItem();
			this.menuSetGType5IR = new System.Windows.Forms.MenuItem();
			this.menuSetGType6IR = new System.Windows.Forms.MenuItem();
			this.menuSettingBackground = new System.Windows.Forms.MenuItem();
			this.menuSettingsBackPicture = new System.Windows.Forms.MenuItem();
			this.menuSettingsBackGroundColor = new System.Windows.Forms.MenuItem();
			this.menuSettingsAnimate = new System.Windows.Forms.MenuItem();
			this.menuNet = new System.Windows.Forms.MenuItem();
			this.menuNetSettings = new System.Windows.Forms.MenuItem();
			this.menuNetConnect = new System.Windows.Forms.MenuItem();
			this.menuNetDisconnect = new System.Windows.Forms.MenuItem();
			this.menuNetChat = new System.Windows.Forms.MenuItem();
			this.menuItemView = new System.Windows.Forms.MenuItem();
			this.menuViewToolBar = new System.Windows.Forms.MenuItem();
			this.menuViewStatusBar = new System.Windows.Forms.MenuItem();
			this.menuSettingsShowStatus = new System.Windows.Forms.MenuItem();
			this.menuViewGameBoard = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.panel = new System.Windows.Forms.Panel();
			this.toolBarButtonNewGame = new System.Windows.Forms.ToolBarButton();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.toolBarButtonNewNetGame = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonUndo = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonRedo = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonSep2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonExit = new System.Windows.Forms.ToolBarButton();
			this.toolBarButtonAbout = new System.Windows.Forms.ToolBarButton();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItemFile,
																					 this.menuEdit,
																					 this.menuItemSettings,
																					 this.menuNet,
																					 this.menuItemView,
																					 this.menuItemHelp,
																					 this.menuItem1});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuFileNew,
																						 this.menuItem3,
																						 this.menuFileLoad,
																						 this.menuFileSave,
																						 this.menuFileSaveAs,
																						 this.menuItem7,
																						 this.menuFileExit});
			this.menuItemFile.Text = "&File";
			this.menuItemFile.Select += new System.EventHandler(this.menuItemFile_Select);
			// 
			// menuFileNew
			// 
			this.menuFileNew.Index = 0;
			this.menuFileNew.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuFileLocalGame,
																						this.menuFileNetworkGame});
			this.menuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuFileNew.Text = "&New";
			// 
			// menuFileLocalGame
			// 
			this.menuFileLocalGame.Index = 0;
			this.menuFileLocalGame.Text = "&Local Game";
			this.menuFileLocalGame.Click += new System.EventHandler(this.menuFileLocalGame_Click);
			// 
			// menuFileNetworkGame
			// 
			this.menuFileNetworkGame.Index = 1;
			this.menuFileNetworkGame.Text = "&Network Game";
			this.menuFileNetworkGame.Click += new System.EventHandler(this.menuFileNetworkGame_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuFileLoad
			// 
			this.menuFileLoad.Index = 2;
			this.menuFileLoad.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.menuFileLoad.Text = "&Load";
			this.menuFileLoad.Click += new System.EventHandler(this.menuFileLoad_Click);
			// 
			// menuFileSave
			// 
			this.menuFileSave.Index = 3;
			this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuFileSave.Text = "&Save";
			this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
			// 
			// menuFileSaveAs
			// 
			this.menuFileSaveAs.Index = 4;
			this.menuFileSaveAs.Shortcut = System.Windows.Forms.Shortcut.F12;
			this.menuFileSaveAs.Text = "Save &As";
			this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 5;
			this.menuItem7.Text = "-";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 6;
			this.menuFileExit.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
			this.menuFileExit.Text = "&Exit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuEditUndo,
																					 this.menuEditRedo});
			this.menuEdit.Text = "&Edit";
			this.menuEdit.Select += new System.EventHandler(this.menuEdit_Select);
			// 
			// menuEditUndo
			// 
			this.menuEditUndo.Index = 0;
			this.menuEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
			this.menuEditUndo.Text = "&Undo";
			this.menuEditUndo.Click += new System.EventHandler(this.menuEditUndo_Click);
			// 
			// menuEditRedo
			// 
			this.menuEditRedo.Index = 1;
			this.menuEditRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
			this.menuEditRedo.Text = "&Redo";
			this.menuEditRedo.Click += new System.EventHandler(this.menuEditRedo_Click);
			// 
			// menuItemSettings
			// 
			this.menuItemSettings.Index = 2;
			this.menuItemSettings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.menuSettingsPlayer1,
																							 this.menuSettingsPlayer2,
																							 this.menuSettingsGT,
																							 this.menuSettingBackground,
																							 this.menuSettingsAnimate});
			this.menuItemSettings.Text = "&Settings";
			this.menuItemSettings.Select += new System.EventHandler(this.menuItemSettings_Select);
			// 
			// menuSettingsPlayer1
			// 
			this.menuSettingsPlayer1.Index = 0;
			this.menuSettingsPlayer1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.menuSettingsP1Color,
																								this.menuSettingsP1Name});
			this.menuSettingsPlayer1.Text = "Player 1";
			// 
			// menuSettingsP1Color
			// 
			this.menuSettingsP1Color.Index = 0;
			this.menuSettingsP1Color.Text = "&Color";
			this.menuSettingsP1Color.Click += new System.EventHandler(this.menuSettingsP1Color_Click);
			// 
			// menuSettingsP1Name
			// 
			this.menuSettingsP1Name.Index = 1;
			this.menuSettingsP1Name.Text = "&Name";
			this.menuSettingsP1Name.Click += new System.EventHandler(this.menuSettingsP1Name_Click);
			// 
			// menuSettingsPlayer2
			// 
			this.menuSettingsPlayer2.Index = 1;
			this.menuSettingsPlayer2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.menuSettingsP2Color,
																								this.menuSettingsP2Name});
			this.menuSettingsPlayer2.Text = "Player 2";
			// 
			// menuSettingsP2Color
			// 
			this.menuSettingsP2Color.Index = 0;
			this.menuSettingsP2Color.Text = "&Color";
			this.menuSettingsP2Color.Click += new System.EventHandler(this.menuSettingsP2Color_Click);
			// 
			// menuSettingsP2Name
			// 
			this.menuSettingsP2Name.Index = 1;
			this.menuSettingsP2Name.Text = "&Name";
			this.menuSettingsP2Name.Click += new System.EventHandler(this.menuSettingsP2Name_Click);
			// 
			// menuSettingsGT
			// 
			this.menuSettingsGT.Index = 2;
			this.menuSettingsGT.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuSetGType4IR,
																						   this.menuSetGType5IR,
																						   this.menuSetGType6IR});
			this.menuSettingsGT.Text = "&Game type";
			this.menuSettingsGT.Popup += new System.EventHandler(this.menuSettingsGT_Click);
			// 
			// menuSetGType4IR
			// 
			this.menuSetGType4IR.Index = 0;
			this.menuSetGType4IR.Text = "Win by 4";
			this.menuSetGType4IR.Click += new System.EventHandler(this.menuSetGType4IR_Click);
			// 
			// menuSetGType5IR
			// 
			this.menuSetGType5IR.Index = 1;
			this.menuSetGType5IR.Text = "Win by 5";
			this.menuSetGType5IR.Click += new System.EventHandler(this.menuSetGType5IR_Click);
			// 
			// menuSetGType6IR
			// 
			this.menuSetGType6IR.Index = 2;
			this.menuSetGType6IR.Text = "Win by 6";
			this.menuSetGType6IR.Click += new System.EventHandler(this.menuSetGType6IR_Click);
			// 
			// menuSettingBackground
			// 
			this.menuSettingBackground.Index = 3;
			this.menuSettingBackground.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								  this.menuSettingsBackPicture,
																								  this.menuSettingsBackGroundColor});
			this.menuSettingBackground.Text = "&Background";
			this.menuSettingBackground.Popup += new System.EventHandler(this.menuSettingBackground_Popup);
			// 
			// menuSettingsBackPicture
			// 
			this.menuSettingsBackPicture.Checked = true;
			this.menuSettingsBackPicture.Index = 0;
			this.menuSettingsBackPicture.Text = "Picture";
			this.menuSettingsBackPicture.Click += new System.EventHandler(this.menuSettingsBackPicture_Click);
			// 
			// menuSettingsBackGroundColor
			// 
			this.menuSettingsBackGroundColor.Index = 1;
			this.menuSettingsBackGroundColor.Text = "Background Color";
			this.menuSettingsBackGroundColor.Click += new System.EventHandler(this.menuSettingsBg_Click);
			// 
			// menuSettingsAnimate
			// 
			this.menuSettingsAnimate.Checked = true;
			this.menuSettingsAnimate.Index = 4;
			this.menuSettingsAnimate.Text = "Animate";
			this.menuSettingsAnimate.Click += new System.EventHandler(this.menuSettingsAnimate_Click);
			// 
			// menuNet
			// 
			this.menuNet.Index = 3;
			this.menuNet.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuNetSettings,
																					this.menuNetConnect,
																					this.menuNetDisconnect,
																					this.menuNetChat});
			this.menuNet.Text = "&Network";
			this.menuNet.Select += new System.EventHandler(this.menuNet_Select);
			// 
			// menuNetSettings
			// 
			this.menuNetSettings.Index = 0;
			this.menuNetSettings.Text = "&Settings";
			this.menuNetSettings.Click += new System.EventHandler(this.menuNetSettings_Click);
			// 
			// menuNetConnect
			// 
			this.menuNetConnect.Index = 1;
			this.menuNetConnect.Text = "&Connect";
			this.menuNetConnect.Click += new System.EventHandler(this.menuNetConnect_Click);
			// 
			// menuNetDisconnect
			// 
			this.menuNetDisconnect.Index = 2;
			this.menuNetDisconnect.Text = "&Disconnect";
			this.menuNetDisconnect.Click += new System.EventHandler(this.menuNetDisconnect_Click);
			// 
			// menuNetChat
			// 
			this.menuNetChat.Index = 3;
			this.menuNetChat.Shortcut = System.Windows.Forms.Shortcut.F11;
			this.menuNetChat.Text = "&Chat";
			this.menuNetChat.Click += new System.EventHandler(this.menuChat_Click);
			// 
			// menuItemView
			// 
			this.menuItemView.Index = 4;
			this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuViewToolBar,
																						 this.menuViewStatusBar,
																						 this.menuSettingsShowStatus,
																						 this.menuViewGameBoard});
			this.menuItemView.Text = "&View";
			this.menuItemView.Select += new System.EventHandler(this.menuItemView_Select);
			// 
			// menuViewToolBar
			// 
			this.menuViewToolBar.Checked = true;
			this.menuViewToolBar.Index = 0;
			this.menuViewToolBar.Text = "Toolbar";
			this.menuViewToolBar.Click += new System.EventHandler(this.menuViewToolBar_Click);
			// 
			// menuViewStatusBar
			// 
			this.menuViewStatusBar.Checked = true;
			this.menuViewStatusBar.Index = 1;
			this.menuViewStatusBar.Text = "Status Bar";
			this.menuViewStatusBar.Click += new System.EventHandler(this.menuViewStatusBar_Click);
			// 
			// menuSettingsShowStatus
			// 
			this.menuSettingsShowStatus.Checked = true;
			this.menuSettingsShowStatus.Index = 2;
			this.menuSettingsShowStatus.Text = "&Show Status";
			this.menuSettingsShowStatus.Click += new System.EventHandler(this.menuSettingsShowStatus_Click);
			// 
			// menuViewGameBoard
			// 
			this.menuViewGameBoard.Index = 3;
			this.menuViewGameBoard.Text = "Hide Game Board";
			this.menuViewGameBoard.Click += new System.EventHandler(this.menuViewGameBoard_Click);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Index = 5;
			this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuHelpAbout});
			this.menuItemHelp.Text = "&Help";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 0;
			this.menuHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuHelpAbout.Text = "&About";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 6;
			this.menuItem1.Text = "";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 288);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(384, 22);
			this.statusBar.TabIndex = 1;
			this.statusBar.Text = "Welcome";
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.Color.Transparent;
			this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 25);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(384, 263);
			this.panel.TabIndex = 2;
			this.panel.Resize += new System.EventHandler(this.panel_Resize);
			this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
			this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
			this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
			// 
			// toolBarButtonNewGame
			// 
			this.toolBarButtonNewGame.ImageIndex = 0;
			this.toolBarButtonNewGame.Tag = this.menuFileLocalGame;
			this.toolBarButtonNewGame.ToolTipText = "New Game";
			// 
			// toolBar
			// 
			this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar.BackColor = System.Drawing.SystemColors.Info;
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					   this.toolBarButtonNewGame,
																					   this.toolBarButtonNewNetGame,
																					   this.toolBarButtonSave,
																					   this.toolBarButtonOpen,
																					   this.toolBarButtonSep1,
																					   this.toolBarButtonUndo,
																					   this.toolBarButtonRedo,
																					   this.toolBarButtonSep2,
																					   this.toolBarButtonExit,
																					   this.toolBarButtonAbout});
			this.toolBar.ButtonSize = new System.Drawing.Size(30, 30);
			this.toolBar.Divider = ((bool)(configurationAppSettings.GetValue("toolBar.Divider", typeof(bool))));
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList;
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(384, 25);
			this.toolBar.TabIndex = 0;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// toolBarButtonNewNetGame
			// 
			this.toolBarButtonNewNetGame.ImageIndex = 7;
			this.toolBarButtonNewNetGame.Tag = this.menuFileNetworkGame;
			this.toolBarButtonNewNetGame.ToolTipText = "New Network game";
			// 
			// toolBarButtonSave
			// 
			this.toolBarButtonSave.ImageIndex = 6;
			this.toolBarButtonSave.Tag = this.menuFileSave;
			this.toolBarButtonSave.ToolTipText = "Save Game";
			// 
			// toolBarButtonOpen
			// 
			this.toolBarButtonOpen.ImageIndex = 4;
			this.toolBarButtonOpen.Tag = this.menuFileLoad;
			this.toolBarButtonOpen.ToolTipText = "Load Game";
			// 
			// toolBarButtonSep1
			// 
			this.toolBarButtonSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonUndo
			// 
			this.toolBarButtonUndo.ImageIndex = 5;
			this.toolBarButtonUndo.Tag = this.menuEditUndo;
			this.toolBarButtonUndo.ToolTipText = "Undo last move";
			// 
			// toolBarButtonRedo
			// 
			this.toolBarButtonRedo.ImageIndex = 3;
			this.toolBarButtonRedo.Tag = this.menuEditRedo;
			this.toolBarButtonRedo.ToolTipText = "Redo last move";
			// 
			// toolBarButtonSep2
			// 
			this.toolBarButtonSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButtonExit
			// 
			this.toolBarButtonExit.ImageIndex = 2;
			this.toolBarButtonExit.Tag = this.menuFileExit;
			this.toolBarButtonExit.ToolTipText = "Exit Game";
			// 
			// toolBarButtonAbout
			// 
			this.toolBarButtonAbout.ImageIndex = 1;
			this.toolBarButtonAbout.Tag = this.menuHelpAbout;
			this.toolBarButtonAbout.ToolTipText = "About";
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileName = "Game";
			this.saveFileDialog.Filter = "Game files|*.sav|All files|*.*";
			this.saveFileDialog.Title = "Save current game state";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "Game";
			this.openFileDialog.Filter = "Game files|*.sav|All files|*.*";
			this.openFileDialog.Title = "Load 4 In A Row game";
			// 
			// Game
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Menu;
			this.ClientSize = new System.Drawing.Size(384, 310);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel,
																		  this.statusBar,
																		  this.toolBar});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "Game";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "4 In A Row Game";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]

		static void Main() 
		{
			Application.Run(new Game());
		}

		#region Panel Drawing functions

		private void panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics grfx;
			Bitmap bmp;
			bmp = new Bitmap (panel.ClientSize.Width+1, panel.ClientSize.Height+1);
			grfx = Graphics.FromImage (bmp);
			grfx.Clear(panel.BackColor);
			FillBackGround(panel.ClientRectangle,grfx);
			FillGameBord(GetGameBordArea(),grfx);
			if(!this.isAnimating)
				ShowVictory(grfx);
			e.Graphics.DrawImage (bmp, 0, 0);
			grfx.Dispose();
		}
		private void panel_Resize(object sender, System.EventArgs e)
		{
			Graphics g=panel.CreateGraphics(); 
			PaintEventArgs pea=new PaintEventArgs(g,panel.ClientRectangle);
			this.panel_Paint(this.panel,pea);			
			g.Dispose();
		}

		public void UpdateCurrentRectangle(Rectangle uRect)
		{
			Graphics grfx=panel.CreateGraphics();
			PaintEventArgs pea=new PaintEventArgs(grfx,uRect);
			if(!this.menuSettingsAnimate.Checked)
				this.panel_Paint(this,pea);
			else
				this.AnimateMove(ref grfx);	
			grfx.Dispose();
		}

		private void AnimateMove(ref Graphics grfx)
		{
			this.statusBar.Text = "Animating";
			this.isAnimating = true;
			Graphics tGrfx;
			Bitmap panelBitmap = new Bitmap(this.panel.Width+1,panel.Height+1);
			Bitmap animBitmap = new Bitmap(this.panel.Width+1,panel.Height+1);
			Bitmap backBitmap = new Bitmap(this.panel.Width+1,panel.Height+1);
			tGrfx = Graphics.FromImage(panelBitmap);
			Player.SwapBrush();
			this.panel_Paint(this,new PaintEventArgs(tGrfx,this.panel.ClientRectangle));
			Player.SwapBrush();
			tGrfx.Dispose();
			panelBitmap.MakeTransparent(Color.White);
			this.panel.Cursor = Cursors.WaitCursor;
			DropChip(grfx,tGrfx,panelBitmap,animBitmap,backBitmap);
			this.panel.Cursor = Cursors.Arrow;
			this.isAnimating = false;
			this.panel_Resize(this,EventArgs.Empty);
			this.statusBar.Text = "Ready";
		}

		private void DropChip(Graphics screen, Graphics mem, Bitmap frontPic, Bitmap middlePic, Bitmap backPic)
		{
			int x = GetCurrentRectangle(this.matrix.LastUsedCell).Left;
			int y = GetGameBordArea().Top;
			int limit = GetCurrentRectangle(this.matrix.LastUsedCell).Bottom;
			int width = GetCurrentRectangle(this.matrix.LastUsedCell).Width;
			Rectangle cr = new Rectangle(x,y,width,width);
			while(cr.Bottom<=limit)
			{
				mem = Graphics.FromImage(middlePic);
				Player.SwapBrush();
				mem.FillRectangle(Player.DefualtBrush(),0,0,this.panel.Width+1,panel.Height+1);
				if(this.env.Turn)
					mem.FillEllipse(player1.CBrush,cr);
				else
					mem.FillEllipse(player2.CBrush,cr);
				mem.DrawImage(frontPic,0,0,this.panel.Width+1,panel.Height+1);
				Player.SwapBrush();
				middlePic.MakeTransparent(Color.White);	
				mem.Dispose();
				mem = Graphics.FromImage(backPic);
				mem.FillRectangle(Player.DefualtBrush(),0,0,this.panel.Width+1,panel.Height+1);
				mem.DrawImage(middlePic,0,0,this.panel.Width+1,panel.Height+1);
				screen.DrawImage(backPic,0,0,this.panel.Width+1,this.panel.Height+1);
				mem.Dispose();
				cr.Y+=width;
			}
		
		}
	
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			this.menuNetDisconnect.PerformClick();
		}

		#endregion
		
		#region Game Maneging functions

		public void InitializeLocalGame()
		{
			if(this.netService != null)
				this.netService.DisposeChat();
			this.path=null;
			this.modifyFlag=false;
			matrix.Reset();
			env.InitializeEnvironment(true);
			panel.BackColor=env.PBackGround;
			stb.CurrentTurn=env.Turn;
			this.Text="New "+matrix.VictoryType + " In A Row game";
			this.isNetworkGame = false;
			this.EnableGame = true;
			this.menuNet.Enabled = false;
			this.toolBarButtonOpen.Enabled = true;
			this.toolBarButtonSave.Enabled = true;
			this.toolBarButtonRedo.Enabled = true;
			this.toolBarButtonUndo.Enabled = true;
			this.panel_Resize(this,EventArgs.Empty);
		}

		public void InitializeNetworkGame()
		{
			this.panel_Resize(this,EventArgs.Empty);
			this.isNetworkGame = true;
			this.menuNet.Enabled = true;
			this.menuSettingsGT.Enabled = false;
			this.enableGame = false;
			env.InitializeEnvironment(true);
			matrix.Reset();
			panel.BackColor=env.PBackGround;
			stb.CurrentTurn=env.Turn;
			this.matrix.GameWinType = 4;
			this.toolBarButtonOpen.Enabled = false;
			this.toolBarButtonSave.Enabled = false;
			this.toolBarButtonRedo.Enabled = false;
			this.toolBarButtonUndo.Enabled = false;
			this.panel_Resize(this,EventArgs.Empty);
		}
		
		public Rectangle GetGameBordArea()
		{
			int ribSize,x1,y1;
			if(panel.Height>panel.Width)
				ribSize=panel.Width;
			else
				ribSize=panel.Height;
			ribSize-=20;
			x1=(panel.Width/2)-(ribSize/2);
			y1=(panel.Height/2)-(ribSize/2);
			return new Rectangle(x1,y1,ribSize,ribSize);
		}

		public Rectangle GetCurrentRectangle(Point p)
		{
			Rectangle r=GetGameBordArea();
			return new Rectangle(r.X+(p.Y*env.Rad)+env.Shift,r.Y+(p.X*env.Rad)+env.Dy+env.Shift,env.Rad-env.Shift,env.Rad-env.Shift);
		}
		
		public void FillBackGround(Rectangle GameArea,Graphics g)
		{
			if(env.ImageFlag)
				g.FillRectangle(tBrush,GameArea);
		}

		public void FillGameBord(Rectangle GameArea,Graphics g)
		{
			env.Dy=((GameArea.Height)/7)/2;
			env.Rad=(int)GameArea.Width/7;
			Pen p=new Pen(Color.DarkGray,3);
			for(int i=0;i<6 && (GameArea.Width>40);i++)
				for(int j=0;j<7;j++)
				{
					if(this.isAnimating && (this.matrix.LastUsedCell.X == i) && (this.matrix.LastUsedCell.Y == j))
					{
						g.FillEllipse(Player.DefualtBrush(),GameArea.Left+(j*env.Rad)+env.Shift,GameArea.Top+(i*env.Rad)+env.Dy+env.Shift,env.Rad-env.Shift,env.Rad-env.Shift);
						continue;
					}
					if(matrix.GetBorg(i,j)==1)
						g.FillEllipse(player1.CBrush,GameArea.Left+(j*env.Rad)+env.Shift,GameArea.Top+(i*env.Rad)+env.Dy+env.Shift,env.Rad-env.Shift,env.Rad-env.Shift);
					if(matrix.GetBorg(i,j)==2)
						g.FillEllipse(player2.CBrush,GameArea.Left+(j*env.Rad)+env.Shift,GameArea.Top+(i*env.Rad)+env.Dy+env.Shift,env.Rad-env.Shift,env.Rad-env.Shift);
					if(matrix.GetBorg(i,j)==0)
						g.FillEllipse(Player.DefualtBrush(),GameArea.Left+(j*env.Rad)+env.Shift,GameArea.Top+(i*env.Rad)+env.Dy+env.Shift,env.Rad-env.Shift,env.Rad-env.Shift);
					g.DrawEllipse(p,GameArea.Left+(j*env.Rad)+env.Shift,GameArea.Top+(i*env.Rad)+env.Dy+env.Shift,env.Rad-env.Shift,env.Rad-env.Shift);
				}
			p.Dispose();
		}

		public void ShowVictory(Graphics g)
		{
			if(matrix.IsWinner>0 && matrix.IsWinner<=3)
			{
				Pen p=new Pen(Brushes.DeepSkyBlue,3);
				Rectangle updateRect;
				for(int i=0;i<matrix.GameWinType;i++)
				{
					updateRect=GetCurrentRectangle(matrix.GetVictoryPath(i));
					updateRect.Inflate(1,1);
					g.DrawEllipse(p,updateRect);
				}
			}
		}
		#endregion

		#region Game playing

		private void panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int col;
			bool netFlag = false;
			bool flag = true;

			if(!this.enableGame)
				return;

			if(this.isNetworkGame==true && this.enableGame==true)
			{
				if((this.netService.IsHosting && !this.env.Turn) || (!this.netService.IsHosting && this.env.Turn))
					flag = false;
				else
					netFlag = true;
			}
			else
				if(this.isNetworkGame)
					flag = false;

			Point click=new Point(e.X,e.Y);
			Rectangle gameArea=GetGameBordArea();
			gameArea.Inflate(0,-env.Dy);
			gameArea.Y+=env.Shift;
			gameArea.Height-=(env.Shift+1);
			if(gameArea.Contains(click) && e.Button==MouseButtons.Left)
			{
				col=(click.X-gameArea.Left)/env.Rad;
				gameArea.X+=((env.Rad*col)+env.Shift);
				gameArea.Width=(env.Rad-env.Shift);
				if(gameArea.Contains(click) && flag)
					ExecuteTurn(col,netFlag);
			}
		}
		
		private void panel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int col,row;
			Point mp=new Point(e.X,e.Y);
			Rectangle gameArea=GetGameBordArea();
			gameArea.Inflate(0,-env.Dy);
			gameArea.Y+=env.Shift;
			gameArea.Height-=(env.Shift+1);
			if(gameArea.Contains(mp))
			{
				col=(mp.X-gameArea.Left)/env.Rad;
				row=(mp.Y-gameArea.Top)/env.Rad;
				gameArea.X+=((env.Rad*col)+env.Shift);
				gameArea.Width=(env.Rad-env.Shift);
				if(gameArea.Contains(mp))
				{
					row=6-row;
					col=col+1;
					stb.CurrentMousePosition="Position [x="+row+",y="+col+"]";
				}
			}
			else
				stb.CurrentMousePosition="Out of range";
		}

		private void Game_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			bool netFlag = false;
			bool flag = true;

			if(!this.enableGame)
				return;

			if(this.isNetworkGame==true && this.enableGame==true)
			{
				if((this.netService.IsHosting && !this.env.Turn) || (!this.netService.IsHosting && this.env.Turn))
					flag = false;
				else
					netFlag = true;
			}
			else
				if(this.isNetworkGame)
				flag = false;


			if(e.KeyCode>Keys.D0 && e.KeyCode<Keys.D8)
				if(flag)
					ExecuteTurn(e.KeyValue-49,netFlag);
		}

		public void ExecuteTurn(int col,bool netFlag)
		{
			bool matCheckedOk = false;

			if(!isNetworkGame)
				this.modifyFlag=true;
	
			if(env.Turn)
			{
				if(matrix.SetBord(col,1,true))
				{
					if(netFlag)
						this.netService.Send((int)DataType.move,col);
					matrix.CheckVictory(1);
					matCheckedOk = true;
				}
			}
			else
			{
				if(matrix.SetBord(col,2,true))
				{
					if(netFlag)
						this.netService.Send((int)DataType.move,col);
					matrix.CheckVictory(2);
					matCheckedOk = true;
				}
			}
			
			if(matrix.IsWinner==0 && matCheckedOk)
			{
				this.UpdateCurrentRectangle(GetCurrentRectangle(matrix.LastUsedCell));
				env.Turn=!env.Turn;
				stb.CurrentTurn=!stb.CurrentTurn;
			}
			else
				if(matCheckedOk)
				{
					this.UpdateCurrentRectangle(GetCurrentRectangle(matrix.LastUsedCell));
					if(env.Turn && matrix.IsWinner==1)
						AnnounceVictory(1);
					else
						if(!env.Turn && matrix.IsWinner==1)
						AnnounceVictory(2);
					else
						AnnounceVictory(matrix.IsWinner);
				}
		}

		public void AnnounceVictory(int endState)
		{
			this.enableGame = false;
			this.EndGameSyncNear = false;
			this.EndGameSyncFar = false;
			DialogResult result = DialogResult.Cancel;

			if(endState==1)
				result = MessageBox.Show(player1.Name+" Has won the game","Winner",MessageBoxButtons.OK,MessageBoxIcon.Information);
			if(endState==2)
				result = MessageBox.Show(player2.Name+" Has won the game","Winner",MessageBoxButtons.OK,MessageBoxIcon.Information);
			if(endState==4)
				result = MessageBox.Show("No one win's it's a Drow","A Drow",MessageBoxButtons.OK,MessageBoxIcon.Information);

			this.panel_Resize(this,EventArgs.Empty);
			if (result == DialogResult.OK)
				if(this.isNetworkGame && (this.netService != null) && this.netService.IsOnline)
				{
					this.InitializeNetworkGame();
					this.EndGameSyncNear = true;
					this.netService.Send((int)DataType.endGame,NetService.requestInitializeString);
					if(this.netService.IsHosting && this.endGameSync[1])
						this.netService.Send((int)DataType.endGame,NetService.initializeString);
					else 
						this.statusBar.Text = "Waiting for other side to finish playing";
				}
				else
					InitializeLocalGame();
		}

		#endregion

		#region Main Menu Functions

		private void menuViewToolBar_Click(object sender, System.EventArgs e)
		{
			this.toolBar.Visible=!this.toolBar.Visible;
		}
		
		private void menuViewStatusBar_Click(object sender, System.EventArgs e)
		{
			this.statusBar.Visible=!this.statusBar.Visible;
		}

		private void menuViewGameBoard_Click(object sender, System.EventArgs e)
		{
			this.panel.Visible=!this.panel.Visible;
			if(this.panel.Visible)
				menuViewGameBoard.Text="Hide Game Board";
			else
				menuViewGameBoard.Text="View Game Board";
			
		}

		private void menuItemView_Select(object sender, System.EventArgs e)
		{
			if(this.toolBar.Visible)
				this.menuViewToolBar.Checked=true;
			else
				this.menuViewToolBar.Checked=false;
			if(this.statusBar.Visible)
				this.menuViewStatusBar.Checked=true;
			else
				this.menuViewStatusBar.Checked=false;

		}

		private void menuEditUndo_Click(object sender, System.EventArgs e)
		{
			Point p=matrix.UndoLast;
			if(p.X!=-1)
			{
				env.Turn=!env.Turn;
				this.UpdateCurrentRectangle(GetCurrentRectangle(p));
			}
		}

		private void menuEditRedo_Click(object sender, System.EventArgs e)
		{
			Point p=matrix.RedoLast;
			if(p.X!=-1)
			{
				if(env.Turn)
					matrix.SetBord(p.Y,1,false);
				else
					matrix.SetBord(p.Y,2,false);
				this.panel_Resize(this,EventArgs.Empty);
				this.UpdateCurrentRectangle(GetCurrentRectangle(p));
				env.Turn=!env.Turn;
			}
		}

		private void menuEdit_Select(object sender, System.EventArgs e)
		{
			if(this.isNetworkGame)
			{
				this.menuEditUndo.Enabled = false;
				this.menuEditRedo.Enabled = false;
				return;
			}
			if(matrix.DiskCounter==0)
				menuEditUndo.Enabled=false;
			else
				menuEditUndo.Enabled=true;
			if(matrix.IsRedoable==0)
				menuEditRedo.Enabled=false;
			else
				menuEditRedo.Enabled=true;
		}
		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			while((this.Opacity-=0.2)>0);
			this.menuNetDisconnect.PerformClick();
			Application.Exit();
		}
	
		private void menuItemSettings_Select(object sender, System.EventArgs e)
		{
			menuSettingsPlayer1.Text=player1.Name;
			menuSettingsPlayer2.Text=player2.Name;
		}
	
		private void menuSettingsP1Color_Click(object sender, System.EventArgs e)
		{
			int flag=0;
			ColorDialog dlg=new ColorDialog();
			dlg.Color=player1.CColor;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				if(dlg.Color==player2.CColor)
					flag=1;
				if(dlg.Color==panel.BackColor)
					flag=2;

				if(dlg.Color == Color.White)
				{
					MessageBox.Show("You can not choose white colors","Error",MessageBoxButtons.OK,MessageBoxIcon.Question);
					return;
				}
				if(flag==0)
				{
					player1.SetPlayerBrush=dlg.Color;
					this.panel_Resize(this,EventArgs.Empty);
				}
				else
				{
					if(flag==1)
						MessageBox.Show("This color is already assigned to "+player2.Name,"Error",MessageBoxButtons.OK,MessageBoxIcon.Question);
					else
						MessageBox.Show("This color is already assigned to the background","Error",MessageBoxButtons.OK,MessageBoxIcon.Question);
				}
			}
		}

		private void menuSettingsP2Color_Click(object sender, System.EventArgs e)
		{
			int flag=0;
			ColorDialog dlg=new ColorDialog();
			dlg.Color=player2.CColor;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				if(dlg.Color==player1.CColor)
					flag=1;
				if(dlg.Color==panel.BackColor)
					flag=2;
				if(dlg.Color == Color.White)
				{
					MessageBox.Show("You can not choose white colors","Error",MessageBoxButtons.OK,MessageBoxIcon.Question);
					return;
				}
				if(flag==0)
				{
					player2.SetPlayerBrush=dlg.Color;
					this.panel_Resize(this,EventArgs.Empty);
				}
				else
				{
					if(flag==1)
						MessageBox.Show("This color is already assigned to "+player1.Name,"Error",MessageBoxButtons.OK,MessageBoxIcon.Question);
					else
						MessageBox.Show("This color is already assigned to the background","Error",MessageBoxButtons.OK,MessageBoxIcon.Question);
				}
			}
		}
	
        private void menuSettingsBg_Click(object sender, System.EventArgs e)
		{
			ColorDialog dlg=new ColorDialog();
			dlg.Color=env.PBackGround;
			if(dlg.ShowDialog()==DialogResult.OK)
			{
				if(dlg.Color == Color.White)
					return;
				if(dlg.Color!=player1.CColor && dlg.Color!=player2.CColor)
				{
					panel.BackColor=dlg.Color;
					env.PBackGround=dlg.Color;
					statusBar.Text="Color Changed";
					this.UpdateCurrentRectangle(GetGameBordArea());
				}
				else
					MessageBox.Show("This color is already assigned to on of the players",
						"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		private void menuSettingsBackPicture_Click(object sender, System.EventArgs e)
		{
			env.ImageFlag=!env.ImageFlag;
			this.panel_Resize(this,EventArgs.Empty);
		}

		private void menuSettingBackground_Popup(object sender, System.EventArgs e)
		{
			this.menuSettingsBackPicture.Checked=env.ImageFlag;
			this.menuSettingsBackGroundColor.Enabled=!env.ImageFlag;
		}

		private void menuSettingsAnimate_Click(object sender, System.EventArgs e)
		{
			this.menuSettingsAnimate.Checked =! this.menuSettingsAnimate.Checked;
		}

		private void menuSettingsP1Name_Click(object sender, System.EventArgs e)
		{
			if(this.isNetworkGame && this.netService != null && !this.netService.IsHosting)
			{
				MessageBox.Show("You can not chane Server player name","Error",MessageBoxButtons.OK,MessageBoxIcon.Hand);
				return;
			}																				 																			  
			NameDialog dlg=new NameDialog();
			dlg.NewName=player1.Name;
			if(dlg.ShowDialog()==DialogResult.OK)
				if(dlg.NewName==player2.Name)
					MessageBox.Show("Hey this is my name !!!",player2.Name,MessageBoxButtons.OK,MessageBoxIcon.Hand);
				else
				{
					player1.Name=dlg.NewName;
					stb.NameP1=dlg.NewName;
					if(this.isNetworkGame && this.netService != null)
						this.netService.Send((int)DataType.name,dlg.NewName);
				}
		}

		private void menuSettingsP2Name_Click(object sender, System.EventArgs e)
		{
			if(this.isNetworkGame && this.netService != null && this.netService.IsHosting)
			{
				MessageBox.Show("You can not chane Client player name","Error",MessageBoxButtons.OK,MessageBoxIcon.Hand);
				return;
			}		
			NameDialog dlg=new NameDialog();
			dlg.NewName=player2.Name;
			if(dlg.ShowDialog()==DialogResult.OK)
				if(dlg.NewName==player1.Name)
					MessageBox.Show("Hey this is my name !!!",player1.Name,MessageBoxButtons.OK,MessageBoxIcon.Hand);
				else
				{
					player2.Name=dlg.NewName;
					stb.NameP2=dlg.NewName;
					if(this.isNetworkGame && this.netService != null)
						this.netService.Send((int)DataType.name,dlg.NewName);
				}
		}

		private void menuFileLocalGame_Click(object sender, System.EventArgs e)
		{
			if(this.netService != null && this.netService.IsListening)
				MessageBox.Show("Please Disconnect first","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			else
				InitializeLocalGame();
		}

		private void menuFileNetworkGame_Click(object sender, System.EventArgs e)
		{
			if(this.netService != null && this.netService.IsListening)
				MessageBox.Show("Please Disconnect first","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			else
			{
				this.enableGame = false;
				InitializeNetworkGame();
			}
		}

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			AboutDialog dlg=new AboutDialog();
			dlg.ShowDialog();
		}
		
		
		private void menuSetGType4IR_Click(object sender, System.EventArgs e)
		{
			if(matrix.VictoryType==4)
				statusBar.Text="Game type is already set to - Win by 4";
			else
			{
				statusBar.Text="Game type was set to - Win by 4";
				this.Text="4 In A Row game";
				matrix.VictoryType=4;
				this.menuFileNew.PerformClick();
			}
		}

		private void menuSetGType5IR_Click(object sender, System.EventArgs e)
		{
			if(matrix.VictoryType==5)
				statusBar.Text="Game type is already set to - Win by 5";
			else
			{
				statusBar.Text="Game type was set to - Win by 5";
				this.Text="5 In A Row game";
				matrix.VictoryType=5;
				this.menuFileNew.PerformClick();
			}
		}

		private void menuSetGType6IR_Click(object sender, System.EventArgs e)
		{
			if(matrix.VictoryType==6)
				statusBar.Text="Game type is already set to - Win by 6";
			else
			{
				statusBar.Text="Game type was set to - Win by 6";
				this.Text="6 In A Row game";
				matrix.VictoryType=6;
				this.menuFileNew.PerformClick();
			}
		}

		private void menuSettingsGT_Click(object sender, System.EventArgs e)
		{
			this.menuSetGType4IR.Checked= matrix.VictoryType==4;
			this.menuSetGType5IR.Checked= matrix.VictoryType==5;
			this.menuSetGType6IR.Checked= matrix.VictoryType==6;
		}
		private void menuSettingsShowStatus_Click(object sender, System.EventArgs e)
		{
			this.menuSettingsShowStatus.Checked=!this.menuSettingsShowStatus.Checked;
			stb.Visible=!stb.Visible;
		}

		#endregion

		#region ToolBar Functions
		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			((MenuItem)e.Button.Tag).PerformClick();
		}
		#endregion

		#region Game Load\Save functions
		
		private void menuItemFile_Select(object sender, System.EventArgs e)
		{
			menuFileSave.Enabled=this.modifyFlag;
			this.menuFileLoad.Enabled = !this.isNetworkGame;
			this.menuFileSave.Enabled = !this.isNetworkGame;
			this.menuFileSaveAs.Enabled = !this.isNetworkGame;
		}
		
		private void menuFileSave_Click(object sender, System.EventArgs e)
		{
			if(this.modifyFlag && this.path==null)
				this.menuFileSaveAs_Click(this,e);
			else
				if(this.modifyFlag)
					saveGame();
		}

		private void menuFileSaveAs_Click(object sender, System.EventArgs e)
		{
			if(this.saveFileDialog.ShowDialog()==DialogResult.OK)
			{
				this.path=saveFileDialog.FileName;
				saveGame();
			}
		}

		private void menuFileLoad_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog.ShowDialog()==DialogResult.OK)
			{
				try
				{
					Stream stream=openFileDialog.OpenFile();
					this.path=openFileDialog.FileName;
					player1=(Player)formatter.Deserialize(stream);
					player2=(Player)formatter.Deserialize(stream);
					player1.SetPlayerBrush=player1.CColor;
					player2.SetPlayerBrush=player2.CColor;
					matrix=(GameMatrix)formatter.Deserialize(stream);
					env=(Environment)formatter.Deserialize(stream);
					stream.Close();
					
					// Additional settings 
					panel.BackColor=env.PBackGround;
					this.Text=this.path;
					stb.CurrentTurn=env.Turn;
					stb.NameP1=player1.Name;
					stb.NameP2=player2.Name;
					stb.CurrentMousePosition="";
					this.panel_Resize(this,EventArgs.Empty);
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}

		public void saveGame()
		{
			try
			{
				FileStream stream=new FileStream(this.path,FileMode.Create,FileAccess.Write);
				formatter.Serialize(stream,player1);
				formatter.Serialize(stream,player2);
				formatter.Serialize(stream,matrix);
				formatter.Serialize(stream,env);
				stream.Close();
                this.modifyFlag=false;
				this.Text=this.path;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		#endregion

		#region Network : Porperties, Functions, Events

		private void menuNetSettings_Click(object sender, System.EventArgs e)
		{
			if(this.netService != null)
			{
				this.netService.Stop();
				this.netService.DisposeChat();
			}
			this.netService = NetService.Create(this);
		}

		private void menuNetConnect_Click(object sender, System.EventArgs e)
		{
			if(this.netService.IsHosting)
				this.Text="New "+matrix.VictoryType + " In A Row game - Server";
			else
				this.Text="New "+matrix.VictoryType + " In A Row game - Client";
			this.InitializeNetworkGame();
			this.netService.Start();
			this.menuNetChat.Enabled = true;
		}

		private void menuNetDisconnect_Click(object sender, System.EventArgs e)
		{
			if(this.netService != null)
				this.netService.Stop();
			this.Text="New "+matrix.VictoryType + " In A Row game";
			this.InitializeNetworkGame();
			this.isNetworkGame = false;
			this.enableGame = false;
		}

		private void menuNet_Select(object sender, System.EventArgs e)
		{
			if ( this.netService != null )
			{
				this.menuNetConnect.Enabled = !this.netService.IsListening;
				this.menuNetDisconnect.Enabled = this.netService.IsListening;
				if(this.netService != null && this.netService.Chat != null)
					this.menuNetChat.Checked = this.netService.Chat.Visible;
			}
			else
			{
				this.menuNetConnect.Enabled = false;
				this.menuNetDisconnect.Enabled = false;
				this.menuNetChat.Enabled=false;
				this.menuNetSettings.Enabled = this.isNetworkGame;
			}

		}

		private void menuChat_Click(object sender, System.EventArgs e)
		{
			this.netService.Chat.Visible = !this.netService.Chat.Visible;
		}

		public Player Player1
		{
			get
			{
				return this.player1;
			}
		}

		public Player Player2
		{
			get
			{
				return this.player2;
			}
		}

		public NetService NetService 
		{
			get 
			{
				return this.netService;
			}
		}

		public GameMatrix Matrix
		{
			get
			{
				return this.matrix;
			}
		}

		public Environment Env
		{
			get 
			{
				return this.env;
			}
		}

		public bool EnableGame
		{
			set
			{
				this.enableGame = value ; 
			}
		}

		public StatusBoard Stb
		{
			get
			{
				return this.stb;
			}
		}
		
		public bool EndGameSyncNear
		{
			get 
			{
				return this.endGameSync[0];
			}
			set
			{
				this.endGameSync[0] = value;
			}
		}

		public bool EndGameSyncFar
		{
			get 
			{
				return this.endGameSync[1];
			}
			set
			{
				this.endGameSync[1] = value;
			}
		}

		public StatusBar statBar
		{
			get
			{
				return this.statusBar;
			}
		}

		#endregion
	
	}
}  
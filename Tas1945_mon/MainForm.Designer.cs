
namespace Tas1945_mon
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent ()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tpTas1945Ctrl = new System.Windows.Forms.TabPage();
            this.cbDark_Apply = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbMaxFrame = new System.Windows.Forms.Label();
            this.lbFrames = new System.Windows.Forms.Label();
            this.nudCsvSaveCnt = new System.Windows.Forms.NumericUpDown();
            this.rbTestPixel = new System.Windows.Forms.RadioButton();
            this.rbChartPixel = new System.Windows.Forms.RadioButton();
            this.tgsCsvSave = new JCS.ToggleSwitch();
            this.gbPixel = new System.Windows.Forms.GroupBox();
            this.tgsRefVal = new JCS.ToggleSwitch();
            this.nudSetCenterValue = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbDark_Y_Offset = new System.Windows.Forms.RadioButton();
            this.nudDark_Y = new System.Windows.Forms.NumericUpDown();
            this.nudPixelMeasure = new System.Windows.Forms.NumericUpDown();
            this.nudDark_X = new System.Windows.Forms.NumericUpDown();
            this.rbAvrOffset = new System.Windows.Forms.RadioButton();
            this.rbDark_X_Offset = new System.Windows.Forms.RadioButton();
            this.rbOffsetDisable = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nudMinVal = new System.Windows.Forms.NumericUpDown();
            this.nudMaxVal = new System.Windows.Forms.NumericUpDown();
            this.btnChartClear = new System.Windows.Forms.Button();
            this.rbSetPixel5 = new System.Windows.Forms.RadioButton();
            this.rbSetPixel4 = new System.Windows.Forms.RadioButton();
            this.rbSetPixel3 = new System.Windows.Forms.RadioButton();
            this.rbSetPixel2 = new System.Windows.Forms.RadioButton();
            this.rbSetPixel1 = new System.Windows.Forms.RadioButton();
            this.btnPixelChartShow = new System.Windows.Forms.Button();
            this.gbSingleRead = new System.Windows.Forms.GroupBox();
            this.tgsPushSkip = new JCS.ToggleSwitch();
            this.btnReadPushMode = new System.Windows.Forms.Button();
            this.gbAverage = new System.Windows.Forms.GroupBox();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbMoveAvr = new System.Windows.Forms.RadioButton();
            this.rbGuiAvr = new System.Windows.Forms.RadioButton();
            this.rbFpgaAvr = new System.Windows.Forms.RadioButton();
            this.nudAvrCnt = new System.Windows.Forms.NumericUpDown();
            this.rbOddEvenToggle = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.tgsContinue = new JCS.ToggleSwitch();
            this.rbSingleEven = new System.Windows.Forms.RadioButton();
            this.rbSingleOdd = new System.Windows.Forms.RadioButton();
            this.btnGetPixelInfo = new System.Windows.Forms.Button();
            this.rgRegCtrl = new System.Windows.Forms.GroupBox();
            this.cbReg24yearSetting = new System.Windows.Forms.CheckBox();
            this.cbReg127mode = new System.Windows.Forms.ComboBox();
            this.btnRegAllRead = new System.Windows.Forms.Button();
            this.btnTas1945RegCtrl = new System.Windows.Forms.Button();
            this.btnRegRead = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegWrite = new System.Windows.Forms.Button();
            this.tbRegData = new System.Windows.Forms.TextBox();
            this.nudRegAddr = new System.Windows.Forms.NumericUpDown();
            this.gbTcpConnect = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tgsNetMode = new JCS.ToggleSwitch();
            this.ipAddress = new IPAddressControlLib.IPAddressControl();
            this.nudTcpPort = new System.Windows.Forms.NumericUpDown();
            this.btnTcpConnect = new System.Windows.Forms.Button();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDeviceCtrl = new System.Windows.Forms.TabPage();
            this.gbIpSetup = new System.Windows.Forms.GroupBox();
            this.ipSetAddress = new IPAddressControlLib.IPAddressControl();
            this.nupSetPort = new System.Windows.Forms.NumericUpDown();
            this.btnIpSetup = new System.Windows.Forms.Button();
            this.rbSetIpClient = new System.Windows.Forms.RadioButton();
            this.rbSetIpServer = new System.Windows.Forms.RadioButton();
            this.gbDeviceCtrl = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnResend = new System.Windows.Forms.Button();
            this.btnSetReadPLStart = new System.Windows.Forms.Button();
            this.btnGetSetupInfo = new System.Windows.Forms.Button();
            this.nudSetAvrCnt = new System.Windows.Forms.NumericUpDown();
            this.btnSetAverage = new System.Windows.Forms.Button();
            this.tgsReadEdge = new JCS.ToggleSwitch();
            this.nudClockDelay = new System.Windows.Forms.NumericUpDown();
            this.btnSetRead = new System.Windows.Forms.Button();
            this.nudSetClock = new System.Windows.Forms.NumericUpDown();
            this.btnSetClock = new System.Windows.Forms.Button();
            this.tpFilter = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tgsKalman = new JCS.ToggleSwitch();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.nudLpfSensitive = new System.Windows.Forms.NumericUpDown();
            this.tgsLpfIir = new JCS.ToggleSwitch();
            this.tpImageCal = new System.Windows.Forms.TabPage();
            this.btnColInit = new System.Windows.Forms.Button();
            this.btnColLive = new System.Windows.Forms.Button();
            this.btnXYInit = new System.Windows.Forms.Button();
            this.btnXYLive = new System.Windows.Forms.Button();
            this.btnXYDead = new System.Windows.Forms.Button();
            this.btnColDead = new System.Windows.Forms.Button();
            this.tbY_dpc = new System.Windows.Forms.TextBox();
            this.tbX_dpc = new System.Windows.Forms.TextBox();
            this.tbColselect = new System.Windows.Forms.TextBox();
            this.cbISPoffset = new System.Windows.Forms.CheckBox();
            this.btnISPoffsetCal = new System.Windows.Forms.Button();
            this.btcalOffsetload = new System.Windows.Forms.Button();
            this.btnDataverify = new System.Windows.Forms.Button();
            this.btnKalmanError = new System.Windows.Forms.Button();
            this.tbKalmanError = new System.Windows.Forms.TextBox();
            this.btnDP_cal = new System.Windows.Forms.Button();
            this.btnGain = new System.Windows.Forms.Button();
            this.tbNoise_min = new System.Windows.Forms.TextBox();
            this.tbSignal_min = new System.Windows.Forms.TextBox();
            this.tbStoN_min = new System.Windows.Forms.TextBox();
            this.tbNoise_max = new System.Windows.Forms.TextBox();
            this.tbSignal_max = new System.Windows.Forms.TextBox();
            this.tbStoN_max = new System.Windows.Forms.TextBox();
            this.tbGain = new System.Windows.Forms.TextBox();
            this.lbGain = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbDPC_apply_cnt = new System.Windows.Forms.Label();
            this.lbLivePixel_count = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbDPC_apply_perc = new System.Windows.Forms.Label();
            this.lbLivePixel_perc = new System.Windows.Forms.Label();
            this.lbKalmanError = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbDPC_apply = new System.Windows.Forms.CheckBox();
            this.Noise_ck = new System.Windows.Forms.CheckBox();
            this.cbNF_apply = new System.Windows.Forms.CheckBox();
            this.Signal_ck = new System.Windows.Forms.CheckBox();
            this.StoN_ck = new System.Windows.Forms.CheckBox();
            this.cbDP_apply = new System.Windows.Forms.CheckBox();
            this.cbSensitivy_cal = new System.Windows.Forms.CheckBox();
            this.nudcal35 = new System.Windows.Forms.NumericUpDown();
            this.nudcal45 = new System.Windows.Forms.NumericUpDown();
            this.nudcal25 = new System.Windows.Forms.NumericUpDown();
            this.btncal35 = new System.Windows.Forms.Button();
            this.btncal45 = new System.Windows.Forms.Button();
            this.btcal35load = new System.Windows.Forms.Button();
            this.btcal45load = new System.Windows.Forms.Button();
            this.btcal25load = new System.Windows.Forms.Button();
            this.btncal25 = new System.Windows.Forms.Button();
            this.cbCalmode = new System.Windows.Forms.CheckBox();
            this.cbABS_apply = new System.Windows.Forms.CheckBox();
            this.cbOffset_apply = new System.Windows.Forms.CheckBox();
            this.tpRegTest = new System.Windows.Forms.TabPage();
            this.btnRegRD_Set2 = new System.Windows.Forms.Button();
            this.btnRegWR_Set2 = new System.Windows.Forms.Button();
            this.btnRegRD_Set1 = new System.Windows.Forms.Button();
            this.btnRegWR_Set1 = new System.Windows.Forms.Button();
            this.tbReg215_Set2 = new System.Windows.Forms.TextBox();
            this.tbReg215_Set1 = new System.Windows.Forms.TextBox();
            this.tbReg213_Set2 = new System.Windows.Forms.TextBox();
            this.tbReg213_Set1 = new System.Windows.Forms.TextBox();
            this.tbReg154_Set2 = new System.Windows.Forms.TextBox();
            this.tbReg154_Set1 = new System.Windows.Forms.TextBox();
            this.tbReg127_Set2 = new System.Windows.Forms.TextBox();
            this.tbReg127_Set1 = new System.Windows.Forms.TextBox();
            this.nudTestReg_215 = new System.Windows.Forms.NumericUpDown();
            this.nudTestReg_213 = new System.Windows.Forms.NumericUpDown();
            this.nudTestReg_154 = new System.Windows.Forms.NumericUpDown();
            this.nudTestReg_127 = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tpFTDI = new System.Windows.Forms.TabPage();
            this.cbFTDICSV = new System.Windows.Forms.CheckBox();
            this.cbFTDILog = new System.Windows.Forms.CheckBox();
            this.btnFTDIoffset = new System.Windows.Forms.Button();
            this.btnFTDIRead = new System.Windows.Forms.Button();
            this.ssMainStrip = new System.Windows.Forms.StatusStrip();
            this.tssConnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.btnImageClear = new System.Windows.Forms.Button();
            this.tmImageDsp = new System.Windows.Forms.Timer(this.components);
            this.tbPixelX = new System.Windows.Forms.TextBox();
            this.tbPixelY = new System.Windows.Forms.TextBox();
            this.tbPixelValue = new System.Windows.Forms.TextBox();
            this.tbPixelRGB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPixelOffset = new System.Windows.Forms.TextBox();
            this.tgsDebugLog = new JCS.ToggleSwitch();
            this.tgsPixels = new JCS.ToggleSwitch();
            this.tgsImageX10 = new JCS.ToggleSwitch();
            this.tmPixelCountinue = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.nudPixelSpace = new System.Windows.Forms.NumericUpDown();
            this.tgsChartLog = new JCS.ToggleSwitch();
            this.tgsShowImage = new JCS.ToggleSwitch();
            this.ttHint = new System.Windows.Forms.ToolTip(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbEven = new Bulb.LedBulb();
            this.lbOdd = new Bulb.LedBulb();
            this.panMain = new Tas1945_mon.DoubleBufferPanel();
            this.tmSisoRD = new System.Windows.Forms.Timer(this.components);
            this.tbFTDILogPixelNum = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.btnFTDILogPixelApply = new System.Windows.Forms.Button();
            this.tpTas1945Ctrl.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCsvSaveCnt)).BeginInit();
            this.gbPixel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetCenterValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDark_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelMeasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDark_X)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVal)).BeginInit();
            this.gbSingleRead.SuspendLayout();
            this.gbAverage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvrCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.rgRegCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegAddr)).BeginInit();
            this.gbTcpConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTcpPort)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpDeviceCtrl.SuspendLayout();
            this.gbIpSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSetPort)).BeginInit();
            this.gbDeviceCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetAvrCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClockDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetClock)).BeginInit();
            this.tpFilter.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLpfSensitive)).BeginInit();
            this.tpImageCal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcal35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcal45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcal25)).BeginInit();
            this.tpRegTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_215)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_213)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_154)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_127)).BeginInit();
            this.tpFTDI.SuspendLayout();
            this.ssMainStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // tpTas1945Ctrl
            // 
            this.tpTas1945Ctrl.BackColor = System.Drawing.SystemColors.Control;
            this.tpTas1945Ctrl.Controls.Add(this.cbDark_Apply);
            this.tpTas1945Ctrl.Controls.Add(this.groupBox5);
            this.tpTas1945Ctrl.Controls.Add(this.gbPixel);
            this.tpTas1945Ctrl.Controls.Add(this.groupBox1);
            this.tpTas1945Ctrl.Controls.Add(this.gbSingleRead);
            this.tpTas1945Ctrl.Controls.Add(this.rgRegCtrl);
            this.tpTas1945Ctrl.Controls.Add(this.gbTcpConnect);
            this.tpTas1945Ctrl.Location = new System.Drawing.Point(4, 27);
            this.tpTas1945Ctrl.Name = "tpTas1945Ctrl";
            this.tpTas1945Ctrl.Padding = new System.Windows.Forms.Padding(3);
            this.tpTas1945Ctrl.Size = new System.Drawing.Size(1370, 168);
            this.tpTas1945Ctrl.TabIndex = 0;
            this.tpTas1945Ctrl.Text = "TAS1945 Ctrl";
            // 
            // cbDark_Apply
            // 
            this.cbDark_Apply.AutoSize = true;
            this.cbDark_Apply.Location = new System.Drawing.Point(1104, 19);
            this.cbDark_Apply.Name = "cbDark_Apply";
            this.cbDark_Apply.Size = new System.Drawing.Size(86, 22);
            this.cbDark_Apply.TabIndex = 48;
            this.cbDark_Apply.Text = "(-)Dark";
            this.cbDark_Apply.UseVisualStyleBackColor = true;
            this.cbDark_Apply.CheckedChanged += new System.EventHandler(this.cbDark_Apply_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbMaxFrame);
            this.groupBox5.Controls.Add(this.lbFrames);
            this.groupBox5.Controls.Add(this.nudCsvSaveCnt);
            this.groupBox5.Controls.Add(this.rbTestPixel);
            this.groupBox5.Controls.Add(this.rbChartPixel);
            this.groupBox5.Controls.Add(this.tgsCsvSave);
            this.groupBox5.Location = new System.Drawing.Point(940, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(154, 163);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CSV Save Ctrl";
            // 
            // lbMaxFrame
            // 
            this.lbMaxFrame.AutoSize = true;
            this.lbMaxFrame.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaxFrame.Location = new System.Drawing.Point(17, 104);
            this.lbMaxFrame.Name = "lbMaxFrame";
            this.lbMaxFrame.Size = new System.Drawing.Size(70, 22);
            this.lbMaxFrame.TabIndex = 85;
            this.lbMaxFrame.Text = "Frames";
            // 
            // lbFrames
            // 
            this.lbFrames.AutoSize = true;
            this.lbFrames.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrames.Location = new System.Drawing.Point(17, 133);
            this.lbFrames.Name = "lbFrames";
            this.lbFrames.Size = new System.Drawing.Size(70, 22);
            this.lbFrames.TabIndex = 84;
            this.lbFrames.Text = "Frames";
            // 
            // nudCsvSaveCnt
            // 
            this.nudCsvSaveCnt.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCsvSaveCnt.Location = new System.Drawing.Point(85, 20);
            this.nudCsvSaveCnt.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudCsvSaveCnt.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCsvSaveCnt.Name = "nudCsvSaveCnt";
            this.nudCsvSaveCnt.Size = new System.Drawing.Size(63, 25);
            this.nudCsvSaveCnt.TabIndex = 83;
            this.nudCsvSaveCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCsvSaveCnt.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // rbTestPixel
            // 
            this.rbTestPixel.AutoSize = true;
            this.rbTestPixel.Location = new System.Drawing.Point(5, 50);
            this.rbTestPixel.Name = "rbTestPixel";
            this.rbTestPixel.Size = new System.Drawing.Size(149, 22);
            this.rbTestPixel.TabIndex = 82;
            this.rbTestPixel.TabStop = true;
            this.rbTestPixel.Text = "80,0-2-59 Pixel";
            this.rbTestPixel.UseVisualStyleBackColor = true;
            // 
            // rbChartPixel
            // 
            this.rbChartPixel.AutoSize = true;
            this.rbChartPixel.Location = new System.Drawing.Point(5, 69);
            this.rbChartPixel.Name = "rbChartPixel";
            this.rbChartPixel.Size = new System.Drawing.Size(117, 22);
            this.rbChartPixel.TabIndex = 81;
            this.rbChartPixel.TabStop = true;
            this.rbChartPixel.Text = "Chart Pixel";
            this.rbChartPixel.UseVisualStyleBackColor = true;
            // 
            // tgsCsvSave
            // 
            this.tgsCsvSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsCsvSave.BackColor = System.Drawing.SystemColors.Control;
            this.tgsCsvSave.Location = new System.Drawing.Point(4, 19);
            this.tgsCsvSave.Name = "tgsCsvSave";
            this.tgsCsvSave.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsCsvSave.OffText = "DISABLE";
            this.tgsCsvSave.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsCsvSave.OnForeColor = System.Drawing.Color.White;
            this.tgsCsvSave.OnText = "ENABLE";
            this.tgsCsvSave.Size = new System.Drawing.Size(75, 25);
            this.tgsCsvSave.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsCsvSave.TabIndex = 55;
            this.tgsCsvSave.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsCsvSave_CheckedChanged);
            // 
            // gbPixel
            // 
            this.gbPixel.Controls.Add(this.tgsRefVal);
            this.gbPixel.Controls.Add(this.nudSetCenterValue);
            this.gbPixel.Controls.Add(this.groupBox2);
            this.gbPixel.Location = new System.Drawing.Point(753, 6);
            this.gbPixel.Name = "gbPixel";
            this.gbPixel.Size = new System.Drawing.Size(181, 163);
            this.gbPixel.TabIndex = 46;
            this.gbPixel.TabStop = false;
            this.gbPixel.Text = "Pixel Ctrl";
            // 
            // tgsRefVal
            // 
            this.tgsRefVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsRefVal.BackColor = System.Drawing.SystemColors.Control;
            this.tgsRefVal.Checked = true;
            this.tgsRefVal.Location = new System.Drawing.Point(4, 19);
            this.tgsRefVal.Name = "tgsRefVal";
            this.tgsRefVal.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsRefVal.OffText = "Normal";
            this.tgsRefVal.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsRefVal.OnForeColor = System.Drawing.Color.White;
            this.tgsRefVal.OnText = "Reference";
            this.tgsRefVal.Size = new System.Drawing.Size(99, 25);
            this.tgsRefVal.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsRefVal.TabIndex = 81;
            // 
            // nudSetCenterValue
            // 
            this.nudSetCenterValue.Location = new System.Drawing.Point(108, 21);
            this.nudSetCenterValue.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudSetCenterValue.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.nudSetCenterValue.Name = "nudSetCenterValue";
            this.nudSetCenterValue.Size = new System.Drawing.Size(67, 25);
            this.nudSetCenterValue.TabIndex = 79;
            this.nudSetCenterValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.rbDark_Y_Offset);
            this.groupBox2.Controls.Add(this.nudDark_Y);
            this.groupBox2.Controls.Add(this.nudPixelMeasure);
            this.groupBox2.Controls.Add(this.nudDark_X);
            this.groupBox2.Controls.Add(this.rbAvrOffset);
            this.groupBox2.Controls.Add(this.rbDark_X_Offset);
            this.groupBox2.Controls.Add(this.rbOffsetDisable);
            this.groupBox2.Location = new System.Drawing.Point(6, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 112);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Offset";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 18);
            this.label14.TabIndex = 78;
            this.label14.Text = "Measure Cnt";
            // 
            // rbDark_Y_Offset
            // 
            this.rbDark_Y_Offset.AutoSize = true;
            this.rbDark_Y_Offset.Location = new System.Drawing.Point(6, 62);
            this.rbDark_Y_Offset.Name = "rbDark_Y_Offset";
            this.rbDark_Y_Offset.Size = new System.Drawing.Size(77, 22);
            this.rbDark_Y_Offset.TabIndex = 77;
            this.rbDark_Y_Offset.TabStop = true;
            this.rbDark_Y_Offset.Text = "Dark Y";
            this.rbDark_Y_Offset.UseVisualStyleBackColor = true;
            this.rbDark_Y_Offset.CheckedChanged += new System.EventHandler(this.rbDarkOffset_CheckedChanged);
            // 
            // nudDark_Y
            // 
            this.nudDark_Y.Location = new System.Drawing.Point(89, 61);
            this.nudDark_Y.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.nudDark_Y.Name = "nudDark_Y";
            this.nudDark_Y.Size = new System.Drawing.Size(77, 25);
            this.nudDark_Y.TabIndex = 76;
            this.nudDark_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDark_Y.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // nudPixelMeasure
            // 
            this.nudPixelMeasure.Location = new System.Drawing.Point(89, 85);
            this.nudPixelMeasure.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudPixelMeasure.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPixelMeasure.Name = "nudPixelMeasure";
            this.nudPixelMeasure.Size = new System.Drawing.Size(77, 25);
            this.nudPixelMeasure.TabIndex = 74;
            this.nudPixelMeasure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPixelMeasure.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudDark_X
            // 
            this.nudDark_X.Location = new System.Drawing.Point(89, 37);
            this.nudDark_X.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudDark_X.Name = "nudDark_X";
            this.nudDark_X.Size = new System.Drawing.Size(77, 25);
            this.nudDark_X.TabIndex = 72;
            this.nudDark_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDark_X.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // rbAvrOffset
            // 
            this.rbAvrOffset.AutoSize = true;
            this.rbAvrOffset.Location = new System.Drawing.Point(87, 19);
            this.rbAvrOffset.Name = "rbAvrOffset";
            this.rbAvrOffset.Size = new System.Drawing.Size(85, 22);
            this.rbAvrOffset.TabIndex = 71;
            this.rbAvrOffset.TabStop = true;
            this.rbAvrOffset.Text = "Average";
            this.rbAvrOffset.UseVisualStyleBackColor = true;
            this.rbAvrOffset.CheckedChanged += new System.EventHandler(this.rbAvrOffset_CheckedChanged);
            // 
            // rbDark_X_Offset
            // 
            this.rbDark_X_Offset.AutoSize = true;
            this.rbDark_X_Offset.Location = new System.Drawing.Point(6, 39);
            this.rbDark_X_Offset.Name = "rbDark_X_Offset";
            this.rbDark_X_Offset.Size = new System.Drawing.Size(77, 22);
            this.rbDark_X_Offset.TabIndex = 70;
            this.rbDark_X_Offset.TabStop = true;
            this.rbDark_X_Offset.Text = "Dark X";
            this.rbDark_X_Offset.UseVisualStyleBackColor = true;
            this.rbDark_X_Offset.CheckedChanged += new System.EventHandler(this.rbDarkOffset_CheckedChanged);
            // 
            // rbOffsetDisable
            // 
            this.rbOffsetDisable.AutoSize = true;
            this.rbOffsetDisable.Location = new System.Drawing.Point(6, 19);
            this.rbOffsetDisable.Name = "rbOffsetDisable";
            this.rbOffsetDisable.Size = new System.Drawing.Size(85, 22);
            this.rbOffsetDisable.TabIndex = 0;
            this.rbOffsetDisable.TabStop = true;
            this.rbOffsetDisable.Text = "Disable";
            this.rbOffsetDisable.UseVisualStyleBackColor = true;
            this.rbOffsetDisable.CheckedChanged += new System.EventHandler(this.rbOffNormal_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.nudMinVal);
            this.groupBox1.Controls.Add(this.nudMaxVal);
            this.groupBox1.Controls.Add(this.btnChartClear);
            this.groupBox1.Controls.Add(this.rbSetPixel5);
            this.groupBox1.Controls.Add(this.rbSetPixel4);
            this.groupBox1.Controls.Add(this.rbSetPixel3);
            this.groupBox1.Controls.Add(this.rbSetPixel2);
            this.groupBox1.Controls.Add(this.rbSetPixel1);
            this.groupBox1.Controls.Add(this.btnPixelChartShow);
            this.groupBox1.Location = new System.Drawing.Point(582, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 163);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pixel Chart";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(84, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 18);
            this.label13.TabIndex = 71;
            this.label13.Text = "Min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(84, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 18);
            this.label12.TabIndex = 70;
            this.label12.Text = "Max";
            // 
            // nudMinVal
            // 
            this.nudMinVal.Location = new System.Drawing.Point(85, 135);
            this.nudMinVal.Maximum = new decimal(new int[] {
            32766,
            0,
            0,
            0});
            this.nudMinVal.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.nudMinVal.Name = "nudMinVal";
            this.nudMinVal.Size = new System.Drawing.Size(74, 25);
            this.nudMinVal.TabIndex = 69;
            this.nudMinVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudMaxVal
            // 
            this.nudMaxVal.Location = new System.Drawing.Point(85, 99);
            this.nudMaxVal.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.nudMaxVal.Minimum = new decimal(new int[] {
            32767,
            0,
            0,
            -2147483648});
            this.nudMaxVal.Name = "nudMaxVal";
            this.nudMaxVal.Size = new System.Drawing.Size(74, 25);
            this.nudMaxVal.TabIndex = 68;
            this.nudMaxVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxVal.Value = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            // 
            // btnChartClear
            // 
            this.btnChartClear.Location = new System.Drawing.Point(85, 54);
            this.btnChartClear.Name = "btnChartClear";
            this.btnChartClear.Size = new System.Drawing.Size(75, 27);
            this.btnChartClear.TabIndex = 65;
            this.btnChartClear.Text = "Clear";
            this.btnChartClear.UseVisualStyleBackColor = true;
            this.btnChartClear.Click += new System.EventHandler(this.btnChartClear_Click);
            // 
            // rbSetPixel5
            // 
            this.rbSetPixel5.AutoSize = true;
            this.rbSetPixel5.Location = new System.Drawing.Point(6, 133);
            this.rbSetPixel5.Name = "rbSetPixel5";
            this.rbSetPixel5.Size = new System.Drawing.Size(77, 22);
            this.rbSetPixel5.TabIndex = 64;
            this.rbSetPixel5.TabStop = true;
            this.rbSetPixel5.Text = "Set P5";
            this.rbSetPixel5.UseVisualStyleBackColor = true;
            // 
            // rbSetPixel4
            // 
            this.rbSetPixel4.AutoSize = true;
            this.rbSetPixel4.Location = new System.Drawing.Point(6, 106);
            this.rbSetPixel4.Name = "rbSetPixel4";
            this.rbSetPixel4.Size = new System.Drawing.Size(77, 22);
            this.rbSetPixel4.TabIndex = 63;
            this.rbSetPixel4.TabStop = true;
            this.rbSetPixel4.Text = "Set P4";
            this.rbSetPixel4.UseVisualStyleBackColor = true;
            // 
            // rbSetPixel3
            // 
            this.rbSetPixel3.AutoSize = true;
            this.rbSetPixel3.Location = new System.Drawing.Point(6, 78);
            this.rbSetPixel3.Name = "rbSetPixel3";
            this.rbSetPixel3.Size = new System.Drawing.Size(77, 22);
            this.rbSetPixel3.TabIndex = 62;
            this.rbSetPixel3.TabStop = true;
            this.rbSetPixel3.Text = "Set P3";
            this.rbSetPixel3.UseVisualStyleBackColor = true;
            // 
            // rbSetPixel2
            // 
            this.rbSetPixel2.AutoSize = true;
            this.rbSetPixel2.Location = new System.Drawing.Point(6, 52);
            this.rbSetPixel2.Name = "rbSetPixel2";
            this.rbSetPixel2.Size = new System.Drawing.Size(77, 22);
            this.rbSetPixel2.TabIndex = 61;
            this.rbSetPixel2.TabStop = true;
            this.rbSetPixel2.Text = "Set P2";
            this.rbSetPixel2.UseVisualStyleBackColor = true;
            // 
            // rbSetPixel1
            // 
            this.rbSetPixel1.AutoSize = true;
            this.rbSetPixel1.Location = new System.Drawing.Point(6, 26);
            this.rbSetPixel1.Name = "rbSetPixel1";
            this.rbSetPixel1.Size = new System.Drawing.Size(77, 22);
            this.rbSetPixel1.TabIndex = 60;
            this.rbSetPixel1.TabStop = true;
            this.rbSetPixel1.Text = "Set P1";
            this.rbSetPixel1.UseVisualStyleBackColor = true;
            // 
            // btnPixelChartShow
            // 
            this.btnPixelChartShow.Location = new System.Drawing.Point(85, 21);
            this.btnPixelChartShow.Name = "btnPixelChartShow";
            this.btnPixelChartShow.Size = new System.Drawing.Size(75, 27);
            this.btnPixelChartShow.TabIndex = 49;
            this.btnPixelChartShow.Text = "Start";
            this.btnPixelChartShow.UseVisualStyleBackColor = true;
            this.btnPixelChartShow.Click += new System.EventHandler(this.btnPixelChartShow_Click);
            // 
            // gbSingleRead
            // 
            this.gbSingleRead.Controls.Add(this.tgsPushSkip);
            this.gbSingleRead.Controls.Add(this.btnReadPushMode);
            this.gbSingleRead.Controls.Add(this.gbAverage);
            this.gbSingleRead.Controls.Add(this.nudAvrCnt);
            this.gbSingleRead.Controls.Add(this.rbOddEvenToggle);
            this.gbSingleRead.Controls.Add(this.label8);
            this.gbSingleRead.Controls.Add(this.nudInterval);
            this.gbSingleRead.Controls.Add(this.tgsContinue);
            this.gbSingleRead.Controls.Add(this.rbSingleEven);
            this.gbSingleRead.Controls.Add(this.rbSingleOdd);
            this.gbSingleRead.Controls.Add(this.btnGetPixelInfo);
            this.gbSingleRead.Location = new System.Drawing.Point(362, 6);
            this.gbSingleRead.Name = "gbSingleRead";
            this.gbSingleRead.Size = new System.Drawing.Size(214, 163);
            this.gbSingleRead.TabIndex = 40;
            this.gbSingleRead.TabStop = false;
            this.gbSingleRead.Text = "Image Read";
            // 
            // tgsPushSkip
            // 
            this.tgsPushSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsPushSkip.BackColor = System.Drawing.SystemColors.Control;
            this.tgsPushSkip.Checked = true;
            this.tgsPushSkip.Location = new System.Drawing.Point(10, 104);
            this.tgsPushSkip.Name = "tgsPushSkip";
            this.tgsPushSkip.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsPushSkip.OffText = "ALL";
            this.tgsPushSkip.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsPushSkip.OnForeColor = System.Drawing.Color.White;
            this.tgsPushSkip.OnText = "SKIP 1By1";
            this.tgsPushSkip.Size = new System.Drawing.Size(95, 25);
            this.tgsPushSkip.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsPushSkip.TabIndex = 70;
            // 
            // btnReadPushMode
            // 
            this.btnReadPushMode.Location = new System.Drawing.Point(9, 132);
            this.btnReadPushMode.Name = "btnReadPushMode";
            this.btnReadPushMode.Size = new System.Drawing.Size(99, 27);
            this.btnReadPushMode.TabIndex = 69;
            this.btnReadPushMode.Text = "Push Read";
            this.btnReadPushMode.UseVisualStyleBackColor = true;
            this.btnReadPushMode.Click += new System.EventHandler(this.btnReadPushMode_Click);
            // 
            // gbAverage
            // 
            this.gbAverage.Controls.Add(this.rbNormal);
            this.gbAverage.Controls.Add(this.rbMoveAvr);
            this.gbAverage.Controls.Add(this.rbGuiAvr);
            this.gbAverage.Controls.Add(this.rbFpgaAvr);
            this.gbAverage.Location = new System.Drawing.Point(114, 69);
            this.gbAverage.Name = "gbAverage";
            this.gbAverage.Size = new System.Drawing.Size(94, 89);
            this.gbAverage.TabIndex = 68;
            this.gbAverage.TabStop = false;
            this.gbAverage.Text = "Avrage";
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(6, 14);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(77, 22);
            this.rbNormal.TabIndex = 64;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbMoveAvr
            // 
            this.rbMoveAvr.AutoSize = true;
            this.rbMoveAvr.Location = new System.Drawing.Point(6, 67);
            this.rbMoveAvr.Name = "rbMoveAvr";
            this.rbMoveAvr.Size = new System.Drawing.Size(69, 22);
            this.rbMoveAvr.TabIndex = 63;
            this.rbMoveAvr.TabStop = true;
            this.rbMoveAvr.Text = "Move8";
            this.rbMoveAvr.UseVisualStyleBackColor = true;
            this.rbMoveAvr.CheckedChanged += new System.EventHandler(this.rbMoveAvr_CheckedChanged);
            // 
            // rbGuiAvr
            // 
            this.rbGuiAvr.AutoSize = true;
            this.rbGuiAvr.Location = new System.Drawing.Point(6, 49);
            this.rbGuiAvr.Name = "rbGuiAvr";
            this.rbGuiAvr.Size = new System.Drawing.Size(53, 22);
            this.rbGuiAvr.TabIndex = 62;
            this.rbGuiAvr.TabStop = true;
            this.rbGuiAvr.Text = "GUI";
            this.rbGuiAvr.UseVisualStyleBackColor = true;
            this.rbGuiAvr.CheckedChanged += new System.EventHandler(this.rbGuiAvr_CheckedChanged);
            // 
            // rbFpgaAvr
            // 
            this.rbFpgaAvr.AutoSize = true;
            this.rbFpgaAvr.Location = new System.Drawing.Point(6, 32);
            this.rbFpgaAvr.Name = "rbFpgaAvr";
            this.rbFpgaAvr.Size = new System.Drawing.Size(61, 22);
            this.rbFpgaAvr.TabIndex = 61;
            this.rbFpgaAvr.TabStop = true;
            this.rbFpgaAvr.Text = "FPGA";
            this.rbFpgaAvr.UseVisualStyleBackColor = true;
            this.rbFpgaAvr.CheckedChanged += new System.EventHandler(this.rbFpgaAvr_CheckedChanged);
            // 
            // nudAvrCnt
            // 
            this.nudAvrCnt.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudAvrCnt.Location = new System.Drawing.Point(69, 76);
            this.nudAvrCnt.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudAvrCnt.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudAvrCnt.Name = "nudAvrCnt";
            this.nudAvrCnt.ReadOnly = true;
            this.nudAvrCnt.Size = new System.Drawing.Size(36, 25);
            this.nudAvrCnt.TabIndex = 67;
            this.nudAvrCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAvrCnt.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // rbOddEvenToggle
            // 
            this.rbOddEvenToggle.AutoSize = true;
            this.rbOddEvenToggle.Location = new System.Drawing.Point(128, 17);
            this.rbOddEvenToggle.Name = "rbOddEvenToggle";
            this.rbOddEvenToggle.Size = new System.Drawing.Size(93, 22);
            this.rbOddEvenToggle.TabIndex = 63;
            this.rbOddEvenToggle.TabStop = true;
            this.rbOddEvenToggle.Text = "ODD/EVEN";
            this.rbOddEvenToggle.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 61;
            this.label8.Text = "Interval(ms)";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(115, 48);
            this.nudInterval.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(93, 25);
            this.nudInterval.TabIndex = 60;
            this.nudInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudInterval.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudInterval.Click += new System.EventHandler(this.nudInterval_Click);
            // 
            // tgsContinue
            // 
            this.tgsContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsContinue.BackColor = System.Drawing.SystemColors.Control;
            this.tgsContinue.Checked = true;
            this.tgsContinue.Location = new System.Drawing.Point(10, 45);
            this.tgsContinue.Name = "tgsContinue";
            this.tgsContinue.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsContinue.OffText = "Single";
            this.tgsContinue.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsContinue.OnForeColor = System.Drawing.Color.White;
            this.tgsContinue.OnText = "Continue";
            this.tgsContinue.Size = new System.Drawing.Size(98, 25);
            this.tgsContinue.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsContinue.TabIndex = 58;
            // 
            // rbSingleEven
            // 
            this.rbSingleEven.AutoSize = true;
            this.rbSingleEven.Location = new System.Drawing.Point(69, 17);
            this.rbSingleEven.Name = "rbSingleEven";
            this.rbSingleEven.Size = new System.Drawing.Size(61, 22);
            this.rbSingleEven.TabIndex = 42;
            this.rbSingleEven.Text = "EVEN";
            this.rbSingleEven.UseVisualStyleBackColor = true;
            // 
            // rbSingleOdd
            // 
            this.rbSingleOdd.AutoSize = true;
            this.rbSingleOdd.Checked = true;
            this.rbSingleOdd.Location = new System.Drawing.Point(10, 17);
            this.rbSingleOdd.Name = "rbSingleOdd";
            this.rbSingleOdd.Size = new System.Drawing.Size(53, 22);
            this.rbSingleOdd.TabIndex = 41;
            this.rbSingleOdd.TabStop = true;
            this.rbSingleOdd.Text = "ODD";
            this.rbSingleOdd.UseVisualStyleBackColor = true;
            // 
            // btnGetPixelInfo
            // 
            this.btnGetPixelInfo.Location = new System.Drawing.Point(10, 73);
            this.btnGetPixelInfo.Name = "btnGetPixelInfo";
            this.btnGetPixelInfo.Size = new System.Drawing.Size(58, 27);
            this.btnGetPixelInfo.TabIndex = 40;
            this.btnGetPixelInfo.Text = "Read";
            this.btnGetPixelInfo.UseVisualStyleBackColor = true;
            this.btnGetPixelInfo.Click += new System.EventHandler(this.btnGetPixelInfoRead_Click);
            // 
            // rgRegCtrl
            // 
            this.rgRegCtrl.Controls.Add(this.cbReg24yearSetting);
            this.rgRegCtrl.Controls.Add(this.cbReg127mode);
            this.rgRegCtrl.Controls.Add(this.btnRegAllRead);
            this.rgRegCtrl.Controls.Add(this.btnTas1945RegCtrl);
            this.rgRegCtrl.Controls.Add(this.btnRegRead);
            this.rgRegCtrl.Controls.Add(this.label2);
            this.rgRegCtrl.Controls.Add(this.label1);
            this.rgRegCtrl.Controls.Add(this.btnRegWrite);
            this.rgRegCtrl.Controls.Add(this.tbRegData);
            this.rgRegCtrl.Controls.Add(this.nudRegAddr);
            this.rgRegCtrl.Location = new System.Drawing.Point(189, 6);
            this.rgRegCtrl.Name = "rgRegCtrl";
            this.rgRegCtrl.Size = new System.Drawing.Size(167, 163);
            this.rgRegCtrl.TabIndex = 39;
            this.rgRegCtrl.TabStop = false;
            this.rgRegCtrl.Text = "REG Ctrl";
            // 
            // cbReg24yearSetting
            // 
            this.cbReg24yearSetting.AutoSize = true;
            this.cbReg24yearSetting.Location = new System.Drawing.Point(94, 132);
            this.cbReg24yearSetting.Name = "cbReg24yearSetting";
            this.cbReg24yearSetting.Size = new System.Drawing.Size(54, 22);
            this.cbReg24yearSetting.TabIndex = 48;
            this.cbReg24yearSetting.Text = "24\'";
            this.cbReg24yearSetting.UseVisualStyleBackColor = true;
            // 
            // cbReg127mode
            // 
            this.cbReg127mode.FormattingEnabled = true;
            this.cbReg127mode.Items.AddRange(new object[] {
            "미선택",
            "Diffential",
            "Sensor",
            "Reset"});
            this.cbReg127mode.Location = new System.Drawing.Point(11, 129);
            this.cbReg127mode.Name = "cbReg127mode";
            this.cbReg127mode.Size = new System.Drawing.Size(77, 26);
            this.cbReg127mode.TabIndex = 47;
            this.cbReg127mode.SelectedIndexChanged += new System.EventHandler(this.cbReg127mode_SelectedIndexChanged);
            // 
            // btnRegAllRead
            // 
            this.btnRegAllRead.Location = new System.Drawing.Point(84, 94);
            this.btnRegAllRead.Name = "btnRegAllRead";
            this.btnRegAllRead.Size = new System.Drawing.Size(75, 27);
            this.btnRegAllRead.TabIndex = 46;
            this.btnRegAllRead.Text = "ALL RD";
            this.btnRegAllRead.UseVisualStyleBackColor = true;
            this.btnRegAllRead.Click += new System.EventHandler(this.btnRegAllRead_Click);
            // 
            // btnTas1945RegCtrl
            // 
            this.btnTas1945RegCtrl.Location = new System.Drawing.Point(4, 94);
            this.btnTas1945RegCtrl.Name = "btnTas1945RegCtrl";
            this.btnTas1945RegCtrl.Size = new System.Drawing.Size(75, 27);
            this.btnTas1945RegCtrl.TabIndex = 43;
            this.btnTas1945RegCtrl.Text = "Reg Ctrl";
            this.btnTas1945RegCtrl.UseVisualStyleBackColor = true;
            this.btnTas1945RegCtrl.Click += new System.EventHandler(this.btnTas1945Init_Click);
            // 
            // btnRegRead
            // 
            this.btnRegRead.Location = new System.Drawing.Point(84, 61);
            this.btnRegRead.Name = "btnRegRead";
            this.btnRegRead.Size = new System.Drawing.Size(75, 27);
            this.btnRegRead.TabIndex = 42;
            this.btnRegRead.Text = "REG RD";
            this.btnRegRead.UseVisualStyleBackColor = true;
            this.btnRegRead.Click += new System.EventHandler(this.btnSpiRead_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 41;
            this.label2.Text = "Data(hexa)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "Addr(dec)";
            // 
            // btnRegWrite
            // 
            this.btnRegWrite.Location = new System.Drawing.Point(4, 61);
            this.btnRegWrite.Name = "btnRegWrite";
            this.btnRegWrite.Size = new System.Drawing.Size(75, 27);
            this.btnRegWrite.TabIndex = 39;
            this.btnRegWrite.Text = "REG WR";
            this.btnRegWrite.UseVisualStyleBackColor = true;
            this.btnRegWrite.Click += new System.EventHandler(this.btnSpiWrite_Click);
            // 
            // tbRegData
            // 
            this.tbRegData.Location = new System.Drawing.Point(84, 34);
            this.tbRegData.MaxLength = 2;
            this.tbRegData.Name = "tbRegData";
            this.tbRegData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbRegData.Size = new System.Drawing.Size(75, 25);
            this.tbRegData.TabIndex = 38;
            this.tbRegData.Text = "00";
            this.tbRegData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbRegData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRegData_KeyPress);
            // 
            // nudRegAddr
            // 
            this.nudRegAddr.Location = new System.Drawing.Point(4, 34);
            this.nudRegAddr.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRegAddr.Name = "nudRegAddr";
            this.nudRegAddr.Size = new System.Drawing.Size(75, 25);
            this.nudRegAddr.TabIndex = 37;
            this.nudRegAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRegAddr.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // gbTcpConnect
            // 
            this.gbTcpConnect.Controls.Add(this.pictureBox1);
            this.gbTcpConnect.Controls.Add(this.tgsNetMode);
            this.gbTcpConnect.Controls.Add(this.ipAddress);
            this.gbTcpConnect.Controls.Add(this.nudTcpPort);
            this.gbTcpConnect.Controls.Add(this.btnTcpConnect);
            this.gbTcpConnect.Controls.Add(this.rbClient);
            this.gbTcpConnect.Controls.Add(this.rbServer);
            this.gbTcpConnect.Location = new System.Drawing.Point(6, 6);
            this.gbTcpConnect.Name = "gbTcpConnect";
            this.gbTcpConnect.Size = new System.Drawing.Size(177, 157);
            this.gbTcpConnect.TabIndex = 38;
            this.gbTcpConnect.TabStop = false;
            this.gbTcpConnect.Text = "TCP IP / UDP";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tas1945_mon.Properties.Resources._크기변환_Tempus_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 89);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 70);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // tgsNetMode
            // 
            this.tgsNetMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsNetMode.BackColor = System.Drawing.SystemColors.Control;
            this.tgsNetMode.Location = new System.Drawing.Point(119, 34);
            this.tgsNetMode.Name = "tgsNetMode";
            this.tgsNetMode.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsNetMode.OffText = "UDP";
            this.tgsNetMode.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsNetMode.OnForeColor = System.Drawing.Color.White;
            this.tgsNetMode.OnText = "TCP";
            this.tgsNetMode.Size = new System.Drawing.Size(52, 25);
            this.tgsNetMode.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsNetMode.TabIndex = 69;
            this.tgsNetMode.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsNetMode_CheckedChanged);
            // 
            // ipAddress
            // 
            this.ipAddress.AllowInternalTab = false;
            this.ipAddress.AutoHeight = true;
            this.ipAddress.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddress.Location = new System.Drawing.Point(5, 35);
            this.ipAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipAddress.MinimumSize = new System.Drawing.Size(126, 25);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.ReadOnly = false;
            this.ipAddress.Size = new System.Drawing.Size(126, 25);
            this.ipAddress.TabIndex = 36;
            this.ipAddress.Text = "192.168.1.10";
            // 
            // nudTcpPort
            // 
            this.nudTcpPort.Location = new System.Drawing.Point(5, 63);
            this.nudTcpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudTcpPort.Name = "nudTcpPort";
            this.nudTcpPort.Size = new System.Drawing.Size(67, 25);
            this.nudTcpPort.TabIndex = 35;
            this.nudTcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTcpPort.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btnTcpConnect
            // 
            this.btnTcpConnect.Location = new System.Drawing.Point(78, 60);
            this.btnTcpConnect.Name = "btnTcpConnect";
            this.btnTcpConnect.Size = new System.Drawing.Size(94, 27);
            this.btnTcpConnect.TabIndex = 34;
            this.btnTcpConnect.Text = "Connect";
            this.btnTcpConnect.UseVisualStyleBackColor = true;
            this.btnTcpConnect.Click += new System.EventHandler(this.btnTcpConnect_Click);
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Checked = true;
            this.rbClient.Enabled = false;
            this.rbClient.Location = new System.Drawing.Point(104, 10);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(77, 22);
            this.rbClient.TabIndex = 32;
            this.rbClient.TabStop = true;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            this.rbClient.CheckedChanged += new System.EventHandler(this.rbClient_CheckedChanged);
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Enabled = false;
            this.rbServer.Location = new System.Drawing.Point(7, 12);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(77, 22);
            this.rbServer.TabIndex = 31;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpTas1945Ctrl);
            this.tabControl1.Controls.Add(this.tpDeviceCtrl);
            this.tabControl1.Controls.Add(this.tpFilter);
            this.tabControl1.Controls.Add(this.tpImageCal);
            this.tabControl1.Controls.Add(this.tpRegTest);
            this.tabControl1.Controls.Add(this.tpFTDI);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(6, 831);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1378, 199);
            this.tabControl1.TabIndex = 23;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpDeviceCtrl
            // 
            this.tpDeviceCtrl.Controls.Add(this.gbIpSetup);
            this.tpDeviceCtrl.Controls.Add(this.gbDeviceCtrl);
            this.tpDeviceCtrl.Location = new System.Drawing.Point(4, 27);
            this.tpDeviceCtrl.Name = "tpDeviceCtrl";
            this.tpDeviceCtrl.Size = new System.Drawing.Size(1370, 168);
            this.tpDeviceCtrl.TabIndex = 2;
            this.tpDeviceCtrl.Text = "Device Ctrl";
            this.tpDeviceCtrl.UseVisualStyleBackColor = true;
            // 
            // gbIpSetup
            // 
            this.gbIpSetup.Controls.Add(this.ipSetAddress);
            this.gbIpSetup.Controls.Add(this.nupSetPort);
            this.gbIpSetup.Controls.Add(this.btnIpSetup);
            this.gbIpSetup.Controls.Add(this.rbSetIpClient);
            this.gbIpSetup.Controls.Add(this.rbSetIpServer);
            this.gbIpSetup.Location = new System.Drawing.Point(247, 6);
            this.gbIpSetup.Name = "gbIpSetup";
            this.gbIpSetup.Size = new System.Drawing.Size(182, 163);
            this.gbIpSetup.TabIndex = 45;
            this.gbIpSetup.TabStop = false;
            this.gbIpSetup.Text = "IP Setup";
            // 
            // ipSetAddress
            // 
            this.ipSetAddress.AllowInternalTab = false;
            this.ipSetAddress.AutoHeight = true;
            this.ipSetAddress.BackColor = System.Drawing.SystemColors.Window;
            this.ipSetAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipSetAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipSetAddress.Location = new System.Drawing.Point(8, 36);
            this.ipSetAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ipSetAddress.MinimumSize = new System.Drawing.Size(126, 25);
            this.ipSetAddress.Name = "ipSetAddress";
            this.ipSetAddress.ReadOnly = false;
            this.ipSetAddress.Size = new System.Drawing.Size(167, 25);
            this.ipSetAddress.TabIndex = 41;
            this.ipSetAddress.Text = "192.168.1.10";
            // 
            // nupSetPort
            // 
            this.nupSetPort.Location = new System.Drawing.Point(8, 64);
            this.nupSetPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nupSetPort.Name = "nupSetPort";
            this.nupSetPort.Size = new System.Drawing.Size(67, 25);
            this.nupSetPort.TabIndex = 40;
            this.nupSetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupSetPort.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // btnIpSetup
            // 
            this.btnIpSetup.Location = new System.Drawing.Point(81, 61);
            this.btnIpSetup.Name = "btnIpSetup";
            this.btnIpSetup.Size = new System.Drawing.Size(94, 27);
            this.btnIpSetup.TabIndex = 39;
            this.btnIpSetup.Text = "Set IP";
            this.btnIpSetup.UseVisualStyleBackColor = true;
            this.btnIpSetup.Click += new System.EventHandler(this.btnIpSetup_Click);
            // 
            // rbSetIpClient
            // 
            this.rbSetIpClient.AutoSize = true;
            this.rbSetIpClient.Location = new System.Drawing.Point(111, 13);
            this.rbSetIpClient.Name = "rbSetIpClient";
            this.rbSetIpClient.Size = new System.Drawing.Size(77, 22);
            this.rbSetIpClient.TabIndex = 38;
            this.rbSetIpClient.Text = "Client";
            this.rbSetIpClient.UseVisualStyleBackColor = true;
            // 
            // rbSetIpServer
            // 
            this.rbSetIpServer.AutoSize = true;
            this.rbSetIpServer.Checked = true;
            this.rbSetIpServer.Location = new System.Drawing.Point(10, 13);
            this.rbSetIpServer.Name = "rbSetIpServer";
            this.rbSetIpServer.Size = new System.Drawing.Size(77, 22);
            this.rbSetIpServer.TabIndex = 37;
            this.rbSetIpServer.TabStop = true;
            this.rbSetIpServer.Text = "Server";
            this.rbSetIpServer.UseVisualStyleBackColor = true;
            // 
            // gbDeviceCtrl
            // 
            this.gbDeviceCtrl.Controls.Add(this.btnReset);
            this.gbDeviceCtrl.Controls.Add(this.btnResend);
            this.gbDeviceCtrl.Controls.Add(this.btnSetReadPLStart);
            this.gbDeviceCtrl.Controls.Add(this.btnGetSetupInfo);
            this.gbDeviceCtrl.Controls.Add(this.nudSetAvrCnt);
            this.gbDeviceCtrl.Controls.Add(this.btnSetAverage);
            this.gbDeviceCtrl.Controls.Add(this.tgsReadEdge);
            this.gbDeviceCtrl.Controls.Add(this.nudClockDelay);
            this.gbDeviceCtrl.Controls.Add(this.btnSetRead);
            this.gbDeviceCtrl.Controls.Add(this.nudSetClock);
            this.gbDeviceCtrl.Controls.Add(this.btnSetClock);
            this.gbDeviceCtrl.Location = new System.Drawing.Point(6, 6);
            this.gbDeviceCtrl.Name = "gbDeviceCtrl";
            this.gbDeviceCtrl.Size = new System.Drawing.Size(235, 163);
            this.gbDeviceCtrl.TabIndex = 44;
            this.gbDeviceCtrl.TabStop = false;
            this.gbDeviceCtrl.Text = "Device Ctrl";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(154, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 27);
            this.btnReset.TabIndex = 70;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnResend
            // 
            this.btnResend.Location = new System.Drawing.Point(6, 131);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(75, 27);
            this.btnResend.TabIndex = 69;
            this.btnResend.Text = "Resend";
            this.btnResend.UseVisualStyleBackColor = true;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // btnSetReadPLStart
            // 
            this.btnSetReadPLStart.Location = new System.Drawing.Point(6, 102);
            this.btnSetReadPLStart.Name = "btnSetReadPLStart";
            this.btnSetReadPLStart.Size = new System.Drawing.Size(75, 27);
            this.btnSetReadPLStart.TabIndex = 68;
            this.btnSetReadPLStart.Text = "PL Read";
            this.btnSetReadPLStart.UseVisualStyleBackColor = true;
            this.btnSetReadPLStart.Click += new System.EventHandler(this.btnSetReadPLStart_Click);
            // 
            // btnGetSetupInfo
            // 
            this.btnGetSetupInfo.Location = new System.Drawing.Point(154, 72);
            this.btnGetSetupInfo.Name = "btnGetSetupInfo";
            this.btnGetSetupInfo.Size = new System.Drawing.Size(75, 27);
            this.btnGetSetupInfo.TabIndex = 67;
            this.btnGetSetupInfo.Text = "Get Info";
            this.btnGetSetupInfo.UseVisualStyleBackColor = true;
            this.btnGetSetupInfo.Click += new System.EventHandler(this.btnGetSetupInfo_Click);
            // 
            // nudSetAvrCnt
            // 
            this.nudSetAvrCnt.Location = new System.Drawing.Point(87, 75);
            this.nudSetAvrCnt.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudSetAvrCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSetAvrCnt.Name = "nudSetAvrCnt";
            this.nudSetAvrCnt.ReadOnly = true;
            this.nudSetAvrCnt.Size = new System.Drawing.Size(62, 25);
            this.nudSetAvrCnt.TabIndex = 66;
            this.nudSetAvrCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSetAvrCnt.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btnSetAverage
            // 
            this.btnSetAverage.Location = new System.Drawing.Point(6, 73);
            this.btnSetAverage.Name = "btnSetAverage";
            this.btnSetAverage.Size = new System.Drawing.Size(75, 27);
            this.btnSetAverage.TabIndex = 65;
            this.btnSetAverage.Text = "Set AVR";
            this.btnSetAverage.UseVisualStyleBackColor = true;
            this.btnSetAverage.Click += new System.EventHandler(this.btnSetAverage_Click);
            // 
            // tgsReadEdge
            // 
            this.tgsReadEdge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsReadEdge.BackColor = System.Drawing.SystemColors.Control;
            this.tgsReadEdge.Location = new System.Drawing.Point(155, 45);
            this.tgsReadEdge.Name = "tgsReadEdge";
            this.tgsReadEdge.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsReadEdge.OffText = "R-Edge";
            this.tgsReadEdge.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsReadEdge.OnForeColor = System.Drawing.Color.White;
            this.tgsReadEdge.OnText = "F-Edge";
            this.tgsReadEdge.Size = new System.Drawing.Size(74, 25);
            this.tgsReadEdge.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsReadEdge.TabIndex = 64;
            // 
            // nudClockDelay
            // 
            this.nudClockDelay.Location = new System.Drawing.Point(87, 46);
            this.nudClockDelay.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudClockDelay.Name = "nudClockDelay";
            this.nudClockDelay.ReadOnly = true;
            this.nudClockDelay.Size = new System.Drawing.Size(62, 25);
            this.nudClockDelay.TabIndex = 63;
            this.nudClockDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSetRead
            // 
            this.btnSetRead.Location = new System.Drawing.Point(6, 44);
            this.btnSetRead.Name = "btnSetRead";
            this.btnSetRead.Size = new System.Drawing.Size(75, 27);
            this.btnSetRead.TabIndex = 62;
            this.btnSetRead.Text = "Set Read";
            this.btnSetRead.UseVisualStyleBackColor = true;
            this.btnSetRead.Click += new System.EventHandler(this.btnSetRead_Click);
            // 
            // nudSetClock
            // 
            this.nudSetClock.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSetClock.Location = new System.Drawing.Point(87, 20);
            this.nudSetClock.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSetClock.Name = "nudSetClock";
            this.nudSetClock.ReadOnly = true;
            this.nudSetClock.Size = new System.Drawing.Size(62, 25);
            this.nudSetClock.TabIndex = 61;
            this.nudSetClock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSetClock.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudSetClock.ValueChanged += new System.EventHandler(this.nudSetClock_ValueChanged);
            // 
            // btnSetClock
            // 
            this.btnSetClock.Location = new System.Drawing.Point(6, 16);
            this.btnSetClock.Name = "btnSetClock";
            this.btnSetClock.Size = new System.Drawing.Size(75, 27);
            this.btnSetClock.TabIndex = 49;
            this.btnSetClock.Text = "Set CLK";
            this.btnSetClock.UseVisualStyleBackColor = true;
            this.btnSetClock.Click += new System.EventHandler(this.btnSetClock_Click);
            // 
            // tpFilter
            // 
            this.tpFilter.Controls.Add(this.groupBox4);
            this.tpFilter.Controls.Add(this.groupBox3);
            this.tpFilter.Location = new System.Drawing.Point(4, 27);
            this.tpFilter.Name = "tpFilter";
            this.tpFilter.Size = new System.Drawing.Size(1370, 168);
            this.tpFilter.TabIndex = 1;
            this.tpFilter.Text = "Filter";
            this.tpFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tgsKalman);
            this.groupBox4.Location = new System.Drawing.Point(6, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 45);
            this.groupBox4.TabIndex = 92;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kalman Filter";
            // 
            // tgsKalman
            // 
            this.tgsKalman.BackColor = System.Drawing.SystemColors.Control;
            this.tgsKalman.Location = new System.Drawing.Point(144, 14);
            this.tgsKalman.Name = "tgsKalman";
            this.tgsKalman.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsKalman.OffText = "OFF";
            this.tgsKalman.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsKalman.OnForeColor = System.Drawing.Color.White;
            this.tgsKalman.OnText = "ON";
            this.tgsKalman.Size = new System.Drawing.Size(75, 25);
            this.tgsKalman.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsKalman.TabIndex = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.nudLpfSensitive);
            this.groupBox3.Controls.Add(this.tgsLpfIir);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 46);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LPF Filter";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 18);
            this.label15.TabIndex = 92;
            this.label15.Text = "Sensitive";
            // 
            // nudLpfSensitive
            // 
            this.nudLpfSensitive.DecimalPlaces = 2;
            this.nudLpfSensitive.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudLpfSensitive.Location = new System.Drawing.Point(77, 17);
            this.nudLpfSensitive.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLpfSensitive.Name = "nudLpfSensitive";
            this.nudLpfSensitive.Size = new System.Drawing.Size(61, 25);
            this.nudLpfSensitive.TabIndex = 91;
            this.nudLpfSensitive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudLpfSensitive.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // tgsLpfIir
            // 
            this.tgsLpfIir.BackColor = System.Drawing.SystemColors.Control;
            this.tgsLpfIir.Location = new System.Drawing.Point(144, 14);
            this.tgsLpfIir.Name = "tgsLpfIir";
            this.tgsLpfIir.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsLpfIir.OffText = "IIR OFF";
            this.tgsLpfIir.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsLpfIir.OnForeColor = System.Drawing.Color.White;
            this.tgsLpfIir.OnText = "IIR ON";
            this.tgsLpfIir.Size = new System.Drawing.Size(75, 25);
            this.tgsLpfIir.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsLpfIir.TabIndex = 87;
            // 
            // tpImageCal
            // 
            this.tpImageCal.Controls.Add(this.btnColInit);
            this.tpImageCal.Controls.Add(this.btnColLive);
            this.tpImageCal.Controls.Add(this.btnXYInit);
            this.tpImageCal.Controls.Add(this.btnXYLive);
            this.tpImageCal.Controls.Add(this.btnXYDead);
            this.tpImageCal.Controls.Add(this.btnColDead);
            this.tpImageCal.Controls.Add(this.tbY_dpc);
            this.tpImageCal.Controls.Add(this.tbX_dpc);
            this.tpImageCal.Controls.Add(this.tbColselect);
            this.tpImageCal.Controls.Add(this.cbISPoffset);
            this.tpImageCal.Controls.Add(this.btnISPoffsetCal);
            this.tpImageCal.Controls.Add(this.btcalOffsetload);
            this.tpImageCal.Controls.Add(this.btnDataverify);
            this.tpImageCal.Controls.Add(this.btnKalmanError);
            this.tpImageCal.Controls.Add(this.tbKalmanError);
            this.tpImageCal.Controls.Add(this.btnDP_cal);
            this.tpImageCal.Controls.Add(this.btnGain);
            this.tpImageCal.Controls.Add(this.tbNoise_min);
            this.tpImageCal.Controls.Add(this.tbSignal_min);
            this.tpImageCal.Controls.Add(this.tbStoN_min);
            this.tpImageCal.Controls.Add(this.tbNoise_max);
            this.tpImageCal.Controls.Add(this.tbSignal_max);
            this.tpImageCal.Controls.Add(this.tbStoN_max);
            this.tpImageCal.Controls.Add(this.tbGain);
            this.tpImageCal.Controls.Add(this.lbGain);
            this.tpImageCal.Controls.Add(this.label17);
            this.tpImageCal.Controls.Add(this.label20);
            this.tpImageCal.Controls.Add(this.label23);
            this.tpImageCal.Controls.Add(this.label22);
            this.tpImageCal.Controls.Add(this.label21);
            this.tpImageCal.Controls.Add(this.label19);
            this.tpImageCal.Controls.Add(this.label26);
            this.tpImageCal.Controls.Add(this.label28);
            this.tpImageCal.Controls.Add(this.label25);
            this.tpImageCal.Controls.Add(this.lbDPC_apply_cnt);
            this.tpImageCal.Controls.Add(this.lbLivePixel_count);
            this.tpImageCal.Controls.Add(this.label30);
            this.tpImageCal.Controls.Add(this.label24);
            this.tpImageCal.Controls.Add(this.lbDPC_apply_perc);
            this.tpImageCal.Controls.Add(this.lbLivePixel_perc);
            this.tpImageCal.Controls.Add(this.lbKalmanError);
            this.tpImageCal.Controls.Add(this.label27);
            this.tpImageCal.Controls.Add(this.label18);
            this.tpImageCal.Controls.Add(this.label16);
            this.tpImageCal.Controls.Add(this.cbDPC_apply);
            this.tpImageCal.Controls.Add(this.Noise_ck);
            this.tpImageCal.Controls.Add(this.cbNF_apply);
            this.tpImageCal.Controls.Add(this.Signal_ck);
            this.tpImageCal.Controls.Add(this.StoN_ck);
            this.tpImageCal.Controls.Add(this.cbDP_apply);
            this.tpImageCal.Controls.Add(this.cbSensitivy_cal);
            this.tpImageCal.Controls.Add(this.nudcal35);
            this.tpImageCal.Controls.Add(this.nudcal45);
            this.tpImageCal.Controls.Add(this.nudcal25);
            this.tpImageCal.Controls.Add(this.btncal35);
            this.tpImageCal.Controls.Add(this.btncal45);
            this.tpImageCal.Controls.Add(this.btcal35load);
            this.tpImageCal.Controls.Add(this.btcal45load);
            this.tpImageCal.Controls.Add(this.btcal25load);
            this.tpImageCal.Controls.Add(this.btncal25);
            this.tpImageCal.Controls.Add(this.cbCalmode);
            this.tpImageCal.Controls.Add(this.cbABS_apply);
            this.tpImageCal.Controls.Add(this.cbOffset_apply);
            this.tpImageCal.Location = new System.Drawing.Point(4, 27);
            this.tpImageCal.Name = "tpImageCal";
            this.tpImageCal.Padding = new System.Windows.Forms.Padding(3);
            this.tpImageCal.Size = new System.Drawing.Size(1370, 168);
            this.tpImageCal.TabIndex = 3;
            this.tpImageCal.Text = "Image Cal";
            this.tpImageCal.UseVisualStyleBackColor = true;
            // 
            // btnColInit
            // 
            this.btnColInit.Location = new System.Drawing.Point(830, 134);
            this.btnColInit.Name = "btnColInit";
            this.btnColInit.Size = new System.Drawing.Size(46, 31);
            this.btnColInit.TabIndex = 14;
            this.btnColInit.Text = "Init";
            this.btnColInit.UseVisualStyleBackColor = true;
            this.btnColInit.Click += new System.EventHandler(this.btnColInit_Click);
            // 
            // btnColLive
            // 
            this.btnColLive.Location = new System.Drawing.Point(830, 102);
            this.btnColLive.Name = "btnColLive";
            this.btnColLive.Size = new System.Drawing.Size(46, 31);
            this.btnColLive.TabIndex = 14;
            this.btnColLive.Text = "L";
            this.btnColLive.UseVisualStyleBackColor = true;
            this.btnColLive.Click += new System.EventHandler(this.btnColLive_Click);
            // 
            // btnXYInit
            // 
            this.btnXYInit.Location = new System.Drawing.Point(928, 134);
            this.btnXYInit.Name = "btnXYInit";
            this.btnXYInit.Size = new System.Drawing.Size(46, 31);
            this.btnXYInit.TabIndex = 14;
            this.btnXYInit.Text = "Init";
            this.btnXYInit.UseVisualStyleBackColor = true;
            this.btnXYInit.Click += new System.EventHandler(this.btnXYInit_Click);
            // 
            // btnXYLive
            // 
            this.btnXYLive.Location = new System.Drawing.Point(928, 102);
            this.btnXYLive.Name = "btnXYLive";
            this.btnXYLive.Size = new System.Drawing.Size(46, 31);
            this.btnXYLive.TabIndex = 14;
            this.btnXYLive.Text = "L";
            this.btnXYLive.UseVisualStyleBackColor = true;
            this.btnXYLive.Click += new System.EventHandler(this.btnXYLive_Click);
            // 
            // btnXYDead
            // 
            this.btnXYDead.Location = new System.Drawing.Point(928, 71);
            this.btnXYDead.Name = "btnXYDead";
            this.btnXYDead.Size = new System.Drawing.Size(46, 31);
            this.btnXYDead.TabIndex = 14;
            this.btnXYDead.Text = "D";
            this.btnXYDead.UseVisualStyleBackColor = true;
            this.btnXYDead.Click += new System.EventHandler(this.btnXYDead_Click);
            // 
            // btnColDead
            // 
            this.btnColDead.Location = new System.Drawing.Point(830, 71);
            this.btnColDead.Name = "btnColDead";
            this.btnColDead.Size = new System.Drawing.Size(46, 31);
            this.btnColDead.TabIndex = 14;
            this.btnColDead.Text = "D";
            this.btnColDead.UseVisualStyleBackColor = true;
            this.btnColDead.Click += new System.EventHandler(this.btnColDead_Click);
            // 
            // tbY_dpc
            // 
            this.tbY_dpc.Location = new System.Drawing.Point(887, 106);
            this.tbY_dpc.Name = "tbY_dpc";
            this.tbY_dpc.Size = new System.Drawing.Size(35, 25);
            this.tbY_dpc.TabIndex = 13;
            this.tbY_dpc.Text = "Y";
            // 
            // tbX_dpc
            // 
            this.tbX_dpc.Location = new System.Drawing.Point(887, 75);
            this.tbX_dpc.Name = "tbX_dpc";
            this.tbX_dpc.Size = new System.Drawing.Size(35, 25);
            this.tbX_dpc.TabIndex = 13;
            this.tbX_dpc.Text = "X";
            // 
            // tbColselect
            // 
            this.tbColselect.Location = new System.Drawing.Point(791, 75);
            this.tbColselect.Name = "tbColselect";
            this.tbColselect.Size = new System.Drawing.Size(35, 25);
            this.tbColselect.TabIndex = 13;
            this.tbColselect.Text = "Col";
            // 
            // cbISPoffset
            // 
            this.cbISPoffset.AutoSize = true;
            this.cbISPoffset.Location = new System.Drawing.Point(210, 117);
            this.cbISPoffset.Name = "cbISPoffset";
            this.cbISPoffset.Size = new System.Drawing.Size(18, 17);
            this.cbISPoffset.TabIndex = 12;
            this.cbISPoffset.UseVisualStyleBackColor = true;
            this.cbISPoffset.CheckedChanged += new System.EventHandler(this.cbISPoffset_CheckedChanged);
            // 
            // btnISPoffsetCal
            // 
            this.btnISPoffsetCal.Location = new System.Drawing.Point(103, 113);
            this.btnISPoffsetCal.Name = "btnISPoffsetCal";
            this.btnISPoffsetCal.Size = new System.Drawing.Size(105, 38);
            this.btnISPoffsetCal.TabIndex = 11;
            this.btnISPoffsetCal.Text = "ISPoffset";
            this.btnISPoffsetCal.UseVisualStyleBackColor = true;
            this.btnISPoffsetCal.Click += new System.EventHandler(this.btnISPoffsetCal_Click);
            // 
            // btcalOffsetload
            // 
            this.btcalOffsetload.Location = new System.Drawing.Point(248, 112);
            this.btcalOffsetload.Name = "btcalOffsetload";
            this.btcalOffsetload.Size = new System.Drawing.Size(112, 23);
            this.btcalOffsetload.TabIndex = 10;
            this.btcalOffsetload.Text = "Load Offset";
            this.btcalOffsetload.UseVisualStyleBackColor = true;
            this.btcalOffsetload.Click += new System.EventHandler(this.g_calCtrl_btLoad);
            // 
            // btnDataverify
            // 
            this.btnDataverify.Location = new System.Drawing.Point(13, 80);
            this.btnDataverify.Name = "btnDataverify";
            this.btnDataverify.Size = new System.Drawing.Size(80, 38);
            this.btnDataverify.TabIndex = 9;
            this.btnDataverify.Text = "Data 검증";
            this.btnDataverify.UseVisualStyleBackColor = true;
            this.btnDataverify.Click += new System.EventHandler(this.btnDataverify_Click);
            // 
            // btnKalmanError
            // 
            this.btnKalmanError.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKalmanError.Location = new System.Drawing.Point(1158, 70);
            this.btnKalmanError.Name = "btnKalmanError";
            this.btnKalmanError.Size = new System.Drawing.Size(45, 29);
            this.btnKalmanError.TabIndex = 8;
            this.btnKalmanError.Text = "적용";
            this.btnKalmanError.UseVisualStyleBackColor = true;
            this.btnKalmanError.Click += new System.EventHandler(this.btnKalmanError_Click);
            // 
            // tbKalmanError
            // 
            this.tbKalmanError.Location = new System.Drawing.Point(1105, 71);
            this.tbKalmanError.Name = "tbKalmanError";
            this.tbKalmanError.Size = new System.Drawing.Size(51, 25);
            this.tbKalmanError.TabIndex = 7;
            this.tbKalmanError.Text = "2";
            // 
            // btnDP_cal
            // 
            this.btnDP_cal.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDP_cal.Location = new System.Drawing.Point(741, 117);
            this.btnDP_cal.Name = "btnDP_cal";
            this.btnDP_cal.Size = new System.Drawing.Size(47, 34);
            this.btnDP_cal.TabIndex = 6;
            this.btnDP_cal.Text = "적용";
            this.btnDP_cal.UseVisualStyleBackColor = true;
            this.btnDP_cal.Click += new System.EventHandler(this.btnDP_cal_Click);
            // 
            // btnGain
            // 
            this.btnGain.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGain.Location = new System.Drawing.Point(748, 35);
            this.btnGain.Name = "btnGain";
            this.btnGain.Size = new System.Drawing.Size(47, 32);
            this.btnGain.TabIndex = 6;
            this.btnGain.Text = "적용";
            this.btnGain.UseVisualStyleBackColor = true;
            this.btnGain.Click += new System.EventHandler(this.btnGain_Click);
            // 
            // tbNoise_min
            // 
            this.tbNoise_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoise_min.Location = new System.Drawing.Point(683, 137);
            this.tbNoise_min.Name = "tbNoise_min";
            this.tbNoise_min.Size = new System.Drawing.Size(42, 25);
            this.tbNoise_min.TabIndex = 5;
            this.tbNoise_min.Text = "0";
            // 
            // tbSignal_min
            // 
            this.tbSignal_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSignal_min.Location = new System.Drawing.Point(617, 137);
            this.tbSignal_min.Name = "tbSignal_min";
            this.tbSignal_min.Size = new System.Drawing.Size(42, 25);
            this.tbSignal_min.TabIndex = 5;
            this.tbSignal_min.Text = "0";
            // 
            // tbStoN_min
            // 
            this.tbStoN_min.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStoN_min.Location = new System.Drawing.Point(548, 137);
            this.tbStoN_min.Name = "tbStoN_min";
            this.tbStoN_min.Size = new System.Drawing.Size(42, 25);
            this.tbStoN_min.TabIndex = 5;
            this.tbStoN_min.Text = "0.5";
            // 
            // tbNoise_max
            // 
            this.tbNoise_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoise_max.Location = new System.Drawing.Point(683, 112);
            this.tbNoise_max.Name = "tbNoise_max";
            this.tbNoise_max.Size = new System.Drawing.Size(42, 25);
            this.tbNoise_max.TabIndex = 5;
            this.tbNoise_max.Text = "200";
            // 
            // tbSignal_max
            // 
            this.tbSignal_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSignal_max.Location = new System.Drawing.Point(617, 112);
            this.tbSignal_max.Name = "tbSignal_max";
            this.tbSignal_max.Size = new System.Drawing.Size(42, 25);
            this.tbSignal_max.TabIndex = 5;
            this.tbSignal_max.Text = "200";
            // 
            // tbStoN_max
            // 
            this.tbStoN_max.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStoN_max.Location = new System.Drawing.Point(548, 112);
            this.tbStoN_max.Name = "tbStoN_max";
            this.tbStoN_max.Size = new System.Drawing.Size(42, 25);
            this.tbStoN_max.TabIndex = 5;
            this.tbStoN_max.Text = "99999";
            // 
            // tbGain
            // 
            this.tbGain.Location = new System.Drawing.Point(674, 40);
            this.tbGain.Name = "tbGain";
            this.tbGain.Size = new System.Drawing.Size(68, 25);
            this.tbGain.TabIndex = 5;
            this.tbGain.Text = "1000";
            // 
            // lbGain
            // 
            this.lbGain.AutoSize = true;
            this.lbGain.Location = new System.Drawing.Point(603, 44);
            this.lbGain.Name = "lbGain";
            this.lbGain.Size = new System.Drawing.Size(0, 18);
            this.lbGain.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(801, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "(1 ~ 1,000,000) ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label20.Location = new System.Drawing.Point(498, 141);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 18);
            this.label20.TabIndex = 4;
            this.label20.Text = "MIN :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label23.Location = new System.Drawing.Point(679, 90);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 18);
            this.label23.TabIndex = 4;
            this.label23.Text = "Noise";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(605, 90);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 18);
            this.label22.TabIndex = 4;
            this.label22.Text = "Signal";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Location = new System.Drawing.Point(544, 90);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 18);
            this.label21.TabIndex = 4;
            this.label21.Text = "StoN";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label19.Location = new System.Drawing.Point(499, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 18);
            this.label19.TabIndex = 4;
            this.label19.Text = "MAX :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(1053, 74);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 18);
            this.label26.TabIndex = 4;
            this.label26.Text = "M.E :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(1089, 137);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 18);
            this.label28.TabIndex = 4;
            this.label28.Text = "Live:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(366, 125);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 18);
            this.label25.TabIndex = 4;
            this.label25.Text = "Live:";
            // 
            // lbDPC_apply_cnt
            // 
            this.lbDPC_apply_cnt.AutoSize = true;
            this.lbDPC_apply_cnt.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbDPC_apply_cnt.Location = new System.Drawing.Point(1144, 143);
            this.lbDPC_apply_cnt.Name = "lbDPC_apply_cnt";
            this.lbDPC_apply_cnt.Size = new System.Drawing.Size(24, 18);
            this.lbDPC_apply_cnt.TabIndex = 4;
            this.lbDPC_apply_cnt.Text = "00";
            // 
            // lbLivePixel_count
            // 
            this.lbLivePixel_count.AutoSize = true;
            this.lbLivePixel_count.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbLivePixel_count.Location = new System.Drawing.Point(416, 137);
            this.lbLivePixel_count.Name = "lbLivePixel_count";
            this.lbLivePixel_count.Size = new System.Drawing.Size(24, 18);
            this.lbLivePixel_count.TabIndex = 4;
            this.lbLivePixel_count.Text = "00";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(1176, 144);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 18);
            this.label30.TabIndex = 4;
            this.label30.Text = "/4860";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(448, 138);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 18);
            this.label24.TabIndex = 4;
            this.label24.Text = "/4860";
            // 
            // lbDPC_apply_perc
            // 
            this.lbDPC_apply_perc.AutoSize = true;
            this.lbDPC_apply_perc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbDPC_apply_perc.Location = new System.Drawing.Point(1143, 119);
            this.lbDPC_apply_perc.Name = "lbDPC_apply_perc";
            this.lbDPC_apply_perc.Size = new System.Drawing.Size(32, 18);
            this.lbDPC_apply_perc.TabIndex = 4;
            this.lbDPC_apply_perc.Text = "00%";
            // 
            // lbLivePixel_perc
            // 
            this.lbLivePixel_perc.AutoSize = true;
            this.lbLivePixel_perc.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbLivePixel_perc.Location = new System.Drawing.Point(413, 112);
            this.lbLivePixel_perc.Name = "lbLivePixel_perc";
            this.lbLivePixel_perc.Size = new System.Drawing.Size(32, 18);
            this.lbLivePixel_perc.TabIndex = 4;
            this.lbLivePixel_perc.Text = "00%";
            // 
            // lbKalmanError
            // 
            this.lbKalmanError.AutoSize = true;
            this.lbKalmanError.Location = new System.Drawing.Point(1287, 76);
            this.lbKalmanError.Name = "lbKalmanError";
            this.lbKalmanError.Size = new System.Drawing.Size(0, 18);
            this.lbKalmanError.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(1207, 75);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(78, 18);
            this.label27.TabIndex = 4;
            this.label27.Text = "(현재 M.E:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(510, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 18);
            this.label18.TabIndex = 4;
            this.label18.Text = "(현재 Gain:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(510, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(418, 18);
            this.label16.TabIndex = 4;
            this.label16.Text = "(Check 시, Offset/Move8 효과 사라짐 + 아래 Cal기능 사용가능)";
            // 
            // cbDPC_apply
            // 
            this.cbDPC_apply.AutoSize = true;
            this.cbDPC_apply.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDPC_apply.Location = new System.Drawing.Point(1029, 109);
            this.cbDPC_apply.Name = "cbDPC_apply";
            this.cbDPC_apply.Size = new System.Drawing.Size(91, 24);
            this.cbDPC_apply.TabIndex = 3;
            this.cbDPC_apply.Text = "DPC 적용";
            this.cbDPC_apply.UseVisualStyleBackColor = true;
            this.cbDPC_apply.CheckedChanged += new System.EventHandler(this.cbDPC_apply_CheckedChanged);
            // 
            // Noise_ck
            // 
            this.Noise_ck.AutoSize = true;
            this.Noise_ck.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Noise_ck.Location = new System.Drawing.Point(727, 92);
            this.Noise_ck.Name = "Noise_ck";
            this.Noise_ck.Size = new System.Drawing.Size(18, 17);
            this.Noise_ck.TabIndex = 3;
            this.Noise_ck.UseVisualStyleBackColor = true;
            this.Noise_ck.CheckedChanged += new System.EventHandler(this.Noise_ck_CheckedChanged);
            // 
            // cbNF_apply
            // 
            this.cbNF_apply.AutoSize = true;
            this.cbNF_apply.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNF_apply.Location = new System.Drawing.Point(1029, 41);
            this.cbNF_apply.Name = "cbNF_apply";
            this.cbNF_apply.Size = new System.Drawing.Size(289, 24);
            this.cbNF_apply.TabIndex = 3;
            this.cbNF_apply.Text = "노이즈 필터 적용(MoveAvg.Kalman순)";
            this.cbNF_apply.UseVisualStyleBackColor = true;
            this.cbNF_apply.CheckedChanged += new System.EventHandler(this.cbNF_apply_CheckedChanged);
            // 
            // Signal_ck
            // 
            this.Signal_ck.AutoSize = true;
            this.Signal_ck.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Signal_ck.Location = new System.Drawing.Point(661, 92);
            this.Signal_ck.Name = "Signal_ck";
            this.Signal_ck.Size = new System.Drawing.Size(18, 17);
            this.Signal_ck.TabIndex = 3;
            this.Signal_ck.UseVisualStyleBackColor = true;
            this.Signal_ck.CheckedChanged += new System.EventHandler(this.Signal_ck_CheckedChanged);
            // 
            // StoN_ck
            // 
            this.StoN_ck.AutoSize = true;
            this.StoN_ck.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.StoN_ck.Location = new System.Drawing.Point(584, 92);
            this.StoN_ck.Name = "StoN_ck";
            this.StoN_ck.Size = new System.Drawing.Size(18, 17);
            this.StoN_ck.TabIndex = 3;
            this.StoN_ck.UseVisualStyleBackColor = true;
            this.StoN_ck.CheckedChanged += new System.EventHandler(this.StoN_ck_CheckedChanged);
            // 
            // cbDP_apply
            // 
            this.cbDP_apply.AutoSize = true;
            this.cbDP_apply.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDP_apply.Location = new System.Drawing.Point(392, 89);
            this.cbDP_apply.Name = "cbDP_apply";
            this.cbDP_apply.Size = new System.Drawing.Size(154, 24);
            this.cbDP_apply.TabIndex = 3;
            this.cbDP_apply.Text = "Dead Pixel 적용";
            this.cbDP_apply.UseVisualStyleBackColor = true;
            this.cbDP_apply.CheckedChanged += new System.EventHandler(this.cbDP_apply_CheckedChanged);
            // 
            // cbSensitivy_cal
            // 
            this.cbSensitivy_cal.AutoSize = true;
            this.cbSensitivy_cal.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSensitivy_cal.Location = new System.Drawing.Point(392, 43);
            this.cbSensitivy_cal.Name = "cbSensitivy_cal";
            this.cbSensitivy_cal.Size = new System.Drawing.Size(112, 24);
            this.cbSensitivy_cal.TabIndex = 3;
            this.cbSensitivy_cal.Text = "감도보정 적용";
            this.cbSensitivy_cal.UseVisualStyleBackColor = true;
            this.cbSensitivy_cal.CheckedChanged += new System.EventHandler(this.cbSensitivy_cal_CheckedChanged);
            // 
            // nudcal35
            // 
            this.nudcal35.Location = new System.Drawing.Point(206, 77);
            this.nudcal35.Name = "nudcal35";
            this.nudcal35.Size = new System.Drawing.Size(56, 25);
            this.nudcal35.TabIndex = 2;
            this.nudcal35.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudcal45
            // 
            this.nudcal45.Location = new System.Drawing.Point(206, 45);
            this.nudcal45.Name = "nudcal45";
            this.nudcal45.Size = new System.Drawing.Size(56, 25);
            this.nudcal45.TabIndex = 2;
            this.nudcal45.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudcal25
            // 
            this.nudcal25.Location = new System.Drawing.Point(206, 16);
            this.nudcal25.Name = "nudcal25";
            this.nudcal25.Size = new System.Drawing.Size(56, 25);
            this.nudcal25.TabIndex = 2;
            this.nudcal25.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btncal35
            // 
            this.btncal35.Location = new System.Drawing.Point(128, 78);
            this.btncal35.Name = "btncal35";
            this.btncal35.Size = new System.Drawing.Size(75, 23);
            this.btncal35.TabIndex = 1;
            this.btncal35.Text = "35℃ Cal";
            this.btncal35.UseVisualStyleBackColor = true;
            this.btncal35.Click += new System.EventHandler(this.btncal35_Click);
            // 
            // btncal45
            // 
            this.btncal45.Location = new System.Drawing.Point(128, 44);
            this.btncal45.Name = "btncal45";
            this.btncal45.Size = new System.Drawing.Size(75, 23);
            this.btncal45.TabIndex = 1;
            this.btncal45.Text = "45℃ Cal";
            this.btncal45.UseVisualStyleBackColor = true;
            this.btncal45.Click += new System.EventHandler(this.btncal45_Click);
            // 
            // btcal35load
            // 
            this.btcal35load.Location = new System.Drawing.Point(265, 77);
            this.btcal35load.Name = "btcal35load";
            this.btcal35load.Size = new System.Drawing.Size(95, 23);
            this.btcal35load.TabIndex = 1;
            this.btcal35load.Text = "Load 35℃";
            this.btcal35load.UseVisualStyleBackColor = true;
            this.btcal35load.Click += new System.EventHandler(this.g_calCtrl_btLoad);
            // 
            // btcal45load
            // 
            this.btcal45load.Location = new System.Drawing.Point(265, 45);
            this.btcal45load.Name = "btcal45load";
            this.btcal45load.Size = new System.Drawing.Size(95, 23);
            this.btcal45load.TabIndex = 1;
            this.btcal45load.Text = "Load 45℃";
            this.btcal45load.UseVisualStyleBackColor = true;
            this.btcal45load.Click += new System.EventHandler(this.g_calCtrl_btLoad);
            // 
            // btcal25load
            // 
            this.btcal25load.Location = new System.Drawing.Point(265, 16);
            this.btcal25load.Name = "btcal25load";
            this.btcal25load.Size = new System.Drawing.Size(95, 23);
            this.btcal25load.TabIndex = 1;
            this.btcal25load.Text = "Load 25℃";
            this.btcal25load.UseVisualStyleBackColor = true;
            this.btcal25load.Click += new System.EventHandler(this.g_calCtrl_btLoad);
            // 
            // btncal25
            // 
            this.btncal25.Location = new System.Drawing.Point(128, 15);
            this.btncal25.Name = "btncal25";
            this.btncal25.Size = new System.Drawing.Size(75, 23);
            this.btncal25.TabIndex = 1;
            this.btncal25.Text = "25℃ Cal";
            this.btncal25.UseVisualStyleBackColor = true;
            this.btncal25.Click += new System.EventHandler(this.btncal25_Click);
            // 
            // cbCalmode
            // 
            this.cbCalmode.AutoSize = true;
            this.cbCalmode.BackColor = System.Drawing.Color.Transparent;
            this.cbCalmode.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCalmode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCalmode.Location = new System.Drawing.Point(368, 13);
            this.cbCalmode.Name = "cbCalmode";
            this.cbCalmode.Size = new System.Drawing.Size(136, 24);
            this.cbCalmode.TabIndex = 0;
            this.cbCalmode.Text = "Cal Mode 적용";
            this.cbCalmode.UseVisualStyleBackColor = false;
            this.cbCalmode.CheckedChanged += new System.EventHandler(this.cbCalmode_CheckedChanged);
            // 
            // cbABS_apply
            // 
            this.cbABS_apply.AutoSize = true;
            this.cbABS_apply.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbABS_apply.Location = new System.Drawing.Point(17, 53);
            this.cbABS_apply.Name = "cbABS_apply";
            this.cbABS_apply.Size = new System.Drawing.Size(110, 22);
            this.cbABS_apply.TabIndex = 0;
            this.cbABS_apply.Text = "ABS(pixel)";
            this.cbABS_apply.UseVisualStyleBackColor = true;
            // 
            // cbOffset_apply
            // 
            this.cbOffset_apply.AutoSize = true;
            this.cbOffset_apply.Checked = true;
            this.cbOffset_apply.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOffset_apply.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOffset_apply.Location = new System.Drawing.Point(17, 16);
            this.cbOffset_apply.Name = "cbOffset_apply";
            this.cbOffset_apply.Size = new System.Drawing.Size(108, 22);
            this.cbOffset_apply.TabIndex = 0;
            this.cbOffset_apply.Text = "Offset 적용";
            this.cbOffset_apply.UseVisualStyleBackColor = true;
            // 
            // tpRegTest
            // 
            this.tpRegTest.Controls.Add(this.btnRegRD_Set2);
            this.tpRegTest.Controls.Add(this.btnRegWR_Set2);
            this.tpRegTest.Controls.Add(this.btnRegRD_Set1);
            this.tpRegTest.Controls.Add(this.btnRegWR_Set1);
            this.tpRegTest.Controls.Add(this.tbReg215_Set2);
            this.tpRegTest.Controls.Add(this.tbReg215_Set1);
            this.tpRegTest.Controls.Add(this.tbReg213_Set2);
            this.tpRegTest.Controls.Add(this.tbReg213_Set1);
            this.tpRegTest.Controls.Add(this.tbReg154_Set2);
            this.tpRegTest.Controls.Add(this.tbReg154_Set1);
            this.tpRegTest.Controls.Add(this.tbReg127_Set2);
            this.tpRegTest.Controls.Add(this.tbReg127_Set1);
            this.tpRegTest.Controls.Add(this.nudTestReg_215);
            this.tpRegTest.Controls.Add(this.nudTestReg_213);
            this.tpRegTest.Controls.Add(this.nudTestReg_154);
            this.tpRegTest.Controls.Add(this.nudTestReg_127);
            this.tpRegTest.Controls.Add(this.label32);
            this.tpRegTest.Controls.Add(this.label31);
            this.tpRegTest.Controls.Add(this.label29);
            this.tpRegTest.Location = new System.Drawing.Point(4, 27);
            this.tpRegTest.Name = "tpRegTest";
            this.tpRegTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpRegTest.Size = new System.Drawing.Size(1370, 168);
            this.tpRegTest.TabIndex = 4;
            this.tpRegTest.Text = "Reg Test";
            this.tpRegTest.UseVisualStyleBackColor = true;
            // 
            // btnRegRD_Set2
            // 
            this.btnRegRD_Set2.Location = new System.Drawing.Point(534, 116);
            this.btnRegRD_Set2.Name = "btnRegRD_Set2";
            this.btnRegRD_Set2.Size = new System.Drawing.Size(76, 31);
            this.btnRegRD_Set2.TabIndex = 3;
            this.btnRegRD_Set2.Text = "Set2 RD";
            this.btnRegRD_Set2.UseVisualStyleBackColor = true;
            this.btnRegRD_Set2.Click += new System.EventHandler(this.btnRegRD_Set2_Click);
            // 
            // btnRegWR_Set2
            // 
            this.btnRegWR_Set2.Location = new System.Drawing.Point(452, 116);
            this.btnRegWR_Set2.Name = "btnRegWR_Set2";
            this.btnRegWR_Set2.Size = new System.Drawing.Size(76, 31);
            this.btnRegWR_Set2.TabIndex = 3;
            this.btnRegWR_Set2.Text = "Set2 WR";
            this.btnRegWR_Set2.UseVisualStyleBackColor = true;
            this.btnRegWR_Set2.Click += new System.EventHandler(this.btnRegWR_Set2_Click);
            // 
            // btnRegRD_Set1
            // 
            this.btnRegRD_Set1.Location = new System.Drawing.Point(534, 71);
            this.btnRegRD_Set1.Name = "btnRegRD_Set1";
            this.btnRegRD_Set1.Size = new System.Drawing.Size(76, 31);
            this.btnRegRD_Set1.TabIndex = 3;
            this.btnRegRD_Set1.Text = "Set1 RD";
            this.btnRegRD_Set1.UseVisualStyleBackColor = true;
            this.btnRegRD_Set1.Click += new System.EventHandler(this.btnRegRD_Set1_Click);
            // 
            // btnRegWR_Set1
            // 
            this.btnRegWR_Set1.Location = new System.Drawing.Point(452, 71);
            this.btnRegWR_Set1.Name = "btnRegWR_Set1";
            this.btnRegWR_Set1.Size = new System.Drawing.Size(76, 31);
            this.btnRegWR_Set1.TabIndex = 3;
            this.btnRegWR_Set1.Text = "Set1 WR";
            this.btnRegWR_Set1.UseVisualStyleBackColor = true;
            this.btnRegWR_Set1.Click += new System.EventHandler(this.btnRegWR_Set1_Click);
            // 
            // tbReg215_Set2
            // 
            this.tbReg215_Set2.Location = new System.Drawing.Point(370, 119);
            this.tbReg215_Set2.Name = "tbReg215_Set2";
            this.tbReg215_Set2.Size = new System.Drawing.Size(61, 25);
            this.tbReg215_Set2.TabIndex = 2;
            this.tbReg215_Set2.Text = "1B";
            // 
            // tbReg215_Set1
            // 
            this.tbReg215_Set1.Location = new System.Drawing.Point(369, 74);
            this.tbReg215_Set1.Name = "tbReg215_Set1";
            this.tbReg215_Set1.Size = new System.Drawing.Size(61, 25);
            this.tbReg215_Set1.TabIndex = 2;
            this.tbReg215_Set1.Text = "1B";
            // 
            // tbReg213_Set2
            // 
            this.tbReg213_Set2.Location = new System.Drawing.Point(291, 119);
            this.tbReg213_Set2.Name = "tbReg213_Set2";
            this.tbReg213_Set2.Size = new System.Drawing.Size(61, 25);
            this.tbReg213_Set2.TabIndex = 2;
            this.tbReg213_Set2.Text = "17";
            // 
            // tbReg213_Set1
            // 
            this.tbReg213_Set1.Location = new System.Drawing.Point(290, 74);
            this.tbReg213_Set1.Name = "tbReg213_Set1";
            this.tbReg213_Set1.Size = new System.Drawing.Size(61, 25);
            this.tbReg213_Set1.TabIndex = 2;
            this.tbReg213_Set1.Text = "17";
            // 
            // tbReg154_Set2
            // 
            this.tbReg154_Set2.Location = new System.Drawing.Point(211, 119);
            this.tbReg154_Set2.Name = "tbReg154_Set2";
            this.tbReg154_Set2.Size = new System.Drawing.Size(61, 25);
            this.tbReg154_Set2.TabIndex = 2;
            this.tbReg154_Set2.Text = "18";
            // 
            // tbReg154_Set1
            // 
            this.tbReg154_Set1.Location = new System.Drawing.Point(210, 74);
            this.tbReg154_Set1.Name = "tbReg154_Set1";
            this.tbReg154_Set1.Size = new System.Drawing.Size(61, 25);
            this.tbReg154_Set1.TabIndex = 2;
            this.tbReg154_Set1.Text = "18";
            // 
            // tbReg127_Set2
            // 
            this.tbReg127_Set2.Location = new System.Drawing.Point(131, 119);
            this.tbReg127_Set2.Name = "tbReg127_Set2";
            this.tbReg127_Set2.Size = new System.Drawing.Size(61, 25);
            this.tbReg127_Set2.TabIndex = 2;
            this.tbReg127_Set2.Text = "03";
            // 
            // tbReg127_Set1
            // 
            this.tbReg127_Set1.Location = new System.Drawing.Point(130, 74);
            this.tbReg127_Set1.Name = "tbReg127_Set1";
            this.tbReg127_Set1.Size = new System.Drawing.Size(61, 25);
            this.tbReg127_Set1.TabIndex = 2;
            this.tbReg127_Set1.Text = "00";
            // 
            // nudTestReg_215
            // 
            this.nudTestReg_215.Location = new System.Drawing.Point(370, 10);
            this.nudTestReg_215.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudTestReg_215.Name = "nudTestReg_215";
            this.nudTestReg_215.Size = new System.Drawing.Size(62, 25);
            this.nudTestReg_215.TabIndex = 1;
            this.nudTestReg_215.Value = new decimal(new int[] {
            221,
            0,
            0,
            0});
            // 
            // nudTestReg_213
            // 
            this.nudTestReg_213.Location = new System.Drawing.Point(290, 10);
            this.nudTestReg_213.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudTestReg_213.Name = "nudTestReg_213";
            this.nudTestReg_213.Size = new System.Drawing.Size(62, 25);
            this.nudTestReg_213.TabIndex = 1;
            this.nudTestReg_213.Value = new decimal(new int[] {
            215,
            0,
            0,
            0});
            // 
            // nudTestReg_154
            // 
            this.nudTestReg_154.Location = new System.Drawing.Point(210, 10);
            this.nudTestReg_154.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudTestReg_154.Name = "nudTestReg_154";
            this.nudTestReg_154.Size = new System.Drawing.Size(62, 25);
            this.nudTestReg_154.TabIndex = 1;
            this.nudTestReg_154.Value = new decimal(new int[] {
            213,
            0,
            0,
            0});
            // 
            // nudTestReg_127
            // 
            this.nudTestReg_127.Location = new System.Drawing.Point(130, 10);
            this.nudTestReg_127.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudTestReg_127.Name = "nudTestReg_127";
            this.nudTestReg_127.Size = new System.Drawing.Size(62, 25);
            this.nudTestReg_127.TabIndex = 1;
            this.nudTestReg_127.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(21, 119);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 36);
            this.label32.TabIndex = 0;
            this.label32.Text = "Setting 2\r\n(hexa)";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(21, 74);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(80, 36);
            this.label31.TabIndex = 0;
            this.label31.Text = "Setting 1\r\n(hexa)";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(53, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(48, 18);
            this.label29.TabIndex = 0;
            this.label29.Text = "Addr.";
            // 
            // tpFTDI
            // 
            this.tpFTDI.Controls.Add(this.btnFTDILogPixelApply);
            this.tpFTDI.Controls.Add(this.label33);
            this.tpFTDI.Controls.Add(this.tbFTDILogPixelNum);
            this.tpFTDI.Controls.Add(this.cbFTDICSV);
            this.tpFTDI.Controls.Add(this.cbFTDILog);
            this.tpFTDI.Controls.Add(this.btnFTDIoffset);
            this.tpFTDI.Controls.Add(this.btnFTDIRead);
            this.tpFTDI.Location = new System.Drawing.Point(4, 27);
            this.tpFTDI.Name = "tpFTDI";
            this.tpFTDI.Padding = new System.Windows.Forms.Padding(3);
            this.tpFTDI.Size = new System.Drawing.Size(1370, 168);
            this.tpFTDI.TabIndex = 5;
            this.tpFTDI.Text = "FTDI Ctrl";
            this.tpFTDI.UseVisualStyleBackColor = true;
            // 
            // cbFTDICSV
            // 
            this.cbFTDICSV.AutoSize = true;
            this.cbFTDICSV.Location = new System.Drawing.Point(477, 73);
            this.cbFTDICSV.Name = "cbFTDICSV";
            this.cbFTDICSV.Size = new System.Drawing.Size(102, 22);
            this.cbFTDICSV.TabIndex = 3;
            this.cbFTDICSV.Text = "CSV Check";
            this.cbFTDICSV.UseVisualStyleBackColor = true;
            this.cbFTDICSV.CheckedChanged += new System.EventHandler(this.cbFTDICSV_CheckedChanged);
            // 
            // cbFTDILog
            // 
            this.cbFTDILog.AutoSize = true;
            this.cbFTDILog.Location = new System.Drawing.Point(477, 43);
            this.cbFTDILog.Name = "cbFTDILog";
            this.cbFTDILog.Size = new System.Drawing.Size(102, 22);
            this.cbFTDILog.TabIndex = 2;
            this.cbFTDILog.Text = "Log Check";
            this.cbFTDILog.UseVisualStyleBackColor = true;
            // 
            // btnFTDIoffset
            // 
            this.btnFTDIoffset.Location = new System.Drawing.Point(298, 68);
            this.btnFTDIoffset.Name = "btnFTDIoffset";
            this.btnFTDIoffset.Size = new System.Drawing.Size(123, 42);
            this.btnFTDIoffset.TabIndex = 1;
            this.btnFTDIoffset.Text = "FTDI Offset";
            this.btnFTDIoffset.UseVisualStyleBackColor = true;
            this.btnFTDIoffset.Click += new System.EventHandler(this.btnFTDIOffset_Click);
            // 
            // btnFTDIRead
            // 
            this.btnFTDIRead.Location = new System.Drawing.Point(299, 19);
            this.btnFTDIRead.Name = "btnFTDIRead";
            this.btnFTDIRead.Size = new System.Drawing.Size(123, 42);
            this.btnFTDIRead.TabIndex = 0;
            this.btnFTDIRead.Text = "FTDI Read";
            this.btnFTDIRead.UseVisualStyleBackColor = true;
            this.btnFTDIRead.Click += new System.EventHandler(this.btnFTDIOpen_Click);
            // 
            // ssMainStrip
            // 
            this.ssMainStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssConnectStatus});
            this.ssMainStrip.Location = new System.Drawing.Point(0, 1027);
            this.ssMainStrip.Name = "ssMainStrip";
            this.ssMainStrip.Size = new System.Drawing.Size(1384, 28);
            this.ssMainStrip.TabIndex = 21;
            this.ssMainStrip.Text = "statusStrip1";
            // 
            // tssConnectStatus
            // 
            this.tssConnectStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssConnectStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tssConnectStatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssConnectStatus.Name = "tssConnectStatus";
            this.tssConnectStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tssConnectStatus.RightToLeftAutoMirrorImage = true;
            this.tssConnectStatus.Size = new System.Drawing.Size(124, 22);
            this.tssConnectStatus.Text = "Connected : No";
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbLog.Location = new System.Drawing.Point(0, -1);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(531, 750);
            this.rtbLog.TabIndex = 22;
            this.rtbLog.Text = "";
            // 
            // btnLogClear
            // 
            this.btnLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogClear.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogClear.Location = new System.Drawing.Point(13, 789);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(75, 27);
            this.btnLogClear.TabIndex = 28;
            this.btnLogClear.Text = "Log Clear";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // btnImageClear
            // 
            this.btnImageClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImageClear.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageClear.Location = new System.Drawing.Point(462, 794);
            this.btnImageClear.Name = "btnImageClear";
            this.btnImageClear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnImageClear.Size = new System.Drawing.Size(82, 27);
            this.btnImageClear.TabIndex = 39;
            this.btnImageClear.Text = "Image Clear";
            this.btnImageClear.UseVisualStyleBackColor = true;
            this.btnImageClear.Click += new System.EventHandler(this.btnImageClear_Click);
            // 
            // tmImageDsp
            // 
            this.tmImageDsp.Interval = 10;
            this.tmImageDsp.Tick += new System.EventHandler(this.tmImage_Tick);
            // 
            // tbPixelX
            // 
            this.tbPixelX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPixelX.Location = new System.Drawing.Point(240, 768);
            this.tbPixelX.MaxLength = 2;
            this.tbPixelX.Name = "tbPixelX";
            this.tbPixelX.Size = new System.Drawing.Size(33, 25);
            this.tbPixelX.TabIndex = 40;
            this.tbPixelX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPixelX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPixelX_KeyPress);
            // 
            // tbPixelY
            // 
            this.tbPixelY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPixelY.Location = new System.Drawing.Point(279, 768);
            this.tbPixelY.MaxLength = 2;
            this.tbPixelY.Name = "tbPixelY";
            this.tbPixelY.Size = new System.Drawing.Size(35, 25);
            this.tbPixelY.TabIndex = 41;
            this.tbPixelY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPixelY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPixelY_KeyPress);
            // 
            // tbPixelValue
            // 
            this.tbPixelValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPixelValue.BackColor = System.Drawing.SystemColors.Window;
            this.tbPixelValue.Location = new System.Drawing.Point(320, 768);
            this.tbPixelValue.Name = "tbPixelValue";
            this.tbPixelValue.ReadOnly = true;
            this.tbPixelValue.Size = new System.Drawing.Size(53, 25);
            this.tbPixelValue.TabIndex = 42;
            this.tbPixelValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPixelRGB
            // 
            this.tbPixelRGB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPixelRGB.BackColor = System.Drawing.SystemColors.Window;
            this.tbPixelRGB.Location = new System.Drawing.Point(437, 768);
            this.tbPixelRGB.Name = "tbPixelRGB";
            this.tbPixelRGB.ReadOnly = true;
            this.tbPixelRGB.Size = new System.Drawing.Size(107, 25);
            this.tbPixelRGB.TabIndex = 43;
            this.tbPixelRGB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 753);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 18);
            this.label3.TabIndex = 44;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 753);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "Y";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 753);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "Value";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 753);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 47;
            this.label6.Text = "R, G, B";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 753);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 49;
            this.label7.Text = "Offset";
            // 
            // tbPixelOffset
            // 
            this.tbPixelOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPixelOffset.BackColor = System.Drawing.SystemColors.Window;
            this.tbPixelOffset.Location = new System.Drawing.Point(379, 768);
            this.tbPixelOffset.Name = "tbPixelOffset";
            this.tbPixelOffset.ReadOnly = true;
            this.tbPixelOffset.Size = new System.Drawing.Size(53, 25);
            this.tbPixelOffset.TabIndex = 48;
            this.tbPixelOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tgsDebugLog
            // 
            this.tgsDebugLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsDebugLog.BackColor = System.Drawing.SystemColors.Control;
            this.tgsDebugLog.Location = new System.Drawing.Point(14, 757);
            this.tgsDebugLog.Name = "tgsDebugLog";
            this.tgsDebugLog.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsDebugLog.OffText = "LOG OFF";
            this.tgsDebugLog.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsDebugLog.OnForeColor = System.Drawing.Color.White;
            this.tgsDebugLog.OnText = "LOG ON";
            this.tgsDebugLog.Size = new System.Drawing.Size(81, 25);
            this.tgsDebugLog.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsDebugLog.TabIndex = 55;
            // 
            // tgsPixels
            // 
            this.tgsPixels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsPixels.BackColor = System.Drawing.SystemColors.Control;
            this.tgsPixels.Location = new System.Drawing.Point(390, 795);
            this.tgsPixels.Name = "tgsPixels";
            this.tgsPixels.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsPixels.OffText = "BITMAP";
            this.tgsPixels.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsPixels.OnForeColor = System.Drawing.Color.White;
            this.tgsPixels.OnText = "PIXELS";
            this.tgsPixels.Size = new System.Drawing.Size(66, 25);
            this.tgsPixels.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsPixels.TabIndex = 56;
            this.tgsPixels.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsPixels_CheckedChanged);
            // 
            // tgsImageX10
            // 
            this.tgsImageX10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsImageX10.BackColor = System.Drawing.SystemColors.Control;
            this.tgsImageX10.Location = new System.Drawing.Point(318, 795);
            this.tgsImageX10.Name = "tgsImageX10";
            this.tgsImageX10.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsImageX10.OffText = "x10";
            this.tgsImageX10.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsImageX10.OnForeColor = System.Drawing.Color.White;
            this.tgsImageX10.OnText = "x1";
            this.tgsImageX10.Size = new System.Drawing.Size(66, 25);
            this.tgsImageX10.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsImageX10.TabIndex = 57;
            // 
            // tmPixelCountinue
            // 
            this.tmPixelCountinue.Tick += new System.EventHandler(this.tmPixelCountinue_Tick);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(199, 752);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 18);
            this.label11.TabIndex = 72;
            this.label11.Text = "Edge";
            // 
            // nudPixelSpace
            // 
            this.nudPixelSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudPixelSpace.Location = new System.Drawing.Point(198, 769);
            this.nudPixelSpace.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPixelSpace.Name = "nudPixelSpace";
            this.nudPixelSpace.Size = new System.Drawing.Size(36, 25);
            this.nudPixelSpace.TabIndex = 71;
            this.nudPixelSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tgsChartLog
            // 
            this.tgsChartLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsChartLog.BackColor = System.Drawing.SystemColors.Control;
            this.tgsChartLog.Location = new System.Drawing.Point(101, 757);
            this.tgsChartLog.Name = "tgsChartLog";
            this.tgsChartLog.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsChartLog.OffText = "CLOG OFF";
            this.tgsChartLog.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsChartLog.OnForeColor = System.Drawing.Color.White;
            this.tgsChartLog.OnText = "CLOG ON";
            this.tgsChartLog.Size = new System.Drawing.Size(81, 25);
            this.tgsChartLog.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsChartLog.TabIndex = 85;
            // 
            // tgsShowImage
            // 
            this.tgsShowImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tgsShowImage.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowImage.Checked = true;
            this.tgsShowImage.Location = new System.Drawing.Point(246, 795);
            this.tgsShowImage.Name = "tgsShowImage";
            this.tgsShowImage.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowImage.OffText = "IMG OFF";
            this.tgsShowImage.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowImage.OnForeColor = System.Drawing.Color.White;
            this.tgsShowImage.OnText = "IMG ON";
            this.tgsShowImage.Size = new System.Drawing.Size(66, 25);
            this.tgsShowImage.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowImage.TabIndex = 86;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 784);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 18);
            this.label9.TabIndex = 83;
            this.label9.Text = "Odd";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 784);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 18);
            this.label10.TabIndex = 84;
            this.label10.Text = "Even";
            // 
            // lbEven
            // 
            this.lbEven.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbEven.Location = new System.Drawing.Point(142, 798);
            this.lbEven.Name = "lbEven";
            this.lbEven.On = true;
            this.lbEven.Size = new System.Drawing.Size(27, 23);
            this.lbEven.TabIndex = 82;
            this.lbEven.Text = "ledBulb1";
            // 
            // lbOdd
            // 
            this.lbOdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbOdd.Location = new System.Drawing.Point(109, 798);
            this.lbOdd.Name = "lbOdd";
            this.lbOdd.On = true;
            this.lbOdd.Size = new System.Drawing.Size(27, 23);
            this.lbOdd.TabIndex = 81;
            this.lbOdd.Text = "ledBulb1";
            // 
            // panMain
            // 
            this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMain.BackColor = System.Drawing.SystemColors.Control;
            this.panMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMain.Location = new System.Drawing.Point(570, -1);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(693, 826);
            this.panMain.TabIndex = 20;
            // 
            // tmSisoRD
            // 
            this.tmSisoRD.Tick += new System.EventHandler(this.tmSisoRD_Tick);
            // 
            // tbFTDILogPixelNum
            // 
            this.tbFTDILogPixelNum.Location = new System.Drawing.Point(685, 45);
            this.tbFTDILogPixelNum.Name = "tbFTDILogPixelNum";
            this.tbFTDILogPixelNum.Size = new System.Drawing.Size(100, 25);
            this.tbFTDILogPixelNum.TabIndex = 4;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(684, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(110, 18);
            this.label33.TabIndex = 5;
            this.label33.Text = "Log Pixel 선택";
            // 
            // btnFTDILogPixelApply
            // 
            this.btnFTDILogPixelApply.Location = new System.Drawing.Point(808, 50);
            this.btnFTDILogPixelApply.Name = "btnFTDILogPixelApply";
            this.btnFTDILogPixelApply.Size = new System.Drawing.Size(69, 44);
            this.btnFTDILogPixelApply.TabIndex = 6;
            this.btnFTDILogPixelApply.Text = "변경";
            this.btnFTDILogPixelApply.UseVisualStyleBackColor = true;
            this.btnFTDILogPixelApply.Click += new System.EventHandler(this.btnFTDILogPixelApply_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 1055);
            this.Controls.Add(this.tgsShowImage);
            this.Controls.Add(this.tgsChartLog);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbEven);
            this.Controls.Add(this.lbOdd);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudPixelSpace);
            this.Controls.Add(this.tgsImageX10);
            this.Controls.Add(this.tgsPixels);
            this.Controls.Add(this.tgsDebugLog);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPixelOffset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPixelRGB);
            this.Controls.Add(this.tbPixelValue);
            this.Controls.Add(this.tbPixelY);
            this.Controls.Add(this.tbPixelX);
            this.Controls.Add(this.btnImageClear);
            this.Controls.Add(this.btnLogClear);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ssMainStrip);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.rtbLog);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1400, 814);
            this.Name = "MainForm";
            this.Text = " TAS1945";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.tpTas1945Ctrl.ResumeLayout(false);
            this.tpTas1945Ctrl.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCsvSaveCnt)).EndInit();
            this.gbPixel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSetCenterValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDark_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelMeasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDark_X)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxVal)).EndInit();
            this.gbSingleRead.ResumeLayout(false);
            this.gbSingleRead.PerformLayout();
            this.gbAverage.ResumeLayout(false);
            this.gbAverage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvrCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.rgRegCtrl.ResumeLayout(false);
            this.rgRegCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegAddr)).EndInit();
            this.gbTcpConnect.ResumeLayout(false);
            this.gbTcpConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTcpPort)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpDeviceCtrl.ResumeLayout(false);
            this.gbIpSetup.ResumeLayout(false);
            this.gbIpSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSetPort)).EndInit();
            this.gbDeviceCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSetAvrCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudClockDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSetClock)).EndInit();
            this.tpFilter.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLpfSensitive)).EndInit();
            this.tpImageCal.ResumeLayout(false);
            this.tpImageCal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudcal35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcal45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcal25)).EndInit();
            this.tpRegTest.ResumeLayout(false);
            this.tpRegTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_215)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_213)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_154)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTestReg_127)).EndInit();
            this.tpFTDI.ResumeLayout(false);
            this.tpFTDI.PerformLayout();
            this.ssMainStrip.ResumeLayout(false);
            this.ssMainStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPixelSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TabPage tpTas1945Ctrl;
		private System.Windows.Forms.GroupBox rgRegCtrl;
		public System.Windows.Forms.Button btnRegRead;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button btnRegWrite;
		private System.Windows.Forms.TextBox tbRegData;
		public System.Windows.Forms.NumericUpDown nudRegAddr;
		private System.Windows.Forms.GroupBox gbTcpConnect;
		public System.Windows.Forms.NumericUpDown nudTcpPort;
		public System.Windows.Forms.Button btnTcpConnect;
		public System.Windows.Forms.RadioButton rbClient;
		public System.Windows.Forms.RadioButton rbServer;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripStatusLabel tssConnectStatus;
		private System.Windows.Forms.RichTextBox rtbLog;
		public IPAddressControlLib.IPAddressControl ipAddress;
		public System.Windows.Forms.Button btnLogClear;
		private System.Windows.Forms.GroupBox gbSingleRead;
		public System.Windows.Forms.Button btnGetPixelInfo;
		public System.Windows.Forms.RadioButton rbSingleEven;
		public System.Windows.Forms.RadioButton rbSingleOdd;
		public System.Windows.Forms.Button btnImageClear;
		public System.Windows.Forms.Timer tmImageDsp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox tbPixelX;
		public System.Windows.Forms.TextBox tbPixelY;
		public System.Windows.Forms.TextBox tbPixelValue;
		public System.Windows.Forms.TextBox tbPixelRGB;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox tbPixelOffset;
		public System.Windows.Forms.Button btnTas1945RegCtrl;
		private JCS.ToggleSwitch tgsPixels;
		private JCS.ToggleSwitch tgsContinue;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.NumericUpDown nudInterval;
		public System.Windows.Forms.RadioButton rbOddEvenToggle;
		public System.Windows.Forms.Button btnRegAllRead;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.Button btnPixelChartShow;
		public System.Windows.Forms.RadioButton rbSetPixel5;
		public System.Windows.Forms.RadioButton rbSetPixel4;
		public System.Windows.Forms.RadioButton rbSetPixel3;
		public System.Windows.Forms.RadioButton rbSetPixel2;
		public System.Windows.Forms.RadioButton rbSetPixel1;
		public System.Windows.Forms.NumericUpDown nudAvrCnt;
		private System.Windows.Forms.GroupBox gbPixel;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.NumericUpDown nudPixelSpace;
		public System.Windows.Forms.Button btnChartClear;
		public System.Windows.Forms.StatusStrip ssMainStrip;
		public System.Windows.Forms.Timer tmPixelCountinue;
		public System.Windows.Forms.NumericUpDown nudMinVal;
		public System.Windows.Forms.NumericUpDown nudMaxVal;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox gbAverage;
		public System.Windows.Forms.RadioButton rbGuiAvr;
		public System.Windows.Forms.RadioButton rbFpgaAvr;
		public System.Windows.Forms.RadioButton rbNormal;
		public System.Windows.Forms.RadioButton rbMoveAvr;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.NumericUpDown nudDark_X;
		public System.Windows.Forms.Button btnReadPushMode;
		public JCS.ToggleSwitch tgsChartLog;
		public JCS.ToggleSwitch tgsShowImage;
		public JCS.ToggleSwitch tgsImageX10;
		public DoubleBufferPanel panMain;
		public JCS.ToggleSwitch tgsDebugLog;
		private JCS.ToggleSwitch tgsNetMode;
		private System.Windows.Forms.ToolTip ttHint;
		public JCS.ToggleSwitch tgsPushSkip;
		public System.Windows.Forms.NumericUpDown nudPixelMeasure;
		private Bulb.LedBulb lbOdd;
		private Bulb.LedBulb lbEven;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		public System.Windows.Forms.NumericUpDown nudDark_Y;
		public System.Windows.Forms.RadioButton rbOffsetDisable;
		public System.Windows.Forms.RadioButton rbDark_X_Offset;
		public System.Windows.Forms.RadioButton rbAvrOffset;
		public System.Windows.Forms.RadioButton rbDark_Y_Offset;
		private System.Windows.Forms.TabPage tpFilter;
		private System.Windows.Forms.GroupBox groupBox3;
		public JCS.ToggleSwitch tgsLpfIir;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.NumericUpDown nudLpfSensitive;
		private System.Windows.Forms.GroupBox groupBox4;
		public JCS.ToggleSwitch tgsKalman;
		private System.Windows.Forms.TabPage tpDeviceCtrl;
		private System.Windows.Forms.GroupBox gbIpSetup;
		public IPAddressControlLib.IPAddressControl ipSetAddress;
		public System.Windows.Forms.NumericUpDown nupSetPort;
		public System.Windows.Forms.Button btnIpSetup;
		public System.Windows.Forms.RadioButton rbSetIpClient;
		public System.Windows.Forms.RadioButton rbSetIpServer;
		private System.Windows.Forms.GroupBox gbDeviceCtrl;
		public System.Windows.Forms.Button btnReset;
		public System.Windows.Forms.Button btnResend;
		public System.Windows.Forms.Button btnSetReadPLStart;
		public System.Windows.Forms.Button btnGetSetupInfo;
		public System.Windows.Forms.NumericUpDown nudSetAvrCnt;
		public System.Windows.Forms.Button btnSetAverage;
		private JCS.ToggleSwitch tgsReadEdge;
		public System.Windows.Forms.NumericUpDown nudClockDelay;
		public System.Windows.Forms.Button btnSetRead;
		public System.Windows.Forms.NumericUpDown nudSetClock;
		public System.Windows.Forms.Button btnSetClock;
		private JCS.ToggleSwitch tgsRefVal;
		public System.Windows.Forms.NumericUpDown nudSetCenterValue;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox5;
		public JCS.ToggleSwitch tgsCsvSave;
		private System.Windows.Forms.RadioButton rbTestPixel;
		private System.Windows.Forms.RadioButton rbChartPixel;
		public System.Windows.Forms.NumericUpDown nudCsvSaveCnt;
        private System.Windows.Forms.Label lbFrames;
        private System.Windows.Forms.Label lbMaxFrame;
        private System.Windows.Forms.TabPage tpImageCal;
        private System.Windows.Forms.NumericUpDown nudcal35;
        private System.Windows.Forms.NumericUpDown nudcal45;
        private System.Windows.Forms.NumericUpDown nudcal25;
        private System.Windows.Forms.Button btncal35;
        private System.Windows.Forms.Button btncal45;
        private System.Windows.Forms.Button btcal35load;
        private System.Windows.Forms.Button btcal45load;
        private System.Windows.Forms.Button btcal25load;
        private System.Windows.Forms.Button btncal25;
        private System.Windows.Forms.CheckBox cbCalmode;
        private System.Windows.Forms.CheckBox cbABS_apply;
        private System.Windows.Forms.CheckBox cbOffset_apply;
        private System.Windows.Forms.TabPage tpRegTest;
        private System.Windows.Forms.CheckBox cbDPC_apply;
        private System.Windows.Forms.CheckBox cbNF_apply;
        private System.Windows.Forms.CheckBox cbDP_apply;
        private System.Windows.Forms.CheckBox cbSensitivy_cal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbGain;
        private System.Windows.Forms.Button btnGain;
        private System.Windows.Forms.Label lbGain;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbStoN_min;
        private System.Windows.Forms.TextBox tbStoN_max;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox Signal_ck;
        private System.Windows.Forms.CheckBox StoN_ck;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbNoise_min;
        private System.Windows.Forms.TextBox tbSignal_min;
        private System.Windows.Forms.TextBox tbNoise_max;
        private System.Windows.Forms.TextBox tbSignal_max;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox Noise_ck;
        private System.Windows.Forms.Button btnDP_cal;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lbLivePixel_count;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lbLivePixel_perc;
        private System.Windows.Forms.Button btnKalmanError;
        private System.Windows.Forms.TextBox tbKalmanError;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lbKalmanError;
        private System.Windows.Forms.Button btnDataverify;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lbDPC_apply_cnt;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lbDPC_apply_perc;
        private System.Windows.Forms.Button btcalOffsetload;
        private System.Windows.Forms.Button btnISPoffsetCal;
        private System.Windows.Forms.CheckBox cbISPoffset;
        private System.Windows.Forms.Button btnColInit;
        private System.Windows.Forms.Button btnColLive;
        private System.Windows.Forms.Button btnColDead;
        private System.Windows.Forms.TextBox tbColselect;
        private System.Windows.Forms.TextBox tbX_dpc;
        private System.Windows.Forms.TextBox tbY_dpc;
        private System.Windows.Forms.Button btnXYInit;
        private System.Windows.Forms.Button btnXYLive;
        private System.Windows.Forms.Button btnXYDead;
        private System.Windows.Forms.CheckBox cbDark_Apply;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox tbReg127_Set1;
        private System.Windows.Forms.NumericUpDown nudTestReg_215;
        private System.Windows.Forms.NumericUpDown nudTestReg_213;
        private System.Windows.Forms.NumericUpDown nudTestReg_154;
        private System.Windows.Forms.NumericUpDown nudTestReg_127;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnRegRD_Set2;
        private System.Windows.Forms.Button btnRegWR_Set2;
        private System.Windows.Forms.Button btnRegRD_Set1;
        private System.Windows.Forms.Button btnRegWR_Set1;
        private System.Windows.Forms.TextBox tbReg215_Set2;
        private System.Windows.Forms.TextBox tbReg215_Set1;
        private System.Windows.Forms.TextBox tbReg213_Set2;
        private System.Windows.Forms.TextBox tbReg213_Set1;
        private System.Windows.Forms.TextBox tbReg154_Set2;
        private System.Windows.Forms.TextBox tbReg154_Set1;
        private System.Windows.Forms.TextBox tbReg127_Set2;
        private System.Windows.Forms.ComboBox cbReg127mode;
        public System.Windows.Forms.CheckBox cbReg24yearSetting;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tpFTDI;
        private System.Windows.Forms.CheckBox cbFTDILog;
        private System.Windows.Forms.Button btnFTDIoffset;
        private System.Windows.Forms.Button btnFTDIRead;
        public System.Windows.Forms.Timer tmSisoRD;
        private System.Windows.Forms.CheckBox cbFTDICSV;
        private System.Windows.Forms.Button btnFTDILogPixelApply;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbFTDILogPixelNum;
    }
}


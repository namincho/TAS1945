namespace Tas1945_mon
{
	partial class Tas1945_PixelChartForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tas1945_PixelChartForm));
            this.splitContainerChartVertical = new System.Windows.Forms.SplitContainer();
            this.label13 = new System.Windows.Forms.Label();
            this.nudChartMax = new System.Windows.Forms.NumericUpDown();
            this.nudChartLimit = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbChartRange = new System.Windows.Forms.CheckBox();
            this.chPixel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTPOffset = new System.Windows.Forms.TextBox();
            this.tbTPValue = new System.Windows.Forms.TextBox();
            this.tbTPCalValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbP5Offset = new System.Windows.Forms.TextBox();
            this.tbP5Value = new System.Windows.Forms.TextBox();
            this.tbP5CalValue = new System.Windows.Forms.TextBox();
            this.tbP4Offset = new System.Windows.Forms.TextBox();
            this.tbP4Value = new System.Windows.Forms.TextBox();
            this.tbP4CalValue = new System.Windows.Forms.TextBox();
            this.tbP3Offset = new System.Windows.Forms.TextBox();
            this.tbP3Value = new System.Windows.Forms.TextBox();
            this.tbP3CalValue = new System.Windows.Forms.TextBox();
            this.tbP2Offset = new System.Windows.Forms.TextBox();
            this.tbP2Value = new System.Windows.Forms.TextBox();
            this.tbP2CalValue = new System.Windows.Forms.TextBox();
            this.tbP1Offset = new System.Windows.Forms.TextBox();
            this.tbP1Value = new System.Windows.Forms.TextBox();
            this.tbP1CalValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tgsShowPixelTP = new JCS.ToggleSwitch();
            this.label12 = new System.Windows.Forms.Label();
            this.tbChartTPY = new System.Windows.Forms.TextBox();
            this.tbChartTPX = new System.Windows.Forms.TextBox();
            this.tbChartTPValue = new System.Windows.Forms.TextBox();
            this.tgsShowPixel5 = new JCS.ToggleSwitch();
            this.tgsShowPixel4 = new JCS.ToggleSwitch();
            this.tgsShowPixel3 = new JCS.ToggleSwitch();
            this.tgsShowPixel2 = new JCS.ToggleSwitch();
            this.tgsShowPixel1 = new JCS.ToggleSwitch();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbChart5Y = new System.Windows.Forms.TextBox();
            this.tbChart5X = new System.Windows.Forms.TextBox();
            this.tbChart5Value = new System.Windows.Forms.TextBox();
            this.tbChart4Y = new System.Windows.Forms.TextBox();
            this.tbChart4X = new System.Windows.Forms.TextBox();
            this.tbChart4Value = new System.Windows.Forms.TextBox();
            this.tbChart3Y = new System.Windows.Forms.TextBox();
            this.tbChart3X = new System.Windows.Forms.TextBox();
            this.tbChart3Value = new System.Windows.Forms.TextBox();
            this.tbChart2Y = new System.Windows.Forms.TextBox();
            this.tbChart2X = new System.Windows.Forms.TextBox();
            this.tbChart2Value = new System.Windows.Forms.TextBox();
            this.tbChart1Y = new System.Windows.Forms.TextBox();
            this.tbChart1X = new System.Windows.Forms.TextBox();
            this.tbChart1Value = new System.Windows.Forms.TextBox();
            this.lbChart_MaxScale = new System.Windows.Forms.Label();
            this.lbChart_MinScale = new System.Windows.Forms.Label();
            this.tbChart_MaxScale = new System.Windows.Forms.TextBox();
            this.tbChart_MinScale = new System.Windows.Forms.TextBox();
            this.btnChart_ScaleSet = new System.Windows.Forms.Button();
            this.btnChart_ScaleInit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChartVertical)).BeginInit();
            this.splitContainerChartVertical.Panel1.SuspendLayout();
            this.splitContainerChartVertical.Panel2.SuspendLayout();
            this.splitContainerChartVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChartMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChartLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPixel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerChartVertical
            // 
            this.splitContainerChartVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerChartVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerChartVertical.Location = new System.Drawing.Point(0, 0);
            this.splitContainerChartVertical.Name = "splitContainerChartVertical";
            // 
            // splitContainerChartVertical.Panel1
            // 
            this.splitContainerChartVertical.Panel1.Controls.Add(this.label13);
            this.splitContainerChartVertical.Panel1.Controls.Add(this.nudChartMax);
            this.splitContainerChartVertical.Panel1.Controls.Add(this.nudChartLimit);
            this.splitContainerChartVertical.Panel1.Controls.Add(this.btnClear);
            this.splitContainerChartVertical.Panel1.Controls.Add(this.cbChartRange);
            this.splitContainerChartVertical.Panel1.Controls.Add(this.chPixel);
            // 
            // splitContainerChartVertical.Panel2
            // 
            this.splitContainerChartVertical.Panel2.Controls.Add(this.btnChart_ScaleInit);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.btnChart_ScaleSet);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.tbChart_MinScale);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.tbChart_MaxScale);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.lbChart_MinScale);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.lbChart_MaxScale);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.btnClose);
            this.splitContainerChartVertical.Panel2.Controls.Add(this.groupBox6);
            this.splitContainerChartVertical.Size = new System.Drawing.Size(1384, 861);
            this.splitContainerChartVertical.SplitterDistance = 1100;
            this.splitContainerChartVertical.TabIndex = 71;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(987, 808);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 12);
            this.label13.TabIndex = 82;
            this.label13.Text = "MAX";
            // 
            // nudChartMax
            // 
            this.nudChartMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudChartMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudChartMax.Location = new System.Drawing.Point(1025, 806);
            this.nudChartMax.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudChartMax.Name = "nudChartMax";
            this.nudChartMax.Size = new System.Drawing.Size(72, 21);
            this.nudChartMax.TabIndex = 81;
            this.nudChartMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudChartMax.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // nudChartLimit
            // 
            this.nudChartLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudChartLimit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudChartLimit.Location = new System.Drawing.Point(1025, 783);
            this.nudChartLimit.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudChartLimit.Name = "nudChartLimit";
            this.nudChartLimit.Size = new System.Drawing.Size(72, 21);
            this.nudChartLimit.TabIndex = 80;
            this.nudChartLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudChartLimit.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(979, 833);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(118, 23);
            this.btnClear.TabIndex = 71;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbChartRange
            // 
            this.cbChartRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChartRange.AutoSize = true;
            this.cbChartRange.Checked = true;
            this.cbChartRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChartRange.Location = new System.Drawing.Point(956, 786);
            this.cbChartRange.Name = "cbChartRange";
            this.cbChartRange.Size = new System.Drawing.Size(66, 16);
            this.cbChartRange.TabIndex = 79;
            this.cbChartRange.Text = "RANGE";
            this.cbChartRange.UseVisualStyleBackColor = true;
            // 
            // chPixel
            // 
            chartArea1.Name = "ChartArea1";
            this.chPixel.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chPixel.Legends.Add(legend1);
            this.chPixel.Location = new System.Drawing.Point(382, 395);
            this.chPixel.Name = "chPixel";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chPixel.Series.Add(series1);
            this.chPixel.Size = new System.Drawing.Size(351, 354);
            this.chPixel.TabIndex = 1;
            this.chPixel.Text = "Pixel Chart";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbTPOffset);
            this.groupBox1.Controls.Add(this.tbTPValue);
            this.groupBox1.Controls.Add(this.tbTPCalValue);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbP5Offset);
            this.groupBox1.Controls.Add(this.tbP5Value);
            this.groupBox1.Controls.Add(this.tbP5CalValue);
            this.groupBox1.Controls.Add(this.tbP4Offset);
            this.groupBox1.Controls.Add(this.tbP4Value);
            this.groupBox1.Controls.Add(this.tbP4CalValue);
            this.groupBox1.Controls.Add(this.tbP3Offset);
            this.groupBox1.Controls.Add(this.tbP3Value);
            this.groupBox1.Controls.Add(this.tbP3CalValue);
            this.groupBox1.Controls.Add(this.tbP2Offset);
            this.groupBox1.Controls.Add(this.tbP2Value);
            this.groupBox1.Controls.Add(this.tbP2CalValue);
            this.groupBox1.Controls.Add(this.tbP1Offset);
            this.groupBox1.Controls.Add(this.tbP1Value);
            this.groupBox1.Controls.Add(this.tbP1CalValue);
            this.groupBox1.Location = new System.Drawing.Point(5, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 180);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pixel Info [Value, Offset, Cal-Value]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "TP";
            // 
            // tbTPOffset
            // 
            this.tbTPOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTPOffset.Location = new System.Drawing.Point(108, 151);
            this.tbTPOffset.Name = "tbTPOffset";
            this.tbTPOffset.ReadOnly = true;
            this.tbTPOffset.Size = new System.Drawing.Size(70, 21);
            this.tbTPOffset.TabIndex = 30;
            this.tbTPOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTPValue
            // 
            this.tbTPValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTPValue.Location = new System.Drawing.Point(33, 151);
            this.tbTPValue.Name = "tbTPValue";
            this.tbTPValue.ReadOnly = true;
            this.tbTPValue.Size = new System.Drawing.Size(70, 21);
            this.tbTPValue.TabIndex = 29;
            this.tbTPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTPCalValue
            // 
            this.tbTPCalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbTPCalValue.Location = new System.Drawing.Point(184, 151);
            this.tbTPCalValue.Name = "tbTPCalValue";
            this.tbTPCalValue.ReadOnly = true;
            this.tbTPCalValue.Size = new System.Drawing.Size(70, 21);
            this.tbTPCalValue.TabIndex = 28;
            this.tbTPCalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "P5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "P4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "P3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "P2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "P1";
            // 
            // tbP5Offset
            // 
            this.tbP5Offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP5Offset.Location = new System.Drawing.Point(108, 125);
            this.tbP5Offset.Name = "tbP5Offset";
            this.tbP5Offset.ReadOnly = true;
            this.tbP5Offset.Size = new System.Drawing.Size(70, 21);
            this.tbP5Offset.TabIndex = 22;
            this.tbP5Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP5Value
            // 
            this.tbP5Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP5Value.Location = new System.Drawing.Point(33, 125);
            this.tbP5Value.Name = "tbP5Value";
            this.tbP5Value.ReadOnly = true;
            this.tbP5Value.Size = new System.Drawing.Size(70, 21);
            this.tbP5Value.TabIndex = 21;
            this.tbP5Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP5CalValue
            // 
            this.tbP5CalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP5CalValue.Location = new System.Drawing.Point(184, 125);
            this.tbP5CalValue.Name = "tbP5CalValue";
            this.tbP5CalValue.ReadOnly = true;
            this.tbP5CalValue.Size = new System.Drawing.Size(70, 21);
            this.tbP5CalValue.TabIndex = 20;
            this.tbP5CalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP4Offset
            // 
            this.tbP4Offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP4Offset.Location = new System.Drawing.Point(108, 98);
            this.tbP4Offset.Name = "tbP4Offset";
            this.tbP4Offset.ReadOnly = true;
            this.tbP4Offset.Size = new System.Drawing.Size(70, 21);
            this.tbP4Offset.TabIndex = 19;
            this.tbP4Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP4Value
            // 
            this.tbP4Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP4Value.Location = new System.Drawing.Point(33, 98);
            this.tbP4Value.Name = "tbP4Value";
            this.tbP4Value.ReadOnly = true;
            this.tbP4Value.Size = new System.Drawing.Size(70, 21);
            this.tbP4Value.TabIndex = 18;
            this.tbP4Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP4CalValue
            // 
            this.tbP4CalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP4CalValue.Location = new System.Drawing.Point(184, 98);
            this.tbP4CalValue.Name = "tbP4CalValue";
            this.tbP4CalValue.ReadOnly = true;
            this.tbP4CalValue.Size = new System.Drawing.Size(70, 21);
            this.tbP4CalValue.TabIndex = 17;
            this.tbP4CalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP3Offset
            // 
            this.tbP3Offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP3Offset.Location = new System.Drawing.Point(108, 71);
            this.tbP3Offset.Name = "tbP3Offset";
            this.tbP3Offset.ReadOnly = true;
            this.tbP3Offset.Size = new System.Drawing.Size(70, 21);
            this.tbP3Offset.TabIndex = 16;
            this.tbP3Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP3Value
            // 
            this.tbP3Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP3Value.Location = new System.Drawing.Point(33, 71);
            this.tbP3Value.Name = "tbP3Value";
            this.tbP3Value.ReadOnly = true;
            this.tbP3Value.Size = new System.Drawing.Size(70, 21);
            this.tbP3Value.TabIndex = 15;
            this.tbP3Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP3CalValue
            // 
            this.tbP3CalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP3CalValue.Location = new System.Drawing.Point(184, 71);
            this.tbP3CalValue.Name = "tbP3CalValue";
            this.tbP3CalValue.ReadOnly = true;
            this.tbP3CalValue.Size = new System.Drawing.Size(70, 21);
            this.tbP3CalValue.TabIndex = 14;
            this.tbP3CalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP2Offset
            // 
            this.tbP2Offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP2Offset.Location = new System.Drawing.Point(108, 44);
            this.tbP2Offset.Name = "tbP2Offset";
            this.tbP2Offset.ReadOnly = true;
            this.tbP2Offset.Size = new System.Drawing.Size(70, 21);
            this.tbP2Offset.TabIndex = 13;
            this.tbP2Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP2Value
            // 
            this.tbP2Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP2Value.Location = new System.Drawing.Point(33, 44);
            this.tbP2Value.Name = "tbP2Value";
            this.tbP2Value.ReadOnly = true;
            this.tbP2Value.Size = new System.Drawing.Size(70, 21);
            this.tbP2Value.TabIndex = 12;
            this.tbP2Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP2CalValue
            // 
            this.tbP2CalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP2CalValue.Location = new System.Drawing.Point(184, 44);
            this.tbP2CalValue.Name = "tbP2CalValue";
            this.tbP2CalValue.ReadOnly = true;
            this.tbP2CalValue.Size = new System.Drawing.Size(70, 21);
            this.tbP2CalValue.TabIndex = 11;
            this.tbP2CalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP1Offset
            // 
            this.tbP1Offset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP1Offset.Location = new System.Drawing.Point(108, 17);
            this.tbP1Offset.Name = "tbP1Offset";
            this.tbP1Offset.ReadOnly = true;
            this.tbP1Offset.Size = new System.Drawing.Size(70, 21);
            this.tbP1Offset.TabIndex = 10;
            this.tbP1Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP1Value
            // 
            this.tbP1Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP1Value.Location = new System.Drawing.Point(33, 17);
            this.tbP1Value.Name = "tbP1Value";
            this.tbP1Value.ReadOnly = true;
            this.tbP1Value.Size = new System.Drawing.Size(70, 21);
            this.tbP1Value.TabIndex = 9;
            this.tbP1Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbP1CalValue
            // 
            this.tbP1CalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbP1CalValue.Location = new System.Drawing.Point(184, 17);
            this.tbP1CalValue.Name = "tbP1CalValue";
            this.tbP1CalValue.ReadOnly = true;
            this.tbP1CalValue.Size = new System.Drawing.Size(70, 21);
            this.tbP1CalValue.TabIndex = 8;
            this.tbP1CalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(189, 831);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 23);
            this.btnClose.TabIndex = 77;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.tgsShowPixelTP);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.tbChartTPY);
            this.groupBox6.Controls.Add(this.tbChartTPX);
            this.groupBox6.Controls.Add(this.tbChartTPValue);
            this.groupBox6.Controls.Add(this.tgsShowPixel5);
            this.groupBox6.Controls.Add(this.tgsShowPixel4);
            this.groupBox6.Controls.Add(this.tgsShowPixel3);
            this.groupBox6.Controls.Add(this.tgsShowPixel2);
            this.groupBox6.Controls.Add(this.tgsShowPixel1);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.tbChart5Y);
            this.groupBox6.Controls.Add(this.tbChart5X);
            this.groupBox6.Controls.Add(this.tbChart5Value);
            this.groupBox6.Controls.Add(this.tbChart4Y);
            this.groupBox6.Controls.Add(this.tbChart4X);
            this.groupBox6.Controls.Add(this.tbChart4Value);
            this.groupBox6.Controls.Add(this.tbChart3Y);
            this.groupBox6.Controls.Add(this.tbChart3X);
            this.groupBox6.Controls.Add(this.tbChart3Value);
            this.groupBox6.Controls.Add(this.tbChart2Y);
            this.groupBox6.Controls.Add(this.tbChart2X);
            this.groupBox6.Controls.Add(this.tbChart2Value);
            this.groupBox6.Controls.Add(this.tbChart1Y);
            this.groupBox6.Controls.Add(this.tbChart1X);
            this.groupBox6.Controls.Add(this.tbChart1Value);
            this.groupBox6.Location = new System.Drawing.Point(5, 8);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(268, 182);
            this.groupBox6.TabIndex = 76;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Chart Info [X, Y, Value, On/Off]";
            // 
            // tgsShowPixelTP
            // 
            this.tgsShowPixelTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgsShowPixelTP.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowPixelTP.Location = new System.Drawing.Point(193, 151);
            this.tgsShowPixelTP.Name = "tgsShowPixelTP";
            this.tgsShowPixelTP.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixelTP.OffText = "TP OFF";
            this.tgsShowPixelTP.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixelTP.OnForeColor = System.Drawing.Color.White;
            this.tgsShowPixelTP.OnText = "TP ON";
            this.tgsShowPixelTP.Size = new System.Drawing.Size(66, 25);
            this.tgsShowPixelTP.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowPixelTP.TabIndex = 89;
            this.tgsShowPixelTP.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsShowPixelTP_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 12);
            this.label12.TabIndex = 88;
            this.label12.Text = "TP";
            // 
            // tbChartTPY
            // 
            this.tbChartTPY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChartTPY.Location = new System.Drawing.Point(73, 153);
            this.tbChartTPY.Name = "tbChartTPY";
            this.tbChartTPY.ReadOnly = true;
            this.tbChartTPY.Size = new System.Drawing.Size(40, 21);
            this.tbChartTPY.TabIndex = 87;
            this.tbChartTPY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChartTPX
            // 
            this.tbChartTPX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChartTPX.Location = new System.Drawing.Point(31, 153);
            this.tbChartTPX.Name = "tbChartTPX";
            this.tbChartTPX.ReadOnly = true;
            this.tbChartTPX.Size = new System.Drawing.Size(40, 21);
            this.tbChartTPX.TabIndex = 86;
            this.tbChartTPX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChartTPValue
            // 
            this.tbChartTPValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChartTPValue.Location = new System.Drawing.Point(115, 153);
            this.tbChartTPValue.Name = "tbChartTPValue";
            this.tbChartTPValue.ReadOnly = true;
            this.tbChartTPValue.Size = new System.Drawing.Size(70, 21);
            this.tbChartTPValue.TabIndex = 85;
            this.tbChartTPValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tgsShowPixel5
            // 
            this.tgsShowPixel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgsShowPixel5.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowPixel5.Location = new System.Drawing.Point(193, 124);
            this.tgsShowPixel5.Name = "tgsShowPixel5";
            this.tgsShowPixel5.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel5.OffText = "P5 OFF";
            this.tgsShowPixel5.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel5.OnForeColor = System.Drawing.Color.White;
            this.tgsShowPixel5.OnText = "P5 ON";
            this.tgsShowPixel5.Size = new System.Drawing.Size(66, 25);
            this.tgsShowPixel5.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowPixel5.TabIndex = 84;
            this.tgsShowPixel5.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsShowChart5_CheckedChanged);
            // 
            // tgsShowPixel4
            // 
            this.tgsShowPixel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgsShowPixel4.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowPixel4.Location = new System.Drawing.Point(193, 96);
            this.tgsShowPixel4.Name = "tgsShowPixel4";
            this.tgsShowPixel4.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel4.OffText = "P4 OFF";
            this.tgsShowPixel4.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel4.OnForeColor = System.Drawing.Color.White;
            this.tgsShowPixel4.OnText = "P4 ON";
            this.tgsShowPixel4.Size = new System.Drawing.Size(66, 25);
            this.tgsShowPixel4.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowPixel4.TabIndex = 83;
            this.tgsShowPixel4.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsShowChart4_CheckedChanged);
            // 
            // tgsShowPixel3
            // 
            this.tgsShowPixel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgsShowPixel3.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowPixel3.Location = new System.Drawing.Point(193, 69);
            this.tgsShowPixel3.Name = "tgsShowPixel3";
            this.tgsShowPixel3.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel3.OffText = "P3 OFF";
            this.tgsShowPixel3.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel3.OnForeColor = System.Drawing.Color.White;
            this.tgsShowPixel3.OnText = "P3 ON";
            this.tgsShowPixel3.Size = new System.Drawing.Size(66, 25);
            this.tgsShowPixel3.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowPixel3.TabIndex = 82;
            this.tgsShowPixel3.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsShowChart3_CheckedChanged);
            // 
            // tgsShowPixel2
            // 
            this.tgsShowPixel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgsShowPixel2.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowPixel2.Location = new System.Drawing.Point(193, 42);
            this.tgsShowPixel2.Name = "tgsShowPixel2";
            this.tgsShowPixel2.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel2.OffText = "P2 OFF";
            this.tgsShowPixel2.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel2.OnForeColor = System.Drawing.Color.White;
            this.tgsShowPixel2.OnText = "P2 ON";
            this.tgsShowPixel2.Size = new System.Drawing.Size(66, 25);
            this.tgsShowPixel2.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowPixel2.TabIndex = 81;
            this.tgsShowPixel2.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsShowChart2_CheckedChanged);
            // 
            // tgsShowPixel1
            // 
            this.tgsShowPixel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgsShowPixel1.BackColor = System.Drawing.SystemColors.Control;
            this.tgsShowPixel1.Location = new System.Drawing.Point(193, 15);
            this.tgsShowPixel1.Name = "tgsShowPixel1";
            this.tgsShowPixel1.OffFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel1.OffText = "P1 OFF";
            this.tgsShowPixel1.OnFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tgsShowPixel1.OnForeColor = System.Drawing.Color.White;
            this.tgsShowPixel1.OnText = "P1 ON";
            this.tgsShowPixel1.Size = new System.Drawing.Size(66, 25);
            this.tgsShowPixel1.Style = JCS.ToggleSwitch.ToggleSwitchStyle.IOS5;
            this.tgsShowPixel1.TabIndex = 72;
            this.tgsShowPixel1.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.tgsShowChart1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "P5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "P4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "P3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "P2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "P1";
            // 
            // tbChart5Y
            // 
            this.tbChart5Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart5Y.Location = new System.Drawing.Point(73, 126);
            this.tbChart5Y.Name = "tbChart5Y";
            this.tbChart5Y.ReadOnly = true;
            this.tbChart5Y.Size = new System.Drawing.Size(40, 21);
            this.tbChart5Y.TabIndex = 22;
            this.tbChart5Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart5X
            // 
            this.tbChart5X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart5X.Location = new System.Drawing.Point(31, 126);
            this.tbChart5X.Name = "tbChart5X";
            this.tbChart5X.ReadOnly = true;
            this.tbChart5X.Size = new System.Drawing.Size(40, 21);
            this.tbChart5X.TabIndex = 21;
            this.tbChart5X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart5Value
            // 
            this.tbChart5Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart5Value.Location = new System.Drawing.Point(115, 126);
            this.tbChart5Value.Name = "tbChart5Value";
            this.tbChart5Value.ReadOnly = true;
            this.tbChart5Value.Size = new System.Drawing.Size(70, 21);
            this.tbChart5Value.TabIndex = 20;
            this.tbChart5Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart4Y
            // 
            this.tbChart4Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart4Y.Location = new System.Drawing.Point(73, 99);
            this.tbChart4Y.Name = "tbChart4Y";
            this.tbChart4Y.ReadOnly = true;
            this.tbChart4Y.Size = new System.Drawing.Size(40, 21);
            this.tbChart4Y.TabIndex = 19;
            this.tbChart4Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart4X
            // 
            this.tbChart4X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart4X.Location = new System.Drawing.Point(31, 99);
            this.tbChart4X.Name = "tbChart4X";
            this.tbChart4X.ReadOnly = true;
            this.tbChart4X.Size = new System.Drawing.Size(40, 21);
            this.tbChart4X.TabIndex = 18;
            this.tbChart4X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart4Value
            // 
            this.tbChart4Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart4Value.Location = new System.Drawing.Point(115, 99);
            this.tbChart4Value.Name = "tbChart4Value";
            this.tbChart4Value.ReadOnly = true;
            this.tbChart4Value.Size = new System.Drawing.Size(70, 21);
            this.tbChart4Value.TabIndex = 17;
            this.tbChart4Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart3Y
            // 
            this.tbChart3Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart3Y.Location = new System.Drawing.Point(73, 72);
            this.tbChart3Y.Name = "tbChart3Y";
            this.tbChart3Y.ReadOnly = true;
            this.tbChart3Y.Size = new System.Drawing.Size(40, 21);
            this.tbChart3Y.TabIndex = 16;
            this.tbChart3Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart3X
            // 
            this.tbChart3X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart3X.Location = new System.Drawing.Point(31, 72);
            this.tbChart3X.Name = "tbChart3X";
            this.tbChart3X.ReadOnly = true;
            this.tbChart3X.Size = new System.Drawing.Size(40, 21);
            this.tbChart3X.TabIndex = 15;
            this.tbChart3X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart3Value
            // 
            this.tbChart3Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart3Value.Location = new System.Drawing.Point(115, 72);
            this.tbChart3Value.Name = "tbChart3Value";
            this.tbChart3Value.ReadOnly = true;
            this.tbChart3Value.Size = new System.Drawing.Size(70, 21);
            this.tbChart3Value.TabIndex = 14;
            this.tbChart3Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart2Y
            // 
            this.tbChart2Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart2Y.Location = new System.Drawing.Point(73, 45);
            this.tbChart2Y.Name = "tbChart2Y";
            this.tbChart2Y.ReadOnly = true;
            this.tbChart2Y.Size = new System.Drawing.Size(40, 21);
            this.tbChart2Y.TabIndex = 13;
            this.tbChart2Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart2X
            // 
            this.tbChart2X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart2X.Location = new System.Drawing.Point(31, 45);
            this.tbChart2X.Name = "tbChart2X";
            this.tbChart2X.ReadOnly = true;
            this.tbChart2X.Size = new System.Drawing.Size(40, 21);
            this.tbChart2X.TabIndex = 12;
            this.tbChart2X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart2Value
            // 
            this.tbChart2Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart2Value.Location = new System.Drawing.Point(115, 45);
            this.tbChart2Value.Name = "tbChart2Value";
            this.tbChart2Value.ReadOnly = true;
            this.tbChart2Value.Size = new System.Drawing.Size(70, 21);
            this.tbChart2Value.TabIndex = 11;
            this.tbChart2Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart1Y
            // 
            this.tbChart1Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart1Y.Location = new System.Drawing.Point(73, 18);
            this.tbChart1Y.Name = "tbChart1Y";
            this.tbChart1Y.ReadOnly = true;
            this.tbChart1Y.Size = new System.Drawing.Size(40, 21);
            this.tbChart1Y.TabIndex = 10;
            this.tbChart1Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart1X
            // 
            this.tbChart1X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart1X.Location = new System.Drawing.Point(31, 18);
            this.tbChart1X.Name = "tbChart1X";
            this.tbChart1X.ReadOnly = true;
            this.tbChart1X.Size = new System.Drawing.Size(40, 21);
            this.tbChart1X.TabIndex = 9;
            this.tbChart1X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbChart1Value
            // 
            this.tbChart1Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbChart1Value.Location = new System.Drawing.Point(115, 18);
            this.tbChart1Value.Name = "tbChart1Value";
            this.tbChart1Value.ReadOnly = true;
            this.tbChart1Value.Size = new System.Drawing.Size(70, 21);
            this.tbChart1Value.TabIndex = 8;
            this.tbChart1Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbChart_MaxScale
            // 
            this.lbChart_MaxScale.AutoSize = true;
            this.lbChart_MaxScale.Location = new System.Drawing.Point(31, 483);
            this.lbChart_MaxScale.Name = "lbChart_MaxScale";
            this.lbChart_MaxScale.Size = new System.Drawing.Size(30, 12);
            this.lbChart_MaxScale.TabIndex = 79;
            this.lbChart_MaxScale.Text = "Max";
            // 
            // lbChart_MinScale
            // 
            this.lbChart_MinScale.AutoSize = true;
            this.lbChart_MinScale.Location = new System.Drawing.Point(35, 510);
            this.lbChart_MinScale.Name = "lbChart_MinScale";
            this.lbChart_MinScale.Size = new System.Drawing.Size(26, 12);
            this.lbChart_MinScale.TabIndex = 80;
            this.lbChart_MinScale.Text = "min";
            // 
            // tbChart_MaxScale
            // 
            this.tbChart_MaxScale.Location = new System.Drawing.Point(67, 480);
            this.tbChart_MaxScale.Name = "tbChart_MaxScale";
            this.tbChart_MaxScale.Size = new System.Drawing.Size(69, 21);
            this.tbChart_MaxScale.TabIndex = 81;
            // 
            // tbChart_MinScale
            // 
            this.tbChart_MinScale.Location = new System.Drawing.Point(67, 507);
            this.tbChart_MinScale.Name = "tbChart_MinScale";
            this.tbChart_MinScale.Size = new System.Drawing.Size(69, 21);
            this.tbChart_MinScale.TabIndex = 81;
            // 
            // btnChart_ScaleSet
            // 
            this.btnChart_ScaleSet.Location = new System.Drawing.Point(142, 478);
            this.btnChart_ScaleSet.Name = "btnChart_ScaleSet";
            this.btnChart_ScaleSet.Size = new System.Drawing.Size(55, 23);
            this.btnChart_ScaleSet.TabIndex = 82;
            this.btnChart_ScaleSet.Text = "Set";
            this.btnChart_ScaleSet.UseVisualStyleBackColor = true;
            this.btnChart_ScaleSet.Click += new System.EventHandler(this.btnChart_ScaleSet_Click);
            // 
            // btnChart_ScaleInit
            // 
            this.btnChart_ScaleInit.Location = new System.Drawing.Point(142, 505);
            this.btnChart_ScaleInit.Name = "btnChart_ScaleInit";
            this.btnChart_ScaleInit.Size = new System.Drawing.Size(55, 23);
            this.btnChart_ScaleInit.TabIndex = 82;
            this.btnChart_ScaleInit.Text = "Init";
            this.btnChart_ScaleInit.UseVisualStyleBackColor = true;
            this.btnChart_ScaleInit.Click += new System.EventHandler(this.btnChart_ScaleInit_Click);
            // 
            // Tas1945_PixelChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.splitContainerChartVertical);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1400, 814);
            this.Name = "Tas1945_PixelChartForm";
            this.Text = "Pixel Chart";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PixelGraph_FormClosed);
            this.Load += new System.EventHandler(this.PixelGraph_Load);
            this.splitContainerChartVertical.Panel1.ResumeLayout(false);
            this.splitContainerChartVertical.Panel1.PerformLayout();
            this.splitContainerChartVertical.Panel2.ResumeLayout(false);
            this.splitContainerChartVertical.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerChartVertical)).EndInit();
            this.splitContainerChartVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudChartMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChartLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPixel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.SplitContainer splitContainerChartVertical;
		public System.Windows.Forms.DataVisualization.Charting.Chart chPixel;
		private System.Windows.Forms.GroupBox groupBox6;
		public System.Windows.Forms.TextBox tbChart5Y;
		public System.Windows.Forms.TextBox tbChart5X;
		public System.Windows.Forms.TextBox tbChart5Value;
		public System.Windows.Forms.TextBox tbChart4Y;
		public System.Windows.Forms.TextBox tbChart4X;
		public System.Windows.Forms.TextBox tbChart4Value;
		public System.Windows.Forms.TextBox tbChart3Y;
		public System.Windows.Forms.TextBox tbChart3X;
		public System.Windows.Forms.TextBox tbChart3Value;
		public System.Windows.Forms.TextBox tbChart2Y;
		public System.Windows.Forms.TextBox tbChart2X;
		public System.Windows.Forms.TextBox tbChart2Value;
		public System.Windows.Forms.TextBox tbChart1Y;
		public System.Windows.Forms.TextBox tbChart1X;
		public System.Windows.Forms.TextBox tbChart1Value;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnClear;
		public JCS.ToggleSwitch tgsShowPixel5;
		public JCS.ToggleSwitch tgsShowPixel4;
		public JCS.ToggleSwitch tgsShowPixel3;
		public JCS.ToggleSwitch tgsShowPixel2;
		public JCS.ToggleSwitch tgsShowPixel1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox tbP5Offset;
		public System.Windows.Forms.TextBox tbP5Value;
		public System.Windows.Forms.TextBox tbP5CalValue;
		public System.Windows.Forms.TextBox tbP4Offset;
		public System.Windows.Forms.TextBox tbP4Value;
		public System.Windows.Forms.TextBox tbP4CalValue;
		public System.Windows.Forms.TextBox tbP3Offset;
		public System.Windows.Forms.TextBox tbP3Value;
		public System.Windows.Forms.TextBox tbP3CalValue;
		public System.Windows.Forms.TextBox tbP2Offset;
		public System.Windows.Forms.TextBox tbP2Value;
		public System.Windows.Forms.TextBox tbP2CalValue;
		public System.Windows.Forms.TextBox tbP1Offset;
		public System.Windows.Forms.TextBox tbP1Value;
		public System.Windows.Forms.TextBox tbP1CalValue;
		public System.Windows.Forms.NumericUpDown nudChartLimit;
		public System.Windows.Forms.CheckBox cbChartRange;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.TextBox tbTPOffset;
		public System.Windows.Forms.TextBox tbTPValue;
		public System.Windows.Forms.TextBox tbTPCalValue;
		public JCS.ToggleSwitch tgsShowPixelTP;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.TextBox tbChartTPY;
		public System.Windows.Forms.TextBox tbChartTPX;
		public System.Windows.Forms.TextBox tbChartTPValue;
		public System.Windows.Forms.NumericUpDown nudChartMax;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnChart_ScaleSet;
        private System.Windows.Forms.TextBox tbChart_MinScale;
        private System.Windows.Forms.TextBox tbChart_MaxScale;
        private System.Windows.Forms.Label lbChart_MinScale;
        private System.Windows.Forms.Label lbChart_MaxScale;
        private System.Windows.Forms.Button btnChart_ScaleInit;
    }
}
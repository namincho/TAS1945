
namespace Tas1945_mon
{
	partial class PixelForm
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
			this.btnPixelFormClose = new System.Windows.Forms.Button();
			this.dgvPixelOffset = new System.Windows.Forms.DataGridView();
			this.btnPixelOffsetSave = new System.Windows.Forms.Button();
			this.tbPosXY = new System.Windows.Forms.TextBox();
			this.tbPixelOffset = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnPixelOffsetZero = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvPixelOffset)).BeginInit();
			this.SuspendLayout();
			// 
			// btnPixelFormClose
			// 
			this.btnPixelFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPixelFormClose.Location = new System.Drawing.Point(1106, 775);
			this.btnPixelFormClose.Name = "btnPixelFormClose";
			this.btnPixelFormClose.Size = new System.Drawing.Size(75, 23);
			this.btnPixelFormClose.TabIndex = 0;
			this.btnPixelFormClose.Text = "Close";
			this.btnPixelFormClose.UseVisualStyleBackColor = true;
			this.btnPixelFormClose.Click += new System.EventHandler(this.btnPixelFormClose_Click);
			// 
			// dgvPixelOffset
			// 
			this.dgvPixelOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPixelOffset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dgvPixelOffset.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
			this.dgvPixelOffset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPixelOffset.Location = new System.Drawing.Point(3, 3);
			this.dgvPixelOffset.Name = "dgvPixelOffset";
			this.dgvPixelOffset.RowTemplate.Height = 23;
			this.dgvPixelOffset.Size = new System.Drawing.Size(1178, 743);
			this.dgvPixelOffset.TabIndex = 1;
			this.dgvPixelOffset.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPixelOffset_CellValueChanged);
			// 
			// btnPixelOffsetSave
			// 
			this.btnPixelOffsetSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPixelOffsetSave.Location = new System.Drawing.Point(1106, 752);
			this.btnPixelOffsetSave.Name = "btnPixelOffsetSave";
			this.btnPixelOffsetSave.Size = new System.Drawing.Size(75, 23);
			this.btnPixelOffsetSave.TabIndex = 2;
			this.btnPixelOffsetSave.Text = "Save";
			this.btnPixelOffsetSave.UseVisualStyleBackColor = true;
			this.btnPixelOffsetSave.Click += new System.EventHandler(this.btnPixelOffsetSave_Click);
			// 
			// tbPosXY
			// 
			this.tbPosXY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPosXY.Location = new System.Drawing.Point(1008, 754);
			this.tbPosXY.Name = "tbPosXY";
			this.tbPosXY.Size = new System.Drawing.Size(92, 21);
			this.tbPosXY.TabIndex = 3;
			// 
			// tbPixelOffset
			// 
			this.tbPixelOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPixelOffset.Location = new System.Drawing.Point(1008, 777);
			this.tbPixelOffset.Name = "tbPixelOffset";
			this.tbPixelOffset.Size = new System.Drawing.Size(92, 21);
			this.tbPixelOffset.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(973, 757);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "X, Y";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(965, 780);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 12);
			this.label3.TabIndex = 8;
			this.label3.Text = "Offset";
			// 
			// btnPixelOffsetZero
			// 
			this.btnPixelOffsetZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPixelOffsetZero.Location = new System.Drawing.Point(3, 757);
			this.btnPixelOffsetZero.Name = "btnPixelOffsetZero";
			this.btnPixelOffsetZero.Size = new System.Drawing.Size(75, 23);
			this.btnPixelOffsetZero.TabIndex = 9;
			this.btnPixelOffsetZero.Text = "Zero";
			this.btnPixelOffsetZero.UseVisualStyleBackColor = true;
			this.btnPixelOffsetZero.Click += new System.EventHandler(this.btnPixelOffsetZero_Click);
			// 
			// PixelForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 801);
			this.Controls.Add(this.btnPixelOffsetZero);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbPixelOffset);
			this.Controls.Add(this.tbPosXY);
			this.Controls.Add(this.btnPixelOffsetSave);
			this.Controls.Add(this.dgvPixelOffset);
			this.Controls.Add(this.btnPixelFormClose);
			this.Name = "PixelForm";
			this.Text = "Pixel Offset (80 x 60)";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PixelForm_FormClosed);
			this.Load += new System.EventHandler(this.PixelForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvPixelOffset)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPixelFormClose;
		private System.Windows.Forms.DataGridView dgvPixelOffset;
		private System.Windows.Forms.Button btnPixelOffsetSave;
		private System.Windows.Forms.TextBox tbPosXY;
		private System.Windows.Forms.TextBox tbPixelOffset;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnPixelOffsetZero;
	}
}
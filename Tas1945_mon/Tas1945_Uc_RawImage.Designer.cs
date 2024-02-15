
namespace Tas1945_mon
{
	partial class Tas1945_Uc_RawImage
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

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent ()
		{
			this.panRawImage = new Tas1945_mon.DoubleBufferPanel();
			this.pbRawImage = new System.Windows.Forms.PictureBox();
			this.panRawImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbRawImage)).BeginInit();
			this.SuspendLayout();
			// 
			// panRawImage
			// 
			this.panRawImage.Controls.Add(this.pbRawImage);
			this.panRawImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panRawImage.Location = new System.Drawing.Point(0, 0);
			this.panRawImage.Name = "panRawImage";
			this.panRawImage.Size = new System.Drawing.Size(810, 600);
			this.panRawImage.TabIndex = 1;
			// 
			// pbRawImage
			// 
			this.pbRawImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbRawImage.Location = new System.Drawing.Point(0, 0);
			this.pbRawImage.Name = "pbRawImage";
			this.pbRawImage.Size = new System.Drawing.Size(810, 600);
			this.pbRawImage.TabIndex = 0;
			this.pbRawImage.TabStop = false;
			this.pbRawImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panRawImage_MouseDown);
			// 
			// Tas1945_Uc_RawImage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panRawImage);
			this.DoubleBuffered = true;
			this.Name = "Tas1945_Uc_RawImage";
			this.Size = new System.Drawing.Size(810, 600);
			this.panRawImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbRawImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DoubleBufferPanel panRawImage;
		public System.Windows.Forms.PictureBox pbRawImage;
	}
}

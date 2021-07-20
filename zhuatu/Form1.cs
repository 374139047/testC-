using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;

namespace zhua2
{

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;

		private System.ComponentModel.Container components = null;

		public Form1()
		{

			InitializeComponent();

		}


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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(80, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "开始抓图";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "doc1";
			this.saveFileDialog1.Filter = "jpg Files(*.jpg)|*.jpg|jpeg Files(*.*)|*.jpeg|bmp Files(*.bmp)|*.bmp";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 93);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "抓图软件";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		[ System.Runtime.InteropServices.DllImportAttribute ( "gdi32.dll" ) ]
		private static extern bool BitBlt (
			IntPtr hdcDest , 
			int nXDest , 
			int nYDest , 
			int nWidth , 
			int nHeight , 
			IntPtr hdcSrc , 
			int nXSrc , 
			int nYSrc , 
			System.Int32 dwRop
			) ;

		[ System.Runtime.InteropServices.DllImportAttribute ( "gdi32.dll" ) ]
		private static extern IntPtr CreateDC (
			string lpszDriver , 
			string lpszDevice , 
			IntPtr lpInitData 
			) ;
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Hide();
			IntPtr dc1 = CreateDC ( "DISPLAY" , null , null , ( IntPtr ) null ) ;
			Graphics g1 = Graphics.FromHdc ( dc1 ) ;
			Bitmap MyImage = new Bitmap ( Screen.PrimaryScreen.Bounds.Width , Screen.PrimaryScreen.Bounds.Height , g1 ) ;
			Graphics g2 = Graphics.FromImage ( MyImage ) ;
			IntPtr dc3 = g1.GetHdc ( ) ;
			IntPtr dc2 = g2.GetHdc ( ) ;
			BitBlt ( dc2 , 0 , 0 , Screen.PrimaryScreen.Bounds.Width , Screen.PrimaryScreen.Bounds.Height , dc3 , 0 , 0 , 13369376 ) ;
			g1.ReleaseHdc ( dc3 ) ;
			g2.ReleaseHdc ( dc2 ) ;
			if (saveFileDialog1.ShowDialog () == DialogResult.OK )
			{
				MyImage.Save ( saveFileDialog1.FileName, ImageFormat.Bmp ) ;
				MessageBox.Show ( "已经把当前屏幕保存！" ) ;
				this.Show();
			}
		}
	}
}

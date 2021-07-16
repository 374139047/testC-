using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyClockApp
{

	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lbTime;
		private System.ComponentModel.IContainer components;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 287);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(344, 22);
			this.statusBar1.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lbTime
			// 
			this.lbTime.Font = new System.Drawing.Font("Arial", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTime.Location = new System.Drawing.Point(24, 24);
			this.lbTime.Name = "lbTime";
			this.lbTime.Size = new System.Drawing.Size(288, 49);
			this.lbTime.TabIndex = 1;
			this.lbTime.Text = "88:88:88";
			this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(344, 309);
			this.Controls.Add(this.lbTime);
			this.Controls.Add(this.statusBar1);
			this.Name = "Form1";
			this.Text = "MyClockApp";
			this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		public string GetTime()
		{
			string TimeInString="";
			int hour=DateTime.Now.Hour;
			int min=DateTime.Now.Minute;
			int sec=DateTime.Now.Second;
			TimeInString=(hour < 10)?"0" + hour.ToString() :hour.ToString();
			TimeInString+=":" + ((min<10)?"0" + min.ToString() :min.ToString());
			TimeInString+=":" + ((sec<10)?"0" + sec.ToString() :sec.ToString());
			return TimeInString;
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			int h = DateTime.Now .Hour ;
			int m = DateTime.Now .Minute ;
			int s = DateTime.Now .Second ;
			MyDrawClock(h,m,s);
			statusBar1.Text = String.Format ("{0}:{1}:{2}",h,m,s);
			lbTime.Text=GetTime(); 
		}
		

		private const int s_pinlen = 75;
		private const int m_pinlen = 50;
		private const int h_pinlen = 25;
		
		private void MyDrawClock(int h, int m, int s)
		{
			Graphics g = this.CreateGraphics ();

            Rectangle rect = this.ClientRectangle;

			rect = new Rectangle(this.ClientRectangle.Right-250,this.ClientRectangle.Bottom-230,150,150);
			g.Clear (Color.White);
                                 
			Pen myPen = new Pen (Color.Blue ,1);
			g.DrawEllipse (myPen,rect);
			Point centerPoint = new Point (this.ClientRectangle.Width/2 ,this.ClientRectangle .Height /2);
			Point secPoint = new Point ( (int)(centerPoint.X +(Math.Sin(6*s*Math.PI/180) )*s_pinlen) ,
											(int)(centerPoint.Y -(Math.Cos(6*s*Math.PI/180) )*s_pinlen) ) ;
			Point minPoint = new Point ( (int)(centerPoint.X +(Math.Sin(6*m*Math.PI/180) )*m_pinlen) ,
									   	 (int)(centerPoint.Y -(Math.Cos(6*m*Math.PI/180) )*m_pinlen) ) ;
			
			Point hourPoint = new Point ( (int)(centerPoint.X +(Math.Sin(((30*h)+(m/2))*Math.PI/180) )*h_pinlen) ,
									   	 (int)(centerPoint.Y -(Math.Cos(((30*h)+(m/2))*Math.PI/180) )*h_pinlen) );
			g.DrawLine (myPen,centerPoint,secPoint);
			myPen = new Pen (Color.Green ,2);
			g.DrawLine (myPen,centerPoint,minPoint);
			myPen = new Pen (Color.Red  ,4);
			g.DrawLine (myPen,centerPoint,hourPoint);
		}
	}
}

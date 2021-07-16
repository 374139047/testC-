using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MyClockApp
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lbTime;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
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

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		public string GetTime()
		{
			string TimeInString="";
			//DateTime.Now.Hour返回当前时
			int hour=DateTime.Now.Hour;
			//DateTime.Now.Hour返回当前分
			int min=DateTime.Now.Minute;
			//DateTime.Now.Hour返回当前秒
			int sec=DateTime.Now.Second;
            //将时、分、秒连在一起得到TimeInString
			TimeInString=(hour < 10)?"0" + hour.ToString() :hour.ToString();
			TimeInString+=":" + ((min<10)?"0" + min.ToString() :min.ToString());
			TimeInString+=":" + ((sec<10)?"0" + sec.ToString() :sec.ToString());
			return TimeInString;
		}
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			//得到当前的时、分、秒
			int h = DateTime.Now .Hour ;
			int m = DateTime.Now .Minute ;
			int s = DateTime.Now .Second ;
			//调用MyDrawClock绘制图形表盘
			MyDrawClock(h,m,s);
			//在statusbar上显示数字时钟
			statusBar1.Text = String.Format ("{0}:{1}:{2}",h,m,s);
		    //在lbtime上显示数字时钟 
			lbTime.Text=GetTime(); 
		}
		
		//定义秒针，分针，时针的长度
		private const int s_pinlen = 75;
		private const int m_pinlen = 50;
		private const int h_pinlen = 25;
		
		private void MyDrawClock(int h, int m, int s)
		{
			Graphics g = this.CreateGraphics ();
			//清除所有
			
            //得到当前矩形值
            Rectangle rect = this.ClientRectangle;
			//新建矩形对象距离 底边250 右边230 横纵半径都是150 如果不都是150 两个不相等
			//比如一个是140 一个是160 则画出来的是一个椭圆 
			rect = new Rectangle(this.ClientRectangle.Right-250,this.ClientRectangle.Bottom-230,150,150);
			g.Clear (Color.White);
			//创建Pen                                    
			Pen myPen = new Pen (Color.Blue ,1);
			//绘制表盘
			g.DrawEllipse (myPen,rect);
			//表中心点 
			Point centerPoint = new Point (this.ClientRectangle.Width/2 ,this.ClientRectangle .Height /2);
			//计算出秒针，分针，时针的另外端点
			Point secPoint = new Point ( (int)(centerPoint.X +(Math.Sin(6*s*Math.PI/180) )*s_pinlen) ,
											(int)(centerPoint.Y -(Math.Cos(6*s*Math.PI/180) )*s_pinlen) ) ;
			Point minPoint = new Point ( (int)(centerPoint.X +(Math.Sin(6*m*Math.PI/180) )*m_pinlen) ,
									   	 (int)(centerPoint.Y -(Math.Cos(6*m*Math.PI/180) )*m_pinlen) ) ;
			
			Point hourPoint = new Point ( (int)(centerPoint.X +(Math.Sin(((30*h)+(m/2))*Math.PI/180) )*h_pinlen) ,
									   	 (int)(centerPoint.Y -(Math.Cos(((30*h)+(m/2))*Math.PI/180) )*h_pinlen) );
			//以不同的颜色绘制
			g.DrawLine (myPen,centerPoint,secPoint);
			myPen = new Pen (Color.Green ,2);
			g.DrawLine (myPen,centerPoint,minPoint);
			myPen = new Pen (Color.Red  ,4);
			g.DrawLine (myPen,centerPoint,hourPoint);
		}
	}
}

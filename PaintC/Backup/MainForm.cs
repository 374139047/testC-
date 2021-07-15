using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace PaintClient
{
	/// <summary>
	/// MainForm 的摘要说明。
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemSetting;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		//设置系统组件
				
		Coordinator coordinator;
		//定义了一个能够返回系统时间的对象coordinator
		
		//Store the lines
		private ArrayList Strokes=new ArrayList();
		//建立一个大小可按动态增加的数组实现接口Strokes
		//Store the current line
		Stroke CurrentStroke=null;
		//定义了一个CurrentStroke对象 用来绘制当前点
		
		Point OriginPoint;
		//设置初始点
		
		Point CurrentPoint;
		//设置当前点
		//Default width of the pen
		private int m_PenWidth=4;
		//默认笔的宽度
		private System.Windows.Forms.MenuItem menuItem2;
		
		private Color m_PenColor=Color.Black;
		//默认笔的颜色为黑色

		protected MainForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			
			try {
				
				coordinator=new Coordinator();
				//Display the time on statusbar
				statusBar1.Text="当前时间： "+coordinator.GetCurrentTime();
				
			}
			catch(Exception ex)
			{
				
			}
			
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItemSetting = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemSetting,
																					  this.menuItem2});
			this.menuItem1.Text = "选项";
			// 
			// menuItemSetting
			// 
			this.menuItemSetting.Index = 0;
			this.menuItemSetting.Text = "设置";
			this.menuItemSetting.Click += new System.EventHandler(this.menuItemSetting_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "退出";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 296);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(336, 22);
			this.statusBar1.TabIndex = 0;
			this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "简单的绘图实例";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(336, 318);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusBar1);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "PaintForm";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(Instance());
		}
		//声明一个静态属性 _instance，保证在外部类中实例化一个MainForm类时，仅有一个实例被返回
		private static MainForm _instance;
		public static MainForm Instance() {
			if(_instance==null)
				_instance=new MainForm();
			return _instance;
		}

		private void menuItemSetting_Click(object sender, System.EventArgs e)
		{
			SettingDialog dlgSetting=new SettingDialog();
			dlgSetting.ShowDialog();
			m_PenColor=dlgSetting.PenColor;
			m_PenWidth=dlgSetting.PenWidth;
			dlgSetting.Close();
		}

		//鼠标按下
		private void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Left) {
				CurrentStroke=new Stroke(e.X,e.Y);
				CurrentStroke.PenColor=m_PenColor;
				CurrentStroke.PenWidth=m_PenWidth;
				OriginPoint=new Point(e.X,e.Y);
				CurrentPoint=new Point(e.X,e.Y);

			}
		}
        //鼠标移动
		private void MainForm_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if((e.Button&MouseButtons.Left)!=0&&CurrentStroke!=null) {
				CurrentPoint=new Point(e.X,e.Y);
				Graphics g=Graphics.FromHwnd(Handle);
				Pen pen=new Pen(m_PenColor,m_PenWidth);
				g.DrawLine(pen,OriginPoint,CurrentPoint);
				pen.Dispose();
				g.Dispose();
				CurrentStroke.Add(e.X,e.Y);
				OriginPoint=CurrentPoint;

			}
		}
        //鼠标抬起
		private void MainForm_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==MouseButtons.Left && CurrentStroke!=null) {
				CurrentPoint=new Point(e.X,e.Y);
				Graphics g=Graphics.FromHwnd(Handle);
				Pen pen=new Pen(m_PenColor,m_PenWidth);
				g.DrawLine(pen,OriginPoint,CurrentPoint);
				pen.Dispose();
				g.Dispose();
				CurrentStroke.Add(e.X,e.Y);
				coordinator.DrawStroke(CurrentStroke);
				CurrentStroke=null;
			}
		}

		private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			lock(Strokes.SyncRoot) {
				foreach(Stroke stroke in Strokes) {
					stroke.DrawStroke(e.Graphics);
				}
			}
		}

		
		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//coordinator.NewStroke -= new NewStrokeEventHandler(callback.NewStrokeCallback);
		}

		private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
		
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
		
		}

		

		
	}//End of the class


	
}

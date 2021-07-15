using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

namespace PaintClient
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemSetting;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label label1;
        private IContainer components;


        Coordinator coordinator;

		
		private ArrayList Strokes=new ArrayList();

		Stroke CurrentStroke=null;
		
		Point OriginPoint;
		
		Point CurrentPoint;

		private int m_PenWidth=4;
		private System.Windows.Forms.MenuItem menuItem2;
		
		private Color m_PenColor=Color.Black;

		protected MainForm()
		{

			InitializeComponent();

			
			try {
				
				coordinator=new Coordinator();
				statusBar1.Text="当前时间： "+coordinator.GetCurrentTime();
				
			}
			catch(Exception ex)
			{
				
			}
			
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
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
            this.statusBar1.Location = new System.Drawing.Point(0, 290);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(336, 28);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar1_PanelClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "简单的绘图实例";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(336, 318);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar1);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "PaintForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			Application.Run(Instance());
		}

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

		}

		private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
		
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
		
		}

		

		
	}


	
}

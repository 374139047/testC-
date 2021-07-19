	using System ;
	using System.Drawing ;
	using System.Collections ;
	using System.ComponentModel ;
	using System.Windows.Forms ;
	using System.Data ;
	public class ScreenSaver : Form
	{
		private System.ComponentModel.IContainer components ;
		private Timer timerSaver ;
		private Label lblMarquee ;
		private int  speed = 12 ;
		private string strMarqueeText = "用C＃制造的屏幕保护" ;
		private Font fontMarquee = new Font ( "Arial" , 20 , FontStyle.Bold ) ;        
		private Color colorMarquee = Color.BlueViolet  ;
		private int iDistance ;
		private int ixStart = 0 ;
		private int iyStart = 0 ;  
		public ScreenSaver ( )
		{            
			InitializeComponent ( ) ;
			lblMarquee.Font=fontMarquee ;
			lblMarquee.ForeColor=colorMarquee ;			
			Cursor.Hide  ( ) ;
		}
		protected override void Dispose ( bool disposing )
		{
			if ( disposing )
			{
				if ( components != null ) 
				{
					components.Dispose ( ) ;
				}
			}
			base.Dispose ( disposing ) ;
		}
		private void InitializeComponent ( )
		{
			components = new System.ComponentModel.Container ( ) ;
			timerSaver = new Timer ( components ) ;
			lblMarquee = new Label ( ) ;
			SuspendLayout ( ) ;
			timerSaver.Enabled = true ;
			timerSaver.Interval = 1 ;
			timerSaver.Tick += new System.EventHandler ( timerSaver_Tick ) ;
			lblMarquee.ForeColor = Color.White ;
			lblMarquee.Location = new Point ( 113 , 0 ) ;
			lblMarquee.Name = "lblMarquee" ;
			lblMarquee.Size = new Size ( 263 , 256 ) ;
			lblMarquee.TabIndex = 0 ;
			lblMarquee.Visible = false ;
			AutoScaleBaseSize = new Size ( 6 , 14 ) ;
			BackColor = Color.Black ;
			ClientSize = new Size ( 384 , 347 ) ;
			ControlBox = false ;

			this.Controls.Add ( lblMarquee) ;
			this.KeyPreview = true ;
			this.MaximizeBox = false ;
			this.MinimizeBox = false ;
			this.Name = "ScreenSaver" ;
			this.FormBorderStyle = FormBorderStyle.None ;
			this.ShowInTaskbar = false ;
			this.WindowState = FormWindowState.Maximized ;
			this.StartPosition = FormStartPosition.Manual ;
			this.KeyDown += new KeyEventHandler ( Form1_KeyDown ) ;
			this.MouseDown += new MouseEventHandler ( Form1_MouseDown ) ;
			this.MouseMove += new MouseEventHandler ( Form1_MouseMove ) ;
			ResumeLayout ( false ) ;
		}
		protected void timerSaver_Tick ( object sender , System.EventArgs e )
		{			
			int randomum1 ;
			Random r1 = new Random();
			randomum1 = (int)(600*r1.NextDouble());
			lblMarquee.Text = strMarqueeText ;					
			lblMarquee.Height = lblMarquee.Font.Height ;									
			
			lblMarquee.Width = 350 ;
			Rectangle ssWorkArea = Screen.GetWorkingArea ( this ) ;
			lblMarquee.Location = new Point ( ssWorkArea.Width - iDistance ,
				lblMarquee.Location.Y ) ;
			randomum1 = (int)(ssWorkArea.Width*r1.NextDouble()); 
			lblMarquee.Visible = true ;
			iDistance += speed ;
			if ( lblMarquee.Location.X <= -( lblMarquee.Width ) )
			{
				iDistance = 0 ;
				lblMarquee.Location = new Point ( lblMarquee.Location.X , randomum1 ) ;
			}


		}
		protected void Form1_MouseDown ( object sender , MouseEventArgs e )
		{
			Cursor .Show  ( ) ; 
			timerSaver.Enabled = false ;
			Application .Exit ( ) ;
		}

		protected void Form1_MouseMove ( object sender , MouseEventArgs e )
		{
			if ( ixStart == 0 && iyStart == 0 )
			{
				ixStart = e.X ;
				iyStart = e.Y ;
				return ;
			}
			else if ( e.X != ixStart || e.Y != iyStart )
			  {
			     Cursor .Show  ( ) ; 
			     timerSaver.Enabled = false ;
			     Application .Exit ( ) ;
			  };
		}
	protected void Form1_KeyDown ( object sender , KeyEventArgs e )
		{
			Cursor .Show  ( ) ; 
			timerSaver.Enabled = false ;
			Application .Exit ( ) ;
		}
		public static void Main (  )
		{
			
				Application.Run ( new ScreenSaver ( ) ) ;
		}
	}
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace catchMe
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btn_catchMe;
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_catchMe = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// btn_catchMe
			// 
			this.btn_catchMe.Location = new System.Drawing.Point(100, 100);
			this.btn_catchMe.Name = "btn_catchMe";
			this.btn_catchMe.TabIndex = 0;
			this.btn_catchMe.Text = "?ƶ??İ?ť";
			this.btn_catchMe.Click += new System.EventHandler(this.btn_catchMe_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 257);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(292, 16);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "statusBar1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.btn_catchMe);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "catch me";
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private void btn_catchMe_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("?ɹ???׽");
        }

        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int border = 50;
            int x = e.X;
            int y = e.Y;
            int left = btn_catchMe.Left;
            int right = btn_catchMe.Right;
            int top = btn_catchMe.Top;
            int bottom = btn_catchMe.Bottom;
            /* ???굽??ť????(20??????) */
            if( x > left - border && x < right + border && y > top - border && y < bottom + border)
            {
                
				string prompt = "????λ??("+e.X.ToString()+","+e.Y.ToString()+")";
				statusBar1.Text = prompt;




				//?ӽ??˶??? ????20
				btn_catchMe.Top += (y > top ? -20 : 20);
                if(btn_catchMe.Top > Form1.ActiveForm.Size.Height || btn_catchMe.Bottom < 0)
                {
                    btn_catchMe.Top = Form1.ActiveForm.Size.Height/2;
                }
                //?ӽ????????? Ҳ??20
				btn_catchMe.Left += (x > left ? -20 : 20);
                if(btn_catchMe.Left > Form1.ActiveForm.Size.Width || btn_catchMe.Right < 0)
                {
                    btn_catchMe.Left = Form1.ActiveForm.Size.Width/2;
                }

            }
        }
	}
}

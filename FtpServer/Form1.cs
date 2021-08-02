using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

namespace FtpServer
{
	
	public class Form1 : System.Windows.Forms.Form
	{
		private int port;
		private Socket socket;
		private int number;
		private int i;
		private int j;
		private TcpListener listener;
		private FileStream filestream;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.ComponentModel.Container components = null;

		public Form1()
		{

			InitializeComponent();
			string[] str = new string[1024];
			string fileNameList = "";
			string strPath = Application.StartupPath + @"\..\..";
			for (i=0;i<Directory.GetFiles(strPath,"*").Length;i++)
			{
				str[i]=Directory.GetFiles(strPath)[i];
				fileNameList += str[i]+"\r\n";
			}

			textBox2.Text = fileNameList;
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(280, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 0;
			this.button1.Text = "开始";
			this.button1.Click += new System.EventHandler(this.BeginBtn_click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(360, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 1;
			this.button2.Text = "停止";
			this.button2.Click += new System.EventHandler(this.CloseBtn_click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "端口:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "文件列表:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 216);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "客户端信息:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 21);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 72);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(424, 136);
			this.textBox2.TabIndex = 6;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(8, 240);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(424, 80);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(440, 341);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Ftp服务器";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
	static void Main() 
	{
		Application.Run(new Form1());
	}
	
		private void BeginBtn_click(object sender, System.EventArgs e)
		{
			try
			{
				port = Int32.Parse(textBox1.Text);
			}
			catch{MessageBox.Show("Please enter a number!");}
			try
			{
				listener = new TcpListener(port);
				listener.Start();
				Thread thread = new Thread(new ThreadStart(receive));
				thread.Start();
			}
			catch(Exception ee){MessageBox.Show(ee.Message);}
		}
		public void receive()
		{
			try
			{
				socket = listener.AcceptSocket();
			}
			catch{return;}

			if (socket.Connected)
			{
				string str = textBox2.Text;
				byte[] bytee = System.Text.Encoding.BigEndianUnicode.GetBytes(str.ToCharArray());
				socket.Send(bytee,bytee.Length,0);

				NetworkStream stream = new NetworkStream(socket);
				byte[] by = new byte[1024];
				int i = socket.Receive(by,by.Length,0);
				string s = System.Text.Encoding.BigEndianUnicode.GetString(by);
				textBox3.AppendText(s);

				if( s.CompareTo("***The client has been closed!***") == 1 )
				{
					filestream=new FileStream(s.Substring(0,s.IndexOf("\r\n")),FileMode.Open,FileAccess.Read);
				
					byte[] buffer = new byte[1024];
					
					filestream.Seek(0,SeekOrigin.Begin);
					while((number=filestream.Read(buffer,0,1024))!=0)
					{
						stream.Write(buffer,0,number);
						stream.Flush();
						Console.WriteLine(filestream.Position);
					}
					filestream.Close();
				}
				
			}
		}

		private void CloseBtn_click(object sender, System.EventArgs e)
		{
			try
			{
				listener.Stop();
			}
			catch{MessageBox.Show("侦听尚未开始!");}
		}
	}
}

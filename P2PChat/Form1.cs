using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace P2PChat
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		private Thread th;
		private TcpListener	tcpl;
		private bool listenerRun = true;
		private System.Windows.Forms.Label label3;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(24, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "开始侦听";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(24, 96);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "停止侦听";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(24, 136);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 32);
			this.button3.TabIndex = 2;
			this.button3.Text = "发送消息";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(136, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(280, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(136, 56);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(280, 112);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "";
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.ForeColor = System.Drawing.Color.SteelBlue;
			this.richTextBox1.Location = new System.Drawing.Point(24, 200);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(392, 152);
			this.richTextBox1.TabIndex = 5;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 351);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(440, 22);
			this.statusBar1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 32);
			this.label1.TabIndex = 7;
			this.label1.Text = "目标地址:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "昵称：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.ForeColor = System.Drawing.Color.Firebrick;
			this.textBox3.Location = new System.Drawing.Point(136, 32);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(280, 21);
			this.textBox3.TabIndex = 9;
			this.textBox3.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 10;
			this.label3.Text = "聊天纪录：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(440, 373);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "P2P聊天工具";
			this.ResumeLayout(false);

		}
		#endregion

		private void Listen()
		{
			try
			{
				tcpl = new TcpListener(5656);
				tcpl.Start();
				statusBar1.Text = "正在监听...";

				while(listenerRun)
				{
					Socket s = tcpl.AcceptSocket();
					Byte[] stream = new Byte[80];
					int i=s.Receive(stream) ;
					string message = System.Text.Encoding.UTF8.GetString(stream);
					richTextBox1.AppendText(message);
				}
			}
			catch(System.Security.SecurityException)
			{
				MessageBox.Show("防火墙安全错误！","错误",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch(Exception)
			{
				statusBar1.Text = "已停止监听！";
			}
		}

		private void Send()
		{
			try
			{
				string msg = "<"+textBox3.Text+">"+textBox2.Text;
				TcpClient tcpc = new TcpClient(textBox1.Text, 5656);
				NetworkStream tcpStream = tcpc.GetStream();

				StreamWriter reqStreamW = new StreamWriter(tcpStream);
				reqStreamW.Write(msg);
				reqStreamW.Flush();
				tcpStream.Close();
				tcpc.Close();
				richTextBox1.AppendText(msg);
				textBox2.Clear();
			}
			catch(Exception)
			{
				statusBar1.Text = "目标计算机拒绝连接请求！";
			}
		}

		private void Stop()
		{
			tcpl.Stop();
			th.Abort();
		}
       
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Enabled = false;
			button2.Enabled = true;
			th = new Thread(new ThreadStart(Listen));	
			th.Start();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			button1.Enabled = true;
			button2.Enabled = false;
			listenerRun = false;
			Stop();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Send();
		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void richTextBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}

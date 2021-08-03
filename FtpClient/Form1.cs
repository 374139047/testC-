using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Text;

namespace FtpClient
{
	public class Form1 : System.Windows.Forms.Form
	{
		private TcpClient client;
		private int i;
		private NetworkStream netStream;
		private FileStream filestream=null;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private string inputString = null;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "服务器 IP:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(256, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "端口:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 24);
			this.label3.TabIndex = 3;
			this.label3.Text = "服务器文件列表:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "选择文件:";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(16, 192);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(416, 20);
			this.comboBox1.TabIndex = 6;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 288);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "连接";
			this.button1.Click += new System.EventHandler(this.ConnectBtn_click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(104, 288);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.TabIndex = 8;
			this.button2.Text = "下载";
			this.button2.Click += new System.EventHandler(this.DownloadBtn_click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(200, 288);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 24);
			this.button3.TabIndex = 9;
			this.button3.Text = "关闭";
			this.button3.Click += new System.EventHandler(this.CloseBtn_click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(88, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(144, 21);
			this.textBox1.TabIndex = 11;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(304, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(120, 21);
			this.textBox2.TabIndex = 12;
			this.textBox2.Text = "";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(16, 72);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(408, 88);
			this.textBox3.TabIndex = 13;
			this.textBox3.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(440, 317);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void ConnectBtn_click(object sender, System.EventArgs e)
		{
			int port=0;
			IPAddress serverIP=IPAddress.Parse("127.0.0.1");

			try
			{
				serverIP=IPAddress.Parse(textBox1.Text);
				
			}
			catch{MessageBox.Show("The IP is not correct!");}

			client=new TcpClient();

			try
			{
				port=Int32.Parse(textBox2.Text);

			}
			catch{MessageBox.Show("Please enter a number!");}

			try
			{
				client.Connect(serverIP,port);
				netStream = client.GetStream();
				byte[] bb = new byte[6400];
				i = netStream.Read(bb,0,6400);
				string s = System.Text.Encoding.BigEndianUnicode.GetString(bb);
				textBox3.AppendText(s);
				int j = textBox3.Lines.Length;
				for(int k=0;k<j-1;k++)
				{
					comboBox1.Items.Add(textBox3.Lines[k]);
				}
				comboBox1.Text = comboBox1.Items[0].ToString();
			}
			catch(Exception ee){MessageBox.Show(ee.Message);}
		}

		private void DownloadBtn_click(object sender, System.EventArgs e)
		{
			inputString = comboBox1.Text;
			string[] splitResults;
			string s = null;
			splitResults = Regex.Split(inputString,"\\.");
			StringBuilder resultsString = new StringBuilder(32);

			foreach(string stringElement in splitResults)
			{
				resultsString.Append(stringElement + "\n");
				s =stringElement;
			}
			saveFileDialog1.FileName=comboBox1.Text;
			saveFileDialog1.Filter = "(*."+s+")|*."+s;
			if(saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				
				filestream = new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.Write);
				netStream = client.GetStream();
				string down = comboBox1.Text+"\r\n";
				byte[] by = System.Text.Encoding.BigEndianUnicode.GetBytes(down.ToCharArray());
				netStream.Write(by,0,by.Length);
				netStream.Flush();
				Thread thread = new Thread(new ThreadStart(download));
				thread.Start();
			}
		}

		private void download()
		{
			
			Stream stream=null;
			stream=client.GetStream();
			int length=1024;
			byte[] bye=new byte[1024];
			int size = stream.Read(bye,0,length);
			while(size > 0)
			{
				filestream.Write(bye,0,size);
				filestream.Flush();
				if (size<1024)
					break;
				size = stream.Read(bye,0,length);
			} 
			filestream.Close();
			MessageBox.Show("文件成功下载!");

		}

		private void CloseBtn_click(object sender, System.EventArgs e)
		{
			try
			{
				netStream=client.GetStream();
				string clo="***The client has been closed!***";
				byte[] by=System.Text.Encoding.BigEndianUnicode.GetBytes(clo.ToCharArray());
				netStream.Write(by,0,by.Length);
				netStream.Flush();
				client.Close();
			}
			catch{return;}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}





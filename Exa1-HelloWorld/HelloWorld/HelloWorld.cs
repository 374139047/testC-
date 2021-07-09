using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace HelloWorld
{
	public class HelloWorld : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSaveFile;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.Button btnException;
		private System.Windows.Forms.TextBox txtContent;

		private System.ComponentModel.Container components = null;

		public HelloWorld()
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
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnException = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(21, 267);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(86, 30);
            this.btnSaveFile.TabIndex = 0;
            this.btnSaveFile.Text = "保存文件";
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(117, 267);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(86, 30);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "读取文件";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnException
            // 
            this.btnException.Location = new System.Drawing.Point(213, 267);
            this.btnException.Name = "btnException";
            this.btnException.Size = new System.Drawing.Size(86, 30);
            this.btnException.TabIndex = 2;
            this.btnException.Text = "抛出异常";
            this.btnException.Click += new System.EventHandler(this.btnException_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(21, 21);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(278, 236);
            this.txtContent.TabIndex = 3;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // HelloWorld
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(344, 324);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnException);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnSaveFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HelloWorld";
            this.Text = "HelloWorld";
            this.Load += new System.EventHandler(this.HelloWorld_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HelloWorld_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new HelloWorld());
		}

		private string FileName = "a.txt";
		private string FileContent;
		private void HelloWorld_Load(object sender, System.EventArgs e)
		{		
			FileInfo info = new FileInfo(FileName);
			if (!info.Exists) 
			{
				MessageBox.Show("File Doesn't Exist! Will Create!");
			}
			FileStream fs = info.Open(FileMode.OpenOrCreate,
				FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamReader sr = new StreamReader(fs);
			string strContent = sr.ReadLine();
			sr.Close();
			fs.Close();
			this.txtContent.Text = strContent;
			this.FileContent = strContent;
		}

		private void btnSaveFile_Click(object sender, System.EventArgs e)
		{
			FileInfo info = new FileInfo(FileName);
			if (!info.Exists) 
			{
				MessageBox.Show("File Doesn't Exist! Will Create!");
			}
			FileStream fs = info.Open(FileMode.OpenOrCreate,
				FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamWriter sw = new StreamWriter(fs);
			sw.WriteLine(FileContent);
			sw.Close();
			fs.Close();
		}

		private void btnLoadFile_Click(object sender, System.EventArgs e)
		{		
			FileInfo info = new FileInfo(FileName);
			if (!info.Exists) 
			{
				MessageBox.Show("File Doesn't Exist! Will Create!");
			}
			FileStream fs = info.Open(FileMode.OpenOrCreate,
				FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamReader sr = new StreamReader(fs);
			string strContent = sr.ReadLine();
			sr.Close();
			fs.Close();
			MessageBox.Show("File Content is: " + strContent);
		}

		private void btnException_Click(object sender, System.EventArgs e)
		{
			throw new Exception("I throw an Exception , but i don't know what's to do ,hehe!");
		}

		private void txtContent_TextChanged(object sender, System.EventArgs e)
		{
			this.FileContent = this.txtContent.Text;
		}

		private void HelloWorld_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) 
			{
				ArrayList listContent = new ArrayList();
				string[] strContent = FileContent.Split(null);
				foreach (string str in strContent) 
				{
					if (str != "") 
					{
						listContent.Add(str);
					}			
				}
				string strDisplay = "";
				foreach (object obj in listContent) 
				{
					string str = obj as string;
					if (str != null) 
					{
						strDisplay += str + System.Environment.NewLine;
					}		
				}
				MessageBox.Show(strDisplay);
			}
			else
			{
				Hashtable ht = new Hashtable();
				string[] strContent = FileContent.Split(null);
				int number = 0;
				foreach (string str in strContent) 
				{
					if (str != "") 
					{
						ht.Add("Number"+number.ToString(),str);
					}	
					number ++;
				}
				string strDisplay = "";
				IDictionaryEnumerator enumer = ht.GetEnumerator();
				while (enumer.MoveNext()) {
					strDisplay += enumer.Key.ToString() +
                        ":" + enumer.Value.ToString() +
						System.Environment.NewLine;
				}
				MessageBox.Show(strDisplay);
			}
		}
	}
}

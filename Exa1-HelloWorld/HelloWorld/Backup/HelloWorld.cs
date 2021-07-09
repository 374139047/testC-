using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace HelloWorld
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class HelloWorld : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSaveFile;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.Button btnException;
		private System.Windows.Forms.TextBox txtContent;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HelloWorld()
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
			this.btnSaveFile.Location = new System.Drawing.Point(16, 208);
			this.btnSaveFile.Name = "btnSaveFile";
			this.btnSaveFile.Size = new System.Drawing.Size(64, 23);
			this.btnSaveFile.TabIndex = 0;
			this.btnSaveFile.Text = "保存文件";
			this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
			// 
			// btnLoadFile
			// 
			this.btnLoadFile.Location = new System.Drawing.Point(88, 208);
			this.btnLoadFile.Name = "btnLoadFile";
			this.btnLoadFile.Size = new System.Drawing.Size(64, 23);
			this.btnLoadFile.TabIndex = 1;
			this.btnLoadFile.Text = "读取文件";
			this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
			// 
			// btnException
			// 
			this.btnException.Location = new System.Drawing.Point(160, 208);
			this.btnException.Name = "btnException";
			this.btnException.Size = new System.Drawing.Size(64, 23);
			this.btnException.TabIndex = 2;
			this.btnException.Text = "抛出异常";
			this.btnException.Click += new System.EventHandler(this.btnException_Click);
			// 
			// txtContent
			// 
			this.txtContent.Location = new System.Drawing.Point(16, 16);
			this.txtContent.Multiline = true;
			this.txtContent.Name = "txtContent";
			this.txtContent.Size = new System.Drawing.Size(208, 184);
			this.txtContent.TabIndex = 3;
			this.txtContent.Text = "";
			this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
			// 
			// HelloWorld
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(240, 245);
			this.Controls.Add(this.txtContent);
			this.Controls.Add(this.btnException);
			this.Controls.Add(this.btnLoadFile);
			this.Controls.Add(this.btnSaveFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "HelloWorld";
			this.Text = "HelloWorld";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HelloWorld_MouseDown);
			this.Load += new System.EventHandler(this.HelloWorld_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new HelloWorld());
		}

		// 定义变量
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
				// 将FileContent按照空格或者制表位分割成字符串数组
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
			}// 右键
			else
			{
				Hashtable ht = new Hashtable();
				// 将FileContent按照空格或者制表位分割成字符串数组
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

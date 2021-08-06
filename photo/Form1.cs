using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

using System.IO;
namespace photo
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Data.DataSet dataSet1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
        BindingManagerBase bManager;
		private OleDbCommandBuilder cb;
		private OleDbDataAdapter da;

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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.button2 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dataSet1 = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 64);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "载入";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(16, 112);
			this.button3.Name = "button3";
			this.button3.TabIndex = 3;
			this.button3.Text = "浏览";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
			this.pictureBox1.Location = new System.Drawing.Point(128, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(328, 248);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 160);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "textBox1";
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(464, 273);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		

		private void button2_Click(object sender, System.EventArgs e)
		{
			
			FileStream fs;
			string PathImage;
			OleDbConnection OleConn=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\db1.mdb");
			OleConn.Open();
			if (DialogResult.OK == this.openFileDialog1.ShowDialog())

			{
			 
				PathImage=this.openFileDialog1.FileName;
				fs=new FileStream(PathImage,System.IO.FileMode.Open ,System.IO.FileAccess.Read );
				byte[] ib=new byte[fs.Length];
				fs.Read(ib,0,ib.Length);
				fs.Close();

				OleDbCommand cmd = new OleDbCommand("INSERT INTO [Image1](Image1) VALUES (@img )" ,OleConn);
				((OleDbParameter)cmd.Parameters.Add( "@img" , OleDbType.Binary )).Value = ib;
				cmd.ExecuteNonQuery();
				OleConn.Close();
			
				MessageBox.Show("写入成功！");

			}
			}

		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				OleDbConnection OleConn=new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\db1.mdb");
				OleConn.Open();
			
				OleDbDataAdapter oda = new OleDbDataAdapter( "SELECT  Image1 FROM [Image1] where ID ="+ textBox1.Text ,OleConn);
				bManager.Position +=1;
				DataTable dt = new DataTable();
				oda.Fill( dt );
				OleConn.Close();

				byte[] buffer = dt.Rows[0 ] [0 ]as byte[];
				MemoryStream ms = new MemoryStream( buffer );
				pictureBox1.Image = Image.FromStream( ms );
			}
			catch
			{   MessageBox.Show("图片结束！");}

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			string ConStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\db1.mdb";
    
			
			OleDbConnection Conn = new OleDbConnection(ConStr);
      
			oleDbCommand1 = new OleDbCommand("SELECT * FROM Image1", Conn);

			da = new OleDbDataAdapter();
			da.SelectCommand = oleDbCommand1;

			cb = new OleDbCommandBuilder(da);

			da.Fill(dataSet1, "Image1");

			textBox1.DataBindings.Add("Text", dataSet1, "Image1.ID");
			bManager = this.BindingContext [dataSet1, "Image1"];
		}

		
		}
	}


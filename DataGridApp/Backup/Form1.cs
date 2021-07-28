using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace DataGridApp
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
        
		private OleDbCommandBuilder cb;
		private OleDbDataAdapter da;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
        BindingManagerBase bManager;
		private System.Windows.Forms.Button button4;
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
			this.dataSet1 = new System.Data.DataSet();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-CN");
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(264, 224);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "数据刷新";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 72);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(336, 136);
			this.dataGrid1.TabIndex = 1;
			this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 224);
			this.button2.Name = "button2";
			this.button2.TabIndex = 7;
			this.button2.Text = "Next>>";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(96, 224);
			this.button3.Name = "button3";
			this.button3.TabIndex = 6;
			this.button3.Text = "<<Back";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(216, 21);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "";
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(216, 21);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(184, 224);
			this.button4.Name = "button4";
			this.button4.TabIndex = 8;
			this.button4.Text = "删除";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(352, 253);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			string ConStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SimpleBank.mdb";
    
			
			OleDbConnection Conn = new OleDbConnection(ConStr);
      
			oleDbCommand1 = new OleDbCommand("SELECT * FROM Account", Conn);

			da = new OleDbDataAdapter();
			da.SelectCommand = oleDbCommand1;

			cb = new OleDbCommandBuilder(da);

			da.Fill(dataSet1, "Account");

			dataGrid1.SetDataBinding(dataSet1, "Account");
			textBox1.DataBindings.Add("Text", dataSet1, "Account.AccountID");
			textBox2.DataBindings.Add("Text", dataSet1, "Account.Owner");
			bManager = this.BindingContext [dataSet1, "Account"];
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			da.Update(dataSet1, "Account");
		}

		private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs e)
		{
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
		    bManager.Position -=1;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			bManager.Position +=1;
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
		   dataSet1.Tables["Account"].Rows[bManager.Position].Delete();
		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	
	}
}

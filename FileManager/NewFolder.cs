using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
	public class NewFolder : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Label lbParentPath;
		private System.ComponentModel.Container components = null;

		public NewFolder()
		{
			InitializeComponent();

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.lbParentPath = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "当前路径：";
			// 
			// lbParentPath
			// 
			this.lbParentPath.Location = new System.Drawing.Point(176, 16);
			this.lbParentPath.Name = "lbParentPath";
			this.lbParentPath.Size = new System.Drawing.Size(176, 23);
			this.lbParentPath.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "请输入新目录名：";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(168, 56);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(144, 21);
			this.txtName.TabIndex = 3;
			this.txtName.Text = "";
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(104, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "确认";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(168, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// NewFolder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(376, 182);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbParentPath);
			this.Controls.Add(this.label1);
			this.Name = "NewFolder";
			this.Text = "NewFolder";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			txtName.Text.Trim();
			if(txtName.Text=="") {
				MessageBox.Show("目录名不能为空");
				return;
			}
			if(Directory.Exists(lbParentPath.Text+"\\"+txtName.Text)) {
				MessageBox.Show("该目录已存在，请重新命名");
				return;
			}
			string FullName=lbParentPath.Text+"\\"+txtName.Text;
			Directory.CreateDirectory(FullName);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			return;
		}

		private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) {
				txtName.Text.Trim();
				if(txtName.Text=="") 
				{
					MessageBox.Show("目录名不能为空");
					return;
				}
				if(Directory.Exists(lbParentPath.Text+"\\"+txtName.Text)) 
				{
					MessageBox.Show("该目录已存在，请重新命名");
					return;
				}
				string FullName=lbParentPath.Text+"\\"+txtName.Text;
				Directory.CreateDirectory(FullName);

			}
		}
	}
}

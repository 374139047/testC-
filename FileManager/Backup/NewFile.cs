using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//Add by myself
using System.IO;

namespace FileManager
{
	/// <summary>
	/// NewFile ��ժҪ˵����
	/// </summary>
	public class NewFile : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label lbParentPath;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewFile()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbParentPath = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(184, 128);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 23);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "ȡ��";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(48, 128);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(104, 23);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "ȷ��";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(184, 72);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(144, 21);
			this.txtName.TabIndex = 9;
			this.txtName.Text = "";
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "���������ļ�����";
			// 
			// lbParentPath
			// 
			this.lbParentPath.Location = new System.Drawing.Point(192, 32);
			this.lbParentPath.Name = "lbParentPath";
			this.lbParentPath.Size = new System.Drawing.Size(160, 23);
			this.lbParentPath.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 32);
			this.label1.Name = "label1";
			this.label1.TabIndex = 6;
			this.label1.Text = "��ǰ·����";
			// 
			// NewFile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(376, 182);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbParentPath);
			this.Controls.Add(this.label1);
			this.Name = "NewFile";
			this.Text = "NewFile";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			txtName.Text.Trim();
			//check input
			if(txtName.Text=="") 
			{
				MessageBox.Show("�ļ�������Ϊ��");
				return;
			}
			if(File.Exists(lbParentPath.Text+"\\"+txtName.Text)) 
			{
				MessageBox.Show("���ļ��Ѵ��ڣ�����������");
				return;
			}
			//acquire the new name of Directory
			string FullName=lbParentPath.Text+"\\"+txtName.Text;
			//Directory.CreateDirectory(FullName);
			StreamWriter Sw=File.CreateText(FullName);
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
				//check input
				if(txtName.Text=="") 
				{
					MessageBox.Show("�ļ�������Ϊ��");
					return;
				}
				if(File.Exists(lbParentPath.Text+"\\"+txtName.Text)) 
				{
					MessageBox.Show("���ļ��Ѵ��ڣ�����������");
					return;
				}
				//acquire the new name of Directory
				string FullName=lbParentPath.Text+"\\"+txtName.Text;
				//Directory.CreateDirectory(FullName);
				StreamWriter Sw=File.CreateText(FullName);

			}
		}
	}
}

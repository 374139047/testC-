using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace EditerApp
{
	public class SearchForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnFindNext;
		private System.Windows.Forms.TextBox txtToSearch;
		private System.Windows.Forms.Button btnCancel;

		private System.ComponentModel.Container components = null;

		public SearchForm()
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
			this.btnFindNext = new System.Windows.Forms.Button();
			this.txtToSearch = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "查找内容：";
			// 
			// btnFindNext
			// 
			this.btnFindNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnFindNext.Location = new System.Drawing.Point(16, 56);
			this.btnFindNext.Name = "btnFindNext";
			this.btnFindNext.Size = new System.Drawing.Size(120, 25);
			this.btnFindNext.TabIndex = 4;
			this.btnFindNext.Text = "查找下一处(&F)";
			this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
			// 
			// txtToSearch
			// 
			this.txtToSearch.Location = new System.Drawing.Point(136, 16);
			this.txtToSearch.Name = "txtToSearch";
			this.txtToSearch.Size = new System.Drawing.Size(288, 21);
			this.txtToSearch.TabIndex = 3;
			this.txtToSearch.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(312, 56);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 25);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// SearchForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(432, 165);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnFindNext);
			this.Controls.Add(this.txtToSearch);
			this.Controls.Add(this.label1);
			this.Name = "SearchForm";
			this.Text = "SearchForm";
			this.ResumeLayout(false);

		}
		#endregion

		private int FindPlace = 0;		
		private void btnFindNext_Click(object sender, System.EventArgs e)
		{
			if (txtToSearch.Text != "")	
			{
				Form1 mainForm = (Form1)this.Owner ;
				if (mainForm.MyRTBox .Text .Length >0)
				{
					if ((FindPlace = mainForm.MyRTBox .Text.IndexOf (txtToSearch.Text ,FindPlace))==-1)
					{
						MessageBox.Show ("没有搜索到！");
						FindPlace = 0;	
					}
					else
					{
						mainForm.MyRTBox.Select (FindPlace,txtToSearch.Text .Length );
						FindPlace = FindPlace + txtToSearch.Text .Length ;
						mainForm.Activate ();
					}
				}
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		     this.Hide ();
		}
	}
}

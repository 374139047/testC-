using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
	public class EditTxt : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		public  System.Windows.Forms.Label lbFullName;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.RichTextBox txtContent;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem OpenMenu;
		private System.Windows.Forms.MenuItem NewMenu;
		private System.Windows.Forms.MenuItem SaveMenu;
		private System.Windows.Forms.MenuItem SaveAsMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem MenuBold;
		private System.Windows.Forms.MenuItem MenuItalic;
		private System.Windows.Forms.MenuItem MenuUnderline;
		private System.ComponentModel.Container components = null;

		public EditTxt()
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
			this.lbFullName = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.OpenMenu = new System.Windows.Forms.MenuItem();
			this.NewMenu = new System.Windows.Forms.MenuItem();
			this.SaveMenu = new System.Windows.Forms.MenuItem();
			this.SaveAsMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.MenuBold = new System.Windows.Forms.MenuItem();
			this.MenuItalic = new System.Windows.Forms.MenuItem();
			this.MenuUnderline = new System.Windows.Forms.MenuItem();
			this.txtContent = new System.Windows.Forms.RichTextBox();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "当前的文本路径：";
			// 
			// lbFullName
			// 
			this.lbFullName.Location = new System.Drawing.Point(168, 40);
			this.lbFullName.Name = "lbFullName";
			this.lbFullName.Size = new System.Drawing.Size(336, 23);
			this.lbFullName.TabIndex = 1;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem7});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.OpenMenu,
																					  this.NewMenu,
																					  this.SaveMenu,
																					  this.SaveAsMenu,
																					  this.ExitMenu});
			this.menuItem1.Text = "编辑";
			// 
			// OpenMenu
			// 
			this.OpenMenu.Index = 0;
			this.OpenMenu.Text = "打开";
			this.OpenMenu.Click += new System.EventHandler(this.OpenMenu_Click);
			// 
			// NewMenu
			// 
			this.NewMenu.Index = 1;
			this.NewMenu.Text = "新建";
			this.NewMenu.Click += new System.EventHandler(this.NewMenu_Click);
			// 
			// SaveMenu
			// 
			this.SaveMenu.Index = 2;
			this.SaveMenu.Text = "保存";
			this.SaveMenu.Click += new System.EventHandler(this.SaveMenu_Click);
			// 
			// SaveAsMenu
			// 
			this.SaveAsMenu.Index = 3;
			this.SaveAsMenu.Text = "另存为...";
			this.SaveAsMenu.Click += new System.EventHandler(this.SaveAsMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 4;
			this.ExitMenu.Text = "退出";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 1;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.MenuBold,
																					  this.MenuItalic,
																					  this.MenuUnderline});
			this.menuItem7.Text = "选项";
			// 
			// MenuBold
			// 
			this.MenuBold.Index = 0;
			this.MenuBold.Text = "Bold";
			this.MenuBold.Click += new System.EventHandler(this.MenuBold_Click);
			// 
			// MenuItalic
			// 
			this.MenuItalic.Index = 1;
			this.MenuItalic.Text = "Italic";
			this.MenuItalic.Click += new System.EventHandler(this.MenuItalic_Click);
			// 
			// MenuUnderline
			// 
			this.MenuUnderline.Index = 2;
			this.MenuUnderline.Text = "Underline";
			this.MenuUnderline.Click += new System.EventHandler(this.MenuUnderline_Click);
			// 
			// txtContent
			// 
			this.txtContent.Location = new System.Drawing.Point(24, 80);
			this.txtContent.Name = "txtContent";
			this.txtContent.Size = new System.Drawing.Size(480, 376);
			this.txtContent.TabIndex = 2;
			this.txtContent.Text = "";
			// 
			// dlgOpenFile
			// 
			this.dlgOpenFile.Filter = "Text Document(*.txt)|*.txt";
			this.dlgOpenFile.FilterIndex = 2;
			// 
			// dlgSaveFile
			// 
			this.dlgSaveFile.Filter = "Text Document(*.txt)|*.txt";
			this.dlgSaveFile.FilterIndex = 2;
			// 
			// EditTxt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(528, 449);
			this.Controls.Add(this.txtContent);
			this.Controls.Add(this.lbFullName);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "EditTxt";
			this.Text = "EditTxt";
			this.Load += new System.EventHandler(this.EditTxt_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void EditTxt_Load(object sender, System.EventArgs e)
		{
			try {
				FileStream fs= new FileStream(lbFullName.Text,FileMode.Open,FileAccess.Read);
				StreamReader reader= new StreamReader(fs);
				txtContent.Text=reader.ReadToEnd();
				fs.Close();
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void OpenMenu_Click(object sender, System.EventArgs e)
		{
			try {
				if(dlgOpenFile.ShowDialog()==DialogResult.OK) {
					string fileName=dlgOpenFile.FileName;
					FileStream fs= new FileStream(fileName,FileMode.Open,FileAccess.Read);
					StreamReader reader= new StreamReader(fs);
					lbFullName.Text=fileName;
					txtContent.Text=reader.ReadToEnd();
					fs.Close();
				}

			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void NewMenu_Click(object sender, System.EventArgs e)
		{
			try {
				DialogResult ret=MessageBox.Show("是否保存当前文件？","是否保存",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				if(ret==DialogResult.Yes) 
				{
					FileStream fs=new FileStream(lbFullName.Text,FileMode.Open,FileAccess.Write);
					StreamWriter writer=new StreamWriter(fs);
					writer.Write(txtContent.Text);
					writer.Flush();
					fs.Close();

				}
			
				lbFullName.Text="";
				this.txtContent.Clear();
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
				if(dlgSaveFile.ShowDialog()==DialogResult.OK) 
				{
				    string fileName=dlgSaveFile.FileName;
					Stream stream=File.OpenWrite(fileName);
					using(StreamWriter writer=new StreamWriter(stream)) 
						{
							writer.Write(txtContent.Text);
							writer.Flush();
						}

						MessageBox.Show("文件"+fileName+"保存成功");
					lbFullName.Text=fileName;
				}
			}
			
		}

		private void SaveMenu_Click(object sender, System.EventArgs e)
		{
			try {
				FileStream fs= new FileStream(lbFullName.Text,FileMode.Open,FileAccess.Write);
				StreamWriter writer=new StreamWriter(fs);
				writer.Write(txtContent.Text);
				writer.Flush();
				fs.Close();
				MessageBox.Show("文件"+lbFullName.Text+"保存成功");
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message);
				if(dlgSaveFile.ShowDialog()==DialogResult.OK) 
				{
					string fileName=dlgSaveFile.FileName;
					Stream stream=File.OpenWrite(fileName);
					using(StreamWriter writer=new StreamWriter(stream)) 
					{
						writer.Write(txtContent.Text);
						writer.Flush();
					}

					MessageBox.Show("文件"+fileName+"保存成功");
					lbFullName.Text=fileName;
				}
			}
		}

		private void SaveAsMenu_Click(object sender, System.EventArgs e)
		{
			if(dlgSaveFile.ShowDialog()==DialogResult.OK) {
				string fileName=dlgSaveFile.FileName;
				try {
					Stream stream=File.OpenWrite(fileName);
					using(StreamWriter writer=new StreamWriter(stream)) {
						writer.Write(txtContent.Text);
						writer.Flush();
					}

					MessageBox.Show("文件"+fileName+"保存成功");
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void ExitMenu_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void MenuBold_Click(object sender, System.EventArgs e)
		{
			Font newFont= new Font(txtContent.SelectionFont,(txtContent.SelectionFont.Bold?txtContent.SelectionFont.Style&~FontStyle.Bold:txtContent.SelectionFont.Style|FontStyle.Bold));
			txtContent.SelectionFont= newFont;
		}

		private void MenuItalic_Click(object sender, System.EventArgs e)
		{
			Font newFont= new Font(txtContent.SelectionFont,(txtContent.SelectionFont.Italic?txtContent.SelectionFont.Style&~FontStyle.Italic:txtContent.SelectionFont.Style|FontStyle.Italic));
			txtContent.SelectionFont= newFont;
		}

		private void MenuUnderline_Click(object sender, System.EventArgs e)
		{
			Font newFont= new Font(txtContent.SelectionFont,(txtContent.SelectionFont.Underline?txtContent.SelectionFont.Style&~FontStyle.Underline:txtContent.SelectionFont.Style|FontStyle.Underline));
			txtContent.SelectionFont= newFont;
		}


	}
}

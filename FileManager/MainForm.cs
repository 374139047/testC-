using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;


namespace FileManager
{
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Label labelCurrentPath;
		private System.Windows.Forms.TextBox txtCurPath;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.ListView FilesView;
		private System.Windows.Forms.ImageList imageLarge;
		private System.Windows.Forms.ImageList imageSmall;
		private System.Windows.Forms.ContextMenu contextMenu;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.MenuItem NewMenu;
		private System.Windows.Forms.MenuItem NewFolderMenu;
		private System.Windows.Forms.MenuItem NewFileMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		private System.Windows.Forms.MenuItem EditMenu;
		private System.Windows.Forms.MenuItem DeleteMenu;
		private System.Windows.Forms.MenuItem ContextmenuNew;
		private System.Windows.Forms.MenuItem ContextmenuNewFolder;
		private System.Windows.Forms.MenuItem ContextmenuNewFile;
		private System.Windows.Forms.MenuItem ContextmenuDelete;

		System.Collections.Specialized.StringCollection CurPath= new System.Collections.Specialized.StringCollection();

		public MainForm()
		{
			InitializeComponent();
			try 
			{
				this.txtCurPath.Text="My Computer";
				this.FilesView.Clear();
				this.FilesView.View= View.Details;
				this.FilesView.Columns.Add("本地磁盘",FilesView.Width/3,HorizontalAlignment.Left);
				string[] Drv= Directory.GetLogicalDrives();
				int DrvCnt= Drv.Length;
				for(int i=0;i<DrvCnt;i++) 
				{
					ListViewItem lvi= new ListViewItem();
					lvi.Text="驱动器"+Drv[i];
					lvi.ImageIndex=3;
					lvi.Tag=Drv[i];
					this.FilesView.Items.Add(lvi);
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.FileMenu = new System.Windows.Forms.MenuItem();
			this.NewMenu = new System.Windows.Forms.MenuItem();
			this.NewFolderMenu = new System.Windows.Forms.MenuItem();
			this.NewFileMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.EditMenu = new System.Windows.Forms.MenuItem();
			this.DeleteMenu = new System.Windows.Forms.MenuItem();
			this.labelCurrentPath = new System.Windows.Forms.Label();
			this.txtCurPath = new System.Windows.Forms.TextBox();
			this.btnUp = new System.Windows.Forms.Button();
			this.FilesView = new System.Windows.Forms.ListView();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.ContextmenuNew = new System.Windows.Forms.MenuItem();
			this.ContextmenuNewFolder = new System.Windows.Forms.MenuItem();
			this.ContextmenuNewFile = new System.Windows.Forms.MenuItem();
			this.ContextmenuDelete = new System.Windows.Forms.MenuItem();
			this.imageLarge = new System.Windows.Forms.ImageList(this.components);
			this.imageSmall = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.FileMenu,
																					  this.EditMenu});
			// 
			// FileMenu
			// 
			this.FileMenu.Index = 0;
			this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.NewMenu,
																					 this.ExitMenu});
			this.FileMenu.Text = "文件";
			// 
			// NewMenu
			// 
			this.NewMenu.Index = 0;
			this.NewMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.NewFolderMenu,
																					this.NewFileMenu});
			this.NewMenu.Text = "新建";
			this.NewMenu.Click += new System.EventHandler(this.NewMenu_Click);
			// 
			// NewFolderMenu
			// 
			this.NewFolderMenu.Index = 0;
			this.NewFolderMenu.Text = "文件夹";
			this.NewFolderMenu.Click += new System.EventHandler(this.NewFolderMenu_Click);
			// 
			// NewFileMenu
			// 
			this.NewFileMenu.Index = 1;
			this.NewFileMenu.Text = "文件";
			this.NewFileMenu.Click += new System.EventHandler(this.NewFileMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 1;
			this.ExitMenu.Text = "退出";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// EditMenu
			// 
			this.EditMenu.Index = 1;
			this.EditMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.DeleteMenu});
			this.EditMenu.Text = "编辑";
			// 
			// DeleteMenu
			// 
			this.DeleteMenu.Index = 0;
			this.DeleteMenu.Text = "删除";
			this.DeleteMenu.Click += new System.EventHandler(this.DeleteMenu_Click);
			// 
			// labelCurrentPath
			// 
			this.labelCurrentPath.Location = new System.Drawing.Point(56, 48);
			this.labelCurrentPath.Name = "labelCurrentPath";
			this.labelCurrentPath.Size = new System.Drawing.Size(72, 23);
			this.labelCurrentPath.TabIndex = 0;
			this.labelCurrentPath.Text = "路径：";
			// 
			// txtCurPath
			// 
			this.txtCurPath.Location = new System.Drawing.Point(160, 48);
			this.txtCurPath.Name = "txtCurPath";
			this.txtCurPath.ReadOnly = true;
			this.txtCurPath.Size = new System.Drawing.Size(296, 21);
			this.txtCurPath.TabIndex = 1;
			this.txtCurPath.Text = "";
			this.txtCurPath.TextChanged += new System.EventHandler(this.txtCurPath_TextChanged);
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(472, 48);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(104, 23);
			this.btnUp.TabIndex = 2;
			this.btnUp.Text = "返回上一层";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// FilesView
			// 
			this.FilesView.ContextMenu = this.contextMenu;
			this.FilesView.LargeImageList = this.imageLarge;
			this.FilesView.Location = new System.Drawing.Point(40, 96);
			this.FilesView.Name = "FilesView";
			this.FilesView.Size = new System.Drawing.Size(624, 328);
			this.FilesView.SmallImageList = this.imageSmall;
			this.FilesView.TabIndex = 3;
			this.FilesView.View = System.Windows.Forms.View.Details;
			this.FilesView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilesView_KeyDown);
			this.FilesView.DoubleClick += new System.EventHandler(this.FilesView_DoubleClick);
			this.FilesView.SelectedIndexChanged += new System.EventHandler(this.FilesView_SelectedIndexChanged);
			// 
			// contextMenu
			// 
			this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.ContextmenuNew,
																						this.ContextmenuDelete});
			// 
			// ContextmenuNew
			// 
			this.ContextmenuNew.Index = 0;
			this.ContextmenuNew.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.ContextmenuNewFolder,
																						   this.ContextmenuNewFile});
			this.ContextmenuNew.Text = "新建";
			// 
			// ContextmenuNewFolder
			// 
			this.ContextmenuNewFolder.Index = 0;
			this.ContextmenuNewFolder.Text = "文件夹";
			this.ContextmenuNewFolder.Click += new System.EventHandler(this.ContextmenuNewFolder_Click);
			// 
			// ContextmenuNewFile
			// 
			this.ContextmenuNewFile.Index = 1;
			this.ContextmenuNewFile.Text = "文件";
			this.ContextmenuNewFile.Click += new System.EventHandler(this.ContextmenuNewFile_Click);
			// 
			// ContextmenuDelete
			// 
			this.ContextmenuDelete.Index = 1;
			this.ContextmenuDelete.Text = "删除";
			this.ContextmenuDelete.Click += new System.EventHandler(this.ContextmenuDelete_Click);
			// 
			// imageLarge
			// 
			this.imageLarge.ImageSize = new System.Drawing.Size(16, 16);
			this.imageLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageLarge.ImageStream")));
			this.imageLarge.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imageSmall
			// 
			this.imageSmall.ImageSize = new System.Drawing.Size(16, 16);
			this.imageSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageSmall.ImageStream")));
			this.imageSmall.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(704, 433);
			this.Controls.Add(this.FilesView);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.txtCurPath);
			this.Controls.Add(this.labelCurrentPath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "FileManager";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
		public void FillFilesView(string FullName) 
		{
			FilesView.Clear();

			FilesView.View= View.Details;
			FilesView.Columns.Add("名称",FilesView.Width/3,HorizontalAlignment.Left);
			FilesView.Columns.Add("类型",FilesView.Width/6,HorizontalAlignment.Center);
			FilesView.Columns.Add("大小",FilesView.Width/6,HorizontalAlignment.Right);
			FilesView.Columns.Add("最后访问时间",FilesView.Width/3,HorizontalAlignment.Left);

			DirectoryInfo CurDir= new DirectoryInfo(FullName);
			DirectoryInfo[] dirs=CurDir.GetDirectories();
			FileInfo[] files=CurDir.GetFiles();

			foreach(DirectoryInfo dir in dirs) 
			{
				ListViewItem lvi= new ListViewItem();
				lvi.Text=dir.Name;
				lvi.ImageIndex=0;
				lvi.Tag=dir.FullName;
				lvi.SubItems.Add("文件夹");
				lvi.SubItems.Add("");
				lvi.SubItems.Add(dir.LastAccessTime.ToString());

				FilesView.Items.Add(lvi);
			}

			foreach(FileInfo file in files) 
			{
				ListViewItem lvi= new ListViewItem();
				lvi.Text=file.Name;
				if(file.Extension==".txt") 
				{
					lvi.ImageIndex=1;
				}
				else 
				{
					lvi.ImageIndex=2;
				}

				lvi.Tag=file.FullName;
				lvi.SubItems.Add("文件");
				lvi.SubItems.Add(file.Length.ToString());
				lvi.SubItems.Add(file.LastAccessTime.ToString());

				FilesView.Items.Add(lvi);
			}


		}

		private void FilesView_DoubleClick(object sender, System.EventArgs e)
		{
			try 
			{
				string FullName=FilesView.SelectedItems[0].Tag.ToString();

				
				if(FilesView.SelectedItems[0].ImageIndex==1) {
					return;
				}
				
				else {
				if(FilesView.SelectedItems[0].ImageIndex==2)
					System.Diagnostics.Process.Start(FullName);
				else 
				{
					txtCurPath.Text=FullName;
					FillFilesView(FullName);
					CurPath.Add(FullName);
				}
				}
				

			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
		
		}

		private void btnUp_Click(object sender, System.EventArgs e)
		{
			try 
			{
				if(CurPath.Count>1) 
				{
					string FullName=CurPath[CurPath.Count-2].ToString();
					txtCurPath.Text=FullName;
					FillFilesView(FullName);
					CurPath.RemoveAt(CurPath.Count-1);
				}
				else 
				{
					if(CurPath.Count==1)
						CurPath.RemoveAt(CurPath.Count-1);
					this.txtCurPath.Text="My Computer";
					this.FilesView.Clear();
					this.FilesView.View= View.Details;
					this.FilesView.Columns.Add("本地磁盘",FilesView.Width/3,HorizontalAlignment.Left);
					string[] Drv= Directory.GetLogicalDrives();
					int DrvCnt= Drv.Length;
					for(int i=0;i<DrvCnt;i++) 
					{
						ListViewItem lvi= new ListViewItem();
						lvi.Text="驱动器"+Drv[i];
						lvi.ImageIndex=3;
						lvi.Tag=Drv[i];
						this.FilesView.Items.Add(lvi);
					}
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}

				
		}

		private void DeleteMethod(object sender, System.EventArgs e) {
			try 
			{
				if(FilesView.SelectedItems.Count==0)
					return;
				if(FilesView.SelectedItems[0].SubItems[1].Text=="文件夹") 
				{
					string strDir=FilesView.SelectedItems[0].Tag.ToString();
					DialogResult ret=MessageBox.Show("确定删除文件夹"+strDir+"?","确定删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
					if(ret==DialogResult.OK) 
					{
						Directory.Delete(strDir,false);
						string CurFullPath=CurPath[CurPath.Count-1];
						FillFilesView(CurFullPath);
						MessageBox.Show("文件夹: " +strDir+ "已成功删除" );
					}
				}
				else 
				{
					string strFile=FilesView.SelectedItems[0].Tag.ToString();
					DialogResult ret=MessageBox.Show("确定删除文件"+strFile+"?","确定删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
					if(ret==DialogResult.OK) 
					{
						File.Delete(strFile);
						string CurFullPath=CurPath[CurPath.Count-1];
						FillFilesView(CurFullPath);
						MessageBox.Show("文件: " +strFile+ "已成功删除" );
					}

				}

			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void CreateFolderMethod(object sender, System.EventArgs e) {
			try 
			{
				NewFolder folderDlg= new NewFolder();
				folderDlg.lbParentPath.Text=CurPath[CurPath.Count-1];
				folderDlg.ShowDialog();
				string CurFullPath=CurPath[CurPath.Count-1];
				FillFilesView(CurFullPath);

				folderDlg.Dispose();
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void CreateFileMethod(object sender, System.EventArgs e) {
			try 
			{
				NewFile fileDlg= new NewFile();
				fileDlg.lbParentPath.Text=CurPath[CurPath.Count-1];
				fileDlg.ShowDialog();
				string CurFullPath=CurPath[CurPath.Count-1];
				FillFilesView(CurFullPath);
				fileDlg.Dispose();
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}

		}

		
		private void DeleteMenu_Click(object sender, System.EventArgs e)
		{
			DeleteMethod(sender,e);
		}

		private void ContextmenuDelete_Click(object sender, System.EventArgs e)
		{
			DeleteMethod(sender, e);
		}

		private void NewFolderMenu_Click(object sender, System.EventArgs e)
		{
			CreateFolderMethod(sender, e);

		}

		private void NewFileMenu_Click(object sender, System.EventArgs e)
		{
			CreateFileMethod(sender, e);
		
		}

		private void ContextmenuNewFolder_Click(object sender, System.EventArgs e)
		{
			CreateFolderMethod(sender, e);
		
		}

		private void ContextmenuNewFile_Click(object sender, System.EventArgs e)
		{
			CreateFileMethod(sender, e);		
		}

		private void ExitMenu_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FilesView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Delete) {
				DeleteMethod(sender, e);
			}
		}

		private void FilesView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void NewMenu_Click(object sender, System.EventArgs e)
		{
		
		}

		private void txtCurPath_TextChanged(object sender, System.EventArgs e)
		{
		
		}


	}
	
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO ;

namespace EditerApp
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		public System.Windows.Forms.RichTextBox MyRTBox;
		private System.Windows.Forms.StatusBar MyStatus;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem ����;
		private System.Windows.Forms.MenuItem menuItem9;
        private IContainer components;
        private System.Drawing.Printing.PrintDocument MyPrintDC;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;

		private SearchForm aSForm;
		private StringReader MySReader; 
		public Form1()
		{
			InitializeComponent();

			aSForm = new SearchForm ();
			aSForm.Owner = this;
			aSForm.Hide ();
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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.MyRTBox = new System.Windows.Forms.RichTextBox();
            this.MyStatus = new System.Windows.Forms.StatusBar();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.���� = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MyPrintDC = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // MyRTBox
            // 
            this.MyRTBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyRTBox.Location = new System.Drawing.Point(0, 0);
            this.MyRTBox.Name = "MyRTBox";
            this.MyRTBox.Size = new System.Drawing.Size(292, 254);
            this.MyRTBox.TabIndex = 0;
            this.MyRTBox.Text = "";
            this.MyRTBox.TextChanged += new System.EventHandler(this.MyRTBox_TextChanged);
            // 
            // MyStatus
            // 
            this.MyStatus.Location = new System.Drawing.Point(0, 226);
            this.MyStatus.Name = "MyStatus";
            this.MyStatus.Size = new System.Drawing.Size(292, 28);
            this.MyStatus.TabIndex = 1;
            this.MyStatus.Text = "�½��ļ�";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem7,
            this.menuItem8,
            this.����});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem2,
            this.menuItem10,
            this.menuItem11,
            this.menuItem12,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6});
            this.menuItem1.Text = "�ļ���&F��";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "�½���&N��";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "�򿪣�&O��";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.Text = "��ӡ";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.Text = "��ӡԤ��";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 4;
            this.menuItem12.Text = "ҳ������";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "���棨&S��";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 7;
            this.menuItem6.Text = "�˳���&X��";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9});
            this.menuItem7.Text = "���ڣ�&A��";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "����";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // ����
            // 
            this.����.Index = 3;
            this.����.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text Files(*.txt)|*.txt|Rich Text Format Files(*.rtf)|*.rtf|All Files(*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|Rich Text Format Files(*.rtf)|*.rtf|All Files(*.*)|*.*";
            // 
            // MyPrintDC
            // 
            this.MyPrintDC.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDC_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(292, 254);
            this.Controls.Add(this.MyStatus);
            this.Controls.Add(this.MyRTBox);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "�ı��༭��";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.ResumeLayout(false);

		}
		#endregion


		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


		private void CheckSave()
		{
			if (MyRTBox.Text != "")
			{
				if (MessageBox.Show ("�Ƿ񱣴浱ǰ�ļ���","ȷ��" ,MessageBoxButtons.OKCancel  ) == DialogResult.OK )
				{
					MySaveFile();
				}
			}
		}

		private void MyNewFile()
		{
			CheckSave(); 
			MyRTBox.Clear ();
			MyStatus.Text = "�½��ļ�";
		}


		private void MySaveFile()
		{
			MyStatus.Text = "�����ļ�";
			if (saveFileDialog1.ShowDialog () == DialogResult.OK )
			{
				MyRTBox.SaveFile (saveFileDialog1.FileName,RichTextBoxStreamType.PlainText );
			}
		}

		private void MyOpenFile()
		{
			CheckSave(); 
			
			if (openFileDialog1.ShowDialog () == DialogResult.OK )
			{
				MyRTBox.LoadFile (openFileDialog1.FileName ,RichTextBoxStreamType.PlainText );
				MyStatus.Text = "���ļ�";
			}	
		}

		private void MyExit()
		{
			CheckSave(); 

			Application.Exit ();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			MyNewFile(); 
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{			
			MyOpenFile();	
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			MySaveFile();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			MyExit();
		}

		private void MyRTBox_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			aSForm.Show ();
			aSForm.Activate ();
		}

		private void Form1_Closed(object sender, System.EventArgs e)
		{
		}

		
		private void MyPrintDC_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Graphics MyGraphics = e.Graphics ;
			Font MyPrintFont = MyRTBox.Font ;
			float iLinePerPage = e.MarginBounds.Height  / MyPrintFont.GetHeight (MyGraphics);
			int iLineNumber = 0;
			float fYPosition = 0;
			float fMarginLeft = e.MarginBounds .Left ;
			float fMarginTop = e.MarginBounds .Top;
			string strLine = "";
			while ((iLineNumber < iLinePerPage) && 
				((strLine = MySReader.ReadLine ())!=null))
			{
				fYPosition = fMarginTop + iLineNumber * MyPrintFont.GetHeight(MyGraphics);
				MyGraphics.DrawString (strLine, MyPrintFont, new SolidBrush (Color.Black ),fMarginLeft ,fYPosition,new StringFormat ());
				iLineNumber ++;
			}
			if (strLine!= null)
			{
				e.HasMorePages = true;
			}
			else 
			{
				e.HasMorePages = false;
			}
		}
		
		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			PrintDialog MyPrintDg = new PrintDialog (); 
			MyPrintDg.Document = MyPrintDC ;
			MySReader = new StringReader (MyRTBox.Text );
			if (MyPrintDg.ShowDialog () == DialogResult.OK )
			{
				try 
				{
					MyPrintDC.Print ();
				}
				catch 
				{
					MyPrintDC.PrintController.OnEndPrint (MyPrintDC, new System.Drawing.Printing.PrintEventArgs() ); 
				}
			}
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			PageSetupDialog MyPageSetupDg = new PageSetupDialog ();
			MyPageSetupDg.Document = MyPrintDC;
			try 
			{
				MyPageSetupDg.ShowDialog ();
			}
			catch {}
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			PrintPreviewDialog MyPrintPreviewDg = new PrintPreviewDialog ();
			MyPrintPreviewDg.Document = MyPrintDC;
			
			try 
			{
				MyPrintPreviewDg.ShowDialog ();
			}
			catch 
			{
				MyPrintDC.PrintController .OnEndPrint (MyPrintDC, new System.Drawing .Printing .PrintEventArgs() );
			}
		}
	}
}

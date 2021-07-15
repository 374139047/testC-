using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PaintClient
{
	/// <summary>
	/// SettingDialog 的摘要说明。
	/// </summary>
	public class SettingDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonSingle;
		private System.Windows.Forms.RadioButton radioButtonDouble;
		private System.Windows.Forms.RadioButton radioButtonTriple;
		private System.Windows.Forms.RadioButton radioButtonBlack;
		private System.Windows.Forms.RadioButton radioButtonRed;
		private System.Windows.Forms.RadioButton radioButtonGreen;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		//Add by myself
		private int penWidth=4;
		private Color penColor=Color.Black;

		public SettingDialog()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButtonTriple = new System.Windows.Forms.RadioButton();
			this.radioButtonDouble = new System.Windows.Forms.RadioButton();
			this.radioButtonSingle = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButtonGreen = new System.Windows.Forms.RadioButton();
			this.radioButtonRed = new System.Windows.Forms.RadioButton();
			this.radioButtonBlack = new System.Windows.Forms.RadioButton();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButtonTriple);
			this.groupBox1.Controls.Add(this.radioButtonDouble);
			this.groupBox1.Controls.Add(this.radioButtonSingle);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 160);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "笔宽";
			// 
			// radioButtonTriple
			// 
			this.radioButtonTriple.Location = new System.Drawing.Point(16, 120);
			this.radioButtonTriple.Name = "radioButtonTriple";
			this.radioButtonTriple.TabIndex = 4;
			this.radioButtonTriple.Text = "Triple";
			this.radioButtonTriple.CheckedChanged += new System.EventHandler(this.radioButtonTriple_CheckedChanged);
			// 
			// radioButtonDouble
			// 
			this.radioButtonDouble.Location = new System.Drawing.Point(16, 72);
			this.radioButtonDouble.Name = "radioButtonDouble";
			this.radioButtonDouble.TabIndex = 3;
			this.radioButtonDouble.Text = "Double";
			this.radioButtonDouble.CheckedChanged += new System.EventHandler(this.radioButtonDouble_CheckedChanged);
			// 
			// radioButtonSingle
			// 
			this.radioButtonSingle.Location = new System.Drawing.Point(16, 32);
			this.radioButtonSingle.Name = "radioButtonSingle";
			this.radioButtonSingle.TabIndex = 2;
			this.radioButtonSingle.Text = "Single";
			this.radioButtonSingle.CheckedChanged += new System.EventHandler(this.radioButtonSingle_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButtonGreen);
			this.groupBox2.Controls.Add(this.radioButtonRed);
			this.groupBox2.Controls.Add(this.radioButtonBlack);
			this.groupBox2.Location = new System.Drawing.Point(176, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 160);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "颜色";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// radioButtonGreen
			// 
			this.radioButtonGreen.Location = new System.Drawing.Point(16, 120);
			this.radioButtonGreen.Name = "radioButtonGreen";
			this.radioButtonGreen.TabIndex = 2;
			this.radioButtonGreen.Text = "Green";
			this.radioButtonGreen.CheckedChanged += new System.EventHandler(this.radioButtonGreen_CheckedChanged);
			// 
			// radioButtonRed
			// 
			this.radioButtonRed.Location = new System.Drawing.Point(16, 72);
			this.radioButtonRed.Name = "radioButtonRed";
			this.radioButtonRed.TabIndex = 1;
			this.radioButtonRed.Text = "Red";
			this.radioButtonRed.CheckedChanged += new System.EventHandler(this.radioButtonRed_CheckedChanged);
			// 
			// radioButtonBlack
			// 
			this.radioButtonBlack.Location = new System.Drawing.Point(16, 32);
			this.radioButtonBlack.Name = "radioButtonBlack";
			this.radioButtonBlack.TabIndex = 0;
			this.radioButtonBlack.Text = "Black";
			this.radioButtonBlack.CheckedChanged += new System.EventHandler(this.radioButtonBlack_CheckedChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(40, 200);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(200, 200);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// SettingDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(328, 254);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingDialog";
			this.Text = "Setting";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void radioButtonSingle_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButtonSingle.Checked) {
				penWidth=4;
				radioButtonDouble.Checked=false;
				radioButtonTriple.Checked=false;
			}
		}

		private void radioButtonDouble_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButtonDouble.Checked) 
			{
				penWidth=8;
				radioButtonSingle.Checked=false;
				radioButtonTriple.Checked=false;
			}
		
		}

		private void radioButtonTriple_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButtonTriple.Checked) 
			{
				penWidth=12;
				radioButtonDouble.Checked=false;
				radioButtonSingle.Checked=false;
			}
		}

		private void radioButtonBlack_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButtonBlack.Checked) {
				penColor=Color.Black;
				radioButtonRed.Checked=false;
				radioButtonGreen.Checked=false;
			}
		}

		private void radioButtonRed_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButtonRed.Checked) 
			{
				penColor=Color.Red;
				radioButtonBlack.Checked=false;
				radioButtonGreen.Checked=false;
			}
		}

		private void radioButtonGreen_CheckedChanged(object sender, System.EventArgs e)
		{
			if(radioButtonGreen.Checked) 
			{
				penColor=Color.Green;
				radioButtonRed.Checked=false;
				radioButtonBlack.Checked=false;
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			PaintClient.SettingDialog.ActiveForm.Close();
		
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}

		//属性
		public int PenWidth {
			get {
				return penWidth;
			}
			set {
				penWidth=value;
			}
		}
		public Color PenColor {
			get {
				return penColor;
			}
			set {
				penColor=value;
			}
		}
	}
}

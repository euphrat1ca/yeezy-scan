using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace windowsmanger
{
	public class FormCode : Form
	{
		private ToolStripButton btnGetCode;
		private ToolStripButton btnGetWBCode;
		private IContainer components;
		private FormMain mainfrm;
		private ToolStrip toolStripCode;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private TextBox txtCode;
		public FormCode(FormMain fm)
		{
			this.InitializeComponent();
			this.mainfrm = fm;
		}
		private void btnGetCode_Click(object sender, EventArgs e)
		{
			MessageBox.Show("此功能暂停使用。。。。");
		}
		private void btnGetWBCode_Click(object sender, EventArgs e)
		{
			this.txtCode.Clear();
			string sourceCodeFromWebBrowser = this.mainfrm.GetSourceCodeFromWebBrowser();
			this.txtCode.Text = sourceCodeFromWebBrowser;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormCode));
			this.toolStripCode = new ToolStrip();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.btnGetCode = new ToolStripButton();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.btnGetWBCode = new ToolStripButton();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.txtCode = new TextBox();
			this.toolStripCode.SuspendLayout();
			base.SuspendLayout();
			this.toolStripCode.BackColor = SystemColors.ButtonFace;
			this.toolStripCode.Dock = DockStyle.Bottom;
			this.toolStripCode.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStripCode.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripSeparator1,
				this.btnGetCode,
				this.toolStripSeparator2,
				this.btnGetWBCode,
				this.toolStripSeparator3
			});
			this.toolStripCode.Location = new Point(0, 341);
			this.toolStripCode.Name = "toolStripCode";
			this.toolStripCode.Size = new Size(575, 25);
			this.toolStripCode.TabIndex = 0;
			this.toolStripCode.Text = "toolStrip1";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 25);
			this.btnGetCode.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.btnGetCode.Image = (Image)resources.GetObject("btnGetCode.Image");
			this.btnGetCode.ImageTransparentColor = Color.Magenta;
			this.btnGetCode.Name = "btnGetCode";
			this.btnGetCode.Size = new Size(144, 22);
			this.btnGetCode.Text = "获取当前网址的网站源码";
			this.btnGetCode.Click += new EventHandler(this.btnGetCode_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 25);
			this.btnGetWBCode.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.btnGetWBCode.Image = (Image)resources.GetObject("btnGetWBCode.Image");
			this.btnGetWBCode.ImageTransparentColor = Color.Magenta;
			this.btnGetWBCode.Name = "btnGetWBCode";
			this.btnGetWBCode.Size = new Size(156, 22);
			this.btnGetWBCode.Text = "获取当前浏览器的网站源码";
			this.btnGetWBCode.Click += new EventHandler(this.btnGetWBCode_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(6, 25);
			this.txtCode.Dock = DockStyle.Fill;
			this.txtCode.HideSelection = false;
			this.txtCode.Location = new Point(0, 0);
			this.txtCode.Multiline = true;
			this.txtCode.Name = "txtCode";
			this.txtCode.ScrollBars = ScrollBars.Both;
			this.txtCode.Size = new Size(575, 341);
			this.txtCode.TabIndex = 6;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(575, 366);
			base.Controls.Add(this.txtCode);
			base.Controls.Add(this.toolStripCode);
			this.Cursor = Cursors.Arrow;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormCode";
			this.Text = "FormCode";
			this.toolStripCode.ResumeLayout(false);
			this.toolStripCode.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public void SelectCode(int Location, int Length)
		{
			this.txtCode.Select(Location, Length);
		}
		public void UpdateCodeText(string Code)
		{
			this.txtCode.Text = Code;
		}
	}
}

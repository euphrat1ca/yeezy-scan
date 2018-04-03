using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace windowsmanger
{
	public class FormAbout : Form
	{
		private IContainer components;
		private Label lblRegInfo;
		private FormMain mainfrm;
		private SplitContainer splitAbout;
		private TextBox txtHelp;
		public FormAbout(FormMain fm)
		{
			this.InitializeComponent();
			this.mainfrm = fm;
		}
		private void btnReg_Click(object sender, EventArgs e)
		{
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
			this.splitAbout = new SplitContainer();
			this.txtHelp = new TextBox();
			this.lblRegInfo = new Label();
			this.splitAbout.Panel1.SuspendLayout();
			this.splitAbout.Panel2.SuspendLayout();
			this.splitAbout.SuspendLayout();
			base.SuspendLayout();
			this.splitAbout.Dock = DockStyle.Fill;
			this.splitAbout.Location = new Point(0, 0);
			this.splitAbout.Name = "splitAbout";
			this.splitAbout.Orientation = Orientation.Horizontal;
			this.splitAbout.Panel1.Controls.Add(this.txtHelp);
			this.splitAbout.Panel2.Controls.Add(this.lblRegInfo);
			this.splitAbout.Size = new Size(634, 371);
			this.splitAbout.SplitterDistance = 258;
			this.splitAbout.TabIndex = 0;
			this.txtHelp.BackColor = SystemColors.Control;
			this.txtHelp.Dock = DockStyle.Fill;
			this.txtHelp.Location = new Point(0, 0);
			this.txtHelp.Margin = new Padding(2);
			this.txtHelp.Multiline = true;
			this.txtHelp.Name = "txtHelp";
			this.txtHelp.ReadOnly = true;
			this.txtHelp.Size = new Size(634, 258);
			this.txtHelp.TabIndex = 9;
			this.txtHelp.Text = "非常感谢朋友提供建议让程序各方面日渐完善，By：웷篘梅  270029002\r\n\r\nBy:韩宇 921388559\r\n\r\n备注：部分源码收集于网络 \r\n";
			this.lblRegInfo.AutoSize = true;
			this.lblRegInfo.Location = new Point(3, 10);
			this.lblRegInfo.Name = "lblRegInfo";
			this.lblRegInfo.Size = new Size(0, 12);
			this.lblRegInfo.TabIndex = 1;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(634, 371);
			base.Controls.Add(this.splitAbout);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormAbout";
			this.Text = "FormAbout";
			this.splitAbout.Panel1.ResumeLayout(false);
			this.splitAbout.Panel1.PerformLayout();
			this.splitAbout.Panel2.ResumeLayout(false);
			this.splitAbout.Panel2.PerformLayout();
			this.splitAbout.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		public void InitRegControl()
		{
			if (Reg.A1K3)
			{
				this.lblRegInfo.Text = "This copy of WebCruiser is licensed to: " + Reg.RegUser;
			}
			else
			{
				if (Reg.LeftDays > 0)
				{
					this.lblRegInfo.Text = "This Copy of WebCruiser is UnRegistered! You can use it for " + Reg.LeftDays.ToString() + " days.";
				}
				else
				{
					this.lblRegInfo.Text = "This Copy of WebCruiser is UnRegistered and Expired! Please Register If You Would Like To Continue Using It!";
					MessageBox.Show("This Copy of WebCruiser is UnRegistered and Expired! Please Register If You Would Like To Continue Using It!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			this.mainfrm.InitFunctionByRegistration(Reg.A1K3, Reg.LeftDays);
		}
	}
}

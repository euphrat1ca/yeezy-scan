using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace windowsmanger
{
	public class Form2 : Form
	{
		private IContainer components;
		private ToolStripLabel toolStripLabel1;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStrip toolStripURL;
		private ToolStripTextBox txtURL;
		private ToolStripComboBox cmbReqType;
		private ToolStripButton toolStripBtnGo;
		private ToolStripButton toolStripBtnPause;
		private ToolStripButton toolStripBtnStop;
		private ToolStripStatusLabel lblThreadNum;
		private StatusStrip statusStripMain;
		private ToolStripStatusLabel toolStripStatusProgress;
		private ToolStripStatusLabel toolStripStatusSep1;
		private ToolStrip toolStripMain;
		private ToolStripButton toolStripButtonNew;
		private ToolStripButton toolStripButtonOpen;
		private ToolStripButton toolStripButtonSave;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripButton toolStripButtonBrowser;
		private ToolStripButton toolStripButtonScanner;
		private ToolStripSeparator toolStripSeparator10;
		private ToolStripButton toolStripButtonSQL;
		private ToolStripSeparator toolStripSeparator20;
		private ToolStripButton toolStripButtonXSS;
		private ToolStripSeparator toolStripSeparator11;
		private ToolStripButton ButtonResend;
		private ToolStripButton ButtonCookie;
		private ToolStripSeparator toolStripSeparator17;
		private ToolStripButton ButtonReport;
		private ToolStripSeparator toolStripSeparator18;
		private ToolStripButton ButtonSetting;
		private ToolStripSeparator toolStripSeparator13;
		private ToolStripSeparator toolStripSeparator15;
		private ToolStripButton ButtonScanURL;
		private ToolStripSeparator toolStripSeparator14;
		private ToolStripButton ButtonScanSite;
		private ToolStripButton ButtonAutoFill;
		private Timer ScanTimer;
		private ToolStripSeparator toolStripSeparator16;
		private Timer AdTimer;
		private ToolStripTextBox txtSubmitData;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStrip toolStripData;
		private ToolStripLabel lblSubmitData;
		private TreeView treeViewToolTree;
		private ImageList WCRImageList;
		private SplitContainer splitMain;
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
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(Form2));
			TreeNode treeNode = new TreeNode("浏览器");
			TreeNode treeNode2 = new TreeNode("漏洞扫描");
			TreeNode treeNode3 = new TreeNode("SQL Injection");
			TreeNode treeNode4 = new TreeNode("Cross Site Scripting");
			TreeNode treeNode5 = new TreeNode("AdministrationEntrance");
			TreeNode treeNode6 = new TreeNode("POC(Proof Of Concept)", new TreeNode[]
			{
				treeNode3,
				treeNode4,
				treeNode5
			});
			TreeNode treeNode7 = new TreeNode("ResendTool");
			TreeNode treeNode8 = new TreeNode("CookieTool");
			TreeNode treeNode9 = new TreeNode("CodeTool");
			TreeNode treeNode10 = new TreeNode("StringTool");
			TreeNode treeNode11 = new TreeNode("Settings");
			TreeNode treeNode12 = new TreeNode("Report");
			TreeNode treeNode13 = new TreeNode("SystemTool", new TreeNode[]
			{
				treeNode7,
				treeNode8,
				treeNode9,
				treeNode10,
				treeNode11,
				treeNode12
			});
			TreeNode treeNode14 = new TreeNode("关于");
			this.toolStripLabel1 = new ToolStripLabel();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.toolStripURL = new ToolStrip();
			this.txtURL = new ToolStripTextBox();
			this.cmbReqType = new ToolStripComboBox();
			this.toolStripBtnGo = new ToolStripButton();
			this.toolStripBtnPause = new ToolStripButton();
			this.toolStripBtnStop = new ToolStripButton();
			this.lblThreadNum = new ToolStripStatusLabel();
			this.statusStripMain = new StatusStrip();
			this.toolStripStatusProgress = new ToolStripStatusLabel();
			this.toolStripStatusSep1 = new ToolStripStatusLabel();
			this.toolStripMain = new ToolStrip();
			this.toolStripButtonNew = new ToolStripButton();
			this.toolStripButtonOpen = new ToolStripButton();
			this.toolStripButtonSave = new ToolStripButton();
			this.toolStripSeparator4 = new ToolStripSeparator();
			this.toolStripButtonBrowser = new ToolStripButton();
			this.toolStripButtonScanner = new ToolStripButton();
			this.toolStripSeparator10 = new ToolStripSeparator();
			this.toolStripButtonSQL = new ToolStripButton();
			this.toolStripSeparator20 = new ToolStripSeparator();
			this.toolStripButtonXSS = new ToolStripButton();
			this.toolStripSeparator11 = new ToolStripSeparator();
			this.ButtonResend = new ToolStripButton();
			this.ButtonCookie = new ToolStripButton();
			this.toolStripSeparator17 = new ToolStripSeparator();
			this.ButtonReport = new ToolStripButton();
			this.toolStripSeparator18 = new ToolStripSeparator();
			this.ButtonSetting = new ToolStripButton();
			this.toolStripSeparator13 = new ToolStripSeparator();
			this.toolStripSeparator15 = new ToolStripSeparator();
			this.ButtonScanURL = new ToolStripButton();
			this.toolStripSeparator14 = new ToolStripSeparator();
			this.ButtonScanSite = new ToolStripButton();
			this.ButtonAutoFill = new ToolStripButton();
			this.ScanTimer = new Timer(this.components);
			this.toolStripSeparator16 = new ToolStripSeparator();
			this.AdTimer = new Timer(this.components);
			this.txtSubmitData = new ToolStripTextBox();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.toolStripData = new ToolStrip();
			this.lblSubmitData = new ToolStripLabel();
			this.treeViewToolTree = new TreeView();
			this.WCRImageList = new ImageList(this.components);
			this.splitMain = new SplitContainer();
			this.toolStripURL.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.toolStripMain.SuspendLayout();
			this.toolStripData.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.SuspendLayout();
			base.SuspendLayout();
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new Size(29, 22);
			this.toolStripLabel1.Text = "URL:";
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(6, 25);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 25);
			this.toolStripURL.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripLabel1,
				this.toolStripSeparator1,
				this.txtURL,
				this.toolStripSeparator3,
				this.cmbReqType,
				this.toolStripBtnGo,
				this.toolStripBtnPause,
				this.toolStripBtnStop
			});
			this.toolStripURL.Location = new Point(0, 25);
			this.toolStripURL.Name = "toolStripURL";
			this.toolStripURL.Size = new Size(1058, 25);
			this.toolStripURL.TabIndex = 9;
			this.toolStripURL.Text = "toolStrip1";
			this.txtURL.AutoSize = false;
			this.txtURL.Name = "txtURL";
			this.txtURL.Overflow = ToolStripItemOverflow.Never;
			this.txtURL.Size = new Size(581, 25);
			this.cmbReqType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbReqType.Items.AddRange(new object[]
			{
				"GET",
				"POST",
				"COOKIE"
			});
			this.cmbReqType.Name = "cmbReqType";
			this.cmbReqType.Size = new Size(75, 25);
			this.cmbReqType.ToolTipText = "Request Type";
			this.toolStripBtnGo.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripBtnGo.Image = (Image)resources.GetObject("toolStripBtnGo.Image");
			this.toolStripBtnGo.ImageTransparentColor = Color.Magenta;
			this.toolStripBtnGo.Name = "toolStripBtnGo";
			this.toolStripBtnGo.Size = new Size(23, 22);
			this.toolStripBtnGo.Text = "toolStripButton1";
			this.toolStripBtnGo.ToolTipText = "Browser";
			this.toolStripBtnPause.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripBtnPause.Image = (Image)resources.GetObject("toolStripBtnPause.Image");
			this.toolStripBtnPause.ImageTransparentColor = Color.Magenta;
			this.toolStripBtnPause.Name = "toolStripBtnPause";
			this.toolStripBtnPause.Size = new Size(23, 22);
			this.toolStripBtnPause.Text = "toolStripButton1";
			this.toolStripBtnPause.ToolTipText = "Pause";
			this.toolStripBtnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripBtnStop.Image = (Image)resources.GetObject("toolStripBtnStop.Image");
			this.toolStripBtnStop.ImageTransparentColor = Color.Magenta;
			this.toolStripBtnStop.Name = "toolStripBtnStop";
			this.toolStripBtnStop.Size = new Size(23, 22);
			this.toolStripBtnStop.Text = "toolStripButton1";
			this.toolStripBtnStop.ToolTipText = "Stop";
			this.lblThreadNum.AutoSize = false;
			this.lblThreadNum.Name = "lblThreadNum";
			this.lblThreadNum.Size = new Size(125, 17);
			this.lblThreadNum.TextAlign = ContentAlignment.MiddleLeft;
			this.statusStripMain.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusProgress,
				this.toolStripStatusSep1,
				this.lblThreadNum
			});
			this.statusStripMain.Location = new Point(0, 539);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new Size(1058, 22);
			this.statusStripMain.TabIndex = 8;
			this.statusStripMain.Text = "statusStrip1";
			this.toolStripStatusProgress.AutoSize = false;
			this.toolStripStatusProgress.Name = "toolStripStatusProgress";
			this.toolStripStatusProgress.Size = new Size(642, 17);
			this.toolStripStatusProgress.Text = "Done";
			this.toolStripStatusProgress.TextAlign = ContentAlignment.MiddleLeft;
			this.toolStripStatusSep1.ForeColor = SystemColors.ControlDark;
			this.toolStripStatusSep1.Name = "toolStripStatusSep1";
			this.toolStripStatusSep1.Size = new Size(11, 17);
			this.toolStripStatusSep1.Text = "|";
			this.toolStripMain.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButtonNew,
				this.toolStripButtonOpen,
				this.toolStripButtonSave,
				this.toolStripSeparator4,
				this.toolStripButtonBrowser,
				this.toolStripButtonScanner,
				this.toolStripSeparator10,
				this.toolStripButtonSQL,
				this.toolStripSeparator20,
				this.toolStripButtonXSS,
				this.toolStripSeparator11,
				this.ButtonResend,
				this.ButtonCookie,
				this.toolStripSeparator17,
				this.ButtonReport,
				this.toolStripSeparator18,
				this.ButtonSetting,
				this.toolStripSeparator13,
				this.toolStripSeparator15,
				this.ButtonScanURL,
				this.toolStripSeparator14,
				this.ButtonScanSite
			});
			this.toolStripMain.Location = new Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new Size(1058, 25);
			this.toolStripMain.TabIndex = 7;
			this.toolStripMain.Text = "toolStrip1";
			this.toolStripButtonNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonNew.Image = (Image)resources.GetObject("toolStripButtonNew.Image");
			this.toolStripButtonNew.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonNew.Name = "toolStripButtonNew";
			this.toolStripButtonNew.Size = new Size(23, 22);
			this.toolStripButtonNew.Text = "toolStripButton1";
			this.toolStripButtonNew.ToolTipText = "New Scan";
			this.toolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonOpen.Image = (Image)resources.GetObject("toolStripButtonOpen.Image");
			this.toolStripButtonOpen.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonOpen.Name = "toolStripButtonOpen";
			this.toolStripButtonOpen.Size = new Size(23, 22);
			this.toolStripButtonOpen.Text = "toolStripButton2";
			this.toolStripButtonOpen.ToolTipText = "Open Existed Data";
			this.toolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSave.Image = (Image)resources.GetObject("toolStripButtonSave.Image");
			this.toolStripButtonSave.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonSave.Name = "toolStripButtonSave";
			this.toolStripButtonSave.Size = new Size(23, 22);
			this.toolStripButtonSave.Text = "toolStripButton3";
			this.toolStripButtonSave.ToolTipText = "Save Current Data";
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new Size(6, 25);
			this.toolStripButtonBrowser.Image = (Image)resources.GetObject("toolStripButtonBrowser.Image");
			this.toolStripButtonBrowser.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonBrowser.Name = "toolStripButtonBrowser";
			this.toolStripButtonBrowser.Size = new Size(61, 22);
			this.toolStripButtonBrowser.Text = "浏览器";
			this.toolStripButtonBrowser.ToolTipText = "Web Browser";
			this.toolStripButtonScanner.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonScanner.Name = "toolStripButtonScanner";
			this.toolStripButtonScanner.Size = new Size(33, 22);
			this.toolStripButtonScanner.Text = "扫描";
			this.toolStripButtonScanner.ToolTipText = "Vulnerability Scanner";
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new Size(6, 25);
			this.toolStripButtonSQL.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonSQL.Name = "toolStripButtonSQL";
			this.toolStripButtonSQL.Size = new Size(27, 22);
			this.toolStripButtonSQL.Text = "SQL";
			this.toolStripButtonSQL.ToolTipText = "SQL Injection";
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new Size(6, 25);
			this.toolStripButtonXSS.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonXSS.Name = "toolStripButtonXSS";
			this.toolStripButtonXSS.Size = new Size(27, 22);
			this.toolStripButtonXSS.Text = "XSS";
			this.toolStripButtonXSS.ToolTipText = "Cross Site Scripting";
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new Size(6, 25);
			this.ButtonResend.ImageTransparentColor = Color.Magenta;
			this.ButtonResend.Name = "ButtonResend";
			this.ButtonResend.Size = new Size(45, 22);
			this.ButtonResend.Text = "Resend";
			this.ButtonResend.ToolTipText = "Resend Tool";
			this.ButtonCookie.Image = (Image)resources.GetObject("ButtonCookie.Image");
			this.ButtonCookie.ImageTransparentColor = Color.Magenta;
			this.ButtonCookie.Name = "ButtonCookie";
			this.ButtonCookie.Size = new Size(61, 22);
			this.ButtonCookie.Text = "Cookie";
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new Size(6, 25);
			this.ButtonReport.ImageTransparentColor = Color.Magenta;
			this.ButtonReport.Name = "ButtonReport";
			this.ButtonReport.Size = new Size(33, 22);
			this.ButtonReport.Text = "报表";
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new Size(6, 25);
			this.ButtonSetting.ImageTransparentColor = Color.Magenta;
			this.ButtonSetting.Name = "ButtonSetting";
			this.ButtonSetting.Size = new Size(33, 22);
			this.ButtonSetting.Text = "设置";
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new Size(6, 25);
			this.toolStripSeparator15.Alignment = ToolStripItemAlignment.Right;
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new Size(6, 25);
			this.ButtonScanURL.Alignment = ToolStripItemAlignment.Right;
			this.ButtonScanURL.ImageTransparentColor = Color.Magenta;
			this.ButtonScanURL.Name = "ButtonScanURL";
			this.ButtonScanURL.Size = new Size(51, 22);
			this.ButtonScanURL.Text = "扫描URL";
			this.ButtonScanURL.ToolTipText = "Scan Current URL";
			this.toolStripSeparator14.Alignment = ToolStripItemAlignment.Right;
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new Size(6, 25);
			this.ButtonScanSite.Alignment = ToolStripItemAlignment.Right;
			this.ButtonScanSite.ImageTransparentColor = Color.Magenta;
			this.ButtonScanSite.Name = "ButtonScanSite";
			this.ButtonScanSite.Size = new Size(57, 22);
			this.ButtonScanSite.Text = "扫描网站";
			this.ButtonScanSite.ToolTipText = "Scan Current Site";
			this.ButtonAutoFill.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.ButtonAutoFill.ImageTransparentColor = Color.Magenta;
			this.ButtonAutoFill.Name = "ButtonAutoFill";
			this.ButtonAutoFill.Size = new Size(23, 22);
			this.ButtonAutoFill.Text = "Fill in Form";
			this.ScanTimer.Enabled = true;
			this.ScanTimer.Interval = 2500;
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new Size(6, 25);
			this.AdTimer.Enabled = true;
			this.AdTimer.Interval = 90000;
			this.txtSubmitData.AutoSize = false;
			this.txtSubmitData.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.txtSubmitData.Name = "txtSubmitData";
			this.txtSubmitData.Overflow = ToolStripItemOverflow.Never;
			this.txtSubmitData.Size = new Size(650, 25);
			this.txtSubmitData.ToolTipText = resources.GetString("txtSubmitData.ToolTipText");
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 25);
			this.toolStripData.Items.AddRange(new ToolStripItem[]
			{
				this.lblSubmitData,
				this.toolStripSeparator2,
				this.txtSubmitData,
				this.toolStripSeparator16,
				this.ButtonAutoFill
			});
			this.toolStripData.Location = new Point(0, 0);
			this.toolStripData.Name = "toolStripData";
			this.toolStripData.Size = new Size(1058, 25);
			this.toolStripData.TabIndex = 11;
			this.toolStripData.Visible = false;
			this.lblSubmitData.Name = "lblSubmitData";
			this.lblSubmitData.Size = new Size(29, 22);
			this.lblSubmitData.Text = "Data";
			this.treeViewToolTree.Dock = DockStyle.Fill;
			this.treeViewToolTree.ImageIndex = 0;
			this.treeViewToolTree.ImageList = this.WCRImageList;
			this.treeViewToolTree.Location = new Point(0, 0);
			this.treeViewToolTree.Name = "treeViewToolTree";
			treeNode.ImageKey = "ie.png";
			treeNode.Name = "WebBrowser";
			treeNode.Text = "浏览器";
			treeNode2.ImageKey = "scan.png";
			treeNode2.Name = "Scanner";
			treeNode2.Text = "漏洞扫描";
			treeNode3.ImageKey = "db.png";
			treeNode3.Name = "SQL";
			treeNode3.Text = "SQL Injection";
			treeNode4.ImageKey = "xss.png";
			treeNode4.Name = "XSS";
			treeNode4.Text = "Cross Site Scripting";
			treeNode5.ImageKey = "admin.png";
			treeNode5.Name = "Admin";
			treeNode5.Text = "AdministrationEntrance";
			treeNode6.ImageKey = "tool.png";
			treeNode6.Name = "POCTool";
			treeNode6.Text = "POC(Proof Of Concept)";
			treeNode7.ImageKey = "resend.png";
			treeNode7.Name = "Resend";
			treeNode7.Text = "ResendTool";
			treeNode8.ImageKey = "cookie.png";
			treeNode8.Name = "Cookie";
			treeNode8.Text = "CookieTool";
			treeNode9.ImageKey = "code.png";
			treeNode9.Name = "Code";
			treeNode9.Text = "CodeTool";
			treeNode10.ImageKey = "encode.png";
			treeNode10.Name = "StringTool";
			treeNode10.Text = "StringTool";
			treeNode11.ImageKey = "tool.png";
			treeNode11.Name = "Setting";
			treeNode11.Text = "Settings";
			treeNode12.ImageKey = "report.png";
			treeNode12.Name = "Report";
			treeNode12.Text = "Report";
			treeNode13.ImageKey = "tool.png";
			treeNode13.Name = "SystemTool";
			treeNode13.Text = "SystemTool";
			treeNode14.ImageKey = "about.png";
			treeNode14.Name = "About";
			treeNode14.Text = "关于";
			this.treeViewToolTree.Nodes.AddRange(new TreeNode[]
			{
				treeNode,
				treeNode2,
				treeNode6,
				treeNode13,
				treeNode14
			});
			this.treeViewToolTree.SelectedImageIndex = 0;
			this.treeViewToolTree.Size = new Size(201, 561);
			this.treeViewToolTree.TabIndex = 0;
			this.WCRImageList.ImageStream = (ImageListStreamer)resources.GetObject("WCRImageList.ImageStream");
			this.WCRImageList.TransparentColor = Color.Transparent;
			this.WCRImageList.Images.SetKeyName(0, "select.png");
			this.WCRImageList.Images.SetKeyName(1, "ie.png");
			this.WCRImageList.Images.SetKeyName(2, "scan.png");
			this.WCRImageList.Images.SetKeyName(3, "env.png");
			this.WCRImageList.Images.SetKeyName(4, "db.png");
			this.WCRImageList.Images.SetKeyName(5, "xss.png");
			this.WCRImageList.Images.SetKeyName(6, "cmd.png");
			this.WCRImageList.Images.SetKeyName(7, "admin.png");
			this.WCRImageList.Images.SetKeyName(8, "file.png");
			this.WCRImageList.Images.SetKeyName(9, "tool.png");
			this.WCRImageList.Images.SetKeyName(10, "code.png");
			this.WCRImageList.Images.SetKeyName(11, "about.png");
			this.WCRImageList.Images.SetKeyName(12, "go.png");
			this.WCRImageList.Images.SetKeyName(13, "start.png");
			this.WCRImageList.Images.SetKeyName(14, "pause.png");
			this.WCRImageList.Images.SetKeyName(15, "stop.png");
			this.WCRImageList.Images.SetKeyName(16, "table.png");
			this.WCRImageList.Images.SetKeyName(17, "column.png");
			this.WCRImageList.Images.SetKeyName(18, "vul.png");
			this.WCRImageList.Images.SetKeyName(19, "xml.png");
			this.WCRImageList.Images.SetKeyName(20, "report.png");
			this.WCRImageList.Images.SetKeyName(21, "cookie.png");
			this.WCRImageList.Images.SetKeyName(22, "resend.png");
			this.WCRImageList.Images.SetKeyName(23, "encode.png");
			this.splitMain.BackColor = SystemColors.ButtonFace;
			this.splitMain.Dock = DockStyle.Fill;
			this.splitMain.Location = new Point(0, 0);
			this.splitMain.Name = "splitMain";
			this.splitMain.Panel1.BackColor = Color.WhiteSmoke;
			this.splitMain.Panel1.Controls.Add(this.treeViewToolTree);
			this.splitMain.Panel2.BackColor = Color.WhiteSmoke;
			this.splitMain.Panel2.Paint += new PaintEventHandler(this.splitMain_Panel2_Paint);
			this.splitMain.Size = new Size(1058, 561);
			this.splitMain.SplitterDistance = 201;
			this.splitMain.TabIndex = 10;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(1058, 561);
			base.Controls.Add(this.toolStripURL);
			base.Controls.Add(this.statusStripMain);
			base.Controls.Add(this.toolStripMain);
			base.Controls.Add(this.toolStripData);
			base.Controls.Add(this.splitMain);
			base.Name = "Form2";
			this.Text = "Form2";
			this.toolStripURL.ResumeLayout(false);
			this.toolStripURL.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.toolStripData.ResumeLayout(false);
			this.toolStripData.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public Form2()
		{
			this.InitializeComponent();
		}
		private void splitMain_Panel2_Paint(object sender, PaintEventArgs e)
		{
		}
	}
}

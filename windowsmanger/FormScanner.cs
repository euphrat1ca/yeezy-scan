using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web.UI;
using System.Windows.Forms;
using System.Xml;
using windowsmanger.Properties;
namespace windowsmanger
{
	public class FormScanner : Form
	{
		private delegate void dd(string s);
		private delegate void ddc(TreeView s, TreeView d);
		private delegate ListViewItem dl(int i);
		private ColumnHeader columnKeyWord;
		private ColumnHeader columnParameter;
		private ColumnHeader columnType;
		private ColumnHeader columnURL;
		private ColumnHeader columnVul;
		private IContainer components;
		private ImageList ImageListScanner;
		private bool IsMultiScanSubForm;
		private ToolStripStatusLabel lblProgress;
		private ToolStripStatusLabel lblThreadNum;
		private ListView listViewWVS;
		private FormMain mainfrm;
		private int ScanDepth;
		private System.Timers.Timer ScannerTimer;
		private WebSite SiteA;
		private SplitContainer splitScanner;
		private StatusStrip statusScanner;
		private ToolStripButton toolStripClearWVS;
		private ToolStripButton toolStripExpWVS;
		private ToolStripButton toolStripImpWVS;
		private ToolStripButton toolStripMultiScan;
		private ToolStrip toolStripScanner;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripSeparator toolStripSeparator7;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private ToolStripButton toolStripURLScan;
		private ToolStripButton toolStripWVScan;
		private List<string> TreeNodeURL;
		private TreeView treeViewWVS;
		public FormScanner(FormMain fm)
		{
			this.TreeNodeURL = new List<string>();
			this.InitializeComponent();
			this.mainfrm = fm;
			this.SiteA = this.mainfrm.CurrentSite;
			this.InitSystemTimer();
		}
		public FormScanner(FormMain fm, WebSite wsite)
		{
			this.TreeNodeURL = new List<string>();
			this.InitializeComponent();
			this.mainfrm = fm;
			this.IsMultiScanSubForm = true;
			WebSite.MultiProcessNum++;
			this.toolStripScanner.Enabled = false;
			base.FormBorderStyle = FormBorderStyle.Sizable;
			this.SiteA = wsite;
			this.Text = this.SiteA.URL + " - Scanner";
			this.InitSystemTimer();
			if (!string.IsNullOrEmpty(this.SiteA.URL))
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.AutoSiteScan));
			}
		}
		public void AddItem2ListViewWVS(string Text)
		{
			if (!this.listViewWVS.InvokeRequired)
			{
				string[] separator = new string[]
				{
					"^^"
				};
				string[] strArray2 = Text.Split(separator, StringSplitOptions.None);
				ListViewItem item = this.listViewWVS.Items.Add(strArray2[0]);
				item.ImageKey = "vul.png";
				for (int i = 1; i < strArray2.Length; i++)
				{
					item.SubItems.Add(strArray2[i]);
				}
				this.listViewWVS.Refresh();
				return;
			}
			FormScanner.dd method = new FormScanner.dd(this.AddItem2ListViewWVS);
			base.Invoke(method, new object[]
			{
				Text
			});
		}
		private void AddItem2TreeViewWVS(string sURL)
		{
			if (!string.IsNullOrEmpty(sURL))
			{
				if (sURL.IndexOf('^') > 0)
				{
					sURL = sURL.Split(new char[]
					{
						'^'
					})[0];
				}
				try
				{
					sURL = sURL.Replace("/./", "/");
					Uri uri = new Uri(sURL);
					if (uri.Host.Equals(this.SiteA.DomainHost))
					{
						if (!this.treeViewWVS.InvokeRequired)
						{
							int startIndex = sURL.IndexOf('/', 9) + 1;
							if (startIndex != 0)
							{
								string[] strArray2 = sURL.Substring(startIndex).Split(new char[]
								{
									'?'
								});
								string[] strArray3 = strArray2[0].Split(new char[]
								{
									'/'
								});
								string str = "";
								if (strArray2.Length > 1)
								{
									for (int i = 1; i < strArray2.Length; i++)
									{
										if (!string.IsNullOrEmpty(str))
										{
											str += "?";
										}
										str += strArray2[i];
									}
									string[] strArray4;
									IntPtr ptr;
									(strArray4 = strArray3)[(int)(ptr = (IntPtr)(strArray3.Length - 1))] = strArray4[(int)ptr] + "?" + str;
								}
								TreeNode node = new TreeNode();
								TreeNode node2 = new TreeNode();
								for (int j = 0; j < strArray3.Length; j++)
								{
									if (string.IsNullOrEmpty(strArray3[j]))
									{
										return;
									}
									if (j == 0)
									{
										node = this.ContainsTreeNode(this.treeViewWVS.Nodes, strArray3[0]);
										if (node == null)
										{
											node = this.treeViewWVS.Nodes.Add(strArray3[0]);
										}
									}
									else
									{
										node2 = this.ContainsTreeNode(node.Nodes, strArray3[j]);
										if (node2 == null)
										{
											node2 = node.Nodes.Add(strArray3[j]);
										}
										node = node2;
									}
								}
								this.treeViewWVS.ExpandAll();
								this.treeViewWVS.Refresh();
							}
						}
						else
						{
							FormScanner.dd method = new FormScanner.dd(this.AddItem2TreeViewWVS);
							base.Invoke(method, new object[]
							{
								sURL
							});
						}
					}
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
		}
		private void AutoSiteScan(object data)
		{
			try
			{
				this.BeginSiteScan();
				bool flag = false;
				while (!flag)
				{
					Thread.Sleep(1000);
					if (DateTime.Now.Subtract(this.SiteA.LastGetTime).Seconds > 20 && this.SiteA.HTTPThreadNum == 0)
					{
						flag = true;
					}
				}
				if (this.IsMultiScanSubForm)
				{
					WebSite.MultiProcessNum--;
				}
				this.ExportWVS(this.SiteA.DomainHost + "_Vuls_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml");
				XmlDocument xmlDocumentFromWVS = this.GetXmlDocumentFromWVS();
				this.GenReport(xmlDocumentFromWVS);
				this.mainfrm.DisposeSubForm(this);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void AutoSiteScanControl(object data)
		{
			string str = (string)data;
			string[] separator = new string[]
			{
				"^^"
			};
			string[] strArray2 = str.Split(separator, StringSplitOptions.None);
			for (int i = 0; i < strArray2.Length; i++)
			{
				string str2 = strArray2[i].ToString().Trim();
				if (!string.IsNullOrEmpty(str2) && str2.IndexOf("http") >= 0)
				{
					while (WebSite.MultiProcessNum >= WCRSetting.MultiSitesNum)
					{
						Thread.Sleep(1000);
					}
					WebSite wsite = new WebSite(str2);
					FormScanner scanner = new FormScanner(this.mainfrm, wsite);
					MethodInvoker method = new MethodInvoker(scanner.Show);
					base.Invoke(method, null);
				}
			}
		}
		private void BeginSiteScan()
		{
			if (!this.IsMultiScanSubForm)
			{
				this.SiteA.URL = this.mainfrm.URL;
			}
			if (string.IsNullOrEmpty(this.SiteA.URL))
			{
				MessageBox.Show("Null URL!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			this.AddItem2TreeViewWVS(this.SiteA.URL);
			this.DisplayProgress("Scanning...");
			string urlss = this.SiteA.URL;
			if (urlss.Contains("http://"))
			{
				urlss = urlss.Replace("http://", "");
				if (urlss.Contains("/"))
				{
					urlss = urlss.Substring(0, urlss.IndexOf("/"));
				}
			}
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.Scan_cmsshibie), urlss);
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckRobots));
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckSiteMapXML));
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.CrawlPage), this.SiteA.URL);
            new Thread((System.Threading.ThreadStart)delegate
            {
                for (int i = 0; i < WCRSetting.ScanDepth; i++)
                {
                    while (this.SiteA.HTTPThreadNum > 0)
                    {
                        Thread.Sleep(200);
                    }
                    if (WebSite.CurrentStatus == TaskStatus.Stop)
                    {
                        return;
                    }
                    if (i == 0)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckVulnerability), this.SiteA.URL);
                    }
                    this.ScanDepth = i + 1;
                    Thread.Sleep(1000);
                    this.CrawlTreeViewWVS();
                    if (WebSite.CurrentStatus == TaskStatus.Stop)
                    {
                        return;
                    }
                }
            });
		}
		private void CheckRobots(object data)
		{
			try
			{
				string sURL = this.SiteA.HTTPRoot + "robots.txt";
				HttpWebResponse httpWebResponse = this.SiteA.GetHttpWebResponse(sURL, RequestType.GET);
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					string sourceCodeFromHttpWebResponse = this.mainfrm.CurrentSite.GetSourceCodeFromHttpWebResponse(httpWebResponse);
					Regex regex = new Regex("(?<=allow:\\s+)[^\\s?*$]+", RegexOptions.IgnoreCase | RegexOptions.Singleline);
					foreach (Match match in regex.Matches(sourceCodeFromHttpWebResponse))
					{
						string str3 = match.Value;
						if (str3.Length > 1)
						{
							str3 = this.SiteA.HTTPRoot + str3.Substring(1);
							this.AddItem2TreeViewWVS(str3);
						}
					}
				}
			}
			catch
			{
			}
		}
		private void CheckSiteMapXML(object data)
		{
			try
			{
				string sURL = this.SiteA.HTTPRoot + "sitemap.xml";
				HttpWebResponse httpWebResponse = this.SiteA.GetHttpWebResponse(sURL, RequestType.GET);
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					string sourceCodeFromHttpWebResponse = this.mainfrm.CurrentSite.GetSourceCodeFromHttpWebResponse(httpWebResponse);
					Regex regex = new Regex("(?<=<loc>)[\\S]+(?=<\\/loc>)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
					foreach (Match match in regex.Matches(sourceCodeFromHttpWebResponse))
					{
						string str3 = match.Value;
						if (str3.Length > 1)
						{
							str3 = str3.Replace("&amp;", "&");
							this.AddItem2TreeViewWVS(str3);
						}
					}
				}
			}
			catch
			{
			}
		}
		private void CheckVulnerability(object data)
		{
			try
			{
				if (WebSite.CurrentStatus == TaskStatus.Stop)
				{
					Thread.CurrentThread.Abort();
				}
				string sURL = (string)data;
				if (!this.SiteA.HasScannedURL(sURL))
				{
					this.SiteA.AddScannedURL(WebSite.URL2DistinctURL(sURL));
					if (!this.SiteA.GetFileExt(sURL).Equals(".js"))
					{
						if (sURL.IndexOf('=') > 0)
						{
							this.DisplayProgress("正在检查 SQL 注入: " + sURL);
							string[] injectableURLDesc = this.SiteA.GetInjectableURLDesc(sURL, RequestType.GET, "");
							for (int i = 0; i < injectableURLDesc.Length; i++)
							{
								string str2 = injectableURLDesc[i];
								this.AddItem2ListViewWVS(str2);
							}
						}
						if (WebSite.CurrentStatus == TaskStatus.Stop)
						{
							Thread.CurrentThread.Abort();
						}
						if (WCRSetting.ScanXSS)
						{
							this.DisplayProgress("正在检查 网站 XSS: " + sURL);
							string[] xSSURLInfo = this.GetXSSURLInfo(sURL);
							for (int j = 0; j < xSSURLInfo.Length; j++)
							{
								string str3 = xSSURLInfo[j];
								if (!string.IsNullOrEmpty(str3))
								{
									this.AddItem2ListViewWVS(str3);
								}
							}
						}
						if (WebSite.CurrentStatus == TaskStatus.Stop)
						{
							Thread.CurrentThread.Abort();
						}
						this.DisplayProgress("正在检查 Form Vul: " + sURL);
						string[] formVuls = this.SiteA.GetFormVuls(sURL);
						for (int k = 0; k < formVuls.Length; k++)
						{
							string str4 = formVuls[k];
							if (!string.IsNullOrEmpty(str4))
							{
								this.AddItem2ListViewWVS(str4);
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		private void CloneTreeView(TreeView SourceTree, TreeView DestTree)
		{
			if (!this.treeViewWVS.InvokeRequired)
			{
				DestTree.Nodes.Clear();
				foreach (TreeNode node in SourceTree.Nodes)
				{
					DestTree.Nodes.Add((TreeNode)node.Clone());
				}
				DestTree.ExpandAll();
				return;
			}
			FormScanner.ddc method = new FormScanner.ddc(this.CloneTreeView);
			base.Invoke(method, new object[]
			{
				SourceTree,
				DestTree
			});
		}
		private TreeNode ContainsTreeNode(TreeNodeCollection tn, string Text)
		{
			string str = Text;
			if (Text.IndexOf('?') >= 0)
			{
				string[] strArray = Text.Split(new char[]
				{
					'?'
				});
				str = strArray[0];
				if (strArray.Length >= 2)
				{
					string[] array = strArray[1].Split(new char[]
					{
						'&'
					});
					for (int j = 0; j < array.Length; j++)
					{
						string str2 = array[j];
						string[] strArray2 = str2.Split(new char[]
						{
							'='
						});
						str = str + "?" + strArray2[0];
					}
				}
			}
			for (int i = 0; i < tn.Count; i++)
			{
				string text = tn[i].Text;
				if (text.IndexOf('?') >= 0)
				{
					string[] strArray3 = text.Split(new char[]
					{
						'?'
					});
					if (strArray3.Length < 2)
					{
						text = strArray3[0];
					}
					else
					{
						text = strArray3[0];
						string[] array2 = strArray3[1].Split(new char[]
						{
							'&'
						});
						for (int k = 0; k < array2.Length; k++)
						{
							string str3 = array2[k];
							string[] strArray4 = str3.Split(new char[]
							{
								'='
							});
							text = text + "?" + strArray4[0];
						}
					}
				}
				if (text.Equals(str))
				{
					return tn[i];
				}
			}
			return null;
		}
		private void CrawlPage(object Data)
		{
			if (WebSite.CurrentStatus != TaskStatus.Stop)
			{
				try
				{
					string sURL = (string)Data;
					if (!this.SiteA.HasCrawledURL(sURL))
					{
						this.SiteA.AddCrawledURL(WebSite.URL2DistinctURL(sURL));
						if (this.IsWebPage(sURL))
						{
							string fileExt = this.SiteA.GetFileExt(sURL);
							this.DisplayProgress("Depth: " + this.ScanDepth.ToString() + "  Scanning: " + sURL);
							HttpWebResponse httpWebResponse = this.SiteA.GetHttpWebResponse(sURL, RequestType.GET);
							if (httpWebResponse != null)
							{
								string sourceCodeFromHttpWebResponse = this.mainfrm.CurrentSite.GetSourceCodeFromHttpWebResponse(httpWebResponse);
								string str4 = httpWebResponse.ResponseUri.ToString();
								if (!str4.Equals(sURL))
								{
									this.SiteA.AddCrawledURL(WebSite.URL2DistinctURL(str4));
								}
								string pathFromURL = WebSite.GetPathFromURL(str4);
								string[] strArray = this.SiteA.GetLinksFromSource(sourceCodeFromHttpWebResponse, pathFromURL, fileExt);
								for (int i = 0; i < strArray.Length; i++)
								{
									if (WebSite.CurrentStatus == TaskStatus.Stop)
									{
										break;
									}
									string uriString = strArray[i];
									Uri uri = new Uri(uriString);
									if (uri.Host.Equals(this.SiteA.DomainHost))
									{
										this.AddItem2TreeViewWVS(uriString);
										this.AddItem2TreeViewWVS(WebSite.URL2NoParaURL(uriString));
										if (!this.SiteA.HasScannedURL(uriString) && this.IsWebPage(uriString))
										{
											ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckVulnerability), uriString);
										}
									}
									if (uriString.Contains(".action"))
									{
										Struts2 exp = new Struts2();
										string urlsing = uriString.Substring(0, uriString.IndexOf(".action") + 7);
										string jieguo = exp.exp(urlsing);
										if (jieguo != "未做安全检测")
										{
											ListViewItem item = new ListViewItem(urlsing);
											item.SubItems.Add("发现严重漏洞");
											item.SubItems.Add("action");
											item.SubItems.Add("Struts2漏洞");
											item.SubItems.Add("检测结果用户权限为" + jieguo);
											item.ImageKey = "vul.png";
											this.listViewWVS.Items.Add(item);
										}
									}
								}
							}
						}
					}
				}
				catch
				{
				}
			}
		}
		private void CrawlTreeViewWVS()
		{
			try
			{
				this.TreeNodeURL.Clear();
				TreeView destTree = new TreeView();
				this.CloneTreeView(this.treeViewWVS, destTree);
				foreach (TreeNode node in destTree.Nodes)
				{
					if (node.Nodes.Count == 0)
					{
						string sURL = this.SiteA.HTTPRoot + node.Text;
						if (this.IsWebPage(sURL))
						{
							this.TreeNodeURL.Add(sURL);
						}
					}
					else
					{
						this.TreeNode2URLS(this.SiteA.HTTPRoot, node);
					}
				}
				for (int i = 0; i < this.TreeNodeURL.Count; i++)
				{
					if (WebSite.CurrentStatus == TaskStatus.Stop)
					{
						Thread.CurrentThread.Abort();
					}
					if (this.IsWebPage(this.TreeNodeURL[i]))
					{
						this.CrawlPage(this.TreeNodeURL[i]);
					}
				}
			}
			catch
			{
			}
		}
		public void DisplayProgress(string Text)
		{
			if (!this.statusScanner.InvokeRequired)
			{
				this.lblProgress.Text = Text;
				this.statusScanner.Refresh();
				return;
			}
			FormScanner.dd method = new FormScanner.dd(this.DisplayProgress);
			base.Invoke(method, new object[]
			{
				Text
			});
		}
		public void DisplayThreadNum(string Text)
		{
			if (!this.statusScanner.InvokeRequired)
			{
				this.lblThreadNum.Text = Text;
				this.statusScanner.Refresh();
				return;
			}
			FormScanner.dd method = new FormScanner.dd(this.DisplayThreadNum);
			base.Invoke(method, new object[]
			{
				Text
			});
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		public void EnableFunc(bool RegOK)
		{
			this.toolStripWVScan.Enabled = RegOK;
		}
		private void ExportWVS(string WVSXmlFileName)
		{
			try
			{
				XmlDocument xmlDocumentFromWVS = this.GetXmlDocumentFromWVS();
				int i = 1;
				while (File.Exists(Application.StartupPath + "\\" + WVSXmlFileName))
				{
					WVSXmlFileName = i.ToString() + "_" + WVSXmlFileName;
					i++;
				}
				xmlDocumentFromWVS.Save(WVSXmlFileName);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void FormScanner_Resize(object sender, EventArgs e)
		{
			this.lblProgress.Width = this.toolStripScanner.Width - 150;
		}
		private string GenReport(XmlDocument WcrXml)
		{
			string path = this.SiteA.DomainHost + "_Scan_Report_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
			StringWriter writer = new StringWriter();
			string result;
			try
			{
				HtmlTextWriter writer2 = new HtmlTextWriter(writer);
				writer2.RenderBeginTag(HtmlTextWriterTag.Html);
				writer2.RenderBeginTag(HtmlTextWriterTag.Head);
				writer2.Write("<meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">");
				writer2.Write("<style>table{table-layout:fixed;overflow:hidden;}</style>");
				writer2.RenderBeginTag(HtmlTextWriterTag.Title);
				writer2.Write("Scan Report");
				writer2.RenderEndTag();
				writer2.RenderEndTag();
				writer2.RenderBeginTag(HtmlTextWriterTag.Body);
				writer2.RenderBeginTag(HtmlTextWriterTag.Center);
				writer2.Write("<br><br><br><br><br><br><br><br>");
				writer2.RenderBeginTag(HtmlTextWriterTag.H1);
				writer2.Write(this.SiteA.DomainHost + " Scan Report<br>");
				writer2.RenderEndTag();
				writer2.Write("<br><br><br><br><br><br><br><br>Created By WebCruiser - Web Vulnerability Scanner<br>" + DateTime.Now.ToString("yyyy-MM-dd"));
				writer2.Write("<div style=\"page-break-after:always\">&nbsp;</div>");
				XmlNodeList list = WcrXml.SelectNodes("//ROOT/SiteVulList/VulRow");
				if (list.Count > 0)
				{
					writer2.RenderBeginTag(HtmlTextWriterTag.H2);
					writer2.Write("Vulnerability Result");
					writer2.RenderEndTag();
					for (int i = 0; i < list.Count; i++)
					{
						writer2.AddAttribute("border", "1");
						writer2.AddAttribute("width", "640");
						writer2.AddAttribute("cellspacing", "0");
						writer2.AddAttribute("bordercolordark", "009099");
						writer2.RenderBeginTag(HtmlTextWriterTag.Table);
						writer2.Write("<tr><td width=\"150\">No.</td><td>" + (i + 1).ToString() + "</td></tr>");
						XmlNode node = list[i];
						for (int j = 0; j < node.ChildNodes.Count; j++)
						{
							writer2.Write("<tr><td width=\"150\">");
							writer2.Write(node.ChildNodes[j].Name);
							writer2.Write("</td><td>");
							writer2.Write(node.ChildNodes[j].InnerText.Replace("<>", "&lt;&gt;"));
							writer2.Write("</td></tr>");
						}
						writer2.RenderEndTag();
						writer2.Write("<br>");
					}
				}
				writer2.RenderEndTag();
				writer2.RenderEndTag();
				writer2.RenderEndTag();
				File.WriteAllText(path, writer.ToString());
				result = path;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				File.WriteAllText(path, writer.ToString());
				result = path;
			}
			return result;
		}
		private ListViewItem GetListViewItem(int Index)
		{
			if (!this.listViewWVS.InvokeRequired)
			{
				return this.listViewWVS.Items[Index];
			}
			FormScanner.dl method = new FormScanner.dl(this.GetListViewItem);
			return (ListViewItem)base.Invoke(method, new object[]
			{
				Index
			});
		}
		public XmlDocument GetXmlDocumentFromDirTree()
		{
			XmlDocument wVSXml = new XmlDocument();
			XmlNode newChild = wVSXml.CreateXmlDeclaration("1.0", "utf-8", "");
			wVSXml.AppendChild(newChild);
			XmlElement element = wVSXml.CreateElement("ROOT");
			wVSXml.AppendChild(element);
			XmlElement element2 = wVSXml.CreateElement("SiteDirTree");
			element.AppendChild(element2);
			foreach (TreeNode node2 in this.treeViewWVS.Nodes)
			{
				wVSXml = this.TreeNode2XmlElement(wVSXml, element2, node2);
			}
			return wVSXml;
		}
		public XmlDocument GetXmlDocumentFromWVS()
		{
			XmlDocument document = new XmlDocument();
			XmlNode newChild = document.CreateXmlDeclaration("1.0", "utf-8", "");
			document.AppendChild(newChild);
			XmlElement element = document.CreateElement("ROOT");
			document.AppendChild(element);
			XmlElement element2 = document.CreateElement("SiteVulList");
			element.AppendChild(element2);
			for (int i = 0; i < this.listViewWVS.Items.Count; i++)
			{
				ListViewItem listViewItem = this.GetListViewItem(i);
				XmlElement element3 = document.CreateElement("VulRow");
				XmlElement element4 = document.CreateElement("ReferURL");
				element4.InnerText = listViewItem.SubItems[0].Text;
				element3.AppendChild(element4);
				element4 = document.CreateElement("Parameter");
				element4.InnerText = listViewItem.SubItems[1].Text;
				element3.AppendChild(element4);
				element4 = document.CreateElement("Type");
				element4.InnerText = listViewItem.SubItems[2].Text;
				element3.AppendChild(element4);
				element4 = document.CreateElement("KWordActionURL");
				element4.InnerText = listViewItem.SubItems[3].Text;
				element3.AppendChild(element4);
				element4 = document.CreateElement("Vulnerability");
				element4.InnerText = listViewItem.SubItems[4].Text;
				element3.AppendChild(element4);
				element2.AppendChild(element3);
			}
			return document;
		}
		private string[] GetXSSURLInfo(string sURL)
		{
			List<string> list = new List<string>();
			if (WebSite.CurrentStatus != TaskStatus.Stop)
			{
				string[] strArray = sURL.Split(new char[]
				{
					'?'
				});
				if (strArray.Length < 2)
				{
					return list.ToArray();
				}
				string[] strArray2 = strArray[1].Split(new char[]
				{
					'&'
				});
				for (int i = 0; i < strArray2.Length; i++)
				{
					string uRL = strArray[0];
					string str2 = "";
					for (int j = 0; j < i; j++)
					{
						if (!string.IsNullOrEmpty(str2))
						{
							str2 += "&";
						}
						str2 += strArray2[j];
					}
					string str3 = strArray2[i].Split(new char[]
					{
						'='
					})[0];
					string uRLPara = WebSite.URL2NoParaURL(sURL) + "^" + str3.ToLower() + "^XSS";
					if (!this.SiteA.IsScannedParameter(uRLPara))
					{
						this.SiteA.AddScannedParameter(uRLPara);
						if (!string.IsNullOrEmpty(str2))
						{
							str2 += "&";
						}
						str2 = str2 + str3 + "=" + WebSite.GenerateTestInput(i, "<>%3c%3e%253c%253e");
						for (int k = i + 1; k < strArray2.Length; k++)
						{
							if (!string.IsNullOrEmpty(str2))
							{
								str2 += "&";
							}
							str2 += strArray2[k];
						}
						uRL = uRL + "?" + str2;
						string keyTextFromSource = WebSite.GetKeyTextFromSource(this.SiteA.GetSourceCode(uRL, RequestType.GET), i);
						if (!string.IsNullOrEmpty(keyTextFromSource) && keyTextFromSource.IndexOf("<>") >= 0)
						{
							string str4 = WebSite.RemoveTestInput(uRL);
							string item = string.Concat(new string[]
							{
								sURL,
								"^^",
								str3,
								"^^GET^^",
								str4,
								"^^Cross Site Scripting(URL)"
							});
							list.Add(item);
						}
					}
				}
			}
			return list.ToArray();
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FormScanner));
			this.splitScanner = new SplitContainer();
			this.treeViewWVS = new TreeView();
			this.listViewWVS = new ListView();
			this.columnURL = new ColumnHeader();
			this.columnParameter = new ColumnHeader();
			this.columnType = new ColumnHeader();
			this.columnKeyWord = new ColumnHeader();
			this.columnVul = new ColumnHeader();
			this.ImageListScanner = new ImageList(this.components);
			this.toolStripScanner = new ToolStrip();
			this.toolStripSeparator7 = new ToolStripSeparator();
			this.toolStripWVScan = new ToolStripButton();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.toolStripURLScan = new ToolStripButton();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.toolStripMultiScan = new ToolStripButton();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.toolStripClearWVS = new ToolStripButton();
			this.toolStripSeparator4 = new ToolStripSeparator();
			this.toolStripImpWVS = new ToolStripButton();
			this.toolStripSeparator5 = new ToolStripSeparator();
			this.toolStripExpWVS = new ToolStripButton();
			this.toolStripSeparator6 = new ToolStripSeparator();
			this.statusScanner = new StatusStrip();
			this.lblProgress = new ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new ToolStripStatusLabel();
			this.lblThreadNum = new ToolStripStatusLabel();
			this.splitScanner.Panel1.SuspendLayout();
			this.splitScanner.Panel2.SuspendLayout();
			this.splitScanner.SuspendLayout();
			this.toolStripScanner.SuspendLayout();
			this.statusScanner.SuspendLayout();
			base.SuspendLayout();
			this.splitScanner.Dock = DockStyle.Fill;
			this.splitScanner.Location = new Point(0, 25);
			this.splitScanner.Name = "splitScanner";
			this.splitScanner.Orientation = Orientation.Horizontal;
			this.splitScanner.Panel1.Controls.Add(this.treeViewWVS);
			this.splitScanner.Panel2.Controls.Add(this.listViewWVS);
			this.splitScanner.Size = new Size(642, 339);
			this.splitScanner.SplitterDistance = 164;
			this.splitScanner.TabIndex = 0;
			this.treeViewWVS.Dock = DockStyle.Fill;
			this.treeViewWVS.FullRowSelect = true;
			this.treeViewWVS.Location = new Point(0, 0);
			this.treeViewWVS.Name = "treeViewWVS";
			this.treeViewWVS.Size = new Size(642, 164);
			this.treeViewWVS.TabIndex = 5;
			this.treeViewWVS.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeViewWVS_NodeMouseClick);
			this.listViewWVS.Columns.AddRange(new ColumnHeader[]
			{
				this.columnURL,
				this.columnParameter,
				this.columnType,
				this.columnKeyWord,
				this.columnVul
			});
			this.listViewWVS.Dock = DockStyle.Fill;
			this.listViewWVS.FullRowSelect = true;
			this.listViewWVS.Location = new Point(0, 0);
			this.listViewWVS.MultiSelect = false;
			this.listViewWVS.Name = "listViewWVS";
			this.listViewWVS.Size = new Size(642, 171);
			this.listViewWVS.SmallImageList = this.ImageListScanner;
			this.listViewWVS.TabIndex = 3;
			this.listViewWVS.UseCompatibleStateImageBehavior = false;
			this.listViewWVS.View = View.Details;
			this.listViewWVS.MouseClick += new MouseEventHandler(this.listViewWVS_MouseClick);
			this.columnURL.Text = "网址链接";
			this.columnURL.Width = 270;
			this.columnParameter.Text = "Parameter";
			this.columnParameter.Width = 78;
			this.columnType.Text = "类型";
			this.columnType.Width = 59;
			this.columnKeyWord.Text = "关键词";
			this.columnKeyWord.Width = 130;
			this.columnVul.Text = "详细信息";
			this.columnVul.Width = 170;
			this.ImageListScanner.ImageStream = (ImageListStreamer)resources.GetObject("ImageListScanner.ImageStream");
			this.ImageListScanner.TransparentColor = Color.Transparent;
			this.ImageListScanner.Images.SetKeyName(0, "vul.png");
			this.toolStripScanner.BackColor = SystemColors.ButtonFace;
			this.toolStripScanner.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStripScanner.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripSeparator7,
				this.toolStripWVScan,
				this.toolStripSeparator1,
				this.toolStripURLScan,
				this.toolStripSeparator2,
				this.toolStripMultiScan,
				this.toolStripSeparator3,
				this.toolStripClearWVS,
				this.toolStripSeparator4,
				this.toolStripImpWVS,
				this.toolStripSeparator5,
				this.toolStripExpWVS,
				this.toolStripSeparator6
			});
			this.toolStripScanner.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStripScanner.Location = new Point(0, 0);
			this.toolStripScanner.Name = "toolStripScanner";
			this.toolStripScanner.Size = new Size(642, 25);
			this.toolStripScanner.TabIndex = 1;
			this.toolStripScanner.Text = "toolStrip1";
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new Size(6, 25);
			this.toolStripWVScan.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripWVScan.Image = (Image)resources.GetObject("toolStripWVScan.Image");
			this.toolStripWVScan.ImageTransparentColor = Color.Magenta;
			this.toolStripWVScan.Name = "toolStripWVScan";
			this.toolStripWVScan.Size = new Size(81, 22);
			this.toolStripWVScan.Text = "扫描当前站点";
			this.toolStripWVScan.Click += new EventHandler(this.toolStripWVScan_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(6, 25);
			this.toolStripURLScan.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripURLScan.Image = (Image)resources.GetObject("toolStripURLScan.Image");
			this.toolStripURLScan.ImageTransparentColor = Color.Magenta;
			this.toolStripURLScan.Name = "toolStripURLScan";
			this.toolStripURLScan.Size = new Size(75, 22);
			this.toolStripURLScan.Text = "扫描当前URL";
			this.toolStripURLScan.Click += new EventHandler(this.toolStripURLScan_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(6, 25);
			this.toolStripMultiScan.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripMultiScan.Image = (Image)resources.GetObject("toolStripMultiScan.Image");
			this.toolStripMultiScan.ImageTransparentColor = Color.Magenta;
			this.toolStripMultiScan.Name = "toolStripMultiScan";
			this.toolStripMultiScan.Size = new Size(99, 22);
			this.toolStripMultiScan.Text = "Scan Multi-Site";
			this.toolStripMultiScan.Click += new EventHandler(this.toolStripMultiScan_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(6, 25);
			this.toolStripClearWVS.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripClearWVS.Image = (Image)resources.GetObject("toolStripClearWVS.Image");
			this.toolStripClearWVS.ImageTransparentColor = Color.Magenta;
			this.toolStripClearWVS.Name = "toolStripClearWVS";
			this.toolStripClearWVS.Size = new Size(81, 22);
			this.toolStripClearWVS.Text = "重置或者清空";
			this.toolStripClearWVS.Click += new EventHandler(this.toolStripClearWVS_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new Size(6, 25);
			this.toolStripImpWVS.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripImpWVS.Image = (Image)resources.GetObject("toolStripImpWVS.Image");
			this.toolStripImpWVS.ImageTransparentColor = Color.Magenta;
			this.toolStripImpWVS.Name = "toolStripImpWVS";
			this.toolStripImpWVS.Size = new Size(33, 22);
			this.toolStripImpWVS.Text = "导入";
			this.toolStripImpWVS.Click += new EventHandler(this.toolStripImpWVS_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new Size(6, 25);
			this.toolStripExpWVS.DisplayStyle = ToolStripItemDisplayStyle.Text;
			this.toolStripExpWVS.Image = (Image)resources.GetObject("toolStripExpWVS.Image");
			this.toolStripExpWVS.ImageTransparentColor = Color.Magenta;
			this.toolStripExpWVS.Name = "toolStripExpWVS";
			this.toolStripExpWVS.Size = new Size(33, 22);
			this.toolStripExpWVS.Text = "导出";
			this.toolStripExpWVS.Click += new EventHandler(this.toolStripExpWVS_Click);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new Size(6, 25);
			this.statusScanner.Items.AddRange(new ToolStripItem[]
			{
				this.lblProgress,
				this.toolStripStatusLabel1,
				this.lblThreadNum
			});
			this.statusScanner.Location = new Point(0, 364);
			this.statusScanner.Name = "statusScanner";
			this.statusScanner.Size = new Size(642, 22);
			this.statusScanner.TabIndex = 2;
			this.statusScanner.Text = "statusStrip1";
			this.lblProgress.AutoSize = false;
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new Size(460, 17);
			this.lblProgress.Text = "Done";
			this.lblProgress.TextAlign = ContentAlignment.MiddleLeft;
			this.toolStripStatusLabel1.ForeColor = SystemColors.ButtonShadow;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new Size(11, 17);
			this.toolStripStatusLabel1.Text = "|";
			this.lblThreadNum.AutoSize = false;
			this.lblThreadNum.Name = "lblThreadNum";
			this.lblThreadNum.Size = new Size(125, 17);
			this.lblThreadNum.Text = "HTTP Thread:";
			this.lblThreadNum.TextAlign = ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(642, 386);
			base.Controls.Add(this.splitScanner);
			base.Controls.Add(this.toolStripScanner);
			base.Controls.Add(this.statusScanner);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (Icon)resources.GetObject("$this.Icon");
			base.Name = "FormScanner";
			this.Text = "FormScanner";
			base.Resize += new EventHandler(this.FormScanner_Resize);
			this.splitScanner.Panel1.ResumeLayout(false);
			this.splitScanner.Panel2.ResumeLayout(false);
			this.splitScanner.ResumeLayout(false);
			this.toolStripScanner.ResumeLayout(false);
			this.toolStripScanner.PerformLayout();
			this.statusScanner.ResumeLayout(false);
			this.statusScanner.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		private void InitSystemTimer()
		{
			this.ScannerTimer = new System.Timers.Timer();
			this.ScannerTimer.Interval = 2500.0;
			this.ScannerTimer.Elapsed += new ElapsedEventHandler(this.ScannerTimer_Elapsed);
			this.ScannerTimer.Enabled = true;
		}
		private bool IsWebPage(string sURL)
		{
			string fileExt = this.SiteA.GetFileExt(sURL);
			if (string.IsNullOrEmpty(fileExt))
			{
				return true;
			}
			fileExt = fileExt.Substring(1).ToLower();
			string[] strArray = WCRSetting.CrawlableExt.Split(new char[]
			{
				':'
			});
			for (int i = 0; i < strArray.Length; i++)
			{
				if (fileExt.Equals(strArray[i]))
				{
					return true;
				}
			}
			return false;
		}
		private void listViewWVS_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.listViewWVS.SelectedItems.Count >= 1)
			{
				ContextMenuStrip strip = new ContextMenuStrip();
				strip.Items.Add("Copy URL To ClipBoard", null, new EventHandler(this.WVSItemClick));
				string text = this.listViewWVS.SelectedItems[0].SubItems[4].Text;
				if (text.IndexOf("SQL INJECTION") >= 0)
				{
					strip.Items.Add("SQL INJECTION POC", null, new EventHandler(this.WVSItemClick));
				}
				else
				{
					if (text.IndexOf("XPath INJECTION") >= 0)
					{
						strip.Items.Add("XPath INJECTION POC", null, new EventHandler(this.WVSItemClick));
					}
					else
					{
						if (text.IndexOf("Cross Site Scripting(URL)") >= 0)
						{
							strip.Items.Add("Cross Site Scripting(URL) POC", null, new EventHandler(this.WVSItemClick));
						}
						else
						{
							if (text.IndexOf("Cross Site Scripting(Form)") >= 0)
							{
								strip.Items.Add("Cross Site Scripting(Form) POC", null, new EventHandler(this.WVSItemClick));
							}
						}
					}
				}
				strip.Items.Add("Delete Vulnerability", null, new EventHandler(this.WVSItemClick));
				this.listViewWVS.ContextMenuStrip = strip;
			}
		}
		public void LoadFromXmlDocument(XmlDocument WVSXml)
		{
			foreach (XmlNode node in WVSXml.SelectNodes("//ROOT/SiteDirTree/DIR"))
			{
				TreeNode parentTn = this.treeViewWVS.Nodes.Add(node.Attributes["Value"].Value);
				if (node.ChildNodes.Count > 0)
				{
					this.XmlNode2TreeNode(node, parentTn);
				}
			}
			this.treeViewWVS.ExpandAll();
			XmlNodeList list2 = WVSXml.SelectNodes("//ROOT/SiteVulList/VulRow");
			this.listViewWVS.Items.Clear();
			foreach (XmlNode node2 in list2)
			{
				ListViewItem item = new ListViewItem(node2.ChildNodes[0].InnerText);
				item.SubItems.Add(node2.ChildNodes[1].InnerText);
				item.SubItems.Add(node2.ChildNodes[2].InnerText);
				item.SubItems.Add(node2.ChildNodes[3].InnerText);
				item.SubItems.Add(node2.ChildNodes[4].InnerText);
				item.ImageKey = "vul.png";
				this.listViewWVS.Items.Add(item);
			}
		}
		public void ScanCurrentSite()
		{
			this.SiteA.URL = this.mainfrm.URL;
			if (string.IsNullOrEmpty(this.SiteA.URL))
			{
				MessageBox.Show("请输入网址!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.mainfrm.URLTextBoxFocus();
				return;
			}
			if (MessageBox.Show("确定要扫描吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
			{
				this.BeginSiteScan();
			}
		}
		public void ScanCurrentURL()
		{
			if (string.IsNullOrEmpty(this.SiteA.URL))
			{
				MessageBox.Show("请输入网址!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.mainfrm.URLTextBoxFocus();
				return;
			}
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckVulnerability), this.SiteA.URL);
			this.DisplayProgress("正在扫描。。。");
			MessageBox.Show("扫描即将开始，请确认？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		public void Scan_cmsshibie(object url)
		{
			string my_scanUrl = "http://" + url;
			iiswrite iisexp = new iiswrite();
			try
			{
				string iisjieguo = iisexp.exp(my_scanUrl);
				if (iisjieguo != "不存在安全漏洞")
				{
					ListViewItem item = new ListViewItem(my_scanUrl);
					item.SubItems.Add("发现漏洞cms识别");
					item.SubItems.Add("iis写漏洞测试");
					item.SubItems.Add("发现IIS写漏洞权限");
					item.SubItems.Add(iisjieguo);
					item.ImageKey = "vul.png";
					this.listViewWVS.Items.Add(item);
				}
			}
			catch
			{
			}
			StreamReader srReader = new StreamReader("cms.txt", Encoding.GetEncoding("GB2312"));
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
						WebReqScan.UserAgent = "User-Agent\tBaiduspider";
						HttpWebResponse WebRepScan = (HttpWebResponse)WebReqScan.GetResponse();
						WebReqScan.Abort();
						WebRepScan.Close();
						if (WebRepScan.StatusCode != HttpStatusCode.NotFound && my_scanUrl + sArray[0].ToString() == WebRepScan.ResponseUri.ToString())
						{
							string urlvb = my_scanUrl + sArray[0].ToString();
							WebClient aa = new WebClient();
							aa.Headers.Add("User-Agent", "Baiduspider");
							string sss = aa.DownloadString(urlvb);
							string shuju = FormScanner.GetMD5HashHex(sss);
							FormScanner.GetMD5Hash(sss);
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
										ListViewItem item2 = new ListViewItem(my_scanUrl);
										item2.SubItems.Add("发现漏洞cms识别");
										item2.SubItems.Add(sArray[1].ToString());
										item2.SubItems.Add("cms识别");
										item2.SubItems.Add(exp);
										item2.ImageKey = "vul.png";
										string baohan = "0";
										for (int i9 = 0; i9 < this.listViewWVS.Items.Count; i9++)
										{
											string aaa = this.listViewWVS.Items[i9].SubItems[1].Text;
											if (aaa == WebRepScan.ResponseUri.ToString())
											{
												baohan = "1";
											}
										}
										if (baohan == "0" && !this.listViewWVS.Items.Contains(item2))
										{
											this.listViewWVS.Items.Add(item2);
										}
										break;
									}
									if (sArray[1].ToString() == "southidc")
									{
										southidc decms2 = new southidc();
										string exp2 = decms2.exp(my_scanUrl);
										ListViewItem item3 = new ListViewItem(my_scanUrl);
										item3.SubItems.Add("发现漏洞cms识别");
										item3.SubItems.Add(sArray[1].ToString());
										item3.SubItems.Add("cms识别");
										item3.SubItems.Add(exp2);
										item3.ImageKey = "vul.png";
										string baohan2 = "0";
										for (int i10 = 0; i10 < this.listViewWVS.Items.Count; i10++)
										{
											string aaa2 = this.listViewWVS.Items[i10].SubItems[1].Text;
											if (aaa2 == WebRepScan.ResponseUri.ToString())
											{
												baohan2 = "1";
											}
										}
										if (baohan2 == "0" && !this.listViewWVS.Items.Contains(item3))
										{
											this.listViewWVS.Items.Add(item3);
										}
										break;
									}
									if (sArray[1].ToString() == "w78cms")
									{
										w78cms decms3 = new w78cms();
										string exp3 = decms3.exp(my_scanUrl);
										ListViewItem item4 = new ListViewItem(my_scanUrl);
										item4.SubItems.Add("发现漏洞cms识别");
										item4.SubItems.Add(sArray[1].ToString());
										item4.SubItems.Add("cms识别");
										item4.SubItems.Add(exp3);
										item4.ImageKey = "vul.png";
										string baohan3 = "0";
										for (int i11 = 0; i11 < this.listViewWVS.Items.Count; i11++)
										{
											string aaa3 = this.listViewWVS.Items[i11].SubItems[1].Text;
											if (aaa3 == WebRepScan.ResponseUri.ToString())
											{
												baohan3 = "1";
											}
										}
										if (baohan3 == "0" && !this.listViewWVS.Items.Contains(item4))
										{
											this.listViewWVS.Items.Add(item4);
										}
										break;
									}
									if (sArray[1].ToString() == "B2Bbuilder")
									{
										B2Bbuilder decms4 = new B2Bbuilder();
										string exp4 = decms4.exp(my_scanUrl);
										ListViewItem item5 = new ListViewItem(my_scanUrl);
										item5.SubItems.Add("发现漏洞cms识别");
										item5.SubItems.Add(sArray[1].ToString());
										item5.SubItems.Add("cms识别");
										item5.SubItems.Add(exp4);
										item5.ImageKey = "vul.png";
										string baohan4 = "0";
										for (int i12 = 0; i12 < this.listViewWVS.Items.Count; i12++)
										{
											string aaa4 = this.listViewWVS.Items[i12].SubItems[1].Text;
											if (aaa4 == WebRepScan.ResponseUri.ToString())
											{
												baohan4 = "1";
											}
										}
										if (baohan4 == "0" && !this.listViewWVS.Items.Contains(item5))
										{
											this.listViewWVS.Items.Add(item5);
										}
										break;
									}
									if (sArray[1].ToString() == "5ucms")
									{
										u5ucms decms5 = new u5ucms();
										string exp5 = decms5.exp(my_scanUrl);
										ListViewItem item6 = new ListViewItem(my_scanUrl);
										item6.SubItems.Add("发现漏洞cms识别");
										item6.SubItems.Add(sArray[1].ToString());
										item6.SubItems.Add("cms识别");
										item6.SubItems.Add(exp5);
										item6.ImageKey = "vul.png";
										string baohan5 = "0";
										for (int i13 = 0; i13 < this.listViewWVS.Items.Count; i13++)
										{
											string aaa5 = this.listViewWVS.Items[i13].SubItems[1].Text;
											if (aaa5 == WebRepScan.ResponseUri.ToString())
											{
												baohan5 = "1";
											}
										}
										if (baohan5 == "0" && !this.listViewWVS.Items.Contains(item6))
										{
											this.listViewWVS.Items.Add(item6);
										}
										break;
									}
									if (sArray[1].ToString() == "phpcmsv9")
									{
										phpcms decms6 = new phpcms();
										string exp6 = decms6.exp(my_scanUrl);
										ListViewItem item7 = new ListViewItem(my_scanUrl);
										item7.SubItems.Add("发现漏洞cms识别");
										item7.SubItems.Add(sArray[1].ToString());
										item7.SubItems.Add("cms识别");
										item7.SubItems.Add(exp6);
										item7.ImageKey = "vul.png";
										string baohan6 = "0";
										for (int i14 = 0; i14 < this.listViewWVS.Items.Count; i14++)
										{
											string aaa6 = this.listViewWVS.Items[i14].SubItems[1].Text;
											if (aaa6 == WebRepScan.ResponseUri.ToString())
											{
												baohan6 = "1";
											}
										}
										if (baohan6 == "0" && !this.listViewWVS.Items.Contains(item7))
										{
											this.listViewWVS.Items.Add(item7);
										}
										break;
									}
									if (sArray[1].ToString() == "cmseasy")
									{
										cmseasy decms7 = new cmseasy();
										string exp7 = decms7.exp(my_scanUrl);
										ListViewItem item8 = new ListViewItem(my_scanUrl);
										item8.SubItems.Add("发现漏洞cms识别");
										item8.SubItems.Add(sArray[1].ToString());
										item8.SubItems.Add("cms识别");
										item8.SubItems.Add(exp7);
										item8.ImageKey = "vul.png";
										string baohan7 = "0";
										for (int i15 = 0; i15 < this.listViewWVS.Items.Count; i15++)
										{
											string aaa7 = this.listViewWVS.Items[i15].SubItems[1].Text;
											if (aaa7 == WebRepScan.ResponseUri.ToString())
											{
												baohan7 = "1";
											}
										}
										if (baohan7 == "0" && !this.listViewWVS.Items.Contains(item8))
										{
											this.listViewWVS.Items.Add(item8);
										}
										break;
									}
									if (sArray[1].ToString() == "Easytuan")
									{
										Easytuan decms8 = new Easytuan();
										string exp8 = decms8.exp(my_scanUrl);
										ListViewItem item9 = new ListViewItem(my_scanUrl);
										item9.SubItems.Add("发现漏洞cms识别");
										item9.SubItems.Add(sArray[1].ToString());
										item9.SubItems.Add("cms识别");
										item9.SubItems.Add(exp8);
										item9.ImageKey = "vul.png";
										string baohan8 = "0";
										for (int i16 = 0; i16 < this.listViewWVS.Items.Count; i16++)
										{
											string aaa8 = this.listViewWVS.Items[i16].SubItems[1].Text;
											if (aaa8 == WebRepScan.ResponseUri.ToString())
											{
												baohan8 = "1";
											}
										}
										if (baohan8 == "0" && !this.listViewWVS.Items.Contains(item9))
										{
											this.listViewWVS.Items.Add(item9);
										}
										break;
									}
									if (sArray[1].ToString() == "phpweb")
									{
										phpweb decms9 = new phpweb();
										string exp9 = decms9.exp(my_scanUrl);
										ListViewItem item10 = new ListViewItem(my_scanUrl);
										item10.SubItems.Add("发现漏洞cms识别");
										item10.SubItems.Add(sArray[1].ToString());
										item10.SubItems.Add("cms识别");
										item10.SubItems.Add(exp9);
										item10.ImageKey = "vul.png";
										string baohan9 = "0";
										for (int i17 = 0; i17 < this.listViewWVS.Items.Count; i17++)
										{
											string aaa9 = this.listViewWVS.Items[i17].SubItems[1].Text;
											if (aaa9 == WebRepScan.ResponseUri.ToString())
											{
												baohan9 = "1";
											}
										}
										if (baohan9 == "0" && !this.listViewWVS.Items.Contains(item10))
										{
											this.listViewWVS.Items.Add(item10);
										}
										break;
									}
									if (sArray[1].ToString() == "shopxp")
									{
										shopxp decms10 = new shopxp();
										string exp10 = decms10.shuju(my_scanUrl);
										ListViewItem item11 = new ListViewItem(my_scanUrl);
										item11.SubItems.Add("发现漏洞cms识别");
										item11.SubItems.Add(sArray[1].ToString());
										item11.SubItems.Add("cms识别");
										item11.SubItems.Add(exp10);
										item11.ImageKey = "vul.png";
										string baohan10 = "0";
										for (int i18 = 0; i18 < this.listViewWVS.Items.Count; i18++)
										{
											string aaa10 = this.listViewWVS.Items[i18].SubItems[1].Text;
											if (aaa10 == WebRepScan.ResponseUri.ToString())
											{
												baohan10 = "1";
											}
										}
										if (baohan10 == "0" && !this.listViewWVS.Items.Contains(item11))
										{
											this.listViewWVS.Items.Add(item11);
										}
										break;
									}
									if (sArray[1].ToString() == "Discuz")
									{
										discuz decms11 = new discuz();
										string exp11 = decms11.exp(my_scanUrl);
										ListViewItem item12 = new ListViewItem(my_scanUrl);
										item12.SubItems.Add("发现漏洞cms识别");
										item12.SubItems.Add(sArray[1].ToString());
										item12.SubItems.Add("cms识别");
										item12.SubItems.Add(exp11);
										item12.ImageKey = "vul.png";
										string baohan11 = "0";
										for (int i19 = 0; i19 < this.listViewWVS.Items.Count; i19++)
										{
											string aaa11 = this.listViewWVS.Items[i19].SubItems[1].Text;
											if (aaa11 == WebRepScan.ResponseUri.ToString())
											{
												baohan11 = "1";
											}
										}
										if (baohan11 == "0" && !this.listViewWVS.Items.Contains(item12))
										{
											this.listViewWVS.Items.Add(item12);
										}
										break;
									}
									if (sArray[1].ToString() == "akcms")
									{
										akcms decms12 = new akcms();
										string exp12 = decms12.exp(my_scanUrl);
										ListViewItem item13 = new ListViewItem(my_scanUrl);
										item13.SubItems.Add("发现漏洞cms识别");
										item13.SubItems.Add(sArray[1].ToString());
										item13.SubItems.Add("cms识别");
										item13.SubItems.Add(exp12);
										item13.ImageKey = "vul.png";
										string baohan12 = "0";
										for (int i20 = 0; i20 < this.listViewWVS.Items.Count; i20++)
										{
											string aaa12 = this.listViewWVS.Items[i20].SubItems[1].Text;
											if (aaa12 == WebRepScan.ResponseUri.ToString())
											{
												baohan12 = "1";
											}
										}
										if (baohan12 == "0" && !this.listViewWVS.Items.Contains(item13))
										{
											this.listViewWVS.Items.Add(item13);
										}
										break;
									}
									if (sArray[1].ToString() == "espcms")
									{
										espcms decms13 = new espcms();
										string exp13 = decms13.exp(my_scanUrl);
										ListViewItem item14 = new ListViewItem(my_scanUrl);
										item14.SubItems.Add("发现漏洞cms识别");
										item14.SubItems.Add(sArray[1].ToString());
										item14.SubItems.Add("cms识别");
										item14.SubItems.Add(exp13);
										item14.ImageKey = "vul.png";
										string baohan13 = "0";
										for (int i21 = 0; i21 < this.listViewWVS.Items.Count; i21++)
										{
											string aaa13 = this.listViewWVS.Items[i21].SubItems[1].Text;
											if (aaa13 == WebRepScan.ResponseUri.ToString())
											{
												baohan13 = "1";
											}
										}
										if (baohan13 == "0" && !this.listViewWVS.Items.Contains(item14))
										{
											this.listViewWVS.Items.Add(item14);
										}
										break;
									}
									if (sArray[1].ToString() == "shopex")
									{
										shopex decms14 = new shopex();
										string exp14 = decms14.exp(my_scanUrl);
										ListViewItem item15 = new ListViewItem(my_scanUrl);
										item15.SubItems.Add("发现漏洞cms识别");
										item15.SubItems.Add(sArray[1].ToString());
										item15.SubItems.Add("cms识别");
										item15.SubItems.Add(exp14);
										item15.ImageKey = "vul.png";
										string baohan14 = "0";
										for (int i22 = 0; i22 < this.listViewWVS.Items.Count; i22++)
										{
											string aaa14 = this.listViewWVS.Items[i22].SubItems[1].Text;
											if (aaa14 == WebRepScan.ResponseUri.ToString())
											{
												baohan14 = "1";
											}
										}
										if (baohan14 == "0" && !this.listViewWVS.Items.Contains(item15))
										{
											this.listViewWVS.Items.Add(item15);
										}
										break;
									}
									if (sArray[1].ToString() == "aspcms")
									{
										aspcms decms15 = new aspcms();
										string exp15 = decms15.exp(my_scanUrl);
										ListViewItem item16 = new ListViewItem(my_scanUrl);
										item16.SubItems.Add("发现漏洞cms识别");
										item16.SubItems.Add(sArray[1].ToString());
										item16.SubItems.Add("cms识别");
										item16.SubItems.Add(exp15);
										item16.ImageKey = "vul.png";
										string baohan15 = "0";
										for (int i23 = 0; i23 < this.listViewWVS.Items.Count; i23++)
										{
											string aaa15 = this.listViewWVS.Items[i23].SubItems[1].Text;
											if (aaa15 == WebRepScan.ResponseUri.ToString())
											{
												baohan15 = "1";
											}
										}
										if (baohan15 == "0" && !this.listViewWVS.Items.Contains(item16))
										{
											this.listViewWVS.Items.Add(item16);
										}
										break;
									}
									if (sArray[1].ToString() == "zhuangxiu")
									{
										zhuangxiu decms16 = new zhuangxiu();
										string exp16 = decms16.exp(my_scanUrl);
										ListViewItem item17 = new ListViewItem(my_scanUrl);
										item17.SubItems.Add("发现漏洞cms识别");
										item17.SubItems.Add(sArray[1].ToString());
										item17.SubItems.Add("cms识别");
										item17.SubItems.Add(exp16);
										item17.ImageKey = "vul.png";
										string baohan16 = "0";
										for (int i24 = 0; i24 < this.listViewWVS.Items.Count; i24++)
										{
											string aaa16 = this.listViewWVS.Items[i24].SubItems[1].Text;
											if (aaa16 == WebRepScan.ResponseUri.ToString())
											{
												baohan16 = "1";
											}
										}
										if (baohan16 == "0" && !this.listViewWVS.Items.Contains(item17))
										{
											this.listViewWVS.Items.Add(item17);
										}
										break;
									}
									if (sArray[1].ToString() == "良精南方")
									{
										ljnanfang decms17 = new ljnanfang();
										string exp17 = decms17.exp(my_scanUrl);
										ListViewItem item18 = new ListViewItem(my_scanUrl);
										item18.SubItems.Add("发现漏洞cms识别");
										item18.SubItems.Add(sArray[1].ToString());
										item18.SubItems.Add("cms识别");
										item18.SubItems.Add(exp17);
										item18.ImageKey = "vul.png";
										string baohan17 = "0";
										for (int i25 = 0; i25 < this.listViewWVS.Items.Count; i25++)
										{
											string aaa17 = this.listViewWVS.Items[i25].SubItems[1].Text;
											if (aaa17 == WebRepScan.ResponseUri.ToString())
											{
												baohan17 = "1";
											}
										}
										if (baohan17 == "0" && !this.listViewWVS.Items.Contains(item18))
										{
											this.listViewWVS.Items.Add(item18);
										}
										break;
									}
									if (sArray[1].ToString() == "ecshop")
									{
										ecshop decms18 = new ecshop();
										string exp18 = decms18.exp(my_scanUrl);
										ListViewItem item19 = new ListViewItem(my_scanUrl);
										item19.SubItems.Add("发现漏洞cms识别");
										item19.SubItems.Add(sArray[1].ToString());
										item19.SubItems.Add("cms识别");
										item19.SubItems.Add(exp18);
										item19.ImageKey = "vul.png";
										string baohan18 = "0";
										for (int i26 = 0; i26 < this.listViewWVS.Items.Count; i26++)
										{
											string aaa18 = this.listViewWVS.Items[i26].SubItems[1].Text;
											if (aaa18 == WebRepScan.ResponseUri.ToString())
											{
												baohan18 = "1";
											}
										}
										if (baohan18 == "0" && !this.listViewWVS.Items.Contains(item19))
										{
											this.listViewWVS.Items.Add(item19);
										}
										break;
									}
									if (sArray[1].ToString() == "kesioncms")
									{
										kessionms decms19 = new kessionms();
										string exp19 = decms19.exp(my_scanUrl);
										ListViewItem item20 = new ListViewItem(my_scanUrl);
										item20.SubItems.Add("发现漏洞cms识别");
										item20.SubItems.Add(sArray[1].ToString());
										item20.SubItems.Add("cms识别");
										item20.SubItems.Add(exp19);
										item20.ImageKey = "vul.png";
										string baohan19 = "0";
										for (int i27 = 0; i27 < this.listViewWVS.Items.Count; i27++)
										{
											string aaa19 = this.listViewWVS.Items[i27].SubItems[1].Text;
											if (aaa19 == WebRepScan.ResponseUri.ToString())
											{
												baohan19 = "1";
											}
										}
										if (baohan19 == "0" && !this.listViewWVS.Items.Contains(item20))
										{
											this.listViewWVS.Items.Add(item20);
										}
										break;
									}
									ListViewItem item21 = new ListViewItem(my_scanUrl);
									item21.SubItems.Add("发现漏洞cms识别");
									item21.SubItems.Add(sArray[1].ToString());
									item21.SubItems.Add("cms");
									item21.SubItems.Add("网站未做安全隐患检测");
									item21.ImageKey = "vul.png";
									string baohan20 = "0";
									for (int i28 = 0; i28 < this.listViewWVS.Items.Count; i28++)
									{
										string aaa20 = this.listViewWVS.Items[i28].SubItems[1].Text;
										if (aaa20 == WebRepScan.ResponseUri.ToString())
										{
											baohan20 = "1";
										}
									}
									if (baohan20 == "0" && !this.listViewWVS.Items.Contains(item21))
									{
										this.listViewWVS.Items.Add(item21);
									}
									break;
								}
							}
							if (sArray[3].ToString() != "" && sss.IndexOf(sArray[3].ToString(), StringComparison.CurrentCultureIgnoreCase) > 0)
							{
								ListViewItem item22 = new ListViewItem(my_scanUrl);
								item22.SubItems.Add("发现漏洞cms识别");
								item22.SubItems.Add(sArray[1].ToString());
								item22.SubItems.Add("cms");
								item22.SubItems.Add("网站未做安全隐患检测");
								item22.ImageKey = "vul.png";
								string baohan21 = "0";
								for (int i29 = 0; i29 < this.listViewWVS.Items.Count; i29++)
								{
									string aaa21 = this.listViewWVS.Items[i29].SubItems[1].Text;
									if (aaa21 == WebRepScan.ResponseUri.ToString())
									{
										baohan21 = "1";
									}
								}
								if (baohan21 == "0" && !this.listViewWVS.Items.Contains(item22))
								{
									this.listViewWVS.Items.Add(item22);
								}
							}
						}
					}
				}
				catch
				{
				}
			}
		}
		private void ScannerTimer_Elapsed(object sender, EventArgs e)
		{
			this.ScanningTimerTask();
		}
		private void ScanningTimerTask()
		{
			this.DisplayThreadNum("HTTP Thread: " + this.SiteA.HTTPThreadNum.ToString());
			DateTime now = DateTime.Now;
			TimeSpan span = now.Subtract(WebSite.StopTime);
			span = now.Subtract(this.SiteA.LastGetTime);
			if (span.Seconds > 20 && this.SiteA.HTTPThreadNum == 0)
			{
				this.DisplayProgress("Done");
			}
			if (span.Seconds > 30 && this.SiteA.HTTPThreadNum > 0)
			{
				this.SiteA.HTTPThreadNum = 0;
			}
		}
		private void SiteTreeItemClick(object sender, EventArgs e)
		{
			try
			{
				string str;
				if ((str = ((ToolStripMenuItem)sender).Text) != null && str == "Copy To ClipBoard")
				{
					Clipboard.SetText(this.treeViewWVS.SelectedNode.Text);
				}
			}
			catch
			{
			}
		}
		private void toolStripClearWVS_Click(object sender, EventArgs e)
		{
			this.treeViewWVS.Nodes.Clear();
			this.listViewWVS.Items.Clear();
			this.SiteA.ClearWVS();
		}
		private void toolStripExpWVS_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listViewWVS.Items.Count >= 1)
				{
					string wVSXmlFileName = this.SiteA.DomainHost + "_Vuls_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
					SaveFileDialog dialog = new SaveFileDialog
					{
						Filter = "XML File(*.xml) | *.xml",
						InitialDirectory = Application.StartupPath,
						FileName = wVSXmlFileName
					};
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						wVSXmlFileName = dialog.FileName;
						dialog.Dispose();
						this.ExportWVS(wVSXmlFileName);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
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
		private void toolStripImpWVS_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.listViewWVS.Items.Count > 0)
				{
					if (MessageBox.Show("* Import Vuls Will Clear Current Vuls Information.\r\n* Continue?\r\n", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
					{
						return;
					}
					this.listViewWVS.Items.Clear();
				}
				OpenFileDialog dialog = new OpenFileDialog
				{
					Filter = "XML File(*.xml)|*.xml",
					InitialDirectory = Application.StartupPath
				};
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					string fileName = dialog.FileName;
					dialog.Dispose();
					if (!string.IsNullOrEmpty(fileName))
					{
						XmlDocument wVSXml = new XmlDocument();
						wVSXml.Load(fileName);
						this.LoadFromXmlDocument(wVSXml);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void toolStripMultiScan_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("* Software Disclaimer: \r\n* Authorization must be obtained from the web application owner;\r\n* This program will try to get each link and post any data when scanning;\r\n* Backup the database before scanning so as to avoid disaster;\r\n* Using this software at your own risk. \r\n\r\n* Multi-Site scanning will read the sites list from a text file.\r\n* Continue?\r\n", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.Cancel)
				{
					OpenFileDialog dialog = new OpenFileDialog
					{
						Filter = "Text File(*.txt)|*.txt",
						FileName = "SiteList.txt",
						InitialDirectory = Application.StartupPath
					};
					if (dialog.ShowDialog() == DialogResult.OK)
					{
						string fileName = dialog.FileName;
						dialog.Dispose();
						StreamReader reader = new StreamReader(fileName);
						string str3 = "";
						string str4;
						while ((str4 = reader.ReadLine()) != null)
						{
							if (!string.IsNullOrEmpty(str4))
							{
								if (string.IsNullOrEmpty(str3))
								{
									str3 += str4;
								}
								else
								{
									str3 = str3 + "^^" + str4;
								}
							}
						}
						reader.Close();
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.AutoSiteScanControl), str3);
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}
		private void toolStripURLScan_Click(object sender, EventArgs e)
		{
			this.ScanCurrentURL();
		}
		private void toolStripWVScan_Click(object sender, EventArgs e)
		{
			this.ScanCurrentSite();
		}
		private void TreeNode2URLS(string Path, TreeNode tn)
		{
			if (WebSite.CurrentStatus != TaskStatus.Stop)
			{
				if (tn.Nodes.Count == 0)
				{
					string sURL = Path + tn.Text;
					if (this.IsWebPage(sURL))
					{
						this.TreeNodeURL.Add(Path + tn.Text);
						return;
					}
				}
				else
				{
					this.TreeNodeURL.Add(Path + tn.Text + "/");
					foreach (TreeNode node in tn.Nodes)
					{
						this.TreeNode2URLS(Path + tn.Text + "/", node);
					}
				}
			}
		}
		private XmlDocument TreeNode2XmlElement(XmlDocument WVSXml, XmlElement ParentElem, TreeNode tn)
		{
			XmlElement parentElem = WVSXml.CreateElement("DIR");
			parentElem.SetAttribute("Value", tn.Text);
			foreach (TreeNode node in tn.Nodes)
			{
				WVSXml = this.TreeNode2XmlElement(WVSXml, parentElem, node);
			}
			ParentElem.AppendChild(parentElem);
			return WVSXml;
		}
		private void treeViewWVS_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Point pt = new Point(e.X, e.Y);
			TreeNode nodeAt = this.treeViewWVS.GetNodeAt(pt);
			this.treeViewWVS.SelectedNode = nodeAt;
			ContextMenuStrip strip = new ContextMenuStrip();
			strip.Items.Add("Copy To ClipBoard", null, new EventHandler(this.SiteTreeItemClick));
			this.treeViewWVS.ContextMenuStrip = strip;
		}
		private void WVSItemClick(object sender, EventArgs e)
		{
			try
			{
				string text = this.listViewWVS.SelectedItems[0].SubItems[1].Text;
				string str2 = this.listViewWVS.SelectedItems[0].SubItems[4].Text;
				string str3 = ((ToolStripMenuItem)sender).Text;
				if (str3 != null)
				{
					if (!(str3 == "SQL INJECTION POC"))
					{
						if (!(str3 == "Copy URL To ClipBoard"))
						{
							if (!(str3 == "Delete Vulnerability"))
							{
								if (!(str3 == "XPath INJECTION POC"))
								{
									if (!(str3 == "Cross Site Scripting(URL) POC"))
									{
										if (!(str3 == "Cross Site Scripting(Form) POC"))
										{
											goto IL_246;
										}
									}
									string str4 = this.listViewWVS.SelectedItems[0].Text;
									string actionURL = this.listViewWVS.SelectedItems[0].SubItems[3].Text;
									this.mainfrm.XSSPOC(str4, actionURL);
									this.mainfrm.SelectTool("XSS");
								}
								else
								{
									string str5 = this.listViewWVS.SelectedItems[0].SubItems[3].Text;
									string refURL = this.listViewWVS.SelectedItems[0].Text;
									this.mainfrm.SelectTool("WebBrowser");
									this.mainfrm.XPathPOC(refURL, str5, text);
								}
							}
							else
							{
								this.listViewWVS.SelectedItems[0].Remove();
							}
						}
						else
						{
							Clipboard.SetText(this.listViewWVS.SelectedItems[0].Text);
						}
					}
					else
					{
						string expression = this.listViewWVS.SelectedItems[0].Text;
						if (expression.IndexOf('^') > 0)
						{
							string[] paraNameValue = WebSite.GetParaNameValue(expression, '^');
							expression = paraNameValue[0];
							this.mainfrm.UpdateSubmitData(paraNameValue[1]);
							if (str2.IndexOf("POST") >= 0)
							{
								this.mainfrm.ReqType = RequestType.POST;
							}
							else
							{
								if (str2.IndexOf("COOKIE") >= 0)
								{
									this.mainfrm.ReqType = RequestType.COOKIE;
								}
							}
						}
						else
						{
							this.mainfrm.ReqType = RequestType.GET;
						}
						this.mainfrm.URL = expression;
						string str6 = this.listViewWVS.SelectedItems[0].SubItems[2].Text;
						if (str6.Equals("Integer"))
						{
							this.SiteA.InjType = InjectionType.Integer;
							this.mainfrm.InitByInjectionType(InjectionType.Integer, expression);
						}
						else
						{
							if (str6.Equals("String"))
							{
								this.SiteA.InjType = InjectionType.String;
								this.mainfrm.InitByInjectionType(InjectionType.String, expression);
							}
							else
							{
								if (str6.Equals("Search"))
								{
									this.SiteA.InjType = InjectionType.Search;
									this.mainfrm.InitByInjectionType(InjectionType.Search, expression);
								}
							}
						}
						this.SiteA.CurrentKeyWord = this.listViewWVS.SelectedItems[0].SubItems[3].Text;
						this.mainfrm.UpdateKeyWordText(this.SiteA.CurrentKeyWord);
						this.mainfrm.SelectTool("SQL");
					}
				}
				IL_246:;
			}
			catch
			{
			}
		}
		private void XmlNode2TreeNode(XmlNode dir, TreeNode ParentTn)
		{
			foreach (XmlNode node in dir.ChildNodes)
			{
				TreeNode parentTn = ParentTn.Nodes.Add(node.Attributes["Value"].Value);
				if (node.ChildNodes.Count > 0)
				{
					this.XmlNode2TreeNode(node, parentTn);
				}
			}
		}
	}
}

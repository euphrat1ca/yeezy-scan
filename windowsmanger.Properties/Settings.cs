using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace windowsmanger.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"), CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}
		[DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
		public string HoutaiIsStop
		{
			get
			{
				return (string)this["HoutaiIsStop"];
			}
			set
			{
				this["HoutaiIsStop"] = value;
			}
		}
		[DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
		public string CmsIsStop
		{
			get
			{
				return (string)this["CmsIsStop"];
			}
			set
			{
				this["CmsIsStop"] = value;
			}
		}
		[DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
		public string HoutaiScan
		{
			get
			{
				return (string)this["HoutaiScan"];
			}
			set
			{
				this["HoutaiScan"] = value;
			}
		}
		[DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
		public string Houtaijiaoben
		{
			get
			{
				return (string)this["Houtaijiaoben"];
			}
			set
			{
				this["Houtaijiaoben"] = value;
			}
		}
		[DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
		public string CduanIsStop
		{
			get
			{
				return (string)this["CduanIsStop"];
			}
			set
			{
				this["CduanIsStop"] = value;
			}
		}
		[DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
		public string yeshucode
		{
			get
			{
				return (string)this["yeshucode"];
			}
			set
			{
				this["yeshucode"] = value;
			}
		}
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
namespace Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;
		private static CultureInfo resourceCulture;
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager temp = new ResourceManager("Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}
		internal static Bitmap Image_10
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_10", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_2
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_2", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_21
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_21", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_22
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_22", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_23
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_23", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_3
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_3", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_5
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_5", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal static Bitmap Image_6
		{
			get
			{
				object obj = Resources.ResourceManager.GetObject("Image_6", Resources.resourceCulture);
				return (Bitmap)obj;
			}
		}
		internal Resources()
		{
		}
	}
}

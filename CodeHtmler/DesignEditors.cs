/*
 * Author: Wes Haggard
 * Weblog: http://weblogs.asp.net/whaggard/
 * 
 * This project is an open source project and the code can be used and distrubed freely. 
 * All I ask in return is that credit is given where credit is due.
 * 
 * Copyright © 2003-2004, Wes Haggard. All rights reserved. No warranties extended
 * 
 */
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace CodeHtmler
{
	/// <summary>
	/// This class allows for the Languages object in a property grid to contain a collection of
	/// Language objects.
	/// </summary>
	public class LanguageCollectionEditor : CollectionEditor
	{
		public LanguageCollectionEditor() 
			: base (typeof(ArrayList)) { }
		protected override object CreateInstance(System.Type itemType)
		{
			return new Language();
		}
		protected override System.Type CreateCollectionItemType()
		{
			return typeof(Language);
		}
	}
	/// <summary>
	/// This class allows for the a Language object in a property grid to contain a collection of
	/// CodeElement objects.
	/// </summary>
	public class CodeElementCollectionEditor : CollectionEditor
	{
		public CodeElementCollectionEditor() 
			: base (typeof(ArrayList)) { }
		protected override object CreateInstance(System.Type itemType)
		{
			return new CodeElement();
		}
		protected override System.Type CreateCollectionItemType()
		{
			return typeof(CodeElement);
		}
	}
	/// <summary>
	/// This class allows for the color string property to use the Color Editor to select the color
	/// but still keep the string as a html color string.
	/// </summary>
	public class HtmlColorEditor : System.Drawing.Design.ColorEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object val)
		{
			if(val != null)
				val = ColorTranslator.FromHtml(val.ToString());

			object result = base.EditValue(context, provider, val);

			if(result is Color)
				return ColorTranslator.ToHtml((Color)result);
		
			return result;
		}
		public override void PaintValue(PaintValueEventArgs e)
		{			
			if(e.Value != null)
			{
				Color c = Color.Empty;
				if(e.Value is Color)
					c = (Color)e.Value;
				else
				{
					try
					{
						c = ColorTranslator.FromHtml(e.Value.ToString());
					}
					catch {}
				}

				using(SolidBrush brush = new SolidBrush(c))
				{
					e.Graphics.FillRectangle(brush, e.Bounds);
				}
			}
		}
	}
}

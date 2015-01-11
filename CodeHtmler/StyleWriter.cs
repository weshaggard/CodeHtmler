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
using System.Text;

namespace CodeHtmler
{
	public enum StyleType
	{
		InlineStyles,
		InlineTags,
		GlobalStyles
	}
	/// <summary>
	/// This is class that contains a factory method to create a style writer
	/// based on the style type.
	/// </summary>
	public sealed class StyleFactory
	{
		private StyleFactory() { }
		/// <summary>
		/// This method will return the appropraite style writer based on the style type.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static IStyleWriter Create(StyleType type)
		{
			switch(type)
			{
				case StyleType.GlobalStyles:
					return new GlobalStyleWriter();
				case StyleType.InlineStyles:
					return new InlineStyleWriter();
				case StyleType.InlineTags:
					return new InlineTagsWriter();
			}
			throw new ArgumentException("StyleType not defined", "StyleType");
		}

	}
	public interface IStyleWriter
	{
		string GetStyledElement(string match, CodeElement codeElement);
	}

	public class GlobalStyleWriter : IStyleWriter
	{
		#region IStyleWriter Members

		/// <summary>
		/// This will simply output a span tag with a CSS class labeled with the code
		/// element name.
		/// </summary>
		/// <param name="match"></param>
		/// <param name="codeElement"></param>
		/// <returns></returns>
		public string GetStyledElement(string match, CodeElement codeElement)
		{
			return string.Format(@"<span class='{1}'>{0}</span>", match, codeElement.Name);
		}

		#endregion
	}

	public class InlineStyleWriter : IStyleWriter
	{
		#region IStyleWriter Members

		/// <summary>
		/// This will output a span tag with the style attribute set based
		/// on the options in the code element.
		/// </summary>
		/// <param name="match"></param>
		/// <param name="codeElement"></param>
		/// <returns></returns>
		public string GetStyledElement(string match, CodeElement codeElement)
		{
			StringBuilder css = new StringBuilder();
			if(codeElement.Color != string.Empty)
				css.AppendFormat(" color: {0};", codeElement.Color);

			if(codeElement.BackColor != string.Empty)
				css.AppendFormat(" background-color: {0};", codeElement.BackColor);

			if(codeElement.Bold)
				css.AppendFormat(" font-weight: bold;");
				
			if(codeElement.Italics)
				css.AppendFormat(" font-style: italic;");

			if(css.Length == 0) return match;

			return string.Format(@"<span style='{1}'>{0}</span>", match, css.ToString());
		}

		#endregion
	}

	public class InlineTagsWriter : IStyleWriter
	{
		#region IStyleWriter Members

		/// <summary>
		/// This will simply wrap with plan font, b, and i tags, using no styles
		/// based on the code element options.
		/// </summary>
		/// <param name="match"></param>
		/// <param name="codeElement"></param>
		/// <returns></returns>
		public string GetStyledElement(string match, CodeElement codeElement)
		{
			string tags = match;
						
			if(codeElement.Color != string.Empty)
				tags = string.Format("<font color='{1}'>{0}</font>", tags, codeElement.Color);

			if(codeElement.Bold)
				tags = string.Format("<b>{0}</b>", tags);
				
			if(codeElement.Italics)
				tags = string.Format("<i>{0}</i>", tags);

			return tags;
		}

		#endregion
	}
}

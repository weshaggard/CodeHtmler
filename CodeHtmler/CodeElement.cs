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
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace CodeHtmler
{
	/// <summary>
	/// This class holds the information need to generate html style information for a particular
	/// code element. Including the name, regular expression pattern, styles, and colors.
	/// </summary>
	[Serializable]
	public class CodeElement
	{
		#region Fields
		private string name = string.Empty;
		private string pattern = string.Empty;
		private string color = string.Empty;
		private string backColor = string.Empty;
		private bool bold = false;
		private bool italics = false;
		private Regex regex = null;
		#endregion
		
		#region Public Interface
		/// <summary>
		/// A simple name to identify what this code element represents.
		/// </summary>
		[XmlAttribute]
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		/// <summary>
		/// A regular expression pattern that will match a string for this type of code element.
		/// </summary>
		public string Pattern
		{
			get { return pattern; }
			set { pattern = value; }
		}
		/// <summary>
		/// The color that is desired for the text of this code element.
		/// </summary>
		[XmlAttribute]
		[Editor(typeof(HtmlColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string Color
		{
			get { return color; }
			set { color = value; }
		}
		/// <summary>
		/// The color that is desired for the background color of this code element.
		/// </summary>
		[XmlAttribute]
		[Editor(typeof(HtmlColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string BackColor
		{
			get { return backColor; }
			set { backColor = value; }
		}
		/// <summary>
		/// Indicator to determine if this code element should be bold.
		/// </summary>
		[XmlAttribute]
		public bool Bold
		{
			get { return bold; }
			set { bold = value; }
		}
		/// <summary>
		/// Indicator to determine if this code element should be in italics.
		/// </summary>
		[XmlAttribute]
		public bool Italics
		{
			get { return italics; }
			set { italics = value; }
		}
		/// <summary>
		/// Method will attempt to match the string given starting at the start index.
		/// </summary>
		/// <param name="code">string try to match</param>
		/// <param name="start">index where you wish the match to start</param>
		/// <returns>The regualar expression match object</returns>
		public Match TryMatch(string code, int start)
		{
			if(regex == null)
				regex = new Regex(@"\G" + pattern, RegexOptions.Multiline|RegexOptions.IgnorePatternWhitespace|RegexOptions.Compiled);

			return regex.Match(code, start);
		}
		#endregion
	}
}

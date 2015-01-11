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


namespace CodeHtmler
{
	/// <summary>
	/// Summary description for program.
	/// </summary>
	public class program
	{
		[STAThread]
		public static void Main()
		{
            Languages langs = Languages.Load(); //("DefaultLanguageDefinitions.xml");
			Language lang = langs.CodeLanguages[0] as Language;

            lang.CodeBackColor = "gray";

			string after = lang.ApplyStyles(@"/// <summary>
/// Summary description for Main.
/// </summary>
static void Main(string[] args)
{
  // string variable
  string myString = ""myString"";

  /* integer 
     variable */
  int myInt = 2;
}");

			Console.ReadLine();
//
//			foreach(Language lang in langs.CodeLanguages)
//			{
//				Console.WriteLine(lang.Name);
//			}
//			Languages ls = new Languages();
//			
//			Language l = new Language();
//			l.Name = "C#";
//		
//			CodeElement ce = new CodeElement();
//			ce.Name = "Literal";
//			ce.Pattern = "test";
//
//			l.CodeElements.Add(ce);
//			ls.CodeLanguages.Add(l);
//
//			ls.Save("Test.xml");
//			Console.ReadLine();
		}
//		This Method converts my old language definitions file to the new one.
//		public static void ConvertOld()
//		{
//			LanguageDefinitions.Languages oldlangs = new LanguageDefinitions.Languages();
//			oldlangs.Load("LanguageDefinitions.xml");
//
//			Languages langs = new Languages();
//			foreach(LanguageDefinitions.Language oldlang in oldlangs.LanguageDefintions)
//			{
//				Language lang = new Language();
//				lang.Name = oldlang.LanguageDescription;
//
//				foreach(LanguageDefinitions.CodeElement oldelement in oldlang.CodeElements)
//				{
//					CodeElement element = new CodeElement();
//					element.Name = oldelement.Name;
//					element.Bold = (oldelement.TextStyle | LanguageDefinitions.TextStyle.Bold) > 0;
//					element.Italics = (oldelement.TextStyle | LanguageDefinitions.TextStyle.Italic) > 0;
//					element.Color = LanguageDefinitions.Languages.ConvertTextColorToString(oldelement.TextColor);
//					element.Pattern = oldelement.Pattern.ToString();
//					lang.CodeElements.Add(element);
//				}
//				langs.CodeLanguages.Add(lang);
//			}
//			langs.Save("Test.xml");
//		}
	}
}

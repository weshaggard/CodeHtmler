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
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.Text.RegularExpressions;

namespace CodeHtmler
{
    /// <summary>
    /// This class cantains all the information for converting a string of code to an
    /// html stylized/colorized version of the input code.
    /// </summary>
    [XmlInclude(typeof(CodeElement))]
    public class Language
    {
        #region Fields
        public const int LNWIDTH = 3;
        private int currentLineNumber;
        private string name = string.Empty;
        private ArrayList codeElements = new ArrayList();
        private StyleType styleType = StyleType.InlineStyles;
        private bool showLineNumbers = false;
        private string lineNumberColor = string.Empty;
        private string lineNumberBackColor = string.Empty;
        private bool usePreTag = true;
        private bool escapeHtml = true;
        private string codeBackColor = string.Empty;
        private string divInlineStyleFont = "Courier New";
        #endregion

        #region Public Interface
        /// <summary>
        /// A simple name to descript what this language represents. i.e. C#, XML, VB.Net
        /// </summary>
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// A list of all the code elements that are defined for this language
        /// </summary>
        [XmlArrayItem(typeof(CodeElement))]
        [Editor(typeof(CodeElementCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ArrayList CodeElements
        {
            get { return codeElements; }
        }
        /// <summary>
        /// The style type for the html that is to be generated. i.e. InlineStyles, InlineTags, or GlobalStyles.
        /// </summary>
        [XmlAttribute]
        public StyleType StyleType
        {
            get { return styleType; }
            set { styleType = value; }
        }
        /// <summary>
        /// This determines if elements like '&', '<', '>' are converted to HTML.
        /// </summary>
        [XmlAttribute]
        public bool EscapeHtml
        {
            get { return escapeHtml; }
            set { escapeHtml = value; }
        }
        /// <summary>
        /// This determines if the outputed code is wrapped with pre tags.
        /// </summary>
        [XmlAttribute]
        public bool UsePreTag
        {
            get { return usePreTag; }
            set { usePreTag = value; }
        }
        /// <summary>
        /// Indicator to determine if line numbers should also be generated for this language.
        /// </summary>
        [XmlAttribute]
        public bool ShowLineNumbers
        {
            get { return showLineNumbers; }
            set { showLineNumbers = value; }
        }
        /// <summary>
        /// If line numbers are generated this will be the color of the number text.
        /// </summary>
        [XmlAttribute]
        [Editor(typeof(HtmlColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string LineNumberColor
        {
            get { return lineNumberColor; }
            set { lineNumberColor = value; }
        }
        /// <summary>
        /// If line numbers are generated this will be the background color for the number text.
        /// </summary>
        [XmlAttribute]
        [Editor(typeof(HtmlColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string LineNumberBackColor
        {
            get { return lineNumberBackColor; }
            set { lineNumberBackColor = value; }
        }
        [XmlAttribute]
        [Editor(typeof(HtmlColorEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string CodeBackColor
        {
            get { return codeBackColor; }
            set { codeBackColor = value; }
        }
        /// <summary>
        /// Default font when not using the pre tag
        /// </summary>
        [XmlAttribute]
        public string DivInlineStyleFont
        {
            get { return divInlineStyleFont; }
            set { divInlineStyleFont = value; }
        }
        /// <summary>
        /// This method will take a code string and convert it to an html encoded/colorized/stylized
        /// string based on the options and code elements of this language.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string ApplyStyles(string code)
        {
            StringBuilder html = new StringBuilder();

            IStyleWriter styleWriter = StyleFactory.Create(styleType);

            int current = 0;
            while (current < code.Length)
            {
                int last = current;
                foreach (CodeElement codeElement in this.CodeElements)
                {
                    Match m = codeElement.TryMatch(code, current);

                    if (!m.Success) continue;

                    html.Append(styleWriter.GetStyledElement(Filter(m.Value), codeElement));

                    current += m.Length;
                    break;
                }
                if (current == last)
                {
                    html.Append(Filter(code[current].ToString()));
                    current++;

                    // There should always be a catch all element to deal with the code
                    // that doesn't match any other code element.
                    //throw new Exception("There should always be a catch all element.");
                }
            }

            string output = html.ToString();
            if (showLineNumbers)
                output = AddLineNumbers(output);

            output = WrapCode(output);

            return output;
        }

        /// <summary>
        /// This method will return the raw styles for all the code elements in this
        /// language. Then they can either be placed within style tags or written to a separate
        /// CSS file.
        /// </summary>
        /// <returns></returns>
        public string CodeElementsCSSStyles()
        {
            StringBuilder css = new StringBuilder();

            css.AppendFormat("span.lineNumber {{ color: {0}; background-color: {1}; }}\n",
                lineNumberColor, lineNumberBackColor);
            foreach (CodeElement codeElement in this.CodeElements)
            {
                css.AppendFormat("span.{0}", codeElement.Name);
                css.Append("{");

                if (codeElement.Color != string.Empty)
                    css.AppendFormat(" color: {0};", codeElement.Color);

                if (codeElement.BackColor != string.Empty)
                    css.AppendFormat(" background-color: {0};", codeElement.BackColor);

                if (codeElement.Bold)
                    css.Append(" font-weight: bold;");

                if (codeElement.Italics)
                    css.Append(" font-style: italic;");

                css.Append("}\n");
            }

            return css.ToString();
        }
        #endregion

        #region Private Methods
        private string WrapCode(string codeHtml)
        {
            string attribs = string.Empty;

            switch (StyleType)
            {
                case StyleType.GlobalStyles:
                    attribs = " class='codeHTML'";
                    break;
                case StyleType.InlineStyles:
                    {
                        string style = string.Empty;
                        if (!usePreTag)
                            style += "font-family: " + divInlineStyleFont + ";";

                        if (codeBackColor != string.Empty)
                            style += "background-color: " + codeBackColor + ";";

                        if (style != string.Empty)
                            attribs = string.Format(" style='{0}'", style);

                        break;
                    }
            }

            return string.Format("<{0}{1}>{2}</{0}>",
                (usePreTag ? "pre" : "div"),
                attribs,
                codeHtml);
        }
        /// <summary>
        /// This method will add line numbers to the html code
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string AddLineNumbers(string html)
        {
            currentLineNumber = 1;
            if (!usePreTag)
                return Regex.Replace(html, "(?m)(?<=<BR />)|(^)", new MatchEvaluator(LineNumberMatchEvaluator));
            else
                return Regex.Replace(html, "(?m)^", new MatchEvaluator(LineNumberMatchEvaluator));
        }
        /// <summary>
        /// This is a regular expression match evaluator that will insert the line number html 
        /// and increment the number appropriately for each line.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string LineNumberMatchEvaluator(Match m)
        {
            switch (StyleType)
            {
                case StyleType.GlobalStyles:
                    return string.Format("<span class='lineNumber'>{0}{1}</span> ",
                        GetNumberPad(currentLineNumber),
                        currentLineNumber++);
                case StyleType.InlineStyles:
                    return string.Format("<span style='color: {2}; background-color: {3}'>{0}{1}</span> ",
                        GetNumberPad(currentLineNumber),
                        currentLineNumber++,
                        lineNumberColor,
                        lineNumberBackColor);
                default: // StyleType.InlineTags
                    return string.Format("<font color='{2}'>{0}{1} </font>",
                        GetNumberPad(currentLineNumber),
                        currentLineNumber++,
                        lineNumberColor);
            }
        }
        private string GetNumberPad(int number)
        {
            if (LNWIDTH <= number.ToString().Length)
                return string.Empty;
            return Filter(new string(' ', LNWIDTH - number.ToString().Length));
        }
        /// <summary>
        /// This method filter the matched text as configured by this class. It 
        /// will escape special chars and convert whitespace to html version.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string Filter(string s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(s);
            if (escapeHtml)
            {
                sb.Replace("&", "&amp;");
                sb.Replace("<", "&lt;");
                sb.Replace(">", "&gt;");
            }
            if (!usePreTag)
            {
                sb.Replace(" ", "&nbsp;");
                sb.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
                sb.Replace("\n", @"<BR />");
            }

            return sb.ToString();
        }
        #endregion
    }
}

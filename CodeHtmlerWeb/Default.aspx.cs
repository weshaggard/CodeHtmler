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
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net;

namespace CodeHtmler
{
    /// <summary>
    /// This page will allow for someone to convert code into colorized code
    /// </summary>
    public class CodeConverter : System.Web.UI.Page
    {
        #region Fields

        protected System.Web.UI.WebControls.TextBox txtCodeInput;
        protected System.Web.UI.WebControls.Button btnCodeHtmlify;
        protected System.Web.UI.WebControls.Panel Panel1;
        protected System.Web.UI.WebControls.CheckBox chkIncludeLineNumbers;
        protected System.Web.UI.WebControls.DropDownList ddlStyleType;
        protected System.Web.UI.WebControls.Literal txtColorizedCode;
        protected System.Web.UI.WebControls.Literal txtHtmlForColorizedCode;
        protected System.Web.UI.WebControls.RadioButton rdoUsePreTag;
        protected System.Web.UI.WebControls.RadioButton rdoConvertWhitespace;
        protected System.Web.UI.WebControls.Literal lblCodeHTMLerVersion;
        protected System.Web.UI.WebControls.DropDownList ddlLanguages;
        private Languages languages = null;

        #endregion

        #region Web Form Designer generated code
        /// <summary>
        /// Base Initialize
        /// </summary>
        /// <param name="e"></param>
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            if (languages == null)
            {
                string defFile = Path.Combine(MapPathSecure(this.TemplateSourceDirectory), Languages.AppFilename);

                languages = Languages.Load(defFile);

                // If the defintion file doesn't exist on the server 
                // take the default languages.
                if (languages == null || languages.CodeLanguages.Count == 0)
                    languages = Languages.Load();
            }
            this.txtCodeInput.Style.Add("width", "100%");
            this.txtCodeInput.Style.Add("height", "400px");
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCodeHtmlify.Click += new System.EventHandler(this.btnCodeHtmlify_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Events

        /// <summary>
        /// On page load all the files cs files in the dir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load(object sender, System.EventArgs e)
        {
            this.lblCodeHTMLerVersion.Text = string.Format("Running version {0} of CodeHTMLer.", typeof(Languages).Assembly.GetName().Version);

            if (IsPostBack == false)
            {
                // Load the possible Languanges
                this.ddlLanguages.Items.Clear();

                //Response.Write(Path.Combine(MapPathSecure(this.TemplateSourceDirectory), Languages.AppFilename));
                foreach (Language lang in languages.CodeLanguages)
                    this.ddlLanguages.Items.Add(lang.Name);
            }
        }
        /// <summary>
        /// This will display the colorized code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCodeHtmlify_Click(object sender, System.EventArgs e)
        {
            Language lang = (Language)languages.CodeLanguages[this.ddlLanguages.SelectedIndex];

            lang.ShowLineNumbers = this.chkIncludeLineNumbers.Checked;
            lang.StyleType = (StyleType)this.ddlStyleType.SelectedIndex;

            lang.UsePreTag = this.rdoUsePreTag.Checked; ;
            string htmlcode = lang.ApplyStyles(this.txtCodeInput.Text); ;

            if ((StyleType)this.ddlStyleType.SelectedIndex == StyleType.GlobalStyles)
            {
                htmlcode = string.Format("<style>{0}</style>\n{1}", lang.CodeElementsCSSStyles(), htmlcode);
            }

            this.txtColorizedCode.Text = htmlcode;
            this.txtHtmlForColorizedCode.Text = EscapeHtml(htmlcode);
        }
        /// <summary>
        /// This function will escape any special html chars
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string EscapeHtml(string s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(s);
            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace(" ", "&nbsp;");
            sb.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            sb.Replace("\n", "<BR />");
            return sb.ToString();
        }
        #endregion
    }
}

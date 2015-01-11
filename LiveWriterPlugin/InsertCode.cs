using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeHtmler;

namespace LiveWriterPlugin
{
    public partial class InsertCode : Form
    {
        private Languages languages = null;
        private const string editLangs = "<Edit Languages>";
        public InsertCode()
        {
            InitializeComponent();
            InitializeForm();
        }
        public string Code
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }
        public string CodeHtml
        {
            get
            {
                Language lang = this.languages.FindLanguage(this.cboLanguages.Text);

                if (lang.CodeElements.Count == 0)
                    return this.Code;

                lang.ShowLineNumbers = this.chkLineNumbers.Checked;
                return lang.ApplyStyles(Code);
            }
        }
        private void InitializeForm()
        {
            this.txtCode.Text = @"/// <summary>
/// Summary description for Main.
/// </summary>
static void Main(string[] args)
{
  // string variable
  string myString = ""myString"";

  /* integer 
     variable */
  int myInt = 2;
}";
            this.txtCode.SelectAll();

            this.languages = Languages.Load();
            LoadLanguageCombo();
        }
        private void LoadLanguageCombo()
        {
            this.cboLanguages.SelectedIndexChanged -= new System.EventHandler(this.cboLanguages_SelectedIndexChanged);
            this.cboLanguages.Items.Clear();

            foreach (Language lang in this.languages.CodeLanguages)
            {
                if (this.cboLanguages.Items.Count == 0)
                    this.chkLineNumbers.Checked = lang.ShowLineNumbers;
                this.cboLanguages.Items.Add(lang.Name);
            }
            
            this.cboLanguages.Items.Add(editLangs);
            this.cboLanguages.SelectedIndex = 0;
            this.cboLanguages.SelectedIndexChanged += new System.EventHandler(this.cboLanguages_SelectedIndexChanged);
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void cboLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboLanguages.Text == editLangs)
            {
                using (PropertyGridDialog pgd = new PropertyGridDialog(this.languages))
                {
                    if (pgd.ShowDialog() == DialogResult.OK)
                    {
                        this.languages.Save();
                    }
                    else
                    {
                        this.languages = Languages.Load();
                    }
                    LoadLanguageCombo();
                }
            }
        }
    }
}
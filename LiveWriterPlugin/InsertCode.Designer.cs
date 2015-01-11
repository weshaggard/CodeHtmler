namespace LiveWriterPlugin
{
    partial class InsertCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboLanguages = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.chkLineNumbers = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboLanguages
            // 
            this.cboLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguages.FormattingEnabled = true;
            this.cboLanguages.Location = new System.Drawing.Point(63, 241);
            this.cboLanguages.Name = "cboLanguages";
            this.cboLanguages.Size = new System.Drawing.Size(121, 21);
            this.cboLanguages.TabIndex = 1;
            this.cboLanguages.SelectedIndexChanged += new System.EventHandler(this.cboLanguages_SelectedIndexChanged);
            // 
            // txtCode
            // 
            this.txtCode.AcceptsReturn = true;
            this.txtCode.AcceptsTab = true;
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(509, 236);
            this.txtCode.TabIndex = 0;
            // 
            // chkLineNumbers
            // 
            this.chkLineNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLineNumbers.AutoSize = true;
            this.chkLineNumbers.Location = new System.Drawing.Point(193, 245);
            this.chkLineNumbers.Name = "chkLineNumbers";
            this.chkLineNumbers.Size = new System.Drawing.Size(91, 17);
            this.chkLineNumbers.TabIndex = 2;
            this.chkLineNumbers.Text = "Line Numbers";
            this.chkLineNumbers.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Language";
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(430, 240);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // InsertCode
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 268);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLineNumbers);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cboLanguages);
            this.Name = "InsertCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLanguages;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chkLineNumbers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
    }
}
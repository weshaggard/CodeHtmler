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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeHtmler
{
	/// <summary>
	/// Summary description for PropertyGridDialog.
	/// </summary>
	public class PropertyGridDialog : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(5, 5);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.NoSort;
			this.propertyGrid1.Size = new System.Drawing.Size(280, 75);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "PropertyGrid";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(128, 88);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "Ok";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(208, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			// 
			// PropertyGridDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 118);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.propertyGrid1);
			this.Name = "PropertyGridDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PropertyGridDialog";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// This is a default constructor which will set the 
		/// object as the in the property grid
		/// </summary>
		/// <param name="obj"></param>
		public PropertyGridDialog(object obj)
		{
			InitializeComponent();
			this.propertyGrid1.SelectedObject = obj;

			if(obj != null)
				this.Text = obj.GetType().Name + " Editor";
		}
		/// <summary>
		/// Method will simply set the dialog result to OK
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
		/// <summary>
		/// This will return/set the property grid object.
		/// </summary>
		public object PropertyGridObject
		{
			get { return this.propertyGrid1.SelectedObject; }
			set { this.propertyGrid1.SelectedObject = value; }
		}
	}
}

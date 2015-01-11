using System;
using System.Collections.Generic;
using System.Text;
using WindowsLive.Writer.Api;
using System.Windows.Forms;

namespace LiveWriterPlugin
{
    [WriterPlugin("C220E5B0-5743-11DB-8373-B622A1EF5492", "CodeHTMLer",
        Description = "Converts source code to colorized HTML",
        PublisherUrl = "http://puzzleware.net/codehtmler",
        HasEditableOptions = false,
        ImagePath = "InsertCode.png")]
    [InsertableContentSource("Insert Code", SidebarText = "Code")]
    public class CodeHtmlerSource : ContentSource
    {
        public override System.Windows.Forms.DialogResult CreateContent(System.Windows.Forms.IWin32Window dialogOwner, ref string newContent)
        {
            using (InsertCode insertCode = new InsertCode())
            {
                if (!string.IsNullOrEmpty(newContent))
                    insertCode.Code = newContent;

                DialogResult dr = insertCode.ShowDialog(dialogOwner);

                if (dr == DialogResult.OK)
                    newContent = insertCode.CodeHtml;

                return dr;                
            }
        }
    }
}

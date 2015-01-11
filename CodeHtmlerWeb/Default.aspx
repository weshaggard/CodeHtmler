<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="CodeHtmler.CodeConverter" Debug="true" validateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<HTML>
	<HEAD>
		<title>Convert Code Online</title>
		<LINK href="Master.css" type="text/css" rel="stylesheet">
			<SCRIPT language="javascript">
	function copyCodeHtmlToClipBoard()
	{
		clipboardData.setData("Text", htmlcode.innerHTML);
	}
			</SCRIPT>
	</HEAD>
	<body>
	    <div id="frame">
        <div class="shadow">
            <div class="shadowcontent">
			<div id="header">
				<p><STRONG><FONT size="6">CodeHTMLer</FONT></STRONG></p>
				<P style="TEXT-ALIGN:left">
					CodeHTMLer is a simple program that translates plain text code into a 
					colorized&nbsp;HTML version of the code.
				</P>
				<table style="BORDER-RIGHT: gray thin solid; BORDER-TOP: gray thin solid; BORDER-LEFT: gray thin solid; BORDER-BOTTOM: gray thin solid; BORDER-COLLAPSE: collapse; TEXT-ALIGN: left"
					cellSpacing="0" width="100%" border="1">
					<tr>
						<td>Turns bland looking code like this:
						</td>
						<td>Into colorful code like this:
						</td>
					</tr>
					<tr>
						<td width="50%"><pre style="PADDING-LEFT: 5px">/// &lt;summary&gt;
/// Summary description for Main.
/// &lt;/summary&gt;
static void Main(string[] args)
{
  // string variable
  string myString = "myString";

  /* integer 
     variable */
  int myInt = 2;
}
</pre>
						</td>
						<td width="50%"><pre style="PADDING-LEFT: 5px"><span style="COLOR: gray">/// &lt;summary&gt;
</span><span style="COLOR: gray">/// Summary description for Main.
</span><span style="COLOR: gray">/// &lt;/summary&gt;
</span><span style="COLOR: blue">static</span> <span style="COLOR: blue">void</span> Main(<span style="COLOR: blue">string</span>[] args)
{
  <span style="COLOR: green">// string variable
</span>  <span style="COLOR: blue">string</span> myString = <span style="COLOR: maroon">"myString"</span>;

  <span style="COLOR: green">/* integer 
     variable */</span>
  <span style="COLOR: blue">int</span> myInt = <span style="COLOR: maroon">2</span>;
}
</pre>
						</td>
					</tr>
				</table>
			</div>
			<div id="content">
				<form method="post" runat="server">
					<p>If you wish to try it out enter some code here and select the options you want 
						and then click the <STRONG>Htmlify Code</STRONG> button.</p>
					<P><STRONG>Enter code to be converted into colorized HTML</STRONG>
						<asp:textbox id="txtCodeInput" runat="server" TextMode="MultiLine" Height="400px" Width="100%"
							Wrap="False"></asp:textbox><BR>
					</P>
					<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
						<TR>
							<TD width="173">Code 
								Language&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							<TD><asp:dropdownlist id="ddlLanguages" runat="server"></asp:dropdownlist>&nbsp (for other  
					languages submit an issue or pull request at <a href="https://github.com/weshaggard/codehtmler">
						CodeHtmler</a>)</TD>
						</TR>
						<TR>
							<TD width="173">Type of Style</TD>
							<TD><asp:dropdownlist id="ddlStyleType" runat="server">
									<asp:ListItem Value="Inline Styles" Selected="True">Inline Styles</asp:ListItem>
									<asp:ListItem Value="Inline Tags">Inline Tags</asp:ListItem>
									<asp:ListItem Value="Style Classes">Style Classes</asp:ListItem>
								</asp:dropdownlist></TD>
						</TR>
						<TR>
							<TD width="173">Include Line Numbers</TD>
							<TD><asp:checkbox id="chkIncludeLineNumbers" runat="server"></asp:checkbox></TD>
						</TR>
						<TR>
							<TD width="173" height="16">Whitespace Options</TD>
							<TD height="16">
								<asp:RadioButton id="rdoUsePreTag" runat="server" Text="Use &amp;lt;pre&amp;gt; tag" Checked="True"
									GroupName="whitespaceoptions"></asp:RadioButton>&nbsp;
								<asp:RadioButton id="rdoConvertWhitespace" runat="server" Text="Convert whitespace" GroupName="whitespaceoptions"></asp:RadioButton>
							</TD>
						</TR>
						<TR>
							<TD width="173" height="10"></TD>
							<TD height="10"></TD>
						</TR>
						<TR>
							<TD width="173"><asp:button id="btnCodeHtmlify" runat="server" Text="Htmlify Code"></asp:button></TD>
							<TD></TD>
						</TR>
					</TABLE>
					<br>
					<br>
					<STRONG>Colorized version of the entered code</STRONG>
					<DIV id="htmlcode" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid"><asp:literal id="txtColorizedCode" runat="server"></asp:literal></DIV>
					<br>
					<STRONG>Html for the Colorized version of the entered code</STRONG> <A href="javascript:void(copyCodeHtmlToClipBoard())">
						[Copy HTML to ClipBoard (IE only)]</A>
					<DIV style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; FONT-SIZE: smaller; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid; FONT-FAMILY: courier new"><asp:literal id="txtHtmlForColorizedCode" runat="server"></asp:literal></DIV>
					<br>
					<asp:Literal id="lblCodeHTMLerVersion" runat="server"></asp:Literal>
					<br>
					<hr>
					<P>See source code at <a href="https://github.com/weshaggard/codehtmler">CodeHtmler</a>.</P>
				</form>
			</div>
		</div></div></div>
		<div id="footer">
			Copyright © 2003-2014, <a href="http://weblogs.asp.net/whaggard/">Wes Haggard</a>.</div>
	</body>
</HTML>

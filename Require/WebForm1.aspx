<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="Require.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 16px" runat="server">输入0到100的数字a</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server">输入0到100的数字b</asp:Label>
				<asp:TextBox id="TextBox1" style="Z-INDEX: 103; LEFT: 184px; POSITION: absolute; TOP: 8px" runat="server"
					Width="112px"></asp:TextBox>
				<asp:TextBox id="TextBox2" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 80px" runat="server"
					Width="116px"></asp:TextBox>
				<asp:RangeValidator id="RangeValidator1" style="Z-INDEX: 105; LEFT: 72px; POSITION: absolute; TOP: 48px"
					runat="server" ErrorMessage="RangeValidator" ControlToValidate="TextBox1" MaximumValue="100" MinimumValue="0"
					Type="Integer">输入数字已经超界，请重新输入</asp:RangeValidator>
				<asp:RangeValidator id="RangeValidator2" style="Z-INDEX: 106; LEFT: 72px; POSITION: absolute; TOP: 120px"
					runat="server" ErrorMessage="RangeValidator" ControlToValidate="TextBox2" MaximumValue="100" MinimumValue="0"
					Type="Integer">输入数字已经超界，请重新输入</asp:RangeValidator>
				<asp:Button id="Button1" style="Z-INDEX: 107; LEFT: 40px; POSITION: absolute; TOP: 168px" runat="server"
					Text="统计ab之和" Width="216px"></asp:Button></FONT>
		</form>
	</body>
</HTML>
 
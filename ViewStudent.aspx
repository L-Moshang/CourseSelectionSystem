<%@ Page language="c#" Codebehind="ViewStudent.aspx.cs" AutoEventWireup="false" Inherits="sc.ViewStudent" %>
<%@ Register TagPrefix="uc1" TagName="TeacherHeadControl" Src="TeacherHeadControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewStudent</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 109; LEFT: 136px; POSITION: absolute; TOP: 136px" runat="server">学号</asp:Label>
			<asp:Label id="lbSPhone" style="Z-INDEX: 114; LEFT: 240px; POSITION: absolute; TOP: 440px"
				runat="server"></asp:Label>
			<asp:Label id="lbSName" style="Z-INDEX: 113; LEFT: 240px; POSITION: absolute; TOP: 184px" runat="server"></asp:Label>
			<asp:Label id="lbSSex" style="Z-INDEX: 112; LEFT: 240px; POSITION: absolute; TOP: 240px" runat="server"></asp:Label>
			<asp:Label id="lbSAge" style="Z-INDEX: 111; LEFT: 240px; POSITION: absolute; TOP: 296px" runat="server"></asp:Label>
			<asp:Label id="lbSAddress" style="Z-INDEX: 110; LEFT: 240px; POSITION: absolute; TOP: 392px"
				runat="server"></asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 102; LEFT: 136px; POSITION: absolute; TOP: 184px" runat="server">姓名</asp:Label>
			<asp:Label id="Label8" style="Z-INDEX: 106; LEFT: 136px; POSITION: absolute; TOP: 240px" runat="server">性别</asp:Label>
			<asp:Label id="Label9" style="Z-INDEX: 107; LEFT: 136px; POSITION: absolute; TOP: 296px" runat="server">年龄</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 105; LEFT: 136px; POSITION: absolute; TOP: 344px" runat="server">学分</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 104; LEFT: 136px; POSITION: absolute; TOP: 392px" runat="server">地址</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 440px" runat="server">电话</asp:Label>
			<asp:Label id="lbSCredit" style="Z-INDEX: 108; LEFT: 240px; POSITION: absolute; TOP: 344px"
				runat="server"></asp:Label>
			<asp:Label id="lbSId" style="Z-INDEX: 100; LEFT: 240px; POSITION: absolute; TOP: 136px" runat="server"></asp:Label>
			<uc1:TeacherHeadControl id="TeacherHeadControl1" runat="server"></uc1:TeacherHeadControl>
		</form>
	</body>
</HTML>

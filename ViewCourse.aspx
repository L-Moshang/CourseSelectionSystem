<%@ Page language="c#" Codebehind="ViewCourse.aspx.cs" AutoEventWireup="false" Inherits="sc.ViewCourse" %>
<%@ Register TagPrefix="uc1" TagName="StudentHeadControl" Src="StudentHeadControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewCourse</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:label id="Label1" style="Z-INDEX: 106; LEFT: 280px; POSITION: absolute; TOP: 232px" runat="server">课程名称</asp:label>
				<asp:Label id="lbCName" style="Z-INDEX: 115; LEFT: 408px; POSITION: absolute; TOP: 232px" runat="server"></asp:Label>
				<asp:Label id="lbCType" style="Z-INDEX: 114; LEFT: 408px; POSITION: absolute; TOP: 272px" runat="server"></asp:Label>
				<asp:Label id="lbCCredit" style="Z-INDEX: 113; LEFT: 408px; POSITION: absolute; TOP: 312px"
					runat="server"></asp:Label>
				<asp:Label id="lbPreCName" style="Z-INDEX: 112; LEFT: 408px; POSITION: absolute; TOP: 352px"
					runat="server"></asp:Label>
				<asp:Label id="lbCMax" style="Z-INDEX: 111; LEFT: 408px; POSITION: absolute; TOP: 392px" runat="server"></asp:Label>
				<asp:label id="Label4" style="Z-INDEX: 107; LEFT: 280px; POSITION: absolute; TOP: 192px" runat="server">课程编号</asp:label>
				<asp:label id="Label2" style="Z-INDEX: 100; LEFT: 280px; POSITION: absolute; TOP: 272px" runat="server">课程类别</asp:label>
				<asp:label id="Label8" style="Z-INDEX: 104; LEFT: 280px; POSITION: absolute; TOP: 312px" runat="server">学分</asp:label>
				<asp:label id="Label7" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 352px" runat="server">前导课程</asp:label>
				<asp:label id="Label3" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 392px" runat="server">最大人数</asp:label>
				<asp:label id="Label6" style="Z-INDEX: 102; LEFT: 280px; POSITION: absolute; TOP: 440px" runat="server">课程介绍</asp:label>
				<asp:textbox id="txtCNote" style="Z-INDEX: 105; LEFT: 408px; POSITION: absolute; TOP: 440px"
					runat="server" Height="104px" TextMode="MultiLine" Width="408px" ReadOnly="True"></asp:textbox>
				<asp:Label id="lbCId" style="Z-INDEX: 108; LEFT: 408px; POSITION: absolute; TOP: 192px" runat="server"></asp:Label>
				<uc1:StudentHeadControl id="StudentHeadControl1" runat="server"></uc1:StudentHeadControl></FONT>
		</form>
	</body>
</HTML>

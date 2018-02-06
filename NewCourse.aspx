<%@ Page language="c#" Codebehind="NewCourse.aspx.cs" AutoEventWireup="false" Inherits="sc.NewCourse" %>
<%@ Register TagPrefix="uc1" TagName="TeacherHeadControl" Src="TeacherHeadControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NewCourse</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label6" style="Z-INDEX: 108; LEFT: 280px; POSITION: absolute; TOP: 408px" runat="server">课程介绍</asp:label><asp:label id="Label8" style="Z-INDEX: 110; LEFT: 280px; POSITION: absolute; TOP: 232px" runat="server">学分</asp:label><asp:label id="Label7" style="Z-INDEX: 109; LEFT: 280px; POSITION: absolute; TOP: 280px" runat="server">前导课程</asp:label><uc1:teacherheadcontrol id="TeacherHeadControl1" runat="server"></uc1:teacherheadcontrol><asp:label id="Label1" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 136px" runat="server">课程名称</asp:label><asp:textbox id="txtCName" style="Z-INDEX: 102; LEFT: 416px; POSITION: absolute; TOP: 136px"
				runat="server"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 103; LEFT: 280px; POSITION: absolute; TOP: 192px" runat="server">课程类别</asp:label><asp:dropdownlist id="ddlCType" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 184px"
				runat="server" Width="152px"></asp:dropdownlist><asp:label id="Label3" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 328px" runat="server">最大人数</asp:label><asp:dropdownlist id="ddlCCredit" style="Z-INDEX: 111; LEFT: 416px; POSITION: absolute; TOP: 232px"
				runat="server" Width="152px"></asp:dropdownlist><asp:dropdownlist id="ddlCPreCId" style="Z-INDEX: 112; LEFT: 416px; POSITION: absolute; TOP: 280px"
				runat="server" Width="152px"></asp:dropdownlist><asp:dropdownlist id="ddlCMax" style="Z-INDEX: 113; LEFT: 416px; POSITION: absolute; TOP: 328px" runat="server"
				Width="152px"></asp:dropdownlist><asp:textbox id="txtCNote" style="Z-INDEX: 123; LEFT: 416px; POSITION: absolute; TOP: 384px"
				runat="server" Width="408px" Height="104px" TextMode="MultiLine"></asp:textbox><asp:button id="btnAdd" style="Z-INDEX: 124; LEFT: 352px; POSITION: absolute; TOP: 528px" runat="server"
				Width="176px" Height="40px" Text="开设课程"></asp:button></form>
	</body>
</HTML>

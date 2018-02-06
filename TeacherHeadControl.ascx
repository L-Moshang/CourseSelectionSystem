<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TeacherHeadControl.ascx.cs" Inherits="sc.TeacherHeadControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<FONT face="宋体"></FONT>
<DIV style="WIDTH: 100%; POSITION: relative; HEIGHT: 104px" ms_positioning="GridLayout"
	id="DIV1" runat="server">
	<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 384px; POSITION: absolute; TOP: 16px" runat="server"
		Font-Size="X-Large" Font-Bold="True">选课系统</asp:Label>
	<asp:HyperLink id="HyperLink1" style="Z-INDEX: 102; LEFT: 672px; POSITION: absolute; TOP: 72px"
		runat="server" NavigateUrl="Teacher.aspx">个人信息</asp:HyperLink>
	<asp:HyperLink id="HyperLink2" style="Z-INDEX: 103; LEFT: 776px; POSITION: absolute; TOP: 72px"
		runat="server" NavigateUrl="NewCourse.aspx">开设课程</asp:HyperLink>
	<asp:HyperLink id="hlkQuit" style="Z-INDEX: 104; LEFT: 888px; POSITION: absolute; TOP: 72px" runat="server"
		NavigateUrl="Logout.aspx" ForeColor="Red">退出</asp:HyperLink>
	<asp:HyperLink id="HyperLink4" style="Z-INDEX: 105; LEFT: 568px; POSITION: absolute; TOP: 72px"
		runat="server" NavigateUrl="TeacherMain.aspx">教师首页</asp:HyperLink></DIV>
<FONT face="宋体"></FONT>

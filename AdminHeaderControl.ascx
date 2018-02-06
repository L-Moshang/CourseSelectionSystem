<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminHeaderControl.ascx.cs" Inherits="sc.AdminHeaderControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<body ms_positioning="GridLayout">
	<FONT face="宋体">
		<asp:HyperLink id="hlkAdminRoom" style="Z-INDEX: 102; LEFT: 536px; POSITION: absolute; TOP: 80px"
			Runat="server" ForeColor="#000000" NavigateUrl="AdminRoom.aspx">教学楼与教室设置</asp:HyperLink>
		<asp:HyperLink id="hlkLogout" style="Z-INDEX: 103; LEFT: 896px; POSITION: absolute; TOP: 80px"
			ForeColor="#ff0000" NavigateUrl="Logout.aspx" runat="server">退出</asp:HyperLink>
		<asp:HyperLink id="hlkAdminUser" style="Z-INDEX: 101; LEFT: 712px; POSITION: absolute; TOP: 80px"
			ForeColor="#000000" NavigateUrl="AdminUser.aspx" runat="server">教师和学生信息录入</asp:HyperLink>
		<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 360px; POSITION: absolute; TOP: 24px" runat="server"
			Font-Size="X-Large" Font-Bold="True">选课系统管理</asp:Label>
		<asp:HyperLink id="hlkAdmin" style="Z-INDEX: 105; LEFT: 416px; POSITION: absolute; TOP: 80px" NavigateUrl="Admin.aspx"
			runat="server">管理首页</asp:HyperLink></FONT>
</body>

<%@ Page language="c#" Codebehind="bxCourse.aspx.cs" AutoEventWireup="false" Inherits="sc.bxCourse" %>
<%@ Register TagPrefix="uc1" TagName="StudentHeadControl" Src="StudentHeadControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>bxCourse</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:studentheadcontrol id="StudentHeadControl1" runat="server"></uc1:studentheadcontrol><br>
			<br>
			<asp:DataGrid id="dgCourse" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 240px" runat="server"
				Width="712px" Height="128px" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White"
				CellPadding="4" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="CId" HeaderText="课程编号"></asp:BoundColumn>
					<asp:HyperLinkColumn DataNavigateUrlField="CId" DataNavigateUrlFormatString="ViewCourse.aspx?CId={0}"
						DataTextField="CName" HeaderText="课程名称"></asp:HyperLinkColumn>
					<asp:BoundColumn Visible="False" DataField="TId" HeaderText="老师编号"></asp:BoundColumn>
					<asp:HyperLinkColumn DataNavigateUrlField="TId" DataNavigateUrlFormatString="ViewTeacher.aspx?TId={0}"
						DataTextField="TName" HeaderText="授课老师"></asp:HyperLinkColumn>
					<asp:BoundColumn DataField="CCredit" HeaderText="课程学分"></asp:BoundColumn>
					<asp:HyperLinkColumn Text="查看上课时间地点" DataNavigateUrlField="CId" DataNavigateUrlFormatString="ViewCourseTime.aspx?CId={0}"></asp:HyperLinkColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 104px; POSITION: absolute; TOP: 208px" runat="server">必修课程列表：  (必修课程不需要选择，在您锁定选课信息时候自动加入到您的选课列表中！）</asp:Label></form>
	</body>
</HTML>

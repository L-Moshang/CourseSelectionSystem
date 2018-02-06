<%@ Register TagPrefix="uc1" TagName="StudentHeadControl" Src="StudentHeadControl.ascx" %>
<%@ Page language="c#" Codebehind="xxCourse.aspx.cs" AutoEventWireup="false" Inherits="sc.xxCourse" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>xxCourse</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:StudentHeadControl id="StudentHeadControl1" runat="server"></uc1:StudentHeadControl>
			<asp:DataGrid id="dgCourse" style="Z-INDEX: 101; LEFT: 80px; POSITION: absolute; TOP: 192px" runat="server"
				BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4"
				AutoGenerateColumns="False" Width="824px">
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
						DataTextField="TName" HeaderText="老师姓名"></asp:HyperLinkColumn>
					<asp:HyperLinkColumn DataNavigateUrlField="CPreCId" DataNavigateUrlFormatString="ViewCourse.aspx?CId={0}"
						DataTextField="CPreCName" HeaderText="前导课程"></asp:HyperLinkColumn>
					<asp:BoundColumn DataField="CCredit" HeaderText="课程学分"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="已选人数"></asp:BoundColumn>
					<asp:BoundColumn DataField="CMax" HeaderText="最大人数"></asp:BoundColumn>
					<asp:HyperLinkColumn Text="上课时间地点" DataNavigateUrlField="CId" DataNavigateUrlFormatString="ViewCourseTime.aspx?CId={0}"></asp:HyperLinkColumn>
					<asp:ButtonColumn Text="选修该课程" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 160px" runat="server">选修课程列表：</asp:Label>
			<asp:Label id="lbLock" style="Z-INDEX: 103; LEFT: 496px; POSITION: absolute; TOP: 160px" runat="server"></asp:Label>
		</form>
	</body>
</HTML>

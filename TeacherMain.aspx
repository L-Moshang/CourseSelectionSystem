<%@ Page language="c#" Codebehind="TeacherMain.aspx.cs" AutoEventWireup="false" Inherits="sc.TeacherMain" %>
<%@ Register TagPrefix="uc1" TagName="TeacherHeadControl" Src="TeacherHeadControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TeacherMain</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:TeacherHeadControl id="TeacherHeadControl1" runat="server"></uc1:TeacherHeadControl>
			<asp:DataGrid id="dgCourse" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 168px" runat="server"
				Width="880px" Height="56px" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White"
				CellPadding="4" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="CId" HeaderText="课程编号"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="TId" HeaderText="教师编号"></asp:BoundColumn>
					<asp:BoundColumn DataField="CName" HeaderText="课程名称"></asp:BoundColumn>
					<asp:BoundColumn DataField="CType" HeaderText="课程类别"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CPreCId" HeaderText="前导课程编号"></asp:BoundColumn>
					<asp:BoundColumn DataField="CPreCName" HeaderText="前导课程"></asp:BoundColumn>
					<asp:BoundColumn DataField="CCredit" HeaderText="学分"></asp:BoundColumn>
					<asp:BoundColumn DataField="CMax" HeaderText="最大人数"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="已选人数"></asp:BoundColumn>
					<asp:HyperLinkColumn Text="评定成绩" DataNavigateUrlField="CId" DataNavigateUrlFormatString="SC.aspx?CId={0}"></asp:HyperLinkColumn>
					<asp:HyperLinkColumn Text="时间地点编排" DataNavigateUrlField="CId" DataNavigateUrlFormatString="CourseTime.aspx?CId={0}"></asp:HyperLinkColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 128px" runat="server"
				Font-Bold="True" ForeColor="SeaGreen">您当前开设的课程：</asp:Label>
			<asp:Label id="lbCount" style="Z-INDEX: 103; LEFT: 208px; POSITION: absolute; TOP: 128px" runat="server"></asp:Label>
		</form>
	</body>
</HTML>

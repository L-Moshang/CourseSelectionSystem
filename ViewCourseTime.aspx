<%@ Page language="c#" Codebehind="ViewCourseTime.aspx.cs" AutoEventWireup="false" Inherits="sc.ViewCourseTime" %>
<%@ Register TagPrefix="uc1" TagName="StudentHeadControl" Src="StudentHeadControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewCourseTime</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lbCaption" style="Z-INDEX: 116; LEFT: 112px; POSITION: absolute; TOP: 184px"
				runat="server"></asp:label>
			<asp:datagrid id="dgTime" style="Z-INDEX: 115; LEFT: 112px; POSITION: absolute; TOP: 216px" runat="server"
				PageSize="5" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC"
				AutoGenerateColumns="False" Height="104px" Width="833px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="CWeekStart" HeaderText="开始周次"></asp:BoundColumn>
					<asp:BoundColumn DataField="CWeekEnd" HeaderText="结束周次"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="BuildingId" HeaderText="教学楼编号"></asp:BoundColumn>
					<asp:BoundColumn DataField="BuildingName" HeaderText="教学楼"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RoomId" HeaderText="教室编号"></asp:BoundColumn>
					<asp:BoundColumn DataField="RoomName" HeaderText="教室"></asp:BoundColumn>
					<asp:BoundColumn DataField="CTime" HeaderText="上课时间">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="下一页" PrevPageText="上一页" HorizontalAlign="Left" ForeColor="#003399"
					BackColor="#99CCCC"></PagerStyle>
			</asp:datagrid>
			<uc1:StudentHeadControl id="StudentHeadControl1" runat="server"></uc1:StudentHeadControl>
		</form>
	</body>
</HTML>

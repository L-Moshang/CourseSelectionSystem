<%@ Register TagPrefix="uc1" TagName="TeacherHeadControl" Src="TeacherHeadControl.ascx" %>
<%@ Page language="c#" Codebehind="CourseTime.aspx.cs" AutoEventWireup="false" Inherits="sc.WebForm1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CourseTime</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:label id="Label5" style="Z-INDEX: 113; LEFT: 80px; POSITION: absolute; TOP: 352px" runat="server">上课时间</asp:label><asp:label id="Label12" style="Z-INDEX: 114; LEFT: 128px; POSITION: absolute; TOP: 392px" runat="server">从第</asp:label><asp:dropdownlist id="ddlCWeekStart" style="Z-INDEX: 103; LEFT: 176px; POSITION: absolute; TOP: 392px"
					runat="server" Width="72px" AutoPostBack="True"></asp:dropdownlist><asp:label id="Label11" style="Z-INDEX: 110; LEFT: 280px; POSITION: absolute; TOP: 392px" runat="server">周到第</asp:label><asp:dropdownlist id="ddlCWeekEnd" style="Z-INDEX: 104; LEFT: 368px; POSITION: absolute; TOP: 392px"
					runat="server" Width="72px"></asp:dropdownlist><asp:label id="Label10" style="Z-INDEX: 109; LEFT: 464px; POSITION: absolute; TOP: 392px" runat="server"
					Width="72px">周，每周</asp:label><asp:dropdownlist id="ddlWeek" style="Z-INDEX: 105; LEFT: 552px; POSITION: absolute; TOP: 392px" runat="server"
					Width="88px"></asp:dropdownlist><asp:dropdownlist id="ddlTime" style="Z-INDEX: 106; LEFT: 672px; POSITION: absolute; TOP: 392px" runat="server"
					Width="112px"></asp:dropdownlist><asp:label id="lbTime2" style="Z-INDEX: 112; LEFT: 80px; POSITION: absolute; TOP: 440px" runat="server">上课地点</asp:label><asp:dropdownlist id="ddlBuilding" style="Z-INDEX: 101; LEFT: 128px; POSITION: absolute; TOP: 480px"
					runat="server" Width="104px" AutoPostBack="True"></asp:dropdownlist><asp:label id="Label9" style="Z-INDEX: 108; LEFT: 256px; POSITION: absolute; TOP: 480px" runat="server">教学楼</asp:label><asp:dropdownlist id="ddlRoom" style="Z-INDEX: 102; LEFT: 344px; POSITION: absolute; TOP: 480px" runat="server"
					Width="152px"></asp:dropdownlist><asp:label id="Label13" style="Z-INDEX: 111; LEFT: 528px; POSITION: absolute; TOP: 480px" runat="server"
					Width="32px">教室</asp:label><asp:button id="btnAddTime" style="Z-INDEX: 107; LEFT: 664px; POSITION: absolute; TOP: 456px"
					runat="server" Width="144px" Text="添加上课时间" Height="48px"></asp:button><asp:datagrid id="dgTime" style="Z-INDEX: 115; LEFT: 56px; POSITION: absolute; TOP: 144px" runat="server"
					Width="833px" Height="104px" AllowPaging="True" PageSize="5" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False">
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
						<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle NextPageText="下一页" PrevPageText="上一页" HorizontalAlign="Left" ForeColor="#003399"
						BackColor="#99CCCC"></PagerStyle>
				</asp:datagrid><asp:label id="lbCaption" style="Z-INDEX: 116; LEFT: 64px; POSITION: absolute; TOP: 120px"
					runat="server"></asp:label><asp:linkbutton id="lkbAddTime" style="Z-INDEX: 117; LEFT: 752px; POSITION: absolute; TOP: 120px"
					runat="server">添加新的上课时间</asp:linkbutton>
				<uc1:TeacherHeadControl id="TeacherHeadControl1" runat="server"></uc1:TeacherHeadControl></FONT></form>
	</body>
</HTML>

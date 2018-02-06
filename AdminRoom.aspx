<%@ Page language="c#" Codebehind="AdminRoom.aspx.cs" AutoEventWireup="false" Inherits="sc.AdminRoom" %>
<%@ Register TagPrefix="uc1" TagName="AdminHeaderControl" Src="AdminHeaderControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdminRoom</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="Label2" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 240px" runat="server">增加教学楼：</asp:Label>
				<asp:TextBox id="txtBuilding" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 240px"
					runat="server" Width="152px"></asp:TextBox>
				<asp:Button id="btnAddBuilding" style="Z-INDEX: 103; LEFT: 152px; POSITION: absolute; TOP: 288px"
					runat="server" Text="增加教学楼" Width="82px"></asp:Button>
				<asp:DataGrid id="dgView" style="Z-INDEX: 104; LEFT: 448px; POSITION: absolute; TOP: 128px" runat="server"
					Width="264px" Height="268px" AllowPaging="True" BorderColor="LightGray" CellSpacing="1" BorderWidth="1px"
					AutoGenerateColumns="False">
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="#FF0066" VerticalAlign="Middle"
						BackColor="#009999"></HeaderStyle>
					<FooterStyle ForeColor="#FF0033"></FooterStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="RoomId" HeaderText="编号"></asp:BoundColumn>
						<asp:BoundColumn DataField="RoomName" HeaderText="教室名称"></asp:BoundColumn>
						<asp:BoundColumn DataField="RoomSize" HeaderText="教室大小"></asp:BoundColumn>
						<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
					<PagerStyle NextPageText="下一页" PrevPageText="上一页" ForeColor="#FF0066"></PagerStyle>
				</asp:DataGrid>
				<asp:Label id="Label3" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 328px" runat="server">增加教室：</asp:Label>
				<asp:TextBox id="txtRoomName" style="Z-INDEX: 106; LEFT: 152px; POSITION: absolute; TOP: 368px"
					runat="server"></asp:TextBox>
				<asp:TextBox id="txtRoomSize" style="Z-INDEX: 107; LEFT: 152px; POSITION: absolute; TOP: 416px"
					runat="server"></asp:TextBox>
				<asp:Button id="btnAddRoom" style="Z-INDEX: 108; LEFT: 152px; POSITION: absolute; TOP: 464px"
					runat="server" Text="增加教室" Width="88px"></asp:Button>
				<asp:LinkButton id="lkbView" style="Z-INDEX: 109; LEFT: 152px; POSITION: absolute; TOP: 160px" runat="server">查看</asp:LinkButton>
				<asp:DropDownList id="ddlBuilding" style="Z-INDEX: 110; LEFT: 152px; POSITION: absolute; TOP: 128px"
					runat="server" Width="154px"></asp:DropDownList>
				<asp:Label id="Label1" style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 128px" runat="server">已有教学楼：</asp:Label>
				<asp:Label id="Label5" style="Z-INDEX: 112; LEFT: 64px; POSITION: absolute; TOP: 376px" runat="server">教室名称：</asp:Label>
				<asp:Label id="Label6" style="Z-INDEX: 113; LEFT: 64px; POSITION: absolute; TOP: 416px" runat="server">容纳人数：</asp:Label>
				<uc1:AdminHeaderControl id="AdminHeaderControl1" runat="server"></uc1:AdminHeaderControl>
				<asp:LinkButton id="lkbDeleteBuilding" style="Z-INDEX: 115; LEFT: 152px; POSITION: absolute; TOP: 184px"
					runat="server">删除</asp:LinkButton>
				<asp:Label id="Label4" style="Z-INDEX: 116; LEFT: 192px; POSITION: absolute; TOP: 192px" runat="server"
					Width="152px" Font-Size="Smaller">(注：删除教学楼前需先删除该教学楼所有教室！）</asp:Label></FONT>
		</form>
	</body>
</HTML>

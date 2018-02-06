<%@ Register TagPrefix="uc1" TagName="AdminHeaderControl" Src="AdminHeaderControl.ascx" %>
<%@ Page language="c#" Codebehind="AdminUser.aspx.cs" AutoEventWireup="false" Inherits="sc.AdminUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdminUser</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:AdminHeaderControl id="AdminHeaderControl1" runat="server"></uc1:AdminHeaderControl>
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 128px" runat="server">教师编号：</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 168px" runat="server">教师姓名：</asp:Label>
			<asp:TextBox id="txtTId" style="Z-INDEX: 103; LEFT: 112px; POSITION: absolute; TOP: 128px" runat="server"></asp:TextBox>
			<asp:TextBox id="txtTName" style="Z-INDEX: 104; LEFT: 112px; POSITION: absolute; TOP: 168px"
				runat="server"></asp:TextBox>
			<asp:Button id="btnAddTearcher" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 208px"
				runat="server" Text="添加老师" Width="96px"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 106; LEFT: 464px; POSITION: absolute; TOP: 128px" runat="server">学生学号：</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 107; LEFT: 464px; POSITION: absolute; TOP: 168px" runat="server">学生姓名：</asp:Label>
			<asp:TextBox id="txtSId" style="Z-INDEX: 108; LEFT: 560px; POSITION: absolute; TOP: 128px" runat="server"></asp:TextBox>
			<asp:TextBox id="txtSName" style="Z-INDEX: 109; LEFT: 560px; POSITION: absolute; TOP: 160px"
				runat="server"></asp:TextBox>
			<asp:Button id="btnAddStudent" style="Z-INDEX: 110; LEFT: 472px; POSITION: absolute; TOP: 208px"
				runat="server" Text="添加学生" Width="88px"></asp:Button>
			<asp:DataGrid id="dgViewT" style="Z-INDEX: 111; LEFT: 32px; POSITION: absolute; TOP: 248px" runat="server"
				Width="312px" Height="322px" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White"
				CellPadding="4" AutoGenerateColumns="False" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="TId" HeaderText="教师编号"></asp:BoundColumn>
					<asp:BoundColumn DataField="TName" HeaderText="教师姓名"></asp:BoundColumn>
					<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:DataGrid id="dgViewS" style="Z-INDEX: 112; LEFT: 448px; POSITION: absolute; TOP: 248px" runat="server"
				Width="320px" Height="282px" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" BackColor="White"
				CellPadding="4" AutoGenerateColumns="False" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="SId" HeaderText="学生学号"></asp:BoundColumn>
					<asp:BoundColumn DataField="SName" HeaderText="学生姓名"></asp:BoundColumn>
					<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>

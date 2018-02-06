<%@ Register TagPrefix="uc1" TagName="TeacherHeadControl" Src="TeacherHeadControl.ascx" %>
<%@ Page language="c#" Codebehind="SC.aspx.cs" AutoEventWireup="false" Inherits="sc.SC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:teacherheadcontrol id="TeacherHeadControl1" runat="server"></uc1:teacherheadcontrol>
			<asp:datagrid id="dgSC" style="Z-INDEX: 101; LEFT: 136px; POSITION: absolute; TOP: 248px" runat="server"
				Width="664px" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" BackColor="White"
				BorderWidth="1px" BorderStyle="None" BorderColor="#3366CC">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="SId" ReadOnly="True" HeaderText="学号"></asp:BoundColumn>
					<asp:BoundColumn DataField="SName" ReadOnly="True" HeaderText="姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="Score" HeaderText="成绩"></asp:BoundColumn>
					<asp:EditCommandColumn ButtonType="PushButton" UpdateText="更新" HeaderText="修改成绩" CancelText="取消" EditText="修改成绩"></asp:EditCommandColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:label id="lbCId" style="Z-INDEX: 102; LEFT: 152px; POSITION: absolute; TOP: 216px" runat="server"
				Visible="False"></asp:label></form>
	</body>
</HTML>

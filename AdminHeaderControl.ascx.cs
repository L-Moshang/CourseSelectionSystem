namespace sc
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		AdminHeaderControl ��ժҪ˵����
	/// </summary>
	public class AdminHeaderControl : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.HyperLink hlkAdminUser;
        protected System.Web.UI.WebControls.HyperLink hlkLogout;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.HyperLink hlkAdmin;
        protected System.Web.UI.WebControls.HyperLink hlkAdminRoom;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            string id = (string)Session["Id"];
            if ( id == null )
                Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOTLOGIN.ToString());
            else if ( Int32.Parse(Session["Type"].ToString()) != 3 )
                Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOTADMIN.ToString());
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
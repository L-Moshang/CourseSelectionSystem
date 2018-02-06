namespace sc
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		TeacherHeadControl ��ժҪ˵����
	/// </summary>
	public class TeacherHeadControl : System.Web.UI.UserControl
	{
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
        protected System.Web.UI.WebControls.HyperLink HyperLink2;
        protected System.Web.UI.WebControls.HyperLink hlkQuit;
        protected System.Web.UI.HtmlControls.HtmlGenericControl DIV1;
        protected System.Web.UI.WebControls.HyperLink HyperLink4;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            string id = (string)Session["Id"];
            if ( id == null )
                Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOTLOGIN.ToString());
            int type = (int)Session["Type"];
            if (  type != 2 )
                Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOTTEACHER.ToString());
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

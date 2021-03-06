using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace sc
{
	/// <summary>
	/// 错误反馈页面
	/// </summary>
	public class Error : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label lbError;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
        protected System.Web.UI.WebControls.HyperLink HyperLink2;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            string codestring = Request.QueryString["code"];
            try
            {
                if(codestring!=null)
                    lbError.Text = ErrorInfo.Message(Int32.Parse(codestring));
                else
                    lbError.Text = "";
            }
            catch
            {
                lbError.Text = "";
            }
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}

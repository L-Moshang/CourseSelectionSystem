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
	/// ViewStudent 的摘要说明。
	/// </summary>
	public class ViewStudent : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label lbSId;
        protected System.Web.UI.WebControls.Label lbSCredit;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label lbSAge;
        protected System.Web.UI.WebControls.Label lbSSex;
        protected System.Web.UI.WebControls.Label lbSAddress;
        protected System.Web.UI.WebControls.Label lbSPhone;
        protected System.Web.UI.WebControls.Label lbSName;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                string sid = Request.QueryString["SId"].ToString();
                if ( sid != null )
                {
                    string sql = "select * from Student where SId like '"+sid+"'";
                    DataSet ds = Db.ExecuteSelectSql(sql);
                    if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                    {
                        lbSId.Text = sid;
                        lbSName.Text = ds.Tables[0].Rows[0]["SName"].ToString();
                        lbSSex.Text = ds.Tables[0].Rows[0]["SSex"].ToString();
                        lbSAge.Text = ds.Tables[0].Rows[0]["SAge"].ToString();
                        lbSAddress.Text = ds.Tables[0].Rows[0]["SAdress"].ToString();
                        lbSCredit.Text = ds.Tables[0].Rows[0]["SCredit"].ToString();
                        lbSPhone.Text = ds.Tables[0].Rows[0]["SPhone"].ToString();
                    }
                }
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

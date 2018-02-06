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
	/// ViewStudent ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion
	}
}
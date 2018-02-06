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
	/// ViewCourse ��ժҪ˵����
	/// </summary>
	public class ViewCourse : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.TextBox txtCNote;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label lbCId;
        protected System.Web.UI.WebControls.Label lbCMax;
        protected System.Web.UI.WebControls.Label lbPreCName;
        protected System.Web.UI.WebControls.Label lbCCredit;
        protected System.Web.UI.WebControls.Label lbCType;
        protected System.Web.UI.WebControls.Label lbCName;
        protected System.Web.UI.WebControls.Label Label4;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            if ( ! IsPostBack )
            {
                string cid = Request.QueryString["CId"];
                if ( cid != null )
                {
                    string sql = "select x.*,(select CName from Course as y where y.CId = x.CPreCId) as CPreCName from Course as x where x.CId = "+cid;
                    DataSet ds = Db.ExecuteSelectSql(sql);
                    if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                    {
                        lbCId.Text = cid;
                        lbCName.Text = ds.Tables[0].Rows[0]["CName"].ToString();
                        lbPreCName.Text = ds.Tables[0].Rows[0]["CPreCName"].ToString();
                        lbCMax.Text = ds.Tables[0].Rows[0]["CMax"].ToString();
                        lbCCredit.Text = ds.Tables[0].Rows[0]["CCredit"].ToString();
                        lbCType.Text = ds.Tables[0].Rows[0]["CType"].ToString();
                        txtCNote.Text = ds.Tables[0].Rows[0]["CNote"].ToString();
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

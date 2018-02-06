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
	/// Student ��ժҪ˵����
	/// </summary>
	public class Student : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label lbSId;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label lbSCredit;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.TextBox txtSName;
        protected System.Web.UI.WebControls.DropDownList ddlSSex;
        protected System.Web.UI.WebControls.TextBox txtSAge;
        protected System.Web.UI.WebControls.TextBox txtSAddress;
        protected System.Web.UI.WebControls.TextBox txtSPhone;
        protected System.Web.UI.WebControls.Button btnUpdate;
        protected System.Web.UI.WebControls.TextBox txtKey;
        protected System.Web.UI.WebControls.TextBox txtKeyConfirm;
        protected System.Web.UI.WebControls.Button btnUpdateKey;
        protected System.Web.UI.WebControls.Label Label9;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
            if ( ! IsPostBack )
            {
                string sql = "select * from Student where SId like '"+Session["Id"].ToString()+"'";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                {
                    lbSId.Text = Session["Id"].ToString();
                    txtSName.Text = ds.Tables[0].Rows[0]["SName"].ToString();
                    if ( ds.Tables[0].Rows[0]["SSex"].ToString() == "��" )
                        ddlSSex.SelectedIndex = 0;
                    else
                        ddlSSex.SelectedIndex = 1;
                    txtSAge.Text = ds.Tables[0].Rows[0]["SAge"].ToString();
                    txtSAddress.Text = ds.Tables[0].Rows[0]["SAddress"].ToString();
                    txtSPhone.Text = ds.Tables[0].Rows[0]["SPhone"].ToString();
                    lbSCredit.Text = ds.Tables[0].Rows[0]["SCredit"].ToString();
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
            this.btnUpdateKey.Click += new System.EventHandler(this.btnUpdateKey_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                int age = Int32.Parse(txtSAge.Text.Trim());
            }
            catch
            {
                Response.Write(MyUtility.Alert("����ȷ�������䣡"));
                return;
            }
            string sql = "update Student set SName = '"+txtSName.Text.Trim()+"'"+
                ",SSex = '"+ddlSSex.SelectedItem.Text+"'"+
                ",SAge = "+txtSAge.Text.Trim()+
                ",SAddress = '"+txtSAddress.Text.Trim()+"'"+
                ",SPhone = '"+txtSPhone.Text.Trim()+"'"+
                " where SId like '"+Session["Id"].ToString()+"'";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("�޸ĳɹ���"));
            else
                Response.Write(MyUtility.Alert("�޸�ʧ�ܣ�"));
        }

        private void btnUpdateKey_Click(object sender, System.EventArgs e)
        {
            if ( txtKey.Text.Trim() != txtKeyConfirm.Text.Trim() )
            {
                Response.Write(MyUtility.Alert("�����������벻�����"));
                return;
            }
            string sql = "update Student set SKey = '"+MyUtility.MD5(txtKey.Text.Trim())+"' where SId = '"+Session["Id"].ToString()+"'";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("�޸ĳɹ���"));
            else
                Response.Write(MyUtility.Alert("�޸�ʧ�ܣ�"));;
        }
	}
}

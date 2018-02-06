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
	/// Student 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                string sql = "select * from Student where SId like '"+Session["Id"].ToString()+"'";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                {
                    lbSId.Text = Session["Id"].ToString();
                    txtSName.Text = ds.Tables[0].Rows[0]["SName"].ToString();
                    if ( ds.Tables[0].Rows[0]["SSex"].ToString() == "男" )
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
                Response.Write(MyUtility.Alert("请正确输入年龄！"));
                return;
            }
            string sql = "update Student set SName = '"+txtSName.Text.Trim()+"'"+
                ",SSex = '"+ddlSSex.SelectedItem.Text+"'"+
                ",SAge = "+txtSAge.Text.Trim()+
                ",SAddress = '"+txtSAddress.Text.Trim()+"'"+
                ",SPhone = '"+txtSPhone.Text.Trim()+"'"+
                " where SId like '"+Session["Id"].ToString()+"'";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("修改成功！"));
            else
                Response.Write(MyUtility.Alert("修改失败！"));
        }

        private void btnUpdateKey_Click(object sender, System.EventArgs e)
        {
            if ( txtKey.Text.Trim() != txtKeyConfirm.Text.Trim() )
            {
                Response.Write(MyUtility.Alert("两次输入密码不相符合"));
                return;
            }
            string sql = "update Student set SKey = '"+MyUtility.MD5(txtKey.Text.Trim())+"' where SId = '"+Session["Id"].ToString()+"'";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("修改成功！"));
            else
                Response.Write(MyUtility.Alert("修改失败！"));;
        }
	}
}

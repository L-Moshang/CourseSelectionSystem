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
	/// Teacher 的摘要说明。
	/// </summary>
	public class Teacher : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label lbTId;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Button btnUpdate;
        protected System.Web.UI.WebControls.TextBox txtTName;
        protected System.Web.UI.WebControls.DropDownList ddlTSex;
        protected System.Web.UI.WebControls.TextBox txtTPhone;
        protected System.Web.UI.WebControls.TextBox txtKey;
        protected System.Web.UI.WebControls.TextBox txtTAge;
        protected System.Web.UI.WebControls.TextBox txtKeyConfirm;
        protected System.Web.UI.WebControls.TextBox txtTMail;
        protected System.Web.UI.WebControls.Button btnUpdatekey;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                lbTId.Text = Session["Id"].ToString();
                ddlTSex.Items.Clear();
                ddlTSex.Items.Add("男");
                ddlTSex.Items.Add("女");
                string sql = "select * from Teacher where TId like '"+lbTId.Text.Trim()+"'";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                {
                    txtTName.Text = ds.Tables[0].Rows[0]["TName"].ToString();
                    txtTAge.Text = ds.Tables[0].Rows[0]["TAge"].ToString();
                    txtTPhone.Text = ds.Tables[0].Rows[0]["TPhone"].ToString();
                    txtTMail.Text = ds.Tables[0].Rows[0]["TMail"].ToString();
                    if ( ds.Tables[0].Rows[0]["TSex"].ToString() == "男" )
                        ddlTSex.SelectedIndex = 0;
                    else
                        ddlTSex.SelectedIndex = 1;
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
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdatekey.Click += new System.EventHandler(this.btnUpdatekey_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                int age = Int32.Parse(txtTAge.Text.Trim());
            }
            catch
            {
                Response.Write(MyUtility.Alert("年龄输入错误"));
                return;
            }
            string sql = "update Teacher set TName = '"+txtTName.Text.Trim()+
                "',TAge = "+txtTAge.Text.Trim()+
                ",TSex = '"+ddlTSex.SelectedItem.Text+
                "',TPhone = '"+txtTPhone.Text.Trim()+
                "',TMail = '"+txtTMail.Text.Trim()+
                "' where TId = '"+Session["Id"].ToString()+"'";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("修改成功！"));
            return;
        }

        private void btnUpdatekey_Click(object sender, System.EventArgs e)
        {
            if ( txtKey.Text.Trim() != txtKeyConfirm.Text.Trim() )
            {
                Response.Write(MyUtility.Alert("两次输入密码不相符合"));
                return;
            }
            string sql = "update Teacher set TKey = '"+MyUtility.MD5(txtKey.Text.Trim())+"' where TId = '"+Session["Id"].ToString()+"'";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("修改成功！"));
            else
                Response.Write(MyUtility.Alert("修改失败！"));
        }
	}
}

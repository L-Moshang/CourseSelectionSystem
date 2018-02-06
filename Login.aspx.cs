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
using System.Data.SqlClient;
using System.Configuration;

namespace sc
{
	/// <summary>
	/// WebForm1 的摘要说明。
	/// </summary>
	public class Login : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.TextBox txtKey;
        protected System.Web.UI.WebControls.DropDownList ddlType;
        protected System.Web.UI.WebControls.Button btnLogin;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Image Image1;
        protected System.Web.UI.WebControls.TextBox txtUser;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            int chk = MyUtility.CheckTime();
            if ( chk < 0 )
                Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_SCTIMEEARLY.ToString());
            else if ( chk > 0 )
                Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_SCTIMELATE.ToString());
//            string sql = " update Admin set AKey = '"+MyUtility.MD5("admin")+"'";
//            Db.ExecuteSql(sql);
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
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            int type = Int32.Parse(ddlType.SelectedItem.Value);
            string user = txtUser.Text.Trim();
            string inputkey = txtKey.Text.Trim();
            string key = "";
            string sql = "";
            DataSet ds;
            switch( type )
            {
                case    1://学生
                    sql = "select SKey from Student where SId like '"+user+"'";
                    ds = Db.ExecuteSelectSql(sql);
                    if ( ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0&&!ds.Tables[0].Rows[0].IsNull(0) )
                    {
                        key = ds.Tables[0].Rows[0][0].ToString();
                        if ( MyUtility.MD5(inputkey) == key )//密码正确登陆成功
                        {
                            Session["Id"] = user;
                            Session["Type"] = type;
                            //Response.Write(MyUtility.Alert("学生"+user+"登陆成功"));
                            Response.Redirect("StudentMain.aspx");
                        }
                        else//密码错误
                        {
                            Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_KEYERROR.ToString());
                        }
                    }
                    else//不存在该学生
                    {
                        Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOSTUDENT.ToString());
                    }
                    break;
                case    2://教师
                    sql = "select TKey from Teacher where TId like '"+user+"'";
                    ds = Db.ExecuteSelectSql(sql);
                    if(ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0&&!ds.Tables[0].Rows[0].IsNull(0))
                    {
                        key = ds.Tables[0].Rows[0][0].ToString();
                        if ( MyUtility.MD5(inputkey) == key )//密码正确登陆成功
                        {
                            Session["Id"] = user;
                            Session["Type"] = type;
                            //Response.Write(MyUtility.Alert("教师"+user+"登陆成功"));
                            Response.Redirect("TeacherMain.aspx");
                        }
                        else
                        {
                            Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_KEYERROR.ToString());
                        }
                    }
                    else
                    {
                        Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOTEACHER.ToString());
                    }
                    break;
                case    3://系统管理员
                    sql = "select AKey from Admin where AId like '"+user+"'";
                    ds = Db.ExecuteSelectSql(sql);
                    if(ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0&&!ds.Tables[0].Rows[0].IsNull(0))
                    {
                        key = ds.Tables[0].Rows[0][0].ToString();
                        if ( MyUtility.MD5(inputkey) == key )//密码正确登陆成功
                        {
                            Session["Id"] = user;
                            Session["Type"] = type;
                            //Response.Write(MyUtility.Alert("系统管理员"+user+"登陆成功"));
                            Response.Redirect("Admin.aspx");
                        }
                        else//密码错误
                        {
                            Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_KEYERROR.ToString());
                        }
                    }
                    else//不存在该系统管理员
                    {
                        Response.Redirect("Error.aspx?code="+ErrorInfo.ERR_NOADMIN.ToString());
                    }
                    break;
                default:
                    break;
            }
        }
	}
}

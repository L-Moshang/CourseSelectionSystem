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
	/// SelectedCourse 的摘要说明。
	/// </summary>
	public class SelectedCourse : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label lbLock;
        protected System.Web.UI.WebControls.Button btnLock;
        protected System.Web.UI.WebControls.DataGrid dgCourse;
        protected System.Web.UI.WebControls.Label Label1;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                string sql = "select Course.CName,Course.CCredit,Course.CType,Teacher.TName,Teacher.TId,SC.* from SC,Teacher,Course where SC.SId like '"+Session["Id"].ToString()+"' and SC.CId = Course.CId and Course.TId like Teacher.TId";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 )
                {
                    dgCourse.DataSource = ds.Tables[0];
                    dgCourse.DataBind();
                }
                bool locked= bool.Parse(Session["Locked"].ToString());
                if ( ! locked )
                {
                    lbLock.Text = "您尚未锁定选课信息！";
                    btnLock.Visible = true;
                }
                else
                {
                    lbLock.Text = "选课信息已被锁定！";
                    Label1.Text = "您所要学习的课程（必修和选修的）:";
                    btnLock.Visible = false;
                    dgCourse.Columns[7].Visible = false;
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
            this.dgCourse.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCourse_DeleteCommand);
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void dgCourse_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            string cId = dgCourse.Items[index].Cells[0].Text;
            string sql = "delete from SC where SId like '"+Session["Id"].ToString()+"' and CId = "+cId;
            Db.ExecuteSelectSql(sql);
            sql = "select Course.CName,Course.CCredit,Course.CType,Teacher.TName,Teacher.TId,SC.* from SC,Teacher,Course where SC.SId like '"+Session["Id"].ToString()+"' and SC.CId = Course.CId and Course.TId like Teacher.TId";
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgCourse.DataSource = ds.Tables[0];
                dgCourse.DataBind();
            }
        }

        private void btnLock_Click(object sender, System.EventArgs e)
        {
            string sql = "select count(*) from SC where SId like '"+Session["Id"].ToString()+"'";
            DataSet ds = Db.ExecuteSelectSql(sql);
            int nCourse=0;
            if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
            {
                nCourse = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            if ( nCourse < 2 )
            {
                Response.Write(MyUtility.Alert("您必须选择至少两门选修课程!"));
                return;
            }
            else
            {
                //先将所有必修课程加入到选课表中再锁定
                sql = "select CId from Course where CType = '必修'";
                DataSet ds2 = Db.ExecuteSelectSql(sql);
                if ( ds2 != null && ds2.Tables.Count > 0 )
                {
                    for ( int i = 0; i < ds2.Tables[0].Rows.Count; i++ )
                    {
                        string cid = ds2.Tables[0].Rows[i][0].ToString();
                        sql = "insert into SC(SId,CId,Score) values('"+Session["Id"].ToString()+"',"+cid+",0)";
                        Db.ExecuteSql(sql);
                    }
                }
                sql = "update Student set SLocked = 1 where SId like '"+Session["Id"].ToString()+"'";
                if ( Db.ExecuteSql(sql) == 1 )
                {
                    lbLock.Text = "选课信息已被锁定！";
                    Session["Locked"] = "true";
                    Response.Redirect("Selectedcourse.aspx");
                }
            }
        }
	}
}

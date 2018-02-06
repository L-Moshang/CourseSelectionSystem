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
	/// TeacherMain 的摘要说明。
	/// </summary>
	public class TeacherMain : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid dgCourse;
        protected System.Web.UI.WebControls.Label lbCount;
        protected System.Web.UI.WebControls.Label Label1;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                string sql = "select x.*,(select CName from Course as y where y.CId = x.CPreCId) as CPreCName from Course as x where x.TId like '"+Session["Id"].ToString()+"'";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 )
                {
                    if ( ds.Tables[0].Rows.Count > 0 )
                    {
                        lbCount.Text = "您一共开设有 "+ds.Tables[0].Rows.Count.ToString()+" 门课程!";
                        dgCourse.DataSource = ds.Tables[0];
                        dgCourse.DataBind(); 
                        for ( int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                        {
                            if ( dgCourse.Items[i].Cells[3].Text == "必修" )
                                dgCourse.Items[i].Cells[8].Text = "必修";
                            else
                            {
                                sql = "select count(*) from SC where CId = "+ds.Tables[0].Rows[i]["CId"].ToString();
                                DataSet ds1 = Db.ExecuteSelectSql(sql);
                                if ( ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 )
                                    dgCourse.Items[i].Cells[8].Text = ds1.Tables[0].Rows[0][0].ToString();
                            }
                        }
                    }
                    else
                    {
                        lbCount.Text = "您暂时还没有开设课程!";
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

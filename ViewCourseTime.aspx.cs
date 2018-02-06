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
	/// ViewCourseTime 的摘要说明。
	/// </summary>
	public class ViewCourseTime : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid dgTime;
        protected System.Web.UI.WebControls.Label lbCaption;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                int CId = 0;
                try
                {
                    CId = Int32.Parse( Request.QueryString["CId"] );
                }
                catch
                {
                    CId = 0;
                }
                if ( CId != 0 )
                {
                    string sql = "select CourseTime.*,Building.*,Room.RoomName from CourseTime,Building,Room where CId = "+CId.ToString()+" and CourseTime.RoomId = Room.RoomId and Room.BuildingId = Building.BuildingId";
                    DataSet ds = Db.ExecuteSelectSql(sql);
                    if ( ds != null && ds.Tables.Count > 0 )
                    {
                        dgTime.DataSource = ds.Tables[0];
                        dgTime.DataBind();
                        lbCaption.Text = lbCaption.Text = "该课程已有 "+ds.Tables[0].Rows.Count.ToString()+" 个时间段！";
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

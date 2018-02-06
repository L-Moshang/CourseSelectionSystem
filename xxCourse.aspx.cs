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
	/// xxCourse 的摘要说明。
	/// </summary>
	public class xxCourse : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid dgCourse;
        protected System.Web.UI.WebControls.Label lbLock;
        protected System.Web.UI.WebControls.Label Label1;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                string sql = "select x.*,TName,(select CName from Course as y where y.CId = x.CPreCId) as CPreCName from Course as x,Teacher where x.CType like '选修' and x.TId like Teacher.TId";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 )
                {
                    dgCourse.DataSource = ds.Tables[0];
                    dgCourse.DataBind();
                    for ( int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                    {
                        sql = "select count(*) from SC where CId = "+ds.Tables[0].Rows[i]["CId"].ToString();
                        DataSet ds1 = Db.ExecuteSelectSql(sql);
                        if ( ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 )
                            dgCourse.Items[i].Cells[6].Text = ds1.Tables[0].Rows[0][0].ToString();
                    }
                }
                bool locked= bool.Parse(Session["Locked"].ToString());
                if ( ! locked )
                {
                    lbLock.Text = "您尚未锁定选课信息！";
                }
                else
                {
                    lbLock.Text = "选课信息已被锁定！";
                    dgCourse.Columns[9].Visible = false;
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
            this.dgCourse.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgCourse_ItemCommand);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void dgCourse_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if ( e.CommandName == "Select" )
            {
                string cid = e.Item.Cells[0].Text;
                string sql = "select * from SC where CId = "+cid+" and SId like '"+Session["Id"].ToString()+"'";
                DataSet ds = Db.ExecuteSelectSql(sql);
                bool flag = false;             //是否已经选修过了
                if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                    flag = true;
                if ( flag )
                {
                    Response.Write(MyUtility.Alert("您已经选了该课程了！"));
                    return;
                }
                else
                {
                    sql = "select CPreCId from Course where CId = "+cid;
                    DataSet ds1 = Db.ExecuteSelectSql(sql);
                    if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                    {
                        string cpcid = ds.Tables[0].Rows[0][0].ToString();
                        bool flag2 = false; //前导课程判断标志
                        //判断前导课程是否是必修课
                        sql = "select CType from Course where CId = "+cpcid;
                        DataSet ds2 = Db.ExecuteSelectSql(sql);
                        if ( ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0 )
                        {
                            if ( ds2.Tables[0].Rows[0][0].ToString() == "必修" )
                                flag2 = true;
                        }
                        else
                        {
                            //判断是否在已经选择的选修课中
                            sql = "select * from SC where SId like '"+Session["Id"].ToString()+"' and CId = "+cpcid;
                            DataSet ds3 = Db.ExecuteSelectSql(sql);
                            if ( ds3 != null && ds3.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                                flag2 = true;
                        }
                        if ( flag2 )
                        {//有前导课程，但前导课程是必修课或者已经选择了选修课程
                            SelectCourse(Int32.Parse(cid));
                            return;
                        }
                        else
                        {//有前导课程，前导课程不是是必修课，也不是已经选择了的选修课程，不能选
                            Response.Write(MyUtility.Alert("请先选择该课程的前导课程"));
                            return;
                        }
                    }
                    else //没有前导课程
                    {
                        SelectCourse(Int32.Parse(cid));
                    }
                }
            }
        }

        private void SelectCourse(int cid)
        {
            int max=0,current=0;
            string sql = "select CMax from Course where CId = "+cid.ToString();
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                max = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            else
                return;
            sql = "select count(*) from SC where SId like '"+Session["Id"].ToString()+"' and CId = "+cid.ToString();
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 )
                current = Int32.Parse(ds1.Tables[0].Rows[0][0].ToString());
            else
                return;
            if ( current > max )
            {
                Response.Write(MyUtility.Alert("人数已满！"));
                return;
            }
            sql = "insert into SC values('"+Session["Id"].ToString()+"',"+cid+",0)";
            if ( Db.ExecuteSql(sql) == 1 )
                Response.Write(MyUtility.Alert("选课成功"));
            else
                Response.Write(MyUtility.Alert("选课失败"));
        }
	}
}

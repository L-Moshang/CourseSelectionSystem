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
	/// WebForm1 的摘要说明。
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label Label13;
        protected System.Web.UI.WebControls.DropDownList ddlRoom;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.DropDownList ddlBuilding;
        protected System.Web.UI.WebControls.Label lbTime2;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.DropDownList ddlCWeekEnd;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.DropDownList ddlCWeekStart;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label lbCaption;
        protected System.Web.UI.WebControls.DataGrid dgTime;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.LinkButton lkbAddTime;
        protected System.Web.UI.WebControls.Button btnAddTime;
        protected System.Web.UI.WebControls.DropDownList ddlWeek;
        protected System.Web.UI.WebControls.DropDownList ddlTime;
    
        private static int CId = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
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
                    else
                        lbCaption.Text = "该课程还没有设置上课时间地点！请尽快设置！";
                }

                Label13.Visible = false;
                ddlRoom.Visible = false;
                Label9.Visible = false;
                ddlBuilding.Visible = false;
                lbTime2.Visible = false;
                Label10.Visible = false;
                ddlCWeekEnd.Visible = false;
                Label11.Visible = false;
                ddlCWeekStart.Visible = false;
                Label12.Visible = false;
                Label5.Visible = false;
                btnAddTime.Visible = false;
                ddlWeek.Visible = false;
                ddlTime.Visible = false;
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
            this.ddlCWeekStart.SelectedIndexChanged += new System.EventHandler(this.ddlCWeekStart_SelectedIndexChanged);
            this.ddlBuilding.SelectedIndexChanged += new System.EventHandler(this.ddlBuilding_SelectedIndexChanged);
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            this.dgTime.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTime_DeleteCommand);
            this.lkbAddTime.Click += new System.EventHandler(this.lkbAddTime_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void lkbAddTime_Click(object sender, System.EventArgs e)
        {
            //教学楼
            ddlBuilding.Items.Clear();
            ddlBuilding.Items.Add("请选择");
            string sql = "select BuildingId,BuildingName from Building";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                for ( int i = 0; i < ds1.Tables[0].Rows.Count; i++ )
                    ddlBuilding.Items.Add( new ListItem( ds1.Tables[0].Rows[i]["BuildingName"].ToString(), ds1.Tables[0].Rows[i]["BuildingId"].ToString() ) );
            }
            ddlBuilding.SelectedIndex = 0;

            //教室
            ddlRoom.Items.Clear();
            ddlRoom.Items.Add("请选择");
            ddlRoom.SelectedIndex = 0;

            //开始周次
            ddlCWeekStart.Items.Clear();
            ddlCWeekStart.Items.Add("请选择");
            for ( int i = 1; i <= 22; i++ )
                ddlCWeekStart.Items.Add( i.ToString() );
            ddlCWeekStart.SelectedIndex = 0;

            //结束周次
            ddlCWeekEnd.Items.Clear();
            ddlCWeekEnd.Items.Add("请选择");
            ddlCWeekEnd.SelectedIndex = 0;

            //第一次课时间，第二次课时间
            ddlWeek.Items.Clear();  
            ddlWeek.Items.Add("请选择");
            for ( int i = 1; i <= 7; i++ )
            {
                if ( i == 7 )
                {
                    ddlWeek.Items.Add( new ListItem( "星期天", "7") );
                }
                else
                {
                    ddlWeek.Items.Add( new ListItem( "星期"+i.ToString(), i.ToString() ) ) ;
                }
            }
            ddlWeek.SelectedIndex = 0;

            ddlTime.Items.Clear();
            ddlTime.Items.Add("请选择");
            for ( int i = 1; i <= 6; i++ )
            {
                int t1 = 2 * i - 1;
                int t2 = 2 * i;
                ddlTime.Items.Add( new ListItem("第"+t1.ToString()+"-"+t2.ToString()+"节课", t1.ToString()+t2.ToString() ) );
            }
            ddlTime.SelectedIndex = 0;

            Label13.Visible = true;
            ddlRoom.Visible = true;
            Label9.Visible = true;
            ddlBuilding.Visible = true;
            lbTime2.Visible = true;
            Label10.Visible = true;
            ddlCWeekEnd.Visible = true;
            Label11.Visible = true;
            ddlCWeekStart.Visible = true;
            Label12.Visible = true;
            Label5.Visible = true;
            btnAddTime.Visible = true;
            ddlWeek.Visible = true;
            ddlTime.Visible = true;
        }

        private void ddlCWeekStart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ( ddlCWeekStart.SelectedIndex > 0 )
            {
                ddlCWeekEnd.Items.Clear();
                ddlCWeekEnd.Items.Add("请选择");
                int start = Int32.Parse(ddlCWeekStart.SelectedItem.Value);
                for ( int i = start; i <= 23; i++ )
                    ddlCWeekEnd.Items.Add( i.ToString() );
                ddlCWeekEnd.SelectedIndex = 0;
            }
        }

        private void ddlBuilding_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ( ddlBuilding.SelectedIndex > 0 )
            {
                ddlRoom.Items.Clear();
                ddlRoom.Items.Add("请选择");
                string sql = "select * from Room where BuildingId = "+ddlBuilding.SelectedItem.Value;
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 )
                {
                    
                    for ( int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                        ddlRoom.Items.Add( new ListItem(ds.Tables[0].Rows[i]["RoomName"].ToString()+"(容纳"+ds.Tables[0].Rows[i]["RoomSize"].ToString()+"人)", ds.Tables[0].Rows[i]["RoomId"].ToString() ) );
                }
                ddlRoom.SelectedIndex = 0;
            }
        }

        private void btnAddTime_Click(object sender, System.EventArgs e)
        {
            #region check input
            if ( ddlBuilding.SelectedIndex <= 0 )
            {
                Response.Write( MyUtility.Alert("请选择课的教学楼！") );
                return;
            }
            if ( ddlRoom.SelectedIndex <= 0 )
            {
                Response.Write( MyUtility.Alert("请选择课的教室！") );
                return;
            }
            if ( ddlCWeekStart.SelectedIndex <= 0 )
            {
                Response.Write( MyUtility.Alert("请选择课程开始周次！") );
                return;
            }
            if ( ddlCWeekEnd.SelectedIndex <= 0 )
            {
                Response.Write( MyUtility.Alert("请选择课程结束周次！") );
                return;
            }
            if ( ddlWeek.SelectedIndex <= 0 || ddlTime.SelectedIndex <= 0 )
            {
                Response.Write( MyUtility.Alert("请选择上课的时间！") );
                return;
            }
            #endregion

            string sql = "select * from CourseTime where RoomId = "+ddlRoom.SelectedItem.Value+" and CTime like '"+ddlWeek.SelectedItem.Text+ddlTime.SelectedItem.Text+"'";
            DataSet ds = Db.ExecuteSelectSql(sql);
            bool flag = true;
            if ( ds != null && ds.Tables.Count > 0 )
            {
                int ws = Int32.Parse(ddlCWeekStart.SelectedItem.Text);
                int we = Int32.Parse(ddlCWeekEnd.SelectedItem.Text);
                for ( int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                {
                    int nws = Int32.Parse(ds.Tables[0].Rows[i]["CWeekStart"].ToString());
                    int nwe = Int32.Parse(ds.Tables[0].Rows[i]["CWeekEnd"].ToString());
                    if ( we < nws || ws > nwe )
                        flag = true;
                    else
                        flag = false;
                }
            }
            if ( flag == false )
            {
                Response.Write(MyUtility.Alert("您选择的时间地点和其他课程有冲突，抱歉，请再次选择！"));
                return;
            }
            else
            {
                if ( CId != 0 )
                {
                    sql = "insert into CourseTime(CId,RoomId,CWeekStart,CWeekEnd,CTime) "+
                        "values("+CId.ToString()+
                        ","+ddlRoom.SelectedItem.Value+
                        ","+ddlCWeekStart.SelectedItem.Text+
                        ","+ddlCWeekEnd.SelectedItem.Text+
                        ",'"+ddlWeek.SelectedItem.Text+ddlTime.SelectedItem.Text+"')";
                    Db.ExecuteSql(sql);
                }   
            }

            Label13.Visible = false;
            ddlRoom.Visible = false;
            Label9.Visible = false;
            ddlBuilding.Visible = false;
            lbTime2.Visible = false;
            Label10.Visible = false;
            ddlCWeekEnd.Visible = false;
            Label11.Visible = false;
            ddlCWeekStart.Visible = false;
            Label12.Visible = false;
            Label5.Visible = false;
            btnAddTime.Visible = false;
            ddlWeek.Visible = false;
            ddlTime.Visible = false;

            sql = "select CourseTime.*,Building.*,Room.RoomName from CourseTime,Building,Room where CId = "+CId.ToString()+" and CourseTime.RoomId = Room.RoomId and Room.BuildingId = Building.BuildingId";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                dgTime.DataSource = ds1.Tables[0];
                dgTime.DataBind();
                lbCaption.Text = "该课程已有 "+ds1.Tables[0].Rows.Count.ToString()+" 个时间段！";
            }
            else
                lbCaption.Text = "该课程还没有设置上课时间地点！请尽快设置！";

        }

        private void dgTime_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            string sWeekStart = dgTime.Items[index].Cells[0].Text.Trim();
            string sWeekEnd = dgTime.Items[index].Cells[1].Text.Trim();
            string sRoomId = dgTime.Items[index].Cells[4].Text.Trim();
            string sTime = dgTime.Items[index].Cells[6].Text.Trim();
            string sql = "delete from CourseTime where CId = "+CId.ToString()+
                " and CWeekStart = "+sWeekStart+
                " and CWeekEnd = "+sWeekEnd+
                " and RoomId = "+sRoomId+
                " and CTime like '"+sTime+"'";
            Db.ExecuteSql(sql);

            sql = "select CourseTime.*,Building.*,Room.RoomName from CourseTime,Building,Room where CId = "+CId.ToString()+" and CourseTime.RoomId = Room.RoomId and Room.BuildingId = Building.BuildingId";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                dgTime.DataSource = ds1.Tables[0];
                dgTime.DataBind();
                lbCaption.Text = "该课程已有 "+ds1.Tables[0].Rows.Count.ToString()+" 个时间段！";
            }
            else
                lbCaption.Text = "该课程还没有设置上课时间地点！请尽快设置！";       
        }
	}
}

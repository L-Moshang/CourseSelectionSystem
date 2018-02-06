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
	/// AdminRoom 的摘要说明。
	/// </summary>
	public class AdminRoom : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.LinkButton lkbView;
        protected System.Web.UI.WebControls.TextBox txtBuilding;
        protected System.Web.UI.WebControls.Button btnAddBuilding;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.TextBox txtRoomName;
        protected System.Web.UI.WebControls.TextBox txtRoomSize;
        protected System.Web.UI.WebControls.Button btnAddRoom;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.DataGrid dgView;
        protected System.Web.UI.WebControls.DropDownList ddlBuilding;
        protected System.Web.UI.WebControls.LinkButton lkbDeleteBuilding;
        protected System.Web.UI.WebControls.Label Label4;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( !IsPostBack )
            {
                string sql = "select * from Building";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 )
                {
                    DataView dv = new DataView(ds.Tables[0]);
                    ddlBuilding.DataSource = dv;
                    ddlBuilding.DataTextField = "BuildingName";
                    ddlBuilding.DataValueField = "BuildingId";
                    ddlBuilding.DataBind();
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
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            this.dgView.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgView_PageIndexChanged);
            this.dgView.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgView_DeleteCommand);
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            this.lkbView.Click += new System.EventHandler(this.lkbView_Click);
            this.lkbDeleteBuilding.Click += new System.EventHandler(this.lkbDeleteBuilding_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void btnAddBuilding_Click(object sender, System.EventArgs e)
        {
            if ( txtBuilding.Text.Trim() == "" )
            {
                Response.Write(MyUtility.Alert("请输入教学楼名称！"));
                return;
            }
            string sql = "insert into Building(BuildingName) values('"+txtBuilding.Text.Trim()+"')";
            Db.ExecuteSql(sql);
            sql = "select * from Building";
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                DataView dv = new DataView(ds.Tables[0]);
                ddlBuilding.DataSource = dv;
                ddlBuilding.DataTextField = "BuildingName";
                ddlBuilding.DataValueField = "BuildingId";
                ddlBuilding.DataBind();
            }
        }

        private void lkbDeleteBuilding_Click(object sender, System.EventArgs e)
        {
            if ( ddlBuilding.SelectedIndex < 0 )
            {
                Response.Write(MyUtility.Alert("请选择一个教学楼！"));
                return;
            }
            string sql = "select count(*) from Room where BuildingId = "+ddlBuilding.SelectedItem.Value;
            DataSet ds = Db.ExecuteSelectSql(sql);
            int roomNum = 0;
            if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
            {
               roomNum = (int)ds.Tables[0].Rows[0][0];
            }
            if ( roomNum > 0 )
            {
                Response.Write(MyUtility.Alert("请先删除该教学楼所有教室！"));
                return;
            }
            else
            {
                sql = "delete from Building where BuildingId = "+ddlBuilding.SelectedItem.Value;
                Db.ExecuteSql(sql);
                sql = "select * from Building";
                DataSet ds2 = Db.ExecuteSelectSql(sql);
                if ( ds2 != null && ds2.Tables.Count > 0 )
                {
                    DataView dv = new DataView(ds2.Tables[0]);
                    ddlBuilding.DataSource = dv;
                    ddlBuilding.DataTextField = "BuildingName";
                    ddlBuilding.DataValueField = "BuildingId";
                    ddlBuilding.DataBind();
                }
            }
        }

        private void lkbView_Click(object sender, System.EventArgs e)
        {
            if ( ddlBuilding.SelectedIndex < 0 )
            {
                Response.Write(MyUtility.Alert("请选择一个教学楼！"));
                return;
            }
            dgView.DataSource = null;
            dgView.DataBind();
            string sql = "select RoomId,RoomName,RoomSize from Room where BuildingId = "+ddlBuilding.SelectedItem.Value;
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgView.DataSource = ds.Tables[0];
             
                dgView.DataBind();
            }
        }

        private void btnAddRoom_Click(object sender, System.EventArgs e)
        {
            if ( ddlBuilding.SelectedIndex < 0 )
            {
                Response.Write(MyUtility.Alert("请选择一个教学楼！"));
                return;
            }
            if ( txtRoomName.Text.Trim() == "" )
            {
                Response.Write(MyUtility.Alert("请选输入教室名称！"));
                return;
            }
            if ( txtRoomSize.Text.Trim() == "" )
            {
                Response.Write(MyUtility.Alert("请输入教室能容纳的人数！"));
                return;
            }
            int size = 0;
            try
            {
                size = Int32.Parse(txtRoomSize.Text.Trim());
            }
            catch
            {
                Response.Write(MyUtility.Alert("请输入正确的教室能容纳的人数！"));
                return;
            }
            string sql = "insert into Room(RoomName,BuildingId,RoomSize) values('"+txtRoomName.Text.Trim()+"',"+ddlBuilding.SelectedItem.Value+","+size.ToString()+")";
            Db.ExecuteSql(sql);
            sql = "select RoomId,RoomName,RoomSize from Room where BuildingId = "+ddlBuilding.SelectedItem.Value;
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgView.DataSource = ds.Tables[0];
                dgView.DataBind();
            }
        }

        //从Excel文件中导入
        private void LinkButton1_Click(object sender, System.EventArgs e)
        {
        
        }

        private void dgView_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            string sId = dgView.Items[index].Cells[0].Text;
            string sql = "delete from Room where RoomId = "+sId;
            Db.ExecuteSql(sql);
            sql = "select RoomId,RoomName,RoomSize from Room where BuildingId = "+ddlBuilding.SelectedItem.Value;
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgView.DataSource = ds.Tables[0];    
                dgView.DataBind();
            }
        }

        private void dgView_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgView.CurrentPageIndex = e.NewPageIndex;
            string sql = "select RoomId,RoomName,RoomSize from Room where BuildingId = "+ddlBuilding.SelectedItem.Value;
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgView.DataSource = ds.Tables[0];
                
                dgView.DataBind();
            }
            
        }

    }
}

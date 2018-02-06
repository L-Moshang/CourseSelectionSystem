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
	/// NewCourse 的摘要说明。
	/// </summary>
	public class NewCourse : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label lbTId;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.DropDownList ddlCType;
        protected System.Web.UI.WebControls.DropDownList ddlCCredit;
        protected System.Web.UI.WebControls.DropDownList ddlCPreCId;
        protected System.Web.UI.WebControls.DropDownList ddlCMax;
        protected System.Web.UI.WebControls.TextBox txtCNote;
        protected System.Web.UI.WebControls.Button btnAdd;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.TextBox txtCName;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                //课程类别
                ddlCType.Items.Clear();
                ddlCType.Items.Add("请选择");
                ddlCType.Items.Add("必修");
                ddlCType.Items.Add("选修");
                ddlCType.SelectedIndex = 0;

                //课程学分
                ddlCCredit.Items.Clear();
                ddlCCredit.Items.Add("请选择");
                ddlCCredit.Items.Add("1");
                ddlCCredit.Items.Add("1.5");
                ddlCCredit.Items.Add("2");
                ddlCCredit.Items.Add("2.5");
                ddlCCredit.Items.Add("3");
                ddlCCredit.Items.Add("3.5");
                ddlCCredit.Items.Add("4");
                ddlCCredit.Items.Add("4.5");
                ddlCCredit.Items.Add("5");
                ddlCCredit.Items.Add("5.5");
                ddlCCredit.Items.Add("6");
                ddlCType.SelectedIndex = 0;

                //课程最大人数
                ddlCMax.Items.Clear();
                ddlCMax.Items.Add("请选择");
                ddlCMax.Items.Add("50");
                ddlCMax.Items.Add("100");
                ddlCMax.Items.Add("150");
                ddlCMax.Items.Add("200");
                ddlCMax.SelectedIndex = 0;

                //前导课程
                ddlCPreCId.Items.Clear();
                ddlCPreCId.Items.Add("请选择");
                string sql = "select CId,CName from Course";
                DataSet ds = Db.ExecuteSelectSql(sql);
                if ( ds != null && ds.Tables.Count > 0 )
                {
                    for ( int i = 0; i < ds.Tables[0].Rows.Count; i++ )
                        ddlCPreCId.Items.Add( new ListItem( ds.Tables[0].Rows[i]["CName"].ToString(), ds.Tables[0].Rows[i]["CId"].ToString() ) );
                }
                ddlCPreCId.SelectedIndex = 0;

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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if ( txtCName.Text.Trim() == "" )
            {
                Response.Write(MyUtility.Alert("请输入课程名称！"));
                return;
            }
            if ( ddlCType.SelectedIndex <= 0 )
            {
                Response.Write(MyUtility.Alert("请选择课程类型！"));
                return;
            }
            if ( ddlCCredit.SelectedIndex <= 0 )
            {
                Response.Write(MyUtility.Alert("请选择课程学分！"));
                return;
            }
            if ( ddlCMax.SelectedIndex <= 0 )
            {
                Response.Write(MyUtility.Alert("请选择课程最大人数！"));
                return;
            }
            string sql;
            sql = "select count(*) from Course where TId like '"+Session["Id"].ToString()+"'";
            DataSet ds = Db.ExecuteSelectSql(sql);
            int nCourse = 0;
            if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >0 )
                nCourse = (int)ds.Tables[0].Rows[0][0];
            if ( nCourse >= 3 )
            {
                Response.Write(MyUtility.Alert("您已经开设了3门课程了！不能再开设了"));
                return;
            }
            if ( ddlCPreCId.SelectedIndex <= 0 )
            {
                sql = "insert into Course(TId,CName,CType,CCredit,CMax,CNote) values("+
                    Session["Id"].ToString()+
                    ",'"+txtCName.Text.Trim()+
                    "','"+ddlCType.SelectedItem.Text+
                    "',"+ddlCCredit.SelectedItem.Text+
                    ","+ddlCMax.SelectedItem.Text+
                    ",'"+MyUtility.Encode(txtCNote.Text)+"')";
            }
            else
            {
                sql = "insert into Course(TId,CName,CType,CCredit,CMax,CNote,CPreCId) values("+
                    Session["Id"].ToString()+
                    ",'"+txtCName.Text.Trim()+
                    "','"+ddlCType.SelectedItem.Text+
                    "',"+ddlCCredit.SelectedItem.Text+
                    ","+ddlCMax.SelectedItem.Text+
                    ",'"+MyUtility.Encode(txtCNote.Text)+
                    "',"+ddlCPreCId.SelectedItem.Value+")";
            }
            Db.ExecuteSql(sql);
            Response.Redirect("TeacherMain.aspx");
        }

      
	}
}

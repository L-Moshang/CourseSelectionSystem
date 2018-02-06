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
	/// AdminUser 的摘要说明。
	/// </summary>
	public class AdminUser : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.TextBox txtTId;
        protected System.Web.UI.WebControls.TextBox txtTName;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Button btnAddTearcher;
        protected System.Web.UI.WebControls.TextBox txtSId;
        protected System.Web.UI.WebControls.TextBox txtSName;
        protected System.Web.UI.WebControls.Button btnAddStudent;
        protected System.Web.UI.WebControls.DataGrid dgViewS;
        protected System.Web.UI.WebControls.DataGrid dgViewT;
    
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                string sql = "select * from Teacher";
                DataSet ds1 = Db.ExecuteSelectSql(sql);
                if ( ds1 != null && ds1.Tables.Count > 0 )
                {
                    dgViewT.DataSource = ds1.Tables[0];
                    dgViewT.DataBind();
                }
                sql = "select * from Student";
                DataSet ds2 = Db.ExecuteSelectSql(sql);
                if ( ds2 != null && ds2.Tables.Count > 0 )
                {
                    dgViewS.DataSource = ds2.Tables[0];
                    dgViewS.DataBind();
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
            this.btnAddTearcher.Click += new System.EventHandler(this.btnAddTearcher_Click);
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            this.dgViewT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgViewT_PageIndexChanged);
            this.dgViewT.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgViewT_DeleteCommand);
            this.dgViewS.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgViewS_PageIndexChanged);
            this.dgViewS.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgViewS_DeleteCommand);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void btnAddTearcher_Click(object sender, System.EventArgs e)
        {
            if ( txtTId.Text.Trim() == "" )
            {
                Response.Write( MyUtility.Alert("请输入教师编号！") );
                return;
            }
            if ( txtTName.Text.Trim() == "" )
            {
                Response.Write( MyUtility.Alert("请输入教师姓名！") );
                return;
            }
            string sql = "insert into Teacher(TId,TKey,TName) values('"+txtTId.Text.Trim()+"','"+MyUtility.MD5(txtTId.Text.Trim())+"','"+txtTName.Text.Trim()+"')";
            try
            {
                if ( Db.ExecuteSql(sql) == 1 )
                {
                    sql = "select * from Teacher";
                    DataSet ds1 = Db.ExecuteSelectSql(sql);
                    if ( ds1 != null && ds1.Tables.Count > 0 )
                    {
                        dgViewT.DataSource = ds1.Tables[0];
                        dgViewT.DataBind();
                    }
                }
                else
                {
                    Response.Write( MyUtility.Alert("添加失败-_-,请检查编号是否已经存在！") );
                    return;
                }
            }
            catch
            {
                Response.Write( MyUtility.Alert("添加失败-_-,请检查编号是否已经存在！") );
                return;
            }
        }

        private void btnAddStudent_Click(object sender, System.EventArgs e)
        {
            if ( txtSId.Text.Trim() == "" )
            {
                Response.Write( MyUtility.Alert("请输入学生学号！") );
                return;
            }
            if ( txtSName.Text.Trim() == "" )
            {
                Response.Write( MyUtility.Alert("请输入学生姓名！") );
                return;
            }
            string sql = "insert into Student(SId,SKey,SName,SCredit,SLocked) values('"+txtSId.Text.Trim()+"','"+MyUtility.MD5(txtSId.Text.Trim())+"','"+txtSName.Text.Trim()+"',0,0)";
            try
            {
                if ( Db.ExecuteSql(sql) == 1 )
                {
                    sql = "select * from Student";
                    DataSet ds1 = Db.ExecuteSelectSql(sql);
                    if ( ds1 != null && ds1.Tables.Count > 0 )
                    {
                        dgViewS.DataSource = ds1.Tables[0];
                        dgViewS.DataBind();
                    }
                }
                else
                {
                    Response.Write( MyUtility.Alert("添加失败-_-,请检查学号是否已经存在！") );
                    return;
                }
            }
            catch
            {
                Response.Write( MyUtility.Alert("添加失败-_-,请检查学号是否已经存在！") );
                return;
            }
        }

        private void dgViewT_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            string TId = dgViewT.Items[index].Cells[0].Text;
            string sql = "delete from Teacher where TId like '"+TId+"'";
            Db.ExecuteSql(sql);
            sql = "select * from Teacher";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                dgViewT.DataSource = ds1.Tables[0];
                dgViewT.DataBind();
            }
        }

        private void dgViewT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgViewT.CurrentPageIndex = e.NewPageIndex;
            string sql = "select * from Teacher";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                dgViewT.DataSource = ds1.Tables[0];
                dgViewT.DataBind();
            }
        }

        private void dgViewS_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            int index = e.Item.ItemIndex;
            string SId = dgViewS.Items[index].Cells[0].Text;
            string sql = "delete from Student where SId like '"+SId+"'";
            Db.ExecuteSql(sql);
            sql = "select * from Student";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                dgViewS.DataSource = ds1.Tables[0];
                dgViewS.DataBind();
            }
        }

        private void dgViewS_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgViewS.CurrentPageIndex = e.NewPageIndex;
            string sql = "select * from Student";
            DataSet ds1 = Db.ExecuteSelectSql(sql);
            if ( ds1 != null && ds1.Tables.Count > 0 )
            {
                dgViewS.DataSource = ds1.Tables[0];
                dgViewS.DataBind();
            }
        }
	}
}

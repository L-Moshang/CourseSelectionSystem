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
	/// SC 的摘要说明。
	/// </summary>
	public class SC : System.Web.UI.Page
	{
        protected System.Web.UI.WebControls.DataGrid dgSC;
        protected System.Web.UI.WebControls.Label lbCId;
       
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if ( ! IsPostBack )
            {
                try
                {
                    lbCId.Text =Request.QueryString["CId"];
                    string sql = "select SC.*,SName from SC,Student where CId = "+lbCId.Text+" and SC.SId like Student.SId";
                    DataSet ds = Db.ExecuteSelectSql(sql);
                    if ( ds != null && ds.Tables.Count > 0 )
                    {
                        dgSC.DataSource = ds.Tables[0];
                        dgSC.DataKeyField = "SId";
                        dgSC.DataBind();
                    }
                }
                catch
                {
                    lbCId.Text = "-1";
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
            this.dgSC.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgSC_PageIndexChanged);
            this.dgSC.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSC_CancelCommand);
            this.dgSC.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSC_EditCommand);
            this.dgSC.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSC_UpdateCommand);
            this.dgSC.SelectedIndexChanged += new System.EventHandler(this.dgSC_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
		#endregion

        private void dgSC_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            dgSC.EditItemIndex = e.Item.ItemIndex;

            string sql = "select SC.*,SName from SC,Student where CId = "+lbCId.Text+" and SC.SId like Student.SId";
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgSC.DataSource = ds.Tables[0];
                dgSC.DataKeyField = "SId";
                dgSC.DataBind();
            }
            //dgSC.DataBind();
        }

        private void dgSC_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            dgSC.EditItemIndex = -1;
            string sql = "select SC.*,SName from SC,Student where CId = "+lbCId.Text+" and SC.SId like Student.SId";
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgSC.DataSource = ds.Tables[0];
                dgSC.DataKeyField = "SId";
                dgSC.DataBind();
            }
            //dgSC.DataBind();

        }

        private void dgSC_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            dgSC.CurrentPageIndex = e.NewPageIndex;
            string sql = "select * from SC where CId = "+lbCId.Text;
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 )
            {
                dgSC.DataSource = ds.Tables[0];
                dgSC.DataKeyField = "SId";
                dgSC.DataBind();
            }
        }

        private void dgSC_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string sid = dgSC.DataKeys[e.Item.ItemIndex].ToString().Trim();
            string str_score = ((TextBox)(e.Item.Cells[2].Controls[0])).Text;
            float score = 0;
            try
            {
                score = float.Parse(str_score);
            }
            catch
            {
                Response.Write(MyUtility.Alert("请正确输入"));
                Response.Write(MyUtility.Back(-1));
            }
            float preScore = 0;
            string sql = "select Score from SC where CId = "+lbCId.Text+" and SId like '"+sid+"'";
            DataSet ds = Db.ExecuteSelectSql(sql);
            if ( ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                preScore = float.Parse(ds.Tables[0].Rows[0][0].ToString());
            int flag = 0;
            if ( preScore < 60 && score > 60 ) //成绩合格学风增加
                flag = 1;
            else if ( preScore > 60 && score < 60 )//不合格学分减少
                flag = -1;
            if ( flag != 0 )
            {
                sql = "select CCredit from Course where CId = "+lbCId.Text;
                DataSet ds1 = Db.ExecuteSelectSql(sql);
                if ( ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 )
                {
                    float credit  = (float)flag * float.Parse(ds1.Tables[0].Rows[0][0].ToString());
                    sql = "update SC set Score = "+score.ToString()+" where CId = "+lbCId.Text+" and SId like '"+sid+"'";
                    Db.ExecuteSql(sql);
                    sql = "update Student set SCredit = SCredit + "+credit.ToString()+" where SId like '"+sid+"'";
                    Db.ExecuteSql(sql);
                }
            }
            dgSC.EditItemIndex = -1;
            sql = "select SC.*,SName from SC,Student where CId = "+lbCId.Text+" and SC.SId like Student.SId";
            DataSet ds2 = Db.ExecuteSelectSql(sql);
            if ( ds2 != null && ds2.Tables.Count > 0 )
            {
                dgSC.DataSource = ds2.Tables[0];
                dgSC.DataKeyField = "SId";
                dgSC.DataBind();
            }
        }

        private void dgSC_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        
        }
	}
}

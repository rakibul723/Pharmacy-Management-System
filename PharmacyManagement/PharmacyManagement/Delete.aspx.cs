using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace PharmacyManagement
{
    public partial class Edit : System.Web.UI.Page
    {
        DataRead Dobj = new DataRead();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void loadgrid()
        {
            DataRead dc = new DataRead();
            String query = @"select * from datainsert where medicinename ='" + deletemed.Text + "'";
            GridView1.DataSource = Dobj.Getdata(query);
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataRead dc = new DataRead();
            Label lvlid = (Label)GridView1.Rows[e.RowIndex].FindControl("Label1");
            String query = @"DELETE FROM [dbo].[datainsert]
      WHERE medicinename = '"+deletemed.Text+"'";
            if(dc.executequary(query)==1)
            {
                loadgrid();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin login.aspx");
        }
    }
}
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
    public partial class Search : System.Web.UI.Page
    {
        DataRead Dobj = new DataRead();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Name"] == null)
            {
                Response.Redirect("Customer Login.aspx");
            }
        }
        void loadgrid()
        {
            String query = @"select * from datainsert where medicinename ='" + TextBox1.Text + "'";
            GridView1.DataSource = Dobj.Getdata(query);
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loadgrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String query = @"select medicieprice from datainsert where medicinename ='" + TextBox1.Text + "'";
            Response.Redirect("upcoming.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.RemoveAll();
            Response.Redirect("Customer Login.aspx");
        }
    }
}
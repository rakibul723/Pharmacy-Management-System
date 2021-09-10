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
    public partial class Delete : System.Web.UI.Page
    {
        DataRead Dobj = new DataRead();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void loadgrid()
        {
            String query = @"select * from datainsert where medicinename ='" + TextBox1.Text + "'";
            GridView1.DataSource = Dobj.Getdata(query);
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }
    }
}
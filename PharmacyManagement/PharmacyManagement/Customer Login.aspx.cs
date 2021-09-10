using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmacyManagement
{
    public partial class Lgin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FHKILVU;Initial Catalog=Pharmacymanagement;Integrated Security=True");
            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("select count(*) from registration where username='" + TextBox1.Text + "'and passwords='" + TextBox2.Text + "'", con);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            if (DT.Rows[0][0].ToString() == "1")
            {
                Session["User_Name"] = TextBox2.Text;
                Response.Redirect("Search.aspx");
            }


        }
    }
}
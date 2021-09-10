using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PharmacyManagement
{
    public partial class Admin : System.Web.UI.Page
    {
        DataRead Dobj = new DataRead();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_Name"] == null)
            {
                Response.Redirect("Admin Login.aspx");
            }
        }
        void loadgrid()
        {
            String query = @"select * from datainsert ";
            GridView1.DataSource = Dobj.Getdata(query);
            GridView1.DataBind();

        }
        DataInsrt di = new DataInsrt();
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int medicine_price = Convert.ToInt32(medicineprice.Text);
                string query = @"INSERT INTO [dbo].[datainsert]
           ([medicinename]
           ,[companyname]
           ,[medicineprice]
           ,[expdate])
     VALUES('" + medicinename.Text + "','" + companyname.Text + "','" +medicineprice.Text + "','" + expdate.Text+ "')";

                if (di.executequary(query) == 1)
                {
                    successorerror.Text = "Save Success";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    successorerror.Text = "Info already Exist";
                }
                else
                {
                    successorerror.Text = "Error : " + ex;
                }
            }
            loadgrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.RemoveAll();
            Response.Redirect("Admin Login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("upcoming.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
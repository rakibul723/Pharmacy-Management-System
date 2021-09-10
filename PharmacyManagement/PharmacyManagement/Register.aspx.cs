using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

namespace PharmacyManagement
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataInsrt di = new DataInsrt();
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {    
                string query = @"INSERT INTO [dbo].[registration]
           ([username]
           ,[firstname]
           ,[lastname]
           ,[address]
           ,[email]
           ,[passwords])
     VALUES('" + username.Text + "','" + firstname.Text + "','" + lastname.Text + "','" +address.Text+ "','"+email.Text+"','"+ TextBox1.Text + "')";

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
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer Login.aspx");
        }
    }
}
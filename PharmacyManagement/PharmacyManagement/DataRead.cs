using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmacyManagement
{
    public class DataRead
    {
        string ConStr = "Data Source = DESKTOP-FHKILVU; Initial Catalog = Pharmacymanagement; Integrated Security = True";
        public DataTable Getdata(string query)
        {
            SqlConnection conn = new SqlConnection(ConStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int executequary (String query)
        {
            SqlConnection conn = new SqlConnection(ConStr);
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
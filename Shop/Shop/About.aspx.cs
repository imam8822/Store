using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string conString = ConfigurationManager.ConnectionStrings["StoreConnectionDB"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                string query = "select fname from Customer where email = '" + Session["UserName"] + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                string user = (string)cmd.ExecuteScalar();
                Master.linkLogin.Visible = false;
                Master.linklogout.Visible = true;
                Master.linkReg.Visible = false;
                Master.LabUser.Text = user;
            }
            
        }
    }
}
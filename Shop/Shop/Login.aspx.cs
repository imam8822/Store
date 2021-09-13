using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class Login : System.Web.UI.Page
    {
        string encytPwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }    
        }

        private void LoadData()
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
                Master.user_profile.Text = "Hello " + user;
            }
        }

        protected void lk_newUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }
        public void encryption()
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[tb_pass.Text.ToString().Length];
            encode = Encoding.UTF8.GetBytes(tb_pass.Text);
            strmsg = Convert.ToBase64String(encode);
            encytPwd = strmsg;
           
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            encryption();
            string conString = ConfigurationManager.ConnectionStrings["StoreConnectionDB"].ConnectionString;
            string query = "select email,password from Customer where email='" + tb_email.Text + "' and password = '" + encytPwd + "'";
            using (SqlConnection con = new SqlConnection(conString))
            {
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Session["UserName"] = tb_email.Text;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lbl_log_error.Text = "Invalid email or Password ";
                    }
                }
            }
        }

        protected void cb_changed(object sender, EventArgs e)
        {
            
        }
    }
}
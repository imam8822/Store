using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class UserProfile : System.Web.UI.Page
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
                getUserDetails();
            }
        }

        public void getUserDetails()
        {
            string conString = ConfigurationManager.ConnectionStrings["StoreConnectionDB"].ConnectionString;
            string query = "select * from Customer where email = '" + Session["UserName"].ToString() + "'";
            using(SqlConnection con = new SqlConnection(conString))
            {
                using(SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            tb_fname.Text = dr["fname"].ToString();
                            tb_lname.Text = dr["lname"].ToString();
                            tb_dob.Text = dr["dob"].ToString();
                            tb_email.Text = dr["email"].ToString();
                        }
                    }
                }
            }
        }
        public void encryption()
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[tb_pass.Text.ToString().Length];
            encode = Encoding.UTF8.GetBytes(tb_pass.Text);
            strmsg = Convert.ToBase64String(encode);
            encytPwd = strmsg;
        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            string conString = ConfigurationManager.ConnectionStrings["StoreConnectionDB"].ConnectionString;
            string plain_pass;
            string fname = tb_fname.Text;
            string lname = tb_lname.Text;
            string dob = tb_dob.Text;
            encryption();
            string query = "select password from Customer where email = '" + Session["UserName"].ToString() + "'";
            string query1 = "update Customer set fname = @fname, lname = @lname, dob = @dob where email= @email";
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    string pass = cmd.ExecuteScalar().ToString();
                    byte[] b = Convert.FromBase64String(pass);
                    plain_pass = System.Text.ASCIIEncoding.ASCII.GetString(b);
                    con.Close();
                }
     
            }
            if (plain_pass == tb_pass.Text)
            {
                encryption();
                try
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query1, con))
                        {
                            cmd.Parameters.AddWithValue("@fname", fname);
                            cmd.Parameters.AddWithValue("@lname", lname);
                            cmd.Parameters.AddWithValue("@dob", dob);
                            cmd.Parameters.AddWithValue("@email", Session["UserName"].ToString());
                            con.Open();
                            cmd.ExecuteNonQuery();
                            lbl_password.Text = "Details Updated Successfully";
                            lbl_password.ForeColor = Color.Green;
                            con.Close();
                        }

                    }
                }
                catch(SqlException ex)
                {
                    lbl_password.Text = "Incorrect password ";
                }
                
            }
            
        }

    }
}
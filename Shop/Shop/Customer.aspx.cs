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
    public partial class Customer1 : System.Web.UI.Page
    {
        string encytPwd;
        string conString = ConfigurationManager.ConnectionStrings["StoreConnectionDB"].ConnectionString;
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

        public void encryption()
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[tb_confirm.Text.ToString().Length];
            encode = Encoding.UTF8.GetBytes(tb_confirm.Text);
            strmsg = Convert.ToBase64String(encode);
            encytPwd = strmsg;
        }
        protected void lb1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            Label lbl = (Label)this.Master.FindControl("lbl_login");
            lbl.Text = "Imam";
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {          
            string fname = tb_fname.Text;
            string lname = tb_lname.Text;
            string dob = tb_dob.Text;
            string email = tb_email.Text;
            string pass = tb_password.Text;
            encryption();
            string query = "insert into Customer(Fname, Lname,dob,email,password) values (@fname,@lname,@dob,@email,@pass)";
            string conString = ConfigurationManager.ConnectionStrings["StoreConnectionDb"].ConnectionString;
            using(SqlConnection cons = new SqlConnection(conString))
            {
                using(SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", encytPwd);
                    cmd.Connection = cons;
                    try
                    {
                        cons.Open();
                        cmd.ExecuteNonQuery();
                        tb_fname.Text = "";
                        tb_lname.Text = "";
                        tb_dob.Text = "";
                        tb_email.Text = "";
                        lbl_success.Text = "You are successfully registerd with us <br/> You can Login now ";
                        cons.Close();
                    }
                    catch(SqlException ex)
                    {

                    }
                    
                }
            }

        }
    }
}
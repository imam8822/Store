using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public LinkButton linkReg
        {
            get
            {
                return this.lb_reg;
            }
        }
        public LinkButton linkLogin
        {
            get
            {
                return this.lb_login;
            }
        }
        public LinkButton linklogout
        {
            get
            {
                return this.lb_logout;
            }
        }
        public LinkButton user_profile
        {
            get
            {
                return this.lb_user;
            }

        }
        protected void lb_reg_Click(object sender, EventArgs e)
        {
              Response.Redirect("Customer.aspx");
            //Server.Transfer("Customer.aspx");
        }

        protected void lb_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            //Server.Transfer("Login.aspx");

        }

        protected void lb_logout_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Login.aspx");
            
            Session.Abandon();
            Response.Redirect("Login.aspx");      
        }

        protected void lb_user_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
    }
}
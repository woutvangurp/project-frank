using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project_frank.Controllers;

namespace project_frank
{
    public partial class About : Page
    {
        private DBFunctions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DBFunctions();
            if (!IsPostBack)
            {

            }

            if (Password.Text != "")
            {
                Login();
            }
        }

        protected void Load_Data()
        {

        }

        protected void Login()
        {
            string WW = Password.Text;
            if (WW != "")
            {
                bool check = db.CheckLogin(WW);
                if (check)
                {
                    Session["Logged"] = 1;
                }
            }
            Page.Response.Redirect("Admin.aspx");
        }
    }
}
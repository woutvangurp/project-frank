using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_frank
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
                Load_data();
        }

        protected void Load_data()
        {
            if (Session["Logged"] != null)
            {
                int Logged = int.Parse(Session["Logged"].ToString());

                if (Logged == 1)
                {
                    btnAdmin.Visible = true;
                    btnLogout.Visible = true;
                    btnLog.Visible = false;
                }
                else
                {
                    btnAdmin.Visible = false;
                    btnLog.Visible = true;
                    btnLogout.Visible = false;
                }
            }
            else
                btnAdmin.Visible = false;
        }

        protected void logoutClick(object sender, EventArgs e)
        {
            Session["Logged"] = null;
            btnLog.Visible = true;
            btnLogout.Visible = false;
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
}
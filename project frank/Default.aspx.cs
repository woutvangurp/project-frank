using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project_frank.Controllers;

namespace project_frank
{
    public partial class _Default : Page
    {
        protected DBFunctions db;
        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DBFunctions();
            if (!IsPostBack) 
                Load_data();

        }

        protected void Load_data()
        {
            bindData();
        }

        protected void bindData()
        {
            List<Table> list = db.getSongs();
            if (list.Count > 0)
            {
                SongsGrid.DataSource = list;
                SongsGrid.DataBind();
            }
        }
    }
}
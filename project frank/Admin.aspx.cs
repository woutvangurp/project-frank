using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using project_frank.Controllers;

namespace project_frank
{
    public partial class Contact : Page
    {
        private DBFunctions dbFunctions;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbFunctions = new DBFunctions();
            if (!IsPostBack)
            {
                if (Session["Logged"] != null)
                {
                    var sess = Session["Logged"];
                    if (sess == null)
                    {
                        Page.Response.Redirect("Default.aspx");
                    }
                    else
                        Load_data();
                }
                else
                    Page.Response.Redirect("Default.aspx");    
            }
        }

        protected void Load_data()
        {
            List<Table> Songs = dbFunctions.getAllSongs();
            if (Songs.Count != 0)
            {
                allePlaten.DataSource = Songs;
                allePlaten.DataBind();
            }
        }

        protected void DeleteCLick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void EditClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void allePlaten_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var id = allePlaten.DataKeys[e.Row.RowIndex].Value.ToString();
                if (id != null)
                {
                    var row = e.Row;
                    LinkButton btnDel = (LinkButton)row.FindControl("btnDel");
                    LinkButton btnEdit = (LinkButton)row.FindControl("btnEdit");

                    if (btnDel != null) btnDel.CommandArgument = id;
                    if (btnEdit != null) btnEdit.CommandArgument = id;
                }
            }
        }

        protected void addPlaat_OnClick(object sender, EventArgs e)
        {
            Overlay.Visible = true;
            addPanel.Visible = true;
        }

        protected void btnClose_OnClick(object sender, EventArgs e)
        {
            Overlay.Visible =false;
            addPanel.Visible =false;
            pnlAlert.Visible = false;
        }

        protected void btnSend_OnClick(object sender, EventArgs e)
        {
            int nummer = int.Parse(tbxNummer.Text);
            string band = tbxBand.Text;
            string song = tbxSong.Text;
            int fav = ddlBool.SelectedIndex;

            if (tbxSong.Text != "" &&
                tbxBand.Text != "" &&
                tbxNummer.Text != "")
            {
                addPanel.Visible = false;
                pnlAlert.Visible = true;
                string feedback;
                bool check = dbFunctions.addSong(nummer, band, song, fav);
                if (check)
                    feedback = "De plaat staat er in!";
                else
                    feedback = "Kan de plaat niet toevoegen. <br> heb je wat verkeerds of te lang geschreven?";
                lblAlert.Text = feedback;
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            else
            {
                btnSend.Visible = false;
                btnSend.Enabled = false;
                btnAddAl.Visible = true;
                btnAddAl.Enabled = true;
                btnAddAl.Text = "Frank, vul alles in! alles ingevuld, druk hier!";

                if (tbxSong.Text == "")
                    tbxSong.CssClass = "tbxempty";
                else
                    tbxSong.CssClass = "tbxfull";
                if (tbxBand.Text == "")
                    tbxBand.CssClass = "tbxempty";
                else
                    tbxBand.CssClass = "tbxfull";
                if (tbxNummer.Text == "")
                    tbxNummer.CssClass = "tbxempty";
                else
                    tbxNummer.CssClass = "tbxfull";
            }
        }
    }
}
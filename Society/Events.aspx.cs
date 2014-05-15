using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;

public partial class Society_Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Organiser"]==null)
        {
            Response.Redirect("~/Login.aspx");
        }
        else
        {            
            Organiser organiser = (Organiser)Session["Organiser"];
            lblSocietyName.Text = organiser.Society.ToString();
            Page.Title = organiser.Society.ToString();
            rptrEvents.DataSource = Society.GetEvents(organiser.Society);
            rptrEvents.DataBind();
        }
    }
    protected void rptrEvents_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Session["EventID"] = e.CommandArgument;
        Response.Redirect("Selection.aspx");
    }
    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
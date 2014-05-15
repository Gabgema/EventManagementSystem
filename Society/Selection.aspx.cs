using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;

public partial class Society_Selection : System.Web.UI.Page
{
    Event ev;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Organiser"] == null || Session["EventID"] == null)
            Response.Redirect("~/Login.aspx");
        else
        {
            Organiser organiser = (Organiser)Session["Organiser"];
            ev = Event.GetEventDetails(int.Parse(Session["EventID"].ToString()));
            lblEventName.Text = ev.Name;
            //GridView1.DataSource = Event.GetRegisteredParticipants(ev);
            //GridView1.DataBind();
            if (ev.IsSinglePlayer)
            {
                lblEventType.Text = "Single Player Game.";
                //lblNumberOfParticipants.Text = "Total Participants: " + GridView1.Rows.Count.ToString();
                pnlUpdation.Visible = false;
            }
            else
            {
                lblEventType.Text = "Multi Player Game.";
                //var numberOfTeams = (from i in GridView1.Rows.Cast<GridViewRow>() select new { Teamid = i.Cells[0].Text }).Distinct().Count();
                //lblNumberOfParticipants.Text = "Total Teams: " + numberOfTeams.ToString();
                pnlUpdation.Visible = true;
            }
            Page.Title = organiser.Society + "- " + ev.Name;
        }
    }
    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
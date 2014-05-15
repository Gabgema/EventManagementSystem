using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;

public partial class Society_EventRegistration : System.Web.UI.Page
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
            if (ev.IsSinglePlayer)
                lblEventType.Text = "Single Player Game.";
            else
                lblEventType.Text = "Multi Player Game.";
            Page.Title = organiser.Society + "- " + ev.Name;
            for (int i = 0; i < ev.MaxTeamSize; i++)
            {
                TextBox tb = new TextBox();
                tb.ID = "TTID" + (i + 1).ToString();
                tb.Attributes.Add("placeholder", "TTID " + (i + 1).ToString());
                pnlTxtBx.Controls.Add(tb);
                RegularExpressionValidator rev = new RegularExpressionValidator();
                rev.ControlToValidate = tb.ClientID;
                rev.ValidationExpression = "\\d{4}";
                rev.ErrorMessage = "*";
                pnlTxtBx.Controls.Add(rev);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Team team = new Team();

        //make up participant list from textboxes
        team.FromTextboxes(pnlTxtBx.Controls.OfType<TextBox>().ToList());

        // if no participant
        if (team.Participants.Count == 0)
        {
            lblResult.Text = "Enter atleast one TTID";
            lblResult.ForeColor = Color.Red;
            return;
        }
        // check if participants are registered in TT
        //if (!team.Participants.All(i => Participant.CheckParticipantTTID(i.TTID)))
        //{
        //    lblResult.Text = "Invalid TTIDs";
        //    lblResult.ForeColor = Color.Red;
        //    return;
        //}
        // register team in this event
        int teamID = Event.CreateNewTeam(ev, team);

        bool teamAdded;
        // error registering in event
        if (teamID == -1)
        {
            lblResult.Text = "Error! Please try again";
            lblResult.ForeColor = Color.Red;
            return;
        }


        team.ID = teamID;

        if (!ev.IsSinglePlayer) //if multiplayer
        {
            teamAdded = Team.AddNewTeam(team); // save team data
            if (teamAdded)
            {
                // success
                lblResult.Text = "Team Created. Team ID is: " + teamID.ToString();
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                //failure
                lblResult.Text = "Team NOT Added";
                lblResult.ForeColor = Color.Red;
            }
        }
        else// if singleplayer
        {
            //success
            lblResult.Text = "Participant Registered";
            lblResult.ForeColor = Color.Green;
        }
        //clear textboxes
        pnlTxtBx.Controls.OfType<TextBox>().ToList().ForEach(i => i.Text = "");
    }

    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
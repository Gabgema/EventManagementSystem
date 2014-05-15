using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;
using System.Data;

public partial class Society_Promotion : System.Web.UI.Page
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
            {
                lblEventType.Text = "Single Player Game.";
                lblIDType.Text = "TTIDs below for promotion.";
            }
            else
            {
                lblEventType.Text = "Multi Player Game.";
                lblIDType.Text = "Team IDs below for promotion.";
            }
            Page.Title = organiser.Society + "- " + ev.Name;
            int currentLevel;
            if (!IsPostBack)
            {
                DataTable dt = Event.GetParticipantsForPromotion(ev);
                grdvwPromotion.DataSource = dt;
                grdvwPromotion.DataBind();
                if (dt.Rows.Count == 0)
                {
                    lblResult.Text = "Data not available";
                    btnSubmit.Visible = false;
                }
                else
                {
                    currentLevel = int.Parse(grdvwPromotion.Rows[0].Cells[3].Text);
                    if (ev.IsSinglePlayer)
                        grdvwPromotion.Columns[1].Visible = false;
                    else
                        grdvwPromotion.Columns[2].Visible = false;
                    btnSubmit.Text = "Promote To Level " + (currentLevel + 1).ToString();
                    btnSubmit.Visible = true;
                }
            }
        }
    }

    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<int> participantID = new List<int>();
        int count = 0;
        foreach (GridViewRow row in grdvwPromotion.Rows)
        {
            CheckBox c = row.FindControl("chkbxParticipantID") as CheckBox;
            if (c.Checked)
            {
                if (ev.IsSinglePlayer)
                    participantID.Add(int.Parse(row.Cells[2].Text));
                else
                    participantID.Add(int.Parse(row.Cells[1].Text));
            }
            else
                count++;
        }
        if (count == grdvwPromotion.Rows.Count)
        {
            lblResult.Text = "Please select at least 1 checkbox";
            return;
        }
        bool participantsPromoted = Event.PromoteParticipants(participantID, ev);
        if (participantsPromoted)
        {
            lblResult.Text = "Participants Promoted";
            DataTable dt = Event.GetParticipantsForPromotion(ev);
            grdvwPromotion.DataSource = dt;
            grdvwPromotion.DataBind();
            int currentLevel = int.Parse(grdvwPromotion.Rows[0].Cells[3].Text);
            btnSubmit.Text = "Promote To Level " + (currentLevel + 1).ToString();
        }
        else
            lblResult.Text = "Error! Please try again";
    }
}
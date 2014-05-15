using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Data;

public partial class SI_Promotion : System.Web.UI.Page
{
    Event ev = new Event();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptrEvents.DataSource = Event.GetAllEvents();
            rptrEvents.DataBind();
            btnSubmit.Visible = false;
        }
    }
    protected void rptrEvents_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Session["EventID"] = e.CommandArgument;
        ev.ID = int.Parse(Session["EventID"].ToString());
        ev = Event.GetEventDetails(ev.ID);
        lblEventName.Text = ev.Name;

        int currentLevel;
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
            {
                grdvwPromotion.Columns[1].Visible = false;
                grdvwPromotion.Columns[2].Visible = true;
            }
            else
            {
                grdvwPromotion.Columns[2].Visible = false;
                grdvwPromotion.Columns[1].Visible = true;
            }
            btnSubmit.Text = "Promote To Level " + (currentLevel + 1).ToString();
            btnSubmit.Visible = true;
            lblResult.Text = "";
            grdvwPromotion.Focus();            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        List<int> participantID = new List<int>();
        int count = 0;
        ev.ID = int.Parse(Session["EventID"].ToString());
        ev = Event.GetEventDetails(ev.ID);
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
            btnSubmit.Visible = true;
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
        {
            lblResult.Text = "Error! Please try again";
        }
        btnSubmit.Visible = true;
    }
}
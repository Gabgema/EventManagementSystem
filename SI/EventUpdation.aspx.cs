using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;

public partial class SI_EventUpdation : System.Web.UI.Page
{
    Event ev;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            ev = Event.GetEventDetails(Team.GetEventID(int.Parse(txtbxTeamID.Text)));
            if (ev == null)
            {
                lblResult.Text = "Team does not exit.";
                return;
            }
            for (int i = 0; i < ev.MaxTeamSize; i++)
            {
                TextBox tb = new TextBox();
                tb.ID = "TTID" + (i + 1).ToString();
                tb.Attributes.Add("placeholder", "TTID " + (i + 1).ToString());
                pnlTxtBx.Controls.Add(tb);
                RegularExpressionValidator rev = new RegularExpressionValidator();
                rev.ControlToValidate = tb.ID;
                rev.ValidationExpression = "\\d{4}";
                rev.ErrorMessage = "*";
                pnlTxtBx.Controls.Add(rev);
            }
        }
        pnlTxtBx.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Team t = new Team();
        t.ID = int.Parse(txtbxTeamID.Text);
        t = Team.GetTeam(t.ID);
        if (t.Participants.Count == 0)
        {
            lblResult.Text = "Team does not exit.";
        }
        else
        {
            int i = 0;
            List<TextBox> tb = pnlTxtBx.Controls.OfType<TextBox>().ToList();
            foreach (Participant p in t.Participants)
            {
                tb[i].Text = p.TTID.ToString();
                i++;
            }
            btnUpdate.Visible = true;
            pnlTxtBx.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Team t = new Team();
        t.ID = int.Parse(txtbxTeamID.Text);
        t.FromTextboxes(pnlTxtBx.Controls.OfType<TextBox>().ToList());
        if (t.Participants.Count == 0)
        {
            lblResult.Text = "Enter atleast one TTID";
            lblResult.ForeColor = Color.Red;
            return;
        }

        bool teamDeleted = Team.DeleteTeam(t.ID);
        if (teamDeleted)
        {           
            // if all participants registered in TT
            //if (!t.Participants.All(i => Participant.CheckParticipantTTID(i.TTID)))
            //{
            //    lblResult.Text = "Invalid TTIDs";
            //    lblResult.ForeColor = Color.Red;
            //    return;
            //}

            bool teamAdded = Team.AddNewTeam(t);
            if (teamAdded)
            {
                // success
                lblResult.Text = "Team Updated";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                //failure
                lblResult.Text = "Team NOT Updated";
                lblResult.ForeColor = Color.Red;
            }
        }
        else
        {
            lblResult.Text = "Error! Please try again";
        }
    }
}
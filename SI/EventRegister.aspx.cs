using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;

public partial class SI_EventRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Event> events = Event.GetAllEvents();

        foreach (Event selectedEvent in events)
        {
            Panel pnlEvent = new Panel();
            pnlEvent.ID = selectedEvent.ID.ToString();
            pnlEvent.Attributes.Add("class", "panel");
            CheckBox chkbxEventName = new CheckBox();
            chkbxEventName.ID = "chkbx" + selectedEvent.Name;
            chkbxEventName.Text = selectedEvent.Name;
            pnlEvent.Controls.Add(chkbxEventName);
            for (int i = 0; i < selectedEvent.MaxTeamSize; i++)
            {
                TextBox txtbxTTID = new TextBox();
                txtbxTTID.ID = "TTID" + (i + 1).ToString() + selectedEvent.ID;
                txtbxTTID.Attributes.Add("placeholder", "TTID " + (i + 1).ToString());
                txtbxTTID.Attributes.Add("style", "display:none;");
                pnlEvent.Controls.Add(txtbxTTID);
                RegularExpressionValidator rev = new RegularExpressionValidator();
                rev.ControlToValidate = txtbxTTID.ClientID;
                rev.Attributes.Add("style", "display:none;");
                rev.ValidationExpression = "\\d{4}";
                rev.ErrorMessage = "*";
                pnlEvent.Controls.Add(rev);
            }
            pnlEvents.Controls.Add(pnlEvent);
        }
    }
    
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Team team = new Team();
        string result = null;
        int teamID;
        bool teamAdded;
        foreach (Panel pnlEvent in pnlEvents.Controls)
        {
            List<CheckBox> c = pnlEvent.Controls.OfType<CheckBox>().ToList();     
            if(c[0].Checked)
            {
                team.FromTextboxes(pnlEvent.Controls.OfType<TextBox>().ToList());
                if (team.Participants.Count == 0)
                {
                    result += "Enter atleast one TTID for <b>" + c[0].Text + "</b>.<br />";                    
                    continue;
                }

                Event ev = Event.GetEventDetails(int.Parse(pnlEvent.ID));
                teamID = Event.CreateNewTeam(ev, team);

                if (teamID == -1)
                {
                    result += "Error! Please try again for <b>" + c[0].Text + "</b>.<br />";
                    continue;
                }

                team.ID = teamID;

                if (!ev.IsSinglePlayer)
                {
                    teamAdded = Team.AddNewTeam(team);
                    if (teamAdded)
                    {
                        result += "Team ID for <b>" + c[0].Text + "</b> is: <b>" + teamID.ToString() + "</b>.<br />";              
                    }
                    else
                    {
                        result += "Team <b>NOT</b> Added for <b>" + c[0].Text + "</b>.<br />";                        
                    }
                }
                else
                {
                    result += "Participant Registered in <b>" + c[0].Text + "</b>.<br />";                    
                }

                pnlEvent.Controls.OfType<TextBox>().ToList().ForEach(i => i.Text = "");
                pnlEvent.Controls.OfType<CheckBox>().ToList().ForEach(i => i.Checked = false);
            }
        }
        lblResult.Text = result;
    }
}
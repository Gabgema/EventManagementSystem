using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;

public partial class SI_EventWiseParticipation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Event> events = Event.GetAllEvents();
        foreach (Event ev in events)
        {            
            Panel pnlEvent = new Panel();
            pnlEvent.ID = ev.ID.ToString();
            Label lblEventName = new Label();
            lblEventName.Text = ev.Name;
            Label lblNumberOfParticipants = new Label();                          
            pnlEvent.Controls.Add(lblEventName);
            pnlEvent.Controls.Add(lblNumberOfParticipants);  
            GridView grdvwParticipation = new GridView();
            grdvwParticipation.DataSource = Event.GetRegisteredParticipants(ev, 0);
            grdvwParticipation.DataBind();
            pnlEvent.Controls.Add(grdvwParticipation);
            pnlDetails.Controls.Add(pnlEvent);
            if (ev.IsSinglePlayer)
            {
                foreach (GridViewRow row in grdvwParticipation.Rows)
                {
                    row.Cells[0].Text = "TT" + row.Cells[0].Text;
                }
                lblNumberOfParticipants.Text = "Total Participants: " + grdvwParticipation.Rows.Count.ToString();
            }
            else
            {
                var numberOfTeams = (from i in grdvwParticipation.Rows.Cast<GridViewRow>() select new { Teamid = i.Cells[0].Text }).Distinct().Count();
                lblNumberOfParticipants.Text = "Total Teams: " + numberOfTeams.ToString();
            }
        }
    }
}
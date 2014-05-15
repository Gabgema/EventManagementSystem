using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;

public partial class Society_Participation : System.Web.UI.Page
{
    Event ev;
    protected void Page_Load(object sender, EventArgs e)
    {
        ev = Event.GetEventDetails(int.Parse(Session["EventID"].ToString()));        
        GridView1.DataSource = Event.GetRegisteredParticipants(ev,0);
        GridView1.DataBind();
        if (ev.IsSinglePlayer)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.Cells[0].Text = "TT" + row.Cells[0].Text;
            }
            lblNumberOfParticipants.Text = "Total Participants: " + GridView1.Rows.Count.ToString();           
        }
        else
        {            
            var numberOfTeams = (from i in GridView1.Rows.Cast<GridViewRow>() select new { Teamid = i.Cells[0].Text }).Distinct().Count();
            lblNumberOfParticipants.Text = "Total Teams: " + numberOfTeams.ToString();            
        }
    }
}
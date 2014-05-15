using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EMS.Model;
using EMS.Model.Enums;

public partial class SI_ViewReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString.AllKeys.Contains("eid"))
        {
            int eventID = int.Parse(Request.QueryString["eid"]);
            int level = int.Parse(Request.QueryString["l"]);
            Event ev = Event.GetEventDetails(eventID);
            grdvwReport.DataSource = Event.GetRegisteredParticipants(ev, level);
            grdvwReport.DataBind();
            lblLeft.Text = ev.Name;
            if (level == 0)
                lblCenter.Text = "All";
            else
                lblCenter.Text = level.ToString();
            if (ev.IsSinglePlayer)
            {
                foreach (GridViewRow row in grdvwReport.Rows)
                {
                    row.Cells[1].Text = "TT" + row.Cells[1].Text;
                }
                lblRight.Text = "Total Participants: " + grdvwReport.Rows.Count.ToString();
            }
            else
            {
                var numberOfTeams = (from i in grdvwReport.Rows.Cast<GridViewRow>() select new { Teamid = i.Cells[1].Text }).Distinct().Count();
                lblRight.Text = "Total Teams: " + numberOfTeams.ToString();
            }
        }
        else if (Request.QueryString.AllKeys.Contains("rep"))
        {

            switch (Request.QueryString["rep"])
            {
                case "collegecounts":
                    grdvwReport.DataSource = Participant.GetAllColleges();
                    break;
                case "eve": break;
                case "fulltt":
                    lblCenter.Text = "Total Tech Trishna Patricipations : " + Participant.GetTotalParticipation().ToString();
                    grdvwReport.DataSource = Participant.GetAllParticipants();
                    break;
                case "collegecount":
                    lblCenter.Text = "College Wise Report";
                    grdvwReport.DataSource = Participant.GetCollegeWiseParticipation();
                    break;
                case "akg":

                    #region AKGEC / NON AKGEC

                    lblCenter.Text = "College Wise Report";
                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[]{ 
                        new DataColumn("College"),
                        new DataColumn("Count")
                   });
                    int akg, nonakg;
                    Participant.GetTotalAkgecianAndNonAkgecian(out akg, out nonakg);

                    DataRow dr = dt.NewRow();

                    dt.Rows.Add("AKGEC", akg);
                    dt.Rows.Add("Non Akg", nonakg);


                    grdvwReport.DataSource = dt;

                    #endregion

                    break;
                case "counts":
                    break;
                case "win":
                    
                    break;
            }
            grdvwReport.DataBind();


        }
        else
        { }
    }
}


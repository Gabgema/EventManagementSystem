using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Data;

public enum ReportType
{
    EventReport = 1,
    TechtrishnaReport = 2
}

public partial class SI_Report : System.Web.UI.Page
{
    Event ev = new Event();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptrEvents.DataSource = Event.GetAllEvents();
            rptrEvents.DataBind();
            pnlReport.Visible = false;
        }
    }


    protected void rptrEvents_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Session["EventID"] = e.CommandArgument;
        ev.ID = int.Parse(Session["EventID"].ToString());
        ev = Event.GetEventDetails(ev.ID);
        lblEventName.Text = ev.Name;
        int currentLevel = Event.GetCurrentLevel(ev.ID);
        drpdwnlstLevel.Items.Clear();
        System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("All", "0");
        drpdwnlstLevel.Items.Add(li);
        for (int i = 1; i <= currentLevel; i++)
        {
            drpdwnlstLevel.Items.Add(i.ToString());
        }
        frameReport.Attributes.Add("src", "ViewReports.aspx?eid=" + ev.ID.ToString() + "&l=0");
        pnlReport.Visible = true;

    }
    protected void drpdwnlstLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ev.ID = int.Parse(Session["EventID"].ToString());
        ev = Event.GetEventDetails(ev.ID);
        lblEventName.Text = ev.Name;
    }
    protected void drpdwnlstReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (int.Parse(drpdwnlstReportType.SelectedItem.Value) == (int)ReportType.EventReport)
        {
            pnlEventReport.Visible = true;
            pnlTechtrishnaReport.Visible = false;
            rptrEvents.DataSource = Event.GetAllEvents();
            rptrEvents.DataBind();
        }
        else
        {
           
           


            //lblTotalParticipation.Text = "Total Participants: " + Participant.GetTotalParticipation();
            //int totalAkgecian, totalNonAkgecian;
            //Participant.GetTotalAkgecianAndNonAkgecian(out totalAkgecian, out totalNonAkgecian);
            //lblTotalAkgecian.Text = "Total Akgecian: " + totalAkgecian;
            //lblTotalNonAkgecian.Text = "Total Non-Akgecian: " + totalNonAkgecian;
            //grdvwCollegeWiseParticipation.DataSource = Participant.GetCollegeWiseParticipation();
            //this.DataBind();                 
            pnlTechtrishnaReport.Visible = true;
            pnlEventReport.Visible = false;
        }
    }

    protected void lnkbtnPrint_Click(object sender, EventArgs e)
    {
        Response.Write("<script type='text/javascript'>window.open('ViewReports.aspx?eid=" + Session["EventID"].ToString() + "&l=" + drpdwnlstLevel.SelectedValue + "','_blank');</script>");
    }
}
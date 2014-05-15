using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;

public partial class SI_PrintICard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        Participant participant = new Participant();
        if(Session["TTID"] != null)
        {
            participant = Participant.GetParticipantDetails(int.Parse(Session["TTID"].ToString()));
            Session["TTID"] = null;              
        }
        else
        {
            participant = Participant.GetParticipantDetails(Session["EmailID"].ToString());
            Session["EmailID"] = null;
        }
       
        if (participant != null)
        {
            lblName.Text = participant.Name;
            lblBranch.Text = participant.Branch.ToString();
            lblCollege.Text = Participant.GetCollegeName(participant.CollegeID);
            lblTTID.Text = "TT" + participant.TTID.ToString();
            lblYear.Text = participant.Year.ToString();
            lblContact.Text = participant.ContactNo;
        }
        else
        {
            Response.Redirect("ICard.aspx");
        }
        
    }

     
   
}
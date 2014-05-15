using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Organiser organiser = Organiser.GetOrganiserDetails(txtbxUsername.Text, txtbxPassword.Text);
        if (organiser == null)
        {
            lblResult.Text = "Invalid Credentials";
        }
        else
        {
            Session["Organiser"] = organiser;
            if (organiser.Society == SocietyType.SI)
            {
                Response.Redirect("~/SI/Home.aspx");                
            }
            else
            {                
                Response.Redirect("~/Society/Events.aspx");
            }
        }
    }
}
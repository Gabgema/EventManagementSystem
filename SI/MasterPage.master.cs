using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Web.Security;

public partial class SI_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Software Incubator";
        if (Session["Organiser"] == null || ((Organiser)Session["Organiser"]).Society != SocietyType.SI)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void lnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();        
        Response.Redirect("~/Login.aspx");

    }
}

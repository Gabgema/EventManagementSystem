using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;

public partial class RegisterOrganiser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drpdwnlstSocieties.DataSource = Society.GetAllSocieties();
            drpdwnlstSocieties.DataBind();
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Organiser organiser = new Organiser
        {
            Name = txtbxName.Text,
            Username = txtbxUsername.Text,
            Password = txtbxPassword.Text,
            Society = (SocietyType)Enum.Parse(typeof(SocietyType), drpdwnlstSocieties.SelectedItem.Text)
        };
        bool organiserRegistered = Organiser.AddNewOrganiser(organiser);
        if (organiserRegistered)
        {
            lblResult.Text = "Registered Successfully";
            lblResult.ForeColor = Color.Green;
        }
        else
        {
            lblResult.Text = "Error! Please try again";
            lblResult.ForeColor = Color.Red;
        }
    }
}
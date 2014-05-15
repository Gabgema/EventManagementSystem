using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SI_ICard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGenerateICard_Click(object sender, EventArgs e)
    {
        if(txtbxTTID.Text != "")
        {
            Session["TTID"] = txtbxTTID.Text;
            Response.Write("<script type='text/javascript'>window.open('PrintICard.aspx','_blank');</script>");
        }
        else if(txtbxEmail.Text != "")
        {
            Session["EmailID"] = txtbxEmail.Text;
            Response.Write("<script type='text/javascript'>window.open('PrintICard.aspx','_blank');</script>");       
        }
        else
        {
            lblResult.Text = "Enter atleast one of the above fields";
        }
    }
}
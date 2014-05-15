using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EMS.Model;
using EMS.Model.Enums;
using System.Drawing;

public partial class SI_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DDLCollege.DataSource = Participant.GetAllColleges();
            DDLCollege.DataBind();
            ListItem li = new ListItem();
            li.Text = "Other College";
            li.Value = "-1";
            DDLCollege.Items.Add(li);
            DDLBranch.DataSource = Participant.GetAllBranches();
            DDLBranch.DataBind();
        }
    }

    protected void DDLCollege_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLCollege.SelectedItem.Value == "-1")
        {
            RowCollege.Visible = true;
        }
        else
        {
            RowCollege.Visible = false;
        }
        if (DDLCollege.SelectedItem.Value != "1")
        {
            RowStudentNo.Visible = false;
            RowAccomodation.Visible = true;
        }
        else
        {
            RowStudentNo.Visible = true;
            RowAccomodation.Visible = false;
        }
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        bool partnerExists = true;
        if (TxtBxPartnerID.Text != "")
        {
            partnerExists = Participant.CheckParticipantTTID(int.Parse(TxtBxPartnerID.Text.Substring(2)));
        }
        if (partnerExists)
        {
            Participant participant = InitializeParticipant();
            int ttid = Participant.AddNewParticipant(participant);
            if (ttid != 0)
            {
                //bool mailSent = Communication.Sendmail("priyanshuagrawal2005@gmail.com", "", participant.EmailID, "Techtrishna 2014 registration", "You are successfully registered in Techtrishan 2014. Your registration id is TT" + ttid.ToString());
                LblResult.Text = "Registered. Your ID is TT" + ttid.ToString();
            }
            else
                LblResult.Text = "Error! Please try again.";

        }
        else
        {
            LblResult.Text = "Invalid Partner ID";
        }

    }

    protected void DDLBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLBranch.SelectedItem.Text == "MCA")
        {
            DDLYear.Items.Clear();
            DDLYear.Items.Add("1");
            DDLYear.Items.Add("2");
            DDLYear.Items.Add("3");
        }
        else
        {
            DDLYear.Items.Clear();
            DDLYear.Items.Add("1");
            DDLYear.Items.Add("2");
            DDLYear.Items.Add("3");
            DDLYear.Items.Add("4");
        }
    }

    private Participant InitializeParticipant()
    {
        int collegeID = -1;
        if (DDLCollege.SelectedItem.Value == "-1")
        {
            collegeID = Participant.AddNewCollege(TxtBxCollege.Text);
        }
        else
        {
            collegeID = int.Parse(DDLCollege.SelectedValue);
        }
        int partnerID;
        if (TxtBxPartnerID.Text == "")
            partnerID = 0;
        else
            partnerID = int.Parse(TxtBxPartnerID.Text.Substring(2));
        Participant participant = new Participant
        {
            Name = TxtBxName.Text,
            CollegeID = collegeID,
            WantAccomodation = CBWantAccomodation.Checked,
            Branch = (BranchType)Enum.Parse(typeof(BranchType), DDLBranch.SelectedValue),
            ContactNo = TxtBxContactNo.Text,
            EmailID = TxtBxEmail.Text,
            Gender = (GenderType)Enum.Parse(typeof(GenderType), RBLGender.SelectedValue),
            PartnerID = partnerID,
            Password = GeneratePassword(),
            StudentNo = TxtBxStudentNo.Text,
            WantTShirt = CBWantTShirt.Checked,
            Year = int.Parse(DDLYear.SelectedValue)
        };
        return participant;
    }

    private string GeneratePassword()
    {
        Random pg = new Random();
        int pwd = pg.Next(1000, 9999);
        int start = pg.Next(0, 26);
        int end = pg.Next(0, 26);
        char a = Convert.ToChar('a' + start);
        char b = Convert.ToChar('a' + end);
        string pass = a + pwd.ToString() + b;
        return pass;
    }
    protected void btnGetStudentData_Click(object sender, EventArgs e)
    {
        Student student = new Student();
        student.StudentNo = TxtBxStudentNo.Text;
        student = Student.GetStudentDetails(student.StudentNo);
        if (student == null)
        {
            LblResult.Text = "No data found";
            LblResult.Focus();
        }
        else
        {
            TxtBxStudentNo.Text = student.StudentNo;
            TxtBxName.Text = student.Name;
            TxtBxEmail.Text = student.EmailID;
            TxtBxContactNo.Text = student.ContactNo;
            RBLGender.SelectedIndex = RBLGender.Items.IndexOf(RBLGender.Items.FindByText(student.Gender.ToString()));
            DDLBranch.SelectedIndex = DDLBranch.Items.IndexOf(DDLBranch.Items.FindByText(student.Branch.ToString()));
            DDLYear.SelectedIndex = DDLYear.Items.IndexOf(DDLYear.Items.FindByValue(student.Year.ToString()));
            DDLCollege.SelectedIndex = DDLCollege.Items.IndexOf(DDLCollege.Items.FindByValue("1"));
        }
    }
}
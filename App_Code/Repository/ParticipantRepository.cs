using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Model;
using EMS.Model.Enums;
using System.Data;

namespace EMS.Repository
{
    /// <summary>
    /// This class contains the functionality of the participant class.
    /// </summary>
    public static class ParticipantRepository
    {
        static string sql = "";
        static Connect c;

        /// <summary>
        /// This method inserts the details of the participant into the TT database and 
        /// returns the generated TTID on successful insertion and 0 otherwise.
        /// </summary>
        /// <param name="participant">An object of Participant class containing the details of the participant.</param>
        /// <returns>It returns generated TTID.</returns>
        public static int AddNewParticipant(Participant participant)
        {
            sql = "INSERT INTO Participants(Name,EmailID,ContactNo,PartnerID,StudentNo,Password,GenderID,BranchID,Year,CollegeID,TShirt,Accomodation)" +
            "VALUES(@Name,@EmailID,@ContactNo,@PartnerID,@StudentNo,@Password,@GenderID,@BranchID,@Year,@CollegeID,@TShirt,@Accomodation)";
            Connect.ConnectTT();
            int ttID;
            string[] s = { "@Name", "@EmailID", "@ContactNo", "@PartnerID", "@StudentNo", "@Password", "@GenderID", "@BranchID", "@Year", "CollegeID", "TShirt", "Accomodation" };
            try
            {
                c = new Connect(sql, s, participant.Name, participant.EmailID, participant.ContactNo, participant.PartnerID, participant.StudentNo, participant.Password,
                  ((int)participant.Gender), ((int)participant.Branch), participant.Year, participant.CollegeID, participant.WantTShirt, participant.WantAccomodation);
                ttID = c.lastId;
            }
            catch (Exception ex)
            {
                ttID = 0;
            }
            return ttID;
        }

        /// <summary>
        /// This method fetches the details of the participant based on ttid.
        /// </summary>
        /// <param name="ttID">An integer parameter containing the ttid of the participant</param>
        /// <returns>It returns a Data table containing the details.</returns>
        public static DataTable GetParticipantDetails(int ttID)
        {
            sql = "SELECT * FROM Participants WHERE TTID=@ttid";
            string[] s = { "@ttid" };
            Connect.ConnectTT();
            c = new Connect(sql, s, ttID);
            return c.ds.Tables[0];
        }

        /// <summary>
        /// This method fetches the details of the participant based on email id.
        /// </summary>
        /// <param name="ttID">An integer parameter containing the email id of the participant</param>
        /// <returns>It returns a Data table containing the details.</returns>
        public static DataTable GetParticipantDetails(string emailID)
        {
            sql = "SELECT * FROM Participants WHERE EmailID=@emailID";
            string[] s = { "@emailID" };
            Connect.ConnectTT();
            c = new Connect(sql, s, emailID);
            return c.ds.Tables[0];
        }

        /// <summary>
        /// This method fetches the list of colleges from the database.
        /// </summary>
        /// <returns>It returns a data set containing the list of colleges.</returns>
        public static DataSet GetAllColleges()
        {
            sql = "SELECT * FROM Colleges";
            Connect.ConnectTT();
            c = new Connect(sql);
            return c.ds;
        }

        /// <summary>
        /// This method fetches the list of branches from the database.
        /// </summary>
        /// <returns>It returns a data set containing the list of branches.</returns>
        public static DataSet GetAllBranches()
        {
            sql = "SELECT * FROM Branches";
            Connect.ConnectTT();
            c = new Connect(sql);
            return c.ds;
        }

        /// <summary>
        /// This method inserts the college into the database.
        /// </summary>
        /// <param name="collegeName">A string containing the name of the college</param>
        /// <returns>It returns the generated id of the college.</returns>
        public static int AddNewCollege(string collegeName)
        {
            sql = "INSERT INTO Colleges(CollegeName) VALUES(@collegeName)";
            Connect.ConnectTT();
            string[] s = { "@collegeName" };
            c = new Connect(sql, s, collegeName);
            int collegeID = -1;
            collegeID = c.lastId;
            return collegeID;
        }

        /// <summary>
        /// This method updates the details of the participant.
        /// </summary>
        /// <param name="participant">An object of Participant type.</param>
        /// <returns>It returns true if the details are upadted otherwise false.</returns>
        public static bool UpdateParticipantDetails(Participant participant)
        {
            sql = "UPDATE Participants SET Accomodation = @accomodation,BranchID=@branchID,CollegeID=@collegeID,ContactNo=@contactNo,EmailID=@emailID,"
            + "GenderID=@genderID,Name=@name,PartnerID=@partnerId,Password=@password,StudentNo=@studentNo,TShirt=@tshirt,Year=@year WHERE TTID=@ttid";
            string[] s = { "@accomodation", "@branchID", "@collegeID", "@contactNo", "@emailID", "@genderID", "@name", "@partnerID", "@password", "@studentNo", "@tshirt", "@year", "@ttid" };
            Connect.ConnectTT();
            try
            {
                c = new Connect(sql, s, participant.WantAccomodation, ((int)participant.Branch), participant.CollegeID, participant.ContactNo, participant.EmailID,
                    ((int)participant.Gender), participant.Name, participant.PartnerID, participant.Password, participant.StudentNo, participant.WantTShirt,
                    participant.Year, participant.TTID);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// This method updates the password of the participant.
        /// </summary>
        /// <param name="emailID">A string containing the email id of the participant.</param>
        /// <param name="password">A string containing the password of the participant.</param>
        /// <returns>It retuurns true if the password is updated otherwise false.</returns>
        public static bool UpdatePassword(string emailID, string password)
        {
            sql = "UPDATE Participants SET Password=@password WHERE EmailID=@emailID";
            string[] s = { "@password", "@emailID" };
            Connect.ConnectTT();
            try
            {
                c = new Connect(sql, s, password, emailID);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataSet GetAllParticipants()
        {
            sql = "SELECT TTID,Name,EmailID,ContactNo,PartnerID,StudentNo,GenderID,BranchName,Year,TShirt,Accomodation,CollegeName FROM Participants,Colleges,Branches WHERE Participants.CollegeID = Colleges.CollegeID AND Participants.BranchID = Branches.BranchID";
            Connect.ConnectTT();
            c = new Connect(sql);
            return c.ds;
        }

        public static DataSet GetCollegeWiseParticipation()
        {
            sql = "SELECT CollegeName,TotalCount FROM Colleges,(SELECT CollegeID,COUNT(*) AS TotalCount FROM Participants GROUP BY CollegeID)AS CollegeWiseCountTable WHERE Colleges.CollegeID = CollegeWiseCountTable.CollegeID;";
            Connect.ConnectTT();
            c = new Connect(sql);
            return c.ds;
        }

        public static string GetCollegeName(int collegeID)
        {
            sql = "SELECT CollegeName FROM Colleges WHERE CollegeID=@collegeID";
            Connect.ConnectTT();
            string[] s = { "@collegeID" };
            c = new Connect(sql, s, collegeID);
            return c.ds.Tables[0].Rows[0]["CollegeName"].ToString();
        }

    }
}

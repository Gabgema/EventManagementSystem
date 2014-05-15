using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Model.Enums;
using EMS.Repository;
using System.Data;

/// <summary>
/// Participant class houses the properties of a participant.
/// </summary>

namespace EMS.Model
{
    public class Participant : Student
    {

        #region Properties
        public int TTID { get; set; }
        public int PartnerID { get; set; }
        public string Password { get; set; }
        public bool WantTShirt { get; set; }
        public bool WantAccomodation { get; set; }
        #endregion


        public static int AddNewParticipant(Participant participant)
        {
            return ParticipantRepository.AddNewParticipant(participant);
        }

        public static Participant GetParticipantDetails(int ttID)
        {
            DataTable participantDataTable;
            participantDataTable = ParticipantRepository.GetParticipantDetails(ttID);
            return InitializeParticipant(participantDataTable);
        }

        public static Participant GetParticipantDetails(string emailID)
        {
            DataTable participantDataTable;
            participantDataTable = ParticipantRepository.GetParticipantDetails(emailID);
            return InitializeParticipant(participantDataTable);
        }

        private static Participant InitializeParticipant(DataTable participantDataTable)
        {
            if (participantDataTable.Rows.Count > 0)
            {
                DataRow row = participantDataTable.Rows[0];
                bool tshirt, accomodation;
                if (row["TShirt"].ToString() == "1")
                    tshirt = true;
                else
                    tshirt = false;
                if (row["Accomodation"].ToString() == "1")
                    accomodation = true;
                else
                    accomodation = false;
                Participant participant = new Participant
                {
                    Name = row["Name"].ToString(),
                    TTID = (int)row["TTID"],
                    PartnerID = (int)row["PartnerID"],
                    Password = row["Password"].ToString(),
                    WantTShirt = tshirt,
                    WantAccomodation = accomodation,
                    EmailID = row["EmailID"].ToString(),
                    ContactNo = row["ContactNo"].ToString(),
                    StudentNo = row["StudentNo"].ToString(),
                    Gender = (GenderType)Enum.Parse(typeof(GenderType), row["GenderID"].ToString()),
                    Branch = (BranchType)Enum.Parse(typeof(BranchType), row["BranchID"].ToString()),
                    Year = int.Parse(row["Year"].ToString()),
                    CollegeID = int.Parse(row["CollegeID"].ToString())
                };
                return participant;
            }
            else
            {
                return null;
            }
        }

        public static DataSet GetAllColleges()
        {
            return ParticipantRepository.GetAllColleges();
        }

        public static DataSet GetAllBranches()
        {
            return ParticipantRepository.GetAllBranches();
        }

        public static int AddNewCollege(string collegeName)
        {
            return ParticipantRepository.AddNewCollege(collegeName);
        }

        public static bool UpdateParticipantDetails(Participant participant)
        {
            return ParticipantRepository.UpdateParticipantDetails(participant);
        }

        public static bool UpdatePassword(string emailID, string password)
        {
            return ParticipantRepository.UpdatePassword(emailID, password);
        }

        public static bool CheckParticipantTTID(int ttid)
        {
            DataTable participantDataTable = ParticipantRepository.GetParticipantDetails(ttid);
            if (participantDataTable.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DataSet GetAllParticipants()
        {
            DataSet participantDataSet = ParticipantRepository.GetAllParticipants();
            DataTable participantDataTable = participantDataSet.Tables[0];
            DataColumn genderColumn = new DataColumn();
            genderColumn.ColumnName = "Gender";
            genderColumn.DataType = typeof(string);
            participantDataTable.Columns.Add(genderColumn);
            foreach (DataRow row in participantDataTable.Rows)
            {
                if (row["GenderID"].ToString() == "1")
                    row["Gender"] = "Male";
                else
                    row["Gender"] = "Female";
            }
            return participantDataSet;
        }

        public static int GetTotalParticipation()
        {
            return ParticipantRepository.GetAllParticipants().Tables[0].Rows.Count;
        }

        public static void GetTotalMalesAndFemales(out int totalMales, out int totalFemales)
        {
            totalMales = 0;
            totalFemales = 0;
            DataSet participantDataSet = ParticipantRepository.GetAllParticipants();
            DataTable participantDataTable = participantDataSet.Tables[0];
            DataColumn genderColumn = new DataColumn();
            genderColumn.ColumnName = "Gender";
            genderColumn.DataType = typeof(string);
            participantDataTable.Columns.Add(genderColumn);
            foreach (DataRow row in participantDataTable.Rows)
            {
                if (row["GenderID"].ToString() == "1")
                    totalMales++;
                else
                    totalFemales++;
            }
        }

        public static void GetTotalAkgecianAndNonAkgecian(out int totalAkgecian,out int totalNonAkgecian)
        {
            totalAkgecian = 0;
            totalNonAkgecian = 0;
            DataSet participantDataSet = ParticipantRepository.GetAllParticipants();
            DataTable participantDataTable = participantDataSet.Tables[0];            
            foreach (DataRow row in participantDataTable.Rows)
            {
                if (row["CollegeName"].ToString() == "Ajay Kumar Garg Engineering College")
                    totalAkgecian++;
                else
                    totalNonAkgecian++;
            }
        }

        public static DataSet GetCollegeWiseParticipation()
        {
            return ParticipantRepository.GetCollegeWiseParticipation();
        }

        public static string GetCollegeName(int collegeID)
        {
            return ParticipantRepository.GetCollegeName(collegeID);
        }
    }
}

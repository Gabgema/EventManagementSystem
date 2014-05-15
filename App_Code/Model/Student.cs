using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Model.Enums;
using EMS.Repository;
using System.Data;

/// <summary>
/// Student is the base class containing the basic attributes and properties.
/// </summary>

namespace EMS.Model
{
    public class Student
    {
       
        #region Properties      
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }       
        public string StudentNo { get; set; }    
        public GenderType Gender { get; set; }
        public BranchType Branch { get; set; }
        public int Year { get; set; }
        public int CollegeID { get; set; }      
        #endregion


        public static Student GetStudentDetails(string studentNumber)
        {
            DataTable studentDataTable;
            studentDataTable = StudentRepository.GetStudentDetails(studentNumber);
            if (studentDataTable.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow studentRow = studentDataTable.Rows[0];
                Student student = new Student
                {
                    Name = studentRow["Name"].ToString(),
                    EmailID = (studentRow["EmailID"] == DBNull.Value ? string.Empty : studentRow["EmailID"].ToString()),
                    ContactNo = studentRow["ContactNo"].ToString(),
                    StudentNo = studentNumber,
                    Gender = (GenderType)Enum.Parse(typeof(GenderType), studentRow["GenderID"].ToString()),
                    Branch = (BranchType)Enum.Parse(typeof(BranchType), studentRow["BranchID"].ToString()),
                    Year = (int)studentRow["Year"]
                };
                return student;
            }
        }
    }
}

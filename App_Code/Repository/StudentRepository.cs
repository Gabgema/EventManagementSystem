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
    /// This class contains the functionality of the student class.
    /// </summary>
    public static class StudentRepository
    {
        static string sql = "";
        static Connect c;

        /// <summary>
        /// This method fetches the details of the student from the EMS database based on the student number.
        /// </summary>
        /// <param name="studentNumber">A string containing the student number of the student.</param>
        /// <returns>It returns a data table containing the details of the student.</returns>
        public static DataTable GetStudentDetails(string studentNumber)
        {
            sql = "SELECT * FROM Students WHERE StudentNo=@StudentNo";
            Connect.ConnectEMS();
            string[] s = { "@StudentNo" };
            c = new Connect(sql, s, studentNumber);
            return c.ds.Tables[0];
        }
    }
}
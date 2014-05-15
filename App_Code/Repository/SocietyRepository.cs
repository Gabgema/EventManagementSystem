using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EMS.Model;

/// <summary>
/// Summary description for SocietyRepository
/// </summary>

namespace EMS.Repository
{
    public static class SocietyRepository
    {
        static string sql = "";
        static Connect c;

        /// <summary>
        /// This method fetches the events of a particular society.
        /// </summary>
        /// <param name="societyID">An integer parameter containing the societyID</param>
        /// <returns>It returns a data table containing the events.</returns>
        public static DataTable GetEvents(int societyID)
        {
            sql = "SELECT * FROM EVENTS WHERE SocietyID=@societyID";
            Connect.ConnectEMS();
            string[] s = { "@societyID" };
            c = new Connect(sql, s, societyID);
            return c.ds.Tables[0];
        }
        
        /// <summary>
        /// This method returns all the societies from the database.
        /// </summary>
        /// <returns>It returns a datatable containing all the societies.</returns>
        public static DataTable GetAllSocieties()
        {
            sql = "SELECT * FROM Societies";
            Connect.ConnectEMS();
            c = new Connect(sql);
            return c.ds.Tables[0];
        }
    }
}

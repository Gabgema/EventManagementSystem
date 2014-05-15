using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Model;
using System.Data;


/// <summary>
/// Summary description for TeamRepository
/// </summary>

namespace EMS.Repository
{
    public static class TeamRepository
    {
        static string sql = "";
        static Connect c;

        /// <summary>
        /// This method inserts the team into the teams table of the EMS14 database.
        /// </summary>
        /// <param name="t">An object of Team class.</param>
        /// <returns>It returns true if the team is successfully inserted otherwise false.</returns>
        public static bool AddNewTeam(Team t)
        {
            sql = "INSERT INTO  Teams VALUES(@teamID,@ttID)";
            Connect.ConnectEMS();
            string[] s = { "@teamID", "@ttID" };
            foreach(Participant p in t.Participants)
            {
                try
                {
                    c = new Connect(sql, s, t.ID, p.TTID);
                }
                catch(Exception ex)
                {
                    return false;
                }                
            }
            return true;
        }

        /// <summary>
        /// This method fetches the team from the database.
        /// </summary>
        /// <param name="teamID">An integer parameter containing the teamID.</param>
        /// <returns>It returns a data table containing the team details.</returns>
        public static DataTable GetTeam(int teamID)
        {
            sql = "SELECT * FROM Teams WHERE TeamID=@teamID";
            Connect.ConnectEMS();
            string[] s = { "@teamID" };
            c = new Connect(sql, s, teamID);
            return c.ds.Tables[0];
        }

        /// <summary>
        /// This method returns the event id the team is regisreted in.
        /// </summary>
        /// <param name="teamID">An integer parameter containing the id of the team.</param>
        /// <returns>It returns an integer parameter containing the event id.</returns>
        public static int GetEventID(int teamID)
        {
            sql = "SELECT * FROM EventRegistrations WHERE TeamID=@teamID";
            Connect.ConnectEMS();
            string[] s = { "@teamID" };
            c = new Connect(sql, s, teamID);
            if (c.ds.Tables[0].Rows.Count != 0)
                return int.Parse(c.ds.Tables[0].Rows[0]["EventID"].ToString());
            else
                return -1;
        }

        /// <summary>
        /// This method deletes a team from the database.
        /// </summary>
        /// <param name="teamID">An integer parameter containing the team ID.</param>
        /// <returns>It returns true if the team is successfully deleted otherwise false.</returns>
        public static bool DeleteTeam(int teamID)
        {
            sql = "DELETE FROM Teams WHERE TeamID=@teamID";
            Connect.ConnectEMS();
            string[] s = { "@teamID" };
            try
            {
                c = new Connect(sql, s, teamID);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}
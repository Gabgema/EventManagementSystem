using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Model;
using System.Data;

/// <summary>
/// Summary description for EventRepository
/// </summary>

namespace EMS.Model
{
    public static class EventRepository
    {
        static string sql = "";
        static Connect c;

        /// <summary>
        /// This method creates a new team in the eventregistration table. If the event is a single player, then it stores the ttid in the 
        /// table otherwise it is set to 0;
        /// </summary>
        /// <param name="e">An object of Event Class.</param>
        /// <param name="t">An object of Team Class.</param>
        /// <returns></returns>
        public static int CreateNewTeam(Event e, Team t)
        {
            sql = "INSERT INTO EventRegistrations(EventID,TTID,CurrentLevel) VALUES(@eventID,@ttID,@currentLevel)";
            Connect.ConnectEMS();
            string[] s = { "@eventID", "@ttID", "@currentLevel" };
            if (e.IsSinglePlayer)
                c = new Connect(sql, s, e.ID, t.Participants[0].TTID, 1);
            else
                c = new Connect(sql, s, e.ID, 0, 1);
            int teamID = -1;
            teamID = c.lastId;
            return teamID;
        }

        /// <summary>
        /// This method fetches all the events from the database.
        /// </summary>
        /// <returns>It returns a datatable containing all the events.</returns>
        public static DataTable GetAllEvents()
        {
            sql = "SELECT * FROM Events";
            Connect.ConnectEMS();
            c = new Connect(sql);
            return c.ds.Tables[0];
        }

        /// <summary>
        /// This method fetches the details of a particular event.
        /// </summary>
        /// <param name="eventID">An integer parameter containing the ID of the event.</param>
        /// <returns>It returns a data table containing the details of the event.</returns>
        public static DataTable GetEventDetails(int eventID)
        {
            sql = "SELECT * FROM Events WHERE EventID=@eventID";
            string[] s = { "@eventID" };
            Connect.ConnectEMS();
            c = new Connect(sql, s, eventID);
            return c.ds.Tables[0];
        }

        /// <summary>
        /// This method fetches the details of a particular event.
        /// </summary>
        /// <param name="eventName">A string parameter containing the name of the event.</param>
        /// <returns>It returns a data table containing the details of the event.</returns>
        public static DataTable GetEventDetails(string eventName)
        {
            sql = "SELECT * FROM Events WHERE EventName=@eventName";
            string[] s = { "@eventName" };
            Connect.ConnectEMS();
            c = new Connect(sql, s, eventName);
            return c.ds.Tables[0];
        }

        /// <summary>
        /// This method gets the participants registered for a particular event with maximum current level.
        /// </summary>
        /// <param name="eventID">An integer parameter containing the id of the event.</param>
        /// <returns>It returns a datatable containing the list of participants registered.</returns>
        public static DataTable GetParticipantsForPromotion(int eventID)
        {
            sql = "SELECT * FROM EventRegistrations WHERE EventID=@eventID AND CurrentLevel = (SELECT MAX(CurrentLevel) FROM EventRegistrations WHERE EventID=@eventID)";
            string[] s = { "@eventID" };
            Connect.ConnectEMS();
            c = new Connect(sql, s, eventID);
            return c.ds.Tables[0];
        }

        public static bool PromoteParticipants(List<int> participantID, Event ev)
        {
            string[] s = new string[2];
            if (ev.IsSinglePlayer)
            {
                sql = "Update EventRegistrations SET CurrentLevel = CurrentLevel + 1 WHERE EventID=@eventID AND TTID=@ttid";
                s[0] = "@eventID";
                s[1] = "@ttid";
                Connect.ConnectEMS();
            }
            else
            {
                sql = "Update EventRegistrations SET CurrentLevel = CurrentLevel + 1 WHERE EventID=@eventID AND TeamID=@teamid";
                s[0] = "@eventID";
                s[1] = "@teamid";
                Connect.ConnectEMS();
            }
            foreach (int id in participantID)
            {
                try
                {
                    c = new Connect(sql, s, ev.ID, id);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SetColumnsOrder(this DataTable table, params String[] columnNames)
        {
            for (int columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
            {
                table.Columns[columnNames[columnIndex]].SetOrdinal(columnIndex);
            }
        }

        public static DataTable GetRegisteredParticipants(Event ev, int level)
        {
            if (level == 0)
                sql = "SELECT TeamID,TTID,CurrentLevel FROM EventRegistrations WHERE EventID=@eventID";
            else
                sql = "SELECT TeamID,TTID,CurrentLevel FROM EventRegistrations WHERE EventID=@eventID AND CurrentLevel>=" + level + "";
            string[] s = { "@eventID" };
            Connect.ConnectEMS();
            c = new Connect(sql, s, ev.ID);
            if (c.ds.Tables[0].Rows.Count == 0)
                return null;
            DataColumn nameColumn = new DataColumn();
            nameColumn.ColumnName = "Name";
            //DataColumn serialNoColumn = new DataColumn();
            //serialNoColumn.ColumnName = "SNo";
            DataColumn contactColumn = new DataColumn();
            contactColumn.ColumnName = "ContactNo";
            DataColumn collegeColumn = new DataColumn();
            collegeColumn.ColumnName = "College";
            DataColumn eventColumn = new DataColumn();
            eventColumn.ColumnName = "EventName";
            if (ev.IsSinglePlayer)
            {
                DataTable participantDataTable = c.ds.Tables[0];
                //participantDataTable.Columns.Add(serialNoColumn);
                participantDataTable.Columns.Add(nameColumn);
                participantDataTable.Columns.Add(contactColumn);
                participantDataTable.Columns.Add(collegeColumn);
                participantDataTable.Columns.Add(eventColumn);
                participantDataTable.Columns.Remove("TeamID");
                Connect.ConnectTT();
                int count = 1;
                foreach (DataRow row in participantDataTable.Rows)
                {
                    //row[serialNoColumn] = count;
                    sql = "SELECT Name,ContactNo,CollegeName FROM Participants,Colleges WHERE TTID=@ttID AND Participants.CollegeID = Colleges.CollegeID";
                    s[0] = "@ttID";
                    c = new Connect(sql, s, row["TTID"]);
                    row["Name"] = c.ds.Tables[0].Rows[0]["Name"].ToString();
                    row["ContactNo"] = c.ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    row["College"] = c.ds.Tables[0].Rows[0]["CollegeName"].ToString();
                    row["EventName"] = ev.Name;
                    count++;
                }
                participantDataTable.SetColumnsOrder("TTID", "Name", "ContactNo", "College", "EventName", "CurrentLevel");
                participantDataTable.Columns["TTID"].ColumnName = "Tech Trishna ID";
                participantDataTable.Columns["CurrentLevel"].ColumnName = "Level";
                participantDataTable.Columns["ContactNo"].ColumnName = "Contact No";
                participantDataTable.Columns.Remove("EventName");
                if (level != 0)
                    participantDataTable.Columns.Remove("Level");
                foreach (DataRow row in participantDataTable.Rows)
                {
                    if (row["College"].ToString().Equals("Ajay Kumar Garg Engineering College"))
                        row["College"] = "A.K.G.E.C.";
                }
                return participantDataTable;
            }
            else
            {
                DataTable dt = c.ds.Tables[0];
                DataTable participantDataTable = new DataTable();
                DataColumn teamColumn = new DataColumn();
                DataColumn ttColumn = new DataColumn();
                DataColumn levelColumn = new DataColumn();
                levelColumn.ColumnName = "Level";
                teamColumn.ColumnName = "TeamID";
                ttColumn.ColumnName = "TTID";
                participantDataTable.Columns.Add(teamColumn);
                //participantDataTable.Columns.Add(serialNoColumn);
                participantDataTable.Columns.Add(ttColumn);
                participantDataTable.Columns.Add(levelColumn);
                participantDataTable.Columns.Add(nameColumn);
                participantDataTable.Columns.Add(contactColumn);
                participantDataTable.Columns.Add(collegeColumn);
                participantDataTable.Columns.Add(eventColumn);
                Connect.ConnectEMS();
                foreach (DataRow row in dt.Rows)
                {
                    sql = "SELECT * FROM Teams WHERE TeamID=@teamID";
                    s[0] = "@teamID";
                    c = new Connect(sql, s, (int)row["TeamID"]);
                    for (int i = 0; i < c.ds.Tables[0].Rows.Count; i++)
                    {
                        participantDataTable.Rows.Add(c.ds.Tables[0].Rows[i]["TeamID"].ToString(), c.ds.Tables[0].Rows[i]["TTID"].ToString(), row["CurrentLevel"].ToString());
                    }
                }
                Connect.ConnectTT();
                int count = 1;
                foreach (DataRow row in participantDataTable.Rows)
                {
                    //row[serialNoColumn] = count;
                    sql = "SELECT Name,ContactNo,CollegeName FROM Participants,Colleges WHERE TTID=@ttID AND Participants.CollegeID = Colleges.CollegeID";
                    s[0] = "@ttID";
                    c = new Connect(sql, s, row["TTID"]);
                    row["Name"] = c.ds.Tables[0].Rows[0]["Name"].ToString();
                    row["ContactNo"] = c.ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    row["College"] = c.ds.Tables[0].Rows[0]["CollegeName"].ToString();
                    row["EventName"] = ev.Name;
                    count++;
                }
                participantDataTable.SetColumnsOrder("TeamID", "TTID", "Name", "ContactNo", "College", "EventName", "Level");
                participantDataTable.Columns["TTID"].ColumnName = "Tech Trishna ID";
                participantDataTable.Columns["TeamID"].ColumnName = "Team ID";
                participantDataTable.Columns["ContactNo"].ColumnName = "Contact No";
                participantDataTable.Columns.Remove("EventName");
                if (level != 0)
                    participantDataTable.Columns.Remove("Level");
                foreach (DataRow row in participantDataTable.Rows)
                {
                    row["Tech Trishna ID"] = "TT" + row["Tech Trishna ID"];
                    if (row["College"].ToString().Equals("Ajay Kumar Garg Engineering College"))
                        row["College"] = "A.K.G.E.C.";
                }
                return participantDataTable;
            }
        }

        public static int GetCurrentLevel(int eventID)
        {
            sql = "SELECT MAX(CurrentLevel) AS CurrentLevel FROM EventRegistrations WHERE EventID=@eventID";
            string[] s = { "@eventID" };
            Connect.ConnectEMS();
            try
            {
                c = new Connect(sql, s, eventID);
                return int.Parse(c.ds.Tables[0].Rows[0]["CurrentLevel"].ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}

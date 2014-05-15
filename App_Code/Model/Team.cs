using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EMS.Repository;
using System.Data;

/// <summary>
/// Team class contains the functionality and properties of a team.
/// </summary>

namespace EMS.Model
{
    public class Team
    {
        public int ID { get; set; }
        public List<Participant> Participants { get; set; }

        public Team()
        {
            Participants = new List<Participant>();

        }

        public static bool AddNewTeam(Team t)
        {
            return TeamRepository.AddNewTeam(t);
        }

        public static int GetEventID(int teamID)
        {
            return TeamRepository.GetEventID(teamID);
        }

        public Team FromTextboxes(List<TextBox> textboxes)
        {
            foreach (TextBox t in textboxes)
            {

                if (t.Text != "")
                {
                    Participants.Add(new Participant { TTID = int.Parse(t.Text) });
                }
            }
            return this;
        }

        public static Team GetTeam(int teamID)
        {
            DataTable teamDataTable = new DataTable();
            teamDataTable = TeamRepository.GetTeam(teamID);

            List<Participant> participants = new List<Participant>();
            foreach (DataRow row in teamDataTable.Rows)
            {
                participants.Add(new Participant { TTID = (int)row["TTID"] });
            }

            Team team = new Team
            {
                ID = teamID,
                Participants = participants
            };
            return team;
        }


        public static bool DeleteTeam(int teamID)
        {
            return TeamRepository.DeleteTeam(teamID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using EMS.Repository;
using EMS.Model.Enums;

/// <summary>
/// Society class contains the properties and functionality of a society
/// </summary>

namespace EMS.Model
{
    public class Society
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }

        public static List<Event> GetEvents(SocietyType society)
        {
            DataTable eventsDataTable = SocietyRepository.GetEvents((int)society);
            List<Event> events = new List<Event>();
            foreach (DataRow row in eventsDataTable.Rows)
            {
                events.Add(new Event { ID = (int)row["EventID"], Name = row["EventName"].ToString(), MaxTeamSize = (int)row["MaxTeamSize"] });
            }
            return events;
        }

        public static List<Society> GetAllSocieties()
        {
            DataTable societiesDataTable = SocietyRepository.GetAllSocieties();
            List<Society> societies = new List<Society>();
            foreach (DataRow row in societiesDataTable.Rows)
            {
                societies.Add(new Society { ID = (int)row["SocietyID"], Name = (string)row["SocietyName"] });
            }
            return societies;
        }
    }
}

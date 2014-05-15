using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Repository;
using System.Data;

/// <summary>
/// This class contains the properties of Events.
/// </summary>

namespace EMS.Model
{
    [Serializable]
    public class Event
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxTeamSize { get; set; }
        public bool IsSinglePlayer { get; set; }
        #endregion

        public static int CreateNewTeam(Event e, Team t)
        {
            return EventRepository.CreateNewTeam(e, t);
        }
        
        public static List<Event> GetAllEvents()
        {
            DataTable eventsDataTable = EventRepository.GetAllEvents();
            List<Event> events = new List<Event>();
            foreach (DataRow row in eventsDataTable.Rows)
            {
                events.Add(new Event
                {
                    ID = (int)row["EventID"],
                    Name = (string)row["EventName"],
                    MaxTeamSize = (int)row["MaxTeamSize"],
                    IsSinglePlayer = (int)row["MaxTeamSize"] == 1
                });
            }
            return events;
        }

        public static Event GetEventDetails(int eventID)
        {
            DataTable eventDataTable = EventRepository.GetEventDetails(eventID);
            if (eventDataTable.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = eventDataTable.Rows[0];
                Event ev = new Event
                {
                    Name = (string)row["EventName"],
                    ID = (int)row["EventID"],
                    MaxTeamSize = (int)row["MaxTeamSize"],
                    IsSinglePlayer = (int)row["MaxTeamSize"] == 1
                };
                return ev;
            }
        }

        public static Event GetEventDetails(string eventName)
        {
            DataTable eventDataTable = EventRepository.GetEventDetails(eventName);
            if (eventDataTable.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = eventDataTable.Rows[0];
                Event ev = new Event
                {
                    Name = (string)row["EventName"],
                    ID = (int)row["EventID"],
                    MaxTeamSize = (int)row["MaxTeamSize"],
                    IsSinglePlayer = (int)row["MaxTeamSize"] == 1
                };
                return ev;
            }
        }

        public static DataTable GetParticipantsForPromotion(Event ev)
        {
            return EventRepository.GetParticipantsForPromotion(ev.ID);            
        }

        public static bool PromoteParticipants(List<int> participantID,Event ev)
        {
            return EventRepository.PromoteParticipants(participantID, ev);
        }

        public static DataTable GetRegisteredParticipants(Event ev,int level)
        {
            return EventRepository.GetRegisteredParticipants(ev, level);
        }

        public static int GetCurrentLevel(int eventID)
        {
            return EventRepository.GetCurrentLevel(eventID);
        }        
    }
}

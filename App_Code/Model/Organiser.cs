using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Repository;
using EMS.Model.Enums;
using System.Data;

/// <summary>
/// Summary description for Organiser
/// </summary>

namespace EMS.Model
{
    [Serializable]
    public class Organiser : Participant
    {
        public string Username { get; set; }
        public SocietyType Society { get; set; }

        public static bool AddNewOrganiser(Organiser organiser)
        {
            return OrganiserRepository.AddNewOrganiser(organiser);
        }

        public static Organiser GetOrganiserDetails(string username,string password)
        {
            DataTable organiserDataTable = OrganiserRepository.GetOrganiserDetails(username, password);
            if (organiserDataTable.Rows.Count > 0)
            {
                DataRow organiserRow = organiserDataTable.Rows[0];
                Organiser organiser = new Organiser
                {
                    Name = organiserRow["Name"].ToString(),
                    Password = organiserRow["Password"].ToString(),
                    Username = organiserRow["Username"].ToString(),
                    Society = (SocietyType)Enum.Parse(typeof(SocietyType),organiserRow["SocietyID"].ToString())
                };
                return organiser;
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMS.Model;
using System.Data;

/// <summary>
/// Summary description for OrganiserRepository
/// </summary>

namespace EMS.Repository
{
    public static class OrganiserRepository
    {
        static string sql = "";
        static Connect c;

        /// <summary>
        /// This method registers the organisers of different society.
        /// </summary>
        /// <param name="organiser">An object of Organiser Class.</param>
        /// <returns>It returns true if the organiser is registered otherwise false.</returns>
        public static bool AddNewOrganiser(Organiser organiser)
        {
            sql = "INSERT INTO Login(Name,Password,SocietyID,Username) VALUES(@name,@password,@societyID,@username)";
            Connect.ConnectEMS();
            string[] s = { "@name", "@password", "@societyID", "@username" };
            try
            {
                c = new Connect(sql, s, organiser.Name, organiser.Password, (int)organiser.Society, organiser.Username);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// This method fetches the details of the organiser based on the username and password.
        /// </summary>
        /// <param name="username">A string containing the username of the organiser.</param>
        /// <param name="password">A string containing the password of the organiser.</param>
        /// <returns>It returns a data table containing the details of the organiser.</returns>
        public static DataTable GetOrganiserDetails(string username,string password)
        {
            sql = "SELECT * FROM Login WHERE Username=@username AND Password=@password";
            Connect.ConnectEMS();
            string[] s = { "@username", "@password" };
            c = new Connect(sql, s, username, password);
            return c.ds.Tables[0];
        }
    }
}

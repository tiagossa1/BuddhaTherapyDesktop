using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TherapyManagementSystem.Common;
using TherapyManagementSystem.Common.Models;

namespace TherapyManagementSystem.DataAccessLayer
{
    public class TherapistDAL
    {
        public List<Therapist> GetAllTherapists()
        {
            List<Therapist> therapists = new List<Therapist>();

            string cs = $"URI=file:{Constants.DatabasePath}";

            using (var dbConnection = new SQLiteConnection(cs))
            {
                dbConnection.Open();

                const string query = "SELECT * FROM Therapists";

                using (var command = new SQLiteCommand(query, dbConnection))
                {
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var therapist = new Therapist()
                            {
                                ID = dataReader.GetString(0),
                                Name = dataReader.GetString(1),
                                Gender = dataReader.GetString(2),
                                MobileNumber = dataReader.GetString(3),
                                Email = dataReader.GetString(4),
                                Address = dataReader.GetString(5),
                                Username = dataReader.GetString(6),
                                Password = dataReader.GetString(7)
                            };

                            therapists.Add(therapist);
                        }
                    }
                }
            }

            return therapists;
        }
    }
}

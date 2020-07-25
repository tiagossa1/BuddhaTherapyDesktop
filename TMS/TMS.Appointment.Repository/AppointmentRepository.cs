using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TMS.Appointment.Domain.Interfaces;
using TMS.Appointment.Domain.Models;

namespace TMS.Appointment.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private const string tableName = "appointment";

        public bool Delete(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<AppointmentModel>(tableName);

                    if (col.FindById(id) != null)
                    {
                        return col.Delete(id);
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteByClientID(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<AppointmentModel>(tableName);

                    var findAppointmentByClientID = col.FindOne(x => x.ClientID == id);

                    if (findAppointmentByClientID != null)
                    {
                        return col.Delete(findAppointmentByClientID.Id);
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public AppointmentModel Get(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<AppointmentModel>(tableName);
                    return col.FindById(id);
                }
            }
            catch
            {
                return new AppointmentModel();
            }
        }

        public List<AppointmentModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<AppointmentModel>(tableName);
                    return col.FindAll().ToList();
                }
            }
            catch
            {
                return new List<AppointmentModel>();
            }
        }

        public bool Create(AppointmentModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<AppointmentModel>(tableName);
                    Guid id = col.Insert(obj);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(AppointmentModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<AppointmentModel>(tableName);
                    return col.Update(obj);
                }
            }
            catch
            {
                return false;
            }
        }

    }
}

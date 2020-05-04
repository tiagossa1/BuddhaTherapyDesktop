using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;

namespace TMS.Clientes.Repository.Repository
{
    public class ClientRepository : IClientRepository
    {
        public bool Post(ClientModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>("cliente");
                    Guid id = col.Insert(obj);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Delete(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>("cliente");
                    if (col.FindById(id) != new ClientModel())
                        return col.Delete(id);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public Client.Domain.Model.ClientModel Get(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>("cliente");
                    return col.FindById(id);
                }
            }
            catch
            {
                return new Client.Domain.Model.ClientModel();
            }
        }

        public IList<Client.Domain.Model.ClientModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>("cliente");
                    return col.FindAll().ToList();
                }
            }
            catch
            {
                return new List<Client.Domain.Model.ClientModel>();
            }
        }

        public bool Put(Client.Domain.Model.ClientModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>("cliente");
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

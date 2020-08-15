﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Client.Domain.Interfaces;
using TMS.Client.Domain.Model;

namespace TMS.Clientes.Repository.Repository
{
    public class ClientRepository : IClientRepository
    {
        private const string tableName = "client";

        public bool Create(ClientModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>(tableName);
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
                    var col = db.GetCollection<ClientModel>(tableName);
                    if (col.FindById(id) != null)
                        return col.Delete(id);
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public ClientModel Get(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>(tableName);
                    return col.FindById(id);
                }
            }
            catch
            {
                return new ClientModel();
            }
        }

        public List<ClientModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>(tableName);
                    return col.FindAll().ToList();
                }
            }
            catch (Exception)
            {
                return new List<ClientModel>();
            }
        }

        public bool Edit(ClientModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<ClientModel>(tableName);
                    return col.Update(obj);
                }
            }
            catch
            {
                return false;
            }
        }

        public long Count()
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    return db.GetCollection<ClientModel>(tableName).LongCount();
                }
            }
            catch
            {
                return default;
            }
        }
    }
}

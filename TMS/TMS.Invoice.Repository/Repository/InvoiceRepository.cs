using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Invoice.Domain.Interfaces;
using TMS.Invoice.Domain.Models;

namespace TMS.Invoice.Repository.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly string collectionName = "invoice";
        public bool Delete(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(collectionName);
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

        public InvoiceModel Get(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(collectionName);
                    return col.FindById(id);
                }
            }
            catch
            {
                return new InvoiceModel();
            }
        }

        public IList<InvoiceModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(collectionName);
                    return col.FindAll().ToList();
                }
            }
            catch
            {
                return new List<InvoiceModel>();
            }
        }

        public bool Post(InvoiceModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(collectionName);
                    Guid id = col.Insert(obj);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Put(InvoiceModel obj)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(collectionName);
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

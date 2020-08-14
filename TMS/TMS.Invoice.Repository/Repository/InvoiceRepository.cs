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
        private const string tableName = "invoice";

        public bool Delete(Guid id)
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(tableName);
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
                    var col = db.GetCollection<InvoiceModel>(tableName);

                    return col.FindById(id);
                }
            }
            catch
            {
                return new InvoiceModel();
            }
        }

        public List<InvoiceModel> GetAll()
        {
            try
            {
                using (var db = new LiteDatabase("Database.db"))
                {
                    var col = db.GetCollection<InvoiceModel>(tableName);
                    return col.FindAll().ToList();
                }
            }
            catch (Exception)
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
                    var col = db.GetCollection<InvoiceModel>(tableName);
                    col.Insert(obj);
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
                    var col = db.GetCollection<InvoiceModel>(tableName);
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

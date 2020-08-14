using Dapper;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ImportRepository
{
    public class Repository : IRepository
    {
        public string ConnectionString { get; set; }
        public Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<AccessClientModel> Get()
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                var output = conn.Query<AccessClientModel>("select * from Clientes", new DynamicParameters());
                return output.ToList();
            }
        }
    }
}

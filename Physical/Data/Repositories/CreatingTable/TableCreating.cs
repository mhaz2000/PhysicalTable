using Data.Context;
using Data.Models;
using Data.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.CreatingTable
{
    class TableCreating : Repository, ITableCreating
    {
        private PhysicalDB _db;
        public TableCreating()
        {
            _db = new PhysicalDB();
        }
        //Add new table into data base.
        public void AddTable(string tableName, string[] fieldNames, string[] fieldTypes)
        {
            string query = GetSqlQuery.CreateTableQuery(tableName, fieldNames, fieldTypes);
            _db.Database.ExecuteSqlCommand(query);

            Log log = new Log(tableName);
            _db.Logs.Add(log);

            _db.SaveChanges();
        }
    }
}

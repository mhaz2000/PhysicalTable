using Data.Context;
using Data.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.AddingValueToTable
{
    class TableAdding : Repository, ITableAdding
    {
        //Add new values into a table.
        public void AddValueToTable(string[] Values, string tableName)
        {
            string query = GetSqlQuery.AddValueQuery(Values, tableName, GetAllFieldTypes(tableName), GetAllFieldNames(tableName));

            _db.Database.ExecuteSqlCommand(query);
        }
    }
}

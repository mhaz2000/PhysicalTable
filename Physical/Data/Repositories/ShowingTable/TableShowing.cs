using Data.Context;
using Data.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.ShowingTable
{
    class TableShowing : Repository, ITableShowing
    {
        private PhysicalDB _db;
        public TableShowing()
        {
            _db = new PhysicalDB();
        }
        //return full table.
        public List<object> GetFullTable(string tableName)
        {
            List<object> values = new List<object>();
            var FieldNames = GetAllFieldNames(tableName);
            var types = GetAllFieldTypes(tableName);

            for (int i = 0; i < FieldNames.Count; i++)
            {
                string query = GetSqlQuery.FeildValueQuery(tableName, FieldNames[i]);
                switch (types[i])
                {
                    case "int":
                        var result1 = _db.Database.SqlQuery<int>(query).ToList();
                        foreach (var item in result1)
                        {
                            values.Add(item);
                        }
                        break;
                    case "nvarchar":
                        var result2 = _db.Database.SqlQuery<string>(query).ToList();
                        foreach (var item in result2)
                        {
                            values.Add(item);
                        }
                        break;
                    case "char":
                        var result3 = _db.Database.SqlQuery<char>(query).ToList();
                        foreach (var item in result3)
                        {
                            values.Add(item);
                        }
                        break;
                    case "float":
                        var result4 = _db.Database.SqlQuery<double>(query).ToList();
                        foreach (var item in result4)
                        {
                            values.Add(item);
                        }
                        break;
                    case "real":
                        var result5 = _db.Database.SqlQuery<Single>(query).ToList();
                        foreach (var item in result5)
                        {
                            values.Add(item);
                        }
                        break;
                    case "DateTime":
                        var result6 = _db.Database.SqlQuery<DateTime>(query).ToList();
                        foreach (var item in result6)
                        {
                            values.Add(item);
                        }
                        break;
                }
            }
            return values;
        }
    }
}

using Data.Context;
using Data.SqlQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository : IRepository
    {
        protected PhysicalDB _db;

        public Repository()
        {
            _db = new PhysicalDB();
        }

        //Gets all field names of a table by a given name.
        public List<string> GetAllFieldNames(string name)
        {
            string query = GetSqlQuery.AllFieldNamesQuery(name);
            var results = _db.Database.SqlQuery<string>(query).ToList();

            return results.Where(w => !w.ToLower().Contains("id")).ToList();
        }

        //Gets all field Types.
        public List<string> GetAllFieldTypes(string name)
        {
            string query = GetSqlQuery.AllFieldTypesQuery(name);
            return _db.Database.SqlQuery<string>(query).ToList();
        }

        //return all the table names in a database.
        public List<string> GetAllTableName()
        {
            var names= _db.Database.SqlQuery<string>(GetSqlQuery.TableNamesQuery("PhysicalDB")).ToList();
            names.Remove("Logs");
            names.Remove("__MigrationHistory");

            return names;
        }
    }
}

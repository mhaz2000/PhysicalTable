using Physical.Context;
using Physical.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.Services.AddingValueToTableServices
{
    class AddValueService : AddValueQueryConstructor, IAddValueService
    {
        private PhysicalDB _db;
        public AddValueService()
        {
            _db = new PhysicalDB();
        }

        public void AddValueToTable(AddNewValueDto table)
        {
            string query = AddValueQueryConstructor.AddValueQuery(table.FieldValues,table.ChosenName,
                GetAllFieldTypes(table.ChosenName), GetAllFieldNames(table.ChosenName));

            _db.Database.ExecuteSqlCommand(query);
        }

        //Gets all field names of a table by a given name.
        public List<string> GetAllFieldNames(string name)
        {
            string query = AddValueQueryConstructor.AllFieldNamesQuery(name);
            var results = _db.Database.SqlQuery<string>(query).ToList();
            
            return results.Where(w => !w.ToLower().Contains("id")).ToList();
        }

        //Gets all field Types.
        public List<string> GetAllFieldTypes(string name)
        {
            string query = AddValueQueryConstructor.AllFieldTypesQuery(name);
            return _db.Database.SqlQuery<string>(query).ToList();
        }

        //Gets all table names.
        public List<string> GetAllTableNames()
        {
            List<string> result = _db.Database.SqlQuery<string>(AddValueQueryConstructor.AllTableNamesQuery("PhysicalDB")).ToList();
            result.Remove("__MigrationHistory");
            result.Remove("Logs");
            return result;
        }
    }
}
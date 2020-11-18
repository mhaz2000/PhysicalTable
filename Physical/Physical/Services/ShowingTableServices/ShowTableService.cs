using Physical.Context;
using Physical.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.Services.ShowingTableServices
{
    class ShowTableService : ShowTableQueryConstructor, IShowTableService
    {
        private PhysicalDB _db;
        public ShowTableService()
        {
            _db = new PhysicalDB();
        }

        //Gets all field Names by a given name.
        public List<string> GetAllFieldNames(string name)
        {
            string query = ShowTableQueryConstructor.AllFieldNamesQuery(name);
            var results = _db.Database.SqlQuery<string>(query).ToList();

            return results.Where(w => !w.ToLower().Contains("id")).ToList();
        }

        //Gets all fields types in a table.
        public List<string> GetAllFieldTypes(string name)
        {
            string query = ShowTableQueryConstructor.AllFieldTypesQuery(name);
            return _db.Database.SqlQuery<string>(query).ToList();
        }

        //Gets a list of all table names in data base.
        public List<string> GetAllTableNames()
        {
            string query = ShowTableQueryConstructor.AllTableNamesQuery("PhysicalDB");
            List<string> result = _db.Database.SqlQuery<string>(query).ToList();
            result.Remove("__MigrationHistory");
            result.Remove("Logs");

            return result;
        }

        //Gets whole of a table according to its name.
        public void GetFullTable(ShowTableDto table)
        {
            List<object> values = new List<object>();
            table.FieldNames = GetAllFieldNames(table.ChosenName);

            var types = GetAllFieldTypes(table.ChosenName);

            for (int i = 0; i < table.FieldNames.Count; i++)
            {
                string query = ShowTableQueryConstructor.FeildValueQuery(table.ChosenName,table.FieldNames[i]);
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
            table.TableNames = GetAllTableNames();
            table.Width = table.FieldNames.Count;
            table.Height = values.Count / table.FieldNames.Count;
            table.Values=values;
        }
    }
}
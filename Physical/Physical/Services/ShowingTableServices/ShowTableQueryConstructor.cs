using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.Services.ShowingTableServices
{
    class ShowTableQueryConstructor
    {
        //returns a query for getting field types.
        protected static string AllFieldTypesQuery(string name)
        {
            return "SELECT DATA_TYPE FROM " +
                    "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + name + "' AND COLUMN_NAME not LIKE '%ID'";
        }
        //Get a query for getting all table names.
        protected static string AllTableNamesQuery(string name)
        {
            return "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='" + name + "'";
        }

        //Get all feild names an specific table
        protected static string AllFieldNamesQuery(string name)
        {
            return "SELECT COLUMN_NAME FROM " +
                    "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + name + "'";
        }
        //returns a query for getting a record from table according to its name.
        protected static string FeildValueQuery(string tableName, string fieldName)
        {
            return "SELECT " + fieldName + " from " + tableName;
        }
    }
}
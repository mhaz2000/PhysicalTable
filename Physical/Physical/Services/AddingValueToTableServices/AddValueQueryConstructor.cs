using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physical.Services.AddingValueToTableServices
{
    class AddValueQueryConstructor
    {
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

        //returns a query for adding value to data base.
        protected static string AddValueQuery(string[] values, string tableName,List<string> fieldTypes,List<string> fieldNames)
        {
            string query = "Insert into " + tableName + " (";
            for (int i = 0; i < fieldNames.Count; i++)
            {
                query += fieldNames[i];

                if (i == fieldNames.Count - 1)
                    query += ")";
                else
                    query += ",";
            }


            query += " Values(";
            for (int i = 0; i < fieldNames.Count; i++)
            {
                //strings must be in single quotation.
                if (fieldTypes[i] == "nvarchar")
                    query += "'" + values[i] + "'";
                else
                    query += values[i];


                if (i == fieldNames.Count - 1)
                    query += ")";
                else
                    query += ",";
            }

            return query;
        }

        //returns a query for getting field types.
        protected static string AllFieldTypesQuery(string name)
        {
            return "SELECT DATA_TYPE FROM " +
                    "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + name + "' AND COLUMN_NAME not LIKE '%ID'";
        }
    }
}
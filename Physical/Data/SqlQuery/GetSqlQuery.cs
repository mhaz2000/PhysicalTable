using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlQuery
{
    public class GetSqlQuery
    {
        //Gets a query for getting all table names.
        public static string TableNamesQuery(string name)
        {
            return "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='" + name + "'";
        }

        //Gets a query for creating a table in data base.
        public static string CreateTableQuery(string tableName, string[] fieldNames, string[] fieldTypes)
        {
            string query = "create table " + tableName + " (" + tableName + "ID int primary key identity";
            for (int i = 0; i < fieldTypes.Length; i++)
            {
                query += "," + fieldNames[i] + " " + fieldTypes[i];
            }
            query += ")";

            return query;
        }
        //Gets a query for getting all field names.
        public static string AllFieldNamesQuery(string name)
        {
            return "SELECT COLUMN_NAME FROM " +
                    "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + name + "'";
        }

        //Gets a query for getting all fields type.
        public static string AllFieldTypesQuery(string name)
        {
            return "SELECT DATA_TYPE FROM " +
                    "INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + name + "' AND COLUMN_NAME not LIKE '%ID'";
        }
        //Gets a query for add new values to a table.
        public static string AddValueQuery(string[] values, string tableName, List<string> fieldTypes, List<string> fieldNames)
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

        //returns a query for getting a record from table according to its name.
        public static string FeildValueQuery(string tableName, string fieldName)
        {
            return "SELECT " + fieldName + " from " + tableName;
        }
    }
}

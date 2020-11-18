using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Physical.Common.Enums;

namespace Physical.Services.TableCreationServices
{
    class CreationQueryConstructor
    {
        //returns a query for showing all table names
        protected static string TableNamesQuery(string name)
        {
            return "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='"+name+"'";
        }

        //returns a query for creating a table.
        protected static string CreateTable(string tableName,string[] fieldNames,string[] fieldTypes)
        {
            string query = "create table " + tableName + " (" + tableName + "ID int primary key identity";
            for (int i = 0; i < fieldTypes.Length; i++)
            {
                query += "," + fieldNames[i] + " " + fieldTypes[i];
            }
            query += ")";

            return query;
        }
    }
}
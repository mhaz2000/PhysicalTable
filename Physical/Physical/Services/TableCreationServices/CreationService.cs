using Physical.Context;
using Physical.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Physical.Common.Messages;
using Physical.Common.TypeConvertion;
using Physical.Models;

namespace Physical.Services.TableCreationServices
{
    class CreationService : CreationQueryConstructor, ICreationService
    {
        private PhysicalDB _db;
        public CreationService()
        {
            _db = new PhysicalDB();
        }

        //Add new table in database.
        public void AddTable(TableStructionDto tableStruction)
        {
            string query = CreationQueryConstructor.CreateTable(tableStruction.tableName, tableStruction.FieldNames
                 , TypeConvert.TypeExtraction(tableStruction.FieldTypes));
            int result = _db.Database.ExecuteSqlCommand(query);

            //log new table.
            Log log = new Log(tableStruction.tableName);
            _db.Logs.Add(log);
            Save();
        }

        //Checks if new table has a repetitive name or not and set a suitable message.
        public TableStructionDto CheckNewTable(TableStructionDto table)
        {
            var names = GetTableNames();
            if (names.Where(w => w.Contains(table.tableName)).Any())
            {
                table.Message = Message.RepetitiveTableName();
                table.FieldNumber = 0;
            }
            else
                table.Message = Message.AcceptableName();

            return table;
        }

        //Gets all table names.
        public List<string> GetTableNames()
        {
            List<string> result = _db.Database.SqlQuery<string>(CreationQueryConstructor.TableNamesQuery("PhysicalDB")).ToList();
            result.Remove("__MigrationHistory");
            result.Remove("Logs");
            return result;
        }

        //Saves all changes.
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
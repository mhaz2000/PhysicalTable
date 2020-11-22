using Common.DTOs;
using Common.Messages;
using Common.TypeConvertion;
using Data.DataUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CreateTableService
{
    public class CreatingService : ICreatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreatingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //Add new Table into data base.
        public void AddTable(TableStructionDto table)
        {
            _unitOfWork.TableCreating.AddTable(table.tableName, table.FieldNames, TypeConvert.TypeExtraction(table.FieldTypes));
        }

        //Checks if new table name is valid or not.
        public TableStructionDto CheckNewTable(TableStructionDto table)
        {
            var names = _unitOfWork.TableCreating.GetAllTableName();

            //Checks if the given name is repetitive or not.
            if (names.Where(w => w.Contains(table.tableName)).Any())
            {
                table.Message = Message.RepetitiveTableName();
                table.FieldNumber = 0;
                return table;
            }
            table.Message = Message.AcceptableName();

            return table;
        }
    }
}

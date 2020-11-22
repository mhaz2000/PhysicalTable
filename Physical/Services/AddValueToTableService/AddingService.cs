using Common.DTOs;
using Data.DataUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AddValueToTableService
{
    public class AddingService : IAddingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //add values to a table.
        public void AddValueToTable(AddNewValueDto table)
        {
            _unitOfWork.TableAdding.AddValueToTable(table.FieldValues, table.ChosenName);
        }
        //Gets Fields name.
        public List<string> GetTableFieldNames(AddNewValueDto table)
        {
            return _unitOfWork.TableAdding.GetAllFieldNames(table.ChosenName);
        }
        //Gets all table names.
        public List<string> GetTableNames()
        {
            return _unitOfWork.TableAdding.GetAllTableName();
        }
    }
}

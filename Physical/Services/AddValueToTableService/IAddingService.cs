using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AddValueToTableService
{
    public interface IAddingService
    {
        void AddValueToTable(AddNewValueDto table);
        List<string> GetTableNames();
        List<string> GetTableFieldNames(AddNewValueDto table);
    }
}

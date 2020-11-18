using Physical.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physical.Services.AddingValueToTableServices
{
    interface IAddValueService
    {
        List<string> GetAllTableNames();
        List<string> GetAllFieldNames(string name);
        void AddValueToTable(AddNewValueDto table);
        List<string> GetAllFieldTypes(string name);
    }
}

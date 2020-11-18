using Physical.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physical.Services.ShowingTableServices
{
    public interface IShowTableService
    {
        List<string> GetAllTableNames();
        List<string> GetAllFieldNames(string name);
        List<string> GetAllFieldTypes(string name);
        void GetFullTable(ShowTableDto table);

    }
}

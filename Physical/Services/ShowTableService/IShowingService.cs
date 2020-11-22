using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShowTableService
{
    public interface IShowingService
    {
        ShowTableDto GetFullTable(ShowTableDto table);
        List<string> GetTableNames();
    }
}

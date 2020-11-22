using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.ShowingTable
{
    public interface ITableShowing : IRepository
    {
        List<object> GetFullTable(string tableName);
    }
}

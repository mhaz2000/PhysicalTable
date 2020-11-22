using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.AddingValueToTable
{
    public interface ITableAdding : IRepository
    {
        void AddValueToTable(string[] Values, string tableName);
    }
}

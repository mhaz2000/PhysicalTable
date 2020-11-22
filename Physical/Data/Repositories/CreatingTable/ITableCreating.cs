using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.CreatingTable
{
    public interface ITableCreating : IRepository
    {
        void AddTable(string tableName, string[] fieldNames, string[] fieldTypes);
    }
}

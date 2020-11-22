using Data.Repositories.AddingValueToTable;
using Data.Repositories.CreatingTable;
using Data.Repositories.ShowingTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITableAdding TableAdding { get; }
        ITableCreating TableCreating { get; }
        ITableShowing TableShowing { get; }
    }
}

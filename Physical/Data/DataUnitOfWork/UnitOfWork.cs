using Data.Context;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhysicalDB _db;
        public UnitOfWork(PhysicalDB db)
        {
            _db = db;

            TableCreating = new TableCreating();
            TableAdding = new TableAdding();
            TableShowing = new TableShowing();
        }
        public ITableAdding TableAdding { get; }

        public ITableCreating TableCreating { get; }

        public ITableShowing TableShowing { get; }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

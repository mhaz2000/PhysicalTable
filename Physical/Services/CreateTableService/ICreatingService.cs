using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CreateTableService
{
    public interface ICreatingService
    {
        TableStructionDto CheckNewTable(TableStructionDto table);
        void AddTable(TableStructionDto table);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physical.DTOs;

namespace Physical.Services.TableCreationServices
{
    public interface ICreationService
    {
        List<string> GetTableNames();
        TableStructionDto CheckNewTable(TableStructionDto table);
        void AddTable(TableStructionDto tableStruction);
        void Save();

    }
}

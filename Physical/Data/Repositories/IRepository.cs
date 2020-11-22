using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository
    {
        List<string> GetAllTableName();
        List<string> GetAllFieldTypes(string name);
        List<string> GetAllFieldNames(string name);
    }
}

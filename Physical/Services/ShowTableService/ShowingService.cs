using Common.DTOs;
using Data.DataUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShowTableService
{
    public class ShowingService : IShowingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShowingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //gets a full table by a given name.
        public ShowTableDto GetFullTable(ShowTableDto table)
        {
            table.FieldNames = _unitOfWork.TableShowing.GetAllFieldNames(table.ChosenName);
            table.Values = _unitOfWork.TableShowing.GetFullTable(table.ChosenName);
            table.Width = table.FieldNames.Count;
            table.Height = table.Values.Count / table.FieldNames.Count;

            return table;
        }
        //Gets all table name.
        public List<string> GetTableNames()
        {
            return _unitOfWork.TableShowing.GetAllTableName();
        }
    }
}

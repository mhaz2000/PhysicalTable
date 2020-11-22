using Common.DTOs;
using Services.AddValueToTableService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physical.Controllers
{
    public class AddValueController : Controller
    {
        private readonly IAddingService _service;

        public AddValueController(IAddingService service)
        {
            _service = service;
        }
        // GET: AddValue
        public ActionResult AddValue()
        {
            return View(new AddNewValueDto(_service.GetTableNames()));
        }
        [HttpPost]
        public ActionResult AddValue([Bind(Include = "ChosenName,FieldValues")] AddNewValueDto table)
        {
            //Checks if user insert values or not.
            if (table.FieldValues is null)
            {
                table.FieldNames = _service.GetTableFieldNames(table);
                table.TableNames = _service.GetTableNames();
                return View(table);
            }

            _service.AddValueToTable(table);
            return RedirectToAction("Index","Home");
        }
    }
}
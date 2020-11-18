using Physical.DTOs;
using Physical.Services.AddingValueToTableServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physical.Controllers
{
    public class AddValueController : Controller
    {
        private readonly IAddValueService _service;

        public AddValueController(IAddValueService service)
        {
            _service = service;
        }
        // GET: AddValue
        public ActionResult AddValue()
        {
            return View(new AddNewValueDto(_service.GetAllTableNames()));
        }
        [HttpPost]
        public ActionResult AddValue([Bind(Include = "ChosenName,FieldValues")] AddNewValueDto table)
        {
            //Checks if user insert values or not.
            if (table.FieldValues is null)
            {
                table.FieldNames = _service.GetAllFieldNames(table.ChosenName);
                table.TableNames = _service.GetAllTableNames();
                return View(table);
            }

            _service.AddValueToTable(table);
            return RedirectToAction("Index","Home");
        }
    }
}
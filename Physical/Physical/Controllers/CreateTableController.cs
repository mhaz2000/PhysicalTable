using Physical.DTOs;
using Physical.Services.TableCreationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physical.Controllers
{
    public class CreateTableController : Controller
    {
        private readonly ICreationService _service;

        public CreateTableController(ICreationService service)
        {
            _service = service;
        }
        // GET: CreateTable
        public ActionResult CreateTable()
        {
            return View(new TableStructionDto());
        }

        [HttpPost]
        public ActionResult CreateTable([Bind(Include = "FieldNumber, tableName, FieldTypes, FieldNames")] TableStructionDto table)
        {
            if (table.FieldNames is null)
                return View(_service.CheckNewTable(table));

            _service.AddTable(table);
            return RedirectToAction("Index", "Home");
        }
    }
}
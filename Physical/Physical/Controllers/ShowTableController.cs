using Common.DTOs;
using Services.ShowTableService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physical.Controllers
{
    public class ShowTableController : Controller
    {
        private readonly IShowingService _service;
        public ShowTableController(IShowingService service)
        {
            _service = service;
        }
        // GET: ShowTable
        public ActionResult ShowTable()
        {
            return View(new ShowTableDto(_service.GetTableNames()));
        }
        [HttpPost]
        public ActionResult ShowTable([Bind(Include = "ChosenName")] ShowTableDto table)
        {
            table.TableNames = _service.GetTableNames();
            _service.GetFullTable(table);
            return View(table);
        }
    }
}
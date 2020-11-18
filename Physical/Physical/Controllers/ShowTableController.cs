using Physical.DTOs;
using Physical.Services.ShowingTableServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Physical.Controllers
{
    public class ShowTableController : Controller
    {
        private readonly IShowTableService _service;
        public ShowTableController()
        {
            _service = new ShowTableService();
        }
        // GET: ShowTable
        public ActionResult ShowTable()
        {
            return View(new ShowTableDto(_service.GetAllTableNames()));
        }
        [HttpPost]
        public ActionResult ShowTable([Bind(Include = "ChosenName")] ShowTableDto table)
        {
            _service.GetFullTable(table);
            return View(table);
        }
    }
}
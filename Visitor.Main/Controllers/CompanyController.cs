using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visitor.Main.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            TempData["data"] = "Page where list of Companies will be displayed";
            return View("Trial");
        }
    }
}
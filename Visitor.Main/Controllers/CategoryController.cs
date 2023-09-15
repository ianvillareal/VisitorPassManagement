using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visitor.Main.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            TempData["data"] = "Page where list of Categories will be displayed";
            return View("Trial");
        }
    }
}
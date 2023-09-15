using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visitor.Main.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            TempData["data"] = "Page where list of Users will be displayed";
            return View("Trial");
        }
    }
}
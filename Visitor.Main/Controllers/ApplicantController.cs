using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visitor.Main.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant
        public ActionResult Index()
        {
            TempData["data"] = "Page where list of Applicants will be displayed";
            return View("Trial");
        }
    }
}
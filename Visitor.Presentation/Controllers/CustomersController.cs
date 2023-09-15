using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visitor.Presentation.ViewModels;

namespace Visitor.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddSubCustomer(SubCustomerViewModel subCustomerViewModel, int subCustomerNumber)
        {
            subCustomerViewModel.SubCustomerId = 0;
            subCustomerViewModel.ForAddition = true;
            subCustomerViewModel.SubCustomerCount = subCustomerNumber;
            return PartialView("_UpdateSubCustomerRecord", subCustomerViewModel);
        }

        public ActionResult UpdateSubCustomerRecord(SubCustomerViewModel subCustomerViewModel, int subCustomerNumber)
        {
            subCustomerViewModel.SubCustomerCount = subCustomerNumber;
            subCustomerViewModel.ForAddition = false;
            return PartialView("_UpdateSubCustomerRecord", subCustomerViewModel);
        }


    }
}
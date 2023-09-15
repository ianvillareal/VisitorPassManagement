using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visitor.Core;
using Visitor.Presentation.ViewModels;
using Visitor.Service;
using Visitor.Service.DTO;
namespace Visitor.Presentation.Controllers
{
    [Authorize]
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Index()
        {
            var viewModel = new VisitorSearchFilterViewModel();
            return RedirectToAction("Search", viewModel);
        }

        public ActionResult Search(VisitorSearchFilterViewModel viewModel)
        {
            viewModel.RequestorId = User.Identity.GetUserId();
            return View(viewModel);
        }

        public ActionResult View(long id)
        {
            var visitorService = new VisitorService();
            var visitorDetails = visitorService.ViewDetails(id);
            var visitorViewModel = Mapper.Map<VisitorViewModel>(visitorDetails);

            //itemViewModel.ItemDetailsPreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return View(visitorViewModel);
        }

        [HttpPost]
        [ActionName("CompleteOrPending")]
        public ActionResult CompleteOrPendingPost(VisitorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                var visitorRequestDTO = Mapper.Map<VisitorRequestDTO>(viewModel);

                visitorService.PrepareAndUpdate(visitorRequestDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View("View", viewModel);
            }
        }
    }
}
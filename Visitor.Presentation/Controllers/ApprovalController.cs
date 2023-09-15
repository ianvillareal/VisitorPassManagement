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
    public class ApprovalController : Controller
    {
        // GET: Approval
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

        public ActionResult Edit(long id)
        {
            var visitorService = new VisitorService();
            var visitorDetails = visitorService.ViewDetails(id);
            var visitorViewModel = Mapper.Map<VisitorViewModel>(visitorDetails);

            return View(visitorViewModel);
        }

        [HttpPost]
        [ActionName("Update")]
        public ActionResult EditPost(VisitorViewModel viewModel)
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
                return View("Edit", viewModel);
            }
        }

        [HttpGet]
        public ActionResult CreateVisit(VisitorViewModel viewModel)
        {
            viewModel.Purpose = PurposeType.Visit;
            viewModel.RequestorId = User.Identity.GetUserId();
            viewModel.Requestor = User.Identity.GetUserName();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateVisit")]
        public ActionResult CreateVisitPost(VisitorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                viewModel.Status = StatusType.ForApproval;
                var visitorRequestDTO = Mapper.Map<VisitorRequestDTO>(viewModel);

                visitorService.PrepareAndSave(visitorRequestDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateVisit", viewModel);
            }
        }

        public PartialViewResult AddVisitor()
        {
            var viewModel = new VisitorNameViewModel();
            return PartialView("_VisitorListCreationView", viewModel);
        }

        //[HttpGet]
        //public ActionResult Approve(long id)
        //{
        //    var visitorService = new VisitorService();
        //    var visitorDetails = visitorService.ViewDetails(id);
        //    var visitorViewModel = Mapper.Map<VisitorViewModel>(visitorDetails);

        //    return View(visitorViewModel);
        //}
        [HttpPost]
        [ActionName("ApproveOrDecline")]
        public ActionResult ApproveOrDeclinePost(VisitorViewModel viewModel)
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
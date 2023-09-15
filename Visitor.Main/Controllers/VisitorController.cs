using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visitor.Core;
using Visitor.Main.ViewModels;
using Visitor.Service;
using Visitor.Service.DTO;
using Visitor.Main.Helpers;

namespace Visitor.Main.Controllers
{
    [Authorize]
    public class VisitorController : Controller
    {
        // GET: Visitor
        public ActionResult Index()
        {
            var viewModel = new VisitorSearchFilterViewModel();
            return RedirectToAction("Search", viewModel);
        }

        public ActionResult Search(VisitorSearchFilterViewModel viewModel)
        {
            //viewModel.RequestorId = User.Identity.GetUserId();
            return View(viewModel);
        }

        public ActionResult View(long id)
        {
            var visitorService = new VisitorService();
            var visitorDetails = visitorService.ViewDetails(id);
            var visitorViewModel = Mapper.Map<VisitorRequestViewModel>(visitorDetails);

            //itemViewModel.ItemDetailsPreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            return View(visitorViewModel);
        }

        public ActionResult Edit(long id)
        {
            var visitorService = new VisitorService();
            var visitorDetails = visitorService.ViewDetails(id);
            var visitorViewModel = Mapper.Map<VisitorRequestViewModel>(visitorDetails);
            //visitorViewModel.Visitors = String.Join(",", visitorViewModel.VisitorList.Select(p => p.ToString()).ToArray());
            return View(visitorViewModel);
        }

        [HttpPost]
        [ActionName("Update")]
        public ActionResult EditPost(VisitorRequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                //viewModel.VisitorList = viewModel.Visitors.Split(',');
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
        public ActionResult CreateVisit(VisitorRequestViewModel viewModel)
        {
            viewModel.Purpose = PurposeType.Visit;
            viewModel.RequestorId = User.Identity.GetUserId();
            viewModel.Requestor = User.Identity.GetFullName();
            viewModel.Company = User.Identity.GetCompany();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateVisit")]
        public ActionResult CreateVisitPost(VisitorRequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                viewModel.Purpose = PurposeType.Visit;
                viewModel.Status = StatusType.ForApproval;
                //if (!string.IsNullOrEmpty(viewModel.Visitors))
                //    viewModel.VisitorList = viewModel.Visitors.Split(',');

                var visitorRequestDTO = Mapper.Map<VisitorRequestDTO>(viewModel);

                visitorService.PrepareAndSave(visitorRequestDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateVisit", viewModel);
            }
        }


        [HttpGet]
        public ActionResult CreateConstruction(VisitorRequestViewModel viewModel)
        {
            viewModel.Purpose = PurposeType.Construction;
            viewModel.RequestorId = User.Identity.GetUserId();
            viewModel.Requestor = User.Identity.GetUserName();
            viewModel.Company = User.Identity.GetCompany();

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateConstruction")]
        public ActionResult CreateConstructionPost(VisitorRequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                viewModel.Purpose = PurposeType.Construction;
                viewModel.Status = StatusType.ForApproval;
                var visitorRequestDTO = Mapper.Map<VisitorRequestDTO>(viewModel);

                visitorService.PrepareAndSave(visitorRequestDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateConstruction", viewModel);
            }
        }

        [HttpGet]
        public ActionResult CreateSeminar(VisitorRequestViewModel viewModel)
        {
            viewModel.Visitors = System.Web.Helpers.Json.Decode<List<VisitorViewModel>>(viewModel.EncodeVisitors);
            viewModel.Purpose = PurposeType.Visit;
            viewModel.Category = CategoryType.Seminar;
            viewModel.RequestorId = User.Identity.GetUserId();
            viewModel.Requestor = User.Identity.GetFullName();
            viewModel.Company = User.Identity.GetCompany();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateSeminar")]
        public ActionResult CreateSeminarPost(VisitorRequestViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                viewModel.Purpose = PurposeType.Visit;
                viewModel.Status = StatusType.Approved;

                var visitorRequestDTO = Mapper.Map<VisitorRequestDTO>(viewModel);

                visitorService.PrepareAndSave(visitorRequestDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateSeminar", viewModel);
            }
        }
        public ActionResult AddVisitor(VisitorViewModel visitorViewModel, int visitorIndex)
        {
            visitorViewModel.VisitorId = 0;
            visitorViewModel.ForAddition = true;
            visitorViewModel.Index = visitorIndex;
            return PartialView("_VisitorInlineDetails", visitorViewModel);
        }

        public ActionResult UpdateVisitor(VisitorViewModel visitorViewModel, int visitorIndex)
        {
            //subCustomerViewModel.SubCustomerCount = subCustomerNumber;
            //subCustomerViewModel.ForAddition = false;
            return PartialView("_VisitorInlineDetails", visitorViewModel);
        }
    }
}
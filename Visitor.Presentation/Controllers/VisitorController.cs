using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Visitor.Core;
using Visitor.Core.Domain;
using Visitor.Presentation.ViewModels;
using Visitor.Service;
using Visitor.Service.DTO;

namespace Visitor.Presentation.Controllers
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
            visitorViewModel.Visitors = String.Join(",", visitorViewModel.VisitorList.Select(p => p.ToString()).ToArray()); 
            return View(visitorViewModel);
        }

        [HttpPost]
        [ActionName("Update")]
        public ActionResult EditPost(VisitorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                viewModel.VisitorList = viewModel.Visitors.Split(',');
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
                viewModel.Purpose = PurposeType.Visit;
                viewModel.Status = StatusType.ForApproval;
                if (!string.IsNullOrEmpty(viewModel.Visitors))
                    viewModel.VisitorList = viewModel.Visitors.Split(',');

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
        public ActionResult CreateConstruction(VisitorViewModel viewModel)
        {
            viewModel.Purpose = PurposeType.Construction;
            viewModel.RequestorId = User.Identity.GetUserId();
            viewModel.Requestor = User.Identity.GetUserName();
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateConstruction")]
        public ActionResult CreateConstructionPost(VisitorViewModel viewModel)
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
        public ActionResult CreateSeminar(VisitorViewModel viewModel)
        {
            viewModel.VisitorList = viewModel.Visitors.Split(',');
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("CreateSeminar")]
        public ActionResult CreateSeminarPost(VisitorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var visitorService = new VisitorService();
                viewModel.Purpose = PurposeType.Visit;
                viewModel.Status = StatusType.Approved;
                if (!string.IsNullOrEmpty(viewModel.Visitors))
                    viewModel.VisitorList = viewModel.Visitors.Split(',');

                var visitorRequestDTO = Mapper.Map<VisitorRequestDTO>(viewModel);

                visitorService.PrepareAndSave(visitorRequestDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateSeminar", viewModel);
            }
        }

        public PartialViewResult AddVisitor()
        {
            var viewModel = new VisitorNameViewModel();
            return PartialView("_VisitorListCreationView", viewModel);
        }
    }
}
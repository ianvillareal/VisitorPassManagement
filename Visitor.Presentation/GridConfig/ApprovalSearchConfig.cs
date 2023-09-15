using AutoMapper;
using MVCGrid.Models;
using MVCGrid.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Visitor.Core;
using Visitor.Presentation.GridConfig.Rendering;
using Visitor.Presentation.Helpers;
using Visitor.Presentation.ViewModels;
using Visitor.Service;
using Visitor.Service.DTO;

namespace Visitor.Presentation.GridConfig
{
    internal class ApprovalSearchConfig
    {
        internal static void GenerateGridConfig(GridDefaults defaultSettings)
        {
            try
            {
                MVCGridDefinitionTable.Add("ApprovalSearch", new MVCGridBuilder<VisitorSearchResultViewModel>(defaultSettings)
                //.WithAuthorizationType(AuthorizationType.Authorized)
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddRenderingEngine("customBootstrap", typeof(CustomBootstrapRenderingEngine))
                .WithDefaultRenderingEngineName("customBootstrap")
                .WithSorting(true, "Visitors")
                .WithPaging(true, 10)
                .WithFiltering(true)
                .WithClientSideLoadingMessageFunctionName("searchShowLoading")
                .WithClientSideLoadingCompleteFunctionName("searchHideLoading")
                .WithQueryOnPageLoad(true)
                .WithPreloadData(true)
                .AddColumns(column =>
                {
                    column.Add("Actions")
                            .WithHeaderText(string.Empty)
                            .WithValueExpression((i, c) => c.UrlHelper.Action("View", "Visitor", new { id = i.VisitorId }))
                            .WithValueTemplate("<a href=\"/Approval/View/{Model.VisitorId}\"><span class=\"glyphicon glyphicon-search space\" data-blockui=\"true\" /></a>")
                            //.WithValueTemplate("<a href=\"/Approval/View/{Model.VisitorId}\"><span class=\"glyphicon glyphicon-search space\" data-blockui=\"true\" /></a>" +
                            //"<a href=\"/Approval/Edit/{Model.VisitorId}\"><span class=\"glyphicon glyphicon-edit space\" data-blockui=\"true\" /></a>")
                            .WithCellCssClassExpression(p => true ? "col-md-2 col-lg-1 text-center" : "")
                            .WithHtmlEncoding(false);
                    column.Add("Arrival").WithHeaderText("Arrival")
                            .WithValueExpression(v => v.Arrival.ToString("MMM-dd-yyyy HH:mm:ss"))
                            .WithSorting(false)
                            .WithFiltering(false);
                    column.Add("Requestor").WithHeaderText("Requestor")
                            .WithValueExpression(v => v.Requestor)
                            .WithSorting(false)
                            .WithFiltering(false);
                    column.Add("Company").WithHeaderText("Company")
                            .WithValueExpression(v => v.Company)
                            .WithSorting(false)
                            .WithFiltering(true);
                    column.Add("Visitors").WithHeaderText("Visitors")
                            .WithValueExpression(v => v.Visitors)
                            .WithSorting(false)
                            .WithFiltering(true);
                    column.Add("Purpose").WithHeaderText("Purpose")
                            .WithValueExpression(v => v.Purpose.DisplayName())
                            .WithSorting(false)
                            .WithFiltering(false);
                    column.Add("Status").WithHeaderText("Status")
                            .WithValueExpression(v => v.Status.DisplayName())
                            .WithCellCssClassExpression(v => v.Status == StatusType.ForApproval ? "warning" : v.Status == StatusType.Approved ? "success" : v.Status == StatusType.Declined ? "danger" : v.Status == StatusType.ForCompletion ? "active" : v.Status == StatusType.Completed ? "active" : "")
                            .WithSorting(false)
                            .WithFiltering(false);
            })
                 .WithRetrieveDataMethod((context) =>
                 {
                     var options = context.QueryOptions;
                     var result = new QueryResult<VisitorSearchResultViewModel>();
                     int totalRecords = 0;
                     var visitorService = new VisitorService();
                     var offset = options.GetLimitOffset();

                 //var test = options.GetFilterString("ItemType");
                 var searchFilters = new VisitorSearchFilterDTO()
                     {
                     Company = String.IsNullOrEmpty(options.GetFilterString("Company")) ? options.GetFilterString("Company") : options.GetFilterString("Company").Trim(),
                     Visitors = String.IsNullOrEmpty(options.GetFilterString("Visitors")) ? options.GetFilterString("Visitors") : options.GetFilterString("Visitors").Trim(),
                     //    CustomerId = Convert.ToInt64(options.GetFilterString("Customer")),
                     //    SubCustomerId = (!String.IsNullOrEmpty(options.GetFilterString("SubCustomer")) && options.GetFilterString("SubCustomer") != "null") ? (long?)Convert.ToInt64(options.GetFilterString("SubCustomer")) : null,
                     //    ItemType = !String.IsNullOrEmpty(options.GetFilterString("ItemType")) ? (ItemType?)EnumsHelper.GetEnumEquivalent<ItemType>(options.GetFilterString("ItemType")) : (ItemType?)null,
                     //    CustomerReference = String.IsNullOrEmpty(options.GetFilterString("CustomerReference")) ? options.GetFilterString("CustomerReference") : options.GetFilterString("CustomerReference").Trim(),
                     //    ItemDescription = String.IsNullOrEmpty(options.GetFilterString("ItemDescription")) ? options.GetFilterString("ItemDescription") : options.GetFilterString("ItemDescription").Trim(),
                     //    ItemStatus = !String.IsNullOrEmpty(options.GetFilterString("ItemStatus")) ? (ItemStatus?)EnumsHelper.GetEnumEquivalent<ItemStatus>(options.GetFilterString("ItemStatus")) : null,
                     Offset = offset,
                         RowCountPerPage = options.GetLimitRowcount(),
                         ColumnToSort = options.GetSortColumnData<string>(),
                     //    SortAscending = options.SortDirection.Equals(SortDirection.Asc) ? true : false,
                     //    ForExporting = offset.HasValue ? false : true,
                     //    SpecialFilters = !String.IsNullOrEmpty(options.GetFilterString("SpecialFilters")) ? (ItemSpecialFilters?)EnumsHelper.GetEnumEquivalent<ItemSpecialFilters>(options.GetFilterString("SpecialFilters")) : (ItemSpecialFilters?)null
                 };

                     result.Items = Mapper.Map<List<VisitorSearchResultViewModel>>(visitorService.Search(searchFilters, out totalRecords));
                     result.TotalRecords = totalRecords;
                     return result;
                 }));

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
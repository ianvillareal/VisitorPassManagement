using MVCGrid.Interfaces;
using MVCGrid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Visitor.Main.GridConfig.Rendering
{
    public class CustomBootstrapRenderingEngine : IMVCGridRenderingEngine
    {
        private string DefaultTableCss;
        private string HtmlImageSortAsc;
        private string HtmlImageSortDsc;
        private string HtmlImageSort;

        public const string SettingNameTableClass = "TableClass";

        public CustomBootstrapRenderingEngine()
        {
            DefaultTableCss = "table table-striped table-bordered rilv-no-wrap-table";
        }

        public void PrepareResponse(HttpResponse response)
        {
        }

        public bool AllowsPaging
        {
            get { return true; }
        }

        public void Render(RenderingModel model, GridContext gridContext, TextWriter outputStream)
        {

            //HtmlImageSortAsc = String.Format("<img src='{0}/sortup.png' class='pull-right' />", model.HandlerPath);
            //HtmlImageSortDsc = String.Format("<img src='{0}/sortdown.png' class='pull-right' />", model.HandlerPath);
            //HtmlImageSort = String.Format("<img src='{0}/sort.png' class='pull-right' />", model.HandlerPath);

            HtmlImageSortAsc = String.Format("<img src='{0}/sortup.png' />", model.HandlerPath);
            HtmlImageSortDsc = String.Format("<img src='{0}/sortdown.png' />", model.HandlerPath);
            HtmlImageSort = String.Format("<img src='{0}/sort.png' />", model.HandlerPath);

            string tableCss = DefaultTableCss;

            StringBuilder sbHtml = new StringBuilder();
            sbHtml.AppendLine("<div class='add-horizontal-scroll add-bottom-margin'>");
            sbHtml.AppendFormat("<table id='{0}'", model.TableHtmlId);
            AppendCssAttribute(tableCss, sbHtml);
            sbHtml.Append(">");

            RenderHeader(model, sbHtml);

            if (model.Rows.Count > 0)
            {
                RenderBody(model, sbHtml);
            }
            else
            {
                sbHtml.Append("<tbody>");
                sbHtml.Append("<tr>");
                sbHtml.AppendFormat("<td colspan='{0}'>", model.Columns.Count());
                sbHtml.Append("No results found.");
                sbHtml.Append("</td>");
                sbHtml.Append("</tr>");
                sbHtml.Append("</tbody>");
            }
            sbHtml.AppendLine("</table>");
            sbHtml.AppendLine("</div>");
            RenderPaging(model, sbHtml);

            outputStream.Write(sbHtml.ToString());
            outputStream.Write(model.ClientDataTransferHtmlBlock);
        }

        private void AppendCssAttribute(string classString, StringBuilder sbHtml)
        {
            if (!String.IsNullOrWhiteSpace(classString))
            {
                sbHtml.Append(String.Format(" class='{0}'", classString));
            }
        }

        private void RenderBody(RenderingModel model, StringBuilder sbHtml)
        {
            sbHtml.AppendLine("<tbody>");

            foreach (var row in model.Rows)
            {
                sbHtml.Append("<tr");
                AppendCssAttribute(row.CalculatedCssClass, sbHtml);
                sbHtml.AppendLine(">");

                foreach (var col in model.Columns)
                {
                    var cell = row.Cells[col.Name];

                    sbHtml.Append("<td");
                    AppendCssAttribute(cell.CalculatedCssClass, sbHtml);
                    sbHtml.Append(">");
                    sbHtml.Append(cell.HtmlText);
                    sbHtml.Append("</td>");
                }
                sbHtml.AppendLine("  </tr>");
            }

            sbHtml.AppendLine("</tbody>");
        }

        private void RenderHeader(RenderingModel model, StringBuilder sbHtml)
        {
            sbHtml.AppendLine("<thead>");
            sbHtml.AppendLine("  <tr>");
            foreach (var col in model.Columns)
            {
                sbHtml.Append("<th");

                if (!String.IsNullOrWhiteSpace(col.Onclick))
                {
                    sbHtml.Append(" style='cursor: pointer;'");
                    sbHtml.AppendFormat(" onclick='{0}'", col.Onclick);
                }
                sbHtml.Append(">");

                sbHtml.Append("<div class='mvcgrid-tableheader'>");
                sbHtml.Append("<span class='mvcgrid-headertext'>");
                sbHtml.Append(col.HeaderText);
                sbHtml.Append("</span>");
                sbHtml.Append("<span class='mvcgrid-imageheader'>");
                if (col.SortIconDirection.HasValue)
                {
                    switch (col.SortIconDirection)
                    {
                        case SortDirection.Asc:
                            sbHtml.Append(" ");
                            sbHtml.Append(HtmlImageSortAsc);
                            break;
                        case SortDirection.Dsc:
                            sbHtml.Append(" ");
                            sbHtml.Append(HtmlImageSortDsc);
                            break;
                        case SortDirection.Unspecified:
                            sbHtml.Append(" ");
                            sbHtml.Append(HtmlImageSort);
                            break;
                    }
                }
                sbHtml.Append("</span>");
                sbHtml.Append("</div>");
                sbHtml.AppendLine("</th>");
            }
            sbHtml.AppendLine("  </tr>");
            sbHtml.AppendLine("</thead>");
        }

        private void RenderPaging(RenderingModel model, StringBuilder sbHtml)
        {
            if (model.PagingModel == null)
            {
                return;
            }

            PagingModel pagingModel = model.PagingModel;
            sbHtml.Append("<div class=\"row\">");
            sbHtml.Append("<div class=\"row\">");
            sbHtml.Append("<div class=\"col-xs-6\">");

            if (pagingModel.TotalRecords != 0)
            {
                sbHtml.AppendFormat("Showing {0} to {1} of {2} entries",
                    pagingModel.FirstRecord, pagingModel.LastRecord, pagingModel.TotalRecords
                    );
            }
            sbHtml.Append("</div>");


            sbHtml.Append("<div class=\"col-xs-6\">");
            int pageToStart;
            int pageToEnd;
            pagingModel.CalculatePageStartAndEnd(5, out pageToStart, out pageToEnd);

            if (pagingModel.TotalRecords > 0)
            {
                sbHtml.Append("<ul class='pagination pull-right' style='margin-top: 0;'>");

                sbHtml.Append("<li");
                if (pagingModel.CurrentPage == 1 || pagingModel.TotalRecords == 0)
                {
                    sbHtml.Append(" class='disabled'");
                }
                sbHtml.Append(">");
                sbHtml.Append("<a href='#' aria-label='First' ");
                if (pagingModel.PageLinks.Count > 0 && pagingModel.CurrentPage != 1)
                {
                    sbHtml.AppendFormat("onclick='{0}'", pagingModel.PageLinks[1]);
                }
                else
                {
                    sbHtml.AppendFormat("onclick='{0}'", "return false;");
                }
                sbHtml.Append(">");
                sbHtml.AppendFormat("<span aria-hidden='true'>&laquo; {0}</span></a></li>", "First");

                sbHtml.Append("<li");
                if (pageToStart == pagingModel.CurrentPage || pagingModel.TotalRecords == 0)
                {
                    sbHtml.Append(" class='disabled'");
                }
                sbHtml.Append(">");

                sbHtml.Append("<a href='#' aria-label='Previous' ");
                if (pageToStart < pagingModel.CurrentPage)
                {
                    sbHtml.AppendFormat("onclick='{0}'", pagingModel.PageLinks[pagingModel.CurrentPage - 1]);
                }
                else
                {
                    sbHtml.AppendFormat("onclick='{0}'", "return false;");
                }
                sbHtml.Append(">");
                sbHtml.AppendFormat("<span aria-hidden='true'>&lsaquo; {0}</span></a></li>", "Previous");

                for (int i = pageToStart; i <= pageToEnd; i++)
                {
                    sbHtml.Append("<li");
                    if (i == pagingModel.CurrentPage)
                    {
                        sbHtml.Append(" class='active'");
                    }
                    sbHtml.Append(">");
                    sbHtml.AppendFormat("<a href='#' onclick='{0}'>{1}</a></li>", pagingModel.PageLinks[i], i);
                }


                sbHtml.Append("<li");
                if (pageToEnd == pagingModel.CurrentPage || pagingModel.TotalRecords == 0)
                {
                    sbHtml.Append(" class='disabled'");
                }
                sbHtml.Append(">");

                sbHtml.Append("<a href='#' aria-label='Next' ");
                if (pageToEnd > pagingModel.CurrentPage)
                {
                    sbHtml.AppendFormat("onclick='{0}'", pagingModel.PageLinks[pagingModel.CurrentPage + 1]);
                }
                else
                {
                    sbHtml.AppendFormat("onclick='{0}'", "return false;");
                }
                sbHtml.Append(">");
                sbHtml.AppendFormat("<span aria-hidden='true'>{0} &rsaquo;</span></a></li>", "Next");

                sbHtml.Append("<li");
                if (pagingModel.CurrentPage == pagingModel.NumberOfPages || pagingModel.TotalRecords == 0)
                {
                    sbHtml.Append(" class='disabled'");
                }
                sbHtml.Append(">");
                sbHtml.Append("<a href='#' aria-label='Last' ");
                if (pagingModel.PageLinks.Count > 0 && pagingModel.CurrentPage != pagingModel.NumberOfPages)
                {
                    sbHtml.AppendFormat("onclick='{0}'", pagingModel.PageLinks[pagingModel.NumberOfPages]);
                }
                else
                {
                    sbHtml.AppendFormat("onclick='{0}'", "return false;");
                }
                sbHtml.Append(">");
                sbHtml.AppendFormat("<span aria-hidden='true'>{0} &raquo;</span></a></li>", "Last");

                sbHtml.Append("</ul>");
            }
            sbHtml.Append("</div>");
            sbHtml.Append("</div>");
        }


        public void RenderContainer(ContainerRenderingModel model, TextWriter outputStream)
        {
            outputStream.Write(model.InnerHtmlBlock);
        }

    }
}
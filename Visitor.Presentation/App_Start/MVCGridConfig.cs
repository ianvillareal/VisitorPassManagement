//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Visitor.Presentation.MVCGridConfig), "RegisterGrids")]

namespace Visitor.Presentation
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using Visitor.Presentation.GridConfig;

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {
            var gridDefaults = new GridDefaults
            {
                PreloadData = true,
                QueryOnPageLoad = true,
                Sorting = true,
                NoResultsMessage = "No results found."
            };

            VisitorSearchConfig.GenerateGridConfig(gridDefaults);
            ApprovalSearchConfig.GenerateGridConfig(gridDefaults);
            SecuritySearchConfig.GenerateGridConfig(gridDefaults);
        }
    }
}
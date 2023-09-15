//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Visitor.Main.MVCGridConfig), "RegisterGrids")]

namespace Visitor.Main
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using Visitor.Main.GridConfig;

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
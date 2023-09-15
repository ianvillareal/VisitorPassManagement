using System.Web;
using System.Web.Optimization;

namespace Visitor.Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //The following are vendor scripts.
            bundles.Add(new ScriptBundle("~/bundles/vendors-js").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery-ui-{version}.js",
            "~/Scripts/jquery.validate.inline.js",
            "~/Scripts/jquery.validate*",
           // "~/Scripts/bootstrap.min.js",
           "~/Scripts/bootstrap.js",
            "~/Scripts/bootstrap-notify.min.js",
            "~/Scripts/jquery.blockUI.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //The following are vendor styles.
            bundles.Add(new StyleBundle("~/Content/vendor-css").Include(
                        //"~/Content/bootstrap.min.css",
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/validationEngine.jquery.css"));

            // Datatable Dependencies
            bundles.Add(new ScriptBundle("~/bundles/datatables-js").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new StyleBundle("~/Content/datatables-css").Include(
                        "~/Content/DataTables/css/jquery.dataTables.css",
                        "~/Content/DataTables/css/jquery.dataTables_themeroller.css"));

            // Bootstrap DatePicker and Timepicker Dependencies
            bundles.Add(new ScriptBundle("~/bundles/datetimepicker-js").Include(
               "~/Scripts/moment-with-locales.min.js",
               "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/datepicker-css").Include(
                "~/Content/bootstrap-datetimepicker.min.css"));

            // Custom Javascripts
            bundles.Add(new ScriptBundle("~/bundles/main-js").Include(
                "~/Scripts/app.js",
                "~/Scripts/inline-validator.js"));

            // Custom Styles
            bundles.Add(new StyleBundle("~/Content/main-css").Include(
                        "~/Content/override-default.css",
                        "~/Content/style.css"));

            //JQuery-Confirm Dependencies
            bundles.Add(new ScriptBundle("~/bundles/jquery-confirm-js").Include(
                "~/Scripts/jquery-confirm.min.js"));

            bundles.Add(new StyleBundle("~/Content/jquery-confirm-css").Include(
                        "~/Content/jquery-confirm.min.css"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            // Customer script
            bundles.Add(new ScriptBundle("~/bundles/visitor-js").Include(
                "~/Scripts/visitor.js"));

            // Customer script
            bundles.Add(new ScriptBundle("~/bundles/customer-js").Include(
                "~/Scripts/customer.js"));
        }
    }
}

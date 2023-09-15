using System.Web;
using System.Web.Optimization;

namespace Visitor.Main
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string components = "~/Scripts/components/";
            string plugins = "~/Scripts/plugins/";

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include(components + "jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib")
                .Include(components + "jquery-ui/jquery-ui.js")
                .Include(components + "bootstrap/dist/js/bootstrap.js")
                .Include(components + "rilv/app.js")
                .Include(components + "raphael/raphael.min.js")
                .Include(components + "morris.js/morris.min.js")
                .Include(components + "chart.js/Chart.min.js")
                .Include(components + "Flot/jquery.flot.js")
                .Include(components + "Flot/jquery.flot.resize.js")
                .Include(components + "Flot/jquery.flot.pie.js")
                .Include(components + "Flot/jquery.flot.categories.js")
                .Include(components + "jquery-sparkline/dist/jquery.sparkline.min.js")
                .Include(plugins + "jvectormap/jquery-jvectormap-1.2.2.min.js")
                .Include(plugins + "jvectormap/jquery-jvectormap-world-mill-en.js")
                .Include(components + "jquery-knob/dist/jquery.knob.min.js")
                .Include(components + "jquery-blockUI/jquery.blockUI.js")
                .Include(components + "moment/moment.js")
                .Include(components + "PACE/pace.min.js")
                .Include(components + "ckeditor/ckeditor.js")
                .Include(components + "datatables.net/js/jquery.dataTables.min.js")
                .Include(components + "datatables.net-bs/js/dataTables.bootstrap.min.js")
                .Include(components + "bootstrap-daterangepicker/daterangepicker.js")
                .Include(components + "bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js")
                .Include(components + "bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js")
                .Include(plugins + "bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js")
                .Include(components + "jquery-slimscroll/jquery.slimscroll.min.js")
                .Include(components + "fastclick/lib/fastclick.js")
                .Include("~/Scripts/js/adminlte.js")
                .Include("~/Scripts/js/demo.js")
                .Include(components + "jquery-confirm/js/jquery-confirm.min.js")
                .Include(plugins + "bootstrap-slider/bootstrap-slider.js")
                .Include(components + "select2/dist/js/select2.full.min.js")
                .Include(plugins + "input-mask/jquery.inputmask.js")
                .Include(plugins + "input-mask/jquery.inputmask.date.extensions.js")
                .Include(plugins + "input-mask/jquery.inputmask.extensions.js")
                .Include(plugins + "timepicker/bootstrap-timepicker.min.js")
                .Include(plugins + "iCheck/icheck.min.js")
                .Include(components + "fullcalendar/dist/fullcalendar.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include(components + "bootstrap/dist/css/bootstrap.min.css")
                .Include(components + "rilv/style.css")
                .Include(components + "font-awesome/css/font-awesome.min.css")
                .Include(components + "Ionicons/css/ionicons.min.css")
                .Include(components + "datatables.net-bs/css/dataTables.bootstrap.min.css")
                .Include("~/Content/css/AdminLTE.css")
                .Include("~/Content/css/skins/skin-green.css")
                //.Include("~/Content/css/skins/_all-skins.min.css")
                .Include(components + "jquery-confirm/css/jquery-confirm.min.css")
                .Include(components + "morris.js/morris.css")
                .Include(components + "jvectormap/jquery-jvectormap.css")
                .Include(components + "bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css")
                .Include(components + "bootstrap-daterangepicker/daterangepicker.css")
                .Include(plugins + "bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css")
                .Include(plugins + "bootstrap-slider/slider.css")
                .Include(components + "select2/dist/css/select2.min.css")
                .Include(components + "bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css")
                .Include(plugins + "timepicker/bootstrap-timepicker.min.css")
                .Include(plugins + "iCheck/all.css")
                .Include(plugins + "pace/pace.min.css")
                .Include(components + "fullcalendar/dist/fullcalendar.min.css"));

            // Visitor script
            bundles.Add(new ScriptBundle("~/bundles/visitor-js")
                .Include(components + "rilv/visitor.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}

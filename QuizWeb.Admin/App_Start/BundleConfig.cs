using System.Web;
using System.Web.Optimization;

namespace QuizWeb.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.1.min.js",
                        "~/Scripts/jquery-easy.js"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr.custom.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Content/plugins/jquery-ui/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/plugins/boostrapv3/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/plugins-jquery").Include(
                        "~/Content/plugins/jquery-unveil/jquery.unveil.min.js",
                        "~/Content/plugins/jquery-bez/jquery.bez.min.js",
                        "~/Content/plugins/jquery-ios-list/jquery.ioslist.min.js",
                        "~/Content/plugins/jquery-actual/jquery.actual.min.js",
                        "~/Content/plugins/jquery-scrollbar/jquery.scrollbar.min.js",
                        "~/Content/plugins/jquery-metrojs/MetroJs.min.js",
                        "~/Content/plugins/jquery-sparkline/jquery.sparkline.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select2").Include(
                        "~/Content/plugins/bootstrap-select2/select2.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/classie").Include(
                        "~/Content/plugins/classie/classie.js"));
            bundles.Add(new ScriptBundle("~/bundles/switchery").Include(
                        "~/Content/plugins/switchery/js/switchery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/nvd3").Include(
                        "~/Content/plugins/nvd3/lib/d3.v3.js",
                        "~/Content/plugins/nvd3/nv.d3.min.js",
                        "~/Content/plugins/nvd3/src/utils.js",
                        "~/Content/plugins/nvd3/src/tooltip.js",
                        "~/Content/plugins/nvd3/src/interactiveLayer.js",
                        "~/Content/plugins/nvd3/src/models/axis.js",
                        "~/Content/plugins/nvd3/src/models/line.js",
                        "~/Content/plugins/nvd3/src/models/lineWithFocusChart.js"));
            bundles.Add(new ScriptBundle("~/bundles/mapplic").Include(
                        "~/Content/plugins/mapplic/js/hammer.js",
                        "~/Content/plugins/mapplic/js/jquery.mousewheel.js",
                        "~/Content/plugins/mapplic/js/mapplic.js"));
            bundles.Add(new ScriptBundle("~/bundles/rickshaw").Include(
                        "~/Content/plugins/rickshaw/rickshaw.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/skycons").Include(
                        "~/Content/plugins/skycons/skycons.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                        "~/Content/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"));
            bundles.Add(new ScriptBundle("~/bundles/pages").Include(
                        "~/Scripts/pages.min.js",
                        "~/Scripts/dashboard.js",
                        "~/Scripts/scripts.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            // Plugins Script
            bundles.Add(new ScriptBundle("~/bundles/plugins/pace").Include(
                      "~/Content/plugins/pace/pace.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            // Plugins css
            bundles.Add(new StyleBundle("~/Content/plugins").Include(
                      "~/Content/plugins/pace/pace-theme-flash.css",
                      "~/Content/plugins/boostrapv3/css/bootstrap.min.css",
                      "~/Content/plugins/font-awesome/css/font-awesome.min.css",
                      "~/Content/plugins/jquery-scrollbar/jquery.scrollbar.css",
                      "~/Content/plugins/bootstrap-select2/select2.css",
                      "~/Content/plugins/switchery/css/switchery.min.css",
                      "~/Content/plugins/nvd3/nv.d3.min.css",
                      "~/Content/plugins/plugins/mapplic/css/mapplic.css",
                      "~/Content/plugins/rickshaw/rickshaw.min.css",
                      "~/Content/plugins/bootstrap-datepicker/css/datepicker3.css",
                      "~/Content/plugins/jquery-metrojs/MetroJs.css"));
            // Pages css
            bundles.Add(new StyleBundle("~/Content/pages").Include(
                      "~/Content/pages-icons.css",
                      "~/Content/themes/unlax.css",
                      "~/Content/style.css"));
        }
    }
}

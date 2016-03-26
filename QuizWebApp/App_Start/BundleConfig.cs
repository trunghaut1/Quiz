using System.Web;
using System.Web.Optimization;

namespace QuizWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",//jquery
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery-migrate.min.js"));//ajax
            bundles.Add(new ScriptBundle("~/bundles/sharrre").Include(
                "~/Scripts/jquery.sharrre.min.js"));//share social network

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/fullby").Include(
                      "~/Scripts/isotope.js",
                      "~/Scripts/fullby-grid.js",
                      "~/Scripts/fullby-parallax.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/fullby-script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/font-awesome.min.css"));
        }
    }
}

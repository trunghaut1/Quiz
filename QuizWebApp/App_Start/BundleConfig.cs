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
                "~/Scripts/plugins/jquery.js"));
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/Scripts/plugins").Include(
                        "~/Scripts/plugins/jquery.migrate.js",
                        "~/Scripts/bootstrap/bootstrap.js",
                        "~/Scripts/plugins/jquery.unobtrusive-ajax.js",
                      "~/Scripts/plugins/jquery.back-to-top.js",
                      "~/Scripts/plugins/jquery.smooth-scroll.js",
                      "~/Scripts/plugins/jquery.cubeportfolio.js",
                      "~/Scripts/plugins/jquery.animsition.js",
                      "~/Scripts/plugins/jquery.wow.js",
                      "~/Scripts/plugins/jquery.html5.video.vide.js",
                      "~/Scripts/plugins/jquery.masonry.pkgd.js",
                      "~/Scripts/plugins/jquery.imagesloaded.pkgd.js"));
            bundles.Add(new ScriptBundle("~/Scripts/rev-slider").Include(
                      "~/Scripts/rev-slider/jquery.themepunch.tools.js",
                      "~/Scripts/rev-slider/jquery.themepunch.revolution.js").IncludeDirectory(
                      "~/Scripts/rev-slider/extensions", "revolution*", false));
            bundles.Add(new ScriptBundle("~/Scripts/counter").Include(
                      "~/Scripts/counter/*.js"));
            bundles.Add(new ScriptBundle("~/Scripts/scrollbar").Include(
                      "~/Scripts/scrollbar/*.js"));
            bundles.Add(new ScriptBundle("~/Scripts/cubeportfolio").Include(
                      "~/Scripts/cubeportfolio/*.js"));
            bundles.Add(new ScriptBundle("~/Scripts/magnific-popup").Include(
                      "~/Scripts/magnific-popup/*.js"));
            bundles.Add(new ScriptBundle("~/Scripts/validation").Include(
                      "~/Scripts/validation/*.js"));
            bundles.Add(new ScriptBundle("~/Scripts/app").Include(
                      "~/Scripts/app.js"));
            bundles.Add(new ScriptBundle("~/Scripts/components").Include(
                      "~/Scripts/components/header-sticky.js",
                      "~/Scripts/components/animsition.js",
                      "~/Scripts/components/scrollbar.js",
                      "~/Scripts/components/form-modal.js",
                      "~/Scripts/components/wow.js",
                      "~/Scripts/components/magnific-popup.js"));
            bundles.Add(new ScriptBundle("~/Scripts/components_index").Include(
                      "~/Scripts/components/rev-slider.js",
                      "~/Scripts/components/counters.js",
                      "~/Scripts/components/masonry.js",
                      "~/Scripts/components/comment-form.js"));
            bundles.Add(new ScriptBundle("~/Scripts/portfolio").Include(
                      "~/Scripts/portfolio/portfolio-3-col-grid.js"));
            bundles.Add(new ScriptBundle("~/Scripts/sharrre").Include(
                "~/Scripts/sharrre/jquery.sharrre.js"));
            bundles.Add(new ScriptBundle("~/Content/ck").Include(
                "~/Content/ckeditor/ckeditor.js",
                "~/Content/ckfinder/ckfinder.js"));
            bundles.Add(new ScriptBundle("~/Scripts/areyousure").Include(
                      "~/Scripts/areyousure/areyousure.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/font-awesome").Include(
                      "~/Content/font-awesome/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/et-line").Include(
                      "~/Content/et-line/et-line.css"));
            bundles.Add(new StyleBundle("~/Content/scrollbar").Include(
                      "~/Content/scrollbar/jquery.mCustomScrollbar.css"));
            bundles.Add(new StyleBundle("~/Content/rev-slider").Include(
                      "~/Content/rev-slider/settings.css",
                      "~/Content/rev-slider/layers.css",
                      "~/Content/rev-slider/navigation.css",
                      "~/Content/rev-slider/fonts/pe-icon-7-stroke.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/animate.css",
                      "~/Content/css/global.css",
                      "~/Content/css/theme/dark.css",
                      "~/Content/css/theme/base.css"));
            bundles.Add(new StyleBundle("~/Content/magnific-popup").Include(
                      "~/Content/magnific-popup/magnific-popup.css"));
            bundles.Add(new StyleBundle("~/Content/cubeportfolio").Include(
                      "~/Content/cubeportfolio/cubeportfolio.css"));
        }
    }
}

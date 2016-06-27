using System.Web;
using System.Web.Optimization;

namespace QuizWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Script Bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/plugins/jquery.js"));

            bundles.Add(new ScriptBundle("~/Scripts/CoreScript").Include(
                "~/Scripts/plugins/jquery.migrate.js",
                "~/Content/plugins/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Scripts/PagePluginScript").Include(
                "~/Scripts/plugins/jquery.back-to-top.js",
                "~/Scripts/plugins/jquery.smooth-scroll.js",
                "~/Scripts/plugins/jquery.animsition.min.js",
                "~/Content/plugins/scrollbar/jquery.mCustomScrollbar.concat.js",
                "~/Scripts/plugins/jquery.wow.js",
                "~/Content/plugins/magnific-popup/jquery.magnific-popup.min.js",
                "~/Scripts/plugins/jquery.footer-reveal.js"));

            bundles.Add(new ScriptBundle("~/Scripts/PageScript").Include(
                "~/Scripts/app.min.js",
                "~/Scripts/components/header-sticky.js",
                "~/Scripts/components/auto-hiding-navbar.js",
                "~/Scripts/components/animsition.js",
                "~/Scripts/components/scrollbar.js",
                "~/Scripts/components/form-modal.js",
                "~/Scripts/components/wow.js",
                "~/Scripts/components/magnific-popup.js",
                "~/Scripts/components/footer-reveal.js"));

            bundles.Add(new ScriptBundle("~/Scripts/rev-slider").Include(
                      "~/Scripts/rev-slider/jquery.themepunch.tools.js",
                      "~/Scripts/rev-slider/jquery.themepunch.revolution.js").IncludeDirectory(
                      "~/Scripts/rev-slider/extensions", "revolution*", false));

            bundles.Add(new ScriptBundle("~/Scripts/validation").Include(
                      "~/Scripts/validation/*.js"));

            bundles.Add(new ScriptBundle("~/Scripts/components_index").Include(
                      "~/Scripts/components/comment-form.js"));

            bundles.Add(new ScriptBundle("~/Scripts/masonry").Include(
                      "~/Scripts/plugins/jquery.masonry.pkgd.js",
                      "~/Scripts/plugins/jquery.imagesloaded.pkgd.js",
                      "~/Scripts/components/masonry.js"));

            bundles.Add(new ScriptBundle("~/Content/ck").Include(
                "~/Content/ckeditor/ckeditor.js",
                "~/Content/ckfinder/ckfinder.js"));

            bundles.Add(new ScriptBundle("~/Scripts/areyousure").Include(
                      "~/Scripts/areyousure/areyousure.js"));

            // Style Bundle
            bundles.Add(new StyleBundle("~/Content/GlobalStyle").Include(
                      "~/Content/plugins/bootstrap/bootstrap.min.css",
                      "~/Content/plugins/font-awesome/font-awesome.min.css",
                      "~/Content/plugins/et-line/et-line.css"));

            bundles.Add(new StyleBundle("~/Content/ThemePluginStyle").Include(
                      "~/Content/plugins/scrollbar/jquery.mCustomScrollbar.css",
                      "~/Content/css/animate.css",
                      "~/Content/plugins/magnific-popup/magnific-popup.css"));

            bundles.Add(new StyleBundle("~/Content/ThemeStyle").Include(
                      "~/Content/css/global.min.css",
                      "~/Content/css/theme/dark.css",
                      "~/Content/css/theme/base.css"));

            bundles.Add(new StyleBundle("~/Content/CustomStyle").Include(
                      "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/rev-slider").Include(
                      "~/Content/plugins/rev-slider/settings.css",
                      "~/Content/plugins/rev-slider/layers.css",
                      "~/Content/plugins/rev-slider/navigation.css"));
        }
    }
}

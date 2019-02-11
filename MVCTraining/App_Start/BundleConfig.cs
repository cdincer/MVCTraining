using System.Web;
using System.Web.Optimization;

namespace MVCTraining
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/thirdparty/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/thirdparty/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/thirdparty/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/thirdparty/bootstrap.js",
                      "~/Scripts/thirdparty/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/AdminMenu").Include(
                        "~/Scripts/AdminMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/UI").Include(
                      "~/Scripts/Carret.js",
                        "~/Scripts/thirdparty/video.dev.js",
                        "~/Scripts/thirdparty/video.js"));

            bundles.Add(new StyleBundle("~/Content/membership").Include(
                      "~/Content/navbar.css",
                       "~/Content/ProductContent.css",
                      "~/Content/thumbnails.css",
                      "~/Content/Carret.css"));
        }
    }
}

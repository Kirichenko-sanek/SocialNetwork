using System.Web;
using System.Web.Optimization;

namespace SocialNetwork.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-migrate-1.2.1.min.js",
                        "~/Scripts/jquery.flexslider.js",
                         "~/Scripts/scrollspy.js",
                        "~/Scripts/jquery.reveal.js",
                        "~/Scripts/smoothscrolling.js"
                        ));

            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/base.css",        
                        "~/Content/fonts.css",
                        "~/Content/layout.css",        
                        "~/Content/font-awesome/css/font-awesome.css",
                        "~/Content/font-awesome/css/font-awesome.min.css",
                        "~/Content/font-awesome/css/font-awesome-ie7.css",
                        "~/Content/font-awesome/css/font-awesome-ie7.min.css"));

            
        }
    }
}

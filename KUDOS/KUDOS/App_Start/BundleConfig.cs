﻿using System.Web;
using System.Web.Optimization;

namespace KUDOS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {   
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include( /* Add angular scripts and angular ui*/
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                             "~/Scripts/AngularJs/angular.js",
                             "~/Scripts/AngularJs/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").Include(
                              "~/Scripts/AngularJs/angular-touch.js",
                              "~/Scripts/AngularJs/angular-animate.js",
                              "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/site.css"));




        }
    }
}

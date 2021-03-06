﻿using System.Web;
using System.Web.Optimization;

namespace MatrixApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Angular/angular.min.js",
                      "~/Matrix/app.js",
//                      "~/Matrix/authentication.js",
                      "~/Matrix/routing.js",
                      "~/Matrix/routingConfig.js",
                      "~/Matrix/controllers.js",
                      "~/Matrix/directives.js",
                      "~/Matrix/factories.js",
                      "~/Matrix/filters.js",
                      "~/Matrix/services.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.css",
                      "~/Content/site.css"));
        }
    }
}

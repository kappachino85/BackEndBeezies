﻿using System.Web;
using System.Web.Optimization;

namespace BackEndBeezies.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //  v2.0 / Bower versions
            //  ------------------------------------------------------------
            bundles.Add(new StyleBundle("~/bower/bootstrap/css").Include(
                      "~/Scripts/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Scripts/bower_components/ngAnimate/css/ng-animation.css",
                      "~/Scripts/bower_components/angular-toastr/dist/angular-toastr.css",
                      "~/Content/angular-material.css"));

            bundles.Add(new StyleBundle("~/site/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bower/bootstrap/js").Include(
                      "~/Scripts/bower_components/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bower/jquery").Include(
                      "~/Scripts/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bower/angular").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-route.js",
                      "~/Scripts/angular-aria.js",
                      "~/Scripts/angular-messages.js",
                      "~/Scripts/angular-material.js",
                      "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap.js",
                      "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-tpls.js",
                      "~/Scripts/bower_components/angular-toastr/dist/angular-toastr.js",
                      "~/Scripts/bower_components/angular-toastr/dist/angular-toastr.tpls.js"));

            //Sabio: this disables the optimizations in Bundles. 
            //this allows all files  to be rendered separately while we develop

            //add angular app
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/bebApp.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}

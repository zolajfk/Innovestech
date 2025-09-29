using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TSPadel_Umbraco.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.7.1.js"
                ,"~/Scripts/bootstrap.js"
                ,"~/Scripts/jquery.validate*"
                ,"~/Scripts/additional-methods.js"
                ));

            //CSS
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/font-awesome.min.css",
                "~/css/sitestyles.css"
                ));
        }

    }
}
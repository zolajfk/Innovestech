using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using TSPadel_Umbraco.Models;
using System.Web.Security;
using Umbraco.Core.Services;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.PublishedCache;

using Umbraco.Web.Security;
using System.Globalization;
using TSPadel_Umbraco.Extensions;
using System.Data;

namespace TSPadel_Umbraco.Controllers
{
    public class ErrorsSurfaceController : SurfaceController
    {

        [HttpGet]
        public ActionResult Http404(string source)
        {
            Response.StatusCode = 404;
            return View();
        }

        [HttpGet]
        public ActionResult Http500(string source)
        {
            Response.StatusCode = 500;
            return View();
        }

        public ActionResult LogError(String functionName, String jqX, String textStatus, String errorThrown)
        {
            string ErrorMessage = "Error Description: " + functionName + " " + textStatus + "<br/><br/>" + errorThrown + "<br/><br/>" + jqX;

            TSPadel_Umbraco.Controller.ApplicationFormSurfaceController.SendApplicationError("john.knott@zolasystems.co.uk", "", "APPLICATION ERROR", ErrorMessage);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
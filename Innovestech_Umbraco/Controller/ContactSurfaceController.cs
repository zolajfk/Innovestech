using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using TSPadel_Umbraco.Models;
using System.Diagnostics;
using TSPadel_Umbraco.Extensions;
using System.Data;

namespace TSPadel_Umbraco.Controller
{
    public class ContactSurfaceController : SurfaceController
    {
        // GET: ContactSurface
        [HttpPost]
        public ActionResult ContactBlock(ContactFormModel contactFormModel)
        {
            DataTable dtContactRequest = DatabaseFunctions.saveContactRequest(contactFormModel);
            
            return Redirect("/contact");
        }
    }
}
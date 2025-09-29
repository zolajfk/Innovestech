using TSPadel_Umbraco.Extensions;
using TSPadel_Umbraco.Models;
using System.IO;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace TSPadel_Umbraco.Controller
{
    public class MonitoringFormSurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult MonitoringFormBlock(MonitoringFormModel monitoringFormModel)
        {
            monitoringFormModel = DatabaseFunctions.saveMonitoringForm(monitoringFormModel);

            string subPath = "~/FileUploads"; // Your code goes here

            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

            subPath = subPath + "\\" + monitoringFormModel.MonitoringCode;

            exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

            if (monitoringFormModel.Conditional_Images_File != null && monitoringFormModel.Conditional_Images_File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(monitoringFormModel.Conditional_Images_File.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath(subPath), fileName);
                monitoringFormModel.Conditional_Images_File.SaveAs(path);
            }

            return Json(new { success = true, MonitoringCode = monitoringFormModel.MonitoringCode }, JsonRequestBehavior.AllowGet);
        }
    }
}
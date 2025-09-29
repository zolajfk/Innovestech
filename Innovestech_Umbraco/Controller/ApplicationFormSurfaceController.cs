using TSPadel_Umbraco.Extensions;
using TSPadel_Umbraco.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace TSPadel_Umbraco.Controller
{
    public class ApplicationFormSurfaceController : SurfaceController
    {

        private const string SmtpServer = "smtp.office365.com";
        private const string SmtpUser = "receipts@bistrolive.com";
        private const string SmtpPassword = "3};5pIe]S]WdRpzg69Ow";
        private const int SmtpPort = 587;

        [System.Web.Http.HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase UploadedFile, String ApplicationCode, String FileType)
        {
            ApplicationFormModel applicationFormModel = new ApplicationFormModel();

            applicationFormModel.ApplicationCode = ApplicationCode;

            string subPath = "~/FileUploads"; // Your code goes here

            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

            subPath = subPath + "\\" + applicationFormModel.ApplicationCode;

            exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

            var fileName = Path.GetFileName(UploadedFile.FileName);
            // store the file inside ~/App_Data/uploads folder
            var path = Path.Combine(Server.MapPath(subPath), fileName);

            UploadedFile.SaveAs(path);

            /****
             Need to look at file type and set the correct property of the applicationformmodel 
             **/

            if (FileType == "Cost_Breakdown_Accounts_Label")
            {
                applicationFormModel.Cost_Breakdown_Accounts = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);
            if (FileType == "Cost_Breakdown_Statement_Label")
            {
                applicationFormModel.Cost_Breakdown_Statement = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);
            if (FileType == "Full_Cost_Breakdown_Statement_Label")
            {
                applicationFormModel.Full_Cost_Breakdown_Statement = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);
            if (FileType == "Key_Policy_1_Label")
            {
                applicationFormModel.Key_Policy_1 = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);
            if (FileType == "Key_Policy_2_Label")
            {
                applicationFormModel.Key_Policy_2 = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);
            if (FileType == "Key_Policy_3_Label")
            {
                applicationFormModel.Key_Policy_3 = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);
            if (FileType == "General_Document_Label")
            {
                applicationFormModel.General_Document = UploadedFile.FileName;
            }
            DatabaseFunctions.saveUploadedFile(applicationFormModel);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpPost]
        public ActionResult ApplicationFormBlock(ApplicationFormModel applicationFormModel)
        {
            try
            {
                Boolean newApplication = (applicationFormModel.ApplicationCode == null || applicationFormModel.ApplicationCode == "" ? true : false);

                applicationFormModel.Funding_Type = (applicationFormModel.Funding_Type == "" ? "0" : applicationFormModel.Funding_Type);

                applicationFormModel = DatabaseFunctions.saveApplicationForm(applicationFormModel);

                string subPath = "~/FileUploads"; // Your code goes here

                bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

                subPath = subPath + "\\" + applicationFormModel.ApplicationCode;

                exists = System.IO.Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    System.IO.Directory.CreateDirectory(Server.MapPath(subPath));

                if (applicationFormModel.Cost_Breakdown_Accounts_File != null && applicationFormModel.Cost_Breakdown_Accounts_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.Cost_Breakdown_Accounts_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.Cost_Breakdown_Accounts_File.SaveAs(path);
                    applicationFormModel.Cost_Breakdown_Accounts = fileName;
                }

                if (applicationFormModel.Cost_Breakdown_Statement_File != null && applicationFormModel.Cost_Breakdown_Statement_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.Cost_Breakdown_Statement_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.Cost_Breakdown_Statement_File.SaveAs(path);
                    applicationFormModel.Cost_Breakdown_Statement = fileName;
                }

                if (applicationFormModel.Full_Cost_Breakdown_Statement_File != null && applicationFormModel.Full_Cost_Breakdown_Statement_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.Full_Cost_Breakdown_Statement_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.Full_Cost_Breakdown_Statement_File.SaveAs(path);
                    applicationFormModel.Full_Cost_Breakdown_Statement = fileName;
                }

                if (applicationFormModel.Key_Policy_1_File != null && applicationFormModel.Key_Policy_1_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.Key_Policy_1_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.Key_Policy_1_File.SaveAs(path);
                    applicationFormModel.Key_Policy_1 = fileName;
                }

                if (applicationFormModel.Key_Policy_2_File != null && applicationFormModel.Key_Policy_2_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.Key_Policy_2_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.Key_Policy_2_File.SaveAs(path);
                    applicationFormModel.Key_Policy_2 = fileName;
                }

                if (applicationFormModel.Key_Policy_3_File != null && applicationFormModel.Key_Policy_3_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.Key_Policy_3_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.Key_Policy_3_File.SaveAs(path);
                    applicationFormModel.Key_Policy_3 = fileName;
                }

                if (applicationFormModel.General_Document_File != null && applicationFormModel.General_Document_File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(applicationFormModel.General_Document_File.FileName);
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    applicationFormModel.General_Document_File.SaveAs(path);
                    applicationFormModel.General_Document = fileName;
                }
                DatabaseFunctions.saveApplicationForm(applicationFormModel);

                if (newApplication)
                {
                    SendApplicationStarted(applicationFormModel.Email_Address, "", "Your TSPadel Application", applicationFormModel.ApplicationCode);
                }

                if (applicationFormModel.completed)
                {
                    SendApplicationCompleted(applicationFormModel.Email_Address, "", "Your TSPadel Application", applicationFormModel.ApplicationCode);
                }

                return Json(new { success = true, ApplicationCode = applicationFormModel.ApplicationCode }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                SendApplicationError("john.knott@zolasystems.co.uk", "", "TSPadel ERROR", ex.Message + "<br/><br/>" + ex.StackTrace + "<br/><br/>" + applicationFormModel.ToString());
                //Throw an exception if there is a problem sending the email
                return Json(new { success = false, ApplicationCode = applicationFormModel.ApplicationCode }, JsonRequestBehavior.AllowGet);
            }
        }

        public static SmtpClient GetSmtpClient()
        {

            //Get default SMTP server settings from our settings node
            //var homepage = UmbracoContext.Current.ContentCache.GetAtRoot().SingleOrDefault(x => x.ContentType.Alias == "settings");

            var server = "smtp.office365.com";
            var user = "admin@TSPadel.co.uk";
            var pass = "C4bw14dmin0916#";

            //Do a null check just in case homepage node values are empty (fallback to Constants)
            server = String.IsNullOrEmpty(server) ? SmtpServer : server;
            user = String.IsNullOrEmpty(user) ? SmtpUser : user;
            pass = String.IsNullOrEmpty(pass) ? SmtpPassword : pass;

            //Create new SmtpClient
            var smtp = new SmtpClient { Host = server, Credentials = new NetworkCredential(user, pass) };
            smtp.EnableSsl = true;
            smtp.Port = SmtpPort;
            //Return the SMTP object
            return smtp;
        }

        internal static void SendApplicationStarted(string Email, string emailFrom, string emailSubject, string applicationCode)
        {
            //Reset link
            var registerUrl = "https://www.TSPadel.org.uk/application-form?ApplicationCode=" + applicationCode;

            var message = "<h3>TSPadel Application Acknowledgement</h3>" +
                "<p>We are pleased that you have started to complete a grant application.  Here is the link to your saved application.</p>" +
                "<a href='" + registerUrl + "'>TSPadel Appplication</a>" +
                "<p>The deadline to submit applications is Monday 19th February 2024 at 18.00.</p>" +
                "<br/><br/>" +
                "Yours faithfully," +
                "<br/><br/>" +
                "<p>Cristina O’Halloran</p>" +
                "<p>Grants Administrator</p>";


            //Create email message to send
            var email = new MailMessage("TSPadel GRANTS <grants@TSPadel.org.uk>", Email)
            {
                Subject = emailSubject,
                IsBodyHtml = true,
                Body = message
            };

            MailAddress copy = new MailAddress("grants@TSPadel.org.uk");
            email.CC.Add(copy);

            try
            {
                var smtp = GetSmtpClient();

                //Try & send the email with the SMTP settings
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }
        }

        internal static void SendApplicationCompleted(string Email, string emailFrom, string emailSubject, string applicationCode)
        {
            //Reset link
            var registerUrl = "https://www.TSPadel.org.uk/application-form?ApplicationCode=" + applicationCode;

            var message = "<h3>TSPadel Application Acknowledgement</h3>" +
                "<p>Your application has been received. We will be in touch soon.</p>" +
                "<p>Here is the link to your completed application.</p>" +
                "<a href='" + registerUrl + "'>TSPadel Appplication</a>" +
                "<p>The deadline to submit applications is Monday 19th February 2024 at 18.00.</p>" +
                "<br/><br/>" +
                "Yours faithfully," +
                "<br/><br/>" +
                "<p>Cristina O’Halloran</p>" +
                "<p>Grants Administrator</p>";


            //Create email message to send
            var email = new MailMessage("TSPadel GRANTS <grants@TSPadel.org.uk>", Email)
            {
                Subject = emailSubject,
                IsBodyHtml = true,
                Body = message
            };

            try
            {
                var smtp = GetSmtpClient();

                //Try & send the email with the SMTP settings
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }
        }

        public static void SendApplicationError(string Email, string emailFrom, string emailSubject, string errorMessage)
        {


            //Create email message to send
            var email = new MailMessage("TSPadel GRANTS <grants@TSPadel.org.uk>", Email)
            {
                Subject = emailSubject,
                IsBodyHtml = true,
                Body = errorMessage
            };

            try
            {
                var smtp = GetSmtpClient();

                //Try & send the email with the SMTP settings
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }
        }
    }
}
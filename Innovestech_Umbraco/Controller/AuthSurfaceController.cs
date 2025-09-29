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

namespace TSPadel_Umbraco.Controller
{
    public class AuthSurfaceController : SurfaceController
    {
        private readonly MembershipHelper _memberHelper;

        public AuthSurfaceController(MembershipHelper memberHelper)
        {
            _memberHelper = memberHelper;
        }
        /// <summary>
        /// Handles the login form when user posts the form/attempts to login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult HandleLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //user already logged in redirect them
            if (this.Members.IsLoggedIn())
            {
                //string currentUserName = this.Members.CurrentUserName;
                //int currentMemberId = this.Members.GetCurrentMemberId();
                //IPublishedContent member = this.Members.GetCurrentMember();
                //ProfileModel profile = this.Members.GetCurrentMemberProfileModel();
                return Redirect("/ccd/applications/");
            }

            //Lets TRY to log the user in
            try
            {
                Session["Email"] = model.EmailAddress;
                //Try and login the user...
                if (Membership.ValidateUser(model.EmailAddress, model.Password))
                {
                    //Get the member from their email address
                    var checkMember = Members.GetByEmail(model.EmailAddress);
                    if (checkMember != null)
                    {
                        //If they have verified then lets log them in
                        //Set Auth cookie
                        FormsAuthentication.SetAuthCookie(model.EmailAddress, true);
                        Session["CustomerID"] = 0;

                        //Once logged in - redirect them back to the return URL
                        return new RedirectResult("/ccd/applications/");
                    }
                }
                else
                {
                    //error logging in
                    ModelState.AddModelError("LoginForm.", "Invalid details");
                    return CurrentUmbracoPage();
                }
            }
            catch (Exception ex)
            {
                //error logging in
                ModelState.AddModelError("LoginForm.", "Error: " + ex.ToString());
                return CurrentUmbracoPage();
            }

            //In theory should never hit this, but you never know...
            return RedirectToCurrentUmbracoPage();
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //Member already logged in, lets log them out and redirect them home
            if (Members.IsLoggedIn())
            {
                //Log member out
                FormsAuthentication.SignOut();

                //Redirect home
                return Redirect("/ccd");
            }
            else
            {
                //Redirect home
                return Redirect("/ccd");
            }
        }

    }
}
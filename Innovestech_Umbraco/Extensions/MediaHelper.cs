using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;
using Umbraco.Core.Models.PublishedContent;

namespace TSPadel_Umbraco.Extensions
{
    public class MediaHelper
    {

        public static String GetImageURL(string imageURL, Int32 ImageWidth, HttpRequest request)
        {
            String mediaURL = "";

            String imgFormat = "";
            String browser = GetUserEnvironment(request);

            if (browser != "Mac OS" && browser != "iPad" && browser != "iPhone")
            {
                imgFormat = "&format=webp";
            }
            try
            {
                mediaURL = imageURL;
                //mediaURL = "/images/standard/logo.png";
                //mediaURL = "/media/1305/animals-in-war-campell-park.jpg";
                /*
                            if (mediaURL == null || mediaURL == "")
                            {
                                UmbracoHelper uHelper = new UmbracoHelper(UmbracoContext.Current);
                                var mediaItem = uHelper.Media(contentItem.GetPropertyValue(propertyName));
                                mediaURL = mediaItem.GetPropertyValue("umbracoFile").Value.ToString();
                            }
                */
                if (ImageWidth != 0 && mediaURL != "")
                {
                    mediaURL = mediaURL + "?width=" + ImageWidth + imgFormat;
                    //mediaURL = mediaURL;
                }
            }
            catch
            {
                mediaURL = "";
            }

            //if (mediaURL == "") { mediaURL = "/images/standard/logo.png"; }
            //mediaURL = "";
            return mediaURL;
        }

        public static String GetMediaURL(IPublishedContent contentItem, string propertyName, Int32 ImageWidth, HttpRequest request)
        {
            String mediaURL = "";

            //mediaURL = Umbraco.Core.Media(itemID).Url;
            String imgFormat = "";
            String browser = GetUserEnvironment(request);

            if (browser != "Mac OS" && browser != "iPad" && browser != "iPhone")
            {
                imgFormat = "&format=webp";
            }
            try
            {
                if (contentItem.Value<IPublishedContent>(propertyName) != null) { 
                mediaURL = contentItem.Value<IPublishedContent>(propertyName).Url();
                //mediaURL = "/images/standard/logo.png";
                //mediaURL = "/media/1305/animals-in-war-campell-park.jpg";
                /*
                            if (mediaURL == null || mediaURL == "")
                            {
                                UmbracoHelper uHelper = new UmbracoHelper(UmbracoContext.Current);
                                var mediaItem = uHelper.Media(contentItem.GetPropertyValue(propertyName));
                                mediaURL = mediaItem.GetPropertyValue("umbracoFile").Value.ToString();
                            }
                */
                if (ImageWidth != 0 && mediaURL != "")
                {
                    mediaURL = mediaURL + "?width=" + ImageWidth + imgFormat;
                    //mediaURL = mediaURL;
                }
                }
            }
            catch
            {
                mediaURL = "";
            }

            //if (mediaURL == "") { mediaURL = "/images/standard/logo.png"; }
            //mediaURL = "";
            return mediaURL;
        }

        public static String GetMediaALT(IPublishedContent contentItem, string propertyName)
        {
            String mediaALT = "";

            try
            {
                //mediaURL = Umbraco.Core.Media(itemID).Url;

                //mediaALT = contentItem.GetPropertyValue<IPublishedContent>(propertyName);

                if (mediaALT == "")
                {
                    mediaALT = contentItem.Value<IPublishedContent>(propertyName).Name;
                }
            }
            catch
            {
                mediaALT = "";
            }

            return mediaALT;
        }

        public static String GetMediaTitle(IPublishedContent contentItem, string propertyName)
        {
            String mediaTitle = "";

            try
            {
                //mediaURL = Umbraco.Core.Media(itemID).Url;

                //    mediaTitle = contentItem.GetPropertyValue<IPublishedContent>(propertyName).TitleTag;

                if (mediaTitle == "")
                {
                    mediaTitle = contentItem.Value<IPublishedContent>(propertyName).Name;
                }
            }
            catch
            {
                mediaTitle = "";
            }
            return mediaTitle;
        }

        public static String GetUserEnvironment(HttpRequest request)
        {
            var browser = request.Browser;
            var platform = GetUserPlatform(request);
            return string.Format("{0} {1} / {2}", browser.Browser, browser.Version, platform);
        }

        public static String GetUserPlatform(HttpRequest request)
        {
            var ua = request.UserAgent;

            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";

            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

            if (ua.Contains("Mac OS"))
                return "Mac OS";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                return "Windows 10";

            //fallback to basic platform:
            return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
        }

        public static String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }

    }
}
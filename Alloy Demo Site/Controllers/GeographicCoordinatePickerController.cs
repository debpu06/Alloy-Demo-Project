using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alloy_Demo_Site.Models.ViewModels;

namespace Alloy_Demo_Site.Controllers
{
    [Authorize(Roles = "CmsEditors, CmsAdmins")]
    public class GeographicCoordinatePickerController : Controller
    {
        public ActionResult Index(decimal latitude = 0, decimal longitude = 0)
        {
            var model = new GeographicCoordinateViewModel();
            model.BingApiKey = ConfigurationManager.AppSettings["BingApiKey"];
            model.Latitude = latitude;
            model.Longitude = longitude;
            return View(model);
        }
    }
}
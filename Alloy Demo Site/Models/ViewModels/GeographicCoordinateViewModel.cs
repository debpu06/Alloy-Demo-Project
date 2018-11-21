using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alloy_Demo_Site.Models.ViewModels
{
    public class GeographicCoordinateViewModel
    {
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public string BingApiKey { get; set; }
    }
}
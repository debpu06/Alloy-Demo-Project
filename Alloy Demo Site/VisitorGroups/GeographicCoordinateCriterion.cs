using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Alloy_Demo_Site.Models.CriterionModels;
using EPiServer.Personalization;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Personalization.VisitorGroups.Criteria;
using EPiServer.ServiceLocation;

namespace Alloy_Demo_Site.VisitorGroups
{
    [VisitorGroupCriterion(
        Category = "Custom Visitor Groups",
        Description = "Get Geographic Range with Coordinates using Bing Maps",
        DisplayName = "Geographic Coordinates", ScriptUrl = "~/ClientResources/Scripts/GeographicCoodinateCriterion.js")]
    public class GeographicCoordinateCriterion : CriterionBase<GeographicCoordinateCriteria>
    {
        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            try
            {
                var clientGeolocationResolver = ServiceLocator.Current.GetInstance<IClientGeolocationResolver>();
                //Get users location from request
                var currentCoordinate = clientGeolocationResolver.ResolveLocation(httpContext);
                //Get distance from specified coordinates in meters
                var distanceInMeters = Model.Coordinate.GetDistanceTo(currentCoordinate.Location);

                if (this.Model.Measurement == DistanceUnit.Miles)
                {
                    //convert distance in miles
                    var distanceInMiles = ConvertMetersToMiles(distanceInMeters);
                    return distanceInMiles <= Model.Range;
                }

                return distanceInMeters <= Model.Range * 1000;
            }
            catch (Exception e)
            {
                //Could throw exception if running on localhost and no location can be determined
                return false;
            }
        }

        /// <summary>
        /// Convert meters to miles
        /// </summary>
        /// <param name="meters"></param>
        /// <returns></returns>
        private double ConvertMetersToMiles(double meters)
        {
            return (meters / 1609.344);
        }

    }
}
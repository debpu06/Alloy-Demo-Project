using EPiServer.Personalization;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.Personalization.VisitorGroups.Criteria;
using System.ComponentModel.DataAnnotations;
using EPiServer.Web.Mvc.VisitorGroups;

namespace Alloy_Demo_Site.Models.CriterionModels
{
    public class GeographicCoordinateCriteria : CriterionModelBase
    {
        public override ICriterionModel Copy()
        {
            return base.ShallowCopy();
        }

        [Required]
        [Range(-90.0, 90.0)]
        public double Latitude { get; set; }
        [Required]
        [Range(-180.0, 180.0)]
        public double Longitude { get; set; }
        [Required]
        [Range(0.0, int.MaxValue)]
        public int Range { get; set; }
        [Required]
        [DojoWidget(AdditionalOptions = "{ selectOnClick: true }", SelectionFactoryType = typeof(EnumSelectionFactory))]
        public DistanceUnit Measurement { get; set; }
        public GeoCoordinate Coordinate
        {
            get { return new GeoCoordinate(Latitude, Longitude); }
        }
    }
}
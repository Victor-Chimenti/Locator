using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Locator.Models
{
    public partial class PointTable
    {
        public string LocationId { get; set; }
        public Geometry Point { get; set; }

        public virtual Locations Location { get; set; }
    }
}

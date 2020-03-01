using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Locator.Models
{
    public partial class PointTable
    {
        [Column(TypeName = "geometry")]
        public Geometry Point { get; set; }


        public virtual Locations Location { get; set; }
        public string LocationID { get; set; }

    }
}

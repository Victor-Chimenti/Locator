using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;
using GeoAPI.Geometries;
using Locator.Models;


namespace Locator.Entities
{
    // Child class inherits from the Locations Model
    public class TellerMachine : Locations
    {

        [Column(TypeName = "geometry")]
        public IPoint Location { get; set; }
    }
}

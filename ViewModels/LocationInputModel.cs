using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Locator.Controllers;

namespace Locator.ViewModels
{
    public class LocationInputModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}

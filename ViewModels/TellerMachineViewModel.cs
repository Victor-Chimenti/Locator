using Locator.Models;
using Locator.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;


namespace Locator.ViewModels
{
    public class TellerMachineViewModel
    {

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }

    }
}

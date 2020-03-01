﻿using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.NetTopologySuite;
namespace Locator.Models
{
    public partial class Locations
    {
        public string LocationID { get; set; }
        public string CoopLocationId { get; set; }
        public bool TakeCoopData { get; set; }
        public bool SoftDelete { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Hours { get; set; }
        public string RetailOutlet { get; set; }
        public string LocationType { get; set; }
        public Geometry Point { get; set; }

        public virtual Contacts Contacts { get; set; }
        public virtual DailyHours DailyHours { get; set; }
        public virtual SpecialQualities SpecialQualities { get; set; }
    }
}

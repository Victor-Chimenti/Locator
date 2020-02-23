using Locator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Locator.ViewModels
{
    public class LocationViewModel
    {
        public Guid Id { get; set; }

        //[Required(ErrorMessage = "required")]
        public string LocationName { get; set; }

        public int SelectedValue { get; set; }

        public virtual LocationCard LocationCard { get; set; }

        [DisplayName("Location Card")]
        public virtual ICollection<LocationCard> LocationCards { get; set; }
    }
}

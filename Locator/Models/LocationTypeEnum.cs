using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Models
{
    public enum LocationTypeEnum
    {
        [Display(Name = "ATM")]
        A,
        [Display(Name = "Shared Branch")]
        S
    }
}

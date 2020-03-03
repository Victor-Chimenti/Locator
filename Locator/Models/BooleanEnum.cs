﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Locator.Models
{
    public enum BooleanEnum
    {
        [Display(Name = "No")]
        N = 0,
        [Display(Name = "Yes")]
        Y = 1,
        [Display(Name = "None")]
        NULL
    }

    public static class BooleanEnumExtensions
    {
        public static string GetDisplayName(this BooleanEnum booleanEnum)
        {
            switch (booleanEnum)
            {
                case (BooleanEnum.N):
                    return "No";

                case (BooleanEnum.Y):
                    return "Yes";

                default:
                    return "Not Set";
            }
        }
    }
}

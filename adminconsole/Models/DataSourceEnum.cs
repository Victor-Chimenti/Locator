using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace adminconsole.Models
{
    public enum DataSourceEnum
    {
        // Display live data from DB
        LIVE,
        
        // Display mock test data
        TEST
    }
}

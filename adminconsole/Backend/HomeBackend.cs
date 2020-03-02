using adminconsole.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace adminconsole.Backend
{
    public class HomeBackend
    {
        private const string U = "jake";
        private const string P = "isamazing";

        public bool Login(string username, string password)
        {
            if (username is null)
            {
                return false;
            }


            if (password is null)
            {
                return false;
            }

            if (!username.Trim().Equals(U))
            {
                return false;
            }


            if (!password.Trim().Equals(P))
            {
                return false;
            }

            return true;
        }
    }
}

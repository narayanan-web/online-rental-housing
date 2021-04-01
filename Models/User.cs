using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rental_housing.Models
{
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public Category category { get; set; }
    }

    public enum Category
    {
        Tenant, Houseowner
    }
}
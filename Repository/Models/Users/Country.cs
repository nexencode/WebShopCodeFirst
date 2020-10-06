using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.Users
{
    public class Country
    {
        #region Fields and Properties
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public string CountryCode { get; set; }
        public bool IsActive { get; set; } = true;
        #endregion

        #region Constructors
        public Country()
        {

        }
        public Country(int id, string countryName, string countryCode, bool isActive)
        {
            CountryName = countryName;
            CountryCode = countryCode;
            IsActive = isActive;
        }


        #endregion
    }
}
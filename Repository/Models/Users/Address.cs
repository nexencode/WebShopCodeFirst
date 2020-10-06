using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.Users
{
    public class Address
    {
        #region Fields and Properties

        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        #endregion

        #region Constructors
        public Address() { }

        public Address(int id, string city, string street, string streetNumber, string region, int countryId, string postalCode)
        {
            City = city;
            Street = street;
            StreetNumber = streetNumber;
            Region = region;
            CountryId = countryId;
            PostalCode = postalCode;
        }
        #endregion

        #region Methods
        public string ShowAddress()
        {
            return $"City: {City}, Street: {Street}, Postal Code: {PostalCode}";
        }
        #endregion
    }
}
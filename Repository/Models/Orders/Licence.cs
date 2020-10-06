using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models.Orders
{
    public class Licence
    {
        public int LicenceId { get; set; }
        public string Key { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
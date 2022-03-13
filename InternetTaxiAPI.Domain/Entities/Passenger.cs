using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Domain.Entities
{
    public class Passenger
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Gender { get; set; }
        public int Trips { get; set; }

    }
}

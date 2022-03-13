using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Domain.Entities
{
    public class Trip
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string BegginAddress { get; set; }
        public string EndAddress { get; set; }
        public virtual Passenger Passenger { get; set; }
        public long PassengerId { get; set; }
        public virtual Driver Driver { get; set; }
        public long DriverId { get; set; }
        public double Price { get; set; }
        public bool IsFinished { get; set; }
    }
}

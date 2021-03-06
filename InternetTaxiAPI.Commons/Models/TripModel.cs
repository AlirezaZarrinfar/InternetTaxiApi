using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Commons.Models
{
    public class TripModel
    {
        public long Id { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string BegginAddress { get; set; }
        [Required]

        public string EndAddress { get; set; }
        [Required]

        public long PassengerId { get; set; }
        [Required]

        public long DriverId { get; set; }
        [Required]

        public double Price { get; set; }

    }
}

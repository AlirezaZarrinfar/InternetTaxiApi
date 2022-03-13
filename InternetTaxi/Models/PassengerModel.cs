using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxi.Models
{
    public class PassengerModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NationalCode { get; set; }
        [Required]
        public string Gender { get; set; }
        public int Trips { get; set; }

    }
}

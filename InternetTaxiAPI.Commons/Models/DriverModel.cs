using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Models
{
    public class DriverModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NationalCode { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BirthdayTime { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public string CarNumber { get; set; }



    }
}

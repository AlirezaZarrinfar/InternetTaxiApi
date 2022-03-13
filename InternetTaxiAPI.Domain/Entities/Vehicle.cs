using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Domain.Entities
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NumberPlate { get; set; }
        public bool IsAvailable { get; set; }
    }
}

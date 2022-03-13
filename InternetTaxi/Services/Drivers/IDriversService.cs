using InternetTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxi.Services.Drivers
{
    public interface IDriversService
    {
        public bool Create(DriverModel model);
        public List<InternetTaxiAPI.Models.DriverModel> Read();

        public bool Delete(long id);

    }
}

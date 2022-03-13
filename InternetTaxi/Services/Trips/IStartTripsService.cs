using InternetTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxi.Services.Trips
{
    public interface IStartTripsService
    {
        public InternetTaxiAPI.Commons.Models.TripModel StartTrip(TripModel model); 
    }
}

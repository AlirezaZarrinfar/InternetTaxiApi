
using InternetTaxiAPI.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Application.Services.Trip
{
    public interface ITripService
    {
        public int GetTripsNum(long Id);
        public Task<TripModel> StartTrip(TripModel model);
        public  Task<bool> EndTrip(long Id);
    }
}

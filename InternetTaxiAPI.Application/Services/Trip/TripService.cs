
using InternetTaxiAPI.Commons.Models;
using InternetTaxiAPI.Domain.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Application.Services.Trip
{
    public class TripService : ITripService
    {
        private readonly DatabaseContext _context;
        public TripService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<TripModel> StartTrip (TripModel model)
        {
            var driver = _context.Drivers.Find(model.DriverId);
            var vehicle = _context.Vehicles.Find(driver.VehicleId);

            if (vehicle.IsAvailable)
            {
                InternetTaxiAPI.Domain.Entities.Trip trip = new Domain.Entities.Trip()
                {
                    City = model.City,
                    BegginAddress = model.BegginAddress,
                    EndAddress = model.EndAddress,
                    DriverId = model.DriverId,
                    PassengerId = model.PassengerId,
                    Price = model.Price,
                    IsFinished = false,
                };
                vehicle.IsAvailable = false;
                await _context.AddAsync(trip);
                await _context.SaveChangesAsync();
                model.Id = trip.Id;
                return model;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> EndTrip(long Id)
        {
                var trip = _context.Trips.Find(Id);
                trip.IsFinished = true;
                var driver = _context.Drivers.Find(trip.DriverId);
                var car = _context.Vehicles.Find(driver.VehicleId);
                car.IsAvailable = true;
                var passenger = _context.Passengers.Find(trip.PassengerId);
                passenger.Trips++;
                await _context.SaveChangesAsync();
                return true;
        }
        public int GetTripsNum (long Id)
        {
            var pass = _context.Passengers.Find(Id);
            return pass.Trips;
        }
    }
}

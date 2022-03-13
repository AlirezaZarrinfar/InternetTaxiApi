using InternetTaxiAPI.Domain.Context;
using InternetTaxiAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Application.Services.Passenger
{
    public class PassengerService : IPassengerService
    {
        private readonly DatabaseContext _context;
        public PassengerService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(PassengerModel model)
        {
            InternetTaxiAPI.Domain.Entities.Passenger passenger = new Domain.Entities.Passenger()
            {
                Name = model.Name,
                LastName = model.LastName,
                Gender = model.Gender,
                NationalCode = model.NationalCode,
            };
            await _context.AddAsync(passenger);
            await _context.SaveChangesAsync();
            return true;
        }
        public List<PassengerModel> Read()
        {
            var passenger = _context.Passengers.AsQueryable();
            return passenger.Select(p => new PassengerModel
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                Gender = p.Gender,
                NationalCode = p.NationalCode,
                Trips = p.Trips,
            }).ToList();
        }
        public async Task<bool> Update(long Id ,PassengerModel model)
        {
            var passenger = _context.Passengers.Find(Id);
            passenger.Name = model.Name;
            passenger.LastName = model.LastName;
            passenger.NationalCode = model.NationalCode;
            passenger.Gender = model.Gender;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(long Id)
        {
            var passenger = _context.Passengers.Find(Id);
            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}

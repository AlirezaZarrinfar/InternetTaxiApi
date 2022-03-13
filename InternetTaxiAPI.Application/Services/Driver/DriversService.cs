using InternetTaxiAPI.Domain.Context;
using InternetTaxiAPI.Domain.Entities;
using InternetTaxiAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Application.Services.Driver
{
    public class DriversService : IDriversService
    {
        private readonly DatabaseContext _context;
        public DriversService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(DriverModel model)
        {

            Vehicle vehicle = new Vehicle()
            {
                Name = model.CarName,
                NumberPlate = model.CarNumber,
                IsAvailable = true
            };

            await _context.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            InternetTaxiAPI.Domain.Entities.Driver driver = new Domain.Entities.Driver()
            {
                Name = model.Name,
                LastName = model.LastName,
                NationalCode = model.NationalCode,
                VehicleId = vehicle.Id,
                Gender = model.Gender,
                BirthdayTime = model.BirthdayTime
            };
            await _context.AddAsync(driver);
            await _context.SaveChangesAsync();
            return true;
        }
        public  List<DriverModel> Read()
        {
            var user = _context.Drivers.AsQueryable() ;
            return user.Select(p => new DriverModel
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                Gender = p.Gender,
                NationalCode = p.NationalCode,
                BirthdayTime = p.BirthdayTime,
                CarName = p.Vehicle.Name,
                CarNumber = p.Vehicle.NumberPlate,
            }).ToList();
        }
        public async Task<bool> Update(long Id,DriverModel model)
        {
            var user = _context.Drivers.Find(Id);
            user.Name = model.Name;
            user.LastName = model.LastName;
            user.NationalCode = model.NationalCode;
            user.BirthdayTime = model.BirthdayTime;
            user.Gender = model.Gender;
            var car = _context.Vehicles.Find(user.VehicleId);
            car.Name = model.CarName;
            car.NumberPlate = model.CarNumber;
            await _context.SaveChangesAsync();
            return true; 
        }
        public async Task<bool> Delete(long Id)
        {
            var user = _context.Drivers.Find(Id);
            var car = _context.Vehicles.Find(user.VehicleId);
            if (user == null)
            {
                return false;
            }
            _context.Remove(car);
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

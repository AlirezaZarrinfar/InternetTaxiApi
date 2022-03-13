using InternetTaxiAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Application.Services.Passenger
{
    public interface IPassengerService
    {
        public Task<bool> Create(PassengerModel model);
        public List<PassengerModel> Read();
        public Task<bool> Update(long Id, PassengerModel model);
        public Task<bool> Delete(long Id);

    }
    
}

using InternetTaxiAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Application.Services.Driver
{
    public interface IDriversService
    {
        public Task<bool> Create(DriverModel model);
        public List<DriverModel> Read();
        public Task<bool> Update(long Id,DriverModel model);
        public Task<bool> Delete(long Id);

    }
}

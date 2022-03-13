using InternetTaxiAPI.Application.Services.Driver;
using InternetTaxiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace InternetTaxiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriversService _driversServices;
        public DriverController(IDriversService driversServices)
        {
            _driversServices = driversServices;
        }
        [HttpPost]
        public async Task<IActionResult> Create(DriverModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _driversServices.Create(model);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        [HttpGet]
        public IActionResult Read()
        {
            var result = _driversServices.Read();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long Id, DriverModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _driversServices.Update(Id, model);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        [HttpDelete("{Id}")]
       public async Task<IActionResult> Delete(long Id)
        {
            var result = await _driversServices.Delete(Id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

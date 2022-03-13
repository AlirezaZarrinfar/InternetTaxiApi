using InternetTaxiAPI.Application.Services.Passenger;
using InternetTaxiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(PassengerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _passengerService.Create(model);
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
            var result = _passengerService.Read();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long Id, PassengerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await _passengerService.Update(Id, model);
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
            var result = await _passengerService.Delete(Id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}

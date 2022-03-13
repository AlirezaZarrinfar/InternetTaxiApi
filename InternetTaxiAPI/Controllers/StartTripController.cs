using InternetTaxiAPI.Application.Services.Trip;
using InternetTaxiAPI.Commons.Models;
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
    public class StartTripController : ControllerBase
    {
        private readonly ITripService _tripService;
        public StartTripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpPost]
        public async Task<IActionResult> StartTrip(TripModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var res = await _tripService.StartTrip(model);
            return Ok(res);
        }
        [HttpGet("{Id}")]
        public IActionResult GetNationalCode(long Id)
        {
            var res = _tripService.GetTripsNum(Id);
            return Ok(res);
        }
    }
}

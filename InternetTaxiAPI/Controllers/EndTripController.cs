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
    public class EndTripController : ControllerBase
    {
        private readonly ITripService _tripService;
        public EndTripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> EndTrip(long Id)
        {
            var result = await _tripService.EndTrip(Id);
            return Ok(result);
        }
    }
}

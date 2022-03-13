using InternetTaxi.Models;
using InternetTaxi.Services.Trips;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxi.Controllers
{
    public class TripController : Controller
    {
        private readonly IStartTripsService _startTripsService;
        private readonly IEndTripsService _endTripsService;

        public TripController(IStartTripsService startTripsService, IEndTripsService endTripsService)
        {
            _startTripsService = startTripsService;
            _endTripsService = endTripsService;
        }
        [HttpGet]
        public IActionResult StartTrip()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StartTrip(TripModel model)
        {
            var res = _startTripsService.StartTrip(model);
            return Json(res);
        }
        public IActionResult EndTrip(long Id)
        {
            var res = _endTripsService.EndTrip(Id);
            return Ok(res);
        }
    }
}

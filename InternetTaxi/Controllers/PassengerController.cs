using InternetTaxi.Models;
using InternetTaxi.Services.Passengers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxi.Controllers
{
    public class PassengerController : Controller
    {
        private IPassengersService _PassengerService;
        public PassengerController(IPassengersService PassengerService)
        {
            _PassengerService = PassengerService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PassengerModel model)
        {
            var res = _PassengerService.Create(model);
            return Json(res);
        }
        [HttpGet]
        public IActionResult Read()
        {
            var res = _PassengerService.Read();
            return View(res);
        }

        public IActionResult Delete(long id)
        {
            var res = _PassengerService.Delete(id);
            return Json(res);
        }
    }
}

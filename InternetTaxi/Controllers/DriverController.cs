using InternetTaxi.Models;
using InternetTaxi.Services.Drivers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTaxi.Controllers
{
    public class DriverController : Controller
    {
        private IDriversService _driversService;
        public DriverController(IDriversService driversService)
        {
            _driversService = driversService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DriverModel model)
        {
            var res = _driversService.Create(model);
            return Json(res);
        }
        [HttpGet]
        public IActionResult Read()
        {
            var res = _driversService.Read();
            return View(res);
        }
        
        public IActionResult Delete(long id)
        {
            var res = _driversService.Delete(id);
            return Json(res);       
        }
    }
}

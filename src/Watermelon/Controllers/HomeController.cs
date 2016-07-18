using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Watermelon.Services;
using Microsoft.Extensions.Options;

namespace Watermelon.Controllers
{
    public class HomeController : Controller
    {
        private IReferenceDataService _referenceDataService;


        public HomeController(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;
        }

        public IActionResult Index()
        {
            var test = _referenceDataService.GetAirports();
            var test2 = _referenceDataService.GetCities();
            var test3 = _referenceDataService.GetAirports(); //TODO: Remove testings
            var test4 = _referenceDataService.GetCities();
            
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

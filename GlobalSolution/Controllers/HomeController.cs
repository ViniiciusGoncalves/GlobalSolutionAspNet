using GlobalSolution.Models;
using GlobalSolution.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClinicaService _clinicaService;

        public HomeController(ClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }

        public async Task<IActionResult> Index()
        {
            var clinicas = await _clinicaService.GetAllClinicasAsync();
            return View(clinicas);
        }
    }

}

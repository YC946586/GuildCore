using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuildCore.Mvc.Models;
using GuildCore.Entities;
using GuildCore.Services.Category;

namespace GuildCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ICategoryService _generalDbContext;

        public HomeController(ICategoryService generalDbContext)
        {
            this._generalDbContext = generalDbContext;
        }


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = _generalDbContext.getAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

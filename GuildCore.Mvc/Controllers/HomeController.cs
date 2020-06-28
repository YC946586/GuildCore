using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuildCore.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using GuildCore.Common;
using GuildCore.Application.User.Dto;
using GuildCore.Application.User;

namespace GuildCore.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "首页"; 
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

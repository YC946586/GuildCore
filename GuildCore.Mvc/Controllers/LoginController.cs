using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildCore.Application.User;
using GuildCore.Application.User.Dto;
using GuildCore.Common;
using GuildCore.Domain.Model.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildCore.Mvc.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(UserModelDto input)
        {
            if (ModelState.IsValid)
            {
                 var dd= await _loginService.VerificationUserLogin(input);
            }
            //return BadRequest("没有该用户");
            return RedirectToAction("Home", "Index");

        }
    }
}
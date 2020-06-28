using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using GuildCore.Application.User;
using GuildCore.Application.User.Dto;
using GuildCore.Common;

namespace GuildCore.Mvc.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly ILoginService _loginService;
        /// <summary>
        /// 主机的参数
        /// </summary>
        private IHostEnvironment _Hosting;
        public BannerController(ILoginService loginService)
        {
            _loginService = loginService;
            //this._Hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditBanner()
        {
            return View();
        }
       
        // GET: BannerController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BannerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BannerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BannerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BannerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BannerController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BannerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

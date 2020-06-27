using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildCore.Entities.Request;
using GuildCore.Entities.Response;
using GuildCore.Services.BannerServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace GuildCore.Mvc.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BannerController : Controller
    {
        private BannerService _banner;

        /// <summary>
        /// 主机的参数
        /// </summary>
        private IHostEnvironment _Hosting;
        public BannerController(BannerService bannerService, IHostEnvironment hosting)
        {
            this._banner = bannerService;
            this._Hosting = hosting;
        }

        public IActionResult Index()
        {
            var banner = _banner.GetBannerList();
            return View(banner);
        }

        public IActionResult EditBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Upload(AddBanner addBanner, IFormCollection Iform)
        {
            try
            {
                var files = Iform.Files;
                if (Iform.Count != 0)
                {
                    var webPath = _Hosting.ContentRootPath;
                    string relativeath = "\\BannerPic";
                    string uplpadPath = webPath + relativeath;
                    string[] fileType = new string[] { ".gif", ".jpg", ".png", ".jpeg", ".bmp" };

                    string extension = Path.GetExtension(Iform.ToString());

                    if (!Directory.Exists(uplpadPath)) Directory.CreateDirectory(uplpadPath);
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + uplpadPath;
                    string filePath = uplpadPath + "\\" + fileName;
                    using (var stream=new FileStream(filePath, FileMode.Create))
                    {
                        //await Iform
                    }

                }
                return Json(new ResponseModel() { Code = 0, result = "上传失败" });
            }
            catch (Exception ex)
            {

                throw;
            }
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

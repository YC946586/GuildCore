using GuildCore.Entities;
using GuildCore.Entities.Category;
using GuildCore.Entities.Request;
using GuildCore.Entities.Response;
using GuildCore.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuildCore.Services.BannerServer
{

   /// <summary>
   /// 
   /// </summary>
    public class BannerService
    {
        private GeneralDbContext _generalDbContext;

        public BannerService(GeneralDbContext db)
        {
            this._generalDbContext = db;
        }
        /// <summary>
        /// 添加Banner
        /// </summary>
        /// <param name="addBanner"></param>
        /// <returns></returns>
        public ResponseModel AddBanner(AddBanner addBanner )
        {
            var ba = new Banner { addDate = DateTime.Now, Image = addBanner.Image, Url = addBanner.Url, Remark = addBanner.Remark };
            _generalDbContext.Add(ba);
            int i = _generalDbContext.SaveChanges();
            if (i!=0)
            {
                return new ResponseModel { Code = 100, result = "添加Banner成功" };
            }
            else
            {
                return new ResponseModel { Code = 0, result = "添加失败" };
            }
        }
        /// <summary>
        /// /获取BannerList
        /// </summary>
        /// <returns></returns>

        public ResponseModel GetBannerList()
        {
            try
            {
                var dd = _generalDbContext.Banners.ToList();
                var banner = _generalDbContext.Banners.ToList().OrderByDescending(s => s.addDate).ToList();
                var Response = new ResponseModel() { Code = 100 };
                Response.data = new List<BannerModel>();
                foreach (var item in banner)
                {
                    Response.data.Add(new BannerModel
                    {
                        Id = item.Id,
                        Image = item.Image,
                        Url = item.Url,
                        Remark = item.Remark
                    });
                }
                return Response;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }


        public ResponseModel DelBanner(int bannerId)
        {
            var banner = _generalDbContext.Banners.Find(bannerId);

            var Response = new ResponseModel();
            if (banner!=null)
            {
                _generalDbContext.Banners.Remove(banner);
                Response.Code = 100;
                Response.result = "删除成功";
            }
            else
            {
                Response.Code = 0;
                Response.result = "删除失败";
            }
            return Response;
        }
    }
}

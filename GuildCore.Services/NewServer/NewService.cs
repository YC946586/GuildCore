using GuildCore.Entities.Category;
using GuildCore.Entities.Request;
using GuildCore.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuildCore.Services.NewServer
{
     public class NewService
    {
        private GeneralDbContext _generalDbContext;

        public NewService(GeneralDbContext db)
        {
            this._generalDbContext = db;
        }
        /// <summary>
        /// 添加新闻类别
        /// </summary>
        /// <param name="addNewClassify"></param>
        /// <returns></returns>
        public ResponseModel AddNewClassify(AddNewClassify addNewClassify)
        {
            var exit = _generalDbContext.NewClassifies.FirstOrDefault(s => s.Name==addNewClassify.Name) != null;
            if (exit)
                return new ResponseModel { Code = 0, result = "新闻类别以及存在" };
            var addcllfiy = new NewClassify { Name = addNewClassify.Name, Remark = addNewClassify.Remark, Sort = addNewClassify.Sort };
            _generalDbContext.NewClassifies.Add(addcllfiy);
            int i = _generalDbContext.SaveChanges();
            if (i != 0)
            {
                return new ResponseModel { Code = 100, result = "添加成功" };
            }
            else
            {
                return new ResponseModel { Code = 0, result = "添加失败" };
            }
        }
    }
}

using GuildCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuildCore.Services.Category
{
    public class CategoryService : ICategoryService
    {
        public GeneralDbContext _generalDbContext;


        public CategoryService(GeneralDbContext generalDbContext)
        {
            _generalDbContext = generalDbContext;
        }
        public List<Entities.Category.Category> getAll()
        {
            return _generalDbContext.Categories.ToList();
        }
    }
}

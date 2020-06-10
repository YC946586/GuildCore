using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Services.Category
{
   public  interface ICategoryService
    {
        public List<GuildCore.Entities.Category.Category> getAll();
    }
}

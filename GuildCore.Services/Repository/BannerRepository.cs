using GuildCore.Entities;
using GuildCore.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuildCore.Services.Repository
{
    public class BannerRepository : RepositoryBase<Banner>
    {
        public BannerRepository(GeneralDbContext context):base(context)
        {

        }
        public override void Insert(Banner entity)
        {  
            base.Insert(entity);
        }

    }
}

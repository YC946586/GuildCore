using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace GuildCore.Entities
{
    public class GeneralDbContext: DbContext
    {
        public GeneralDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category.Category> Categories { get; set; }
    }
}

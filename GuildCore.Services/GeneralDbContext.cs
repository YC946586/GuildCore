using GuildCore.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace GuildCore.Services
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class GeneralDbContext: DbContext
    {
        //public GeneralDbContext(DbContextOptions options) : base(options)
        //{

        //}

        private IConfiguration configuration;

        public GeneralDbContext()
        {
          //configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data source=F:/Data.db");
        }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Banner> Banners { get; set; }

        public virtual DbSet<NewClassify>  NewClassifies { get; set; }
        public virtual DbSet<NewComment> NewComments { get; set; }
        public virtual DbSet<News > News  { get; set; }

    }
}

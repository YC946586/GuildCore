using GuildCore.Entities.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace GuildCore.Entities
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class GeneralDbContext: DbContext
    {
        //public GeneralDbContext(DbContextOptions options) : base(options)
        //{

        //}

        public GeneralDbContext() { }
         protected override void OnConfiguring(DbContextOptionsBuilder dbCommandBuilder)
        {
            base.OnConfiguring(dbCommandBuilder);
            string ConnectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"Data.db;Pooling=true;FailIfMissing=false";
            dbCommandBuilder.UseSqlite(ConnectionString);
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

using GuildCore.Common.DomainInterfaces;
using GuildCore.Domain.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace GuildCore.EntityFrameworkCore
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
    public class GeneralDbContext: DbContext, IMyContext
    {
        public GeneralDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlite("Data source=F:/Data.db");
        //}


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<UserInfo> UserInfo { get; set; }
        //public virtual DbSet<Banner> Banners { get; set; }

        //public virtual DbSet<NewClassify>  NewClassifies { get; set; }
        //public virtual DbSet<NewComment> NewComments { get; set; }
        //public virtual DbSet<News > News  { get; set; }

    }
}

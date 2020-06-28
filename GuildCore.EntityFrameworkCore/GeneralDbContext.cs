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
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // 1. Add the IsDeleted property
                //entityType.GetOrAddProperty("IsDeleted", typeof(bool));

                // 2. Create the query filter
                var parameter = Expression.Parameter(entityType.ClrType);

                // 3. EF.Property<bool>(post, "IsDeleted")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                var isDeletedProperty =
                    Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                // 4. EF.Property<bool>(post, "IsDeleted") == false
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty,
                    Expression.Constant(false));

                // 5. post => EF.Property<bool>(post, "IsDeleted") == false
                var lambda = Expression.Lambda(compareExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);

            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildCore.Common.DomainInterfaces;
using GuildCore.Domain.Repository;
using GuildCore.EntityFrameworkCore;
using GuildCore.Mvc.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GuildCore.Common.IocHelper;
using Autofac.Configuration;

namespace GuildCore.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //配置数据库
            //services.AddDbContextPool<GeneralDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));

            //权限过滤
            services.AddAuthentication();
            //services.AddTransient<BannerService>();
            //services.AddTransient<NewService>();
           
            //依赖注入
            //services.AddScoped<IRepository, CategoryService>();
            //services.AddScoped<UnitOfWork, UnitOfWork<YunSourseContext>>();//注入UOW依赖，确保每次请求都是同一个对象

            services.AddMvc();
            services.AddDbContext<GeneralDbContext>(options => options.UseSqlite("Data source=Data.db"));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IMyContext, GeneralDbContext>();
            services.AddMvc(options =>
            {

                options.Filters.Add(typeof(ProjectExceptionFilter));// 异常过滤器 
            });
           
            //通过反射进行依赖注入
            //services.AddTransient(typeof(IBaseRepository<>));

            //通过反射进行依赖注入不能为空
            //services.RegisterAssembly("GuildCore.Domain.Repository");
            services.AddHttpContextAccessor();
            services.AddControllers() .AddControllersAsServices(); //属性注入必须加上这个 

            services.Configure(Configuration);
            //using (var database = new GeneralDbContext())    //新增
            //{
            //    database.Database.EnsureCreated(); //如果没有创建数据库会自动创建，最为关键的一句代码
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UserAuthenticaation
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areaRoute",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}

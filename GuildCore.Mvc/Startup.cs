using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildCore.Entities;
using GuildCore.Services;
using GuildCore.Services.BannerServer;
using GuildCore.Services.NewServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            //�������ݿ�
            //services.AddDbContextPool<GeneralDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings")));

            //Ȩ�޹���
            services.AddAuthentication();
            services.AddTransient<BannerService>();
            services.AddTransient<NewService>();
            services.AddTransient<GeneralDbContext>();
            
            //����ע��
            //services.AddScoped<IRepository, CategoryService>();
            //services.AddScoped<UnitOfWork, UnitOfWork<YunSourseContext>>();//ע��UOW������ȷ��ÿ��������ͬһ������

            services.AddMvc();
            using (var database = new GeneralDbContext())    //����
            {
                database.Database.EnsureCreated(); //���û�д������ݿ���Զ���������Ϊ�ؼ���һ�����
            }
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Autofac;
using Autofac.Extensions.DependencyInjection;
using GuildCore.Domain.Repository;
using GuildCore.Mvc.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildCore.Common.IocHelper;
using Autofac.Configuration;

namespace GuildCore.Mvc
{
    public static class DependencyInjectionConfig
    {
        //依赖注入的属性
        public static Autofac.IContainer Container { get; private set; }
        public static AutofacServiceProvider Configure(this IServiceCollection services, IConfiguration configuration)
        {
           
            //通过反射进行依赖注入
            //通过反射进行依赖注入不能为空
            //services.RegisterAssembly("ProjectCore.Domain.Repository.Interfaces", "ProjectCore.Infrastructure.Repository");
            services.RegisterAssembly("GuildCore.Application");
            services.RegisterAssembly("GuildCore.Domain.DomainService", "GuildCore.Infrastructure.DomainService");
            //Autofac依赖注入 Class的后面名字必须一致才能注入
            var builder = new ContainerBuilder();
            builder.Populate(services);
            var module = new ConfigurationModule(configuration);
            builder.RegisterModule(module);
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }
    }
}

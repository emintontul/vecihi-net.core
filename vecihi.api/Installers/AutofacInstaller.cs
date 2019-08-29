﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace vecihi.api.Installers
{
    public static class AutofacInstaller
    {
        public static IServiceProvider Container(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            // Load All Services
            Assembly.Load("vecihi.domain");
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
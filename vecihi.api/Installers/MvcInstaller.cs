﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using vecihi.infrastructure;

namespace vecihi.api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.OutputFormatters.RemoveType<StringOutputFormatter>();
                })
                .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #region Read-App-Parameters

            // Email
            services.Configure<EmailSettings>(Configuration.GetSection("AppParameters:" + nameof(EmailSettings)));

            #endregion
        }
    }
}
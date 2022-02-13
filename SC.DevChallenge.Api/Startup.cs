using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SC.DevChallenge.Api.Data;
using SC.DevChallenge.Api.Models;
using DateTimeConverter = SC.DevChallenge.Api.Models.DateTimeConverter;

namespace SC.DevChallenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var cultureInfo = new CultureInfo("fr-FR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("fr-FR");
                options.ApplyCurrentCultureToResponseHeaders = true;
                options.SetDefaultCulture("fr-FR");
                //By default the below will be set to whatever the server culture is. 
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("fr-FR") };
                options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("fr-FR") };

                options.RequestCultureProviders = new List<IRequestCultureProvider>();
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                });

            services.AddLocalization();

            TypeDescriptor.AddAttributes(typeof(DateTime), new TypeConverterAttribute(typeof(FrDateTimeConverter)));

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SC.DevChallenge.Api", Version = "v1" })
            );

            services.AddDbContext<SCDevChallengeApiContext>(options =>
                    options.UseInMemoryDatabase(Configuration.GetConnectionString("SCDevChallengeApiContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SC.DevChallenge.Api v1"));
            }

            app.UseRequestLocalization();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<SCDevChallengeApiContext>();
               // context.Database.EnsureCreated();
                DBInitializer.Seed(context);
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

using Core.Practice2.Domain.Interfaces;
using Core.Practice2.Service.Commands;
using Core.Practice2.Service.Proxies;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Core.Practice2
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Practice Test", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            
            //services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("AppDB"));
            services.AddMediatR(typeof(UserTokenCommand).GetTypeInfo().Assembly);
            RegisterDIConfig(services);

            services.AddHttpClient<IProductClient, ProductClient>()
               .AddTransientHttpErrorPolicy(
                   p => p.WaitAndRetryAsync(new[]
                   {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10)
                   }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice Test"));
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }

        private static void RegisterDIConfig(IServiceCollection services)
        {
            services.AddTransient<IProductClient, ProductClient>();
        }

    }
}

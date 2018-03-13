using Demo.API.Helpers;
using Demo.API.Middleware;
using Demo.Common.Helpers;
using Demo.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Demo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Helper.ConnectionString = Configuration.GetConnectionString("DemoDatabase");
            SecurityHelper.SecretKey = Configuration.GetValue<string>("SecretKey");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DemoContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DemoDatabase")));
            services.AddCors();
            services.AddMvc().AddJsonOptions(option => option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}

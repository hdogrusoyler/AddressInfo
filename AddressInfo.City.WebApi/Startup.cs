using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressInfo.City.BusinessLogic.Abstract;
using AddressInfo.City.BusinessLogic.Concrete;
using AddressInfo.City.DataAccess.Abstract;
using AddressInfo.City.DataAccess.Concrete.EntityFramework;
using AddressInfo.City.DataAccess.UnitOfWork.Abstract;
using AddressInfo.City.DataAccess.UnitOfWork.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AddressInfo.City.WebApi
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
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection"), b => b.MigrationsAssembly("AddressInfo.City.WebApi"));
            });

            services.AddCors();

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICityDal, EfCityDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

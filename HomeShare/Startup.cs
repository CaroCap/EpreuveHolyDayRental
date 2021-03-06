using HolidayRental.BLL.Entities;
using HolidayRental.BLL.Services;
using HolidayRental.Common.Repositories;
using HolidayRental.DAL.Entities;
using HoliDayRental.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoliDayRental
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
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });      //permet de configurer les sessions pour mon application

            services.AddControllersWithViews();
            
            // INJECTER LES DEPENDANCES ICI POUR QUE LES VUES FONCTIONNENT
            // Injection de dépendance pour la DAL
            services.AddScoped<IBienEchangeRepository<BienEchangeDAL>, HolidayRental.DAL.Repositories.BienEchangeService>();
            services.AddScoped<IMembreRepository<MembreDAL>, HolidayRental.DAL.Repositories.MembreService>();
            services.AddScoped<IPaysRepository<PaysDAL>, HolidayRental.DAL.Repositories.PaysService>();
            // Injection de dépendance pour le BLL
            services.AddScoped<IBienEchangeRepository<BienEchangeBLL>, BienEchangeService>();
            services.AddScoped<IMembreRepository<MembreBLL>, MembreService>();
            services.AddScoped<IPaysRepository<PaysBLL>, PaysService>();

            // Pour Session Manager 
            services.AddHttpContextAccessor();
            services.AddScoped<SessionManager>();

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

            // SESSION
            app.UseSession(); //Permet d'utiliser le middlewate session pour notre application
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

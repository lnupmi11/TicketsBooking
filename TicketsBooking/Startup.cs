using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.BLL.Services;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DAL.UnitOfWork;
using AutoMapper;
using TicketsBooking.DAL.Entities;
using DinkToPdf.Contracts;
using DinkToPdf;

namespace TicketsBooking
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<TicketsBooking.DAL.EntityFramework.TicketsBookingContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<User>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<TicketsBooking.DAL.EntityFramework.TicketsBookingContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IServiceTicket, TicketService>();

            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<IServiceUser, UserService>();

            services.AddScoped(typeof(IUnitOfWork), typeof(TicketsBookingUnitOfWork));

            services.AddTransient<IServiceFlight, FlightService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            
            CreateRoles(services.BuildServiceProvider()).Wait();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Ticket}/{action=Index}/{id?}");
            });

            
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = Enum.GetNames(typeof(Roles));



            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            User user = await UserManager.FindByEmailAsync("admin@admin.com");

            if (user == null)
            {
                user = new User()
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                };
                await UserManager.CreateAsync(user, "Admin@1");
            }
            await UserManager.AddToRoleAsync(user, Roles.Admin.ToString());

            User user1 = await UserManager.FindByEmailAsync("user@user.com");

            if (user1 == null)
            {
                user1 = new User()
                {
                    UserName = "user@user.com",
                    Email = "user@user.com",
                };
                await UserManager.CreateAsync(user1, "User@1");
            }
            await UserManager.AddToRoleAsync(user1, Roles.User.ToString());

            
        }
    }
}

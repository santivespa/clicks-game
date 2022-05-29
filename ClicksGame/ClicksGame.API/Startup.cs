using ClicksGame.API.Hubs;
using ClicksGame.BLL.Controllers;
using ClicksGame.BLL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClicksGame.DAL.Context;
using Microsoft.EntityFrameworkCore;
using ClicksGame.DAL.Interfaces;
using ClicksGame.DAL.Managers;

namespace ClicksGame.API
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


            services.AddDbContext<ClicksGameContext>(b => b.UseSqlServer(Configuration.GetConnectionString("LocalConnectionString"), b => b.MigrationsAssembly("ClicksGame.DAL")));

            services.AddCors();

            services.AddSignalR();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins(Configuration["ApplicationSettings:Client_URL_Prod"].ToString());
            }));


            InjectServices(services);


        }


        private void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IMessagesController, MessagesController>();
            services.AddScoped<IUsersController, UsersController>();
            services.AddScoped<IInvitationsController, InvitationsController>();
            services.AddScoped<IMainCounterController, MainCounterController>();

            services.AddScoped<IRankingController, RankingController>();
            services.AddScoped<IRankingManager, RankingManager>();

            services.AddScoped<IMainCounterManager, MainCounterManager>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ClicksHub>("/mainHub");
            });
         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

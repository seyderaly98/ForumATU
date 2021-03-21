using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumATU.Models;
using ForumATU.Models.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace ForumATU
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ForumContext>(options => options.UseNpgsql(connection).UseLazyLoadingProxies())
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 3; // минимальная длина
                    options.Password.RequireNonAlphanumeric = false; // требуются ли не алфавитно-цифровые символы
                    options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                    options.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                    options.Password.RequireDigit = false; // требуются ли цифры
                })
                .AddEntityFrameworkStores<ForumContext>();
            services.AddControllersWithViews();
            
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

            app.UseAuthentication();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeBook.Data;
using CafeBook.Repositories;
using CafeBook.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalRChat.Hubs;

namespace CafeBook
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CafeBookContext>(options => 
            {
                options.UseSqlite("Filename=cafebook.db"); 
            });
            
            services.AddMvc();
            services.AddSignalR();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<BookService>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<BookTypeService>();
            services.AddScoped<IBookTypeRepository, BookTypeRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                            .AddEntityFrameworkStores<CafeBookContext>();
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute( //
                    "default",    //
                    "{controller=Home}/{action=Index}/{id?}"); //
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}

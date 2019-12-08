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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<BookService>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<BookTypeService>();
            services.AddScoped<IBookTypeRepository, BookTypeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute( //
                    "default",    //
                    "{controller=Users}/{action=Index}/{id?}"); //
            });
        }
    }
}

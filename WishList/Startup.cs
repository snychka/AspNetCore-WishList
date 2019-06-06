using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WishList.Data;

namespace WishList
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("WishList"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/


            //            In the Configure method before UseMvcWithDefaultRoute, 
            //add a condition that checks if env is set to Development 
            //    using the IsDevelopment() method.

            //If Development, it should call UseDeveloperExceptionPage 
            //                                    on app to get better detailed error pages.

            //Otherwise, it should call UseExceptionHandler on app and pass it the argument "/Home/Error".

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}

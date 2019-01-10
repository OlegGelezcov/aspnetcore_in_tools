using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;

namespace MvcFromScratch {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc(options => {
                options.MaxModelValidationErrors = 100;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            /*
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) => {
                await context.Response.WriteAsync("Hello World!");
            });*/

            app.UseMvc(routes => {
                //routes.MapRoute(name: "calc",
                //    template: "calculator/square/{value:int}");
                routes.MapRoute(name: "convert",
                    template: "calculator/convertcurrency/{currencyIn}/{currencyOut}/{qty}",
                    defaults: new {
                        currencyIn = "USD",
                        currencyOut = "RUR",
                        qty = 100
                    },
                    constraints: new {
                        currencyIn = new LengthRouteConstraint(3),
                        currencyOut = new MaxLengthRouteConstraint(3)
                    });

                routes.MapRoute(name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

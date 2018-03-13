using Bottle.InMemory;
using Bottle.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MvcSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddCqrs((c, q) =>
                    {
                        c.UseValidation()
                         .UseInMemory();

                        q.UseValidation()
                         .UseInMemory();
                    })
                    .AddQueryHandlers()
                    .AddCommandHandlers();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Core.Extensions;
using OdeToFood.Data;
using OdeToFood.Data.Repositories;

namespace OdeToFood
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OdeToFoodDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb").Decode());
                });

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, OdeToFoodDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(ExampleMiddleware);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            context.EnsureSeedDataExists();

            app.UseMvc();
        }

        private RequestDelegate ExampleMiddleware(RequestDelegate next)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/Example"))
                {
                    await ctx.Response.WriteAsync("Example Middleware triggered.");
                }
                else
                {
                    await next(ctx);
                }
            };
        }
    }
}

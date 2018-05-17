using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BreadShop.Data.DatabaseContext;
using BreadShop.Data.Repositories.Product;
using BreadShop.Application.Services.Product;
using BreadShop.Application.Services.Stock;
using BreadShop.Data.Repositories.Stock;
using BreadShop.Domain.Repositories;
using BreadShop.WebApi.Configurations;
using IdentityModel;

namespace BreadShop.WebApi
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
            services.AddMvc();
            services.AddCors();
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            OidcConfiguration oidcConfiguration = IdentityServerConfiguration.GetOidcConfiguration();

            services.AddAuthentication(Constant.AuthenticationHeaderPrefix)
                .AddIdentityServerAuthentication(opt =>
                {
                    opt.Authority = "http://localhost:5000";
                    opt.RequireHttpsMetadata = false;
                    opt.RoleClaimType = "role";
                    opt.ApiName = "breadshop";
                });

            DbContextOptions<BreadShopDatabaseContext> options =
                new DbContextOptionsBuilder<BreadShopDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "BreadShopDatabase")
                .Options;

            services.AddSingleton(options).AddScoped<BreadShopDatabaseContext>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductApplicationService, ProductApplicationService>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockApplicationService, StockApplicationService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseCors(
            options => options.WithOrigins("http://example.com").AllowAnyMethod()
    );
            app.UseAuthentication();
            app.UseMvc();
            

            

        }
    }
}

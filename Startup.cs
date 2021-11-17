using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using InventoryService.Contexts;
using InventoryService.Repositories;
using InventoryService.Schemas;
using InventoryService.VaultConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService
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

            services.AddControllers();

            //services.AddDbContext<InventoryServiceContext>
            //  (o => o.UseSqlServer(Configuration
            //  .GetConnectionString("connstring")));
            //External Configuration design pattern
            services.AddDbContext<InventoryServiceContext>(o =>
          o.UseSqlServer(EFConnectionString()));
          
            services.AddScoped<CatalogSchema>();
            services.AddGraphQL()
               .AddSystemTextJson()
               .AddGraphTypes(typeof(CatalogSchema), ServiceLifetime.Scoped);

            services.AddApiVersioning(); 
           services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryService", Version = "v1" });
            });

            services.AddTransient<ICatalogRepository, CatalogRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"v1");
            });
            app.UseGraphQL<CatalogSchema>();
            app.UseGraphQLPlayground(options: new PlaygroundOptions());
           
        }
        public String EFConnectionString()
        {
            Dictionary<String, Object> data = new VaultConnection().GetDBCredentials().Result;

            SqlConnectionStringBuilder providerCs = new SqlConnectionStringBuilder();
            providerCs.InitialCatalog = "IntelInventoryDB";
            providerCs.UserID = data["username"].ToString();
            providerCs.Password = data["password"].ToString();
            providerCs.DataSource = "DESKTOP-55AGI0I\\MSSQLEXPRESS2021";

            //providerCs.UserID = CryptoService2.Decrypt(ConfigurationManager.AppSettings["UserId"]);
            providerCs.MultipleActiveResultSets = true;
            providerCs.TrustServerCertificate = false;



            //ecsb.Provider = "System.Data.SqlClient";
            //ecsb.ProviderConnectionString = providerCs.ToString();

            //ecsb.Metadata = string.Format("res://{0}/EDModel.csdl|res://{0}/EDModel.ssdl|res://{0}/EDModel.msl", typeof(Entities).Assembly.FullName);

            return providerCs.ToString();

        }


    }
}

namespace UniversityBoard.Web
{
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    using UniversityBoard.Web.Configurations;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            var connectionString = this.Configuration.GetConnectionString("DefaultSqlConnectionString");
            var entityFrameworkConnectionString = this.Configuration.GetConnectionString("EntityFrameworkConnectionString");
            var mongoDbconnectionString = this.Configuration.GetConnectionString("MongoDbConnectionString");


            services.ConfigureSqlRepositories(connectionString);                 // Use one!
            // services.ConfigureOrmRepositories(entityFrameworkConnectionString);
            // services.ConfigureNoSqlRepositories(mongoDbconnectionString);

            services.ConfigureBllServices();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "UniversityBoard API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "UniversityBoard.Web.xml");
                c.IncludeXmlComments(filePath);
            });
        }
        

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseStatusCodePages();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "api/swagger";
            });
        }
    }
}

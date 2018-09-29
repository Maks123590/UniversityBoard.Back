namespace UniversityBoard.Web
{
    using System.Data;
    using System.Data.Common;
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using MySql.Data.MySqlClient;

    using Swashbuckle.AspNetCore.Swagger;

    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.BLL.Services;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.SQL.Repositories;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            var connectionString = this.Configuration.GetConnectionString("DefaultSqlConnectionString");

            services.AddSingleton<IDbConnection, DbConnection>(provider => new MySqlConnection(connectionString));

            services.AddTransient<IStudentRepository, StudentsRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IStudentCardRepository, StudentCardsRepository>();
            services.AddTransient<IEducationalDirectionRepository, EducationalDirectionRepository>();
            services.AddTransient<IExamInfoRepository, ExamInfoRepository>();
            services.AddTransient<IAcademicDisciplineRepository, AcademicDisciplineRepository>();

            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<IGroupServices, GroupServices>();
            services.AddTransient<IStudentCardServices, StudentCardServices>();
            services.AddTransient<IExamInfoServices, ExamInfoServices>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "UniversityBoard API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "UniversityBoard.Web.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseHsts();
            }


            app.UseCors(
                options => options.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials()
            );

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

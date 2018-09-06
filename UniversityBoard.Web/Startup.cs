using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace UniversityBoard.Back
{
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    using MySql.Data.MySqlClient;

    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.BLL.Services;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.SQL.Repositories;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = @"server=localhost;user=root;database=batunin_402_user;SslMode=none";

            services.AddSingleton<IDbConnection, DbConnection>(provider => new MySqlConnection(connectionString));

            services.AddTransient<IStudentRepository, StudentsRepository>();
            services.AddTransient<IStudentServices, StudentServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

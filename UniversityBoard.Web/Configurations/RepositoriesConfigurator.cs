namespace UniversityBoard.Web.Configurations
{
    using System;
    using System.Data;
    using System.Data.Common;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using MongoDB.Driver;

    using MySql.Data.MySqlClient;
    using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.ORM;
    using UniversityBoard.DAL.ORM.Repositories;
    using UniversityBoard.DAL.SQL.Repositories;

    public static class RepositoriesConfigurator
    {
        public static void ConfigureSqlRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDbConnection, DbConnection>(provider => new MySqlConnection(connectionString));

            services.AddTransient<IStudentRepository, StudentsRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IEducationalDirectionRepository, EducationalDirectionRepository>();
            services.AddTransient<IExamInfoRepository, ExamInfoRepository>();
            services.AddTransient<IAcademicDisciplineRepository, AcademicDisciplineRepository>();
            services.AddTransient<IAcademicDepartamentRepository, AcademicDepartamentsRepository>();
            services.AddTransient<IAttestationRepository, AttestationRepository>();
        }

        public static void ConfigureOrmRepositories(this IServiceCollection services, string connectionString)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            //var options = optionsBuilder.UseMySql(
            //    connectionString,
            //    mysqlOptions => { mysqlOptions.ServerVersion(new Version(5, 5, 17), ServerType.MySql); }).Options;

            // services.AddTransient<DbContext, ApplicationContext>(provider => new ApplicationContext(options));

            services.AddEntityFrameworkMySql().AddDbContext<ApplicationContext>(
                options =>
                    {
                        options.UseMySql(connectionString, builder => builder.ServerVersion(new Version(5, 5, 17), ServerType.MySql));
                    },
                ServiceLifetime.Transient);

            services.AddTransient<DbContext, ApplicationContext>();

            services.AddTransient<IStudentRepository, StudentOrmRepository>();
            services.AddTransient<IGroupRepository, GroupOrmRepository>();
            services.AddTransient<IEducationalDirectionRepository, EducationalDiresctionOrmRepository>();
            services.AddTransient<IExamInfoRepository, ExamInfoOrmRepository>();
            services.AddTransient<IAcademicDisciplineRepository, AcademicDisciplineOrmRepository>();
            services.AddTransient<IAttestationRepository, AttestationOrmRepository>();
            services.AddTransient<IAcademicDepartamentRepository, AcademicDepartamentsOrmRepository>();
        }

        public static void ConfigureNoSqlRepositories(this IServiceCollection services, string connectionString)
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase("test");
        }
    }
}
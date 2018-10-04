namespace UniversityBoard.Web.Configurations
{
    using System;
    using System.Data;
    using System.Data.Common;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<IStudentCardRepository, StudentCardsRepository>();
            services.AddTransient<IEducationalDirectionRepository, EducationalDirectionRepository>();
            services.AddTransient<IExamInfoRepository, ExamInfoRepository>();
            services.AddTransient<IAcademicDisciplineRepository, AcademicDisciplineRepository>();

        }

        public static void ConfigureOrmRepositories(this IServiceCollection services, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var options = optionsBuilder.UseMySql(
                connectionString,
                mysqlOptions => { mysqlOptions.ServerVersion(new Version(5, 5, 17), ServerType.MySql); }).Options;

            services.AddTransient<DbContext, ApplicationContext>(provider => new ApplicationContext(options));
            

            services.AddTransient<IStudentRepository, StudentOrmRepository>();
            services.AddTransient<IGroupRepository, GroupOrmRepository>();
            services.AddTransient<IStudentCardRepository, StudentCardOrmRepository>();
            services.AddTransient<IEducationalDirectionRepository, EducationalDiresctionOrmRepository>();
            services.AddTransient<IExamInfoRepository, ExamInfoOrmRepository>();
            services.AddTransient<IAcademicDisciplineRepository, AcademicDisciplineOrmRepository>();
        }

        public static void ConfigureNoSqlRepositories(this IServiceCollection services, string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
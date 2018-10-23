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
    using UniversityBoard.DAL.Common.Models;
    using UniversityBoard.DAL.NoSQL.Repositories;
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

            IMongoDatabase database = client.GetDatabase("batunin_402_users_onsql");

            services.AddTransient<IMongoCollection<Student>>(provider => database.GetCollection<Student>("students"));
            services.AddTransient<IMongoCollection<Group>>(provider => database.GetCollection<Group>("groups"));
            services.AddTransient<IMongoCollection<EducationalDirection>>(provider => database.GetCollection<EducationalDirection>("educationalDirections"));
            services.AddTransient<IMongoCollection<ExamInfo>>(provider => database.GetCollection<ExamInfo>("examInfos"));
            services.AddTransient<IMongoCollection<AcademicDiscipline>>(provider => database.GetCollection<AcademicDiscipline>("academicDisciplines"));
            services.AddTransient<IMongoCollection<Attestation>>(provider => database.GetCollection<Attestation>("attestations"));
            services.AddTransient<IMongoCollection<AcademicDepartament>>(provider => database.GetCollection<AcademicDepartament>("academicDepartaments"));
            

            services.AddTransient<IStudentRepository, StudentNoSqlRepository>();
            services.AddTransient<IGroupRepository, GroupNoSqlRepository>();
            services.AddTransient<IEducationalDirectionRepository, EducationalDirectionNoSqlRepository>();
            services.AddTransient<IExamInfoRepository, ExamInfoNoSqlRepository>();
            services.AddTransient<IAcademicDisciplineRepository, AcademicDisciplineNoSqlRepository>();
            services.AddTransient<IAttestationRepository, AttestationNoSqlRepository>();
            services.AddTransient<IAcademicDepartamentRepository, AcademicDepartamentNoSqlRepository>();

        }
    }
}
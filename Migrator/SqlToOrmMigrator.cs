namespace Migrator
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Microsoft.EntityFrameworkCore;

    using MySql.Data.MySqlClient;

    using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.ORM;
    using UniversityBoard.DAL.ORM.Repositories;
    using UniversityBoard.DAL.SQL.Repositories;

    public class SqlToOrmMigrator : IDisposable
    {
        private readonly IDbConnection sqlConnection;
        private readonly ApplicationContext ormContext;

        public SqlToOrmMigrator(string sqlConnectionString, string ormConnectionString)
        {
            this.sqlConnection = new MySqlConnection(sqlConnectionString);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var options = optionsBuilder.UseMySql(
                ormConnectionString,
                mysqlOptions => { mysqlOptions.ServerVersion(new Version(5, 5, 17), ServerType.MySql); }).Options;

            this.ormContext = new ApplicationContext(options);
        }

        public void MigrateSqlDbToOrmDb()
        {
            this.MigrateAcademicDepartaments().Wait();
            this.MigrateAcademicDisciplines().Wait();
            this.MigrateEducationalDirections().Wait();
        }

        public void Dispose()
        {
            this.sqlConnection?.Dispose();
            this.ormContext?.Dispose();
        }

        private async Task MigrateAcademicDepartaments()
        {
            var academicDepartamentSqlRepository = new AcademicDepartamentsRepository(this.sqlConnection);
            var academicDepartamentOrmRepository = new AcademicDepartamentsOrmRepository(this.ormContext);

            var academicDepartaments = (await academicDepartamentSqlRepository.GetAll()).ToList();

            for (var i = 0; i < academicDepartaments.Count; i++)
            {
                await academicDepartamentOrmRepository.Create(academicDepartaments[i]);
                Console.WriteLine($"academicDepartaments {i + 1} / {academicDepartaments.Count}");
            }
        }

        private async Task MigrateAcademicDisciplines()
        {
            var academicDisciplinesSqlRepository = new AcademicDisciplineRepository(this.sqlConnection);
            var academicDisciplinesOrmRepository = new AcademicDisciplineOrmRepository(this.ormContext);

            var academicDisciplines = (await academicDisciplinesSqlRepository.GetAll()).ToList();

            for (var i = 0; i < academicDisciplines.Count; i++)
            {
                await academicDisciplinesOrmRepository.Create(academicDisciplines[i]);
                Console.WriteLine($"academicDisciplines {i + 1} / {academicDisciplines.Count}");
            }
        }

        private async Task MigrateEducationalDirections()
        {
            var educationalDirectionsSqlRepository = new EducationalDirectionRepository(this.sqlConnection);
            var educationalDirectionsOrmRepository = new EducationalDiresctionOrmRepository(this.ormContext);

            var academicDisciplines = (await educationalDirectionsSqlRepository.GetAll()).ToList();

            for (var i = 0; i < academicDisciplines.Count; i++)
            {
                await educationalDirectionsOrmRepository.Create(academicDisciplines[i]);
                Console.WriteLine($"educationalDirections {i + 1} / {academicDisciplines.Count}");
            }
        }
    }
}
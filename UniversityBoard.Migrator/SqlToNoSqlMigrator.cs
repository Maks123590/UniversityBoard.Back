namespace UniversityBoard.Migrator
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using MySql.Data.MySqlClient;

    using UniversityBoard.DAL.Common.Models;
    using UniversityBoard.DAL.NoSQL.Repositories;
    using UniversityBoard.DAL.SQL.Repositories;

    public class SqlToNoSqlMigrator : IDisposable
    {
        private readonly IDbConnection sqlConnection;

        private readonly IMongoCollection<EducationalDirection> educationalDirectionsCollection;
        private readonly IMongoCollection<AcademicDiscipline> academicDisciplinesCollection;
        private readonly IMongoCollection<AcademicDepartament> academicDepartamentsCollection;



        public SqlToNoSqlMigrator(string sqlConnectionString, string noSqlConnectionString)
        {
            this.sqlConnection = new MySqlConnection(sqlConnectionString);

            MongoClient client = new MongoClient(noSqlConnectionString);

            IMongoDatabase database = client.GetDatabase("batunin_402_users_onsql");

            this.educationalDirectionsCollection = database.GetCollection<EducationalDirection>("educationalDirections");
            this.academicDisciplinesCollection = database.GetCollection<AcademicDiscipline>("academicDisciplines");
            this.academicDepartamentsCollection = database.GetCollection<AcademicDepartament>("academicDepartaments");
        }

        public void MigrateSqlDbToNoSqlDb()
        {
            this.MigrateAcademicDepartaments().Wait();
            this.MigrateAcademicDisciplines().Wait();
            this.MigrateEducationalDirections().Wait();
        }

        public void Dispose()
        {
            this.sqlConnection?.Dispose();
        }

        private async Task MigrateAcademicDepartaments()
        {
            var academicDepartamentSqlRepository = new AcademicDepartamentsRepository(this.sqlConnection);
            var academicDepartamentOrmRepository = new AcademicDepartamentNoSqlRepository(this.academicDepartamentsCollection);

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
            var academicDisciplinesOrmRepository = new AcademicDisciplineNoSqlRepository(this.academicDisciplinesCollection);

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
            var educationalDirectionsOrmRepository = new EducationalDirectionNoSqlRepository(this.educationalDirectionsCollection);

            var academicDisciplines = (await educationalDirectionsSqlRepository.GetAll()).ToList();

            for (var i = 0; i < academicDisciplines.Count; i++)
            {
                await educationalDirectionsOrmRepository.Create(academicDisciplines[i]);
                Console.WriteLine($"educationalDirections {i + 1} / {academicDisciplines.Count}");
            }
        }
    }
}
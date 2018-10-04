namespace UniversityBoard.DAL.ORM
{
    using Microsoft.EntityFrameworkCore;
    using UniversityBoard.DAL.Common.Models;

    public sealed class ApplicationContext : DbContext
    {
        public DbSet<AcademicDepartament> AcademicDepartaments { get; set; }

        public DbSet<AcademicDiscipline> AcademicDisciplines { get; set; }

        public DbSet<EducationalDirection> EducationalDirections { get; set; }

        public DbSet<ExamInfo> ExamInfos { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCard> StudentCards { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            :base(options)
        {
            Database.EnsureCreated();
        }

    }
}
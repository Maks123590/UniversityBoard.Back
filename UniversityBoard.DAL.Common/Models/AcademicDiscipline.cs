namespace UniversityBoard.DAL.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AcademicDiscipline
    {
        [Key]
        public string DisciplineCode { get; set; }

        public string Name { get; set; }

        public int AcademicDepartamentCode { get; set; }
    }
}
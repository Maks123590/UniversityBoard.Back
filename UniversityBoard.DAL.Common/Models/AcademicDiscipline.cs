using System.ComponentModel.DataAnnotations;

namespace UniversityBoard.DAL.Common.Models
{
    public class AcademicDiscipline
    {
        [Key]
        public string DisciplineCode { get; set; }

        public string Name { get; set; }

        public int AcademicDepartamentCode { get; set; }
    }
}
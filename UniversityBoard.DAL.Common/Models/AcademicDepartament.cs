namespace UniversityBoard.DAL.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AcademicDepartament
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; }
    }
}
namespace UniversityBoard.DAL.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EducationalDirection
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
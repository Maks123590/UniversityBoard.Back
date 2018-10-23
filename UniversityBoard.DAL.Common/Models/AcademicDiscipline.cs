namespace UniversityBoard.DAL.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    using MongoDB.Bson.Serialization.Attributes;

    public class AcademicDiscipline
    {
        [Key]
        [BsonId]
        public string DisciplineCode { get; set; }

        public string Name { get; set; }

        public int AcademicDepartamentCode { get; set; }
    }
}
namespace UniversityBoard.DAL.Common.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using MongoDB.Bson.Serialization.Attributes;

    public class AcademicDepartament
    {
        [Key]
        [BsonId]
        public int Code { get; set; }

        public string Name { get; set; }
    }
}
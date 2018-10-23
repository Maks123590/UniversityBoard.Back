namespace UniversityBoard.DAL.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    using MongoDB.Bson.Serialization.Attributes;

    public class EducationalDirection
    {
        [Key]
        [BsonId]
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
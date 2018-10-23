namespace UniversityBoard.DAL.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MongoDB.Bson.Serialization.Attributes;

    public class ExamInfo
    {
        [Key]
        [BsonId]
        public int Id { get; set; }

        public int AttestationId { get; set; }

        public DateTime Date { get; set; }

        public int StudentId { get; set; }

        public int Score { get; set; }

        public int Level { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(AttestationId))]
        public Attestation Attestation { get; set; }
    }
}
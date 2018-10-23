namespace UniversityBoard.DAL.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MongoDB.Bson.Serialization.Attributes;

    using UniversityBoard.DAL.Common.Enums;

    public class Attestation
    {
        [Key]
        [BsonId]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string AcademicDisciplineCode { get; set; }

        public int GroupId { get; set; }

        public int HoursCount { get; set; }

        public AttestationType AppraisalType { get; set; }

        [ForeignKey(nameof(AcademicDisciplineCode))]
        public AcademicDiscipline AcademicDiscipline { get; set; }

        public IEnumerable<ExamInfo> ExamInfos { get; set; }

        public Group Group { get; set; }
    }
}
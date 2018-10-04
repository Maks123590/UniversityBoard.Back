namespace UniversityBoard.DAL.Common.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Number { get; set; }

        public int? HeadId { get; set; }

        public DateTime FormationDate { get; set; }

        [NotMapped]
        public int StudentsCount { get; set; }

        public string EducationalDirectionCode { get; set; }

        [ForeignKey(nameof(HeadId))]
        public Student Head { get; set; }

        [ForeignKey(nameof(EducationalDirectionCode))]
        public EducationalDirection EducationalDirection { get; set; }

        [NotMapped]
        public IEnumerable<Student> Students { get; set; }
    }
}
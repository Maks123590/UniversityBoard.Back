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

        public int HeadId { get; set; }

        public DateTime FormationDate { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public int StudentsCount { get; set; }

        public string EducationalDirectionCode { get; set; }

        [NotMapped]
        public Student Head { get; set; }

        [NotMapped]
        public EducationalDirection EducationalDirection { get; set; }
    }
}
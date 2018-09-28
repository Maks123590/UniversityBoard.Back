namespace UniversityBoard.DAL.Common.Models
{
    using System;
    using System.Collections.Generic;

    public class Group
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public int HeadId { get; set; }

        public Student Head { get; set; }

        public DateTime FormationDate { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public int StudentsCount { get; set; }

        public string EducationalDirectionCode { get; set; }

        public EducationalDirection EducationalDirection { get; set; }
    }
}
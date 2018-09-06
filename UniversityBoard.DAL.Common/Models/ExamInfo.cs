namespace UniversityBoard.DAL.Common.Models
{
    using System;

    public class ExamInfo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int AcademicDisciplineCode { get; set; }

        public int StudentId { get; set; }

        public int Score { get; set; }

        public int Level { get; set; }
    }
}
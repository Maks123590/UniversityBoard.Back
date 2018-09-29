namespace UniversityBoard.DAL.Common.Models
{
    using System;

    public class ExamInfo
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string AcademicDisciplineCode { get; set; }

        public int GroupId { get; set; }

        public int StudentId { get; set; }

        public int Score { get; set; }

        public int Level { get; set; }

        public bool SetOff { get; set; }

        public int HoursCount { get; set; }

        public int AppraisalType { get; set; }

        public AcademicDiscipline AcademicDiscipline { get; set; }
    }
}
namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    using System;

    public class ExamInfoBaseDto
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
    }
}
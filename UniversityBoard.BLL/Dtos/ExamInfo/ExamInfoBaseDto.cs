namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    using System;

    public class ExamInfoBaseDto
    {
        public int Id { get; set; }

        public int AttestationId { get; set; }

        public DateTime Date { get; set; }

        public int StudentId { get; set; }

        public int Score { get; set; }

        public int Level { get; set; }
    }
}
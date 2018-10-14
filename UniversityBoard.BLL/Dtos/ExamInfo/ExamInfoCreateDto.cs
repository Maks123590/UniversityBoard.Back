namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    using System;

    public class ExamInfoCreateDto
    {
        public int AttestationId { get; set; }

        public DateTime Date { get; set; }

        public int StudentId { get; set; }

        public int Score { get; set; }
    }
}
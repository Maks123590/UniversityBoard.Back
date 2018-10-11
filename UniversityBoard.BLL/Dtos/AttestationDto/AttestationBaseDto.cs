namespace UniversityBoard.BLL.Dtos.AttestationDto
{
    using System;

    using UniversityBoard.DAL.Common.Enums;

    public class AttestationBaseDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string AcademicDisciplineCode { get; set; }

        public int GroupId { get; set; }

        public int HoursCount { get; set; }

        public AttestationType AppraisalType { get; set; }
    }
}
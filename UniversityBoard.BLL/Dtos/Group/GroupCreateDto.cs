namespace UniversityBoard.BLL.Dtos.Group
{
    using System;

    public class GroupCreateDto
    {
        public string Number { get; set; }

        public int? HeadId { get; set; }

        public DateTime FormationDate { get; set; }

        public string EducationalDirectionCode { get; set; }
    }
}
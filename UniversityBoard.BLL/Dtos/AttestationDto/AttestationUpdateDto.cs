namespace UniversityBoard.BLL.Dtos.AttestationDto
{
    using System;

    using UniversityBoard.DAL.Common.Enums;

    public class AttestationUpdateDto : AttestationCreateDto
    {
        public int Id { get; set; }
    }
}
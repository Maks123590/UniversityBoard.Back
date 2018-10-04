namespace UniversityBoard.BLL.Dtos.Group
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using UniversityBoard.BLL.Dtos.EducationalDirection;
    using UniversityBoard.BLL.Dtos.Student;

    public class GroupDto : GroupBaseDto
    {
        public IEnumerable<StudentBaseDto> Students { get; set; }

        public StudentDto Head { get; set; }

        public int StudentsCount { get; set; }

        public EducationalDirectionDto EducationalDirection { get; set; }
    }
}
namespace UniversityBoard.BLL.Dtos.Group
{
    using System.Collections.Generic;

    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.BLL.Dtos.EducationalDirection;

    public class GroupDto : GroupBaseDto
    {
        public IEnumerable<StudentBaseDto> Students { get; set; }

        public StudentDto Head { get; set; }

        public int StudentsCount { get; set; }

        public EducationalDirectionDto EducationalDirection { get; set; }
    }
}
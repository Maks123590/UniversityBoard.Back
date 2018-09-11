namespace UniversityBoard.BLL.Dtos.Student
{
    using UniversityBoard.BLL.Dtos.Group;
    using UniversityBoard.BLL.Dtos.StudentCard;

    public class StudentDto : StudentBaseDto
    {
        public GroupBaseDto Group { get; set; }

        public StudentCardBaseDto StudentCard { get; set; }
    }
}
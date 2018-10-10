namespace UniversityBoard.BLL.Dtos.Student
{
    using UniversityBoard.BLL.Dtos.Group;

    public class StudentDto : StudentBaseDto
    {
        public GroupBaseDto Group { get; set; }
    }
}
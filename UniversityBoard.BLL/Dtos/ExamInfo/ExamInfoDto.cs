namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.BLL.Dtos.Student;

    public class ExamInfoDto : ExamInfoBaseDto
    {
        public StudentBaseDto Student { get; set; }

        public AcademicDisciplineDto AcademicDiscipline { get; set; }
    }
}
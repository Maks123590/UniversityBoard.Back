namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.DAL.Common.Enums;

    public class ExamInfoDto : ExamInfoBaseDto
    {
        public StudentBaseDto Student { get; set; }

        public AcademicDisciplineDto AcademicDiscipline { get; set; }

        public AttestationType AppraisalType { get; set; }
    }
}
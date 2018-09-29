using UniversityBoard.BLL.Dtos.AcademicDiscipline;

namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    public class ExamInfoDto : ExamInfoBaseDto
    {
        public AcademicDisciplineDto AcademicDiscipline { get; set; }
    }
}
namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    using System.Collections.Generic;

    using UniversityBoard.BLL.Dtos.Student;

    public class OneStudentExamInfosDto
    {
        public StudentBaseDto Student { get; set; }

        public IEnumerable<ExamInfoDto> ExamInfoList { get; set; }
    }
}
namespace UniversityBoard.BLL.Dtos.AttestationDto
{
    using System.Collections.Generic;

    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.BLL.Dtos.ExamInfo;
    using UniversityBoard.BLL.Dtos.Group;

    public class AttestationDto : AttestationBaseDto
    {
        public AcademicDisciplineBaseDto AcademicDiscipline { get; set; }

        public IEnumerable<ExamInfoBaseDto> ExamInfos { get; set; }
        
        public GroupBaseDto Group { get; set; }

        public IEnumerable<KeyValuePair<string, int>> ScoreStatistics { get; set; }
    }
}
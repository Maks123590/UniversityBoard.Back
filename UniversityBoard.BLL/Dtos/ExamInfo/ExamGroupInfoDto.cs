using System.Collections.Generic;
using UniversityBoard.BLL.Dtos.Group;

namespace UniversityBoard.BLL.Dtos.ExamInfo
{
    public class ExamGroupInfoDto
    {
        public IEnumerable<ExamInfoDto> ExamInfos { get; set; }

        public GroupBaseDto Group { get; set; }

        public IEnumerable<KeyValuePair<string, int>> ScoreStatistics { get; set; }
    }
}
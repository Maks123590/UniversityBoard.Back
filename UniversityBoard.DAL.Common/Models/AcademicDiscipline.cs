namespace UniversityBoard.DAL.Common.Models
{
    public class AcademicDiscipline
    {
        public int DisciplineCode { get; set; }

        public string Name { get; set; }

        public int EducationalDirectionCode { get; set; }

        public int HoursCount { get; set; }

        public int AppraisalType { get; set; }
    }
}
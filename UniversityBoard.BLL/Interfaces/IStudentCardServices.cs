namespace UniversityBoard.BLL.Interfaces
{
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.StudentCard;

    public interface IStudentCardServices
    {
        Task<StudentCardDto> GetStudentCard(int number);

        Task<StudentCardDto> CreateStudentCard(StudentCardDto studentCard);

        Task DeleteCard(int number);
    }
}
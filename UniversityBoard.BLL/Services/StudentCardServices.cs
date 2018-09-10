namespace UniversityBoard.BLL.Services
{
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.StudentCard;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class StudentCardServices : IStudentCardServices
    {
        private readonly IStudentCardRepository studentCardRepository;

        public StudentCardServices(IStudentCardRepository studentCardRepository)
        {
            this.studentCardRepository = studentCardRepository;
        }

        public async Task<StudentCardDto> GetStudentCard(int number)
        {
            var studentCard = await this.studentCardRepository.Get(number);

            return studentCard.Adapt<StudentCardDto>();
        }

        public async Task<StudentCardDto> CreateStudentCard(StudentCardDto studentCard)
        {
            var studentCardModel = studentCard.Adapt<StudentCard>();

            var newStudetnCard = await this.studentCardRepository.Create(studentCardModel);

            return newStudetnCard.Adapt<StudentCardDto>();
        }

        public async Task DeleteCard(int number)
        {
            await this.studentCardRepository.Delete(number);
        }
    }
}
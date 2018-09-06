namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    using Mapster;

    using UniversityBoard.BLL.Dtos;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;

    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var students = await this.studentRepository.GetAll();

            return students.Adapt<IEnumerable<StudentDto>>();
        }
    }
}
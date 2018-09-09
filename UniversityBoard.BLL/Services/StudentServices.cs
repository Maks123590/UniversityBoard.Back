namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    using Mapster;

    using UniversityBoard.BLL.Dtos;
    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

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

        public async Task<StudentDto> Get(int id)
        {
            var student = await this.studentRepository.Get(id);

            return student.Adapt<StudentDto>();
        }

        public async Task<StudentDto> Create(StudentCreateDto student)
        {
            var studentModel = student.Adapt<Student>();

            var newStudent = await this.studentRepository.Create(studentModel);

            return newStudent.Adapt<StudentDto>();
        }

        public async Task<StudentDto> Update(StudentUpdateDto student)
        {
            var studentModel = student.Adapt<Student>();

            var updatedStudent = await this.studentRepository.Update(studentModel);

            return updatedStudent.Adapt<StudentDto>();
        }

        public async Task Delete(int id)
        {
            await this.studentRepository.Delete(id);
        }
    }
}
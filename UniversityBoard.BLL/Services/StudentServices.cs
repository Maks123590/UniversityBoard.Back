namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    using Mapster;

    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository studentRepository;
        private readonly IGroupRepository groupRepository;

        public StudentServices(IStudentRepository studentRepository, IGroupRepository groupRepository)
        {
            this.studentRepository = studentRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudents()
        {
            var students = await this.studentRepository.GetAll();
            
            foreach (var student in students)
            {
                await this.AddRelatedEntities(student);
            }

            return students.Adapt<IEnumerable<StudentDto>>();
        }

        public async Task<IEnumerable<StudentDto>> GetByGroup(int id)
        {
            return (await this.studentRepository.GetByGroupId(id)).Adapt<IEnumerable<StudentDto>>();
        }

        public async Task<StudentDto> Get(int id)
        {
            var student = await this.studentRepository.Get(id);

            await this.AddRelatedEntities(student);

            return student.Adapt<StudentDto>();
        }

        public async Task<StudentDto> Create(StudentCreateDto student)
        {
            var studentModel = student.Adapt<Student>();

            var newStudent = await this.studentRepository.Create(studentModel);

            await this.AddRelatedEntities(newStudent);

            return newStudent.Adapt<StudentDto>();
        }

        public async Task<StudentDto> Update(StudentUpdateDto student)
        {
            var studentModel = student.Adapt<Student>();
            
            var updatedStudent = await this.studentRepository.Update(studentModel);

            await this.AddRelatedEntities(updatedStudent);

            return updatedStudent.Adapt<StudentDto>();
        }

        public async Task Delete(int id)
        {
            await this.studentRepository.Delete(id);
        }

        public async Task AddRelatedEntities(Student student)
        {
            student.Group = await this.groupRepository.Get(student.GroupId);
        }
    }
}
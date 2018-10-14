namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos;
    using UniversityBoard.BLL.Dtos.Student;

    public interface IStudentServices
    {
        Task<IEnumerable<StudentDto>> GetAllStudents();

        Task<IEnumerable<StudentDto>> GetByGroup(int id);

        Task<StudentDto> Get(int id);

        Task<StudentDto> Create(StudentCreateDto student);

        Task<StudentDto> Update(StudentUpdateDto student);

        Task Delete(int id);
    }
}
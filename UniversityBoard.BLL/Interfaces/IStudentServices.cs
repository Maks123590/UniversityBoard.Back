namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos;

    public interface IStudentServices
    {
        Task<IEnumerable<StudentDto>> GetAllStudents();
    }
}
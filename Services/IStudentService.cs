using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetOne(Guid id);
        Task<Student> CreateStudent(CreateStudentDto dto);
        Task<Student> UpdateStudent(UpdateStudentDto dto, Guid id);
        Task DeleteStudent(Guid id);
    }
}
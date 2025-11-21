using Security.Models;

namespace Security.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetOne(Guid id);
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Student student);
    }
}
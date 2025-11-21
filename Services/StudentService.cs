using Security.Models;
using Security.Models.DTOS;
using Security.Repositories;

namespace Security.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo) => _repo = repo;

        public async Task<Student> CreateStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EnrollmentDate = dto.EnrollmentDate,
                Major = dto.Major
            };
            await _repo.Add(student);
            return student;
        }

        public async Task<IEnumerable<Student>> GetAll() => await _repo.GetAll();

        public async Task<Student?> GetOne(Guid id) => await _repo.GetOne(id);

        public async Task<Student> UpdateStudent(UpdateStudentDto dto, Guid id)
        {
            Student? student = await GetOne(id);
            if (student == null) throw new Exception("Student not found.");

            student.FirstName = dto.FirstName ?? student.FirstName;
            student.LastName = dto.LastName ?? student.LastName;
            student.Major = dto.Major ?? student.Major;

            await _repo.Update(student);
            return student;
        }

        public async Task DeleteStudent(Guid id)
        {
            Student? student = await GetOne(id);
            if (student == null) return;
            await _repo.Delete(student);
        }
    }
}
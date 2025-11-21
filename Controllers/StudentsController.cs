using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Models;
using Security.Models.DTOS;
using Security.Services;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize] //  Todos los endpoints requieren un usuario logueado
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/v1/Student (Solo requiere autenticación)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> items = await _service.GetAll();
            return Ok(items);
        }

        // GET: api/v1/Student/GUID (Solo requiere autenticación)
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var student = await _service.GetOne(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // POST: api/v1/Student (Requiere rol de Admin)
        [HttpPost]
        [Authorize(Policy = "AdminOnly")] // Autorización por Rol
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var student = await _service.CreateStudent(dto);
            return CreatedAtAction(nameof(GetOne), new { id = student.Id }, student);
        }

        // PUT: api/v1/Student/GUID (Solo requiere autenticación)
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto dto, Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var student = await _service.UpdateStudent(dto, id);
            return CreatedAtAction(nameof(GetOne), new { id = student.Id }, student);
        }

        // DELETE: api/v1/Student/GUID (Requiere rol de Admin)
        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")] // Autorización por Rol
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.DeleteStudent(id);
            return NoContent();
        }
    }
}
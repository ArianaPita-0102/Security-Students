using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record CreateStudentDto
    {
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        public required DateTime EnrollmentDate { get; init; } = DateTime.UtcNow;
        public required string Major { get; init; }
    }
}
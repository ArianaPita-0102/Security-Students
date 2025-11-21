namespace Security.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime EnrollmentDate { get; set; } //Fecha de inscripción
        public required string Major { get; set; }
    }
}
namespace Security.Models.DTOS
{
    public record UpdateStudentDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Major { get; set; }
    }
}
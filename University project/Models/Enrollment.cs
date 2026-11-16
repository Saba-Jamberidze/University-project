namespace University_project.Models;

/// <summary>მოსწავლის ჩარიცხვა კურსზე (მოსწავლე-კურსის კავშირი).</summary>
internal class Enrollment
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Enrollment(Guid courseId, Guid studentId)
    {
        CourseId = courseId;
        StudentId = studentId;
    }
}
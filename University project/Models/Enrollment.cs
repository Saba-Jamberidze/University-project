namespace University_project.Models;

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
using University_project.Models;

namespace University_project.Services;

/// <summary>კურსებთან და ჩარიცხვებთან მუშაობა.</summary>
internal class CourseService
{
    private readonly List<Course> courses = new();
    private readonly List<Enrollment> enrollments = new();

    /// <summary>მოსწავლის აქტიური კურსები.</summary>
    public IEnumerable<Course> GetActiveCoursesForStudent(Guid studentId) =>
        enrollments.Where(e => e.StudentId == studentId)
                   .Select(e => courses.First(c => c.Id == e.CourseId))
                   .Where(c => c.IsActive);
    public IEnumerable<Course> GetActiveCoursesForTeacher(Guid teacherId) =>
        courses.Where(c => c.TeacherId == teacherId && c.IsActive);
}

using University_project.Models;

namespace University_project.Services;

/// <summary>კურსებთან და ჩარიცხვებთან მუშაობა.</summary>
internal class CourseService
{
    private readonly List<Course> courses = new();
    private readonly List<Enrollment> enrollments = new();

    /// <summary>ამატებს კურსს სიაში.</summary>
    public void AddCourse(Course course) => courses.Add(course);

    /// <summary>ჩარიცხავს მოსწავლეს კურსზე (დუბლირების გარეშე).</summary>
    public void Enroll(Guid studentId, Guid courseId)
    {
        if (!enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId))
            enrollments.Add(new Enrollment(studentId, courseId));
    }

    /// <summary>მოსწავლის აქტიური კურსები.</summary>
    public IEnumerable<Course> GetActiveCoursesForStudent(Guid studentId) =>
    enrollments.Where(e => e.StudentId == studentId)
               .Select(e => courses.FirstOrDefault(c => c.Id == e.CourseId))
               .OfType<Course>() // ნულიფიცირებული კურსების გამორიცხვა
               .Where(c => c.IsActive);

    /// <summary>ლექტორის აქტიური კურსები.</summary>
    public IEnumerable<Course> GetActiveCoursesForTeacher(Guid teacherId) =>
        courses.Where(c => c.TeacherId == teacherId && c.IsActive);
}

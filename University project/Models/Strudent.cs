namespace University_project.Models;
internal class Strudent : User
{
    public string Role { get; init; } = "student";
    public Course CourseName { get; set; }
    public DateOnly CourseStartDate { get; set; }
    public DateOnly CourseEndDate { get; set; }
    public string CourseDuration { get; set; }
    public string courseStatus { get; set; }

}
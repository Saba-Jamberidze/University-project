namespace University_project.Models;

internal class Student : User
{
    public string Role { get; init; } = "student";

    public Course? Course { get; private set; }
    public DateOnly? StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public string Status { get; set; } = "Active";

    public Student(string name,
                   string lastName,
                   DateOnly birthDate,
                   string username,
                   string password,
                   string email)
        : base(name, lastName, birthDate, username, password, email)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        Username = username;
        Password = password;
        Email = email;
    }

    public void ChooseCourse(Course course, DateOnly startDate)
    {
        Course = course;
        StartDate = startDate;
        EndDate = startDate.AddMonths(course.DurationMonths);
    }
}
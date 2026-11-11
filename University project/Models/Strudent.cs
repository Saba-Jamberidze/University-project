namespace University_project.Models;

internal class Student : User
{
    public string Role { get; init; } = "student";

    public Course? StudyCours { get; private set; }
    public DateOnly? StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public string Status { get; set; } = "Active";

    public Student(string name,
                   string lastName,
                   DateOnly birthDate,
                   string username,
                   string passwordHash,
                   string email)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
    }

    public void ChooseCourse(Course course, DateOnly startDate)
    {
        StudyCours = course;
        StartDate = startDate;
        EndDate = startDate.AddMonths(course.DurationMonths);
    }
}
namespace University_project.Models;

internal class Course
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int DurationMonths { get; set; }

    public static readonly List<Course> Available = new()
    {
        new Course { Name = "C# Basics", Description = "შესავალი C#-ში",   DurationMonths = 3 },
        new Course { Name = "ASP.NET",   Description = "ვებ აპლიკაციები",  DurationMonths = 4 },
        new Course { Name = "SQL",       Description = "მონაცემთა ბაზები", DurationMonths = 2 },
    };
}
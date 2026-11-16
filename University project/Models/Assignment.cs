namespace University_project.Models;

/// <summary>დავალება, რომელსაც ლექტორი აძლევს კურსის მოსწავლეებს.</summary>
internal class Assignment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CourseId { get; set; }
    public string Title
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }
            field = value.Trim();
        }
    }
    public string Description { get; set; }
    public DateOnly DueDate { get; set; }

    public Assignment(Guid courseId, string title, string description, DateOnly dueDate)
    {
        CourseId = courseId;
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
}
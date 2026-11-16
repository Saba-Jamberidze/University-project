namespace University_project.Models;

internal class Assignment(Guid CourseId, string Title, string Description, DateOnly DueDate)
{
    //Id, CourseId, Title, Description, DueDate
    public Guid Id { get; set; } = new Guid();
    public Guid CourseId { get; set; } = CourseId;
    public string Title { get; set; } = Title;
    public string Description { get; set; } = Description;
    public DateOnly DueDate { get; set; } = DueDate;
}

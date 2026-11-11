namespace University_project.Models;

/// <summary>კურსი (ჯგუფი) თარიღებით, ლექტორით და გაკვეთილების განრიგით.</summary>
internal class Course
{
    //Id|Name|Description|DurationMonths|StartDate|TeacherId

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int DurationMonths { get; set; }
    public DateOnly StartDate { get; set; }
    public Guid TeacherId { get; set; }

    public bool IsActive { get; set; }
}
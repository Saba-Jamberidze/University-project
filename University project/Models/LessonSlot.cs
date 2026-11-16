namespace University_project.Models;

/// <summary>ერთი კვირეული გაკვეთილის სლოტი (მაგ. ორშაბათი 18:00-20:00).</summary>
internal class LessonSlot
{
    public Guid CourseId { get; }
    public DayOfWeek Day { get; }
    public TimeOnly Start { get; }
    public TimeOnly End { get; }

    public LessonSlot(Guid courseId,
                      DayOfWeek day,
                      TimeOnly start,
                      TimeOnly end)
    {
        if (end <= start)
        {
            throw new ArgumentException("End time must be later than start time.");
        }

        CourseId = courseId;
        Day = day;
        Start = start;
        End = end;
    }
}
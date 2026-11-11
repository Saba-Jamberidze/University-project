namespace University_project.Models;

internal class LessonSlot
{
    public Guid CourseId { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly Start { get; set; }
    public TimeOnly End { get; set; }

    public LessonSlot(Guid courseId,
                      DayOfWeek day,
                      TimeOnly start,
                      TimeOnly end)
    {
        CourseId = courseId;
        Day = day;
        Start = start;
        End = end;
    }
}

namespace University_project.Models;

internal class Submission
{
    //Id, AssignmentId, StudentId, SubmittedAt, IsGraded

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid AssignmentId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;
    public bool IsGraded { get; set; } = false;

    public Submission(Guid assignmentId, Guid studentId)
    {
        AssignmentId = assignmentId;
        StudentId = studentId;
    }
}

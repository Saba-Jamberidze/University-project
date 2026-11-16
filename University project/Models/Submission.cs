namespace University_project.Models;

internal class Submission(Guid AssignmentId, Guid StudentId)
{
    //Id, AssignmentId, StudentId, SubmittedAt, IsGraded

    public Guid Id { get; set; } = new Guid();
    public Guid AssignmentId { get; set; } = AssignmentId;
    public Guid StudentId { get; set; } = StudentId;
    public DateTime SubmittedAt { get; set; } = DateTime.Now;
    public bool IsGraded { get; set; } = false;
}

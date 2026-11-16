namespace University_project.Models;

/// <summary>ლექტორი. კურსები მას Course.TeacherId-ით უკავშირდება.</summary>
internal class Teacher : User
{
    /// <summary>მომხმარებლის როლი.</summary>
    public override string Role => "teacher";

    /// <summary>სპეციალიზაცია (მაგ. "C#", "Web", "Python").</summary>
    public string Specialization { get; set; } = string.Empty;

    public Teacher(string name,
                   string lastName,
                   DateOnly birthDate,
                   string username,
                   string passwordHash,
                   string email)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
    }
}
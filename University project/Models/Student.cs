namespace University_project.Models;

///<summary>მოსწავლე. კურსებზე ჩარიცხვა ინახება Enrollment-ში.</summary>
internal class Student : User
{
    /// <summary>მომხმარებლის როლი.</summary>
    public override string Role => "student";

    public string Status { get; set; } = "Active";

    public Student(string name,
                   string lastName,
                   DateOnly birthDate,
                   string username,
                   string passwordHash,
                   string email)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
    }
}
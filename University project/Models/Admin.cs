namespace University_project.Models;

/// <summary>ადმინისტრატორი: მართავს კურსებს, ლექტორებსა და ჩარიცხვებს.</summary>
internal class Admin : User
{
    /// <summary>მომხმარებლის როლი.</summary>
    public override string Role => "admin";

    public Admin(string name,
                 string lastName,
                 DateOnly birthDate,
                 string username,
                 string passwordHash,
                 string email)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
    }
}
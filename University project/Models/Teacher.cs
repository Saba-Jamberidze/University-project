namespace University_project.Models;

internal class Teacher : User
{
    public string Role { get; init; } = "teacher";

    public string Specialization { get; set; }




    public Teacher(string name,
                   string lastName,
                   DateOnly birthDate,
                   string username,
                   string passwordHash,
                   string email)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
    }


}

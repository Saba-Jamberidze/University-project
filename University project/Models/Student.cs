namespace University_project.Models;

/// <summary>მოსწავლე. კურსებზე ჩარიცხვა ინახება Enrollment-ში.</summary>
internal class Student : User
{
    private const string AllowedGrades = "ABCDEF";

    /// <summary>მომხმარებლის როლი.</summary>
    public override string Role => "student";


    /// <summary>შეფასება (A-დან F-მდე).</summary>
    public char Grade
    {
        get;
        set
        {
            char upper = char.ToUpper(value);
            if (!AllowedGrades.Contains(upper))
            {
                throw new ArgumentException("Grade must be a letter from A to F.");
            }
            field = upper;
        }
    }

    public string Status { get; set; } = "Active";

    public Student(string name,
                   string lastName,
                   DateOnly birthDate,
                   string username,
                   string passwordHash,
                   string email,
                   char grade)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
        Grade = grade;
    }

    /// <summary>მოსწავლის მოკლე აღწერა (პოლიმორფიზმი).</summary>
    public override string GetInfo() =>
        $"#{Name} {LastName}, შეფასება: {Grade}";
}
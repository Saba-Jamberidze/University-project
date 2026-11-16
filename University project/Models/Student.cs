namespace University_project.Models;

/// <summary>მოსწავლე. კურსებზე ჩარიცხვა ინახება Enrollment-ში.</summary>
internal class Student : User
{
    private const string AllowedGrades = "ABCDEF";

    /// <summary>მომხმარებლის როლი.</summary>
    public override string Role => "student";

    /// <summary>სიის ნომერი. უნიკალურობას ამოწმებს UserService.</summary>
    public int RollNumber
    {
        get;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("RollNumber must be greater than zero.");
            }
            field = value;
        }
    }

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
                   int rollNumber,
                   char grade)
        : base(name, lastName, birthDate, username, passwordHash, email)
    {
        RollNumber = rollNumber;
        Grade = grade;
    }

    /// <summary>მოსწავლის მოკლე აღწერა (პოლიმორფიზმი).</summary>
    public override string GetInfo() =>
        $"#{RollNumber} {Name} {LastName}, შეფასება: {Grade}";
}
namespace University_project.Models;

/// <summary>საბაზო მომხმარებელი (მოსწავლისა და ლექტორის საერთო მონაცემები).</summary>
internal class User
{
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>მომხმარებლის როლი (გადაფარავენ შთამომავალი კლასები).</summary>
    public virtual string Role => "user";
    public string Name
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            field = value.Trim();
        }
    }
    public string LastName
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("LastName cannot be null or empty.");
            }
            field = value.Trim();
        }
    }

    public DateOnly BirthDate
    {
        get;
        set
        {
            if (value > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("BirthDate cannot be in the future.");
            }
            field = value;
        }
    }
    public int Age
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            int age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age))
            {
                age--; // დაბადების დღე ამ წელს ჯერ არ დამდგარა
            }
            return age;
        }
    }

    public string Username
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Username cannot be null or empty.");
            }
            field = value.Trim();
        }
    }
    public string PasswordHash { get; set; }
    public string Email
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Email cannot be null, empty, or invalid.");
            }
            field = value.Trim();
        }
    }

    public User(
                string name,
                string lastName,
                DateOnly birthDate,
                string username,
                string passwordHash,
                string email)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        Username = username;
        PasswordHash = passwordHash;
        Email = email;
    }
}

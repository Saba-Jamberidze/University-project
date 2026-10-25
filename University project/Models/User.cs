namespace University_project.Models;

internal class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
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
            var age = today.Year - BirthDate.Year;
            return age;
        }
    }
    public bool Guest { get; set; } = false;

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
    public string Password
    {
        get;
        set
        {
            if (value.Length < 6 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Password cannot be null, empty, or less than 6 characters.");
            }
            field = value.Trim();
        }
    }
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

    public User(string name, string lastName, DateOnly birthDate,
                string username, string password, string email)
    {
        Name = name;
        LastName = lastName;
        BirthDate = birthDate;
        Username = username;
        Password = password;
        Email = email;
    }
}

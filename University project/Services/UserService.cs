using System.Security.Cryptography;
using System.Text;
using University_project.Models;

namespace University_project.Services;

/// <summary>
/// მომხმარებლების (მოსწავლე, ლექტორი, ადმინი) რეგისტრაცია, ძებნა და ავტორიზაცია.
/// ყველა როლი ერთ სიაში ინახება.
/// </summary>
internal class UserService
{
    private const int MinPasswordLength = 4;

    private readonly List<User> users = new();

    public UserService()
    {
        EnsureDefaultAdmin();
    }

    /// <summary>
    /// თუ სისტემაში არც ერთი ადმინი არ არის, ქმნის საწყის ადმინს (admin / admin123).
    /// ადმინად თვითრეგისტრაცია შეუძლებელია, ამიტომ პირველი ადმინი ასე ჩნდება.
    /// </summary>
    public void EnsureDefaultAdmin()
    {
        if (users.OfType<Admin>().Any())
        {
            return;
        }

        users.Add(new Admin("Admin", "Admin", new DateOnly(2000, 1, 1),
                            "admin", Hash("admin123"), "admin@academy.ge"));
    }

    /// <summary>
    /// არეგისტრირებს მოსწავლეს. აბრუნებს false-ს, თუ მომხმარებლის სახელი ან სიის ნომერი
    /// დაკავებულია, ან პაროლი ძალიან მოკლეა. არასწორი მონაცემებისას (მაგ. ცარიელი სახელი)
    /// მოდელი ArgumentException-ს აგდებს.
    /// </summary>
    public bool RegisterStudent(
        string name,
        string lastName,
        DateOnly birthDate,
        string username,
        string password,
        string email,
        char grade)
    {
        if (!IsPasswordValid(password) ||
            IsUsernameTaken(username))
        {
            return false;
        }

        users.Add(new Student(name, lastName, birthDate, username,
                              Hash(password), email, grade));
        return true;
    }

    /// <summary>ამატებს ლექტორს (ადმინის მოქმედებაა). false, თუ სახელი დაკავებულია ან პაროლი მოკლეა.</summary>
    public bool AddTeacher(
        string name,
        string lastName,
        DateOnly birthDate,
        string username,
        string password,
        string email,
        string specialization)
    {
        if (!IsPasswordValid(password) || IsUsernameTaken(username))
        {
            return false;
        }

        users.Add(new Teacher(name, lastName, birthDate, username, Hash(password), email)
        {
            Specialization = specialization
        });
        return true;
    }

    /// <summary>ამოწმებს მომხმარებლის სახელსა და პაროლს. აბრუნებს მომხმარებელს (ნებისმიერი როლის) ან null-ს.</summary>
    public User Login(string username, string password)
    {
        string hash = Hash(password);

        return users.FirstOrDefault(u =>
            string.Equals(u.Username, username.Trim(), StringComparison.OrdinalIgnoreCase) &&
            u.PasswordHash == hash) ?? throw new InvalidOperationException("User not found or password is incorrect.");
    }

    /// <summary>აბრუნებს მომხმარებელს Id-ით ან null-ს.</summary>
    public User? GetById(Guid id) => users.FirstOrDefault(u => u.Id == id);

    /// <summary>ყველა მომხმარებელი (ადმინის სანახავად).</summary>
    public IReadOnlyList<User> GetAllUsers() => users.AsReadOnly();

    /// <summary>ყველა მოსწავლე.</summary>
    public IEnumerable<Student> GetAllStudents() => users.OfType<Student>();

    /// <summary>ყველა ლექტორი.</summary>
    public IEnumerable<Teacher> GetTeachers() => users.OfType<Teacher>();

    /// <summary>პოულობს მოსწავლეს სიის ნომრით.</summary>
    public Student? GetStudentById(Guid id) =>
        users.OfType<Student>().FirstOrDefault(s => s.Id == id);

    /// <summary>
    /// ანახლებს მოსწავლის შეფასებას სიის ნომრით. აბრუნებს false-ს, თუ მოსწავლე ვერ მოიძებნა.
    /// არასწორი ასოს შემთხვევაში Student.Grade ArgumentException-ს აგდებს.
    /// </summary>
    public bool UpdateGrade(Guid id, char grade)
    {
        Student? student = GetStudentById(id);
        if (student is null)
        {
            return false;
        }

        student.Grade = grade;
        return true;
    }

    /// <summary>მომხმარებლის სახელი დაკავებულია თუ არა (რეგისტრის გათვალისწინების გარეშე).</summary>
    private bool IsUsernameTaken(string username) =>
        users.Any(u => string.Equals(u.Username, username.Trim(), StringComparison.OrdinalIgnoreCase));

    /// <summary>პაროლი ცარიელი არ უნდა იყოს და მინიმალური სიგრძე უნდა ჰქონდეს.</summary>
    private static bool IsPasswordValid(string password) =>
        !string.IsNullOrWhiteSpace(password) && password.Length >= MinPasswordLength;

    /// <summary>პაროლის SHA256 ჰეში (hex სტრიქონის სახით).</summary>
    private static string Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
}
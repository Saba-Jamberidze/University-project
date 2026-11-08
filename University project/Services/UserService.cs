using System.Security.Cryptography;
using System.Text;
using University_project.Models;

namespace University_project.Services;

internal class UserService
{
    private readonly List<Student> students;
    // TODO: Teacher Service

    public UserService()
    {
        students = new List<Student>();
    }

    public bool RegisterStudent(
        string name,
        string lastName,
        DateOnly birthDate,
        string username,
        string password,
        string email)
    {
        if (students.Any(u => u.Username == username))
        {
            return false;
        }

        Student student = new Student(name, lastName, birthDate, username, Hash(password), email);
        students.Add(student);

        return true;
    }

    public Student? GetStudent(string username, string password)
    {
        return students
            .FirstOrDefault(u =>
            u.Username == username && u.PasswordHash == Hash(password));
    }

    private string Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }
}

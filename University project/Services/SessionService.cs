using University_project.Models;

namespace University_project.Services;

internal class SessionService
{
    private Student? currentStudent = null;
    //TODO: Teacher Sesion
    private readonly UserService userService = new UserService();


    public bool IsCurrentStudent
    {
        get
        {
            return currentStudent is not null;
        }
    }

    public bool LoginStudent(string userName, string password)
    {
        if (currentStudent is not null)
        {
            throw new InvalidOperationException("A student is already logged in."); // ToDo: add special exception
        }

        currentStudent = userService.GetStudent(userName, password);

        return currentStudent is null ? false : true;
    }

    public void LogoutStudent()
    {
        if (currentStudent is null)
        {
            throw new InvalidOperationException("No student is currently logged in."); // ToDo: add special exception
        }
        currentStudent = null;
    }
}

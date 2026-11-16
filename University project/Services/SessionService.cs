using University_project.Models;

namespace University_project.Services;

/// <summary>მიმდინარე სესია: ვინ არის ამჟამად სისტემაში შესული.</summary>
internal class SessionService
{
    private readonly UserService userService;

    /// <summary>იღებს საერთო UserService-ს, რომ მონაცემები ერთ ადგილას იყოს.</summary>
    public SessionService(UserService userService)
    {
        this.userService = userService;
    }

    /// <summary>შესული მომხმარებელი (null, თუ არავინ არის შესული).</summary>
    public User? CurrentUser { get; private set; }

    public bool IsLoggedIn => CurrentUser is not null;
    public bool IsAdmin => CurrentUser is Admin;
    public bool IsTeacher => CurrentUser is Teacher;
    public bool IsStudent => CurrentUser is Student;

    /// <summary>შედის სისტემაში. აბრუნებს true-ს, თუ სახელი და პაროლი სწორია.</summary>
    public bool Login(string username, string password)
    {
        if (CurrentUser is not null)
        {
            throw new InvalidOperationException("A user is already logged in.");
        }

        CurrentUser = userService.Login(username, password);
        return CurrentUser is not null;
    }

    /// <summary>გამოდის სისტემიდან.</summary>
    public void Logout()
    {
        if (CurrentUser is null)
        {
            throw new InvalidOperationException("No user is currently logged in.");
        }
    
        CurrentUser = null;
    }
}   
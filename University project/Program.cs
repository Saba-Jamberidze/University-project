using University_project.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

var users = new UserService();
var session = new SessionService(users);

try
{
    Console.WriteLine("username");
    string? sc = Console.ReadLine();
    Console.WriteLine("password");
    string? sc2 = Console.ReadLine();

    session.Login(sc, sc2);
}
catch (Exception ex)
{
    Console.WriteLine($"შეცდომა: {ex.Message}");
}
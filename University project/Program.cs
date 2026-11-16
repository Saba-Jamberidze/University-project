using University_project.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

var users = new UserService();
var session = new SessionService(users);

Console.WriteLine(session.Login("admin", "admin123"));        // True
Console.WriteLine(session.CurrentUser?.GetInfo());            // Admin Admin (admin)
session.Logout();

Console.WriteLine(session.Login("admin", "wrong"));           // False

Console.WriteLine(users.RegisterStudent("Ana", "Beridze", new DateOnly(2005, 3, 14),
                                        "ana", "1234", "ana@mail.com", 1, 'B')); // True
Console.WriteLine(users.RegisterStudent("Nika", "Kapanadze", new DateOnly(2004, 5, 2),
                                        "ANA", "1234", "nika@mail.com", 2, 'A')); // False (სახელი დაკავებულია)
Console.WriteLine(users.UpdateGrade(1, 'A'));                 // True
Console.WriteLine(users.GetStudentByRollNumber(1)?.GetInfo()); // #1 Ana Beridze, შეფასება: A
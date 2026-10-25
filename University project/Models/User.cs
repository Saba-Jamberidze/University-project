using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace University_project.Models;

internal class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public int Age { get; set; }
    public bool Guest { get; set; }

}

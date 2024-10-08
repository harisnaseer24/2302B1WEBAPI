using System;
using System.Collections.Generic;

namespace _2302b1testAPI.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ContactNo { get; set; } = null!;
}

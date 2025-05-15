using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Teacher
{
    public string TeacherId { get; set; } = null!;

    public string TeacherName { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}

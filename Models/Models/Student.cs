using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string Mid { get; set; } = null!;

    public virtual Major MidNavigation { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}

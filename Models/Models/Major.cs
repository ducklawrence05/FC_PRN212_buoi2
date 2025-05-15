using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Major
{
    public string MajorId { get; set; } = null!;

    public string MajorName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

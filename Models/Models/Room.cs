using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Room
{
    public int Seq { get; set; }

    public string RoomName { get; set; } = null!;

    public string StuId { get; set; } = null!;

    public string TeaId { get; set; } = null!;

    public virtual Student Stu { get; set; } = null!;

    public virtual Teacher Tea { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Sportiki.DB;

public partial class Level
{
    public int Id { get; set; }

    public string? Level1 { get; set; }

    public virtual ICollection<Athlete> Athletes { get; set; } = new List<Athlete>();
}

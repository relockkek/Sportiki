using System;
using System.Collections.Generic;

namespace Sportiki.DB;

public partial class Training
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? DateTime { get; set; }

    public string? Duration { get; set; }

    public string? Type { get; set; }

    public sbyte? Estimation { get; set; }

    public string? Comment { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();
}

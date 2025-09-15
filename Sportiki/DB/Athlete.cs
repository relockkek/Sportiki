using System;
using System.Collections.Generic;

namespace Sportiki.DB;

public partial class Athlete
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Birthday { get; set; }

    public int? LevelId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Level? Level { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();
}

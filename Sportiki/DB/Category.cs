using System;
using System.Collections.Generic;

namespace Sportiki.DB;

public partial class Category
{
    public int Id { get; set; }

    public string Category1 { get; set; } = null!;

    public virtual ICollection<Athlete> Athletes { get; set; } = new List<Athlete>();
}

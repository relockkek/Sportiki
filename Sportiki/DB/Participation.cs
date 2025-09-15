using System;
using System.Collections.Generic;

namespace Sportiki.DB;

public partial class Participation
{
    public int Id { get; set; }

    public int? AthleteId { get; set; }

    public int? TrainingId { get; set; }

    public virtual Athlete? Athlete { get; set; }

    public virtual Training? Training { get; set; }
}

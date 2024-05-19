using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Review
{
    public int IdReview { get; set; }

    public int IdClient { get; set; }

    public DateOnly DateOfReview { get; set; }

    public string Review1 { get; set; } = null!;

    public virtual Client IdClientNavigation { get; set; } = null!;
}

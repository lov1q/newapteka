using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Stock
{
    public int ИндексСклада { get; set; }

    public string АдресСклада { get; set; } = null!;

    public string ОбъемСклада { get; set; } = null!;

    public virtual ICollection<Procurement> Procurements { get; set; } = new List<Procurement>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}

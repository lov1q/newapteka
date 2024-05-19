using System;
using System.Collections.Generic;

namespace newapteka;

public partial class SuppliesOfGood
{
    public int ИндексПоставокТовара { get; set; }

    public int ИндексПоставки { get; set; }

    public int ИндексТовара { get; set; }

    public int Количество { get; set; }

    public int Цена { get; set; }

    public virtual Supply ИндексПоставкиNavigation { get; set; } = null!;

    public virtual Product ИндексТовараNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace newapteka;

public partial class StolenProduct
{
    public int ИндексСписанныхТоваров { get; set; }

    public int ИндексАптеки { get; set; }

    public int ИндексТовара { get; set; }

    public DateOnly ДатаСписания { get; set; }

    public int Количество { get; set; }

    public string ПричинаСписания { get; set; } = null!;

    public virtual Pharmacy ИндексАптекиNavigation { get; set; } = null!;

    public virtual Product ИндексТовараNavigation { get; set; } = null!;
}

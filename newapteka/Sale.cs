using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Sale
{
    public int ИндексПродажи { get; set; }

    public int ИндексАптеки { get; set; }

    public int ИндексТовара { get; set; }

    public int ИндексСкидки { get; set; }

    public DateOnly ДатаПродажи { get; set; }

    public int КоличествоТовара { get; set; }

    public virtual Pharmacy ИндексАптекиNavigation { get; set; } = null!;

    public virtual Discount ИндексСкидкиNavigation { get; set; } = null!;

    public virtual Product ИндексТовараNavigation { get; set; } = null!;
}

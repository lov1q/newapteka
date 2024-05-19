using System;
using System.Collections.Generic;

namespace newapteka;

public partial class DiscountsForCustomer
{
    public int ИндексСкидкиДляКлиентов { get; set; }

    public int ИндексСкидки { get; set; }

    public int ИндексКлиента { get; set; }

    public virtual Client ИндексКлиентаNavigation { get; set; } = null!;

    public virtual Discount ИндексСкидкиNavigation { get; set; } = null!;
}

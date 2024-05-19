using System;
using System.Collections.Generic;

namespace newapteka;

public partial class PurchaseDetail
{
    public int ИндексДеталиЗакупки { get; set; }

    public int ИндексТовара { get; set; }

    public int ИндексЗакупки { get; set; }

    public int Количество { get; set; }

    public virtual Procurement ИндексЗакупкиNavigation { get; set; } = null!;

    public virtual Product ИндексТовараNavigation { get; set; } = null!;
}

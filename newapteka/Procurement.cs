using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Procurement
{
    public int ИндексЗакупки { get; set; }

    public int ИндексАптеки { get; set; }

    public int ИндексСклада { get; set; }

    public DateOnly ДатаЗакупки { get; set; }

    public int СуммаЗакупки { get; set; }

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual Pharmacy ИндексАптекиNavigation { get; set; } = null!;

    public virtual Stock ИндексСкладаNavigation { get; set; } = null!;
}

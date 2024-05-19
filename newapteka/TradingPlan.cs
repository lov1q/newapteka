using System;
using System.Collections.Generic;

namespace newapteka;

public partial class TradingPlan
{
    public int ИндексТорговогоПлана { get; set; }

    public int ИндексАптеки { get; set; }

    public int ИндексТовара { get; set; }

    public int ИндексСотрудника { get; set; }

    public DateOnly Дата { get; set; }

    public int Количество { get; set; }

    public string Статус { get; set; } = null!;

    public virtual Pharmacy ИндексАптекиNavigation { get; set; } = null!;

    public virtual Employee ИндексСотрудникаNavigation { get; set; } = null!;

    public virtual Product ИндексТовараNavigation { get; set; } = null!;
}

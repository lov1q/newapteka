using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Salary
{
    public int ИндексЗарплаты { get; set; }

    public int ИндексСотрудника { get; set; }

    public string ДатаВыплаты { get; set; } = null!;

    public int СуммаВыплаты { get; set; }

    public virtual Employee ИндексСотрудникаNavigation { get; set; } = null!;
}

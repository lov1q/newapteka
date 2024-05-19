using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Supply
{
    public int ИндексПоставки { get; set; }

    public int ИндексПоставщика { get; set; }

    public int ИндексСклада { get; set; }

    public DateOnly ДатаПоставки { get; set; }

    public virtual ICollection<SuppliesOfGood> SuppliesOfGoods { get; set; } = new List<SuppliesOfGood>();

    public virtual Provider ИндексПоставщикаNavigation { get; set; } = null!;

    public virtual Stock ИндексСкладаNavigation { get; set; } = null!;
}

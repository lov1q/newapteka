using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Manufacturer
{
    public int ИндексПроизводителя { get; set; }

    public string НазваниеПроизводителя { get; set; } = null!;

    public string СтранаПроизводителя { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

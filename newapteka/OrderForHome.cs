using System;
using System.Collections.Generic;

namespace newapteka;

public partial class OrderForHome
{
    public int ИндексЗаказаНаДом { get; set; }

    public int ИндексКлиента { get; set; }

    public int ИндексКурьера { get; set; }

    public DateOnly ДатаЗаказа { get; set; }

    public DateOnly ДатаДоставки { get; set; }

    public int СуммаДоставки { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Client ИндексКлиентаNavigation { get; set; } = null!;

    public virtual Courier ИндексКурьераNavigation { get; set; } = null!;
}

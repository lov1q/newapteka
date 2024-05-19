using System;
using System.Collections.Generic;

namespace newapteka;

public partial class OrderDetail
{
    public int ИндексДеталейЗаказа { get; set; }

    public int ИндексЗаказаНаДом { get; set; }

    public int ИндкесТовара { get; set; }

    public int Количество { get; set; }

    public virtual OrderForHome ИндексЗаказаНаДомNavigation { get; set; } = null!;

    public virtual Product ИндкесТовараNavigation { get; set; } = null!;
}

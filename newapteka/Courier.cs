using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Courier
{
    public int ИндексКурьера { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public string Телефон { get; set; } = null!;

    public string Транспорт { get; set; } = null!;

    public virtual ICollection<OrderForHome> OrderForHomes { get; set; } = new List<OrderForHome>();
}

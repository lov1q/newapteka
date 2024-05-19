using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Provider
{
    public int ИндексПоставщика { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public string Телефон { get; set; } = null!;

    public string КомпанияПоставщика { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}

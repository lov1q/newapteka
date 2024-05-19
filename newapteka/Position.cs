using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Position
{
    public int ИндексДолжности { get; set; }

    public string НазваниеДолжности { get; set; } = null!;

    public int Оклад { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

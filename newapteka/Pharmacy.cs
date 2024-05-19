using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Pharmacy
{
    public int ИндексАптеки { get; set; }

    public string Название { get; set; } = null!;

    public string Адрес { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public string ГрафикРаботы { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Procurement> Procurements { get; set; } = new List<Procurement>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<StolenProduct> StolenProducts { get; set; } = new List<StolenProduct>();

    public virtual ICollection<TradingPlan> TradingPlans { get; set; } = new List<TradingPlan>();
}

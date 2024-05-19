using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Discount
{
    public int ИндексСкидки { get; set; }

    public string НазвваниеСкидки { get; set; } = null!;

    public int Скидка { get; set; }

    public string Описание { get; set; } = null!;

    public DateOnly ДатаНачала { get; set; }

    public DateOnly ДатаОкончания { get; set; }

    public virtual ICollection<DiscountsForCustomer> DiscountsForCustomers { get; set; } = new List<DiscountsForCustomer>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Client
{
    public int ИндексКлиента { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public DateOnly ДатаРождения { get; set; }

    public string Телефон { get; set; } = null!;

    public virtual ICollection<DiscountsForCustomer> DiscountsForCustomers { get; set; } = new List<DiscountsForCustomer>();

    public virtual ICollection<OrderForHome> OrderForHomes { get; set; } = new List<OrderForHome>();

    public virtual ICollection<ProductAccordingToRecipe> ProductAccordingToRecipes { get; set; } = new List<ProductAccordingToRecipe>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

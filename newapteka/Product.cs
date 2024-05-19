using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Product
{
    public int ИндексТовара { get; set; }

    public string Название { get; set; } = null!;

    public string УсловиеХранения { get; set; } = null!;

    public int Производитель { get; set; }

    public string КатегорияТовара { get; set; } = null!;

    public int Цена { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductAccordingToRecipe> ProductAccordingToRecipes { get; set; } = new List<ProductAccordingToRecipe>();

    public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; } = new List<PurchaseDetail>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<StolenProduct> StolenProducts { get; set; } = new List<StolenProduct>();

    public virtual ICollection<SuppliesOfGood> SuppliesOfGoods { get; set; } = new List<SuppliesOfGood>();

    public virtual ICollection<TradingPlan> TradingPlans { get; set; } = new List<TradingPlan>();

    public virtual Manufacturer ПроизводительNavigation { get; set; } = null!;
}

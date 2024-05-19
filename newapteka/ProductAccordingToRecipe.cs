using System;
using System.Collections.Generic;

namespace newapteka;

public partial class ProductAccordingToRecipe
{
    public int ИндексРецепта { get; set; }

    public int ИндексТовара { get; set; }

    public int ИндексКлиента { get; set; }

    public string Врач { get; set; } = null!;

    public DateOnly ДатаВыпискиРецепта { get; set; }

    public DateOnly ДатаПокупкиТовара { get; set; }

    public virtual Client ИндексКлиентаNavigation { get; set; } = null!;

    public virtual Product ИндексТовараNavigation { get; set; } = null!;
}

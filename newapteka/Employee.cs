using System;
using System.Collections.Generic;

namespace newapteka;

public partial class Employee
{
    public int ИндексСотрудника { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public char Пол { get; set; }

    public string Телефон { get; set; } = null!;

    public string Адрес { get; set; } = null!;

    public string Образование { get; set; } = null!;

    public int Должность { get; set; }

    public int ИндексАптеки { get; set; }

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

    public virtual ICollection<TradingPlan> TradingPlans { get; set; } = new List<TradingPlan>();

    public virtual Position ДолжностьNavigation { get; set; } = null!;

    public virtual Pharmacy ИндексАптекиNavigation { get; set; } = null!;
}

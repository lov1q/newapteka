using System;
using System.Collections.Generic;

namespace newapteka;

public partial class User
{
    public int ИндексПользователя { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public string? Соль { get; set; }

    public string Должность { get; set; } = null!;
}

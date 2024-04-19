using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Compaund { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double? Price { get; set; }

    public virtual ICollection<OrderMenu> OrderMenus { get; set; } = new List<OrderMenu>();
}

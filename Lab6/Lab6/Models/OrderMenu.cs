using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class OrderMenu
{
    public int Id { get; set; }

    public int? MenuId { get; set; }

    public virtual Menu? Menu { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

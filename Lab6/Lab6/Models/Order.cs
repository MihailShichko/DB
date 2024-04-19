using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? OrderMenuId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<OrderCoock> OrderCoocks { get; set; } = new List<OrderCoock>();

    public virtual OrderMenu? OrderMenu { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}

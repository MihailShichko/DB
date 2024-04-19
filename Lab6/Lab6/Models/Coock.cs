using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Coock
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Specialization { get; set; }

    public decimal? Payment { get; set; }

    public int? Post { get; set; }

    public string Telephonenumber { get; set; } = null!;

    public virtual ICollection<OrderCoock> OrderCoocks { get; set; } = new List<OrderCoock>();
}

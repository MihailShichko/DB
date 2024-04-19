using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Fullname { get; set; }

    public string? Telephonenumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

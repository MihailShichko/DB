using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? Rating { get; set; }

    public virtual Order? Order { get; set; }
}

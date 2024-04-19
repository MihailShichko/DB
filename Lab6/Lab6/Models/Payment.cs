using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentType { get; set; }

    public virtual Order? Order { get; set; }
}

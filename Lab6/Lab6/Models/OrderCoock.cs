using System;
using System.Collections.Generic;

namespace Lab6.Models;

public partial class OrderCoock
{
    public int Coockid { get; set; }

    public int Ordernum { get; set; }

    public int? Status { get; set; }

    public virtual Coock Coock { get; set; } = null!;

    public virtual Order OrdernumNavigation { get; set; } = null!;
}

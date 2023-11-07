﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OderDate { get; set; }

    public decimal OrderSum { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}

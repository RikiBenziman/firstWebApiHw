﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int ProductId { get; set; }
    [JsonIgnore]
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

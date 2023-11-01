using System;
using System.Collections.Generic;

namespace Entities;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? ProductName { get; set; }

    public double? ProductPrice { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductImage { get; set; }

    public virtual Category Category { get; set; } = null!;
}

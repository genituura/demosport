﻿using System;
using System.Collections.Generic;

namespace sport;

public partial class ProductSupplier
{
    public int ProductSupplierId { get; set; }

    public string ProductSupplierName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

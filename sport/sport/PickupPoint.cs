﻿using System;
using System.Collections.Generic;

namespace sport;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

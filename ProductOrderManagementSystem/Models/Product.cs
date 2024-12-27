using System;
using System.Collections.Generic;

namespace ProductOrderManagementSystem.Models;

public partial class Product : BaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } 

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public ICollection<Order> Orders { get; set; }
}

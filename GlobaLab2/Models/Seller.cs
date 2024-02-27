using System;
using System.Collections.Generic;

namespace GlobaLab2.Models;

public partial class Seller
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}

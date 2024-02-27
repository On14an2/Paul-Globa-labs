using System;
using System.Collections.Generic;

namespace GlobaLab2.Models;

public partial class Good
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Rating { get; set; }

    public int? IdSellers { get; set; }

    public virtual ICollection<GoodsInOrder> GoodsInOrders { get; set; } = new List<GoodsInOrder>();

    public virtual Seller? IdSellersNavigation { get; set; }
}

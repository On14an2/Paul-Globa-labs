using System;
using System.Collections.Generic;

namespace GlobaLab2.Models;

public partial class Order
{
    public int Id { get; set; }

    public decimal? SellarySum { get; set; }

    public int? IdPickUpPoint { get; set; }

    public int? IdClient { get; set; }

    public virtual ICollection<GoodsInOrder> GoodsInOrders { get; set; } = new List<GoodsInOrder>();

    public virtual Client? IdClientNavigation { get; set; }

    public virtual PickUpPoint? IdPickUpPointNavigation { get; set; }

    public virtual ICollection<IssuingOrder> IssuingOrders { get; set; } = new List<IssuingOrder>();
}

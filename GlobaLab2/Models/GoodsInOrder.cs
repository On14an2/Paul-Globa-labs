using System;
using System.Collections.Generic;

namespace GlobaLab2.Models;

public partial class GoodsInOrder
{
    public int Id { get; set; }

    public int? IdOrder { get; set; }

    public int? IdGoods { get; set; }

    public int? Count { get; set; }

    public virtual Good? IdGoodsNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}

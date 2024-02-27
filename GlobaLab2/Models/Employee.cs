using System;
using System.Collections.Generic;

namespace GlobaLab2.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdPickUpPoint { get; set; }

    public decimal? Salary { get; set; }

    public virtual PickUpPoint? IdPickUpPointNavigation { get; set; }

    public virtual ICollection<IssuingOrder> IssuingOrders { get; set; } = new List<IssuingOrder>();
}

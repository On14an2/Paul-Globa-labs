using System;
using System.Collections.Generic;

namespace GlobaLab2.Models;

public partial class IssuingOrder
{
    public int OrderPlacement { get; set; }

    public int? IdEmployees { get; set; }

    public int? IdOrder { get; set; }

    public DateTime? Date { get; set; }

    public virtual Employee? IdEmployeesNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
}

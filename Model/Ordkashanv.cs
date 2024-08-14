using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class Ordkashanv
{
    public string OrdNum { get; set; } = null!;

    public string? OrdDate { get; set; }

    public string PrtNum { get; set; } = null!;

    public string ItmCod { get; set; } = null!;

    public decimal Qty { get; set; }

    public decimal? OrRem { get; set; }
}

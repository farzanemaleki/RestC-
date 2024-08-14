using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class Ljjustparskhodrov
{
    public string? Srl { get; set; }

    public int TaminMojavezNo { get; set; }

    public string UDateTime { get; set; } = null!;

    public string ItemCode { get; set; } = null!;

    public string PartNo { get; set; } = null!;

    public long Qty { get; set; }

    public string? SendPlanDt { get; set; }

    public string? AdaptionDt { get; set; }

    public int ConstructorSrl { get; set; }

    public int? SubConstructorSrl { get; set; }

    public decimal? SaipaPlace { get; set; }

    public decimal? ParskhodroPlace { get; set; }

    public decimal? SaipakashanPlace { get; set; }

    public decimal? BonroPlace { get; set; }

    public decimal? SaipayadakPlace { get; set; }

    public string TaminGroup { get; set; } = null!;

    public string LicenseReason { get; set; } = null!;

    public string NoAdaptDesc { get; set; } = null!;

    public decimal? BodySrl { get; set; }

    public decimal? CarSrl { get; set; }
}

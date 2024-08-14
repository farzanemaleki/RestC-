using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class Knkanbanmegav
{
    public long KnkanbanSrl { get; set; }

    public decimal KanbanNo { get; set; }

    public string NdcdldSrl { get; set; } = null!;

    public string? PrtNum { get; set; }

    public string ItmCod { get; set; } = null!;

    public string KanbanDate { get; set; } = null!;

    public int PubrndSrl { get; set; }

    public long Qty { get; set; }
}

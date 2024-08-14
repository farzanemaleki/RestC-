using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class Txsaipafctv
{
    public string Taxid { get; set; } = null!;

    public string? Sstid { get; set; }

    public string? CustItmCode { get; set; }

    public string? PrtNum { get; set; }

    public int? CsmconSrl { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Fee { get; set; }

    public decimal? ItmPrice { get; set; }

    public string ManuName { get; set; } = null!;

    public int ManuCode { get; set; }

    public int? SgsFactNo { get; set; }

    public string? CustResidNo { get; set; }

    public string? FactType { get; set; }

    public string? Irtaxid { get; set; }

    public string? SgsUDateTime { get; set; }

    public string? CustResidDate { get; set; }

    public string? SgsFactDate { get; set; }

    public string? SgsAsnNum { get; set; }

    public string? SgsRetaxid { get; set; }

    public string? CustResidNoOthers { get; set; }
}

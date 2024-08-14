using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class EbPrfmwebv
{
    public string? BrandCode { get; set; }

    public string? GrouhKala { get; set; }

    public string? ComplName { get; set; }

    public string? PrtNumHead { get; set; }

    public decimal? Nobat { get; set; }

    public string? BrandName { get; set; }

    public int BiprtcSrl { get; set; }

    public int CgitmmSrl { get; set; }

    public string ItmCod { get; set; } = null!;

    public string PrtNum { get; set; } = null!;

    public string PrtTitleF { get; set; } = null!;

    public string? UnitTitle { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? ConsumeRate { get; set; }

    public long AgrmNum { get; set; }

    public int AgriSeq { get; set; }

    public string? AgrmDate { get; set; }

    public string? AgrmTasvibDate { get; set; }

    public decimal AgriQty { get; set; }

    public string OrdNum { get; set; } = null!;

    public string? OrdDate { get; set; }

    public decimal OrdQty { get; set; }

    public decimal? MandehDar { get; set; }

    public byte? PumonytCode { get; set; }

    public string PumonytTitle { get; set; } = null!;

    public string? OrdRecNo { get; set; }

    public string? Prfmno { get; set; }

    public string? PrfmShamsiDte { get; set; }

    public DateTime? PrfmDate { get; set; }

    public decimal PrfmQty { get; set; }

    public int? PrfmManuCode { get; set; }

    public string? PrfmManuName { get; set; }

    public int? PrfmiIssCode { get; set; }

    public string? PrfmiIssName { get; set; }

    public decimal? TrkdQty { get; set; }

    public decimal? MandePrfm { get; set; }

    public byte? CountryCode { get; set; }

    public string? CountryTitle { get; set; }

    public byte? CountrySalCode { get; set; }

    public string? CountrySalTitle { get; set; }

    public string? ReciveDate { get; set; }

    public decimal? Rqty { get; set; }

    public decimal? ResidQty { get; set; }

    public string? ResidDte { get; set; }

    public string? FirstPayDt { get; set; }

    public decimal? PerTa { get; set; }
}

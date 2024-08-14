using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class ForeignPurchList
{
    public string? BrndCode { get; set; }
    public string? BrndName { get; set; }
    public string PrtNum { get; set; } = null!;
    public string PrtTitle { get; set; } = null!;
    public decimal? PrfmQty { get; set; }
    public string? PrfmNum { get; set; } 
    public string? PrfmShamsiDte { get; set; } 
    public string? Step { get; set; } 
    public string? NextStep { get; set; } 
    public string? SabteSefareshNo { get; set; } 
    public string? SabteSefareshTitle { get; set; } 
    public decimal? SabteSefareshQty { get; set; }
    public string? SabteSefareshDte { get; set; } 
    public string? EtebarDte { get; set; } 
    public decimal? TakhssisArzQty { get; set; }
    public string? TakhssisArzDte { get; set; } 
    public string? EtebarArzDte { get; set; }  
    public decimal? WaitSwift { get; set; }
    public decimal? WaitSwiftQty { get; set; }
    public decimal? SwiftQty { get; set; }
    public string? SwiftDte { get; set; }  
    public decimal? HamlQty { get; set; }
    public string? HamlDte { get; set; }  
    public decimal? GomrokQty { get; set; }
    public string? GomrokDte { get; set; }  
    public decimal? TarkhisQty { get; set; }
    public string? TarkhisDte { get; set; }  
    public decimal? ResidQty { get; set; }
    public string? ResidDte { get; set; }  
    public string? ForwardDte { get; set; }  
    public decimal? PrfmPrice { get; set; }
    public string? PumonyDesc { get; set; }
    public decimal? PrfmTotal { get; set; }

}

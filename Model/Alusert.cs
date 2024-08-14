using System;
using System.Collections.Generic;

namespace SGSWS.Model;

public partial class Alusert
{
    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string Userkey { get; set; } = null!;

    public string? UsrComment { get; set; }

    public int UsrtypSrl { get; set; }

    public string? UDateTime { get; set; }

    public int Srl { get; set; }

    public int? AluserSrl { get; set; }

    public string? PassBack { get; set; }

    public string? ChngDate { get; set; }

    public virtual Alusert? AluserSrlNavigation { get; set; }

    public virtual ICollection<Alusert> InverseAluserSrlNavigation { get; set; } = new List<Alusert>();
}

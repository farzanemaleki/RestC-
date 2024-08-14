using Microsoft.AspNetCore.Mvc;

[Controller]
public class QC : ControllerBase
{

    [HttpGet, Route("QC")]
    public string Index()
    {
        return "QC";
    }

}


using Microsoft.AspNetCore.Mvc;
using SGSWS.Model;
using System.ComponentModel;

[Controller]
public class Parskhodro : ControllerBase
{

    [HttpGet, Route("Parskhodro/ConditionLicense"), Description("Returns a list of conditional license")]
    public IActionResult ConditionLicense(string Apikey)
    {
        //var generateApikey = General.GetApikey("14854", "ConditionLicense");
        //https://api.sazehgostar.com/Parskhodro/ConditionLicense?Apikey=646477476C41712F582F39662F527075477161335477714831625A4F51624B4C

        if (Apikey == null)
            return new JsonResult("Submit an Apikey");     

        if (!General.IsApikey(Apikey, "ConditionLicense"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Parskhodro)
            return new JsonResult("Access denied!");

        return new JsonResult(db.Ljjustparskhodrovs.Select(c => c));
    }

}


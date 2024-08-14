using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using SGSWS.Model;

[Controller]
public class Order : ControllerBase
{

    [HttpGet, Route("Order/KashanList"), Description("Returns a list of orders")]
    public IActionResult ExternalPurchase(string Apikey)
    {
        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        //https://api.sazehgostar.com/Order/KashanList?Apikey=2F5A537642305A336C4277556C53503344316E4E6955366B4E4874674D2B6655
        //var generateApikey = General.GetApikey("16635", "KashanList");

        if (!General.IsApikey(Apikey, "KashanList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.SaipaCitroen)
            return new JsonResult("Access denied!");

        return new JsonResult(db.Ordkashanvs);
    }



}


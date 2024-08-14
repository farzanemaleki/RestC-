using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using SGSWS.Model;
using Oracle.ManagedDataAccess.Client;
using Dapper;

[Controller]
public class Invoice : ControllerBase
{

    [HttpGet, Route("Invoice/ExternalPurchaseList"), Description("Returns a list of external purchases")]
    public IActionResult ExternalPurchase(string Apikey)
    {
        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        //https://api.sazehgostar.com/Invoice/ExternalPurchaseList?Apikey=5949356B764F714D642B6355766C6C457071514E3735756549443779486E784B4678356E2B626954704D633D
        //var generateApikey = General.GetApikey("15397", "ExternalPurchaseList");

        if (!General.IsApikey(Apikey, "ExternalPurchaseList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if(!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");

        //return new JsonResult(db.EbPrfmwebvs);
        var q = " SELECT * FROM ADMIN.EB_PRFMWEBV ";
        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }
    }


    [HttpGet, Route("Invoice/ExternalPurchaseMonitor"), Description("Returns external purchase monitoring")]
    public IActionResult ExternalPurchaseMonitor(string Apikey)
    {
        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        //https://api.sazehgostar.com/Invoice/ExternalPurchaseMonitor?Apikey=5949356B764F714D642B6355766C6C457071514E373069576C646C593355354941527A635A354E4E68496B3D
        //var generateApikey = General.GetApikey("15397", "ExternalPurchaseMonitor");

        if (!General.IsApikey(Apikey, "ExternalPurchaseMonitor"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");

        var q = $@" SELECT * FROM ADMIN.EB_MONITORING_SAIPAV ";
        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }

    }


    [HttpGet, Route("Invoice/TAXList"), Description("Returns a list of TAX invoices")]
    public IActionResult TAXList(string Apikey, string? From, string? To)
    {
        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        if (!General.IsDate8(From) || !General.IsDate8(To))
            return new JsonResult("Submit a valid date in format YYYYMMDD");

        if (From.CompareTo(To) > 0)
            return new JsonResult("Submit a valid date range");

        //https://api.sazehgostar.com/Invoice/TAXList?Apikey=72374F68374458492F512B2B6D42463161616C6943673D3D&From=14021201&To=14021220
        //var generateApikey = General.GetApikey("15397", "TAXList");

        if (!General.IsApikey(Apikey, "TAXList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");

        //var recordCount = db.Txsaipafctvs.Count(c => c.SgsUDateTime.CompareTo(General.ToDate10(From)) >=0  && c.SgsUDateTime.CompareTo(General.ToDate10(To)) <= 0);
        //if(recordCount > 1000)
        //    return new JsonResult($"Too many results! Please submit a shorter date range. ({recordCount} records found)");

        return new JsonResult(db.Txsaipafctvs.Where(c => c.SgsUDateTime.CompareTo(General.ToDate10(From)) >= 0 && c.SgsUDateTime.CompareTo(General.ToDate10(To)) <= 0).Select(c => c));

    }


    [HttpGet, Route("Invoice/CurrencyInfo"), Description("Returns a list of Sazeh Gostar Currency Info")]
    public IActionResult CurrencyInfo(string Apikey)
    {
        //if (Apikey == null)
        //    return new JsonResult("Submit an Apikey");

        https://api.sazehgostar.com/Invoice/CurrencyInfo?Apikey=6C6656427835675A2B73506C58417A43364577594562755832414E3854756276
        //var generateApikey = General.GetApikey("15397", "CurrencyInfo");

        if (!General.IsApikey(Apikey, "CurrencyInfo"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");

        var q = $@" SELECT * FROM ADMIN.EBNEEDV ";
        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }

    }



}


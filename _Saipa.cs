using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using SGSWS.Model;
using System.ComponentModel;
using Dapper;
using System.Globalization;

[Controller]
public class Saipa : ControllerBase
{   
    PersianCalendar pc = new PersianCalendar();

    [HttpGet, Route("Saipa/ForeignPurchList"), Description("Returns a list of Foreign purchase information")]
    public IActionResult ForeignPurchList(string Apikey)
    {
        //var generateApikey = General.GetApikey("15397", "ForeignPurchList");
        //https://api.sazehgostar.com/Saipa/ForeignPurchList?Apikey=6E6B4E386346453048726F556D307864544A48496A487777364A66706568764C

        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        if (!General.IsApikey(Apikey, "ForeignPurchList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");

        return new JsonResult(db.ForeignPurchList.Select(c => c));
    }
    [HttpGet, Route("Saipa/StockReceiptDetailList"), Description("Return a list of details of stock's receipt")]
    public IActionResult StockReceiptDetailList(string Apikey)
    {
        //var generateApikey = General.GetApikey("15397", "StockReceiptDetailList");
        //https://api.sazehgostar.com/Saipa/StockReceiptDetailList?Apikey=776641596D7751327A75556A38786C482B597441655A4C487A774C5670585A5064486270637864356663383D
        if (Apikey == null)
            return new JsonResult("submit an Apikey");

        if (!General.IsApikey(Apikey, "StockReceiptDetailList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");

        var year = pc.GetYear(DateTime.Now);
        var q = " SELECT * FROM ADMIN.SRF40HV WHERE SR_DTE >= '" + year + "' ";
        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }
    }
}
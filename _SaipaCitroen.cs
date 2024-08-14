using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using SGSWS.Model;
using System.ComponentModel;
using Dapper;
using System.Globalization;


[Controller]
public class SaipaCitroen : ControllerBase
{
    [HttpGet, Route("SaipaCitroen/Alteredshipments")] 
    public IActionResult Alteredshipments(string Apikey) {
        var generateApikey = General.GetApikey("16635", "Alteredshipments");
        //https://api.sazehgostar.com/SaipaCitroen/Alteredshipments?Apikey=4446457A4C4F572B3147326C4E366F6F3766534764514F494B6F69516D5A4B74
    
        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        if (!General.IsApikey(Apikey, "ForeignPurchList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Saipa)
            return new JsonResult("Access denied!");
        string q = "SELECT * FROM admin.srupdv;";
        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }
    }
}

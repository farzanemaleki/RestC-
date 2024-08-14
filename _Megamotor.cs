using Microsoft.AspNetCore.Mvc;
using SGSWS.Model;
using System.ComponentModel;

[Controller]
public class Megamotor : ControllerBase
{

    [HttpGet, Route("Megamotor/KanbanList"), Description("Returns a list of kanban for megamotor")]
    public IActionResult KanbanList(string Apikey)
    {
        //var generateApikey = General.GetApikey("15402", "KanbanList");
        //https://api.sazehgostar.com/Megamotor/KanbanList?Apikey=5566494F6C7235444938764E6F4273764C6456554C6B366B4E4874674D2B6655

        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        if (!General.IsApikey(Apikey, "KanbanList"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        if (int.Parse(General.GetUserkey(Apikey)) != (int)General.Title.Megamotor)
            return new JsonResult("Access denied!");

        return new JsonResult(db.Knkanbanmegavs.Select(c => c));
    }

}


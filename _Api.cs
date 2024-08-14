using Dapper;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using SGSWS.Model;
using System.ComponentModel;

[ApiController]
public class Api : ControllerBase
{

    [HttpGet, Route("")]
    public string Index()
    {
        return "Welcome to SazehGostarSaipa WebAPI...";
    }

    [HttpGet, Route("GetSteelSheet"), Description("Returns a list of Steel Sheets")]
    public IActionResult GetSteelSheet(string Apikey, string? From, string? To)
    {
        //https://api.sazehgostar.com/GetSteelSheet?Apikey=4931704130414637752B4B6E453870647259625441346436454E4E6E3670516B&From=14021103&To=14021103
        //var generateApikey = General.GetApikey("15305", "GetSteelSheet");

        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        if (!General.IsDate8(From) || !General.IsDate8(To))
            return new JsonResult("Submit a valid date in format YYYYMMDD");

        if (From.CompareTo(To) > 0)
            return new JsonResult("Submit a valid date range");

        if (!General.IsApikey(Apikey, "GetSteelSheet"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        var ISSINF_SRL = int.Parse(General.GetUserkey(Apikey));
        List<int> allowedUsers = new List<int> { Convert.ToInt32(General.Title.SaipaRing) }; // Add here new allowed manufacturers serail
        if (!allowedUsers.Contains(ISSINF_SRL))
            return new JsonResult("Access denied!");

        var q = $@"
                    SELECT ADMIN.KPSTRNT.NUM, ADMIN.KPSTRNT.EFC_DTE, ADMIN.KPSTRIT.QTY, COIL_NO, WT_QTY, ADMIN.CGITMMT.ITM_COD, ADMIN.CGITMMT.FAR_DES, admin.biprtct.TICKNESS, admin.biprtct.DIMENSION, ADMIN.BIMTRCT.CODE, CGB.ITM_COD ITM_COD_B, admin.srrptlt.BLG_NUM 
                    FROM ADMIN.KPSTRNT, ADMIN.KPSTRIT, ADMIN.KPBRCDT, ADMIN.SRBARCODET, ADMIN.BIPRTCT, ADMIN.CGITMMT, ADMIN.BIMTRCT, ADMIN.BIBASEV, ADMIN.CGITMMT CGB, admin.srrptlt,admin.srrptit 
                    WHERE ADMIN.KPSTRNT.ISSINF_SRL = {ISSINF_SRL}
                    AND ADMIN.KPSTRNT.YER >= 1399 
                    AND ADMIN.KPSTRNT.SRL = ADMIN.KPSTRIT.KPSTRN_SRL(+) 
                    AND ADMIN.KPSTRIT.KPSTRN_SRL = ADMIN.KPBRCDT.KPSTRI_KPSTRN_SRL(+) 
                    AND ADMIN.KPSTRIT.SEQ = ADMIN.KPBRCDT.KPSTRI_SEQ(+) 
                    AND ADMIN.SRBARCODET.SRL(+) = ADMIN.KPBRCDT.SRBARCODE_SRL 
                    AND ADMIN.CGITMMT.SRL = ADMIN.KPSTRIT.CGITMM_SRL 
                    AND ADMIN.KPSTRNT.KPDCTP_SRL = 11 
                    AND ADMIN.BIBASEV.CGITMM_SRL(+) = ADMIN.KPSTRIT.CGITMM_SRL 
                    AND ADMIN.BIBASEV.CGITMM_SRL_BASE = CGB.SRL(+) 
                    AND ADMIN.BIMTRCT.SRL = ADMIN.BIPRTCT.BIMTRC_SRL 
                    AND admin.biprtct.srl = ADMIN.CGITMMT.BIPRTC_SRL 
                    and admin.srrptlt.srl(+) = admin.srrptit.SRRPTL_SRL 
                    and admin.srrptit.SRRPTL_SRl(+) = ADMIN.SRBARCODET.SRRPTIT_SRRPTL_SRL 
                    and admin.srrptit.seq(+) = ADMIN.SRBARCODET.SRRPTIT_seq 
                    and ADMIN.KPSTRNT.EFC_DTE between '{General.ToDate10(From)}' AND '{General.ToDate10(To)}' ";

        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }


    }
    /// <summary>
    /// لیست  جزئیات اطلاعات کانبان
    /// </summary>	
    [HttpPost, Route("KanbanDetail/{Apikey}"), Description("return list of kanban details")]
    public IActionResult KanbanDetail(string Apikey)
    {
        //https://api.sazehgostar.com/KanbanDetail/79556A51494E455A576D5663634C502F47485566637357797172476D4D64736A
        //var generateApikey = General.GetApikey("18079", "KanbanDetail");
        if (Apikey == null)
            return new JsonResult("Submit an Apikey");

        if (!General.IsApikey(Apikey, "KanbanDetail"))
            return new JsonResult("Submit a valid Apikey");

        var db = Singleton.ContextR();
        if (!db.Database.CanConnect())
            return new JsonResult("The API is temporarily out of service (ORA: Disconnected)");

        var ISSINF_SRL = int.Parse(General.GetUserkey(Apikey));
        List<int> allowedUsers = new List<int> { Convert.ToInt32(General.Title.Saipa), 
                                                 Convert.ToInt32(General.Title.Parskhodro),
                                                 Convert.ToInt32(General.Title.Zamiyad), 
                                                 Convert.ToInt32(General.Title.SaipaCitroen), 
                                                 Convert.ToInt32(General.Title.BonRo) }; 

        if (!allowedUsers.Contains(ISSINF_SRL)) return new JsonResult("Access denied!");

        string? st;
        switch (Apikey)
        {
            case "79556A51494E455A576D5663634C502F47485566637357797172476D4D64736A":   //سایپا
                st = "admin.knkanban4st";
                break;
            case "5963396A4731684A76333963634C502F47485566637357797172476D4D64736A":   //پارس خودرو
                st = "admin.knkanban4pt";
                break;
            case "3055737A5945335A36667463634C502F47485566637357797172476D4D64736A":   //زامیاد
                st = "admin.knkanban4zt";
                break;
            case "2F5A537642305A336C427863634C502F47485566637357797172476D4D64736A":   //سایپا سیتروئن - کاشان
                st = "admin.knkanban4kt";
                break;
            case "73335747494B7A636E586463634C502F47485566637357797172476D4D64736A":   //بن رو
                st = "admin.knkanban4t";
                break;
            default:
                return null;
        }

        string q = $@" select cur_date,CGCIDST.PRT_NUM,CGCIDST.itm_cod,CGCIDST.far_des,ndcdld_Srl,kn_qty,qty0,qty1,qty21,qty22,tot_qty,lt_des,ss_des,kanban_qty,min_kanban_qty,prod_qty,inv_qty, NAME || ' ' || FAMILY ep_name,tel_no,code 
             ,(SELECT NVL(BOX_TOT_QTY,TOT_QTY) FROM admin.pkpalt4v where pkpalt4v.ndcdld_Srl = {st}.ndcdld_srl 
             and pkpalt4v.biprtc_srl = eplackv.biprtc_Srl ) pk_qty, 
             nvl((select  nvl(bid.VALPER, 0) 
             from ADMIN.bigrpplnPERt m, ADMIN.BIGRPPLNPERDT bid where  m.srl = bid.BIGRPPLNPER_SRL 
             AND biD.BIPRTC_sRL = cgitmmt.BIPRTC_SRL and    m.ndcdld_Srl = {st}.NDCDLD_sRL 
             and m.pubrnd_Srl = {st}.PUBRND_sRL
            and bid.active = 1)  ,100) c_per ,round(admin.kndailyneedf({st}.ndcdld_Srl, cgitmmt.biprtc_srl) * ((nvl(ss_des, 0) + nvl(ss_c, 0) + (nvl(lt_des, 0) * (1 + (nvl(lt_sure, 0))))) / 24)) op 
            from {st} 
            ,ADMIN.CGCIDST, admin.cgitmmt,admin.eplackv,admin.prtelnt 
            where cur_date ='{General.PersianDate()}' and seq in (select max(seq) 
            from {st} where cur_date ='{General.PersianDate()}' AND Active=0) AND {st}.CGCIDS_sRL = CGCIDST.SRL 
            AND CGCIDST.CGITMM_SRL =CGITMMT.SRL 
            AND cgitmmt.biprtc_Srl = eplackv.biprtc_srl(+) 
            AND eplackv.prpblc_Srl = prtelnt.prpblc_srl(+)
            and  ADMIN.kn_part_typf(cgitmmt.biprtc_srl) <> 15367 ";


        using (var dbDapper = new OracleConnection(General.csR))
        {
            return new JsonResult(dbDapper.Query(q).ToList());
        }
    }
}


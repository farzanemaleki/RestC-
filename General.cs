using SGSWS.Model;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public class General
{
    public static string csR = "Data Source=000";
    public enum Title
    {
        //Serial
        Saipa = 15397,
        Crouse = 3975,
        Parskhodro = 14854,
        Megamotor = 15402,
        SaipaRing = 15305,
        SaipaCitroen = 16635,
        Zamiyad = 13788,
        BonRo = 18079
    };

    public static string PersianDate()
    {
        //1398/02/19
        var pc = new PersianCalendar();
        var dt = System.DateTime.Now;
        return pc.GetYear(dt) + "/" + pc.GetMonth(dt).ToString("00") + "/" + pc.GetDayOfMonth(dt).ToString("00");
    }

    public static string PersianDate(int days)
    {
        //1398/02/19
        var pc = new PersianCalendar();
        var dt = DateTime.Now.AddDays(days);
        return pc.GetYear(dt) + "/" + pc.GetMonth(dt).ToString("00") + "/" + pc.GetDayOfMonth(dt).ToString("00");
    }

    public static string Time()
    {
        var myDateTime = DateTime.Now;
        return myDateTime.ToString("HH:mm");
    }

    public static string Time8()
    {
        var myDateTime = DateTime.Now;
        return myDateTime.ToString("HH:mm:ss");
    }

    public static bool IsDigit(string strInput)
    {
        try
        {
            long tmp = Convert.ToInt64(strInput);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsFloat(string strInput)
    {
        try
        {
            var tmp = Convert.ToDouble(strInput);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool IsDate(string date)
    {
        if (date == null || date.Length != 10) return false;
        if (!Regex.IsMatch(date, @"^[1-4]\d{3}\/((0[1-6]\/((3[0-1])|([1-2][0-9])|(0[1-9])))|((1[0-2]|(0[7-9]))\/(30|([1-2][0-9])|(0[1-9]))))$"))
            return false;

        try
        {
            var dt = DateTime.Parse(date);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public static bool IsDate8(string date)
    {
        if (date == null || date.Length != 8 || !General.IsDigit(date))
            return false;

        if (!(date.StartsWith("13") || date.StartsWith("14")))
            return false;

        var month = Convert.ToInt32(date.Substring(4, 2));
        if (!(month > 0 && month <= 12))
            return false;

        var day = Convert.ToInt32(date.Substring(6, 2));
        if (!(day > 0 && day <= 31))
            return false;

        return true;
    }

    public static string ToDate10(string date)
    {
        if (date.Length != 8 || !IsDigit(date))
            return PersianDate();
        return date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2);
    }

    
    public static bool IsUsername(string s)
    {
        return s.Trim().Length > 3;
    }

    public static bool IsPassword(string s)
    {
        return s.Trim().Length > 3;
    }

    private static string EncryptPassword(string password)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] bytes = encoding.GetBytes(password);
        byte[] buffer2 = SHA1.HashData(bytes);
        var encPass = encoding.GetString(buffer2);
        return encoding.GetString(buffer2);
    }

    
    public static bool IsValidUser(string username, string password)
    {
        var encryptPassword = EncryptPassword(password);
        string tmpPassword = "";
        for (int i = 0; i < encryptPassword.Length; i++)
        {
            tmpPassword += encryptPassword[i].ToString();
            if (encryptPassword[i].ToString() == "'")
                tmpPassword += "'";
        }

        var db = new _ContextR();
        return db.Aluserts.Any(c => c.Username == username.Trim().ToLower() && c.Password == tmpPassword);
    }

    public static string GetUserkey(string username, string password)
    {
        var encryptPassword = EncryptPassword(password);
        string tmpPassword = "";
        for (int i = 0; i < encryptPassword.Length; i++)
        {
            tmpPassword += encryptPassword[i].ToString();
            if (encryptPassword[i].ToString() == "'")
                tmpPassword += "'";
        }

        var db = new _ContextR();
        bool userExist = db.Aluserts.Any(c => c.Username == username.Trim().ToLower() && c.Password == tmpPassword);
        return userExist ? db.Aluserts.Where(c => c.Username == username.Trim().ToLower() && c.Password == tmpPassword).Select(c => c.Userkey).First() : "";

    }
    

    public static bool IsApikey(string apiKey, string methodName)
    {
        if (apiKey == null || apiKey.Length < 20) return false;
        if (!Regex.IsMatch(apiKey, @"\A\b[0-9a-fA-F]+\b\Z")) return false;

        var tmp = Decrypt(apiKey);
        if (tmp == "") return false;

        if (!tmp.Contains(' ')) return false;

        var Userkey = tmp.Substring(0, tmp.IndexOf(' ', 0));
        if (!IsDigit(Userkey)) return false;

        var MethodName = tmp.Replace(Userkey + " ", "");
        if (MethodName != methodName.ToLower()) return false;

        var db = new _ContextR();
        return db.Aluserts.Any(c => c.Userkey == Userkey);
    }

    public static string GetApikey(string userKey, string methodName)
    {
        return Encrypt(userKey + " " + methodName.ToLower());
    }

    public static string GetUserkey(string apikey)
    {
        if (apikey == null || apikey.Length < 20) return "";
        if (!Regex.IsMatch(apikey, @"\A\b[0-9a-fA-F]+\b\Z")) return "";

        var tmp = Decrypt(apikey);
        if (tmp == "") return "";
        if (!tmp.Contains(' '))
            return "";

        var Userkey = tmp.Substring(0, tmp.IndexOf(' ', 0));
        return IsDigit(Userkey) ? Userkey : "";
    }

    private static string Encrypt(string raw)
    {
        byte[] keyArray;
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(raw);
        keyArray = UTF8Encoding.UTF8.GetBytes("Apiy@a67M1%gB78i");

        var tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.ECB;
        tdes.Padding = PaddingMode.PKCS7;

        var cTransform = tdes.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        var tmp = Convert.ToBase64String(resultArray, 0, resultArray.Length);  //returen minLength:12   maxLength:32
        return Convert.ToHexString(Encoding.Default.GetBytes(tmp));
    }

    private static string Decrypt(string encrypted)
    {
        if (encrypted == null || encrypted == "")
            return "";

        encrypted = Encoding.ASCII.GetString(General.FromHex(encrypted));
        byte[] keyArray;
        try
        {
            byte[] toEncryptArray = Convert.FromBase64String(encrypted);
            keyArray = UTF8Encoding.UTF8.GetBytes("Apiy@a67M1%gB78i");
            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            var cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        catch
        {
            return "";
        }
    }


    private static byte[] FromHex(string hex)
    {
        hex = hex.Replace("-", "");
        byte[] raw = new byte[hex.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return raw;
    }


}


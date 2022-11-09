using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    private string path;
    public WebService()
    {
        path = Path.Combine(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory), @"Employees.json");
    }

    [WebMethod]
    public string GetFile()
    {
        string employees = String.Empty;

        using (StreamReader r = new StreamReader(path, Encoding.UTF8))
        {
            employees = r.ReadToEnd();
        }
        return employees;
    }

    [WebMethod]
    public void SendFile(string json)
    {
         File.WriteAllText(path, json);
    }
}

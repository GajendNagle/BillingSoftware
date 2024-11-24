using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class ConnectionC
{
    static public string con()
    {

        string con = ConfigurationManager.ConnectionStrings["dvinfosoft"].ConnectionString;
        return con;
    }
   
}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MessageC
/// </summary>
public class MessageC
{
    public void MsgBox(string msg)
    {
        Page pg = HttpContext.Current.Handler as Page;
        pg.ClientScript.RegisterStartupScript(typeof(Page), "key", "<script>alert('" + msg + "')</script>");
    }
    public void MsgScriptwith(string msgsc, string url)
    {
        Page page = HttpContext.Current.Handler as Page;
        string strScript = "<script>";
        strScript += "alert('" + msgsc + "');";
        strScript += "window.location='" + url + "';";
        strScript += "</script>";
        page.ClientScript.RegisterStartupScript(this.GetType(), "Startup", strScript);
    }

    public void MsgBox1(string msg)
    {
        Page page = HttpContext.Current.Handler as Page;
        string strScript = "javascript: alert('" + msg + "')";
        ScriptManager.RegisterStartupScript(page, this.GetType(), "strScript", strScript, true);

    }
    public void MsgScriptwith1(string msgsc, string url)
    {
        Page page = HttpContext.Current.Handler as Page;
        string strScript = "javascript: alert('" + msgsc + "');window.location='" + url + "';";
        ScriptManager.RegisterStartupScript(page, this.GetType(), "strScript", strScript, true);
    }

    //public void MsgBox(string msgsc)
    //{
    //    Page page = HttpContext.Current.Handler as Page;      
    //    ScriptManager.RegisterStartupScript(page, this.GetType(), "text", "not1('" + msgsc.ToString() + "')", true);
    //}
    //public void MsgBox(string msgsc)
    //{
    //    Page page = HttpContext.Current.Handler as Page;
    //    ScriptManager.RegisterStartupScript(page, this.GetType(), "text", "not2('" + msgsc.ToString() + "')", true);
    //}
}

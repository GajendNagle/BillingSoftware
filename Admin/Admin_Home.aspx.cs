using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_Admin_Home : System.Web.UI.Page
{
    Admin_Home_C aa = new Admin_Home_C();
    LoginC gv = new LoginC();
    MessageC m = new MessageC();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];
            if (admincookie != null) // means cookie is found
            {
                if (!IsPostBack)
                {
                    LblDate.Text = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE).ToString("dd-MM-yyyy");
                    lblcenterid.Text = admincookie["Center_ID"].ToString();
                    lbluserid.Text = admincookie["User_ID"].ToString();
                }
            }
            else
            {
                m.MsgScriptwith("Time Out", "../index.aspx");
            }

        }
        catch
        {
        }
    }
}

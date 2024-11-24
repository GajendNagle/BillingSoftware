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

public partial class Admin_Admin_Change_Password : System.Web.UI.Page
{
    Change_Password_C ac = new Change_Password_C();
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
                    LblCenterId.Text = admincookie["Center_ID"].ToString();
                    lbluserid.Text = admincookie["User_ID"].ToString();
                    Textoldpass.Focus();
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];
            if (admincookie != null)
            {
                if (Textoldpass.Text != "" && cnf_pass_txt.Text != "" && txtloginpass.Text != "")
                {
                    bool b = ac.Get_AdminAutontication1(lbluserid.Text, Textoldpass.Text, LblCenterId.Text);
                    if (b == true)
                    {
                        ac.Get_AdminUpdate_Passward(lbluserid.Text, cnf_pass_txt.Text, LblCenterId.Text);
                        m.MsgScriptwith("Passward Change Successfully....!!", "Admin_Change_Password.aspx");
                    }
                    else
                    {
                        m.MsgBox("Passward wrong");
                        Textoldpass.Text = "";
                    }
                }
                else
                {
                    m.MsgBox("Please Enter Required Fields");
                }
            }
            else
            {
                m.MsgScriptwith("Time Out", "../index.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_Change_Password.aspx");
    }
}

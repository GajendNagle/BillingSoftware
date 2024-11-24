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
using System.Security.Cryptography;
using System.Security;
using System.Text;


public partial class index : System.Web.UI.Page
{
    LoginC l = new LoginC();
    MessageC m = new MessageC();
    static string date;
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE).ToString("dd-MM-yyyy");
                //DataSet dstraial = l.GetTrialDate();
                //if (dstraial.Tables[0].Rows.Count > 0)
                //{
                //    DateTime trialdate = DateTime.ParseExact(dstraial.Tables[0].Rows[0].ItemArray[0].ToString(), "dd-MM-yyyy", null);
                //    DateTime todaydate = DateTime.ParseExact(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE).ToString("dd-MM-yyyy"), "dd-MM-yyyy", null);
                //    if (todaydate > trialdate)
                //    {
                //        Response.Redirect("welcomepage.aspx");
                //    }
                //}
                txtloginname.Focus();
            }
            if (Request.Cookies["AdminInfo"] != null)
            {
                HttpCookie admincookie = new HttpCookie("AdminInfo");
                admincookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(admincookie);
            }
        }
        catch
        {
        }
    }
    //private void txtloginpass_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    //{
    //    if (e.KeyChar.Equals(Convert.ToChar(13)))
    //    {
    //        this.btnlogin_Click(this.btnlogin, null);
    //    }
    //}
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtloginname.Text != "" | txtloginpass.Text != "")
            {
                bool a;
                a = l.Userexist(txtloginname.Text, txtloginpass.Text);
                if (a == true)
                {
                    string user_id = l.FetchUserRagistrationNo(txtloginname.Text, txtloginpass.Text);

                    DataSet ds = l.Fetch_Detail(user_id);
                    string User_Name, Role, Center_ID, Center_Name, State_Code;
                    User_Name = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    Role = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                    Center_ID = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    State_Code = ds.Tables[0].Rows[0].ItemArray[5].ToString();

                    if (Role.ToString() == "Admin")
                    {

                        HttpCookie admincookie = Request.Cookies["AdminInfo"];
                        if (admincookie == null)
                        {
                            admincookie = new HttpCookie("AdminInfo");
                        }

                        admincookie["User_Name"] = User_Name.ToString();
                        admincookie["UserName"] = User_Name.ToString();
                        admincookie["User_ID"] = user_id.ToString();
                        admincookie["UserID"] = user_id.ToString();
                        admincookie["Center_ID"] = user_id.ToString();
                        admincookie["Role"] = Role.ToString();
                        admincookie["State_Code"] = State_Code.ToString();

                        Response.Cookies.Add(admincookie);
                        admincookie.Expires = DateTime.Now.AddDays(1);
                        Response.Redirect("~/Admin/Admin_Home.aspx");
                    }
                    else
                    {

                        string Designationid = l.FetchUserRoleStaffID(txtloginname.Text, txtloginpass.Text);

                        HttpCookie admincookie = Request.Cookies["AdminInfo"];
                        if (admincookie == null)
                        {
                            admincookie = new HttpCookie("AdminInfo");
                        }

                        admincookie["User_Name"] = User_Name.ToString();
                        admincookie["UserName"] = User_Name.ToString();
                        admincookie["User_ID"] = user_id.ToString();
                        admincookie["UserID"] = user_id.ToString();
                        admincookie["Center_ID"] = Center_ID.ToString();
                        admincookie["Role"] = Role.ToString();
                        admincookie["State_Code"] = State_Code.ToString();
                        admincookie["Designation"] = Designationid.ToString();

                        Response.Cookies.Add(admincookie);
                        admincookie.Expires = DateTime.Now.AddDays(1);
                        Response.Redirect("~/Admin/Admin_Home.aspx");
                    }


                }
                else
                {
                    bool a1;
                    a1 = l.Userexist1(txtloginname.Text, txtloginpass.Text);
                    if (a1 == true)
                    {
                        string user_id1 = l.FetchUserRagistrationfrom(txtloginname.Text, txtloginpass.Text);

                        string User_Name1, Role, Center_ID1, Center_Name, State_Code;

                        DataSet ds = l.Fetch_Detail1(user_id1);
                        User_Name1 = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                        // Role = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                        Center_ID1 = ds.Tables[0].Rows[0].ItemArray[2].ToString();

                        HttpCookie usercookie = Request.Cookies["UserInfo"];
                        if (usercookie == null)
                        {
                            usercookie = new HttpCookie("UserInfo");
                        }

                        usercookie["User_Name"] = User_Name1.ToString();
                        usercookie["UserName"] = User_Name1.ToString();
                        usercookie["User_ID"] = user_id1.ToString();
                        usercookie["UserID"] = user_id1.ToString();
                        usercookie["Center_ID"] = Center_ID1.ToString();
                        //    usercookie["Role"] = Role.ToString();
                        //  usercookie["State_Code"] = State_Code.ToString();
                        ///
                        Response.Cookies.Add(usercookie);
                        usercookie.Expires = DateTime.Now.AddDays(1);
                        Response.Redirect("~/User/User_Home.aspx");
                    }

                    else
                    {
                        m.MsgBox("Wrong UserName & Password! Access Denied");
                    }

                }
            }
            else
            {
                m.MsgBox("Please Enter Login Name & Password....");
            }
        }
        catch (Exception ex)
        {
        }
    }
}

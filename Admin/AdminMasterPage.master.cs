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

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    LoginC gv = new LoginC();
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];
            if (admincookie != null)
            {
                if (!IsPostBack)
                {
                    lblname.Text = admincookie["User_Name"].ToString();
                    lblname1.Text = admincookie["User_Name"].ToString();
                    gv.centerid = admincookie["Center_ID"].ToString();
                    GetPermission();
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
    public void GetPermission()
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];

            if (admincookie["Role"].ToString() != "Admin")
            {
                DataSet ds = new DataSet();
                ds = gv.Getmenuemployeewise(admincookie["Designation"].ToString(), admincookie["Center_ID"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int a = 0; a < ds.Tables[0].Rows.Count; a++)
                    {
                        string aaa;
                        aaa = ds.Tables[0].Rows[a].ItemArray[0].ToString();

                        if (aaa.ToString() == "M1")
                        {
                            //if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                            //{
                            //    M1.Visible = true;
                            //}
                            //else
                            //{
                            //    M1.Visible = false;
                            //}
                        }
                        //else if (aaa.ToString() == "M2")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M2.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M2.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M3")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M3.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M3.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M4")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M4.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M4.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M5")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M5.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M5.Visible = false;

                        //    }
                        //}
                        //else if (aaa.ToString() == "M6")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M6.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M6.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M7")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M7.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M7.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M8")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M8.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M8.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M9")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M9.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M9.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M10")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M10.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M10.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M11")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M11.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M11.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M12")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M12.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M12.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "M13")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        M13.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        M13.Visible = false;
                        //    }
                        //}


                        else if (aaa.ToString() == "S1")
                        {
                            //if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                            //{
                            //    S1.Visible = true;

                            //}
                            //else
                            //{
                            //    S1.Visible = false;
                            //}
                        }

                        else if (aaa.ToString() == "S2")
                        {
                            //if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                            //{
                            //    S2.Visible = true;

                            //}
                            //else
                            //{
                            //    S2.Visible = false;
                            //}
                        }
                        else if (aaa.ToString() == "S3")
                        {
                            //if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                            //{
                            //    S3.Visible = true;

                            //}
                            //else
                            //{
                            //    S3.Visible = false;

                            //}
                        }
                        //else if (aaa.ToString() == "S4")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S4.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S4.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S5")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S5.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S5.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S6")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S6.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S6.Visible = false;
                        //    }
                        //}

                        //else if (aaa.ToString() == "S7")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S7.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S7.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S8")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S8.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S8.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S9")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S9.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S9.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S10")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S10.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S10.Visible = false;

                        //    }
                        //}
                        //else if (aaa.ToString() == "S11")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S11.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S11.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S12")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S12.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S12.Visible = false;
                        //    }
                        //}

                        //else if (aaa.ToString() == "S13")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S13.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S13.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S14")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S14.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S14.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S15")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S15.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S15.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S16")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S16.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S16.Visible = false;

                        //    }
                        //}
                        //else if (aaa.ToString() == "S17")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S17.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S17.Visible = false;
                        //    }
                        //}


                        //else if (aaa.ToString() == "S18")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S18.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S18.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S19")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S19.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S19.Visible = false;
                        //    }
                        //}

                        //else if (aaa.ToString() == "S20")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S20.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S20.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S21")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S21.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S21.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S22")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S22.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S22.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S23")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S23.Visible = true;

                        //    }
                        //    else
                        //    {
                        //        S23.Visible = false;

                        //    }
                        //}
                        //else if (aaa.ToString() == "S24")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S24.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S24.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S25")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S25.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S25.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S26")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S26.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S26.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S27")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S27.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S27.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S28")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S28.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S28.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S29")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S29.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S29.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S30")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S30.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S30.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S31")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S31.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S31.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S32")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S32.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S32.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S33")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S33.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S33.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S34")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S34.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S34.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S35")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S35.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S35.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S36")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S36.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S36.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S37")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S37.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S37.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S38")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S38.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S38.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S39")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S39.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S39.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S40")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S40.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S40.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S41")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S41.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S41.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S42")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S42.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S42.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S43")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S43.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S43.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S44")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S44.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S44.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S45")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S45.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S45.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S46")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S46.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S46.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S47")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S47.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S47.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S48")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S48.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S48.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S49")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S49.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S49.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S50")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S50.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S50.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S51")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S51.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S51.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S52")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S52.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S52.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S53")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S53.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S53.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S54")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S54.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S54.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S55")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S55.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S55.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S56")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S56.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S56.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S57")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S57.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S57.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S58")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S58.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S58.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S59")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S59.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S59.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S60")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S60.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S60.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S61")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S61.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S61.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S62")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S62.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S62.Visible = false;
                        //    }
                        //}
                        //else if (aaa.ToString() == "S63")
                        //{
                        //    if (ds.Tables[0].Rows[a].ItemArray[1].ToString() == "True")
                        //    {
                        //        S63.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        S63.Visible = false;
                        //    }
                        //}

                    }
                }
                else
                {

                }
            }
        }

        catch
        {

        }
    }
}

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
using System.Data.SqlClient;
using System.IO;
using System.Net;

public partial class Admin_Admin_Update_Company_Info : System.Web.UI.Page
{
    string Connstr = ConfigurationManager.ConnectionStrings["dvinfosoft"].ConnectionString;
    DataSet ds = new DataSet();
    Admin_Update_Company_Info_C ac = new Admin_Update_Company_Info_C();
    MessageC m = new MessageC();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];
            if (admincookie != null) // means cookie is found
            {
                if (!IsPostBack)
                {
                    //User_ID,Companyname,Address,PhoneNo,Tin_No,Email,logo,Print_Size
                    DataSet ds = new DataSet();
                    ds = ac.Getinfo(admincookie["UserID"].ToString());
                    Label1.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    txtcompany.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    txtphone.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                    txttinno.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                    Image1.ImageUrl = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                    ddlprintmode.SelectedValue = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    txtcompany.Focus();
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
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];
            if (admincookie != null) // means cookie is found
            {
                string FileImg1 = "";
                if (FileUpload1.HasFile)
                {
                    FileImg1 = "~/logo/" + Guid.NewGuid().ToString();
                    string FExtension = Path.GetExtension(FileUpload1.FileName);
                    FileImg1 += FExtension;
                    FileUpload1.SaveAs(Server.MapPath(FileImg1));

                }
                else
                {
                    FileImg1 = Image1.ImageUrl;

                }
                
                ac.Updated_info(Label1.Text, txtcompany.Text, txtaddress.Text, txtphone.Text, txttinno.Text, txtemail.Text, FileImg1, ddlprintmode.SelectedValue);
                m.MsgScriptwith("Record Update...", "Admin_Update_Company_Info.aspx");

            }
            else
            {
                m.MsgScriptwith("Time Out", "index.aspx");
            }

        }
        catch
        {
        }
    }
}

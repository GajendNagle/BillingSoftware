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
using System.Security.Cryptography;

public partial class Admin_PrintInvoiceReceipt : System.Web.UI.Page
{
    string Connstr = ConfigurationManager.ConnectionStrings["dvinfosoft"].ConnectionString;
    DataSet ds = new DataSet();
    MessageC m = new MessageC();
        protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Button1.Attributes.Add("onClick", "CallPrint('divPrint')");
            HttpCookie adminCookie = Request.Cookies["AdminInfo"];

            if (adminCookie == null)
            {
                m.MsgScriptwith("Time Out", "../index.aspx");
                return;
            }
            string Pid = Request.QueryString["Pid"];
            if (string.IsNullOrEmpty(Pid))
            {
                Pid = ""; 
            }
            if (Session["DC_NO"] != null || !string.IsNullOrEmpty(Pid))
            {
                PrintData();
                CompanyData();
            }
        }
        catch (Exception ex)
        {
            throw ex; 
        }
    }

    public void PrintData()
    {
        using (SqlConnection conn = new SqlConnection(Connstr))
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select d.Customer_Name,d.Cust_Address,d.Mobile_no,d.Dc_Date,d.DC_No,d.Total_Amt,d.Total_Qty,i.TotalAmount from dbo.tblDcNO d inner join tblIncomeDetails i on i.Dc_No=d.DC_No where d.DC_No=@DC_No", conn);
            cmd.CommandType = CommandType.Text;
            string dcNo = "";
            if (Session["DC_NO"] != null)
            {
                dcNo = Session["DC_NO"].ToString();
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["Pid"]))
            {
                dcNo = Request.QueryString["Pid"].ToString();
            }

            cmd.Parameters.AddWithValue("@DC_No", dcNo);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblCustomerName.Text = reader["Customer_Name"].ToString();
                lblCustAddress.Text = reader["Cust_Address"].ToString();
                lblMobileNumber.Text = reader["Mobile_no"].ToString();
                lblOrderNo.Text = reader["DC_No"].ToString();
                lblOrderDate.Text =  Convert.ToDateTime(reader["Dc_Date"]).ToString("dd-MM-yyyy");
                //lbltotalQty.Text = reader["Total_Qty"].ToString();
                lbltotalAmount.Text = reader["Total_Amt"].ToString();
            }
            reader.Close();

            SqlCommand cmdGrid = new SqlCommand("select i.Product_Name,i.Product_Qty,i.Product_Rate from dbo.tblDcNO d inner join tblIncomeDetails i on i.Dc_No=d.DC_No where d.DC_No=@DC_No", conn);
            cmdGrid.CommandType = CommandType.Text;
            cmdGrid.Parameters.AddWithValue("@DC_No", dcNo);
            SqlDataAdapter sda = new SqlDataAdapter(cmdGrid);
            sda.Fill(ds);
            grdPrint.DataSource = ds;
            grdPrint.DataBind();

        }
    }
    public void CompanyData()
    {
        using (SqlConnection conn = new SqlConnection(Connstr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select c.Companyname,c.Email,c.Address,c.State_Name,c.MobileNo from  dbo.UserInfo c where c.User_ID=@User_ID", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@User_ID", 3);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblCompanyName.Text = reader["Companyname"].ToString();
                lblAddress.Text = reader["Address"].ToString();
                lblCompanyMobile.Text = reader["MobileNo"].ToString();
                //lblCompanyEmail.Text = reader["Email"].ToString();
            }
            reader.Close();
        }
    }
}
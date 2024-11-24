using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml;
using System.Text;

public partial class Admin_DeliveryChallanReport : System.Web.UI.Page
{
    string Connstr = ConfigurationManager.ConnectionStrings["dvinfosoft"].ConnectionString;
    DataSet ds = new DataSet();
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
                    admincookie["User_ID"].ToString();
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                    txtFromDate.Text = currentDate;
                    txtToDate.Text = currentDate;
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
    protected void txtDCNo_onTextChanged(object sender, EventArgs e)
    {
        string dcNo = txtDCNo.Text.Trim();

        if (string.IsNullOrEmpty(dcNo))
        {

            return;
        }

        using (SqlConnection conn = new SqlConnection(Connstr))
        {
            conn.Open();
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM dbo.tblDcNO WHERE DC_No = @DC_No", conn);
            checkCmd.Parameters.AddWithValue("@DC_No", dcNo);

            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                Response.Redirect("Update_DeliveryChallan.aspx?Id=" + dcNo);
            }
            else
            {
                txtDCNo.Text = string.Empty;
            }
        }
    }

    protected void btnSubmit_onClick(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(Connstr))
        {
            conn.Open();

            DateTime fromDate;
            DateTime toDate;

            // Try to parse the dates
            if (DateTime.TryParse(txtFromDate.Text, out fromDate) && DateTime.TryParse(txtToDate.Text, out toDate))
            {
                SqlCommand cmd = new SqlCommand("SELECT d.Dc_Date,d.Customer_Name,d.Cust_Address, d.Mobile_no,d.Total_Qty, d.DC_No, d.Total_Amt FROM dbo.tblDcNO d left JOIN " +
"tblIncomeDetails i ON i.Dc_No = d.DC_No" +
" WHERE d.Dc_Date BETWEEN @FromDate AND @ToDate " +
"group by d.Dc_Date,d.Customer_Name, d.Total_Qty,d.Cust_Address, d.Mobile_no, d.DC_No, d.Total_Amt order by DC_No", conn);
                cmd.CommandType = CommandType.Text;

                // Use parameters directly without converting to string
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds);
                grdDiv.Visible = true;
                grdReportData.DataSource = ds;
                grdReportData.DataBind();
            }
            else
            {
                ErrorMsg.Visible = true;
            }
        }
    }
    protected void grdReportData_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        if (e.CommandName == "EditRecord")
        {
            Response.Redirect("Update_DeliveryChallan.aspx?DCId=" + e.CommandArgument);
        }
        if (e.CommandName == "PrintRecord")
        {
            Response.Redirect("PrintInvoiceReceipt.aspx?Pid=" + e.CommandArgument);
         
        }
    }
}
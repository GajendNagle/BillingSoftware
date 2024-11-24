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
using iTextSharp.text.xml;

public partial class Admin_Delivery_Challan : System.Web.UI.Page
{
    string Connstr = ConfigurationManager.ConnectionStrings["dvinfosoft"].ConnectionString;
    DataSet ds = new DataSet();
    MessageC m = new MessageC();
    DataTable dt = new DataTable();
    private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];
            if (admincookie == null)
            {
                admincookie["User_ID"].ToString();
                m.MsgScriptwith("Time Out", "../index.aspx");
            }
            if (!IsPostBack)
            {
                txtDate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
                if (ViewState["Data"] != null)
                {
                    grdReceiptData.DataSource = ViewState["Data"] as DataTable;
                    grdReceiptData.DataBind();
                }
            }
        }
        catch
        {
        }
    }
    protected void btnAdd_onClick(object sender, EventArgs e)
    {
        if (ViewState["Data"] != null)
        {
            DataTable dt1 = ViewState["Data"] as DataTable;
            bool isDuplicate = false;
            foreach (DataRow row in dt1.Rows)
            {
                if (row["ItemName"].ToString() == txtItemName.Text &&
                    row["Rate"].ToString() == txtRate.Text)
                {
                    isDuplicate = true;
                    int newQuantity = int.Parse(txtQuantity.Text) + int.Parse(row["Qty"].ToString());
                    decimal newTotalAmount = newQuantity * decimal.Parse(row["Rate"].ToString());
                    row["Qty"] = newQuantity;
                    row["TotalAmount"] = newTotalAmount;
                    break;
                }
            }

            if (!isDuplicate)
            {
                dt1.Rows.Add(txtItemName.Text, txtQuantity.Text, txtRate.Text, Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text));
            }
            grdReceiptData.DataSource = dt1;
            grdReceiptData.DataBind();
        }
        else
        {
            dt.Columns.Add("ItemName");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Rate");
            dt.Columns.Add("TotalAmount");
            dt.Rows.Add(txtItemName.Text, txtQuantity.Text, txtRate.Text, Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text));
            grdReceiptData.DataSource = dt;
            grdReceiptData.DataBind();
            ViewState["Data"] = dt;
        }
        GetTempData();
        ClearField();
        btnSubmit.Visible = true;
    }
    protected void ClearField()
    {
        txtItemName.Text = String.Empty;
        txtQuantity.Text = String.Empty;
        txtRate.Text = String.Empty;
    }
    protected void btnSubmit_onClick(object sender, EventArgs e)
    {
        try
        {
            HttpCookie admincookie = Request.Cookies["AdminInfo"];

            if (admincookie != null)
            {
                using (SqlConnection conn = new SqlConnection(Connstr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("USP_InsertDcNO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ViewState["Data"] != null)
                    {
                        cmd.Parameters.AddWithValue("@Mobile_Number", txtMobileNumber.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Customer_Name", txtCustumerName.Text);
                        DataTable dt1 = ViewState["Data"] as DataTable;
                        cmd.Parameters.AddWithValue("@Customer_Details", dt1);
                        cmd.Parameters.AddWithValue("@Total_Qty", lbltotqty.Text);
                        cmd.Parameters.AddWithValue("@CreatedById", admincookie["User_ID"].ToString());
                        cmd.Parameters.AddWithValue("@TotalAmt", lbltotalamt.Text);
                        txtDate.Text= TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE).ToString("dd-MM-yyyy");
                        cmd.Parameters.AddWithValue("@DC_Date",txtDate.Text);
                        SqlParameter outputParam = new SqlParameter("@Dc_Id", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);
                        cmd.ExecuteNonQuery();
                        int dcId = Convert.ToInt32(outputParam.Value);
                        Session["DC_NO"] = dcId;
                        ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "alert('Successfully Added Items');", true);
                        Response.Redirect("PrintInvoiceReceipt.aspx");
                        pnlReceiptData.Visible = false;
                        ViewState.Clear();
                        cmd.ExecuteNonQuery();
                    }
                    ClearField();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void GetTempData()
    {
        try
        {
            decimal totalQuantity = 0;
            decimal totalAmount = 0;
            DataTable dt = ViewState["Data"] as DataTable;
            pnlReceiptData.Visible = true;
            foreach (DataRow row in dt.Rows)
            {
                totalQuantity += Convert.ToDecimal(row["Qty"].ToString());
                totalAmount += decimal.Parse(row["TotalAmount"].ToString());
            }

            lbltotqty.Text = totalQuantity.ToString();
            lbltotalamt.Text = totalAmount.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdReceiptData_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteItem")
        {
            if (ViewState["Data"] != null)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = (DataTable)ViewState["Data"];
                dt.Rows.RemoveAt(index);
                ViewState["Data"] = dt;
                grdReceiptData.DataSource = dt;
                grdReceiptData.DataBind();
                GetTempData();
            }
        }
    }
}


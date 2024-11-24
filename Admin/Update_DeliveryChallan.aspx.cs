using System;
using System.Collections.Generic;
using System.Linq;
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

public partial class Admin_Update_DeliveryChallan : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    string receivedValue = string.Empty;
    string Connstr = ConfigurationManager.ConnectionStrings["dvinfosoft"].ConnectionString;
    DataSet ds = new DataSet();
    MessageC m = new MessageC();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie adminCookie = Request.Cookies["AdminInfo"];

            if (adminCookie == null)
            {
                m.MsgScriptwith("Time Out", "../index.aspx");
                return;
            }
            receivedValue = Request.QueryString["DCId"] ?? Request.QueryString["Id"];
            if (!IsPostBack && !string.IsNullOrEmpty(receivedValue))
            {
                ViewState["ReceivedValue"] = receivedValue;
                EditableData();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void EditableData()
    {
        using (SqlConnection conn = new SqlConnection(Connstr))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(
                " select convert(varchar,Dc_Date ,105 ) Dc_Date ,Customer_Name, Cust_Address,Mobile_no,DC_No from   dbo.tblDcNO " +
                " WHERE DC_No = @DC_No ", conn))
            {
                cmd.Parameters.AddWithValue("@DC_No", receivedValue);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtAddress.Text = reader["Cust_Address"].ToString();
                        txtCustomerName.Text = reader["Customer_Name"].ToString();
                        txtMobileNumber.Text = reader["Mobile_no"].ToString();
                        txtdate.Text = Convert.ToDateTime(reader["Dc_Date"]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        ClearFields();
                    }
                }
                DataTable dt = new DataTable();
                using (SqlCommand cmd2 = new SqlCommand("SELECT Details_Id,Product_Name, Product_Qty,Product_Rate,TotalAmount  FROM tblIncomeDetails   WHERE Dc_No = @DC_No", conn))
                {
                    cmd2.Parameters.AddWithValue("@DC_No", receivedValue);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd2))
                    {
                        da.Fill(dt);
                        grdReportData.DataSource = dt;
                        grdReportData.DataBind();

                    }
                    DataTable filteredData = dt.DefaultView.ToTable(false, "Product_Name", "Product_Qty", "Product_Rate", "TotalAmount");
                    ViewState["Data"] = filteredData;

                }

            }
        }
    }
    protected void ClearFields()
    {
        txtAddress.Text = "";
        txtCustomerName.Text = "";
        txtMobileNumber.Text = "";
    }
    protected void grdReportData_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

        if (e.CommandName == "DeleteRecord")
        {

            DataTable dt = ViewState["Data"] as DataTable;
            if (dt != null)
            {
                dt.Rows.RemoveAt(row.RowIndex);
                grdReportData.DataSource = dt;
                grdReportData.DataBind();
                btnSubmit.Visible = true;
            }

            //string id = e.CommandArgument.ToString();

            //using (SqlConnection conn = new SqlConnection(Connstr))
            //{
            //    conn.Open();

            //    using (SqlTransaction transaction = conn.BeginTransaction())
            //    {
            //        try
            //        {

            //            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM tblIncomeDetails WHERE Details_Id = @Details_Id;", conn, transaction))
            //            {
            //                cmd1.Parameters.AddWithValue("@Details_Id", id);
            //                cmd1.ExecuteNonQuery();
            //            }
            //            transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            transaction.Rollback();
            //        }
            //    }
            //}
            //EditableData();

        }
    }
    protected void btnAdd_onClick(object sender, EventArgs e)
    {
        DataTable dt1 = ViewState["Data"] as DataTable;

        if (dt1 == null)
        {
            dt1 = new DataTable();
            dt1.Columns.Add("Product_Name");
            dt1.Columns.Add("Product_Qty", typeof(int));
            dt1.Columns.Add("Product_Rate", typeof(decimal));
            dt1.Columns.Add("TotalAmount", typeof(decimal));

        }

        bool isDuplicate = false;
        foreach (DataRow row in dt1.Rows)
        {

            if (row["Product_Name"].ToString() == txtItemName.Text &&
                row["Product_Rate"].ToString() == txtRate.Text)
            {
                isDuplicate = true;
                int newQuantity = Convert.ToInt32(row["Product_Qty"]) + Convert.ToInt32(txtQuantity.Text);
                decimal newTotalAmount = newQuantity * Convert.ToDecimal(txtRate.Text);

                row["Product_Qty"] = newQuantity;
                row["TotalAmount"] = newTotalAmount;
                break;
            }
        }
        if (!isDuplicate)
        {

            int newQuantity = Convert.ToInt32(txtQuantity.Text);
            decimal newTotalAmount = newQuantity * Convert.ToDecimal(txtRate.Text);
            dt1.Rows.Add(txtItemName.Text, newQuantity, txtRate.Text, newTotalAmount);
        }
        grdReportData.DataSource = dt1;
        grdReportData.DataBind();
        ViewState["Data"] = dt1;
        ClearField();
        btnSubmit.Visible = dt1.Rows.Count > 0;
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

            if (admincookie != null && !string.IsNullOrEmpty(admincookie["User_ID"]))
            {
                using (SqlConnection conn = new SqlConnection(Connstr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[USP_UpdateDcNO]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (ViewState["Data"] != null)
                    {
                        DataTable dt1 = ViewState["Data"] as DataTable;
                        cmd.Parameters.AddWithValue("@Customer_Details", dt1);
                        cmd.Parameters.AddWithValue("@Mobile_Number", txtMobileNumber.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@Customer_Name", txtCustomerName.Text);
                        cmd.Parameters.AddWithValue("@DC_Date", DateTime.Now); // DateTime object directly
                        cmd.Parameters.AddWithValue("@Total_Qty", lbltotqty.Text);
                        cmd.Parameters.AddWithValue("@UpdatedById", admincookie["User_ID"].ToString());
                        cmd.Parameters.AddWithValue("@TotalAmt", lbltotalamt.Text);
                        cmd.Parameters.AddWithValue("@Dc_Id", receivedValue); // Ensure receivedValue is set correctly

                        try
                        {
                            cmd.ExecuteNonQuery();
                            ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "alert('Successfully Update Items');", true);
                        }
                        catch (SqlException sqlEx)
                        {
                            // Handle SQL exceptions
                            throw new Exception("Database error: " + sqlEx.Message);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("ViewState['Data'] is null.");
                    }
                    btnSubmit.Visible = false;
                    ClearField();
                }
            }
            else
            {
                throw new InvalidOperationException("AdminInfo cookie or User_ID is missing.");
            }
        }
        catch (Exception ex)
        {
            // Log or handle the general exception
            throw new Exception("Error occurred: " + ex.Message);
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
}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Admin_Home_C
/// </summary>
public class Admin_Home_C
{
    static string _venid;
    public string venid
    {
        get
        {
            return (_venid);
        }
        set
        {
            _venid = value;
        }
    }

    SqlConnection cn = new SqlConnection(ConnectionC.con());
    public DataSet GetAllPlant(object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT PID,Plant_Name from Plant_Master where  Center_ID='" + Center_ID + "' order by Plant_Name";
        SqlDataAdapter adop = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        adop.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataSet GetSample_Receive_Status_Pending_Group()
    {
        cn.Close();
        cn.Open();
        string str = "SELECT s.Plant_ID,s.Plant_Barcode,pla.Plant_Name FROM Product_Sample_Master s,Plant_Master pla where pla.PID=s.Plant_ID and s.Sample_Receive_Status='Pending' group by s.Plant_ID,s.Plant_Barcode,pla.Plant_Name order by s.Plant_ID";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet GetSample_Receive_Status_Pending(object Plant_ID)
    {
        cn.Close();
        cn.Open();
        string str = "SELECT s.SID,s.Sample_Barcode,s.Plant_ID,s.Plant_Barcode,pla.Plant_Name,s.Product_ID,s.Product_Barcde,pro.Pro_Name,s.Sample_Date,s.Samlpe_Time,s.Sample_Collector_ID,s.Sample_Status,s.Samle_Collect_Status,s.Sample_Receive_Status,s.Sample_Point_ID,s.Sample_Point_Barcode,ss.Sample_Name as Sample_Point_Name,s.Sample_Collect_Date,s.Sample_Collect_Time,s.Driver_ID FROM Product_Sample_Master s,Plant_Master pla,Product_Master pro , Sample_Point_Master ss where ss.SP_ID=s.Sample_Point_ID and pla.PID=s.Plant_ID and pro.Pro_ID=s.Product_ID and s.Plant_ID='" + Plant_ID + "' and s.Sample_Receive_Status='Pending' order by s.SID ";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet GetNameemployee(object User_ID)
    {
        cn.Close();
        cn.Open();
        string str = "SELECT Companyname from  UserInfo where User_ID='" + User_ID + "'";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public void Update_Sample_Status_Lab(object SID, object Sample_Barcode, object Sample_Receive_Date, object Sample_Receive_Time, object Sample_Receive_Status, object Sample_Receiver_ID, object Samle_Collect_Status)
    {
        cn.Close();
        cn.Open();
        string str = "Update Product_Sample_Master set Sample_Receive_Date=@Sample_Receive_Date,Sample_Receive_Time=@Sample_Receive_Time,Sample_Receive_Status=@Sample_Receive_Status,Sample_Receiver_ID=@Sample_Receiver_ID,Samle_Collect_Status=@Samle_Collect_Status where SID=@SID and Sample_Barcode=@Sample_Barcode";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;
        SqlParameter p = new SqlParameter("@SID", SqlDbType.BigInt);
        p.Direction = ParameterDirection.Input;
        p.Value = SID;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Sample_Barcode", SqlDbType.VarChar);
        p.Value = Sample_Barcode;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Sample_Receive_Date", SqlDbType.VarChar);
        p.Value = Sample_Receive_Date;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Sample_Receive_Time", SqlDbType.VarChar);
        p.Value = Sample_Receive_Time;
        cmd.Parameters.Add(p);


        p = new SqlParameter("@Sample_Receive_Status", SqlDbType.VarChar);
        p.Value = Sample_Receive_Status;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Sample_Receiver_ID", SqlDbType.BigInt);
        p.Value = Sample_Receiver_ID;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Samle_Collect_Status", SqlDbType.VarChar);
        p.Value = Samle_Collect_Status;
        cmd.Parameters.Add(p);

        cmd.ExecuteNonQuery();
        cn.Close();
    }

    public DataSet GetCheckBarcode(object Sample_Barcode)
    {
        cn.Close();
        cn.Open();
        string str = "SELECT SID,Sample_Barcode FROM Product_Sample_Master where Sample_Barcode='" + Sample_Barcode + "' and Sample_Receive_Status='Pending'";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }


    public DataSet GetSample_Receive_Status_All_Datewise_Group(object fromdate, object todate)
    {
        cn.Close();
        cn.Open();
        string str = "SELECT s.Plant_ID,s.Plant_Barcode,pla.Plant_Name FROM Product_Sample_Master s,Plant_Master pla where pla.PID=s.Plant_ID and convert(datetime,s.Sample_Date,105) between convert(datetime,'" + fromdate + "',105) and convert(datetime,'" + todate + "',105)   group by s.Plant_ID,s.Plant_Barcode,pla.Plant_Name order by s.Plant_ID";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet GetSample_Receive_Status_Datewise(object Plant_ID, object fromdate, object todate)
    {
        cn.Close();
        cn.Open();
        string str = "SELECT s.SID,s.Sample_Barcode,s.Plant_ID,s.Plant_Barcode,pla.Plant_Name,s.Product_ID,s.Product_Barcde,pro.Pro_Name,s.Sample_Date,s.Samlpe_Time,s.Sample_Collector_ID,s.Sample_Status,s.Samle_Collect_Status,s.Sample_Receive_Status,s.Sample_Point_ID,s.Sample_Point_Barcode,ss.Sample_Name as Sample_Point_Name,s.Sample_Collect_Date,s.Sample_Collect_Time,s.Driver_ID,s.Sample_Receive_Date,s.Sample_Receive_Time,s.Sample_Receiver_ID FROM Product_Sample_Master s,Plant_Master pla,Product_Master pro , Sample_Point_Master ss where ss.SP_ID=s.Sample_Point_ID and pla.PID=s.Plant_ID and pro.Pro_ID=s.Product_ID and s.Plant_ID='" + Plant_ID + "' and convert(datetime,s.Sample_Date,105) between convert(datetime,'" + fromdate + "',105) and convert(datetime,'" + todate + "',105) order by s.SID ";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet GetSample_Receive_Status_All_Datewise_Group_plantwise(object fromdate, object todate, object Plant_ID)
    {
        cn.Close();
        cn.Open();
        string str = "SELECT s.Plant_ID,s.Plant_Barcode,pla.Plant_Name FROM Product_Sample_Master s,Plant_Master pla where pla.PID=s.Plant_ID and s.Plant_ID='" + Plant_ID + "' and convert(datetime,s.Sample_Date,105) between convert(datetime,'" + fromdate + "',105) and convert(datetime,'" + todate + "',105)   group by s.Plant_ID,s.Plant_Barcode,pla.Plant_Name order by s.Plant_ID";
        SqlDataAdapter da = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
}

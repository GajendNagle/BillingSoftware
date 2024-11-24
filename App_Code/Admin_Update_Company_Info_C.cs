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
public class Admin_Update_Company_Info_C
{
    SqlConnection cn = new SqlConnection(ConnectionC.con());
    public DataSet Getinfo(object User_ID)
    {
        cn.Open();
        string sql = "select User_ID,Companyname,Address,PhoneNo,GSTin_No,Email,logo,Print_Size from UserInfo where User_ID='" + User_ID + "' and Role='Admin'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    public void Updated_info(object User_ID, object Companyname, object Address, object PhoneNo, object GSTin_No, object Email, object logo, object Print_Size)
    {
        cn.Open();
        string sql = "Update UserInfo set Companyname=@Companyname,Address=@Address,PhoneNo=@PhoneNo,GSTin_No=@GSTin_No,Email=@Email,logo=@logo,Print_Size=@Print_Size where User_ID=@User_ID";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@User_ID", SqlDbType.BigInt);
        p1.Direction = ParameterDirection.Input;
        p1.Value = User_ID;

        cmd.Parameters.Add(p1);
        p1 = new SqlParameter("@Companyname", SqlDbType.VarChar);
        p1.Value = Companyname;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Address", SqlDbType.VarChar);
        p1.Value = Address;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@PhoneNo", SqlDbType.VarChar);
        p1.Value = PhoneNo;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@GSTin_No", SqlDbType.VarChar);
        p1.Value = GSTin_No;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Email", SqlDbType.VarChar);
        p1.Value = Email;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@logo", SqlDbType.VarChar);
        p1.Value = logo;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Print_Size", SqlDbType.VarChar);
        p1.Value = Print_Size;
        cmd.Parameters.Add(p1);

        cmd.ExecuteNonQuery();
        cn.Close();
    }
}

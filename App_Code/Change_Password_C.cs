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
/// Summary description for Change_Password_C
/// </summary>
public class Change_Password_C
{
    SqlConnection cn = new SqlConnection(ConnectionC.con());

    public bool Get_AdminAutontication1(object User_ID, object Password, object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "select * from UserInfo where User_ID='" + User_ID + "' and Password='" + Password + "' and Center_ID='" + Center_ID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Get_AdminUpdate_Passward(object User_ID, object Password, object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "update UserInfo set Password=@Password where User_ID=@User_ID and Center_ID=@Center_ID";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@User_ID", SqlDbType.BigInt);
        p1.Value = User_ID;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Password", SqlDbType.VarChar);
        p1.Value = Password;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Center_ID", SqlDbType.BigInt);
        p1.Value = Center_ID;
        cmd.Parameters.Add(p1);

        cmd.ExecuteNonQuery();
        cn.Close();
    }
}

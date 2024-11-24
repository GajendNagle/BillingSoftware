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
/// Summary description for Menu_Permistion_C
/// </summary>
public class Menu_Permistion_C
{
    SqlConnection cn = new SqlConnection(ConnectionC.con());

    public void Insert_Menu_Details(object Menu_ID, object Show, object Employee_ID, object Section_Master, object Center_ID)
    {
        cn.Close();
        cn.Open();
        string str = "insert into Menu_Permition(Menu_ID,Show,Employee_ID,Section_Master,Center_ID)values(@Menu_ID,@Show,@Employee_ID,@Section_Master,@Center_ID)";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p = new SqlParameter("@Menu_ID", SqlDbType.VarChar);
        p.Direction = ParameterDirection.Input;
        p.Value = Menu_ID;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Show", SqlDbType.VarChar);
        p.Value = Show;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Employee_ID", SqlDbType.BigInt);
        p.Value = Employee_ID;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Section_Master", SqlDbType.VarChar);
        p.Value = Section_Master;
        cmd.Parameters.Add(p);

        p = new SqlParameter("@Center_ID", SqlDbType.BigInt);
        p.Value = Center_ID;
        cmd.Parameters.Add(p);

        cmd.ExecuteNonQuery();
        cn.Close();
    }

    public DataSet Getmenuemployeewise(object Employee_ID, object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT Menu_ID,Show from Menu_Permition where Employee_ID='" + Employee_ID + "' and Center_ID='" + Center_ID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }

    public void Delete_Category_Master(object Employee_ID, object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "Delete from Menu_Permition where Employee_ID='" + Employee_ID + "' and Center_ID='" + Center_ID + "' ";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
        cn.Close();
    }

    public DataSet Getmenuemployeewisemenue(object Employee_ID, object Menu_ID,object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT Show from Menu_Permition where Employee_ID='" + Employee_ID + "' and Menu_ID='" + Menu_ID + "' and Center_ID='"+ Center_ID + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataSet GetMenu()
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT ID,Menu_Name from Admin_Top_Menu order by ID";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataSet GetSubMenu(object TID)
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT SID,S_Menu_Name from Admin_Sab_Menu where TID='" + TID + "' ";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    ///Super Admin
    ///
    public DataSet Getmenuemployeewise_admin(object Employee_ID, object Section_Master)
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT Menu_ID,Show from SuperAdmin_MenuPermission where Employee_ID='" + Employee_ID + "' and Section_Master='" + Section_Master + "'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }

}

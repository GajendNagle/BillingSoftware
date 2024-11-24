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
public class LoginC
{
    SqlConnection cn = new SqlConnection(ConnectionC.con());

    public bool Userexist(object User_Name, object Password)
    {
        cn.Close();
        cn.Open();
        string sql = "select User_Name,Password from UserInfo where User_Name=@User_Name and Password=@Password and Status='Yes'";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@User_Name", SqlDbType.VarChar);
        p1.Direction = ParameterDirection.Input;
        p1.Value = User_Name;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Password", SqlDbType.VarChar);
        p1.Value = Password;
        cmd.Parameters.Add(p1);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public bool Userexist1(object Mobile, object Password)
    {
        cn.Close();
        cn.Open();
        string sql = "select Member_Name,Password from Member_Registraion where Mobile=@Mobile and Password=@Password";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@Mobile", SqlDbType.VarChar);
        p1.Direction = ParameterDirection.Input;
        p1.Value = Mobile;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Password", SqlDbType.VarChar);
        p1.Value = Password;
        cmd.Parameters.Add(p1);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public string FetchUserRagistrationNo(object User_Name, object Password)
    {
        cn.Close();
        cn.Open();
        string str = "select User_ID from UserInfo where User_Name=@User_Name and Password=@Password";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@User_Name", SqlDbType.VarChar);
        p1.Direction = ParameterDirection.Input;
        p1.Value = User_Name;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Password", SqlDbType.VarChar);
        p1.Value = Password;
        cmd.Parameters.Add(p1);        
      
        SqlDataReader rd;
        rd = cmd.ExecuteReader();
        rd.Read();
        if (rd.HasRows)
        {
            string i;
            i = rd["User_ID"].ToString();
            cn.Close();
            return i;
        }
        else
            return "Continue";
    }
    public string FetchUserRagistrationfrom(object Mobile, object Password)
    {
        cn.Close();
        cn.Open();
        string str = "select Member_ID from Member_Registraion where Mobile=@Mobile and Password=@Password";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@Mobile", SqlDbType.VarChar);
        p1.Direction = ParameterDirection.Input;
        p1.Value = Mobile;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Password", SqlDbType.VarChar);
        p1.Value = Password;
        cmd.Parameters.Add(p1);

        SqlDataReader rd;
        rd = cmd.ExecuteReader();
        rd.Read();
        if (rd.HasRows)
        {
            string i;
            i = rd["Member_ID"].ToString();
            cn.Close();
            return i;
        }
        else
            return "Continue";
    }

    public string FetchUserRoleStaffID(object User_Name, object Password)
    {
        cn.Close();
        cn.Open();
        string str = "select Designation_ID  from Staff_Master where Login_ID in(select User_ID from UserInfo where User_Name=@User_Name and Password=@Password)";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@User_Name", SqlDbType.VarChar);
        p1.Direction = ParameterDirection.Input;
        p1.Value = User_Name;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Password", SqlDbType.VarChar);
        p1.Value = Password;
        cmd.Parameters.Add(p1);

        SqlDataReader rd;
        rd = cmd.ExecuteReader();
        rd.Read();
        if (rd.HasRows)
        {
            string i;
            i = rd["Designation_ID"].ToString();
            cn.Close();
            return i;
        }
        else
            return "Continue";
    }

    public DataSet Fetch_Detail(object User_ID)
    {
        cn.Close();
        cn.Open();
        string str = "select User_ID,User_Name,Companyname,Role,Center_ID,State_Code from UserInfo where User_ID=@User_ID";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@User_ID", SqlDbType.BigInt);
        p1.Direction = ParameterDirection.Input;
        p1.Value = User_ID;
        cmd.Parameters.Add(p1);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataSet Fetch_Detail1(object Member_ID)
    {
        cn.Close();
        cn.Open();
        string str = "select Member_ID,Member_Name,Center_ID from Member_Registraion where Member_ID=@Member_ID";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@Member_ID", SqlDbType.BigInt);
        p1.Direction = ParameterDirection.Input;
        p1.Value = Member_ID;
        cmd.Parameters.Add(p1);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataSet GetTrialDate()
    {
        cn.Close();
        cn.Open();
        string str = "select Trail_Date from Trail_Version_Table";
        SqlCommand cmd = new SqlCommand(str, cn);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        cn.Close();
        return ds;
    }
    public DataSet Fetch_Center_Detail(object Center_ID)
    {
        cn.Close();
        cn.Open();
        string str = "select State_Code,Bill_Size,Unit_ID,Parent_ID from Center_Master where Center_ID=@Center_ID";
        SqlCommand cmd = new SqlCommand(str, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@Center_ID", SqlDbType.BigInt);
        p1.Direction = ParameterDirection.Input;
        p1.Value = Center_ID;
        cmd.Parameters.Add(p1);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cn.Close();
        return ds;
    }



    public DataSet Getmenuemployeewise(object Employee_ID, object Center_ID)
    {
        cn.Close();
        cn.Open();
        string sql = "SELECT Menu_ID,Show from Menu_Permition where Employee_ID=@Employee_ID and Center_ID=@Center_ID";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.CommandType = CommandType.Text;

        SqlParameter p1 = new SqlParameter("@Employee_ID", SqlDbType.VarChar);
        p1.Direction = ParameterDirection.Input;
        p1.Value = Employee_ID;
        cmd.Parameters.Add(p1);

        p1 = new SqlParameter("@Center_ID", SqlDbType.BigInt);
        p1.Value = Center_ID;
        cmd.Parameters.Add(p1);


        SqlDataAdapter adop = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adop.Fill(ds);
        cn.Close();
        return ds;
    }

    static string _centerid;
    public string centerid
    {
        get
        {
            return (_centerid);
        }
        set
        {
            _centerid = value;
        }
    }
}

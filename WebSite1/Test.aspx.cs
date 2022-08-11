using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.Sql;

public partial class Test : System.Web.UI.Page
{
    //数据连接最基本需要的两个对象  
    private SqlConnection conn = null;
    private SqlCommand cmd = null;
    //private SqlDataAdapter adapter = null;  
    //为了方便，设为全局对象的sql语句  
    private string sql = null;

    //公用 打开数据库的方法  
    public void openDatabase()
    {
        conn = new SqlConnection();
        //conn.ConnectionString = "Data Source=.;Initial Catalog=DB_weng;User ID=weng;";
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
    }

    public void load()
    {
        openDatabase();
        //cmd = new SqlCommand("select * from users where age=(select max(age) from users)", conn);
        //SqlDataReader dr = cmd.ExecuteReader();
        //if (dr.Read())
        //{
        //   TextBox1.Text = (String)dr[1].ToString().Trim();
        //   TextBox2.Text = (String)dr[2].ToString().Trim();
        //}
        conn.Close();
    }

    //根据sql语句加载信息，重载两个textbox  
    public void load(String sql)
    {
        openDatabase();
        cmd = new SqlCommand(sql, conn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            TextBox1.Text= (String)dr[1].ToString().Trim();
            TextBox2.Text= (String)dr[2].ToString().Trim();
        }
        conn.Close();
    }

    //封装的数据库语句执行的方法  
    public void execute(String sql)
    {
        openDatabase();
        cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    //页面加载时ASP.NET首先会调用这个方法  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { load(); }//如果页面不是刷新，则执行，这个很重要  
    }

    //四个按钮的方法，增删改查  
    protected void Button1_Click(object sender, EventArgs e)
    {
        sql = "insert into users(name,age) values('" + TextBox1.Text.ToString().Trim() + "','" + TextBox2.Text.ToString().Trim() + "')";
        execute(sql);
        Response.Write("<script>alert('增加成功');</script>");
        load();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        sql = "delete from users where name='" + TextBox1.Text.ToString().Trim() + "' and age='" + TextBox2.Text.ToString().Trim() + "'";
        execute(sql);
        Response.Write("<script>alert('删除成功');</script>");
        load();
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        sql = "update  users set age='" + TextBox1.Text.ToString().Trim() + "' where name='" + TextBox2.Text.ToString().Trim() + "'";
        execute(sql);
        Response.Write("<script>alert('修改成功');</script>");
        load();
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        sql = "select * from users where name='" + TextBox1.Text.ToString().Trim() + "'";
        load(sql);
        Response.Write("<script>alert('查询成功');</script>");
        load();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            Login();
        }
        else
        {
            Response.Write("<script>alert('账号和密码不能为空');</script>");
        }
    }





    public void Login()
    {
        if (RadioButton1.Checked == true)
        {
            openDatabase();
            string sql = $"select * from sc where sno='{TextBox1.Text}' and cno='{TextBox2.Text}'";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Response.Write("<script>alert('登录成功');</script>");
                System.Threading.Thread.Sleep(1000);    //1秒
                //Response.Write("<script>alert('登录成功!');window.location.href='http://www.baidu.com';</script>");

                string url = "http://www.baidu.com";
                Response.Write("<script language='javascript'>alert('登录成功');window.open('" + url + "','','resizable=1,scrollbars=0,status=1,menubar=no,toolbar=no,location=no, menu=no');</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败');</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            conn.Close();
        }
        else if (RadioButton2.Checked == true)
        {
            openDatabase();
            string sql = $"select * from stu where sno='{TextBox1.Text}' and age='{TextBox2.Text}'";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string url = "http://www.baidu.com";
                Response.Write("<script language='javascript'>alert('登录成功');window.open('" + url + "','','resizable=1,scrollbars=0,status=1,menubar=no,toolbar=no,location=no, menu=no');</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败');</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            conn.Close();
        }
        else
        {
            openDatabase();
            string sql = $"select * from course where cno='{TextBox1.Text}' and 学分='{TextBox2.Text}'";
            cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string url = "http://www.baidu.com";
                Response.Write("<script language='javascript'>alert('登录成功');window.open('" + url + "','','resizable=1,scrollbars=0,status=1,menubar=no,toolbar=no,location=no, menu=no');</script>");
            }
            else
            {
                Response.Write("<script>alert('登录失败');</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            conn.Close();
        }
        
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        sql = "insert into users(name,age) values('" + TextBox1.Text.ToString().Trim() + "','" + TextBox2.Text.ToString().Trim() + "')";
        execute(sql);
        Response.Write("<script>alert('注册成功');</script>");
        load();
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}
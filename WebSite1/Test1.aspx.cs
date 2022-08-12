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

public partial class Test1 : System.Web.UI.Page
{
    private SqlConnection conn = null;
    private SqlCommand cmd = null;
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

    //默认加载页面的方法 找到年龄最大的加载  
    //有些问题，年龄不能相同，加载中前台的textbox里只能显示一条记录，数据拿到之后有多条只显示一条  
    public void load()
    {
        openDatabase();
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
            TextBox1.Text = (String)dr[1].ToString().Trim();
            TextBox2.Text = (String)dr[2].ToString().Trim();
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { load();
        }//如果页面不是刷新，则执行，这个很重要  
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = $"select postname,class from post where postname='{TextBox1.Text}' or class='{TextBox2.Text}' ";
        openDatabase();
        SqlCommand command = new SqlCommand(sql, conn);
        SqlDataReader dr = command.ExecuteReader();
        //查询功能
        if (TextBox1.Text==null || TextBox1.Text=="")
        {
            if (!dr.Read())
            {
                Response.Write("<script>alert('没有查询到该数据');</script>");
            }
            else
            {
                string sql3 = $"select class from post where class='{TextBox2.Text}'";
                var sql2 = $"select * from post where class like '%{TextBox2.Text}%'";
                sql2 = string.Format(sql2, TextBox2.Text.Trim());
                SqlDataSource1.SelectCommand = sql2;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }  
        }
        else if(TextBox2.Text == null || TextBox2.Text == "")
        {
            if (!dr.Read())
            {
                Response.Write("<script>alert('没有查询到该数据');</script>");
            }
            else
            {
                string sql4 = $"select postname from post where postname='{TextBox1.Text}'";
                var sql1 = $"select * from post where postname like '%{TextBox1.Text}%'";
                sql1 = string.Format(sql1, TextBox1.Text.Trim());
                SqlDataSource1.SelectCommand = sql1;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }    
        }
        else
        {
            if (!dr.Read())
            {
                Response.Write("<script>alert('没有查询到该数据');</script>");
            }
            else
            {
                var sql3 = $"select * from post where postname like '%{TextBox1.Text}%' and class like '%{TextBox2.Text}%'";
                sql3 = string.Format(sql3, TextBox1.Text.Trim(), TextBox2.Text.Trim());
                SqlDataSource1.SelectCommand = sql3;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }  
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Table();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //GridView1.Columns.Clear();//把控件中已知的数据清除
        string sql = "select * from post";
        ShowTable(sql);
    }

    public void ShowTable(string sql)
    {
        SqlDataSource1.SelectCommand = sql;
        GridView1.DataSourceID = SqlDataSource1.ID;
        GridView1.DataBind();
    }
}
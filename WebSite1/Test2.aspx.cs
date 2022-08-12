using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.Sql;
using System.Web.UI.WebControls;

public partial class Test2 : System.Web.UI.Page
{
    private SqlConnection conn = null;
    private SqlCommand cmd = null;
    private string sql = null;

    public void openDatabase()
    {
        conn = new SqlConnection();
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
    }
    public void load()
    {
        openDatabase();
        conn.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();
        }//如果页面不是刷新，则执行，这个很重要  
    }
    public void ShowTable(string sql)
    {
        SqlDataSource1.SelectCommand = sql;
        GridView1.DataSourceID = SqlDataSource1.ID;
        GridView1.DataBind();
    }

    public void load(string sql11)
    {
        openDatabase();
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = sql11;
        cmd = new SqlCommand(sql11, conn);
        SqlDataReader dr1 = cmd.ExecuteReader();
        if (!dr1.Read())
        {
            Response.Write("<script>alert('没有查询到该数据');</script>");
        }
        //封装数据库语句，接下来的每条新的sql语句联动DataReader就都可以用这个方法,这是对代码整体的一个优化
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string sql = $"select empno from empno where empno='{TextBox1.Text}' or ename='{TextBox2.Text}' or eclass='{TextBox3.Text}' or eemail='{TextBox4.Text}'";

            openDatabase();
            SqlCommand command = new SqlCommand(sql, conn);

            SqlDataReader dr = command.ExecuteReader();


            if (TextBox1.Text == "" && TextBox3.Text == "" && TextBox4.Text == "")
            {
                if (!dr.Read())
                {
                    Response.Write("<script>alert('没有查询到该数据');</script>");
                }
                else
                {
                    var sql2 = $"select empno,ename,eclass,eemail,etelphone from empno where ename like '%{TextBox2.Text}%'";
                    sql2 = string.Format(sql2, TextBox2.Text.Trim());
                    SqlDataSource1.SelectCommand = sql2;
                    GridView1.DataSourceID = SqlDataSource1.ID;
                    GridView1.DataBind();
                }
            }
            else if (TextBox2.Text == "" && TextBox3.Text == "" && TextBox4.Text == "")
            {
                if (!dr.Read())
                {
                    Response.Write("<script>alert('没有查询到该数据');</script>");
                }
                else
                {
                    var sql1 = $"select empno,ename,eclass,eemail,etelphone from empno where empno like '%{TextBox1.Text}%'";
                    sql1 = string.Format(sql1, TextBox1.Text.Trim());
                    SqlDataSource1.SelectCommand = sql1;
                    GridView1.DataSourceID = SqlDataSource1.ID;
                    GridView1.DataBind();
                }

            }
            else if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox4.Text == "")
            {
                if (!dr.Read())
                {
                    Response.Write("<script>alert('没有查询到该数据');</script>");
                }
                else
                {
                    var sql3 = $"select empno,ename,eclass,eemail,etelphone from empno where eclass like '%{TextBox3.Text}%'";
                    sql3 = string.Format(sql3, TextBox3.Text.Trim());
                    SqlDataSource1.SelectCommand = sql3;
                    GridView1.DataSourceID = SqlDataSource1.ID;
                    GridView1.DataBind();
                }
            }
            else if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "")
            {
                if (!dr.Read())
                {
                    Response.Write("<script>alert('没有查询到该数据');</script>");
                }
                else
                {
                    var sql4 = $"select empno,ename,eclass,eemail,etelphone from empno where eemail like '%{TextBox4.Text}%'";
                    sql4 = string.Format(sql4, TextBox4.Text.Trim());
                    SqlDataSource1.SelectCommand = sql4;
                    GridView1.DataSourceID = SqlDataSource1.ID;
                    GridView1.DataBind();
                }
            }
            else if (TextBox2.Text == "" && TextBox4.Text == "")
            {
                string sql11 = $"select empno,eclass from empno where empno='{TextBox1.Text}' and eclass='{TextBox3.Text}'";
                load(sql11);
                var sql5 = $"select empno,ename,eclass,eemail,etelphone from empno where empno like '%{TextBox1.Text}%' and eclass like '%{TextBox3.Text}%' ";
                sql5 = string.Format(sql5, TextBox1.Text.Trim(), TextBox3.Text.Trim());
                SqlDataSource1.SelectCommand = sql5;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }
            else if (TextBox1.Text == "" && TextBox4.Text == "")
            {
                string sql12 = $"select ename,eclass from empno where ename='{TextBox2.Text}' and eclass='{TextBox3.Text}'";
                load(sql12);
                var sql6 = $"select empno,ename,eclass,eemail,etelphone from empno where ename like '%{TextBox2.Text}%' and eclass like '%{TextBox3.Text}%'";
                sql6 = string.Format(sql6, TextBox2.Text.Trim(), TextBox3.Text.Trim());
                SqlDataSource1.SelectCommand = sql6;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }
            else if (TextBox4.Text == "" && TextBox1.Text !=""&&TextBox2.Text!=""&&TextBox3.Text!="")//TestBox4为空而其它不为空，不然会和上面的if语句中有TestBox4为空的语句触发
            {
                string sql13 = $"select empno,ename,eclass from empno where empno='{TextBox1.Text}'and ename='{TextBox2.Text}' and eclass='{TextBox3.Text}' ";
                load(sql13);
                var sql7 = $"select empno,ename,eclass,eemail,etelphone from empno where empno like '%{TextBox1.Text}%' and ename like '%{TextBox2.Text}%' and eclass like '%{TextBox3.Text}%'";
                sql7 = string.Format(sql7, TextBox1.Text.Trim(), TextBox2.Text.Trim(), TextBox3.Text.Trim());
                SqlDataSource1.SelectCommand = sql7;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }
            else if (TextBox3.Text == "" && TextBox4.Text == "")
            {
                string sql14 =$"select empno,ename from empno where empno='{TextBox1.Text}' and ename='{TextBox2.Text}'";
                load(sql14);
                var sql8 = $"select empno,ename,eclass,eemail,etelphone from empno where empno like '%{TextBox1.Text}%' and ename like '%{TextBox2.Text}%'";
                sql8 = string.Format(sql8, TextBox1.Text.Trim(), TextBox2.Text.Trim());
                SqlDataSource1.SelectCommand = sql8;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }
            else
            {
                string sql16 = $"select empno,ename,eclass,eemail from empno where empno='{TextBox1.Text}' and ename='{TextBox2.Text}' and eclass='{TextBox3.Text}' and eemail='{TextBox4.Text}'";
                load(sql16);
                var sql10 = $"select empno,ename,eclass,eemail,etelphone from empno where empno like '%{TextBox1.Text}%' and  ename like '%{TextBox2.Text}%' and eclass like '%{TextBox3.Text}%' and eemail like '%{TextBox4.Text}%'";
                sql10 = string.Format(sql10, TextBox1.Text.Trim(), TextBox2.Text.Trim(), TextBox3.Text.Trim(), TextBox4.Text.Trim());
                SqlDataSource1.SelectCommand = sql10;
                GridView1.DataSourceID = SqlDataSource1.ID;
                GridView1.DataBind();
            }
        }
        catch
        {
            Response.Write("<script>alert('触发catch,还有BUG,待解决');</script>");
        }
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string sql = "select empno,ename,eclass,eemail,etelphone from empno";
        ShowTable(sql);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string sql = $"insert into empno(empno,ename,eclass,eemail,etelphone) values('{TextBox1.Text.ToString().Trim()}','{TextBox2.Text.ToString().Trim()}','{TextBox3.Text.ToString().Trim()}','{TextBox4.Text.ToString().Trim()}')  ";
        ShowTable(sql);
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)//编辑时点击更新产生的事件,CommandField是命令列的意思,保存已经被编辑的数据，从编辑状态退出，回到原来的GridView正常状态
    {
        
        TextBox a = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[1];
        Response.Write(a.Text);
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)//进入编辑状态
    {
        //GridView1.EditIndex = e.NewEditIndex;
        //string sql = "select * from empno";
        //ShowTable(sql);

    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//放弃已经编辑的数据，从编辑状态退出，回到原来的GridView正常状态
    {
        //GridView1.EditIndex = -1;
        //string sql = "select * from empno";
        //ShowTable(sql);
    }
}
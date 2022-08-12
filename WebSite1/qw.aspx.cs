using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie empno = new HttpCookie("empno");
        HttpCookie ename = new HttpCookie("ename",System.Web.HttpContext.Current.Server.UrlEncode("我是你爸"));
        HttpCookie eclass = new HttpCookie("eclass");
        HttpCookie eemail = new HttpCookie("eemail");
        HttpCookie etelphone = new HttpCookie("etelphone");
        empno.Value = TextBox1.Text;
        ename.Value = TextBox2.Text;
        eclass.Value = TextBox3.Text;
        eemail.Value = TextBox4.Text;
        etelphone.Value = TextBox5.Text;
        Response.AppendCookie(empno);
        Response.AppendCookie(ename);
        Response.AppendCookie(eclass);
        Response.AppendCookie(eemail);
        Response.AppendCookie(etelphone);
        Response.Redirect("Default.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = new HttpCookie("ename", System.Web.HttpContext.Current.Server.UrlEncode("雨林星空"));
        Response.Cookies.Add(cookie);

    }
}
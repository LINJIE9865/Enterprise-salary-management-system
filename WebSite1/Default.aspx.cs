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
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["ename"] != null)

        {

            Response.Write(System.Web.HttpContext.Current.Server.UrlDecode(Request.Cookies["ename"].Value));

        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
      
        HttpCookie empno = Request.Cookies["empno"];
        HttpCookie ename = Request.Cookies["ename"];
        HttpCookie eclass = Request.Cookies["eclass"];
        HttpCookie eemail = Request.Cookies["eemail"];
        HttpCookie etelphone = Request.Cookies["etelphone"];
        String str1 = empno.Value.ToString();
        String str2 = ename.Value.ToString();
        String str3 = eclass.Value.ToString();
        //String str4 = eemail.Value.ToString();
        String str5 = etelphone.Value.ToString();
        TextBox1.Text = str1;
        TextBox2.Text = str2;
        TextBox3.Text = str3;
        //TextBox4.Text = str4;
        TextBox5.Text = str5;
        string sql = $"select * from empno={TextBox1.Text}";

    }
}
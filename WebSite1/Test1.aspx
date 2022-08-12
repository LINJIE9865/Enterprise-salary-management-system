<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Test2.css" rel="stylesheet"/>
    <title>组织架构</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
              <div class="header">
                <h1>薪酬管理系统</h1>
            </div>
                  <div class="nav">
                <a href="Test1.aspx">导航项</a>
                <a href="Test2.aspx">导航项</a>
                <a href="http://www.baidu.com">导航项</a>
                <a href="http://www.baidu.com">导航项</a>
                <a href="http://www.baidu.com">导航项</a>
            </div>
            <div class="container">
                  <div class="one">
                <h1>岗位信息查询</h1>
                <asp:Label ID="Label1" runat="server" Text="岗位名称："></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="所在部门："></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" />
            </div>
            <div class="two">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridView1_PageIndexChanging" Width="797px" AllowSorting="True" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="postname" HeaderText="岗位名称" SortExpression="postname" />
                        <asp:BoundField DataField="class" HeaderText="所在部门" SortExpression="class" />
                        <asp:BoundField DataField="postshow" HeaderText="岗位描述" SortExpression="postshow" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:masterConnectionString %>" SelectCommand="SELECT * FROM [post]"></asp:SqlDataSource>
            </div>
            </div> 
                <div class="footer">
                <p>
                    网页底部，主要用来放链接
                </p>
            </div>
        </div>
    </form>
</body>
</html>

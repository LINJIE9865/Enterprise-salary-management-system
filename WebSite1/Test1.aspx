<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test1.aspx.cs" Inherits="Test1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>组织架构</title>
    <style>
        .big{
            width:1000px;
            height:800px;
            border:1px solid #666;
        }

        .one{
            width:800px;
            height:200px;
            margin-left:50px;
            margin-top:50px;
            border:1px solid black;
        }

        .two{
            width:800px;
            height:500px;
            margin-left:50px;
            margin-top:20px;
            border:1px solid black;
        }

        .nav{
            float:left;
            width:100%;
            background-color:#333;
        }

        .nav a{
               color:#fff;
               padding:10px 20px;
               display:inline-block;/*让链接以块的形式存在*/
}
        .nav a:hover{
                 background-color:#bbb;
                 color:#000;
                     }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="big">
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
            <div class="nav">
                <a href="http://www.baidu.com">导航项</a>
                <a href="Test2.aspx">导航项</a>
                <a href="http://www.baidu.com">导航项</a>
                <a href="http://www.baidu.com">导航项</a>
                <a href="http://www.baidu.com">导航项</a>
            </div>
        </div>
    </form>
</body>
</html>

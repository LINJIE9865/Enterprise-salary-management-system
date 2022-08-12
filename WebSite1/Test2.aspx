<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test2.aspx.cs" Inherits="Test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>员工信息</title>
    <link href="Test2.css" rel="stylesheet"/>
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
                    <h1>员工信息查询</h1>
                 <asp:Label ID="Label1" runat="server" Text="员工号："></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="姓名："></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label3" runat="server" Text="部门："></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                    <asp:Label ID="Label4" runat="server" Text="邮件账号："></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" />
                </div>
                <div class="two">
                    <div class="two-one">
                        <asp:Button ID="Button3" runat="server" Text="新增员工" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Text="删除员工" />
                    </div>
                    <div class="two-two">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
                            <Columns>
                                <asp:BoundField DataField="empno" HeaderText="员工号" SortExpression="empno" />
                                <asp:BoundField DataField="ename" HeaderText="姓名" SortExpression="ename" />
                                <asp:BoundField DataField="eclass" HeaderText="部门" SortExpression="eclass" />
                                <asp:BoundField DataField="eemail" HeaderText="邮件账号" SortExpression="eemail" />
                                <asp:BoundField DataField="etelphone" HeaderText="电话号码" SortExpression="etelphone" />
                                <asp:CommandField HeaderText="编辑" ShowEditButton="True" ShowHeader="True" />
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ShowHeader="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:masterConnectionString2 %>" SelectCommand="SELECT [empno], [ename], [eclass], [eemail], [etelphone] FROM [empno]"></asp:SqlDataSource>
                    </div>
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

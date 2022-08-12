<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qw.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="员工号："></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="姓名："></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="所在部门"></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="邮箱账号"></asp:Label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" Text="电话号码"></asp:Label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>

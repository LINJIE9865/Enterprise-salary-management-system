<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
       <asp:Label ID="Label1" runat="server" Text="账号："></asp:Label>
       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
       <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
       <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox><br />
       <asp:Label ID="Label3" runat="server" Text="普通用户："></asp:Label> <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="RadioButtons" />
       <asp:Label ID="Label4" runat="server" Text="超级用户："></asp:Label><asp:RadioButton ID="RadioButton2" runat="server" GroupName="RadioButtons" />
       <asp:Label ID="Label5" runat="server" Text="管理员："></asp:Label><asp:RadioButton ID="RadioButton3" runat="server" GroupName="RadioButtons" /><br />
       <asp:Button ID="Button5" runat="server" Text="登录" OnClick="Button5_Click" /><br />
       <asp:Button ID="Button6" runat="server" Text="注册" OnClick="Button6_Click" /><br />
       <asp:Button ID="Button1" runat="server" Text="增" OnClick="Button1_Click" />
       <asp:Button ID="Button2" runat="server" Text="删" OnClick="Button2_Click" />
       <asp:Button ID="Button3" runat="server" Text="改" OnClick="Button3_Click" />
       <asp:Button ID="Button4" runat="server" Text="查" OnClick="Button4_Click" />
    </form>
</body>
</html>

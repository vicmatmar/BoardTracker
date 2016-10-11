<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page_login.aspx.cs" Inherits="Page_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Form_login" runat="server">
    <div>
        <table>
            <tr>
                <td>Username: <asp:DropDownList ID="DropDownList_userName" runat="server" OnLoad="DropDownList_userName_Load"></asp:DropDownList></td>
                <td>Pin:<asp:TextBox ID="TextBox_pin" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="Button_login" runat="server" Text="Login" OnClick="Button_login_Click"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label_msg" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

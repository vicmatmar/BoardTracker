<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page_boardEntry.aspx.cs" Inherits="Page_boardEntry"%>
<%@ Reference Page="~/Page_login.aspx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Form_boardEntry" runat="server">
    <div>
    <asp:Label runat="server" ID="Label_username" Text=""></asp:Label>
    </div>
        <div>
            <asp:TextBox runat="server" ID="Textbox_serial" OnTextChanged="Textbox_serial_TextChanged"></asp:TextBox>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page_boardEntry.aspx.cs" Inherits="Page_boardEntry" %>

<%@ Reference Page="~/Page_login.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Form_boardEntry" runat="server">
        <div>
            <asp:Label runat="server" ID="Label2" Text="Enter serial number"></asp:Label>
        </div>
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <asp:TextBox runat="server" ID="Textbox_serial" OnTextChanged="Textbox_serial_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Label ID="Label_Msg" runat="server" Text="Label" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

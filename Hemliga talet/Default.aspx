<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hemliga_talet.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>
        Gissa det hemliga talet
    </h1>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <p>Ange ett tal mellan 1 och 100</p>
        <asp:TextBox ID="GuessTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett tal måste anges" Display="Dynamic" ControlToValidate="GuessTextBox" Text="*"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer" ControlToValidate="GuessTextBox" Text="*"></asp:RangeValidator>
        <asp:Button ID="Button1" runat="server" Text="Skicka gissning" OnClick="Button1_Click"/>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <asp:Label ID="GuessLabel" runat="server" Text="Label"></asp:Label>
        </asp:PlaceHolder>
    </div>
    </form>
</body>
</html>

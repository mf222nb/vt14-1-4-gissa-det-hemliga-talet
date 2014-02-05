<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hemliga_talet.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <header class="header">
        <h1>
            Gissa det hemliga talet
        </h1>
    </header>
        <asp:ValidationSummary ID="MyValidationSummary" runat="server" />
        <p>Ange ett tal mellan 1 och 100</p>
        <asp:Panel ID="Panel1" runat="server">
            <asp:TextBox ID="GuessTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="MyRequiredFieldValidator" runat="server" ErrorMessage="Ett tal måste anges" Display="Dynamic" ControlToValidate="GuessTextBox" Text="*"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="MyRangeValidator" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer" ControlToValidate="GuessTextBox" Text="*"></asp:RangeValidator>
            <asp:Button ID="Button1" runat="server" Text="Skicka gissning" OnClick="Button1_Click"/>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                <div>
                    <asp:Label ID="PreviousLabel" runat="server" Text=""></asp:Label>
                </div>
                <asp:Label ID="GuessLabel" runat="server" Text=""></asp:Label>
            </asp:PlaceHolder>
        </asp:Panel>
        <asp:Button ID="ResetButton" runat="server" Text="Slumpa ett nytt heltal" Visible="false" OnClick="ResetButton_Click"/>
    </div>
    </form>
</body>
</html>

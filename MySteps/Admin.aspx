<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .gridview {
    width: 100%; 
    word-wrap:break-word;
    table-layout: fixed;
}
    </style>
</head>
<body style="background-color:peachpuff">
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnUserData" runat="server" Text="Show User Data Table" OnClick="btnUserData_Click" />
    
        <asp:Button ID="btnScrnTimData" runat="server" Text="Show Screen Time Table" OnClick="btnScrnTimData_Click" />
    
        <asp:Button ID="btnPhysicalData" runat="server" Text="Show Physical Activity Table" OnClick="btnPhysicalData_Click" />
        <asp:Button ID="btnGameData" runat="server" Text="Show Game Data Table" OnClick="btnGameData_Click" />
        <asp:Button ID="btnUserLevels" runat="server" Text="Show User Levels Table" OnClick="btnUserLevels_Click" />
    
        <asp:Button ID="btnUserPhysicalScreen" runat="server" Text="Show User, Physical & Screen Data" OnClick="btnUserPhysicalScreen_Click" />
        <asp:Button ID="btnUserGameLevels" runat="server" Text="Show User, Game & Levels Data" OnClick="btnUserGameLevels_Click" />
    
        <asp:Button ID="btnForum" runat="server" Text="Show Forum Data" OnClick="btnForum_Click" />
        <asp:Button ID="btnThread" runat="server" Text="Show Thread Data" OnClick="btnThread_Click" />
    
        <asp:Button ID="btnReminder" runat="server" Text="Send a Reminder" OnClick="btnReminder_Click" />
    
        <asp:TextBox ID="txbUserId" runat="server"></asp:TextBox>
    
    </div>
    
        <asp:Label ID="lblError" runat="server"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server"
            BorderStyle="Outset" RowStyle-Wrap="true" 
            RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
            class="gridview" BorderColor="#333333" BorderWidth="2"
            Font-Name="cambria"
                Font-Size="10pt" Cellpadding="4"
            HeaderStyle-BackColor="#444444"
            HeaderStyle-ForeColor="White"
                AlternatingRowStyle-BackColor="#dddddd">
<RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="20px"></RowStyle>
        </asp:GridView>
    </form>
</body>
</html>

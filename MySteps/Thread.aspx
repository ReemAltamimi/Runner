<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Thread.aspx.cs" Inherits="Thread" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="answer" HeaderText="answer" SortExpression="answer" />
                <asp:BoundField DataField="posterName" HeaderText="posterName" SortExpression="posterName" />
                <asp:BoundField DataField="dateTim" HeaderText="dateTim" SortExpression="dateTim" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" SelectCommand="SELECT [answer], [posterName], [dateTim] FROM [Thread]"></asp:SqlDataSource>
    
    </div>
        <asp:TextBox ID="txbComment" runat="server" Height="60px" TextMode="MultiLine" Width="300px"></asp:TextBox>
        <p>
            <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnComment" runat="server" OnClick="btnComment_Click" Text="Post Comment" />
        </p>
    </form>
</body>
</html>

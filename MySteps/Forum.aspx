<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Forum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="titleId">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" SelectCommand="SELECT [titleId], [title] FROM [Title]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="forumId" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="forumId" HeaderText="forumId" InsertVisible="False" ReadOnly="True" SortExpression="forumId" />
                <asp:BoundField DataField="question" HeaderText="question" SortExpression="question" />
                <asp:BoundField DataField="posterName" HeaderText="posterName" SortExpression="posterName" />
                <asp:BoundField DataField="dateTim" HeaderText="dateTim" SortExpression="dateTim" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="select" Text="View Comment" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" SelectCommand="SELECT [forumId], [question], [posterName], [dateTim] FROM [Forum] WHERE ([titleId] = @titleId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="titleId" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:TextBox ID="txbQuestion" runat="server" Height="47px" TextMode="MultiLine" Width="395px"></asp:TextBox>
    
    </div>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txbName" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" Text="Post" />
        </p>
    </form>
</body>
</html>

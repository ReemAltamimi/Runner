<%@ Page Title="Leaderboard Game Levels Details" Language="C#" MasterPageFile="~/Master Page/MasterPage.master" AutoEventWireup="true" CodeFile="Leaderboard2.aspx.cs" Inherits="Leaderboard2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">

    <div>

    <asp:Label ID="lblName" runat="server" Font-Bold ="true" Font-Names="Cambria" 
        ForeColor="White" style ="max-width:650px; text-align:justify; 
                position:absolute; left: 2vw; top:3vh" ></asp:Label>

      <asp:GridView ID="GridView1" runat="server" style="position:absolute; left: 4vw; top:10vh; vertical-align:middle"
            BorderStyle="Outset" RowStyle-Wrap="true" 
            RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Middle"
            class="gridview" BorderColor="#333333" BorderWidth="2"
            Font-Name="cambria"
                Font-Size="10pt" Cellpadding="4"
            HeaderStyle-BackColor="#009933"
            HeaderStyle-ForeColor="White"
                AlternatingRowStyle-BackColor="#dddddd" HorizontalAlign="Center" Width="300px" AllowPaging="False" BackColor="#DDDDDD">

            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="20px"></RowStyle>
        
          </asp:GridView>

    <a href="Leaderboard.aspx" style="position:absolute; left:40vw; top:64vh">Back to Main Leaderboard</a>
   
        
    </div>    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>


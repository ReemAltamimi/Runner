<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Thread.aspx.cs" Inherits="Thread"  MasterPageFile="~/Master Page/MasterPage.master" Title="Thread Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <style type="text/css">

       #rightSidePanel
    {
        display:none;
    }
      #leftSidePanel
    {
        display:none;
    }

        /*div1 style*/
        .style3 {
          width: 70vw;
            height: 70vh;
            position: fixed;
             left:1vw;
            top: 22vh;
            background:#adaaaa;
        }
          /*div2 style*/
        .style4 {
          width: 25vw;
            height: 70vh;
            position: fixed;
            top: 22vh;
            left: 72vw;
            background:#adaaaa;
        }
         </style>

 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">


    
    <div class="style3">
        <asp:Label ID="Label3" runat="server" Text="Answer of " Font-Bold="True" style="text-align:center"
            Font-Names="Comic Sans MS" Font-Size="Medium" ForeColor="Maroon" Height="50px"></asp:Label>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" Width="873px" RowStyle-VerticalAlign="Middle" RowStyle-HorizontalAlign="Center" BorderColor="Maroon" BorderStyle="Outset" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="answer" HeaderText="Answer" SortExpression="answer" />
                <asp:BoundField DataField="posterName" HeaderText="Poster" SortExpression="posterName" />
                <asp:BoundField DataField="dateTim" HeaderText="Date and Time" SortExpression="dateTim" />
            </Columns>
            <EditRowStyle BackColor="White" BorderColor="#6600FF" BorderStyle="Outset" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle BackColor="#990033" Font-Bold="True" ForeColor="White" BorderColor="#666666" BorderStyle="Outset" Height="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" BorderColor="#666666" BorderStyle="Outset" Height="35px" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" SelectCommand="SELECT [answer], [posterName], [dateTim] FROM [Thread] WHERE ([forumId] = @forumId)">
            <SelectParameters>
                <asp:SessionParameter Name="forumId" SessionField="forumId" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>

         <div class="style4">

            <asp:Label ID="Label2" runat="server" Text="New comment  " Font-Bold="True" 
            Font-Names="Comic Sans MS" Font-Size="Medium" ForeColor="Maroon" Height="50px"
                style="text-align:center; position:fixed; left:74vw; top: 23vh"></asp:Label>

               <asp:TextBox ID="txbComment" runat="server" Height="149px" TextMode="MultiLine" 
                   Width="273px" BorderStyle="Outset" style="position:fixed; left:74vw; top:30vh"></asp:TextBox>
    

             <asp:Label ID="Label1" runat="server" Text="My Name"
                 Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Small" 
                 ForeColor="Maroon" Height="50px" 
                 style="text-align:center; position:fixed; left:74vw; top:60vh"></asp:Label>

            <asp:TextBox ID="txbName" runat="server" style="position:fixed; left:80vw; top:60vh">

            </asp:TextBox>
     
            <asp:Button ID="btnComment" runat="server" OnClick="btnComment_Click" 
                BackColor="#006666" Font-Names="Cooper Black" ForeColor="white" Text="Post Comment"
                style="position:fixed; left:80vw; top:75vh" Width="140" Height="50px"  />
        
             <a href="Forum.aspx" style="position:fixed; left:79vw; top:85vh">Back to Discussion page</a>
        
        </div>

      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>
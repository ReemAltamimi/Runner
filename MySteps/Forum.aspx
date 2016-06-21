<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Forum" MasterPageFile="~/Master Page/MasterPage.master" Title="Discussion Board" %>

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

        <asp:Label ID="Label1" runat="server" Text="My question is about " Font-Bold="True" 
            Font-Names="Comic Sans MS" Font-Size="Medium" ForeColor="Maroon" Height="50px"></asp:Label>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="titleId" Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Medium" ForeColor="Maroon" Height="50px" Width="300px">
        </asp:DropDownList>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" SelectCommand="SELECT [titleId], [title] FROM [Title]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="forumId" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" CellPadding="4" Font-Bold="True" Font-Size="Medium" ForeColor="#333333" GridLines="Horizontal" Width="923px" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="forumId" HeaderText="forumId" InsertVisible="False" ReadOnly="True" SortExpression="forumId" />
                <asp:BoundField DataField="question" HeaderText="Question" SortExpression="question" />
                <asp:BoundField DataField="posterName" HeaderText="Poster" SortExpression="posterName" />
                <asp:BoundField DataField="dateTim" HeaderText="date and Time" SortExpression="dateTim" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CommandName="select" Text="View Comment" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" SelectCommand="SELECT [forumId], [question], [posterName], [dateTim] FROM [Forum] WHERE ([titleId] = @titleId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="titleId" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
     
    </div>

        <div class="style4">

            <asp:Label ID="Label2" runat="server" Text="My question is  " Font-Bold="True" 
            Font-Names="Comic Sans MS" Font-Size="Medium" ForeColor="Maroon" Height="50px"
                style="text-align:center; position:fixed; left:74vw; top: 23vh"></asp:Label>

               <asp:TextBox ID="txbQuestion" runat="server" Height="149px" TextMode="MultiLine" 
                   Width="273px" BorderStyle="Outset" style="position:fixed; left:74vw; top:30vh"></asp:TextBox>
    

             <asp:Label ID="lblName" runat="server" Text="My Name"
                 Font-Bold="True" Font-Names="Comic Sans MS" Font-Size="Small" 
                 ForeColor="Maroon" Height="50px" 
                 style="text-align:center; position:fixed; left:74vw; top:60vh"></asp:Label>

            <asp:TextBox ID="txbName" runat="server" style="position:fixed; left:80vw; top:60vh">

            </asp:TextBox>
     
            <asp:Button ID="btnPost" runat="server" OnClick="btnPost_Click" 
                BackColor="#006666" Font-Names="Cooper Black" ForeColor="white" Text="Post"
                style="position:fixed; left:80vw; top:75vh" Width="140" Height="50px"  />

           <a href="Main.aspx" style="position:fixed; left:81vw; top:85vh">Back to Main page</a>
        
        

        </div>

      </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>
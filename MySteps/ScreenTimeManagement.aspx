<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScreenTimeManagement.aspx.cs" Inherits="ScreenTimeManagement" MasterPageFile="~/Master Page/MasterPage.master" Title="Screen Time Management Page" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <style type="text/css">

        /*Textbox style*/
        .style4 {
            position:fixed; 
           left: 25vw;
           top:52vh;
        }
        /*Chart Div Style*/
        .style5 {
           position:fixed;
           top:22vh;
          /*width:20vw*/ 
        }
       
     </style>

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">

       <div class="style5">
            <asp:Chart ID="ScreenTimeChart" runat="server" DataSourceID="SqlDataSource1" Visible="False"  Width="300px" Height="480px" BackColor="#ffff99">
                <series>
                    <asp:Series Name="UserScreenAmount" XValueMember="Date" YValueMembers="UserScreenDailyAmnt" XValueType="DateTime" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Screen Time Amount">
                    </asp:Series>
                    <asp:Series Name="ScreenLimit" XValueMember="Date" YValueMembers="ScreenDailyLimit" XValueType="DateTime" YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Screen Time Limit" >
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
                <Legends>
                    <asp:Legend Name="Legend1" Docking="Bottom">
                    </asp:Legend>
                </Legends>
            </asp:Chart>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" 
                SelectCommand="SELECT * FROM [ScreenTimeData] WHERE (([UserID] = @UserID) AND ([Date] = @Date))">
                <SelectParameters>
                    <asp:SessionParameter Name="UserID" SessionField="UserId" Type="Int32" />
                    <asp:SessionParameter Name="Date" SessionField="LastTime" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" Runat="Server">
     <div>

            <asp:Label ID="Label1" runat="server" Text="Screen Time Management" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 25vw; top:30vh" ForeColor="#FFFF99" Font-Size="XX-Large"></asp:Label>

            <asp:Label ID="Label2" runat="server" Text="How many hours you spent today in front of screen:" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 25vw; top:42vh" Font-Underline="True"></asp:Label>

            <asp:TextBox ID="txbScreenUnits" runat="server" Width="200px" CssClass="style4" ></asp:TextBox>

            <asp:Button ID="btnSubmit" runat="server" Width="120" Text="Submit"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:45vw; top:84vh" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnViewChart" runat="server" Width="120" Text="View Chart"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:30vw; top:84vh" OnClick="btnViewChart_Click" />
           

            <asp:Label ID="Label3" runat="server" Text="" Font-Bold ="true" ForeColor="red"
                 Font-Names="Cambria" style ="position:fixed; left: 25vw; top:62vh" Width="500"
                 BackColor="White"></asp:Label>

        </div>
        
     
          <a href="Main.aspx" style="position:fixed; left:60vw; top:85vh">Back to Main page</a>
   
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

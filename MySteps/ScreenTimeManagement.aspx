<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScreenTimeManagement.aspx.cs" Inherits="ScreenTimeManagement" MasterPageFile="~/Master Page/MasterPage.master" Title="Screen Time Management Page" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <style type="text/css">

        /*Textbox style*/
        .style4 {
            position:absolute; 
           left: 2vw;
           top:25vh;
        }
        /*Chart Div Style*/
        .style5 {
           position:absolute;
           top:0;
           left:0;
        }
        .Chart
        {
            position:absolute; 
            top:0; 
            left:0;   
            vertical-align: middle;
            min-height: 70vh; 
            min-width: 20vw; 
            max-height: 70vh; 
            max-width: 20vw; 
        }
       
     </style>

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphLeft" Runat="Server">

       <div class="style5">
            <asp:Chart ID="ScreenTimeChart" runat="server" DataSourceID="SqlDataSource1" Visible="False" 
                class="Chart" BackColor="#ffff99">
                <series>
                    <asp:Series Name="UserScreenAmount" XValueMember="Date" YValueMembers="UserScreenDailyAmnt" XValueType="DateTime" YValueType="Single"
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
                 Font-Names="Comic Sans MS" style ="position:absolute; left: 2vw; top:3vh" ForeColor="#FFFF99" Font-Size="XX-Large"></asp:Label>

            <asp:Label ID="Label2" runat="server" Text="How many hours you spent today in front of screen:" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:absolute; left: 2vw; top:15vh" Font-Underline="True"></asp:Label>

            <asp:TextBox ID="txbScreenUnits" runat="server" Width="200px" CssClass="style4" ></asp:TextBox>

             <asp:Label ID="Label4" runat="server" Text="Hours ( In Total )" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:absolute; left: 22vw; top:25vh" Font-Underline="True" ForeColor="Maroon"></asp:Label>

          <asp:Label ID="Label3" runat="server" Text="" Font-Bold ="true" ForeColor="red"
                 Font-Names="Cambria" style ="position:absolute; left: 4vw; top:35vh; text-align:center;" Width="650"
                 BackColor="White"></asp:Label>


            <asp:Button ID="btnSubmit" runat="server" Width="120" Text="Submit"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:absolute; left:10vw; top:50vh" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnViewChart" runat="server" Width="120" Text="View Chart"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:absolute; left:25vw; top:50vh" OnClick="btnViewChart_Click" />
           

           
        </div>
        
     
          <a href="Main.aspx" style="position:absolute; left:40vw; top:60vh">Back to Main page</a>
   
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

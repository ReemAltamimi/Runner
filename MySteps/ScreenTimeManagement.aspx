<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScreenTimeManagement.aspx.cs" Inherits="ScreenTimeManagement" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Screen Time Management Page</title>
    <style type="text/css">
        /*Title banner style*/
        .style1 {
           width: 100vw;
            height: 20vh;
            position:fixed;
            background-color:#adaaaa;
        }
        /*Page style*/
        .style2 {
            background-color:#004080;
        }
        /*Middle div style*/
        .style3 {
          width: 50vw;
            height: 70vh;
            position: fixed;
            top: 22vh;
            left:24vw;   
            background:#adaaaa;
        }
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
</head>
<body class="style2">
    <form id="form1" runat="server">
    <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style="text-align:center; position:fixed; left:20vw; top:5vh" />

    </div>
 
        <div class="style3">

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
                 Font-Names="Cambria" style ="position:fixed; left: 25vw; top:62vh"></asp:Label>

        </div>
        
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

       <div style="position:fixed; left:76vw; top:22vh;  width:20vw; height:80vh">
            <asp:Image ID="Image2" runat="server"  Width="300px" Height="480px" ImageUrl="~/Images/ScreenTime1.png" />
     </div>
          <a href="Main.aspx" style="position:fixed; left:60vw; top:85vh">Back to home page</a>
   
    </form>
</body>
</html>

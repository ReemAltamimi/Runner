<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhysicalActivityManagement.aspx.cs" Inherits="MySteps.PhysicalActivityManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physical Activity Management</title>
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
        /*Chart Div Style*/
        .style5 {
            position:fixed;
           top:22vh;
        }

     </style>
</head>
<body class="style2">
    <form id="form1" runat="server">
        <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style=" text-align:center; position:fixed; left:20vw; top:5vh" />

    </div>
        <div class="style3">
            <asp:Label ID="Label1" runat="server" Text="Physical Activity Statistics" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 25vw; top:30vh" ForeColor="#FFCCCC" Font-Size="XX-Large"></asp:Label>
            
             <asp:Label ID="Label4" runat="server" Text="Based on your Fitbit data" Font-Names="Comic Sans MS" 
                            Font-Bold="True" ForeColor="#004080" Font-Underline="true"
                  style="position:fixed; left: 25vw; top:42vh">
                  </asp:Label>

              <asp:Label ID="Label2" runat="server" Text="Your Fitbit Data" Font-Names="Comic Sans MS" 
                            Font-Bold="True" ForeColor="#004080"
                  style="position:fixed; left: 25vw; top:45vh">

              </asp:Label>

     
            
            <asp:Button ID="btnViewChart" runat="server" Width="150" Text="View Chart"
                             BackColor="#adaaaa" Font-Bold="True" Font-Names="Cambria" Font-Size="Medium"
                                style="position:fixed; left:30vw; top:84vh" OnClick="btnViewChart_Click" />

        </div>
   
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" 
            SelectCommand="SELECT * FROM [PhysicalActivityData] WHERE (([UserID] = @UserID) AND ([DateAndTime] = @DateAndTime))">
            <SelectParameters>
                <asp:SessionParameter Name="UserID" SessionField="UserId" Type="Int32" />
                <asp:SessionParameter Name="DateAndTime" SessionField="DateTime" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
 
        <div class="style5" >
        <asp:Chart ID="PhysicalActivityChart" runat="server" Visible="False" Width="300px" Height="480px" 
            DataSourceID="SqlDataSource1" BackColor="#ffcccc">
            <Series>
                <asp:Series Name="UserPhysicalSteps" XValueMember="DateAndTime" YValueMembers="DailySteps" XValueType="DateTime" YValueType="Int32"
                        Color="Red" Legend="Legend1" LegendText="Your Physical Steps" IsValueShownAsLabel="True" Label="#VAL Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedStepsBoys" XValueMember="DateAndTime" YValueMembers="RecomStepsBoys" YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Steps for Boys" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                <asp:Series Name="RecommendedStepsGirls" XValueMember="DateAndTime" YValueMembers="RecomStepsGirls" YValueType="Int32" Color="Yellow" 
                        Legend="Legend1" LegendText="Recommended Steps for Girls" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
            <Legends>
                    <asp:Legend Name="Legend1" Docking="Bottom">
                    </asp:Legend>
                </Legends>
        </asp:Chart>

            <asp:Label ID="Label3" runat="server" Text="" Font-Names="Comic Sans MS" 
                              ForeColor="#ff0066" Font-Size="Small" 
                style ="position:fixed; left: 25vw; top:62vh" ></asp:Label>

            </div> 
     <div style="position:fixed; top:22vh; width:20vw; height:80vh">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PA_Kids.png" Width="300px" Height="480px" />
     </div>

     <div style="position:fixed; left:76vw; top:22vh;  width:20vw; height:80vh">
            <asp:Image ID="Image2" runat="server"  Width="300px" Height="480px" ImageUrl="~/Images/ScreenTime1.png" />
     </div>

           <a href="Main.aspx" style="position:fixed; left:60vw; top:85vh">Back to home page</a>
   
    </form>
</body>
</html>

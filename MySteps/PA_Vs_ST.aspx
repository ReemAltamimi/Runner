<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA_Vs_ST.aspx.cs" Inherits="PA_Vs_ST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physical Activity Vs Screen Time</title>
    <style type="text/css">
        /*Title banner style*/
        .style1 {
            width: 100%;
            height: 200px;
            position:fixed;
            background-color:#adaaaa;
        }
        /*Page style*/
        .style2 {
            background-color:#004080;
        }
        /*Middle div style*/
        .style3 {
             width: 600px;
            height: 100%;
            position: fixed;
            top: 220px;
            left:30%;
            background:#adaaaa;
        }
        /*Textbox style*/
        .style4 {
            position:fixed; 
            left: 32%; 
            top:500px
        }
        /*Chart Div Style*/
        .style5 {
            position:fixed;
            top:300px;
            left:32%;
        }
       
     </style>
</head>
<body class="style2">
    <form id="form1" runat="server">
    <div class="style1">
        <asp:Label ID="PageTitle" runat="server" Text="MYSTEPS <br/> Managing Youth Screen Time and Exercise Performance Statistics" 
            ForeColor="#004080" Font-Names="Gill Sans Ultra Bold" Font-Size="XX-Large" Font-Bold="true" 
            style=" text-align:center; position:fixed; left:4%; top:80px" />

    </div>
 
        <div class="style3">

            <asp:Label ID="Label1" runat="server" Text="Physical Activity Versus Screen Time" Font-Bold ="True"
                 Font-Names="Comic Sans MS" style ="position:fixed; left: 40%; top:250px" Font-Underline="True" ForeColor="#FFFF99"></asp:Label>


            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:RegisterationConnectionString %>" 
                SelectCommand="SELECT * FROM [PA_And_ST] WHERE (([UserID] = @UserID) AND ([DateAndTime] = @DateAndTime) OR ([DateAndTime] = @DateAndTime2))">
                <SelectParameters>
                    <asp:SessionParameter Name="UserID" SessionField="UserId" Type="Int32" />
                    <asp:SessionParameter Name="DateAndTime" SessionField="LastTimeST" Type="DateTime" />
                    <asp:SessionParameter Name="DateAndTime2" SessionField="LastTimePA" Type="DateTime" />
                </SelectParameters>
            </asp:SqlDataSource>

            <asp:Label ID="Label2" runat="server" Text="" Font-Bold ="True"
                 Font-Names="Comic Sans MS" Font-Size="Small" style ="position:fixed; left: 31%; top:690px" ForeColor="#ff0066"></asp:Label>


        </div>

        <div style="position:fixed; top:220px; width:400px; height:500px; border:8px outset #004080">


            


            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PA_Kids.png" Width="400px" Height="500px"  />


        </div>

        <div style="position:fixed; left:71%; top:220px; width:400px; height:500px; border:8px outset #004080">


            <asp:Image ID="Image2" runat="server"  Width="400px" Height="500px" ImageUrl="~/Images/ScreenTime1.png" />


        </div>

        <div class="style5">

        <asp:Chart ID="PA_Versus_ST" runat="server" DataSourceID="SqlDataSource1" Width="550px" Height="380px" BackColor="#ffff99">
                <Series>
                    <asp:Series Name="UserScreenAmount" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="UserDailyAmnt" XValueType="DateTime" YValueType="Int32"
                        Color="#66ff33" Legend="Legend1" LegendText="Your Screen Time Amount" IsValueShownAsLabel="True" Label="#VAL hours" Font="Andalus, 8.25pt, style=Bold">
                    </asp:Series>
                    <asp:Series Name="RecommendedScreenAmount" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="ScreenDailyLimit" XValueType="DateTime" YValueType="Int32" Color="Green" 
                        Legend="Legend1" LegendText="Recommended Screen Time" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL hours" >
                         </asp:Series>
                    <asp:Series Name="UserPhysicalSteps" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="DailySteps" XValueType="DateTime" YValueType="Int32"
                        Color="#ff0000" Legend="Legend1" LegendText="Your Physical Steps" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL Steps">
                    </asp:Series>
                    <asp:Series Name="RecommendedStepsBoys" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="RecomStepsBoys" YValueType="Int32" Color="#cc0000" 
                        Legend="Legend1" LegendText="Recommended Steps for Boys" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                <asp:Series Name="RecommendedStepsGirls" ChartType="Bar" XValueMember="DateAndTime" YValueMembers="RecomStepsGirls" YValueType="Int32" Color="#800000" 
                        Legend="Legend1" LegendText="Recommended Steps for Girls" Font="Andalus, 8.25pt, style=Bold" IsValueShownAsLabel="True" Label="#VAL Steps" >
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            <Legends>
                    <asp:Legend Name="Legend1">
                    </asp:Legend>
                </Legends>
            </asp:Chart>

            <a href="Main.aspx" style="position:fixed; left:60%; top:700px">Back to main page</a>
            </div>
        
        
    </form>
</body>
</html>
